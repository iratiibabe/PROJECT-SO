#include <string.h>
#include <unistd.h>
#include <stdlib.h>
#include <sys/types.h>
#include <sys/socket.h>
#include <netinet/in.h>
#include <stdio.h>
#include <mysql.h>
#include <pthread.h> //para manejar los threads

#define PORT 9000 // port from which we will listen
#define MAX_CLIENTS 20 // maximum nuber of pending petitions

struct thread_data {
	int sock_conn;
	MYSQL* conn;
	char username[20];
};

pthread_mutex_t mutex = PTHREAD_MUTEX_INITIALIZER;
char connected_players[MAX_CLIENTS][20]; //list for connected players
int player_count = 0;
int client_count = 0;
struct thread_data* sockets[MAX_CLIENTS];

// FUNCTIONS
MYSQL* init_mysql_connection();
void* handle_client(void* data);
void process_request(char* request, char* response, MYSQL* conn, char* username, int sender_sock);
void add_player(char* username);
void remove_player(char* username);
void get_connected_players(char* response);

//DECLARACION DE CONSULTAS
void query1(int numero, char* response, MYSQL* conn);
void query2(char* username, char* response, MYSQL* conn);
void query3(char* username, char* response, MYSQL* conn);
void query4(int numero, char* response, MYSQL* conn);
void register_user(char* username, char* password, char* response, MYSQL* conn);
void login_user(char* username, char* password, char* response, MYSQL* conn);



//FUNCTION TO ADD PLAYER TO THE CONNECTED LIST
void add_player(char* username) {
	pthread_mutex_lock(&mutex);
	if (player_count < MAX_CLIENTS) {
		strcpy(connected_players[player_count], username);
		player_count++;
	}
	pthread_mutex_unlock(&mutex);
}

//FUNCTION TO REMOVE PLAYER FROM THE CONNECTED LIST
void remove_player(char* username) {
	pthread_mutex_lock(&mutex);
	for (int i = 0; i < player_count; i++)
	{
		if (strcmp(connected_players[i], username) == 0) {
			for (int j = i; j < player_count - 1; j++) {
				strcpy(connected_players[j], connected_players[j + 1]);
			}
			player_count--;
			break;
		}
	}
	pthread_mutex_unlock(&mutex);
}

//FUNCTION TO GET THE LIST OF CONNECTED PLAYERS
void get_connected_players(char* response) {
	pthread_mutex_lock(&mutex);
	if (player_count == 0) {
		strcpy(response, "7/No players connected\n");
	}
	else {
		strcpy(response, "7/Connected players: \n");
		for (int i = 0; i < player_count; i++) {
			strcat(response, connected_players[i]);
			strcat(response, "\n");
		}
	}
	pthread_mutex_unlock(&mutex);
}



