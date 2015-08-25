use Form112

CREATE TABLE Durees ( 
	IdDuree              int NOT NULL   IDENTITY,
	NbJours              nvarchar(20) NOT NULL   ,
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
	Nom                  nvarchar(50) NOT NULL   ,
	CONSTRAINT Pk_Themes PRIMARY KEY ( IdTheme )
 );

CREATE TABLE Pays ( 
	IdPays               char(3) NOT NULL   ,
	IdRegion             int NOT NULL   ,
	Nom                  nvarchar(30) NOT NULL   ,
	CONSTRAINT Pk_Pays PRIMARY KEY ( IdPays ),
 );

CREATE TABLE Ports ( 
	IdPort               int NOT NULL   IDENTITY,
	IdPays               char(3) NOT NULL   ,
	Nom                  nvarchar(40) NOT NULL   ,
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
	Description          text NOT NULL   ,
	CONSTRAINT Pk_Croisieres PRIMARY KEY ( IdCroisiere )
 );

CREATE TABLE Photos ( 
	IdPhoto              int NOT NULL   IDENTITY,
	IdCroisiere          int NOT NULL   ,
	NomPhoto             nvarchar(40) NOT NULL   ,
	CONSTRAINT Pk_Photos PRIMARY KEY ( IdPhoto )
 );

CREATE INDEX idx_Photos ON Photos ( IdCroisiere );

ALTER TABLE Croisieres ADD CONSTRAINT fk_croisieres_themes FOREIGN KEY ( IdTheme ) REFERENCES Themes( IdTheme ) ON DELETE NO ACTION ON UPDATE NO ACTION;

ALTER TABLE Croisieres ADD CONSTRAINT fk_croisieres_durees FOREIGN KEY ( IdDuree ) REFERENCES Durees( IdDuree ) ON DELETE NO ACTION ON UPDATE NO ACTION;

ALTER TABLE Croisieres ADD CONSTRAINT fk_croisieres_promos FOREIGN KEY ( IdPromo ) REFERENCES Promos( IdPromo ) ON DELETE NO ACTION ON UPDATE NO ACTION;

ALTER TABLE Croisieres ADD CONSTRAINT fk_croisieres_ports FOREIGN KEY ( IdPort ) REFERENCES Ports( IdPort ) ON DELETE NO ACTION ON UPDATE NO ACTION;

ALTER TABLE Pays ADD CONSTRAINT fk_pays_pays FOREIGN KEY ( IdRegion ) REFERENCES Regions( IdRegion ) ON DELETE NO ACTION ON UPDATE NO ACTION;

ALTER TABLE Photos ADD CONSTRAINT fk_photos_croisieres FOREIGN KEY ( IdCroisiere ) REFERENCES Croisieres( IdCroisiere ) ON DELETE NO ACTION ON UPDATE NO ACTION;

ALTER TABLE Ports ADD CONSTRAINT fk_ports_pays FOREIGN KEY ( IdPays ) REFERENCES Pays( IdPays ) ON DELETE NO ACTION ON UPDATE NO ACTION;

--Insersion de donnes
GO
SET ANSI_PADDING OFF
GO
SET IDENTITY_INSERT [dbo].[Regions] ON 

INSERT [dbo].[Regions] ([IdRegion], [Nom]) VALUES (1, N'Europe')
INSERT [dbo].[Regions] ([IdRegion], [Nom]) VALUES (2, N'Caraïbe')
INSERT [dbo].[Regions] ([IdRegion], [Nom]) VALUES (3, N'Amerique')
INSERT [dbo].[Regions] ([IdRegion], [Nom]) VALUES (4, N'Pacifique')
INSERT [dbo].[Regions] ([IdRegion], [Nom]) VALUES (5, N'Mers Orientales')
INSERT [dbo].[Regions] ([IdRegion], [Nom]) VALUES (6, N'Transatlantique')
SET IDENTITY_INSERT [dbo].[Regions] OFF

