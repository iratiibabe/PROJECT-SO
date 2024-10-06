#include <string.h>
#include <unistd.h>
#include <stdlib.h>
#include <sys/types.h>
#include <sys/socket.h>
#include <netinet/in.h>
#include <stdio.h>
#include <mysql.h>

int main(int argc, char* argv[])
{
	int sock_conn, sock_listen, ret;
	struct sockaddr_in serv_adr;
	char peticion[512];
	char respuesta[512];
	
	
	MYSQL *conn;
	int err;
	// Estructura especial para almacenar resultados de consultas
	MYSQL_RES *resultado;
	MYSQL_ROW row;
	char username[60];
	char password[60];
	char query[400];
	char query1[80];
	char query2[80];
	char query3[400];
	char query4[400];
	
	//Creamos una conexion al servidor MYSQL
	conn = mysql_init(NULL);
	if (conn==NULL) {
		printf ("Error al crear la conexi\u1162\u1108n: %u %s\n",
				mysql_errno(conn), mysql_error(conn));
		exit (1);
	}
	
	//inicializamos la conexion
	conn = mysql_real_connect (conn, "localhost","root", "mysql", "EXPLODINGROCKETS",0, NULL, 0);
	if (conn==NULL) {
		printf("hola");
		printf ("Error al inicializar la conexi\u1162\u1108n: %u %s\n",
				mysql_errno(conn), mysql_error(conn));
		exit (1);
	}
	
	// INICIALITZACIONS
	// Obrim el socket
	if ((sock_listen = socket(AF_INET, SOCK_STREAM, 0)) < 0)
		printf("Error creant socket");
	// Fem el bind al port
	memset(&serv_adr, 0, sizeof(serv_adr));// inicialitza a zero serv_addr
	serv_adr.sin_family = AF_INET;
	// asocia el socket a cualquiera de las IP de la m?quina. 
	//htonl formatea el numero que recibe al formato necesario
	serv_adr.sin_addr.s_addr = htonl(INADDR_ANY);
	// escucharemos en el port 9050
	serv_adr.sin_port = htons(9000);
	if (bind(sock_listen, (struct sockaddr*)&serv_adr, sizeof(serv_adr)) < 0)
		printf("Error al bind");
	//La cola de peticiones pendientes no podra ser superior a 4
	if (listen(sock_listen, 4) < 0)
		printf("Error en el Listen");
	int i;
	
	
	for (;;) {
		printf("Escuchando\n");
		
		sock_conn = accept(sock_listen, NULL, NULL);
		printf("He recibido conexi?n\n");
		//sock_conn es el socket que usaremos para este cliente
		
		//Bucle de atenci n al cliente
		int terminar = 0;
		while (terminar == 0)
		{
			// Ahora recibimos su peticion
			ret = read(sock_conn, peticion, sizeof(peticion));
			printf("Recibida una petición\n");
			// Tenemos que a?adirle la marca de fin de string 
			// para que no escriba lo que hay despues en el buffer
			peticion[ret] = '\0';
			
			//Escribimos la peticion en la consola
			
			printf("La petición es: %s\n", peticion);
			
			char* p = strtok(peticion, "/");
			int codigo = atoi(p);
			char nombre[20];
			int numero;
			
			if (codigo == 0)
				terminar = 1;
			
			//QUERY 1
			else if (codigo == 1){ 
				
				p = strtok(NULL, "/");
				numero = atoi(p);
				sprintf(query1, "SELECT PLAYERS.USERNAME FROM PLAYERS, MATCHES, PARTICIPATION WHERE PLAYERS.ID = MATCHES.WINNER AND PARTICIPATION.ID_MATCH=MATCHES.ID AND MATCHES.ID=%d;", numero);
				err = mysql_query(conn, query1);
				
				if (err != 0) {
					printf("Error al consultar datos de la base %u %s\n",
						   mysql_errno(conn), mysql_error(conn));
					exit(1);
				}
				//Recogemos el resultado de la consulta. 
				resultado = mysql_store_result(conn);
				if (resultado == NULL) {
					printf("Error al almacenar el resultado de la consulta: %u %s\n", mysql_errno(conn), mysql_error(conn));
					exit(1);
				}
				
				row = mysql_fetch_row(resultado);
				
				if (row == NULL)
					printf("No se han obtenido datos en la consulta\n");
				else {
					sprintf(respuesta, "%s.\n", row[0]);
					
				}
			}
			
			//QUERY 2
			else if (codigo == 2){
				
				p = strtok(NULL, "/");
				strcpy(username, p);
							
				sprintf(query2, "SELECT POINTS FROM PLAYERS WHERE USERNAME='%s'", username);
				err = mysql_query(conn, query2);
				
				if (err != 0){
					printf("Error al realizar la consulta: %u %s\n", mysql_errno(conn), mysql_error(conn));
					mysql_close(conn);
					exit(1);
				}
					
				//Recogemos el resultado de la consulta
				resultado = mysql_store_result(conn);
				row = mysql_fetch_row(resultado);
				//Verificamos si el resultado contiene alguna fila
				if (row == NULL){
					printf("%s no encontrado o no tiene puntos registrados. \n", username);
				}
				else{					
					
					sprintf(respuesta, "%s\n", row[0]);
					
				}
				mysql_free_result(resultado);
			}
			
			//QUERY 3
			else if (codigo == 3){
				
				p = strtok(NULL, "/");
				strcpy(username, p);
				
				snprintf(query3, sizeof(query3),
						 "SELECT COUNT(DISTINCT PARTICIPATION.ID_MATCH) AS NUMERO_DE_PARTIDAS FROM PLAYERS, PARTICIPATION WHERE PLAYERS.USERNAME = '%s' AND PLAYERS.ID = PARTICIPATION.ID_PLAYER", username);
				err=mysql_query (conn, query3);
				
				if (err!=0) {
					printf ("Error al consultar datos de la base %u %s\n",
							mysql_errno(conn), mysql_error(conn));
					exit (1);
				}
				
				//Recogemos el resultado de la consulta. 
				resultado = mysql_store_result (conn);
				if (resultado == NULL) {
					printf("Error al almacenar el resultado de la consulta: %u %s\n", mysql_errno(conn), mysql_error(conn));
					exit(1);
				}
				row = mysql_fetch_row (resultado);
				if (row == NULL)
					printf ("No se han obtenido datos en la consulta\n");
				else{
					// Mostramos el numero de partidas en las que esta jugando X
					sprintf(respuesta, "%s\n", row[0]);
				}
			}
			
			//QUERY 4
			if (codigo == 4){
				
				p = strtok(NULL, "/");
				numero = atoi(p);

				
				sprintf(query4, "SELECT PLAYERS.USERNAME FROM PLAYERS, PARTICIPATION WHERE PARTICIPATION.ID_MATCH = %d AND PLAYERS.ID = PARTICIPATION.ID_PLAYER", numero);
				err=mysql_query (conn, query4);
				if (err!=0) {
					printf ("Error while querying data from database %u %s\n",
							mysql_errno(conn), mysql_error(conn));
					exit (1);
				}
				
				resultado = mysql_store_result(conn);
				if (resultado == NULL) {
					printf("No data was obtained in the query\n");
				} else {
					int cont = 0;
					while ((row = mysql_fetch_row(resultado)) != NULL) {
						cont++;
					}
					sprintf(respuesta, "%d\n", cont);
					
				}
				mysql_free_result(resultado);
				
			}
			
			//REGISTRO
			else if (codigo == 5)
			{
				//Petición: 5/username/password
				p = strtok(NULL, "/");
				if (p != NULL) {
					strcpy(username, p);
				} else {
					sprintf(respuesta, "Error en el formato de la peticion\n");
					write(sock_conn, respuesta, strlen(respuesta));
					return;
				}
				p = strtok(NULL, "/");
				if (p != NULL) {
					strcpy(password, p);
				} else {
					sprintf(respuesta, "Error en el formato de la peticion\n");
					write(sock_conn, respuesta, strlen(respuesta));
					return;
				}
				
				// Verificamos si el usuario ya existe
				sprintf(query, "SELECT * FROM PLAYERS WHERE USERNAME='%s'", username);
				err = mysql_query(conn, query);
				resultado = mysql_store_result(conn);
				if (resultado == NULL) {
					sprintf(respuesta, "Error en la consulta de usuario: %u %s\n", mysql_errno(conn), mysql_error(conn));
					write(sock_conn, respuesta, strlen(respuesta));
					return;
				}
				if (mysql_num_rows(resultado) > 0) {
					sprintf(respuesta, "Usuario ya existe\n");
				} 
				else {
					// Obtener el ID ma¡ximo actual en la tabla PLAYERS para asignar un id al nuevo jugador 
					mysql_free_result(resultado);
					sprintf(query, "SELECT MAX(ID) FROM PLAYERS");
					err = mysql_query(conn, query);
					resultado = mysql_store_result(conn);
					if (resultado == NULL) {
						sprintf(respuesta, "Error al obtener el ID ma¡ximo: %u %s\n", mysql_errno(conn), mysql_error(conn));
						write(sock_conn, respuesta, strlen(respuesta));
						return;
					}
					row = mysql_fetch_row(resultado);
					int next_id = 1;  // ID 1 si la tabla ests¡ vacia
					if (row[0] != NULL) {
						next_id = atoi(row[0]) + 1;
					}
					mysql_free_result(resultado);  
					// Metemos al nuevo usuario en la tabla players
					sprintf(query, "INSERT INTO PLAYERS (ID, USERNAME, PASSWORD, POINTS) VALUES (%d, '%s', '%s', 0)", next_id, username, password);
					err = mysql_query(conn, query);
					if (err == 0)
						sprintf(respuesta, "Registered\n");
					else
						sprintf(respuesta, "Error al registrar usuario: %u %s\n", mysql_errno(conn), mysql_error(conn));
				}
			}
			
			//LOGIN
			else if (codigo == 6)
			{
				// Peticion: 6/username/password
				p = strtok(NULL, "/");
				strcpy(username, p);
				p = strtok(NULL, "/");
				strcpy(password, p);
				
				// Verificamos credenciales
				sprintf(query, "SELECT * FROM PLAYERS WHERE USERNAME='%s' AND PASSWORD='%s'", username, password);
				err = mysql_query(conn, query);
				resultado = mysql_store_result(conn);
				if (mysql_num_rows(resultado) == 1)
					sprintf(respuesta, "Loged In\n");
				else
					sprintf(respuesta, "Wrong username or password\n");
				mysql_free_result(resultado);
			}
			
			
			printf("Respuesta a enviar: %s\n", respuesta);
			write(sock_conn, respuesta, strlen(respuesta));
		}
		// Se acabo el servicio para este cliente
		close(sock_conn);
	}
}
	
	
	
	
