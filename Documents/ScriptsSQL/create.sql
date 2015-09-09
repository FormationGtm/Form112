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

INSERT INTO Croisieres([IdTheme],[IdDuree],[IdPromo],[IdPort],[Prix],[DateDepart],[Capacite]) VALUES(4,3,5,2,'7405','2015-11-02',860),(3,1,1,20,'7689','2016-08-07',886),(6,2,4,26,'1256','2016-11-19',783),(1,10,5,19,'9197','2015-12-11',546),(4,7,4,7,'6801','2016-06-20',984),(4,3,1,23,'4464','2016-07-26',586),(6,9,3,25,'7928','2016-05-11',764),(5,8,1,15,'6618','2016-04-22',546),(2,7,3,8,'5251','2016-01-26',942),(3,15,2,12,'8164','2015-12-31',804);
INSERT INTO Croisieres([IdTheme],[IdDuree],[IdPromo],[IdPort],[Prix],[DateDepart],[Capacite]) VALUES(1,16,5,23,'0724','2016-08-27',937),(1,3,5,23,'4976','2015-12-19',661),(2,10,2,6,'2601','2016-08-02',692),(2,14,4,6,'6518','2016-07-07',944),(6,8,5,27,'5155','2016-08-06',608),(4,9,3,10,'1365','2016-09-29',646),(6,7,2,26,'1990','2016-10-16',527),(5,10,3,21,'6571','2016-09-30',606),(4,12,3,19,'6892','2016-12-06',984),(3,11,1,6,'9697','2016-03-24',621);
INSERT INTO Croisieres([IdTheme],[IdDuree],[IdPromo],[IdPort],[Prix],[DateDepart],[Capacite]) VALUES(6,2,5,6,'2087','2016-04-13',926),(2,14,2,16,'1493','2016-01-27',699),(6,2,5,25,'2209','2015-12-18',957),(5,9,3,11,'7266','2015-12-18',763),(1,12,5,23,'6421','2016-02-04',508),(3,8,4,12,'4613','2015-10-29',698),(5,4,4,26,'4248','2015-10-25',698),(4,3,5,1,'6733','2016-03-10',680),(4,16,4,11,'4400','2016-07-10',917),(4,13,3,10,'9174','2016-12-07',846);
INSERT INTO Croisieres([IdTheme],[IdDuree],[IdPromo],[IdPort],[Prix],[DateDepart],[Capacite]) VALUES(1,4,2,3,'4635','2016-01-21',668),(3,3,2,24,'9383','2016-03-06',835),(6,4,3,18,'5186','2015-10-16',662),(2,8,3,24,'4617','2016-09-26',575),(2,9,3,10,'3379','2016-12-08',891),(2,6,1,20,'1780','2016-09-11',816),(3,11,2,6,'8108','2015-11-15',854),(4,5,4,17,'5528','2016-01-19',665),(6,9,2,27,'9753','2016-05-07',518),(1,8,5,26,'9806','2016-09-24',629);
INSERT INTO Croisieres([IdTheme],[IdDuree],[IdPromo],[IdPort],[Prix],[DateDepart],[Capacite]) VALUES(3,5,2,1,'9226','2016-12-06',845),(5,6,2,1,'9172','2015-11-25',735),(3,15,3,13,'4093','2016-07-05',708),(6,5,2,22,'4640','2016-09-10',663),(6,16,2,16,'4849','2016-11-05',926),(2,9,1,15,'7525','2015-11-14',763),(5,7,1,17,'6566','2016-09-09',597),(5,15,5,12,'7064','2015-10-07',940),(5,1,4,27,'4698','2016-12-10',834),(1,8,1,18,'8469','2015-12-16',511);
INSERT INTO Croisieres([IdTheme],[IdDuree],[IdPromo],[IdPort],[Prix],[DateDepart],[Capacite]) VALUES(4,11,4,5,'8301','2015-12-30',958),(1,10,2,12,'0817','2016-01-30',508),(2,2,2,19,'6718','2016-02-27',764),(1,6,2,8,'1970','2016-11-16',530),(4,3,1,26,'8774','2016-05-01',984),(1,1,5,22,'7979','2016-12-09',623),(3,14,4,15,'4073','2016-11-05',903),(6,16,5,11,'4565','2016-01-11',906),(3,2,2,23,'6018','2015-11-06',891),(3,14,3,15,'4277','2015-11-08',849);
INSERT INTO Croisieres([IdTheme],[IdDuree],[IdPromo],[IdPort],[Prix],[DateDepart],[Capacite]) VALUES(3,9,3,6,'5127','2016-06-02',876),(5,16,3,7,'3296','2016-11-27',629),(1,5,3,13,'9072','2016-11-15',559),(5,9,4,15,'6486','2016-08-03',761),(5,11,2,14,'1817','2016-07-25',591),(4,9,1,4,'2052','2015-10-08',794),(6,11,5,27,'1077','2016-11-03',591),(6,8,4,19,'4359','2016-01-16',959),(4,6,2,5,'7159','2016-10-17',771),(2,15,2,9,'5631','2016-10-23',813);
INSERT INTO Croisieres([IdTheme],[IdDuree],[IdPromo],[IdPort],[Prix],[DateDepart],[Capacite]) VALUES(6,1,2,24,'8451','2016-05-22',702),(6,6,5,24,'8672','2016-12-23',891),(6,7,5,26,'5135','2016-11-28',551),(1,7,3,3,'7631','2016-01-02',677),(2,13,3,6,'1034','2016-01-27',661),(3,9,3,17,'5157','2015-12-16',758),(4,6,5,10,'6147','2016-08-19',936),(2,10,4,14,'9166','2016-04-26',952),(2,1,4,13,'3449','2015-12-02',860),(1,14,2,6,'5519','2016-01-02',825);
INSERT INTO Croisieres([IdTheme],[IdDuree],[IdPromo],[IdPort],[Prix],[DateDepart],[Capacite]) VALUES(1,2,3,26,'1487','2016-03-31',831),(1,13,1,11,'9927','2016-10-28',938),(6,12,2,18,'7283','2015-10-06',648),(1,6,2,23,'6897','2016-03-01',854),(1,14,1,26,'5181','2016-06-27',738),(3,2,1,12,'8874','2016-09-01',986),(3,2,1,23,'8126','2015-11-01',824),(3,12,3,17,'2323','2016-06-24',928),(6,4,2,26,'2577','2015-12-25',948),(2,2,4,7,'6329','2016-12-15',799);
INSERT INTO Croisieres([IdTheme],[IdDuree],[IdPromo],[IdPort],[Prix],[DateDepart],[Capacite]) VALUES(1,6,1,14,'2282','2016-11-08',848),(4,4,2,23,'8413','2016-12-14',504),(3,15,4,3,'5278','2016-04-23',635),(6,3,4,15,'1859','2016-09-13',934),(6,8,3,11,'3378','2016-12-05',854),(4,7,1,26,'3201','2016-03-27',965),(4,10,4,17,'9174','2015-10-10',670),(1,7,5,26,'4749','2016-05-16',926),(5,8,4,19,'9792','2016-12-17',669),(1,1,3,13,'7709','2016-06-13',944);

 






