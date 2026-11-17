CREATE DATABASE Proizvodnja
GO

USE Proizvodnja
GO

CREATE TABLE Sektor
(
	SektorID INT PRIMARY KEY IDENTITY(1,1) NOT NULL,
	NazivSektora NVARCHAR(100) NOT NULL,
	TipSektora NVARCHAR(50) NOT NULL,
	MaksimalnaDnevnaKolicina INT NULL
);

CREATE TABLE Korisnik(
	KorisnikID INT PRIMARY KEY IDENTITY(1,1) NOT NULL,
	Ime NVARCHAR(50) NOT NULL,
	Prezime NVARCHAR(50) NOT NULL,
	KorisnickoIme NVARCHAR(50) NOT NULL,
	Lozinka NVARCHAR(50) NOT NULL,
	Uloga NVARCHAR(50) NOT NULL
)

CREATE TABLE DeoProizvoda
(
	DeoID INT PRIMARY KEY IDENTITY(1,1) NOT NULL,
	NazivDela NVARCHAR(100) NOT NULL,
	OpisDela NVARCHAR(255) NOT NULL
);

CREATE TABLE Proizvod
(
	ProizvodID INT PRIMARY KEY IDENTITY(1,1) NOT NULL,
	NazivProizvoda NVARCHAR(100) NOT NULL,
	OpisProizvoda NVARCHAR(255) NOT NULL
);

CREATE TABLE SastavnicaProizvoda
(
	SastavnicaProizvodaID INT PRIMARY KEY IDENTITY(1,1) NOT NULL,
	ProizvodID INT NOT NULL,
	DeoID INT NOT NULL,
	KolicinaDelova INT NOT NULL,
	CONSTRAINT UQ_SastavnicaProizvoda UNIQUE (ProizvodID, DeoID)
);

ALTER TABLE SastavnicaProizvoda
ADD CONSTRAINT FK_SastavnicaProizvoda_DeoProizvoda
FOREIGN KEY (DeoID) REFERENCES DeoProizvoda(DeoID)
ON DELETE CASCADE;

ALTER TABLE SastavnicaProizvoda
ADD CONSTRAINT FK_SastavnicaProizvoda_Proizvod
FOREIGN KEY (ProizvodID) REFERENCES Proizvod(ProizvodID)
ON DELETE CASCADE;

CREATE TABLE Kupac
(
	KupacID INT PRIMARY KEY IDENTITY(1,1) NOT NULL,
	NazivKupca NVARCHAR(100) NOT NULL,
	Adresa NVARCHAR(100) NOT NULL,
	Telefon NVARCHAR(50) NOT NULL,
	Email NVARCHAR(100)
);

CREATE TABLE Porudzbina
(
	PorudzbinaID INT PRIMARY KEY IDENTITY(1,1) NOT NULL,
	DatumPorudzbine DATE NOT NULL DEFAULT GETDATE(),
	KupacID INT NOT NULL
);

CREATE TABLE StavkePorudzbine
(
	StavkePorudzbineID INT PRIMARY KEY IDENTITY(1,1) NOT NULL,
	PorudzbinaID INT NOT NULL,
	ProizvodID INT NOT NULL,
	Kolicina INT NOT NULL,
	CenaPoJedinici DECIMAL (10,2) NOT NULL,
	UkupnaCena AS (Kolicina * CenaPoJedinici) PERSISTED
);

ALTER TABLE Porudzbina
ADD CONSTRAINT FK_Porudzbina_Kupac
FOREIGN KEY (KupacID) REFERENCES Kupac(KupacID);

ALTER TABLE StavkePorudzbine
ADD CONSTRAINT FK_StavkePorudzbine_Porudzbina
FOREIGN KEY (PorudzbinaID) REFERENCES Porudzbina(PorudzbinaID);

ALTER TABLE StavkePorudzbine
ADD CONSTRAINT FK_StavkePorudzbine
FOREIGN KEY (ProizvodID) REFERENCES Proizvod(ProizvodID);

CREATE TABLE PlanProizvodnje
(
	PlanID INT PRIMARY KEY IDENTITY(1,1) NOT NULL,
	DatumRokaIzrade DATE NOT NULL,
	PorudzbinaID INT NOT NULL,
	StatusPlana NVARCHAR(50) NOT NULL
);

CREATE TABLE DetaljniPlanProizvodnje
(
	DetaljniPlanID INT PRIMARY KEY IDENTITY(1,1) NOT NULL,
	PlanID INT NOT NULL,
	StavkePorudzbineID INT NOT NULL,
	SastavnicaProizvodaID INT NOT NULL,
	Kolicina INT NOT NULL
);

ALTER TABLE PlanProizvodnje
ADD CONSTRAINT FK_PlanProizvodnje_Porudzbina
FOREIGN KEY (PorudzbinaID) REFERENCES Porudzbina(PorudzbinaID);

ALTER TABLE DetaljniPlanProizvodnje
ADD CONSTRAINT FK_DetaljniPlanProizvodnje_PlanProizvodnje
FOREIGN KEY (PlanID) REFERENCES PlanProizvodnje(PlanID)
ON DELETE CASCADE;

ALTER TABLE DetaljniPlanProizvodnje
ADD CONSTRAINT FK_DetaljniPlanProizvodnje_SastavnicaProizvoda
FOREIGN KEY (SastavnicaProizvodaID) REFERENCES SastavnicaProizvoda(SastavnicaProizvodaID);

CREATE TABLE RealizacijaDelova
(
	RealizacijaDelovaID INT PRIMARY KEY IDENTITY(1,1) NOT NULL,
	DeoID INT NOT NULL,
	RealizovanaKolicina INT NOT NULL,
	DatumRealizacije DATE NOT NULL DEFAULT GETDATE(),
	SektorID INT NOT NULL
);

CREATE TABLE RealizacijaProizvoda
(
	RealizacijaProizvodaID INT PRIMARY KEY IDENTITY(1,1) NOT NULL,
	ProizvodID INT NOT NULL,
	RealizovanaKolicina INT NOT NULL,
	DatumRealizacije DATE NOT NULL DEFAULT GETDATE(),
	SektorID INT NOT NULL
);

ALTER TABLE RealizacijaDelova
ADD CONSTRAINT FK_RealizacijaDelova_DeoProizvoda
FOREIGN KEY (DeoID) REFERENCES DeoProizvoda(DeoID);

ALTER TABLE RealizacijaDelova
ADD CONSTRAINT FK_RealizacijaDelova_Sektor
FOREIGN KEY (SektorID) REFERENCES Sektor(SektorID);

ALTER TABLE RealizacijaProizvoda
ADD CONSTRAINT FK_RealizacijaProizvoda_Proizvod
FOREIGN KEY (ProizvodID) REFERENCES Proizvod(ProizvodID);

ALTER TABLE RealizacijaProizvoda
ADD CONSTRAINT FK_RealizacijaProizvoda_Sektor
FOREIGN KEY (SektorID) REFERENCES Sektor(SektorID);