#include <string.h>
#include <unistd.h>
#include <stdlib.h>
#include <sys/types.h>
#include <sys/socket.h>
#include <netinet/in.h>
#include <stdio.h>
#include <mysql.h>
#include <pthread.h> //para manejar los threads

#define PORT 9100 // port from which we will listen
/*#define PORT 50067 *///shiva
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
void get_connected_players(int sender_sock);

//DECLARACION DE CONSULTAS
void query1(int numero, char* response, MYSQL* conn);
void query2(char* username, char* response, MYSQL* conn);
void query3(char* username, char* response, MYSQL* conn);
void query4(int numero, char* response, MYSQL* conn);
void query5(char* username, char* response, MYSQL* conn);
void query6(char* start, char* finish, char* response, MYSQL* conn);
void register_user(char* username, char* password, char* response, MYSQL* conn);
void unregister_user(char* username, char* password, char* response, MYSQL* conn);
void login_user(char* username, char* password, char* response, MYSQL* conn);
void create_game(char* username, char* response, MYSQL* conn);
void select_cells(char* username, char* response, float position,MYSQL* conn,int numForm,int id_match); 
void select_bomb_cells(char* username, char* response, float position_bomb, MYSQL* conn,int numForm,int id_match);
int send_message_to_user(char* sender_username, char* receiver_username, char* message,int numForm);
int invitation_response(char* sender_username, char* receiver_username, char*message, MYSQL* conn, int ID_Match);
struct thread_data** give_sockets(int id_match, int* match_client_count, MYSQL *conn) ; 
void broadcast_message_chat(char* chat_message, char* username, char* response, int sender_sock, struct thread_data** sockets_match, int match_client_count,int numForm);

//FUNCTION TO ADD PLAYER TO THE CONNECTED LIST
void add_player(char* username) 
{
	pthread_mutex_lock(&mutex);
	if (player_count < MAX_CLIENTS) {
		strcpy(connected_players[player_count], username);
		player_count++;
	}
	pthread_mutex_unlock(&mutex);
}

