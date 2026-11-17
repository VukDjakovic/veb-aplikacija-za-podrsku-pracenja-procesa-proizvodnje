USE Proizvodnja
GO

CREATE VIEW vw_Porudzbine AS
SELECT
	p.PorudzbinaID,
	p.DatumPorudzbine,
	k.NazivKupca,
	sp.StavkePorudzbineID,
	sp.ProizvodID,
	pr.NazivProizvoda,
	sp.Kolicina,
	sp.CenaPoJedinici,
	sp.UkupnaCena
FROM Porudzbina p
JOIN Kupac k ON p.KupacID=k.KupacID
JOIN StavkePorudzbine sp ON p.PorudzbinaID=sp.PorudzbinaID
JOIN Proizvod pr ON sp.ProizvodID=pr.ProizvodID;
GO

CREATE VIEW vw_Plan AS
SELECT
	pl.PlanID,
	pl.DatumRokaIzrade,
	pl.PorudzbinaID,
	pl.StatusPlana,
	pr.ProizvodID,
	pr.NazivProizvoda,
	SUM(sp.Kolicina) AS PotrebnaKolicinaProizvoda,
	d.DeoID,
	d.NazivDela,
	SUM(sp.Kolicina * s.KolicinaDelova) AS PotrebnaKolicinaDelova
FROM PlanProizvodnje pl
JOIN Porudzbina p ON pl.PorudzbinaID = p.PorudzbinaID
JOIN StavkePorudzbine sp ON p.PorudzbinaID = sp.PorudzbinaID
JOIN Proizvod pr ON sp.ProizvodID = pr.ProizvodID
JOIN SastavnicaProizvoda s ON pr.ProizvodID = s.ProizvodID
JOIN DeoProizvoda d ON s.DeoID = d.DeoID
GROUP BY
	pl.PlanID,
	pl.DatumRokaIzrade,
	pl.PorudzbinaID,
	pl.StatusPlana,
	pr.ProizvodID,
	pr.NazivProizvoda,
	d.DeoID,
	d.NazivDela;
GO

CREATE VIEW vw_RealizacijaDelova AS
SELECT 
	rd.RealizacijaDelovaID,
	rd.DatumRealizacije,
	rd.RealizovanaKolicina,
	d.DeoID,
	d.NazivDela,
	d.OpisDela,
	s.SektorID,
	s.NazivSektora,
	s.TipSektora
FROM RealizacijaDelova rd
JOIN DeoProizvoda d ON rd.DeoID = d.DeoID
JOIN Sektor s ON rd.SektorID = s.SektorID;
GO

CREATE VIEW vw_RealizacijaProizvoda AS
SELECT 
	rp.RealizacijaProizvodaID,
	rp.DatumRealizacije,
	rp.RealizovanaKolicina,
	p.ProizvodID,
	p.NazivProizvoda,
	p.OpisProizvoda,
	s.SektorID,
	s.NazivSektora,
	s.TipSektora
FROM RealizacijaProizvoda rp
JOIN Proizvod p ON rp.ProizvodID = p.ProizvodID
JOIN Sektor s ON rp.SektorID = s.SektorID;
GO