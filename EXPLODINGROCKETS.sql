DROP DATABASE IF EXISTS EXPLODINGROCKETS;
CREATE DATABASE EXPLODINGROCKETS;

USE EXPLODINGROCKETS;

CREATE TABLE PLAYERS (
	ID INT NOT NULL,
	USERNAME VARCHAR(60),
	PASSWORD VARCHAR(60),
	POINTS INT,
	PRIMARY KEY (ID)
)ENGINE=InnoDB;

CREATE TABLE MATCHES (
	ID INT NOT NULL,
	DATE_TIME_FINISH DATETIME, /* año-mes-dia horas:minutos:segundos */
	DURATION TIME, /* horas:minutos:segundos */
	WINNER INT,
	FOREIGN KEY (WINNER) REFERENCES PLAYERS(ID),
	PRIMARY KEY (ID)
)ENGINE=InnoDB;

CREATE TABLE PARTICIPATION (
	ID_PLAYER INT,
	ID_MATCH INT,
	FOREIGN KEY (ID_PLAYER) REFERENCES PLAYERS(ID),
	FOREIGN KEY (ID_MATCH) REFERENCES MATCHES(ID)
)ENGINE=InnoDB;

INSERT INTO PLAYERS VALUES (1,'SARA','SARA1',24);
INSERT INTO PLAYERS VALUES (2,'MARIA','MARIA2',20);
INSERT INTO PLAYERS VALUES (3,'LAURA','LAURA3',13);
INSERT INTO PLAYERS VALUES (4,'JOSE','JOSE4',9);
INSERT INTO PLAYERS VALUES (5,'PETRA','PETRA5',14);
INSERT INTO PLAYERS VALUES (6,'LOLA','LOLA6',14);
INSERT INTO PLAYERS VALUES (7,'IRATI','IRATI7',26);
INSERT INTO PLAYERS VALUES (8,'EIRA','EIRA8',30);
INSERT INTO PLAYERS VALUES (9,'ALOMA','ALOMA9',34);

INSERT INTO MATCHES VALUES (1,'2024-09-29 11:06:00','00:14:30',1); 
INSERT INTO MATCHES VALUES (2,'2024-09-29 11:07:59','01:01:00',3);
INSERT INTO MATCHES VALUES (3,'2024-09-29 12:00:00','00:45:45',5);
INSERT INTO MATCHES VALUES (4,'2024-09-20 16:21:00','00:50:45',9);

INSERT INTO PARTICIPATION VALUES (1,1);
INSERT INTO PARTICIPATION VALUES (2,1);
INSERT INTO PARTICIPATION VALUES (4,1);
INSERT INTO PARTICIPATION VALUES (3,2);
INSERT INTO PARTICIPATION VALUES (5,2);
INSERT INTO PARTICIPATION VALUES (6,2);
INSERT INTO PARTICIPATION VALUES (5,3);
INSERT INTO PARTICIPATION VALUES (1,3);
INSERT INTO PARTICIPATION VALUES (2,3);
INSERT INTO PARTICIPATION VALUES (7,4);
INSERT INTO PARTICIPATION VALUES (8,4);
INSERT INTO PARTICIPATION VALUES (9,4);