//FUNCTION TO REMOVE PLAYER FROM THE CONNECTED LIST
void remove_player(char* username) 
{
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
void get_connected_players(int sender_sock) 
{
	char notification[512];
	pthread_mutex_lock(&mutex);
	
	
	if (player_count == 0) {
		sprintf(notification, "7/No players connected\n");
	}
	else {
		sprintf(notification, "7/\n");
		for (int i = 0; i < player_count; i++) {
			strcat(notification, connected_players[i]);
			strcat(notification, "\n");
		}
	}
	for (int j= 0;j<client_count; j++) {
		
		if (sockets[j] != NULL)
			write(sockets[j]->sock_conn, notification, strlen(notification)); // Enviar el mensaje a cada cliente
		
	}
	pthread_mutex_unlock(&mutex);
}


//FUNCTION TO SEND MESSAGES TO OTHER USERS (we use it to the invitation)
int send_message_to_user(char* sender_username, char* receiver_username, char* message,int numForm) {
	int sender_sock = -1;
	int receiver_sock = -1;
	
	pthread_mutex_lock(&mutex);
	// search socket from each user
	for (int i = 0; i < player_count; i++) {
		if (strcmp(connected_players[i], sender_username) == 0) {
			sender_sock = sockets[i]->sock_conn;
		}
		if (strcmp(connected_players[i], receiver_username) == 0) {
			receiver_sock = sockets[i]->sock_conn;
		}
	}
	pthread_mutex_unlock(&mutex);
	// both users must be connected
	if (sender_sock == -1) {
		printf("Error: Sender user '%s' not connected.\n", sender_username);
		return -1;
	}
	if (receiver_sock == -1) {
		printf("Error: Receiver user '%s' not connected.\n", receiver_username);
		return -1;
	}
	// send message
	if (send(receiver_sock, message, strlen(message), 0) < 0) {
		perror("Error sending message");
		return -1;
	}
	return 0;

}
//DAME SOCKETS DE PARTIDA (we use it to send notifications but only to the members o X match)
struct thread_data** give_sockets(int id_match, int* match_client_count, MYSQL *conn ) {

	MYSQL_RES *res;
	MYSQL_ROW row;
	struct thread_data** sockets_match = NULL; // Vector de sockets para la partida
	int match_count = 0;
		
	// Crear la consulta SQL para obtener los nombres de los jugadores en la partida
	char query[256];
	sprintf(query, "SELECT PLAYERS.USERNAME FROM PARTICIPATION  "
			"JOIN PLAYERS  ON PARTICIPATION.ID_PLAYER = PLAYERS.ID "
			"WHERE PARTICIPATION.ID_MATCH = %d", id_match);
	
	if (mysql_query(conn, query)) {
		fprintf(stderr, "9/Error en la consulta SQL: %s\n", mysql_error(conn));
		mysql_close(conn);
		return NULL;
	}
	
	res = mysql_store_result(conn);
	if (res == NULL) {
		fprintf(stderr, "9/Error al obtener resultados: %s\n", mysql_error(conn));
		mysql_close(conn);
		return NULL;
	}
	
	// Crear un vector de sockets para los jugadores de la partida
	pthread_mutex_lock(&mutex); // Proteger la lectura de los sockets
	sockets_match = (struct thread_data**) malloc(sizeof(struct thread_data*) * MAX_CLIENTS);
	
	while ((row = mysql_fetch_row(res))) {
		char* username = row[0];
		printf("Jugador en la partida: %s\n", username);
		
		// Buscar el socket correspondiente al nombre de usuario
		for (int i = 0; i < client_count; i++) {
			if (sockets[i] != NULL && strcmp(sockets[i]->username, username) == 0) {
				printf("nombre del jugador del socket i: %s\n",sockets[i]->username);
				sockets_match[match_count++] = sockets[i];
				break;
			}
		}
	}
	pthread_mutex_unlock(&mutex);
	
	mysql_free_result(res);

	
	*match_client_count = match_count; 
	printf("Match_client_count: %d\n",*match_client_count);
	return sockets_match;
}

//FUNCTION TO NOTIFY THAT ANOTHER USER HAS ACCEPT YOUR INVITATION
int invitation_response(char* sender_username, char* receiver_username, char*message, MYSQL* conn, int ID_Match) {
	int sender_sock = -1;
	int receiver_sock = -1;
	MYSQL_RES* resultado;
	MYSQL_ROW row;
	
	char ID_Player2[20];
	
	char query[512];
	
	// Obtener el ID del jugador (quien enviï¿½ la bomba)
	snprintf(query, sizeof(query),
			 "SELECT ID FROM PLAYERS WHERE USERNAME = '%s';", sender_username);
	if (mysql_query(conn, query) != 0) {
		snprintf(message, 512, "13/Error verifying user: %u %s\n",
				 mysql_errno(conn), mysql_error(conn));
		return;
	}
	resultado = mysql_store_result(conn);
	if (resultado == NULL) {
		snprintf(message, 512, "13/Error storing result: %u %s\n",
				 mysql_errno(conn), mysql_error(conn));
		return;
	}
	row = mysql_fetch_row(resultado);
	if (row != NULL) {
		strcpy(ID_Player2, row[0]); 
	} else {
		snprintf(message, 512, "13/Error: User not found\n");
		mysql_free_result(resultado);
		return;
	}
	mysql_free_result(resultado);
	
	snprintf(query, sizeof(query),
			 "INSERT INTO PARTICIPATION (ID_PLAYER, ID_MATCH) VALUES ('%s', '%d');", ID_Player2, ID_Match);
	if (mysql_query(conn, query) == 0) {
		printf("Inserted correctly\n");
	} else {
		snprintf(message, 512, "13/Error registering: %u %s\n",
				 mysql_errno(conn), mysql_error(conn));
	}
	
	pthread_mutex_lock(&mutex);
	// search socket from each user
	for (int i = 0; i < player_count; i++) {
		if (strcmp(connected_players[i], sender_username) == 0) {
			sender_sock = sockets[i]->sock_conn;
		}
		if (strcmp(connected_players[i], receiver_username) == 0) {
			receiver_sock = sockets[i]->sock_conn;
		}
	}
	pthread_mutex_unlock(&mutex);
	
	if (sender_sock == -1) {
		printf("Error: Sender user '%s' not connected.\n", sender_username);
		return -1;
	}
	if (receiver_sock == -1) {
		printf("Error: Receiver user '%s' not connected.\n", receiver_username);
		return -1;
	}
	// send message
	if (send(receiver_sock, message, strlen(message), 0) < 0) {
		perror("Error sending message");
		return -1;
	}
	
	return 0;
}



// CLIENT'S REQUEST
void process_request(char* request, char* response, MYSQL* conn, char* username, int sender_sock) {
    char* p = strtok(request, "/");
    int codigo = atoi(p);
	char password[60];
	char chat_message[200];
    int numero;
	int id_match;
	char start[19];
	char finish[19];
	
	
	int numForm ;  // Initialize numForm to -1
	

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
				strcpy(response, "6/Invalid request format for login\n");
				return;
			}
			strcpy(username, p);
			p = strtok(NULL, "/");
			if (p == NULL) {
				strcpy(response, "6/Invalid request format for login\n");
				return;
			}
			strcpy(password, p);
			login_user(username, password, response, conn);
			if (strcmp(response, "6/Logged in successfully. \n") == 0) {
				add_player(username);
				
				printf("%s logged in and added to the list\n", username);
			}
			printf("Request to list connected players received\n");
			get_connected_players(sender_sock);
			break;

			
		case 8: 
			p = strtok(NULL, "/");
			if (p != NULL) {
				numForm = atoi(p);
			}
			p = strtok(NULL, "/");
			if (p == NULL) {
				printf(response, "8/%d/Invalid format for selected cells\n",numForm);
				return;
			}
			strcpy(username,p);
			p = strtok(NULL, "/");
			id_match = atoi(p);
			p= strtok(NULL, "/");
			while (p!=NULL){
				float position = atof(p);
				select_cells(username, response, position, conn,numForm,id_match);
				p = strtok(NULL, "/");
			}

			break;
			
		case 9:
			p = strtok(NULL, "/");
			if (p != NULL) {
				numForm = atoi(p);
			}
			p = strtok(NULL, "/");
			strcpy(username, p);
			p = strtok(NULL, "/");
			strcpy(chat_message, p);
			p= strtok(NULL,"/");
			id_match = atoi(p);
			int match_client_count;
			struct thread_data** sockets_match = give_sockets(id_match,&match_client_count,conn);
			broadcast_message_chat(chat_message,username,response, sender_sock,sockets_match,match_client_count,numForm);
			free(sockets_match);
			break;
			
		case 10:
			p = strtok(NULL, "/");
			if (p == NULL) {
				strcpy(response, "Invalid request format\n");
				return;
			}
			strcpy(username, p);		
			create_game(username,response,conn);
			break;
			
		case 11: 
			p = strtok(NULL, "/");
			if (p != NULL) {
				numForm = atoi(p);
			}
			p = strtok(NULL, "/");
			if (p == NULL) {
				printf(response, "11/%d/Invalid format for selected cells\n",numForm);
				return;
			}
			strcpy(username,p);
			p = strtok(NULL, "/");
			id_match = atoi(p);
			p = strtok(NULL, "/");
			float position_bomb = atof(p);
			select_bomb_cells(username, response, position_bomb, conn,numForm,id_match);
			break;
		case 12: {
			// message received -> 12/sender_username/receiver_username/IDpartida
			char sender_username[20];
			char receiver_username[20];
			int IDpartida;
			p = strtok(NULL, "/");
			if (p == NULL) {
				strcpy(response, "12/Invalid format\n");
				return;
			}
			strcpy(sender_username,p);
			p = strtok(NULL, "/");
			strcpy(receiver_username,p);
			p = strtok(NULL, "/");
			IDpartida = atoi(p);
			
			// create the invitation  message
		
			sprintf(response, "12/The player :%s: has invited you :%s: to play(ID_MATCH):%d", sender_username,receiver_username, IDpartida);
			// we use the function to send messages to other users
			int result = send_message_to_user(sender_username, receiver_username, response, numForm);
			if (result == -1) {
				printf("Failed to send game invite from %s to %s.\n", sender_username, receiver_username);
			} else {
				printf("Invitation sent from %s to %s successfully.\n", sender_username, receiver_username);
			}
			break;
			
		}
		case 13:{
			printf("EStoy en el caso 13");
			// message received -> 13/sender_username/receiver_username/response_code
			char sender_username[20];
			char receiver_username[20];
			int response_code;
			int ID_Match;
			p = strtok(NULL, "/");
			if (p == NULL) {
				strcpy(response, "13/Invalid format\n");
				return;
			}
			strcpy(sender_username,p);
			p = strtok(NULL, "/");
			strcpy(receiver_username,p);
			p = strtok(NULL, "/");
			response_code = atoi(p);
			p = strtok(NULL, "/");
			ID_Match= atoi(p);
			
			if (response_code == 0) { 
				sprintf(response, "13/The user %s has accepted your invitation to play at the match with ID:%d", sender_username,ID_Match); 
			} else if (response_code == 1) { 
				sprintf(response, "13/The user %s has rejected your invitation.", sender_username); 
			}
			
			int result = invitation_response(sender_username, receiver_username, response,conn,ID_Match); 
			
			if (result == -1) {
				printf("Failed to send the response from %s.\n", sender_username);
			} else {
				printf("The user %s has accepted the invitation.\n", sender_username);
			}
			break;
		}
		case 14: //UNREGISTER
			p = strtok(NULL, "/");
			if (p == NULL) {
				strcpy(response, "Invalid request format for unregistration\n");
				return;
			}
			strcpy(username, p);
			p = strtok(NULL, "/");
			if (p == NULL) {
				strcpy(response, "Invalid request format for unregistration\n");
				return;
			}
			strcpy(password, p);
			unregister_user(username, password, response, conn);
			break;
		case 15:  //query5
			p = strtok(NULL, "/");
			if (p == NULL) {
				strcpy(response, "Invalid request format\n");
				return;
			}
			strcpy(username, p);
			query5(username, response, conn);
			break;
		case 16:  //query6
			p = strtok(NULL, "/");
			if (p == NULL) {
				strcpy(response, "Invalid request format\n");
				return;
			}
			strcpy(start, p);
			p = strtok(NULL, "/");
			strcpy(finish, p);
			query6(start,finish, response, conn);
			break;
				
			
		case 0:
			p = strtok(NULL, "/");
			if (p != NULL) {
				remove_player(p);
				get_connected_players(sender_sock);
				strcpy(response, "0/End of connection\n");
			}
			else {
				strcpy(response, "0/Player not specified for disconecction\n");
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

    sprintf(query, "SELECT TOTAL_POINTS FROM PLAYERS WHERE USERNAME='%s'", username);
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

//QUERY 5 : players i have played with
void query5(char* username, char* response, MYSQL* conn) {
	char query[400];
	MYSQL_RES* resultado;
	MYSQL_ROW row;
	char players[1000] = "";  
	sprintf(query, "SELECT DISTINCT PLAYERS.USERNAME FROM PLAYERS, PARTICIPATION WHERE PLAYERS.ID = PARTICIPATION.ID_PLAYER AND PARTICIPATION.ID_MATCH IN (SELECT ID_MATCH FROM PARTICIPATION, PLAYERS WHERE PARTICIPATION.ID_PLAYER = PLAYERS.ID AND PLAYERS.USERNAME = '%s') AND PLAYERS.USERNAME != '%s'", username, username);
	if (mysql_query(conn, query) == 0) {
		resultado = mysql_store_result(conn);
		if (mysql_num_rows(resultado) > 0) {
			while ((row = mysql_fetch_row(resultado)) != NULL) {
				strcat(players, row[0]);
				strcat(players, ",");
			}
			players[strlen(players) - 1] = '\0'; 
			sprintf(response, "15/%s\n", players);
		} else {
			strcpy(response, "15/No data found\n");
		}
		mysql_free_result(resultado);
	} else {
		strcpy(response, "15/Error en la consulta\n");
	}
}


//QUERY 6: list of matches in a period of time
void query6(char* start, char* finish, char* response, MYSQL* conn) {
	char query[1000];
	MYSQL_RES* resultado;
	MYSQL_ROW row;
	
	sprintf(query, "SELECT DATE_FORMAT(DATE_TIME_FINISH - INTERVAL DURATION SECOND, '%%Y-%%m-%%d %%H:%%i:%%s') AS START_TIME, ID "
			"FROM MATCHES "
			"WHERE DATE_TIME_FINISH - INTERVAL DURATION SECOND BETWEEN STR_TO_DATE('%s', '%%Y-%%m-%%d %%H:%%i:%%s') "
			"AND STR_TO_DATE('%s', '%%Y-%%m-%%d %%H:%%i:%%s')", start, finish);
	
	if (mysql_query(conn, query) == 0) {
		resultado = mysql_store_result(conn);
		strcpy(response, "16/");
		
		while ((row = mysql_fetch_row(resultado)) != NULL) {
			char players_query[500];
			MYSQL_RES* players_result;
			MYSQL_ROW players_row;
			char players[500] = "";
			
			sprintf(players_query, "SELECT PLAYERS.USERNAME FROM PLAYERS, PARTICIPATION "
					"WHERE PARTICIPATION.ID_MATCH = %s AND PLAYERS.ID = PARTICIPATION.ID_PLAYER", row[1]);
			
			if (mysql_query(conn, players_query) == 0) {
				players_result = mysql_store_result(conn);
				while ((players_row = mysql_fetch_row(players_result)) != NULL) {
					strcat(players, players_row[0]);
					strcat(players, ",");
				}
				if (strlen(players) > 0) {
					players[strlen(players) - 1] = '\0';  
				}
				mysql_free_result(players_result);
			}
			
			strcat(response, row[0]);
			strcat(response, " :  ");
			strcat(response, players);
			strcat(response, "\n");
		}
		
		if (strlen(response) == 3) {  
			strcat(response, "No matches found\n");
		} else {
			response[strlen(response) - 1] = '\n'; 
		}
		
		mysql_free_result(resultado);
	} else {
		strcpy(response, "16/Error executing query\n");
	}
	printf(response);
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
			 "INSERT INTO PLAYERS (USERNAME, PASSWORD) VALUES ('%s', '%s');",
			 username, password);
	if (mysql_query(conn, query) == 0) {
		// Obtain the ID
		my_ulonglong inserted_id = mysql_insert_id(conn);
		snprintf(response, 512, "5/You are now registered successfully.");
		add_player(username);
	} else {
		snprintf(response, 512, "5/Error registering: %u %s\n",
				 mysql_errno(conn), mysql_error(conn));
	}
}

void unregister_user(char* username, char* password, char* response, MYSQL* conn){
	char query[512];
    MYSQL_RES* resultado;
    MYSQL_ROW row;

    // Check if the username exists and verify the password
    snprintf(query, sizeof(query),
             "SELECT ID FROM PLAYERS WHERE USERNAME = '%s' AND PASSWORD = '%s';",
             username, password);

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

    if (mysql_num_rows(resultado) == 0) {
        strcpy(response, "User not found or incorrect password.\n");
        mysql_free_result(resultado);
        return;
    }
    mysql_free_result(resultado);

    // Delete the user from the database
    snprintf(query, sizeof(query),
             "DELETE FROM PLAYERS WHERE USERNAME = '%s' AND PASSWORD = '%s';",
             username, password);
    if (mysql_query(conn, query) == 0) {
        snprintf(response, 512, "14/User successfully unregistered.\n");
        remove_player(username); // Optionally remove from in-memory structures
    } else {
        snprintf(response, 512, "Error unregistering: %u %s\n",
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
        strcpy(response, "6/Incorrect username or password\n");
    }
    mysql_free_result(resultado);
}

//SELECT CELLS
void select_cells(char* username, char* response, float position,MYSQL* conn,int numForm,int id_match) {
	char query[512];
	MYSQL_RES* resultado;
	MYSQL_ROW row;
	char ID_Player[20];
	
	snprintf(query, sizeof(query),
			 "SELECT ID FROM PLAYERS WHERE USERNAME = '%s';", username);
	if (mysql_query(conn, query) != 0) {
		snprintf(response, 512, "8/%d/Error verifying user: %u %s\n",numForm, mysql_errno(conn), mysql_error(conn));
		return;
	}
	resultado = mysql_store_result(conn);
	if (resultado == NULL) {
		snprintf(response, 512, "8/%d/Error storing result: %u %s\n",numForm,
				 mysql_errno(conn), mysql_error(conn));
		return;
	}
	row = mysql_fetch_row(resultado);
	if (row != NULL) {
		strcpy(ID_Player, row[0]); 
	} else {
		snprintf(response, 512, "8/%d/Error: User not found\n",numForm);
		mysql_free_result(resultado);
		return;
	}
	mysql_free_result(resultado);	
	//insert position to the tamble
	snprintf(query, sizeof(query), "INSERT INTO POSITIONS (ID_PLAYER, POSITION_ROCKET) VALUES (%s, %f);", ID_Player, position);
	if (mysql_query(conn, query) == 0) {
		printf("Inserted correctly\n");
		sprintf(response, "8/%d/Inserted correctly",numForm);
		
	} else {
		snprintf(response, 512, "8/%d/Error entering the coordinates: %u %s\n",numForm,
				 mysql_errno(conn), mysql_error(conn));
	}
	
	int sender_sock = -1;
	
	
	pthread_mutex_lock(&mutex);
	// search socket from each user
	for (int i = 0; i < player_count; i++) {
		if (strcmp(connected_players[i], username) == 0) {
			sender_sock = sockets[i]->sock_conn;
		}
		
	}
	pthread_mutex_unlock(&mutex);
	
	
	snprintf(query, sizeof(query),
			 "UPDATE PARTICIPATION SET ROCKETS = 3 WHERE ID_PLAYER = %s AND ID_MATCH = %d;", ID_Player, id_match);
	if (mysql_query(conn, query) == 0) {
		int match_client_count;
		struct thread_data** sockets_aux = give_sockets( id_match,&match_client_count, conn );
		
		pthread_mutex_lock(&mutex);
		// Formatear el mensaje de chat
		
		printf("Rockets updated correctly\n");
		sprintf(response, "8/%d/Rockets inserted correctly/%s/%d/", numForm,username,3);
		printf("ESTO ES LO QUE ENVIAMOS:%s\n",response);
		
		// Enviar el mensaje solo a los jugadores en la partida
		for (int j = 0; j < match_client_count; j++) {
			if (sockets_aux[j] != NULL) {
				if (sockets_aux[j]->sock_conn != sender_sock) {
					write(sockets_aux[j]->sock_conn, response, strlen(response));	
				}
			}
		}
		
		pthread_mutex_unlock(&mutex); 
		
	} else {
		snprintf(response, 512, "8/%d/Error updating rockets: %u %s\n", numForm,
				 mysql_errno(conn), mysql_error(conn));
	}
	
}

//SELECT BOMB CELLS
void select_bomb_cells(char* username, char* response, float position_bomb, MYSQL* conn,int numForm,int id_match){
	MYSQL_RES* resultado;
	MYSQL_ROW row;
	char ID_Player[20];
	char query[512];
	
	// Obtener el ID del jugador (quien enviï¿½ la bomba)
		snprintf(query, sizeof(query),
				 "SELECT ID FROM PLAYERS WHERE USERNAME = '%s';", username);
	if (mysql_query(conn, query) != 0) {
		snprintf(response, 512, "11/%d/Error verifying user: %u %s\n",numForm,
				 mysql_errno(conn), mysql_error(conn));
		return;
}
	resultado = mysql_store_result(conn);
	if (resultado == NULL) {
		snprintf(response, 512, "11/%d/Error storing result: %u %s\n",numForm,
				 mysql_errno(conn), mysql_error(conn));
		return;
}
	row = mysql_fetch_row(resultado);
	if (row != NULL) {
		strcpy(ID_Player, row[0]); 
} else {
		snprintf(response, 512, "11/%d/Error: User not found\n",numForm);
		mysql_free_result(resultado);
		return;
}
	mysql_free_result(resultado);
	
	snprintf(query, sizeof(query),
			 "SELECT POSITION_ROCKET FROM POSITIONS WHERE ID_PLAYER != %s;", ID_Player);
	if (mysql_query(conn, query) != 0) {
		snprintf(response, 512, "11/%d/Error querying other players' positions: %u %s\n",numForm,
				 mysql_errno(conn), mysql_error(conn));
		return;
}
	
	resultado = mysql_store_result(conn);
	if (resultado == NULL) {
		snprintf(response, 512, "11/%d/Error storing result: %u %s\n",numForm,
				 mysql_errno(conn), mysql_error(conn));
		return;
	
}
	int sender_sock = -1;
	
	
	pthread_mutex_lock(&mutex);
	// search socket from each user
	for (int i = 0; i < player_count; i++) {
		if (strcmp(connected_players[i], username) == 0) {
			sender_sock = sockets[i]->sock_conn;
		}
		
	}
	pthread_mutex_unlock(&mutex);
	
	
	int rocket_found = 0;  
	while ((row = mysql_fetch_row(resultado)) != NULL) {
		float position_rocket = atof(row[0]);  
		if (position_rocket == position_bomb) { 
			rocket_found = 1;
			break;
}
}
	
	if (rocket_found) {
		snprintf(query, sizeof(query),
				 "UPDATE PARTICIPATION SET ROCKETS = ROCKETS - 1 WHERE ID_PLAYER = %s AND ID_MATCH = %d AND ROCKETS > 0;", ID_Player, id_match);
		if (mysql_query(conn, query) == 0) {
			printf("Rockets updated correctly\n");
			
		} else {
			snprintf(response, 512, "11/%d/Error updating rockets: %u %s\n", numForm,
					 mysql_errno(conn), mysql_error(conn));
		}
		
		mysql_free_result(resultado);
		snprintf(query, sizeof(query),
				 "SELECT PLAYERS.USERNAME, PARTICIPATION.ROCKETS "
				 "FROM PARTICIPATION "
				 "JOIN PLAYERS ON PARTICIPATION.ID_PLAYER = PLAYERS.ID "
				 "WHERE PARTICIPATION.ID_MATCH = %d;", id_match);
		
		// Ejecutar la consulta
		if (mysql_query(conn, query)) {
			snprintf(response, 512, "11/Error en la consulta SQL: %u %s\n", 
					 mysql_errno(conn), mysql_error(conn));
			return;
		}
		
		// Obtener los resultados
		resultado = mysql_store_result(conn);
		if (resultado == NULL) {
			snprintf(response, 512, "11/Error al obtener resultados: %u %s\n", 
					 mysql_errno(conn), mysql_error(conn));
			return;
		}
		
		int match_client_count;
		// Procesar los resultados para construir la respuesta
		char response_aux[1024] = ""; // Asegúrate de inicializar el string vacío.
		while ((row = mysql_fetch_row(resultado)) != NULL) {
			const char* username = row[0];
			const char* rockets = row[1];
			
			// Evitar la barra extra al final, usando un control de si es el primer elemento.
			if (strlen(response_aux) > 0) {
				strcat(response_aux, "/");
			}
			snprintf(response_aux + strlen(response_aux), sizeof(response_aux) - strlen(response_aux), "%s/%s", username, rockets);
		}
		struct thread_data** sockets_aux = give_sockets( id_match,&match_client_count, conn );
		printf("HEMOS LLEGADO AQUI");
		pthread_mutex_lock(&mutex); // Bloqueo para evitar problemas de concurrencia
		
		// Formatear el mensaje de chat
		sprintf(response,"11/%d/There is a rocket in this position/%f/%s",numForm,position_bomb,response_aux);
		printf("ENVIAMOS LO SIGUIENTE:%s\n",response);

		// Enviar el mensaje solo a los jugadores en la partida
		for (int j = 0; j < match_client_count; j++) {
			if (sockets_aux[j] != NULL) {
				if (sockets_aux[j]->sock_conn != sender_sock) {
					write(sockets_aux[j]->sock_conn, response, strlen(response)); // Enviar el mensaje al cliente
				}
			}
		}
		
		pthread_mutex_unlock(&mutex); 
		
		
} else {
		snprintf(response, 512, "11/%d/No rocket found in this position/%f",numForm,position_bomb);
}
	
	mysql_free_result(resultado);
	
}
//FUNCION PARA QUE EL MENSAJE SE ENVIE A TODOS LOC CLIENTES
void broadcast_message_chat(char* chat_message, char* username, char* response, int sender_sock, struct thread_data** sockets_match, int match_client_count,int numForm) {
	pthread_mutex_lock(&mutex); // Bloqueo para evitar problemas de concurrencia
	
	// Formatear el mensaje de chat
	sprintf(response,"9/%d/%s:%s\n",numForm, username, chat_message);
	

	
	
	// Enviar el mensaje solo a los jugadores en la partida
	for (int j = 0; j < match_client_count; j++) {
		if (sockets_match[j] != NULL) {
			if (sockets_match[j]->sock_conn != sender_sock) {
				write(sockets_match[j]->sock_conn, response, strlen(response)); // Enviar el mensaje al cliente
			}
		}
	}
	
	pthread_mutex_unlock(&mutex); 
}

void create_game(char* username, char* response, MYSQL* conn) {
	MYSQL_RES* resultado;
	MYSQL_ROW row;
	char query[512];
	char datetime[20];
	char ID_Player[20];
	unsigned long long ID_Match;
	time_t t = time(NULL);
	struct tm *tm_info = localtime(&t);
	
	strftime(datetime, sizeof(datetime), "%Y-%m-%d %H:%M:%S", tm_info);
	
	
	// Inserta un nuevo registro en la tabla MATCHES
	snprintf(query, sizeof(query),
			 "INSERT INTO MATCHES (DATE_TIME_FINISH, DURATION, WINNER) VALUES ('%s', 0, NULL);",datetime);
	if (mysql_query(conn, query) == 0) {
		// Obtain the ID
		my_ulonglong inserted_id = mysql_insert_id(conn);
		ID_Match= inserted_id;
		snprintf(response, 512, "10/You are now registered successfully. Your Match ID is:%llu\n", ID_Match);
	} else {
		snprintf(response, 512, "10/Error registering: %u %s\n",
				 mysql_errno(conn), mysql_error(conn));
	}
	snprintf(query, sizeof(query),
			 "SELECT ID FROM PLAYERS WHERE USERNAME = '%s';", username);
	if (mysql_query(conn, query) != 0) {
		snprintf(response, 512, "10/Error verifying user: %u %s\n",
				 mysql_errno(conn), mysql_error(conn));
		return;
	}
	
	// Obtener y verificar el resultado
	resultado = mysql_store_result(conn);
	if (resultado == NULL) {
		snprintf(response, 512, "10/Error storing result: %u %s\n",
				 mysql_errno(conn), mysql_error(conn));
		return;
	}
	
	row = mysql_fetch_row(resultado);
	if (row != NULL) {
		strcpy(ID_Player, row[0]); 
	} else {
		snprintf(response, 512, "10/Error: User not found\n");
		mysql_free_result(resultado);
		return;
	}
	mysql_free_result(resultado);
	
	
	snprintf(query, sizeof(query),
			 "INSERT INTO PARTICIPATION (ID_PLAYER, ID_MATCH) VALUES ('%s', '%llu');", ID_Player, ID_Match);
	if (mysql_query(conn, query) == 0) {
		printf("Inserted correctly\n");
	} else {
		snprintf(response, 512, "10/Error registering: %u %s\n",
				 mysql_errno(conn), mysql_error(conn));
	}
}

// FUNCTION TO INITIALIZE THE CONNECTION WITH MYSQL
MYSQL* init_mysql_connection() {
	MYSQL* conn = mysql_init(NULL);
	if (conn == NULL) {
		printf("Error creating the connection with MySQL: %u %s\n", mysql_errno(conn), mysql_error(conn));
		exit(1);
	}
	//shiva
/*	conn = mysql_real_connect(conn,"shiva2.upc.es", "root", "mysql", "T4_EXPLODINGROCKETS", 0, NULL, 0);*/
	//maquina virtual
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


