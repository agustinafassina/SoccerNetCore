CREATE DATABASE `soccernetcore` /*!40100 DEFAULT CHARACTER SET utf8 */;

/*Tables create for service soccernetcore*/

CREATE TABLE `Team` (
    `Id` int(11) NOT NULL AUTO_INCREMENT,
    `Name` varchar(100) DEFAULT NULL,
    `Country` varchar(50) DEFAULT NULL,
    `Logo` varchar(100) DEFAULT NULL,
    PRIMARY KEY (`Id`)
) ENGINE=InnoDB AUTO_INCREMENT=7 DEFAULT CHARSET=utf8mb4;

CREATE TABLE `Player` (
    `Id` int(11) NOT NULL AUTO_INCREMENT,
    `Name` varchar(100) DEFAULT NULL,
    `LastName` varchar(100) DEFAULT NULL,
    `Country` varchar(100) DEFAULT NULL,
    `Logo` varchar(200) DEFAULT NULL,
    `LogoNameUniq` varchar(200) DEFAULT NULL,
    `TeamId` int(11) DEFAULT NULL,
    PRIMARY KEY (`Id`),
    KEY `player_FK` (`TeamId`),
    CONSTRAINT `player_FK` FOREIGN KEY (`TeamId`) REFERENCES `Team` (`Id`)
) ENGINE=InnoDB AUTO_INCREMENT=57 DEFAULT CHARSET=utf8mb4;

/* Create randoms datas for Team */
INSERT INTO soccernetcore.Team
(Id, Name, Country, Logo)
VALUES(1, 'Barcelona', 'España', NULL);
INSERT INTO soccernetcore.Team
(Id, Name, Country, Logo)
VALUES(2, 'Real Madrid', 'España', NULL);
INSERT INTO soccernetcore.Team
(Id, Name, Country, Logo)
VALUES(3, 'Psg', 'Francia', NULL);
INSERT INTO soccernetcore.Team
(Id, Name, Country, Logo)
VALUES(4, 'Manchester United', 'Inglaterra', NULL);
INSERT INTO soccernetcore.Team
(Id, Name, Country, Logo)
VALUES(5, 'Para borrar', 'borrar', NULL);

/* Create randoms datas for Player */

