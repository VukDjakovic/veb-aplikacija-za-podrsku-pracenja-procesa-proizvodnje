USE Proizvodnja
GO

CREATE PROCEDURE sp_Korisnik
(
@KorisnickoIme NVARCHAR(50),
@Lozinka NVARCHAR(50)
)
AS
SELECT * FROM Korisnik WHERE Korisnik.KorisnickoIme = @KorisnickoIme and Korisnik.Lozinka = @Lozinka
GO

CREATE PROCEDURE sp_Sektor_Prikaz
AS SELECT * FROM Sektor
GO

CREATE PROCEDURE sp_Sektor_PrikazPoIDu
(
	@SektorID INT
)
AS SELECT * FROM Sektor WHERE Sektor.SektorID = @SektorID
GO

CREATE PROCEDURE sp_DetaljniPlanProizvodnje_AutomatskiUnos
(
    @PlanID INT
)
AS
BEGIN
    SET NOCOUNT ON;

    DECLARE @PorudzbinaID INT;

    SELECT @PorudzbinaID = PorudzbinaID
    FROM PlanProizvodnje
    WHERE PlanID = @PlanID;

    INSERT INTO DetaljniPlanProizvodnje (PlanID, StavkePorudzbineID, SastavnicaProizvodaID, Kolicina)
    SELECT 
        @PlanID AS PlanID,
        sp.StavkePorudzbineID,
        s.SastavnicaProizvodaID,
        sp.Kolicina * s.KolicinaDelova AS Kolicina
    FROM StavkePorudzbine sp
    INNER JOIN SastavnicaProizvoda s ON sp.ProizvodID = s.ProizvodID
    WHERE sp.PorudzbinaID = @PorudzbinaID;
END
GO


CREATE PROCEDURE sp_PlanProizvodnje_Unos
(
    @DatumRokaIzrade DATE,
    @PorudzbinaID INT,
    @StatusPlana NVARCHAR(50)
)
AS
BEGIN
    SET NOCOUNT ON;

    INSERT INTO PlanProizvodnje (DatumRokaIzrade, PorudzbinaID, StatusPlana)
    VALUES (@DatumRokaIzrade, @PorudzbinaID, @StatusPlana);

    DECLARE @NoviPlanID INT = SCOPE_IDENTITY();

    EXEC sp_DetaljniPlanProizvodnje_AutomatskiUnos @NoviPlanID;
END
GO


CREATE PROCEDURE sp_PlanProizvodnje_Brisanje
(
	@PlanID INT
)
AS
BEGIN
DELETE FROM PlanProizvodnje WHERE PlanID=@PlanID
END
GO

CREATE PROCEDURE sp_PlanProizvodnje_Izmena
(
	@PlanID INT,
	@DatumRokaIzrade DATE,
	@StatusPlana NVARCHAR(50)
)
AS
BEGIN
UPDATE PlanProizvodnje SET DatumRokaIzrade=@DatumRokaIzrade, StatusPlana=@StatusPlana WHERE PlanID=@PlanID
END
GO

CREATE PROCEDURE sp_RealizacijaDelova_Unos
(
	@DeoID INT,
	@RealizovanaKolicina INT,
	@DatumRealizacije DATE,
	@SektorID INT
)
AS
BEGIN
INSERT INTO RealizacijaDelova (DeoID, RealizovanaKolicina, DatumRealizacije, SektorID) VALUES (@DeoID, @RealizovanaKolicina, @DatumRealizacije, @SektorID)
END
GO

CREATE PROCEDURE sp_RealizacijaDelova_Brisanje
(
	@RealizacijaDelovaID INT
)
AS
BEGIN
DELETE FROM RealizacijaDelova WHERE RealizacijaDelovaID=@RealizacijaDelovaID
END
GO