// CLIENT'S REQUEST
void process_request(char* request, char* response, MYSQL* conn, char* username, int sender_sock) {
    char* p = strtok(request, "/");
    int codigo = atoi(p);
	char password[60];
	char chat_message[200];
    int numero;
	

    switch (codigo) {
        case 1:
			p = strtok(NULL, "/");
			if (p == NULL) {
				strcpy(response, "Invalid request format for code 1\n");
				return;
			}
			numero = atoi(p);
			query1(numero, response, conn);
			break;
        case 2:
			p = strtok(NULL, "/");
			if (p == NULL) {
				strcpy(response, "Invalid request format for code 2\n");
				return;
			}
			strcpy(username, p);
			query2(username, response, conn);
			break;
        case 3:
			p = strtok(NULL, "/");
			if (p == NULL) {
				strcpy(response, "Invalid request format for code 3\n");
				return;
			}
			strcpy(username, p);
			query3(username, response, conn);
			break;
        case 4:
			p = strtok(NULL, "/");
			if (p == NULL) {
				strcpy(response, "Invalid request format for code 4\n");
				return;
			}
			numero = atoi(p);
			query4(numero, response, conn);
			break;
        case 5:
			p = strtok(NULL, "/");
			if (p == NULL) {
				strcpy(response, "Invalid request format for registration\n");
				return;
			}
			strcpy(username, p);
			p = strtok(NULL, "/");
			if (p == NULL) {
				strcpy(response, "Invalid request format for registration\n");
				return;
			}
			strcpy(password, p);
			register_user(username, password, response, conn);
			break;
        case 6:
			p = strtok(NULL, "/");
			if (p == NULL) {
				strcpy(response, "Invalid request format for login\n");
				return;
			}
			strcpy(username, p);
			p = strtok(NULL, "/");
			if (p == NULL) {
				strcpy(response, "Invalid request format for login\n");
				return;
			}
			strcpy(password, p);
			login_user(username, password, response, conn);
			if (strcmp(response, "6/Logged in successfully. \n") == 0) {
				add_player(username);
				printf("%s logged in and added to the list\n", username);
			}
			break;
		case 7:
			printf("Request to list connected players received\n");
			get_connected_players(response);
			break;
			
		case 8: 
			p = strtok(NULL, "/");
			if (p == NULL) {
				strcpy(response, "Invalid format for selected cells\n");
			return;
			}
			select_cells(p, response);
			break;
			
		case 9:
			
			p = strtok(NULL, "/");
			if (p == NULL) {
				strcpy(response, "Invalid request format for login\n");
				return;
			}
			strcpy(username, p);
			p = strtok(NULL, "/");
			if (p == NULL) {
				strcpy(response, "Invalid request format for login\n");
				return;
			}
			strcpy(chat_message, p);
			
			
			broadcast_message_chat(chat_message,username,response, sender_sock);
			
			break;
			
			
			
      
		case 0:
			p = strtok(NULL, "/");
			if (p != NULL) {
				remove_player(p);
				strcpy(response, "End of connection\n");
			}
			else {
				strcpy(response, "Player not specified for disconecction\n");
			}
            break;
		default:
            strcpy(response, "Invalid code\n");
			break;
    }
}

// CLIENT
void* handle_client(void* data) {
	struct thread_data* t_data = (struct thread_data*)data;
	int sock_conn = t_data->sock_conn;
	MYSQL* conn = t_data->conn;
	
	char request[512];
	char response[512];
	int ret;
	int terminar = 0;
	
	while (!terminar) {
		ret = read(sock_conn, request, sizeof(request) -1);
		request[ret] = '\0';
		printf("Received request: %s\n", request);
		
		process_request(request, response, conn, t_data->username,sock_conn);
		write(sock_conn, response, strlen(response));
		
		if (strcmp(request, "0") == 0) {
			terminar = 1;
		}
	}
	close(sock_conn);
	free(t_data); //freeinf memory of the thread data 
	pthread_exit(NULL); //end the thread
}

// QUERY 1 : winner of X match.
void query1(int numero, char* response, MYSQL* conn) {
    char query[400];
    MYSQL_RES* resultado;
    MYSQL_ROW row;

    sprintf(query, "SELECT PLAYERS.USERNAME FROM PLAYERS, MATCHES, PARTICIPATION WHERE PLAYERS.ID = MATCHES.WINNER AND PARTICIPATION.ID_MATCH=MATCHES.ID AND MATCHES.ID=%d;", numero);
    if (mysql_query(conn, query) == 0) {
        resultado = mysql_store_result(conn);
        row = mysql_fetch_row(resultado);
        if (row != NULL) {
            sprintf(response, "1/%s\n", row[0]);
        } else {
            strcpy(response, "1/No data found\n");
        }
        mysql_free_result(resultado);
    }
}