INSERT INTO soccernetcore.Player
(Id, Name, LastName, Country, Logo, LogoNameUniq, TeamId)
VALUES(2, 'Angel', 'Di Maria', 'Argentina', NULL, NULL, 1);
INSERT INTO soccernetcore.Player
(Id, Name, LastName, Country, Logo, LogoNameUniq, TeamId)
VALUES(3, 'Cuti', 'Romero', 'Argentina', NULL, NULL, 2);
INSERT INTO soccernetcore.Player
(Id, Name, LastName, Country, Logo, LogoNameUniq, TeamId)
VALUES(4, 'Nicolas', 'Otamendi', 'Argentina', NULL, NULL, 2);
INSERT INTO soccernetcore.Player
(Id, Name, LastName, Country, Logo, LogoNameUniq, TeamId)
VALUES(5, 'Cristiano', 'Ronaldo', 'Portugal', 'descarga.png', 'descarga-5a5b2248355443e4a2613dea5cdd6781.png', 2);
INSERT INTO soccernetcore.Player
(Id, Name, LastName, Country, Logo, LogoNameUniq, TeamId)
VALUES(6, 'Daniel', 'Alves', 'Brasil', 'descarga.png', 'descarga-085395ae132542a8a23ee36fcb27be02.png', 2);
INSERT INTO soccernetcore.Player
(Id, Name, LastName, Country, Logo, LogoNameUniq, TeamId)
VALUES(7, 'David', 'Luis', 'Brasil', 'descarga.png', 'descarga-7603748305fd4042bcc25191270d9af1.png', 2);
INSERT INTO soccernetcore.Player
(Id, Name, LastName, Country, Logo, LogoNameUniq, TeamId)
VALUES(8, 'Paolo', 'Guerrero', 'Paraguay', 'descarga.png', 'descarga-8324640dd927459ea47786704108bdd7.png', 2);
INSERT INTO soccernetcore.Player
(Id, Name, LastName, Country, Logo, LogoNameUniq, TeamId)
VALUES(9, 'Gary', 'Medel', 'Chile', '450_1000.jpg', '450_1000-e36756b1a81e43f89a795b9e07e6a6f6.jpg', 2);
INSERT INTO soccernetcore.Player
(Id, Name, LastName, Country, Logo, LogoNameUniq, TeamId)
VALUES(10, 'Dibu', 'Martinez', 'Argentina', '450_1000.jpg', '450_1000-a6a054458011464292b3a71d2b421739.jpg', 2);
INSERT INTO soccernetcore.Player
(Id, Name, LastName, Country, Logo, LogoNameUniq, TeamId)
VALUES(11, 'Paul', 'Pogba', 'Francia', '450_1000.jpg', '450_1000-1629403556.jpg', 3);
INSERT INTO soccernetcore.Player
(Id, Name, LastName, Country, Logo, LogoNameUniq, TeamId)
VALUES(12, 'Antonie', 'Griezman', 'Francia', '450_1000.jpg', '450_1000-1629403964.jpg', 3);
INSERT INTO soccernetcore.Player
(Id, Name, LastName, Country, Logo, LogoNameUniq, TeamId)
VALUES(13, 'Diego', 'Costa', 'Brasil', '450_1000.jpg', '450_1000-1629404264.jpg', 3);
INSERT INTO soccernetcore.Player
(Id, Name, LastName, Country, Logo, LogoNameUniq, TeamId)
VALUES(14, 'Daniel', 'De Rossi', 'Italia', '450_1000.jpg', '450_1000-1629404331.jpg', 4);
INSERT INTO soccernetcore.Player
(Id, Name, LastName, Country, Logo, LogoNameUniq, TeamId)
VALUES(15, 'Pipa', 'Higuain', 'Argentina', '450_1000.jpg', '450_1000-1629404386.jpg', 4);
INSERT INTO soccernetcore.Player
(Id, Name, LastName, Country, Logo, LogoNameUniq, TeamId)
VALUES(16, 'Javier', 'Mascherano', 'Argentina', '450_1000.jpg', '450_1000-1629404807.jpg', 4);
INSERT INTO soccernetcore.Player
(Id, Name, LastName, Country, Logo, LogoNameUniq, TeamId)
VALUES(17, 'Mauro', 'Icardi', 'Argentino', '450_1000.jpg', '450_1000-1629404824.jpg', 4);
INSERT INTO soccernetcore.Player
(Id, Name, LastName, Country, Logo, LogoNameUniq, TeamId)
VALUES(18, 'Kun', 'Aguero', 'Argentino', '450_1000.jpg', '450_1000-1629405198.jpg', 4);
INSERT INTO soccernetcore.Player
(Id, Name, LastName, Country, Logo, LogoNameUniq, TeamId)
VALUES(19, 'Robert', 'Lewandowski', 'Alemania', '450_1000.jpg', '450_1000-1629405209.jpg', 2);
INSERT INTO soccernetcore.Player
(Id, Name, LastName, Country, Logo, LogoNameUniq, TeamId)
VALUES(20, 'Kylian', 'Mbappé ', 'Francia', '450_1000.jpg', '450_1000-1629405246.jpg', 2);
INSERT INTO soccernetcore.Player
(Id, Name, LastName, Country, Logo, LogoNameUniq, TeamId)
VALUES(21, 'Carlos', 'Tevez', 'Argentina', '450_1000.jpg', '450_1000-1629405294.jpg', 2);

ALTER TABLE soccernetcore.Player ADD Birthday DATETIME NULL;
ALTER TABLE soccernetcore.Player ADD Email varchar(100) NULL;
ALTER TABLE soccernetcore.Player ADD StartDate DATETIME NULL;
ALTER TABLE soccernetcore.Player ADD EndDate DATETIME NOT NULL;

ALTER TABLE soccernetcore.Team ADD Email varchar(100) NULL;