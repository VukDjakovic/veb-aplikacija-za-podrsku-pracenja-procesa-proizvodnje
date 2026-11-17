using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DBUtils
{
    public class SQLKonekcija
    {
        private SqlConnection pKonekcija;
        private string pPutanjaSqlBaze;
        private string pNazivBaze;
        private string pNazivSQL_DBMSInstance;

        public SQLKonekcija(string putanjaSqlBaze, string nazivBaze, string nazivSQL_DBMSInstance)
        {
            pKonekcija = new SqlConnection();
            pPutanjaSqlBaze = putanjaSqlBaze;
            pNazivBaze = nazivBaze;
            pNazivSQL_DBMSInstance = nazivSQL_DBMSInstance;
        }

        private string DajStringKonekcije()
        {
            string mStringKonekcije;
            if (pPutanjaSqlBaze.Length.Equals(0) || pPutanjaSqlBaze == null)
            {
                mStringKonekcije = "Data Source=" + pNazivSQL_DBMSInstance + ";Initial Catalog=" + pNazivBaze + ";Integrated Security=True";
            }
            else
            {
                mStringKonekcije = "Data Source=.\\" + pNazivSQL_DBMSInstance + ";AttachDbFilename=" + pPutanjaSqlBaze + "\\" + pNazivBaze + ";Integrated Security=True;Connect Timeout=30;User Instance=True";
            }
            return mStringKonekcije;
        }

        public bool OtvoriKonekciju()
        {
            bool uspeh;
            pKonekcija.ConnectionString = DajStringKonekcije();

            try
            {
                pKonekcija.Open();
                uspeh = true;
            }
            catch
            {
                uspeh = false;
            }
            return uspeh;
        }

        public SqlConnection DajKonekciju()
        {
            return pKonekcija;
        }

        public void ZatvoriKonekciju()
        {
            pPutanjaSqlBaze = "";
            pKonekcija.Close();
            pKonekcija.Dispose();
        }
    }
}