// QUERY 2 : poins of player X
void query2(char* username, char* response, MYSQL* conn) {
    char query[400];
    MYSQL_RES* resultado;
    MYSQL_ROW row;

    sprintf(query, "SELECT POINTS FROM PLAYERS WHERE USERNAME='%s'", username);
    if (mysql_query(conn, query) == 0) {
        resultado = mysql_store_result(conn);
        row = mysql_fetch_row(resultado);
        if (row != NULL) {
            sprintf(response, "2/%s\n", row[0]);
        } else {
            sprintf(response, "2/%s has no points registered.\n", username);
        }
        mysql_free_result(resultado);
    }
}

// QUERY 3 : number of matches X is playing
void query3(char* username, char* response, MYSQL* conn) {
    char query[400];
    MYSQL_RES* resultado;
    MYSQL_ROW row;

    sprintf(query, "SELECT COUNT(DISTINCT PARTICIPATION.ID_MATCH) AS NUMERO_DE_PARTIDAS FROM PLAYERS, PARTICIPATION WHERE PLAYERS.USERNAME='%s' AND PLAYERS.ID = PARTICIPATION.ID_PLAYER", username);
    if (mysql_query(conn, query) == 0) {
        resultado = mysql_store_result(conn);
        row = mysql_fetch_row(resultado);
        if (row != NULL) {
            sprintf(response, "3/%s\n", row[0]);
        } else {
            strcpy(response, "3/No data found\n");
        }
        mysql_free_result(resultado);
    }
}

// QUERY 4 : players in match X
void query4(int numero, char* response, MYSQL* conn) {
    char query[400];
    MYSQL_RES* resultado;
    MYSQL_ROW row;
    int cont = 0;

    sprintf(query, "SELECT PLAYERS.USERNAME FROM PLAYERS, PARTICIPATION WHERE PARTICIPATION.ID_MATCH=%d AND PLAYERS.ID=PARTICIPATION.ID_PLAYER", numero);
    if (mysql_query(conn, query) == 0) {
        resultado = mysql_store_result(conn);
        while ((row = mysql_fetch_row(resultado)) != NULL) {
            cont++;
        }
        sprintf(response, "4/%d\n", cont);
        mysql_free_result(resultado);
    }
}

// REGISTER A NEW USER
void register_user(char* username, char* password, char* response, MYSQL* conn) {
	char query[512];
	MYSQL_RES* resultado;
	MYSQL_ROW row;
	
	// check if the username already exists
	snprintf(query, sizeof(query),
			 "SELECT ID FROM PLAYERS WHERE USERNAME = '%s';", username);
	
	if (mysql_query(conn, query) != 0) {
		snprintf(response, 512, "Error verifying user: %u %s\n",
				 mysql_errno(conn), mysql_error(conn));
		return;
	}
	resultado = mysql_store_result(conn);
	if (resultado == NULL) {
		snprintf(response, 512, "Error obtaining result: %u %s\n",
				 mysql_errno(conn), mysql_error(conn));
		return;
	}
	
	if (mysql_num_rows(resultado) > 0) {
		strcpy(response, "This user already exists.\n");
		mysql_free_result(resultado);
		return;
	}
	mysql_free_result(resultado);
	
	// Insert the new user
	snprintf(query, sizeof(query),
			 "INSERT INTO PLAYERS (USERNAME, PASSWORD, POINTS) VALUES ('%s', '%s', 0);",
			 username, password);
	if (mysql_query(conn, query) == 0) {
		// Obtain the ID
		my_ulonglong inserted_id = mysql_insert_id(conn);
		snprintf(response, 512, "5/You are now registered successfully. You ID is: %llu\n", inserted_id);
		add_player(username);
	} else {
		snprintf(response, 512, "Error registering: %u %s\n",
				 mysql_errno(conn), mysql_error(conn));
	}
}
	