CREATE PROCEDURE sp_RealizacijaDelova_Izmena
(
	@RealizacijaDelovaID INT,
	@DeoID INT,
	@RealizovanaKolicina INT,
	@DatumRealizacije DATE,
	@SektorID INT
)
AS
BEGIN
UPDATE RealizacijaDelova SET DeoID=@DeoID, RealizovanaKolicina=@RealizovanaKolicina, DatumRealizacije=@DatumRealizacije, SektorID=@SektorID WHERE RealizacijaDelovaID=@RealizacijaDelovaID
END
GO

CREATE PROCEDURE sp_RealizacijaProizvoda_Unos
(
	@ProizvodID INT,
	@RealizovanaKolicina INT,
	@DatumRealizacije DATE,
	@SektorID INT
)
AS
BEGIN
INSERT INTO RealizacijaProizvoda (ProizvodID, RealizovanaKolicina, DatumRealizacije, SektorID) VALUES (@ProizvodID, @RealizovanaKolicina, @DatumRealizacije, @SektorID)
END
GO

CREATE PROCEDURE sp_RealizacijaProizvoda_Brisanje
(
	@RealizacijaProizvodaID INT
)
AS
BEGIN
DELETE FROM RealizacijaProizvoda WHERE RealizacijaProizvodaID=@RealizacijaProizvodaID
END
GO

CREATE PROCEDURE sp_RealizacijaProizvoda_Izmena
(
	@RealizacijaProizvodaID INT,
	@ProizvodID INT,
	@RealizovanaKolicina INT,
	@DatumRealizacije DATE,
	@SektorID INT
)
AS
BEGIN
UPDATE RealizacijaProizvoda SET ProizvodID=@ProizvodID, RealizovanaKolicina=@RealizovanaKolicina, DatumRealizacije=@DatumRealizacije, SektorID=@SektorID WHERE RealizacijaProizvodaID=@RealizacijaProizvodaID
END
GO

CREATE PROCEDURE sp_Porudzbina_Prikaz
	@PorudzbinaID INT = NULL
AS
BEGIN
    IF @PorudzbinaID = 0
    BEGIN
        SELECT * FROM vw_Porudzbine
        ORDER BY DatumPorudzbine DESC
    END
    ELSE
    BEGIN
        SELECT * FROM vw_Porudzbine
        WHERE PorudzbinaID = @PorudzbinaID
        ORDER BY DatumPorudzbine DESC
    END
END
GO


CREATE PROCEDURE sp_Plan_Prikaz
	@PlanID INT = NULL
AS
BEGIN
	IF @PlanID = 0
	BEGIN
		SELECT * FROM vw_Plan
		ORDER BY DatumRokaIzrade DESC
	END
	ELSE
	BEGIN
		SELECT * FROM vw_Plan
		WHERE PlanID=@PlanID
		ORDER BY DatumRokaIzrade DESC
	END
END
GO

CREATE PROCEDURE sp_RealizacijaDelova_Prikaz
	@RealizacijaDelovaID INT = NULL
AS
BEGIN
	IF @RealizacijaDelovaID = 0
	BEGIN
		SELECT * FROM vw_RealizacijaDelova
		ORDER BY DatumRealizacije DESC
	END
	ELSE
	BEGIN
		SELECT * FROM vw_RealizacijaDelova
		WHERE RealizacijaDelovaID = @RealizacijaDelovaID
		ORDER BY DatumRealizacije DESC
	END
END
GO

CREATE PROCEDURE sp_RealizacijaProizvoda_Prikaz
	@RealizacijaProizvodaID INT = NULL
AS
BEGIN
	IF @RealizacijaProizvodaID = 0
	BEGIN
		SELECT * FROM vw_RealizacijaProizvoda
		ORDER BY DatumRealizacije DESC
	END
	ELSE
	BEGIN
		SELECT * FROM vw_RealizacijaProizvoda
		WHERE RealizacijaProizvodaID = @RealizacijaProizvodaID
		ORDER BY DatumRealizacije DESC
	END
END
GO