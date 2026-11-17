using DBUtils;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;

namespace KlasePodataka
{
    public class RealizacijaDB : SQLTabela
    {
        private readonly string pStringKonekcije;

        public RealizacijaDB()
        {
            pStringKonekcije = ConfigurationManager.ConnectionStrings["KonekcioniString"].ConnectionString;
        }

        public DataSet RealizacijaDelovaPrikaz(int? realizacijaID = null)
        {
            var parametri = new List<SqlParameter>
            {
                new SqlParameter("@RealizacijaDelovaID", SqlDbType.Int) { Value = (object)realizacijaID ?? DBNull.Value }
            };

            return IzvrsiSelect("sp_RealizacijaDelova_Prikaz", parametri);
        }

        public bool RealizacijaDelovaUnos(int deoID, int realizovanaKolicina, DateTime datumRealizacije, int sektorID)
        {
            var parametri = new List<SqlParameter>
            {
                new SqlParameter("@DeoID", SqlDbType.Int) { Value = deoID },
                new SqlParameter("@RealizovanaKolicina", SqlDbType.Int) { Value = realizovanaKolicina },
                new SqlParameter("@DatumRealizacije", SqlDbType.Date) { Value = datumRealizacije },
                new SqlParameter("@SektorID", SqlDbType.Int) { Value = sektorID }
            };

            return IzvrsiNonQuery("sp_RealizacijaDelova_Unos", parametri);
        }

        public bool RealizacijaDelovaIzmena(int realizacijaID, int deoID, int realizovanaKolicina, DateTime datumRealizacije, int sektorID)
        {
            var parametri = new List<SqlParameter>
            {
                new SqlParameter("@RealizacijaDelovaID", SqlDbType.Int) { Value = realizacijaID },
                new SqlParameter("@DeoID", SqlDbType.Int) { Value = deoID },
                new SqlParameter("@RealizovanaKolicina", SqlDbType.Int) { Value = realizovanaKolicina },
                new SqlParameter("@DatumRealizacije", SqlDbType.Date) { Value = datumRealizacije },
                new SqlParameter("@SektorID", SqlDbType.Int) { Value = sektorID }
            };

            return IzvrsiNonQuery("sp_RealizacijaDelova_Izmena", parametri);
        }

        public bool RealizacijaDelovaBrisanje(int realizacijaID)
        {
            var parametri = new List<SqlParameter>
            {
                new SqlParameter("@RealizacijaDelovaID", SqlDbType.Int) { Value = realizacijaID }
            };

            return IzvrsiNonQuery("sp_RealizacijaDelova_Brisanje", parametri);
        }

        public DataSet RealizacijaProizvodaPrikaz(int? realizacijaID = null)
        {
            var parametri = new List<SqlParameter>
            {
                new SqlParameter("@RealizacijaProizvodaID", SqlDbType.Int) { Value = (object)realizacijaID ?? DBNull.Value }
            };

            return IzvrsiSelect("sp_RealizacijaProizvoda_Prikaz", parametri);
        }

        public bool RealizacijaProizvodaUnos(int proizvodID, int realizovanaKolicina, DateTime datumRealizacije, int sektorID)
        {
            var parametri = new List<SqlParameter>
            {
                new SqlParameter("@ProizvodID", SqlDbType.Int) { Value = proizvodID },
                new SqlParameter("@RealizovanaKolicina", SqlDbType.Int) { Value = realizovanaKolicina },
                new SqlParameter("@DatumRealizacije", SqlDbType.Date) { Value = datumRealizacije },
                new SqlParameter("@SektorID", SqlDbType.Int) { Value = sektorID }
            };

            return IzvrsiNonQuery("sp_RealizacijaProizvoda_Unos", parametri);
        }

        public bool RealizacijaProizvodaIzmena(int realizacijaID, int proizvodID, int realizovanaKolicina, DateTime datumRealizacije, int sektorID)
        {
            var parametri = new List<SqlParameter>
            {
                new SqlParameter("@RealizacijaProizvodaID", SqlDbType.Int) { Value = realizacijaID },
                new SqlParameter("@ProizvodID", SqlDbType.Int) { Value = proizvodID },
                new SqlParameter("@RealizovanaKolicina", SqlDbType.Int) { Value = realizovanaKolicina },
                new SqlParameter("@DatumRealizacije", SqlDbType.Date) { Value = datumRealizacije },
                new SqlParameter("@SektorID", SqlDbType.Int) { Value = sektorID }
            };

            return IzvrsiNonQuery("sp_RealizacijaProizvoda_Izmena", parametri);
        }

        public bool RealizacijaProizvodaBrisanje(int realizacijaID)
        {
            var parametri = new List<SqlParameter>
            {
                new SqlParameter("@RealizacijaProizvodaID", SqlDbType.Int) { Value = realizacijaID }
            };

            return IzvrsiNonQuery("sp_RealizacijaProizvoda_Brisanje", parametri);
        }

        public DataSet SektorPrikaz()
        {
            return IzvrsiSelect("sp_Sektor_Prikaz");
        }

        public DataSet SektorPrikazPoIDu(int sektorID)
        {
            var parametri = new List<SqlParameter>
            {
                new SqlParameter("@SektorID", SqlDbType.Int) { Value = sektorID }
            };
            return IzvrsiSelect("sp_Sektor_PrikazPoIDu", parametri);
        }
    }
}
