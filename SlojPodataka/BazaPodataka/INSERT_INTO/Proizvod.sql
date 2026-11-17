USE Proizvodnja
GO

INSERT INTO DeoProizvoda (NazivDela, OpisDela)
VALUES
('Procesor', 'Elektronska komponenta za izvršavanje instrukcija i obradu podataka.'),
('Grafička kartica', 'Uređaj koji omogućava prikaz slike i grafičke obrade podataka.'),
('Hard disk', 'Skladišni uređaj za trajno čuvanje podataka.'),
('RAM memorija', 'Radna memorija za privremeno čuvanje podataka tokom rada sistema.'),
('Ekran', 'Komponenta koja omogućava prikaz vizuelnog sadržaja');

INSERT INTO Proizvod (NazivProizvoda, OpisProizvoda)
VALUES
('Laptop', 'Prenosivi računar namenjen radu, edukaciji i multimediji.'),
('Desktop računar', 'Stoni računar dizajniran za kancelarijski i proizvodni rad.'),
('Monitor', 'Eksterni uređaj za prikazivanje vizuelnog sadržaja');

INSERT INTO SastavnicaProizvoda (ProizvodID, DeoID, KolicinaDelova)
VALUES
(1, 1, 1), -- Laptop - 1 procesor
(1, 2, 1), -- Laptop - 1 grafička kartica
(1, 3, 1), -- Laptop - 1 hard disk
(1, 4, 2), -- Laptop - 2 RAM memorije

(2, 1, 1), -- Desktop - 1 procesor
(2, 2, 1), -- Desktop - 1 grafička kartica
(2, 3, 2), -- Desktop - 2 hard diska
(2, 4, 4), -- Desktop - 4 RAM memorije

(3, 5, 1); -- Monitor - 1 ekran