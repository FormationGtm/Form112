use Form112

CREATE TABLE dbo.LogAction (
  IdNlog int IDENTITY(1, 1) NOT NULL,
  DateNlog datetime2(7) NULL,
  Area varchar(30) COLLATE French_CI_AS NULL,
  Controller varchar(30) COLLATE French_CI_AS NULL,
  Action varchar(30) COLLATE French_CI_AS NULL,
  Parameters varchar(1000) COLLATE French_CI_AS NULL,
  PRIMARY KEY CLUSTERED (IdNlog)
    WITH (
      PAD_INDEX = OFF, IGNORE_DUP_KEY = OFF, STATISTICS_NORECOMPUTE = OFF,
      ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON)
)

CREATE TABLE Durees ( 
	IdDuree              int NOT NULL   IDENTITY,
	NbJours              int NOT NULL   ,
	CONSTRAINT Pk_Durees PRIMARY KEY ( IdDuree )
 );

CREATE TABLE Promos ( 
	IdPromo              int NOT NULL   IDENTITY,
	Reduction            int   ,
	CONSTRAINT Pk_Promos PRIMARY KEY ( IdPromo )
 );

CREATE TABLE Regions ( 
	IdRegion             int NOT NULL   IDENTITY,
	Nom                  nvarchar(30) NOT NULL   ,
	CONSTRAINT Pk_Regions PRIMARY KEY ( IdRegion )
 );

CREATE TABLE Themes ( 
	IdTheme              int NOT NULL   IDENTITY,
	Libelle                  nvarchar(50) NOT NULL   ,
	CONSTRAINT Pk_Themes PRIMARY KEY ( IdTheme )
 );

CREATE TABLE Pays ( 
	CodeIso3             char(3) NOT NULL   ,
	CodeIso2			 char(2) not null,
	IdRegion             int NOT NULL   ,
	Nom                  nvarchar(30) NOT NULL   ,
	CONSTRAINT Pk_Pays PRIMARY KEY ( CodeIso3 ),
 );

CREATE TABLE Ports ( 
	IdPort               int NOT NULL   IDENTITY,
	CodeIso3               char(3) NOT NULL   ,
	Nom                  nvarchar(40) NOT NULL   ,
	Latitude			 double precision not null,
	Longitude			 double precision not null,
	CONSTRAINT Pk_Ports PRIMARY KEY ( IdPort )
 );


CREATE TABLE Croisieres ( 
	IdCroisiere          int NOT NULL   IDENTITY,
	IdTheme              int NOT NULL   ,
	IdDuree              int NOT NULL   ,
	IdPromo              int    ,
	IdPort               int NOT NULL   ,
	Prix                 int NOT NULL   ,
	DateDepart			 Date NOT NULL   ,
	Photo                nvarchar(50)   ,
	Description          text ,
	CONSTRAINT Pk_Croisieres PRIMARY KEY ( IdCroisiere )
 );