SET IDENTITY_INSERT [dbo].[Themes] ON 
INSERT [dbo].[Themes] ([IdTheme], [Nom]) VALUES (1, N'Gastronomique')
INSERT [dbo].[Themes] ([IdTheme], [Nom]) VALUES (2, N'Sports Aquatiques')
INSERT [dbo].[Themes] ([IdTheme], [Nom]) VALUES (3, N'HoneyMoon')
INSERT [dbo].[Themes] ([IdTheme], [Nom]) VALUES (4, N'Famille')
INSERT [dbo].[Themes] ([IdTheme], [Nom]) VALUES (5, N'Noel')
INSERT [dbo].[Themes] ([IdTheme], [Nom]) VALUES (6, N'Nouvel An')
SET IDENTITY_INSERT [dbo].[Themes] OFF


INSERT [dbo].[Pays] ([IdPays], [IdRegion], [Nom]) VALUES ('FRA', 1, N'France')
INSERT [dbo].[Pays] ([IdPays], [IdRegion], [Nom]) VALUES ('TUR', 1, N'Turquie')
INSERT [dbo].[Pays] ([IdPays], [IdRegion], [Nom]) VALUES ('ITA', 1, N'Italie')
INSERT [dbo].[Pays] ([IdPays], [IdRegion], [Nom]) VALUES ('POR', 1, N'Portugal')
INSERT [dbo].[Pays] ([IdPays], [IdRegion], [Nom]) VALUES ('GRE', 1, N'Grèce')
INSERT [dbo].[Pays] ([IdPays], [IdRegion], [Nom]) VALUES ('MAL', 1, N'Malte')
INSERT [dbo].[Pays] ([IdPays], [IdRegion], [Nom]) VALUES ('GRN', 2, N'Grenade')
INSERT [dbo].[Pays] ([IdPays], [IdRegion], [Nom]) VALUES ('GDL', 2, N'Guadaloupe')
INSERT [dbo].[Pays] ([IdPays], [IdRegion], [Nom]) VALUES ('MRT', 2, N'Martinique')
INSERT [dbo].[Pays] ([IdPays], [IdRegion], [Nom]) VALUES ('VEN', 3, N'Venezuela')
INSERT [dbo].[Pays] ([IdPays], [IdRegion], [Nom]) VALUES ('BRE', 3, N'Bresil')
INSERT [dbo].[Pays] ([IdPays], [IdRegion], [Nom]) VALUES ('ARG', 3, N'Argentine')
INSERT [dbo].[Pays] ([IdPays], [IdRegion], [Nom]) VALUES ('AUS', 4, N'Australie')
INSERT [dbo].[Pays] ([IdPays], [IdRegion], [Nom]) VALUES ('SEY', 5, N'Seychelles')


SET IDENTITY_INSERT [dbo].[Promos] ON 
INSERT [dbo].[Promos] ([IdPromo], [Reduction]) VALUES (1, 20)
INSERT [dbo].[Promos] ([IdPromo], [Reduction]) VALUES (2, 30)
INSERT [dbo].[Promos] ([IdPromo], [Reduction]) VALUES (3, 40)
INSERT [dbo].[Promos] ([IdPromo], [Reduction]) VALUES (4, 50)
INSERT [dbo].[Promos] ([IdPromo], [Reduction]) VALUES (5, 60)
SET IDENTITY_INSERT [dbo].[Promos] OFF
 

SET IDENTITY_INSERT [dbo].[Durees] ON 
INSERT [dbo].[Durees] ([IdDuree], [NbJours]) VALUES (1, '5 jours')
INSERT [dbo].[Durees] ([IdDuree], [NbJours]) VALUES (2, '6 jours')
INSERT [dbo].[Durees] ([IdDuree], [NbJours]) VALUES (3, '7 jours')
INSERT [dbo].[Durees] ([IdDuree], [NbJours]) VALUES (4, '8 jours')
INSERT [dbo].[Durees] ([IdDuree], [NbJours]) VALUES (5, '9 jours')
INSERT [dbo].[Durees] ([IdDuree], [NbJours]) VALUES (6, '10 jours')
INSERT [dbo].[Durees] ([IdDuree], [NbJours]) VALUES (7, '11 jours')
INSERT [dbo].[Durees] ([IdDuree], [NbJours]) VALUES (8, '12 jours')
INSERT [dbo].[Durees] ([IdDuree], [NbJours]) VALUES (9, '13 jours')
INSERT [dbo].[Durees] ([IdDuree], [NbJours]) VALUES (10, '14 jours')
INSERT [dbo].[Durees] ([IdDuree], [NbJours]) VALUES (11, '15 jours')
INSERT [dbo].[Durees] ([IdDuree], [NbJours]) VALUES (12, '16 jours')
INSERT [dbo].[Durees] ([IdDuree], [NbJours]) VALUES (13, '17 jours')
INSERT [dbo].[Durees] ([IdDuree], [NbJours]) VALUES (14, '18 jours')
INSERT [dbo].[Durees] ([IdDuree], [NbJours]) VALUES (15, '19 jours')
INSERT [dbo].[Durees] ([IdDuree], [NbJours]) VALUES (16, '20 jours')
SET IDENTITY_INSERT [dbo].[Durees] OFF 

