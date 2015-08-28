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
INSERT [dbo].[Ports] ([IdPort], [CodeIso3],  [Nom], [Latitude], [Longitude]) VALUES (4, 'FRA', 'Point-a†-Pitre', 16.236964, -61.536809)
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


