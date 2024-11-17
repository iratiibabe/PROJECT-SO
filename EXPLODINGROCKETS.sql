DROP DATABASE IF EXISTS EXPLODINGROCKETS;
CREATE DATABASE EXPLODINGROCKETS;

USE EXPLODINGROCKETS;

CREATE TABLE PLAYERS (
	ID INT NOT NULL AUTO_INCREMENT,
	USERNAME VARCHAR(60),
	PASSWORD VARCHAR(60),
	POINTS INT DEFAULT 0,
	PRIMARY KEY (ID)
)ENGINE=InnoDB;

CREATE TABLE MATCHES (
	ID INT NOT NULL AUTO_INCREMENT,
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

CREATE TABLE POSITIONS(
	ID_PLAYER INT,
	FOREIGN KEY (ID_PLAYER) REFERENCES PLAYERS(ID),
	POSITION_ROCKET FLOAT
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


