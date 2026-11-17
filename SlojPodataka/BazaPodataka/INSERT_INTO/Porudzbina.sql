USE Proizvodnja
GO

INSERT INTO Porudzbina (KupacID)
VALUES
(1),
(2);

INSERT INTO StavkePorudzbine  (PorudzbinaID, ProizvodID, Kolicina, CenaPoJedinici)
VALUES
(1, 1, 30, 25000),
(2, 2, 45, 75000),
(2, 3, 45, 60000);