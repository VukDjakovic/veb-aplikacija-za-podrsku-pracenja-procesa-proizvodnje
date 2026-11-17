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
    public class PlanDB : SQLTabela
    {
        private readonly string pStringKonekcije;
        public PlanDB()
        {
            pStringKonekcije = ConfigurationManager.ConnectionStrings["KonekcioniString"].ConnectionString;
        }

        public DataSet PlanPrikaz(int planID)
        {
            var parametri = new List<SqlParameter>
            {
                new SqlParameter("@PlanID", SqlDbType.Int) { Value = (object)planID ?? DBNull.Value }
            };
            return IzvrsiSelect("sp_Plan_Prikaz", parametri);
        }

        public bool PlanAutomatskiUnos(DateTime datumRokaIzrade, int porudzbinaID, string statusPlana)
        {
            var parametri = new List<SqlParameter>
            {
                new SqlParameter("@DatumRokaIzrade", SqlDbType.Date) { Value = datumRokaIzrade },
                new SqlParameter("@PorudzbinaID", SqlDbType.Int) { Value = porudzbinaID },
                new SqlParameter("@StatusPlana", SqlDbType.NVarChar) { Value = statusPlana }
            };

            return IzvrsiNonQuery("sp_PlanProizvodnje_Unos", parametri);
        }

        public bool PlanBrisanje(int planID)
        {
            var parametri = new List<SqlParameter>
            {
                new SqlParameter("@PlanID", SqlDbType.Int) { Value = planID }
            };

            return IzvrsiNonQuery("sp_PlanProizvodnje_Brisanje", parametri);
        }

        public bool PlanIzmena(int planID, DateTime datumRokaIzrade, string statusPlana)
        {
            var parametri = new List<SqlParameter>
            {
                new SqlParameter("@PlanID", SqlDbType.Int) { Value = planID },
                new SqlParameter("@DatumRokaIzrade", SqlDbType.Date) { Value = datumRokaIzrade },
                new SqlParameter("@StatusPlana", SqlDbType.NVarChar) { Value = statusPlana }
            };

            return IzvrsiNonQuery("sp_PlanProizvodnje_Izmena", parametri);
        }
    }
}