// LOGIN AN EXISTING USER
void login_user(char* username, char* password, char* response, MYSQL* conn) {
    char query[400];
    MYSQL_RES* resultado;

    sprintf(query, "SELECT * FROM PLAYERS WHERE USERNAME='%s' AND PASSWORD='%s'", username, password);
    mysql_query(conn, query);
    resultado = mysql_store_result(conn);

    if (mysql_num_rows(resultado) == 1) {
        strcpy(response, "6/Logged in successfully.\n");
		add_player(username);
		printf("%s logged in and added to the list\n", username);
		}
    else {
        strcpy(response, "Incorrect username or password\n");
    }
    mysql_free_result(resultado);
}


//SELECT CELLS
void select_cells(char* cells, char* response) {

	printf("Received selected cells: %s\n", cells);
	sprintf(response, "8/Selected cells: %s\n", cells);	
}

//FUNCION PARA QUE EL MENSAJE SE ENVIE A TODOS LOC CLIENTES
void broadcast_message_chat(char* chat_message, char* username, char* response,int sender_sock) {
	
	
	pthread_mutex_lock(&mutex); // Bloqueo para evitar problemas de concurrencia
	sprintf(response, "9/%s:%s\n",username,chat_message); 
	for (int j= 0;j<client_count; j++) {
		
		if (sockets[j] != NULL){
			if (sockets[j]->sock_conn != sender_sock) 
		
				write(sockets[j]->sock_conn, response, strlen(response)); // Enviar el mensaje a cada cliente
		
		}
	}
	
	pthread_mutex_unlock(&mutex); // Desbloqueo
}

// FUNCTION TO INITIALIZE THE CONNECTION WITH MYSQL
MYSQL* init_mysql_connection() {
	MYSQL* conn = mysql_init(NULL);
	if (conn == NULL) {
		printf("Error creating the connection with MySQL: %u %s\n", mysql_errno(conn), mysql_error(conn));
		exit(1);
	}
	conn = mysql_real_connect(conn, "localhost", "root", "mysql", "EXPLODINGROCKETS", 0, NULL, 0);
	if (conn == NULL) {
		printf("Error initializing the connection with MySQL: %u %s\n", mysql_errno(conn), mysql_error(conn));
		exit(1);
	}
	return conn;
}

// MAIN
int main() {
	int sock_listen, sock_conn;
	struct sockaddr_in serv_adr;
	MYSQL* conn;
	pthread_t threads[MAX_CLIENTS]; //Array of threads
	//Number of connected clients
	
	// conection with MYSQL
	conn = init_mysql_connection();
	
	// create socket
	if ((sock_listen = socket(AF_INET, SOCK_STREAM, 0)) < 0) {
		printf("Error connecting to socket\n");
		exit(1);
	}
	
	// configuration of the server
	memset(&serv_adr, 0, sizeof(serv_adr));
	serv_adr.sin_family = AF_INET;
	serv_adr.sin_addr.s_addr = htonl(INADDR_ANY);
	serv_adr.sin_port = htons(PORT);
	
	// asign socket to port
	if (bind(sock_listen, (struct sockaddr*)&serv_adr, sizeof(serv_adr)) < 0) {
		printf("Error doing the bind\n");
		exit(1);
	}
	
	// Listen connections
	if (listen(sock_listen, MAX_CLIENTS) < 0) {
		printf("Error in listen\n");
		exit(1);
	}
	
	printf("Listening :)\n");
	
	// loop to habdle connections
	while (1) {
		sock_conn = accept(sock_listen, NULL, NULL);
		printf("Connection recieved\n");
		sockets[client_count] = sock_conn;
		
		//structure to pass the parameters to the thread
		struct thread_data* t_data = (struct thread_data*)malloc(sizeof(struct thread_data));
		t_data->sock_conn = sock_conn;
		t_data->conn = conn;
		strcpy(t_data->username, "");
		
		sockets[client_count] = t_data;
		
		//thread to manage the client
		pthread_create(&threads[client_count], NULL, handle_client, (void*)t_data);
		
		client_count++;
		
		//limit the number of connected clients
		if (client_count >= MAX_CLIENTS) {
			client_count = 0;
		}
	}
	
	mysql_close(conn);
	return 0;
}


