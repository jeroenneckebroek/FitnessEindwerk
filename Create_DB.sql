CREATE TABLE [dbo].[Admin] (
[AdminId] [int] IDENTITY(1,1) NOT NULL UNIQUE,
[Admin]      VARCHAR (50) NOT NULL,
[Wachtwoord] VARCHAR (50) NOT NULL,
PRIMARY KEY CLUSTERED ([AdminId] ASC)
);

INSERT INTO Admin(Admin,Wachtwoord)
VALUES ('admin','admin')

CREATE TABLE [dbo].[Afspraken] (
[A_Id] [int] IDENTITY(1,1) NOT NULL UNIQUE,
[A_FirstName] [varchar](45) NOT NULL,
[A_LastName] [varchar](45) NOT NULL,
[A_Datum] [varchar](45) NOT NULL,
[A_Toestel] [varchar](45) NOT NULL,
[A_ToestelId] [int] NOT NULL,
[A_Slot] [varchar](45) NOT NULL,
[A_Email] [varchar](45) NOT NULL,
PRIMARY KEY CLUSTERED
(
[A_Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY];

CREATE TABLE [dbo].[klant] (
[K_Id] [int] IDENTITY(1,1) NOT NULL UNIQUE,
[K_FirstName] [varchar](45) NOT NULL,
[K_Name] [varchar](45) NOT NULL,
[K_Email] [varchar](45) NOT NULL UNIQUE,
[K_Gemeente] [varchar](45) NOT NULL,
[K_GeboorteDatum] [varchar](45) NOT NULL,
[K_Intresse] [varchar](45) DEFAULT NULL,
[K_Subscription] [varchar](45) NOT NULL,
PRIMARY KEY CLUSTERED
(
[K_Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY];

CREATE TABLE [dbo].[LoginKlant] (
[L_Id] [int] IDENTITY(1,1) NOT NULL UNIQUE,
[L_Username] [varchar](45) NOT NULL,
[L_Passwoord] [varchar](45) NOT NULL,
PRIMARY KEY CLUSTERED
(
[L_Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY];

CREATE TABLE [dbo].[Machines] (
[M_Id]   INT          IDENTITY (1, 1) NOT NULL,
[M_Type] VARCHAR (45) NOT NULL,
[Huidig] VARCHAR (45) DEFAULT ('Actief') NULL,
PRIMARY KEY CLUSTERED ([M_Id] ASC),
UNIQUE NONCLUSTERED ([M_Id] ASC)
);

CREATE TABLE [dbo].[Tijdsloten] (
[T_Id] [int] IDENTITY(1,1) NOT NULL UNIQUE,
[T_Uur] [varchar](45) NOT NULL,
[T_Duur] [int] NOT NULL,
PRIMARY KEY CLUSTERED
(
[T_Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY];

INSERT INTO Tijdsloten(T_Uur,T_Duur)
VALUES ('8u','60')

INSERT INTO Tijdsloten(T_Uur,T_Duur)
VALUES ('9u','60')

INSERT INTO Tijdsloten(T_Uur,T_Duur)
VALUES ('10u','60')

INSERT INTO Tijdsloten(T_Uur,T_Duur)
VALUES ('11u','60')

INSERT INTO Tijdsloten(T_Uur,T_Duur)
VALUES ('12u','60')

INSERT INTO Tijdsloten(T_Uur,T_Duur)
VALUES ('13u','60')

INSERT INTO Tijdsloten(T_Uur,T_Duur)
VALUES ('15u','60')

INSERT INTO Tijdsloten(T_Uur,T_Duur)
VALUES ('16u','60')

INSERT INTO Tijdsloten(T_Uur,T_Duur)
VALUES ('17u','60')

INSERT INTO Tijdsloten(T_Uur,T_Duur)
VALUES ('18u','60')

INSERT INTO Tijdsloten(T_Uur,T_Duur)
VALUES ('19u','60')

INSERT INTO Tijdsloten(T_Uur,T_Duur)
VALUES ('20u','60')

INSERT INTO Tijdsloten(T_Uur,T_Duur)
VALUES ('21u','60')