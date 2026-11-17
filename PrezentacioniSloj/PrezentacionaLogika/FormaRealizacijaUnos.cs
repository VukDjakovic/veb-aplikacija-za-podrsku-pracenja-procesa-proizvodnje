using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using KlasePodataka;
using SlojPoslovneLogike;

namespace PrezentacionaLogika
{
    public class FormaRealizacijaUnos
    {
        private PoslovnaPravila pravila;
        private RealizacijaDB realizacijaDB;

        public FormaRealizacijaUnos()
        {
            pravila = new PoslovnaPravila();
            realizacijaDB = new RealizacijaDB();
        }

        public DataSet SektorPrikaz()
        {
            return realizacijaDB.SektorPrikaz();
        }

        public bool RealizacijaDelovaUnos(string deoIDText, string realizovanaKolicinaText, string datumRealizacijeText, int sektorID)
        {
            if (string.IsNullOrWhiteSpace(deoIDText))
                throw new Exception("ID dela mora biti unet!");
            if (!int.TryParse(deoIDText, out int deoID))
                throw new Exception("ID dela mora biti broj!");

            if (string.IsNullOrWhiteSpace(realizovanaKolicinaText))
                throw new Exception("Realizovana količina mora biti uneta!");
            if (!int.TryParse(realizovanaKolicinaText, out int realizovanaKolicina))
                throw new Exception("Realizovana količina mora biti broj!");

            if (string.IsNullOrWhiteSpace(datumRealizacijeText))
                throw new Exception("Datum realizacije mora biti unet!");
            if (!DateTime.TryParse(datumRealizacijeText, out DateTime datumRealizacije))
                throw new Exception("Datum nije u ispravnom formatu!");

            DataSet ds = realizacijaDB.SektorPrikazPoIDu(sektorID);
            string nazivSektora = ds.Tables[0].Rows[0]["NazivSektora"].ToString();

            if (!pravila.ValidirajDatumRealizacije(datumRealizacije))
                throw new Exception("Datum realizacije ne može biti pre današnjeg datuma!");
            if (!pravila.ValidirajKolicinu(nazivSektora, realizovanaKolicina))
                throw new Exception("Uneta količina nije dozvoljena!");

            return realizacijaDB.RealizacijaDelovaUnos(deoID, realizovanaKolicina, datumRealizacije, sektorID);
        }

        public bool RealizacijaDelovaIzmena(int realizacijaID, string deoIDText, string realizovanaKolicinaText, string datumRealizacijeText, int sektorID)
        {
            if (string.IsNullOrWhiteSpace(deoIDText))
                throw new Exception("ID dela mora biti unet!");
            if (!int.TryParse(deoIDText, out int deoID))
                throw new Exception("ID dela mora biti broj!");

            if (string.IsNullOrWhiteSpace(realizovanaKolicinaText))
                throw new Exception("Realizovana količina mora biti uneta!");
            if (!int.TryParse(realizovanaKolicinaText, out int realizovanaKolicina))
                throw new Exception("Realizovana količina mora biti broj!");

            if (string.IsNullOrWhiteSpace(datumRealizacijeText))
                throw new Exception("Datum realizacije mora biti unet!");
            if (!DateTime.TryParse(datumRealizacijeText, out DateTime datumRealizacije))
                throw new Exception("Datum nije u ispravnom formatu!");

            DataSet ds = realizacijaDB.SektorPrikazPoIDu(sektorID);
            string nazivSektora = ds.Tables[0].Rows[0]["NazivSektora"].ToString();

            if (!pravila.ValidirajDatumRealizacije(datumRealizacije))
                throw new Exception("Datum realizacije ne može biti pre današnjeg datuma!");
            if (!pravila.ValidirajKolicinu(nazivSektora, realizovanaKolicina))
                throw new Exception("Uneta količina nije dozvoljena!");

            return realizacijaDB.RealizacijaDelovaIzmena(realizacijaID, deoID, realizovanaKolicina, datumRealizacije, sektorID);
        }

        public bool RealizacijaDelovaBrisanje(int realizacijaID)
        {
            return realizacijaDB.RealizacijaDelovaBrisanje(realizacijaID);
        }

        public bool RealizacijaProizvodaUnos(string proizvodIDText, string realizovanaKolicinaText, string datumRealizacijeText, int sektorID)
        {
            if (string.IsNullOrWhiteSpace(proizvodIDText))
                throw new Exception("ID proizvoda mora biti unet!");
            if (!int.TryParse(proizvodIDText, out int proizvodID))
                throw new Exception("ID proizvoda mora biti broj!");

            if (string.IsNullOrWhiteSpace(realizovanaKolicinaText))
                throw new Exception("Realizovana količina mora biti uneta!");
            if (!int.TryParse(realizovanaKolicinaText, out int realizovanaKolicina))
                throw new Exception("Realizovana količina mora biti broj!");

            if (string.IsNullOrWhiteSpace(datumRealizacijeText))
                throw new Exception("Datum realizacije mora biti unet!");
            if (!DateTime.TryParse(datumRealizacijeText, out DateTime datumRealizacije))
                throw new Exception("Datum nije u ispravnom formatu!");

            DataSet ds = realizacijaDB.SektorPrikazPoIDu(sektorID);
            string nazivSektora = ds.Tables[0].Rows[0]["NazivSektora"].ToString();

            if (!pravila.ValidirajDatumRealizacije(datumRealizacije))
                throw new Exception("Datum realizacije ne može biti pre današnjeg datuma!");
            if (!pravila.ValidirajKolicinu(nazivSektora, realizovanaKolicina))
                throw new Exception("Uneta količina nije dozvoljena!");

            return realizacijaDB.RealizacijaProizvodaUnos(proizvodID, realizovanaKolicina, datumRealizacije, sektorID);
        }

        public bool RealizacijaProizvodaIzmena(int realizacijaID, string proizvodIDText, string realizovanaKolicinaText, string datumRealizacijeText, int sektorID)
        {
            if (string.IsNullOrWhiteSpace(proizvodIDText))
                throw new Exception("ID proizvoda mora biti unet!");
            if (!int.TryParse(proizvodIDText, out int proizvodID))
                throw new Exception("ID proizvoda mora biti broj!");

            if (string.IsNullOrWhiteSpace(realizovanaKolicinaText))
                throw new Exception("Realizovana količina mora biti uneta!");
            if (!int.TryParse(realizovanaKolicinaText, out int realizovanaKolicina))
                throw new Exception("Realizovana količina mora biti broj!");

            if (string.IsNullOrWhiteSpace(datumRealizacijeText))
                throw new Exception("Datum realizacije mora biti unet!");
            if (!DateTime.TryParse(datumRealizacijeText, out DateTime datumRealizacije))
                throw new Exception("Datum nije u ispravnom formatu!");

            DataSet ds = realizacijaDB.SektorPrikazPoIDu(sektorID);
            string nazivSektora = ds.Tables[0].Rows[0]["NazivSektora"].ToString();

            if (!pravila.ValidirajDatumRealizacije(datumRealizacije))
                throw new Exception("Datum realizacije ne može biti pre današnjeg datuma!");
            if (!pravila.ValidirajKolicinu(nazivSektora, realizovanaKolicina))
                throw new Exception("Uneta količina nije dozvoljena!");

            return realizacijaDB.RealizacijaDelovaIzmena(realizacijaID, proizvodID, realizovanaKolicina, datumRealizacije, sektorID);
        }

        public bool RealizacijaProizvodaBrisanje(int realizacijaID)
        {
            return realizacijaDB.RealizacijaProizvodaBrisanje(realizacijaID);
        }
    }
}
