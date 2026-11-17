using DBUtils;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KlasePodataka
{
    public class PorudzbinaDB : SQLTabela
    {
        private readonly string pStringKonekcije;
        public PorudzbinaDB()
        {
            pStringKonekcije = ConfigurationManager.ConnectionStrings["KonekcioniString"].ConnectionString;
        }

        public DataSet PorudzbinaPrikaz(int PorudzbinaID)
        {
            var parametri = new List<SqlParameter>
            {
                new SqlParameter("@PorudzbinaID", SqlDbType.Int) { Value = PorudzbinaID }
            };
            return IzvrsiSelect("sp_Porudzbina_Prikaz", parametri);
        }
    }
}