CREATE TABLE [dbo].[Photos](
	[PhotoName] [varchar](100) NOT NULL,
	[IdCroisiere] [int] NOT NULL,
	[IdPhoto] [uniqueidentifier] NOT NULL,
 CONSTRAINT [Pk_Photos] PRIMARY KEY CLUSTERED 
(
	[IdPhoto] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

CREATE INDEX idx_Photos ON Photos ( IdCroisiere );


ALTER TABLE Croisieres ADD CONSTRAINT fk_croisieres_themes FOREIGN KEY ( IdTheme ) REFERENCES Themes( IdTheme ) ON DELETE NO ACTION ON UPDATE NO ACTION;

ALTER TABLE Croisieres ADD CONSTRAINT fk_croisieres_durees FOREIGN KEY ( IdDuree ) REFERENCES Durees( IdDuree ) ON DELETE NO ACTION ON UPDATE NO ACTION;

ALTER TABLE Croisieres ADD CONSTRAINT fk_croisieres_promos FOREIGN KEY ( IdPromo ) REFERENCES Promos( IdPromo ) ON DELETE NO ACTION ON UPDATE NO ACTION;

ALTER TABLE Croisieres ADD CONSTRAINT fk_croisieres_ports FOREIGN KEY ( IdPort ) REFERENCES Ports( IdPort ) ON DELETE NO ACTION ON UPDATE NO ACTION;

ALTER TABLE Pays ADD CONSTRAINT fk_pays_pays FOREIGN KEY ( IdRegion ) REFERENCES Regions( IdRegion ) ON DELETE NO ACTION ON UPDATE NO ACTION;

ALTER TABLE Photos ADD CONSTRAINT fk_photos_croisieres FOREIGN KEY ( IdCroisiere ) REFERENCES Croisieres( IdCroisiere ) ON DELETE NO ACTION ON UPDATE NO ACTION;

ALTER TABLE Ports ADD CONSTRAINT fk_ports_pays FOREIGN KEY ( CodeIso3 ) REFERENCES Pays( CodeIso3 ) ON DELETE NO ACTION ON UPDATE NO ACTION;
--Ajouter une colonne "Capacité" et "MoyenPaiement"
ALTER TABLE Croisieres ADD Capacite int
ALTER TABLE Croisieres ADD MoyenPaiement int

--Création de la table Reservation 
CREATE TABLE Reservations ( 
	IdReservation          int NOT NULL   IDENTITY,
	IdCroisiere              int NOT NULL   ,
	IdUtilisateur              nvarchar(128) NOT NULL   ,
	NbPlace                 int NOT NULL   ,
	MoyenPaiement           char(10) not null,
	DateReservation			 Date NOT NULL   ,

	CONSTRAINT Pk_Reservations PRIMARY KEY (IdReservation)
 );

 ALTER TABLE Reservations ADD CONSTRAINT fk_reservations_Croisieres FOREIGN KEY (IdCroisiere) REFERENCES Croisieres( IdCroisiere ) ON DELETE NO ACTION ON UPDATE NO ACTION;
 ALTER TABLE Reservations ADD CONSTRAINT fk_reservations_Utilisateurs FOREIGN KEY (IdUtilisateur) REFERENCES Utilisateurs(Id) ON DELETE NO ACTION ON UPDATE NO ACTION;
 
 --Création de la table "ModePaymant"
 Create table MoyensPaiement(
 IdMoyenPaiement int not null identity,
 Titre char(10) ,
 constraint pk_MoyensPaiement primary key (IdMoyenPaiement)
 );


--Insersion de donnes
GO
SET ANSI_PADDING OFF
GO
SET IDENTITY_INSERT [dbo].[Regions] ON 

INSERT [dbo].[Regions] ([IdRegion], [Nom]) VALUES (1, N'Europe')
INSERT [dbo].[Regions] ([IdRegion], [Nom]) VALUES (2, N'CaraÃ¯be')
INSERT [dbo].[Regions] ([IdRegion], [Nom]) VALUES (3, N'Amerique')
INSERT [dbo].[Regions] ([IdRegion], [Nom]) VALUES (4, N'Pacifique')
INSERT [dbo].[Regions] ([IdRegion], [Nom]) VALUES (5, N'Mers Orientales')
INSERT [dbo].[Regions] ([IdRegion], [Nom]) VALUES (6, N'Transatlantique')
SET IDENTITY_INSERT [dbo].[Regions] OFF

SET IDENTITY_INSERT [dbo].[Themes] ON 
INSERT [dbo].[Themes] ([IdTheme], [Libelle]) VALUES (1, N'Gastronomique')
INSERT [dbo].[Themes] ([IdTheme], [Libelle]) VALUES (2, N'Sports Aquatiques')
INSERT [dbo].[Themes] ([IdTheme], [Libelle]) VALUES (3, N'HoneyMoon')
INSERT [dbo].[Themes] ([IdTheme], [Libelle]) VALUES (4, N'Famille')
INSERT [dbo].[Themes] ([IdTheme], [Libelle]) VALUES (5, N'Noel')
INSERT [dbo].[Themes] ([IdTheme], [Libelle]) VALUES (6, N'Nouvel An')
SET IDENTITY_INSERT [dbo].[Themes] OFF


INSERT [dbo].[Pays] ([CodeIso3], [CodeIso2], [IdRegion], [Nom]) VALUES ('FRA', 'FR', 1, N'France')
INSERT [dbo].[Pays] ([CodeIso3], [CodeIso2], [IdRegion], [Nom]) VALUES ('TUR', 'TR', 1, N'Turquie')
INSERT [dbo].[Pays] ([CodeIso3], [CodeIso2], [IdRegion], [Nom]) VALUES ('ITA', 'IT', 1, N'Italie')
INSERT [dbo].[Pays] ([CodeIso3], [CodeIso2], [IdRegion], [Nom]) VALUES ('PRT', 'PT', 1, N'Portugal')
INSERT [dbo].[Pays] ([CodeIso3], [CodeIso2], [IdRegion], [Nom]) VALUES ('GRC', 'GR', 1, N'Grece')
INSERT [dbo].[Pays] ([CodeIso3], [CodeIso2], [IdRegion], [Nom]) VALUES ('MLT', 'MT', 1, N'Malte')
INSERT [dbo].[Pays] ([CodeIso3], [CodeIso2], [IdRegion], [Nom]) VALUES ('GRD', 'GD', 2, N'Grenade')
INSERT [dbo].[Pays] ([CodeIso3], [CodeIso2], [IdRegion], [Nom]) VALUES ('VEN', 'VE', 3, N'Venezuela')
INSERT [dbo].[Pays] ([CodeIso3], [CodeIso2], [IdRegion], [Nom]) VALUES ('BRA', 'BR', 3, N'Bresil')
INSERT [dbo].[Pays] ([CodeIso3], [CodeIso2], [IdRegion], [Nom]) VALUES ('ARG', 'AR', 3, N'Argentine')
INSERT [dbo].[Pays] ([CodeIso3], [CodeIso2], [IdRegion], [Nom]) VALUES ('AUS', 'AU', 4, N'Australie')
INSERT [dbo].[Pays] ([CodeIso3], [CodeIso2], [IdRegion], [Nom]) VALUES ('SYC', 'SC', 5, N'Seychelles')
INSERT [dbo].[Pays] ([CodeIso3], [CodeIso2], [IdRegion], [Nom]) VALUES ('THA', 'TH', 4, N'Thailande')
INSERT [dbo].[Pays] ([CodeIso3], [CodeIso2], [IdRegion], [Nom]) VALUES ('IDN', 'ID', 4, N'Indonesie')
INSERT [dbo].[Pays] ([CodeIso3], [CodeIso2], [IdRegion], [Nom]) VALUES ('ISR', 'IL', 5, N'Israel')
INSERT [dbo].[Pays] ([CodeIso3], [CodeIso2], [IdRegion], [Nom]) VALUES ('NZL', 'NZ', 4, N'Nouvelle Zelande')
INSERT [dbo].[Pays] ([CodeIso3], [CodeIso2], [IdRegion], [Nom]) VALUES ('PAN', 'PA', 3, N'Panama')
INSERT [dbo].[Pays] ([CodeIso3], [CodeIso2], [IdRegion], [Nom]) VALUES ('MEX', 'MX', 3, N'Mexique')
INSERT [dbo].[Pays] ([CodeIso3], [CodeIso2], [IdRegion], [Nom]) VALUES ('ESP', 'ES', 1, N'Espagne')
INSERT [dbo].[Pays] ([CodeIso3], [CodeIso2], [IdRegion], [Nom]) VALUES ('BHS', 'BS', 2, N'Bahamas')
INSERT [dbo].[Pays] ([CodeIso3], [CodeIso2], [IdRegion], [Nom]) VALUES ('DOM', 'DO', 2, N'Republique Dominicaine')
INSERT [dbo].[Pays] ([CodeIso3], [CodeIso2], [IdRegion], [Nom]) VALUES ('CUW', 'VE', 2, N'Curacao')
INSERT [dbo].[Pays] ([CodeIso3], [CodeIso2], [IdRegion], [Nom]) VALUES ('ABW', 'VE', 2, N'Aruba')
INSERT [dbo].[Pays] ([CodeIso3], [CodeIso2], [IdRegion], [Nom]) VALUES ('DZA', 'DZ', 6, N'Algerie')
INSERT [dbo].[Pays] ([CodeIso3], [CodeIso2], [IdRegion], [Nom]) VALUES ('EGY', 'EG', 6, N'Egypte')
INSERT [dbo].[Pays] ([CodeIso3], [CodeIso2], [IdRegion], [Nom]) VALUES ('ARE', 'AE', 5, N'Emirats Arabs Unis')
INSERT [dbo].[Pays] ([CodeIso3], [CodeIso2], [IdRegion], [Nom]) VALUES ('CHL', 'CL', 4, N'Chili')



SET IDENTITY_INSERT [dbo].[Promos] ON 
INSERT [dbo].[Promos] ([IdPromo], [Reduction]) VALUES (1, 20)
INSERT [dbo].[Promos] ([IdPromo], [Reduction]) VALUES (2, 30)
INSERT [dbo].[Promos] ([IdPromo], [Reduction]) VALUES (3, 40)
INSERT [dbo].[Promos] ([IdPromo], [Reduction]) VALUES (4, 50)
INSERT [dbo].[Promos] ([IdPromo], [Reduction]) VALUES (5, 60)
SET IDENTITY_INSERT [dbo].[Promos] OFF
 

SET IDENTITY_INSERT [dbo].[Durees] ON 
INSERT [dbo].[Durees] ([IdDuree], [NbJours]) VALUES (1, 5)
INSERT [dbo].[Durees] ([IdDuree], [NbJours]) VALUES (2, 6)
INSERT [dbo].[Durees] ([IdDuree], [NbJours]) VALUES (3, 7)
INSERT [dbo].[Durees] ([IdDuree], [NbJours]) VALUES (4, 8)
INSERT [dbo].[Durees] ([IdDuree], [NbJours]) VALUES (5, 9)
INSERT [dbo].[Durees] ([IdDuree], [NbJours]) VALUES (6, 10)
INSERT [dbo].[Durees] ([IdDuree], [NbJours]) VALUES (7, 11)
INSERT [dbo].[Durees] ([IdDuree], [NbJours]) VALUES (8, 12)
INSERT [dbo].[Durees] ([IdDuree], [NbJours]) VALUES (9, 13)
INSERT [dbo].[Durees] ([IdDuree], [NbJours]) VALUES (10, 14)
INSERT [dbo].[Durees] ([IdDuree], [NbJours]) VALUES (11, 15)
INSERT [dbo].[Durees] ([IdDuree], [NbJours]) VALUES (12, 16)
INSERT [dbo].[Durees] ([IdDuree], [NbJours]) VALUES (13, 17)
INSERT [dbo].[Durees] ([IdDuree], [NbJours]) VALUES (14, 18)
INSERT [dbo].[Durees] ([IdDuree], [NbJours]) VALUES (15, 19)
INSERT [dbo].[Durees] ([IdDuree], [NbJours]) VALUES (16, 20)
SET IDENTITY_INSERT [dbo].[Durees] OFF 

SET IDENTITY_INSERT [dbo].[Ports] ON 
INSERT [dbo].[Ports] ([IdPort], [CodeIso3],  [Nom], [Latitude], [Longitude]) VALUES (1, 'FRA', 'Marseille', 43.300508, 5.367373)
INSERT [dbo].[Ports] ([IdPort], [CodeIso3],  [Nom], [Latitude], [Longitude]) VALUES (2, 'ITA', 'Venice', 45.438246, 12.322004)
INSERT [dbo].[Ports] ([IdPort], [CodeIso3],  [Nom], [Latitude], [Longitude]) VALUES (3, 'PRT', 'Lisbonne', 38.785215, -9.139776)
INSERT [dbo].[Ports] ([IdPort], [CodeIso3],  [Nom], [Latitude], [Longitude]) VALUES (4, 'FRA', 'Point-a -Pitre', 16.236964, -61.536809)
INSERT [dbo].[Ports] ([IdPort], [CodeIso3],  [Nom], [Latitude], [Longitude]) VALUES (5, 'FRA', 'Port de France', 14.616854, -61.060681)
INSERT [dbo].[Ports] ([IdPort], [CodeIso3],  [Nom], [Latitude], [Longitude]) VALUES (6, 'TUR', 'Istanbul', 41.008690, 28.981967)
INSERT [dbo].[Ports] ([IdPort], [CodeIso3],  [Nom], [Latitude], [Longitude]) VALUES (7, 'FRA', 'Nice', 43.709271, 7.260027)
INSERT [dbo].[Ports] ([IdPort], [CodeIso3],  [Nom], [Latitude], [Longitude]) VALUES (8, 'VEN', 'Margarita', 10.999217, -63.912641)
INSERT [dbo].[Ports] ([IdPort], [CodeIso3],  [Nom], [Latitude], [Longitude]) VALUES (9, 'GRC', 'Athenes', 37.982922, 23.729756)
INSERT [dbo].[Ports] ([IdPort], [CodeIso3],  [Nom], [Latitude], [Longitude]) VALUES (10, 'AUS', 'Brisbane', -27.471986, 153.057791)
INSERT [dbo].[Ports] ([IdPort], [CodeIso3],  [Nom], [Latitude], [Longitude]) VALUES (11, 'CHL', 'Valparaiso', -33.046918, -71.614825)
INSERT [dbo].[Ports] ([IdPort], [CodeIso3],  [Nom], [Latitude], [Longitude]) VALUES (12, 'AUS', 'Sidney', -33.868220, 151.213570)
INSERT [dbo].[Ports] ([IdPort], [CodeIso3],  [Nom], [Latitude], [Longitude]) VALUES (13, 'MLT', 'Tas-Sliema', 10.201733, -64.638568)
INSERT [dbo].[Ports] ([IdPort], [CodeIso3],  [Nom], [Latitude], [Longitude]) VALUES (14, 'ITA', 'Palermo', 38.111506, 13.363679)
INSERT [dbo].[Ports] ([IdPort], [CodeIso3],  [Nom], [Latitude], [Longitude]) VALUES (15, 'EGY', 'Alexandrie', 31.227352, 29.927129)
INSERT [dbo].[Ports] ([IdPort], [CodeIso3],  [Nom], [Latitude], [Longitude]) VALUES (16, 'DZA', 'Alger', 36.759299, 3.0666166)
INSERT [dbo].[Ports] ([IdPort], [CodeIso3],  [Nom], [Latitude], [Longitude]) VALUES (17, 'PAN', 'Colon', 9.338327, -79.900986)
INSERT [dbo].[Ports] ([IdPort], [CodeIso3],  [Nom], [Latitude], [Longitude]) VALUES (18, 'ABW', 'Oranjestad', 12.508684, -70.007232)
INSERT [dbo].[Ports] ([IdPort], [CodeIso3],  [Nom], [Latitude], [Longitude]) VALUES (19, 'CUW', 'Willenstad', 12.104698, -68.931988)
INSERT [dbo].[Ports] ([IdPort], [CodeIso3],  [Nom], [Latitude], [Longitude]) VALUES (20, 'BHS', 'Nassau', 25.065300, -77.305852)
INSERT [dbo].[Ports] ([IdPort], [CodeIso3],  [Nom], [Latitude], [Longitude]) VALUES (21, 'ESP', 'Ibiza', 38.905425, 1.422181)
INSERT [dbo].[Ports] ([IdPort], [CodeIso3],  [Nom], [Latitude], [Longitude]) VALUES (22, 'IDN', 'Bali', -8.741300, 115.230879)
INSERT [dbo].[Ports] ([IdPort], [CodeIso3],  [Nom], [Latitude], [Longitude]) VALUES (23, 'THA', 'Bangkok', 13.511385, 100.437417)
INSERT [dbo].[Ports] ([IdPort], [CodeIso3],  [Nom], [Latitude], [Longitude]) VALUES (24, 'NZL', 'Auckland', -36.847914, 174.783759)
INSERT [dbo].[Ports] ([IdPort], [CodeIso3],  [Nom], [Latitude], [Longitude]) VALUES (25, 'DOM', 'Punta Cana', 18.611181, -68.338920)
INSERT [dbo].[Ports] ([IdPort], [CodeIso3],  [Nom], [Latitude], [Longitude]) VALUES (26, 'MEX', 'Cancun', 21.167395, -86.808928)
INSERT [dbo].[Ports] ([IdPort], [CodeIso3],  [Nom], [Latitude], [Longitude]) VALUES (27, 'ISR', 'Tel-Aviv', 32.085626, 34.770638)
SET IDENTITY_INSERT [dbo].[Ports] OFF 

--Insertion de Croisieres--

INSERT INTO Croisieres([IdTheme],[IdDuree],[IdPromo],[IdPort],[Prix],[DateDepart]) VALUES(6,10,4,20,'5474','2016-02-11'),(3,8,5,8,'2498','2016-09-29'),(1,10,3,8,'6533','2015-12-03'),(5,10,4,15,'0641','2016-04-25'),(2,11,4,6,'7376','2016-08-25'),(3,9,2,17,'2600','2015-12-07'),(3,1,1,21,'8002','2016-10-09'),(1,11,4,20,'5363','2015-11-11'),(2,11,5,2,'1516','2016-10-18'),(5,5,1,13,'1041','2016-03-20');
INSERT INTO Croisieres([IdTheme],[IdDuree],[IdPromo],[IdPort],[Prix],[DateDepart]) VALUES(1,7,2,18,'8432','2016-09-26'),(3,13,1,11,'9184','2016-10-03'),(1,3,4,9,'9824','2016-11-13'),(2,15,4,19,'9588','2016-03-17'),(4,2,4,14,'2932','2015-12-27'),(6,14,1,27,'6624','2016-04-24'),(5,9,2,18,'1065','2016-01-02'),(3,7,5,6,'3567','2016-10-15'),(2,13,1,13,'9466','2016-04-19'),(6,8,1,26,'0674','2015-11-22');
INSERT INTO Croisieres([IdTheme],[IdDuree],[IdPromo],[IdPort],[Prix],[DateDepart]) VALUES(6,12,2,14,'7230','2016-02-08'),(4,8,5,6,'3870','2016-05-29'),(5,11,2,3,'8147','2016-10-11'),(3,15,5,4,'6051','2016-11-04'),(6,3,5,11,'1362','2016-06-12'),(4,8,5,25,'8991','2015-10-28'),(5,4,4,1,'2713','2016-05-19'),(5,10,5,25,'4123','2016-03-27'),(5,5,5,27,'5830','2016-11-29'),(5,2,5,21,'4701','2016-10-14');
INSERT INTO Croisieres([IdTheme],[IdDuree],[IdPromo],[IdPort],[Prix],[DateDepart]) VALUES(1,16,2,14,'4504','2016-12-20'),(4,12,5,22,'2890','2015-10-07'),(6,6,2,11,'8676','2016-01-07'),(3,15,4,13,'7563','2016-03-10'),(3,14,2,15,'6634','2016-12-19'),(4,15,4,21,'6560','2016-09-26'),(5,6,2,26,'8426','2016-06-23'),(5,2,2,20,'4039','2016-04-10'),(4,8,1,6,'9322','2016-01-14'),(4,5,3,2,'6127','2016-08-05');
INSERT INTO Croisieres([IdTheme],[IdDuree],[IdPromo],[IdPort],[Prix],[DateDepart]) VALUES(5,8,4,22,'3448','2016-04-18'),(1,1,1,12,'4894','2016-11-19'),(6,2,5,3,'3509','2016-03-31'),(3,4,3,9,'8320','2016-03-03'),(1,5,2,6,'2251','2016-12-22'),(6,6,2,23,'9704','2016-09-03'),(1,12,3,11,'5988','2016-07-19'),(4,3,5,19,'2410','2016-12-30'),(6,13,4,27,'7840','2016-09-29'),(2,15,5,20,'4579','2016-11-08');
INSERT INTO Croisieres([IdTheme],[IdDuree],[IdPromo],[IdPort],[Prix],[DateDepart]) VALUES(3,1,5,27,'3800','2016-02-08'),(4,4,3,3,'4758','2015-11-25'),(3,7,4,21,'9935','2015-12-04'),(3,7,2,10,'2827','2016-08-11'),(2,16,1,3,'1479','2016-03-23'),(5,4,1,13,'2586','2015-10-25'),(4,9,4,23,'2508','2015-11-02'),(4,5,1,21,'6417','2016-05-22'),(1,2,2,3,'8758','2016-10-25'),(5,9,4,22,'1513','2016-11-09');
INSERT INTO Croisieres([IdTheme],[IdDuree],[IdPromo],[IdPort],[Prix],[DateDepart]) VALUES(3,10,5,12,'4811','2016-06-03'),(1,2,2,22,'9596','2016-10-05'),(6,2,3,10,'1137','2015-10-28'),(6,11,4,20,'7394','2016-05-31'),(5,3,3,9,'7180','2016-08-22'),(6,12,2,1,'3537','2016-02-20'),(3,9,3,19,'7069','2016-04-29'),(5,1,1,12,'4297','2016-05-22'),(1,14,3,14,'1533','2016-05-16'),(2,14,5,13,'5207','2015-11-04');
INSERT INTO Croisieres([IdTheme],[IdDuree],[IdPromo],[IdPort],[Prix],[DateDepart]) VALUES(3,14,1,22,'9448','2016-05-04'),(4,7,2,9,'2797','2015-12-07'),(5,4,5,11,'3658','2015-12-26'),(2,11,4,19,'6407','2016-04-16'),(2,13,4,27,'9638','2015-11-10'),(4,8,2,13,'5742','2016-09-14'),(6,15,3,27,'1422','2016-07-05'),(6,7,2,15,'1328','2016-07-16'),(3,16,4,4,'5925','2016-06-29'),(3,2,5,8,'1170','2016-02-16');
INSERT INTO Croisieres([IdTheme],[IdDuree],[IdPromo],[IdPort],[Prix],[DateDepart]) VALUES(5,12,4,23,'7496','2016-06-26'),(5,8,3,19,'3844','2016-09-03'),(5,16,2,19,'8164','2016-10-14'),(3,14,3,22,'2454','2016-09-22'),(4,14,1,16,'9050','2016-06-30'),(1,4,3,9,'2847','2016-05-28'),(2,8,4,6,'7597','2015-11-21'),(4,11,2,7,'7705','2015-11-01'),(6,4,4,6,'7155','2016-07-07'),(2,16,1,22,'5148','2016-01-23');
INSERT INTO Croisieres([IdTheme],[IdDuree],[IdPromo],[IdPort],[Prix],[DateDepart]) VALUES(4,9,1,1,'8447','2016-08-04'),(4,3,4,4,'8768','2016-11-11'),(5,16,5,17,'7226','2016-06-18'),(1,15,3,12,'1869','2016-11-27'),(2,12,4,22,'6632','2015-12-27'),(2,8,2,10,'5351','2016-11-03'),(1,16,2,17,'5522','2016-08-31'),(4,15,1,15,'1642','2016-10-19'),(4,13,4,7,'0814','2016-07-03'),(4,16,2,22,'7800','2016-06-11');



