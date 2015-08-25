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
	Description          text NOT NULL   ,
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

--Insersion de donnes
GO
SET ANSI_PADDING OFF
GO
SET IDENTITY_INSERT [dbo].[Regions] ON 

INSERT [dbo].[Regions] ([IdRegion], [Nom]) VALUES (1, N'Europe')
INSERT [dbo].[Regions] ([IdRegion], [Nom]) VALUES (2, N'Cara√Øbe')
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
INSERT [dbo].[Pays] ([CodeIso3], [CodeIso2], [IdRegion], [Nom]) VALUES ('TUR', 'TU', 1, N'Turquie')
INSERT [dbo].[Pays] ([CodeIso3], [CodeIso2], [IdRegion], [Nom]) VALUES ('ITA', 'IT', 1, N'Italie')
INSERT [dbo].[Pays] ([CodeIso3], [CodeIso2], [IdRegion], [Nom]) VALUES ('POR', 'PO', 1, N'Portugal')
INSERT [dbo].[Pays] ([CodeIso3], [CodeIso2], [IdRegion], [Nom]) VALUES ('GRE', 'GC', 1, N'Grece')
INSERT [dbo].[Pays] ([CodeIso3], [CodeIso2], [IdRegion], [Nom]) VALUES ('MAL', 'MA', 1, N'Malte')
INSERT [dbo].[Pays] ([CodeIso3], [CodeIso2], [IdRegion], [Nom]) VALUES ('GRN', 'GR', 2, N'Grenade')
INSERT [dbo].[Pays] ([CodeIso3], [CodeIso2], [IdRegion], [Nom]) VALUES ('GDL', 'GD', 2, N'Guadaloupe')
INSERT [dbo].[Pays] ([CodeIso3], [CodeIso2], [IdRegion], [Nom]) VALUES ('MRT', 'MR', 2, N'Martinique')
INSERT [dbo].[Pays] ([CodeIso3], [CodeIso2], [IdRegion], [Nom]) VALUES ('VEN', 'VE', 3, N'Venezuela')
INSERT [dbo].[Pays] ([CodeIso3], [CodeIso2], [IdRegion], [Nom]) VALUES ('BRE', 'BR', 3, N'Bresil')
INSERT [dbo].[Pays] ([CodeIso3], [CodeIso2], [IdRegion], [Nom]) VALUES ('ARG', 'AR', 3, N'Argentine')
INSERT [dbo].[Pays] ([CodeIso3], [CodeIso2], [IdRegion], [Nom]) VALUES ('AUS', 'AU', 4, N'Australie')
INSERT [dbo].[Pays] ([CodeIso3], [CodeIso2], [IdRegion], [Nom]) VALUES ('SEY', 'SE', 5, N'Seychelles')


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
INSERT [dbo].[Ports] ([IdPort], [CodeIso3],  [Nom], [Latitude], [Longitude]) VALUES (3, 'POR', 'Lisbonne', 38.785215, -9.139776)
INSERT [dbo].[Ports] ([IdPort], [CodeIso3],  [Nom], [Latitude], [Longitude]) VALUES (4, 'GDL', 'Point-a†-Pitre', 16.236964, -61.536809)
INSERT [dbo].[Ports] ([IdPort], [CodeIso3],  [Nom], [Latitude], [Longitude]) VALUES (5, 'MRT', 'Port de France', 14.616854, -61.060681)
INSERT [dbo].[Ports] ([IdPort], [CodeIso3],  [Nom], [Latitude], [Longitude]) VALUES (6, 'TUR', 'Istanbul', 41.008690, 28.981967)
INSERT [dbo].[Ports] ([IdPort], [CodeIso3],  [Nom], [Latitude], [Longitude]) VALUES (7, 'FRA', 'Nice', 43.709271, 7.260027)
INSERT [dbo].[Ports] ([IdPort], [CodeIso3],  [Nom], [Latitude], [Longitude]) VALUES (8, 'VEN', 'Margarita', 10.999217, -63.912641)
INSERT [dbo].[Ports] ([IdPort], [CodeIso3],  [Nom], [Latitude], [Longitude]) VALUES (9, 'GRE', 'Athenes', 37.982922, 23.729756)
INSERT [dbo].[Ports] ([IdPort], [CodeIso3],  [Nom], [Latitude], [Longitude]) VALUES (10, 'AUS', 'Brisbane', -27.471986, 153.057791)
SET IDENTITY_INSERT [dbo].[Ports] OFF 


SET IDENTITY_INSERT [dbo].[Croisieres] ON 

INSERT [dbo].[Croisieres] ([IdCroisiere], [IdTheme], [IdDuree], [IdPromo], [IdPort], [Prix], [DateDepart], [Description])
VALUES (1, 3, 6, null, 6, 2790, '10-01-2015', '10 jours / 9 nuits au depart de Istanbul')

INSERT [dbo].[Croisieres] ([IdCroisiere], [IdTheme], [IdDuree], [IdPromo], [IdPort], [Prix], [DateDepart], [Description])
VALUES (2, 4, 3, null, 10, 850, '11-01-2015', '7 jours / 6 nuits au depart de Brisbane vers Ile des Pines')

INSERT [dbo].[Croisieres] ([IdCroisiere], [IdTheme], [IdDuree], [IdPromo], [IdPort], [Prix], [DateDepart], [Description])
VALUES (3, 4, 4, 1, 8, 1950, '12-01-2015', '8 jours / 7 nuits au depart de Margarita')

INSERT [dbo].[Croisieres] ([IdCroisiere], [IdTheme], [IdDuree], [IdPromo], [IdPort], [Prix], [DateDepart], [Description])
VALUES (4, 5, 1, null, 1, 600, '12-23-2015', ' 5 jours / 4 nuits au depart de Marseille')

INSERT [dbo].[Croisieres] ([IdCroisiere], [IdTheme], [IdDuree], [IdPromo], [IdPort], [Prix], [DateDepart], [Description])
VALUES (5, 6, 1, null, 3, 650, '12-30-2015', '5 jours / 4 nuits au depart de Lisbonne')

INSERT [dbo].[Croisieres] ([IdCroisiere], [IdTheme], [IdDuree], [IdPromo], [IdPort], [Prix], [DateDepart], [Description])
VALUES (6, 3, 16, null, 2, 3700, '03-01-2016', '20 jours / 19 nuits au depart de Venice')

SET IDENTITY_INSERT [dbo].[Croisieres] OFF 