SET IDENTITY_INSERT [dbo].[Ports] ON 
INSERT [dbo].[Ports] ([IdPort], [IdPays],  [Nom]) VALUES (1, 'FRA', 'Marseilles')
INSERT [dbo].[Ports] ([IdPort], [IdPays],  [Nom]) VALUES (2, 'ITA', 'Venice')
INSERT [dbo].[Ports] ([IdPort], [IdPays],  [Nom]) VALUES (3, 'POR', 'Lisbonne')
INSERT [dbo].[Ports] ([IdPort], [IdPays],  [Nom]) VALUES (4, 'GDL', 'Point-à-Pitre')
INSERT [dbo].[Ports] ([IdPort], [IdPays],  [Nom]) VALUES (5, 'MRT', 'Port de France')
INSERT [dbo].[Ports] ([IdPort], [IdPays],  [Nom]) VALUES (6, 'TUR', 'Istanbul')
INSERT [dbo].[Ports] ([IdPort], [IdPays],  [Nom]) VALUES (7, 'FRA', 'Nice')
INSERT [dbo].[Ports] ([IdPort], [IdPays],  [Nom]) VALUES (8, 'VEN', 'Margarita')
INSERT [dbo].[Ports] ([IdPort], [IdPays],  [Nom]) VALUES (9, 'GRE', 'Athènes')
INSERT [dbo].[Ports] ([IdPort], [IdPays],  [Nom]) VALUES (10, 'AUS', 'Brisbane')
SET IDENTITY_INSERT [dbo].[Ports] OFF 


SET IDENTITY_INSERT [dbo].[Croisieres] ON 

INSERT [dbo].[Croisieres] ([IdCroisiere], [IdTheme], [IdDuree], [IdPromo], [IdPort], [Prix], [DateDepart], [Description])
VALUES (1, 3, 6, null, 6, 2790, '10-01-2015', '10 jours / 9 nuits au depart de Istanbul')

INSERT [dbo].[Croisieres] ([IdCroisiere], [IdTheme], [IdDuree], [IdPromo], [IdPort], [Prix], [DateDepart], [Photo], [Description])
VALUES (2, 4, 3, null, 10, 850, '11-01-2015', null, '7 jours / 6 nuits au depart de Brisbane vers Ile des Pines')

INSERT [dbo].[Croisieres] ([IdCroisiere], [IdTheme], [IdDuree], [IdPromo], [IdPort], [Prix], [DateDepart], [Photo], [Description])
VALUES (3, 4, 4, 1, 8, 1950, '12-01-2015', null, '8 jours / 7 nuits au depart de Margarita')

INSERT [dbo].[Croisieres] ([IdCroisiere], [IdTheme], [IdDuree], [IdPromo], [IdPort], [Prix], [DateDepart], [Photo], [Description])
VALUES (4, 5, 1, null, 1, 600, '12-23-2015', null, ' 5 jours / 4 nuits au depart de Marseille')

INSERT [dbo].[Croisieres] ([IdCroisiere], [IdTheme], [IdDuree], [IdPromo], [IdPort], [Prix], [DateDepart], [Photo], [Description])
VALUES (5, 6, 1, null, 3, 650, '12-30-2015', null, '5 jours / 4 nuits au depart de Lisbonne')

INSERT [dbo].[Croisieres] ([IdCroisiere], [IdTheme], [IdDuree], [IdPromo], [IdPort], [Prix], [DateDepart], [Photo], [Description])
VALUES (6, 3, 16, null, 2, 3700, '03-01-2016', null, '20 jours / 19 nuits au depart de Venice')

SET IDENTITY_INSERT [dbo].[Croisieres] OFF 

