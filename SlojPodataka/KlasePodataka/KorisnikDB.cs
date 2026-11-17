using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;
using DBUtils;

namespace KlasePodataka
{
    public class KorisnikDB : SQLTabela
    {
        private readonly string pStringKonekcije;

        public KorisnikDB()
        {
            pStringKonekcije = ConfigurationManager.ConnectionStrings["KonekcioniString"].ConnectionString;
        }

        public DataSet ValidacijaKorisnika(string KorisnickoIme, string Lozinka)
        {
            var parametri = new List<SqlParameter>
            {
                new SqlParameter("@KorisnickoIme", SqlDbType.NVarChar, 50) { Value = KorisnickoIme },
                new SqlParameter("@Lozinka", SqlDbType.NVarChar, 50) { Value = Lozinka }
            };
            return IzvrsiSelect("sp_Korisnik", parametri);
        }
    }
}
