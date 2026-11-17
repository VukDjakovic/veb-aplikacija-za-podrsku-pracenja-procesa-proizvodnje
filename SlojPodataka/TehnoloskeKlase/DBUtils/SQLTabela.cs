using DBUtils;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DBUtils
{
    public class SQLTabela
    {

        public SQLTabela()
        {
            pStringKonekcije = ConfigurationManager.ConnectionStrings["KonekcioniString"].ConnectionString;
        }

        private readonly string pStringKonekcije;

        private string pNazivTabele;
        private SQLKonekcija pKonekcija;
        private SqlDataAdapter pAdapter;
        private DataSet pDataSet;

        public SQLTabela(string connectionString)
        {
            pStringKonekcije = connectionString;
        }

        public SQLTabela(SQLKonekcija Konekcija, string NazivTabele)
        {
            pKonekcija = Konekcija;
            pNazivTabele = NazivTabele;
        }

        private void KreirajAdapter(string SelectUpit, string InsertUpit, string DeleteUpit, string UpdateUpit)
        {
            SqlCommand mSelectKomanda, mInsertKomanda, mDeleteKomanda, mUpdateKomanda;

            mSelectKomanda = new SqlCommand();
            mSelectKomanda.CommandText = SelectUpit;
            mSelectKomanda.Connection = pKonekcija.DajKonekciju();

            mInsertKomanda = new SqlCommand();
            mInsertKomanda.CommandText = InsertUpit;
            mInsertKomanda.Connection = pKonekcija.DajKonekciju();

            mDeleteKomanda = new SqlCommand();
            mDeleteKomanda.CommandText = DeleteUpit;
            mDeleteKomanda.Connection = pKonekcija.DajKonekciju();

            mUpdateKomanda = new SqlCommand();
            mUpdateKomanda.CommandText = UpdateUpit;
            mUpdateKomanda.Connection = pKonekcija.DajKonekciju();

            pAdapter = new SqlDataAdapter();
            pAdapter.SelectCommand = mSelectKomanda;
            pAdapter.InsertCommand = mInsertKomanda;
            pAdapter.DeleteCommand = mDeleteKomanda;
            pAdapter.UpdateCommand = mUpdateKomanda;
        }

        private void KreirajDataSet()
        {
            pDataSet = new System.Data.DataSet();
            pAdapter.Fill(pDataSet, pNazivTabele);
        }

        private void ZatvoriAdapterDataSet()
        {
            pAdapter.Dispose();
            pDataSet.Dispose();
        }

        public DataSet PrikaziView(string nazivViewa)
        {
            DataSet ds = new DataSet();

            using (SqlConnection Veza = new SqlConnection(pStringKonekcije))
            {
                Veza.Open();
                using (SqlCommand Komanda = new SqlCommand($"SELECT * FROM {nazivViewa}", Veza))
                {
                    Komanda.CommandType = CommandType.Text;
                    SqlDataAdapter da = new SqlDataAdapter(Komanda);
                    da.Fill(ds);
                }
            }

            return ds;
        }

        public DataSet IzvrsiSelect(string NazivProcedure, List<SqlParameter> parametri = null)
        {
            DataSet ds = new DataSet();
            using (SqlConnection Veza = new SqlConnection(pStringKonekcije))
            {
                Veza.Open();
                using (SqlCommand Komanda = new SqlCommand(NazivProcedure, Veza))
                {
                    Komanda.CommandType = CommandType.StoredProcedure;
                    if (parametri != null)
                        Komanda.Parameters.AddRange(parametri.ToArray());
                    SqlDataAdapter da = new SqlDataAdapter(Komanda);
                    da.Fill(ds);
                }
            }
            return ds;
        }

        public bool IzvrsiNonQuery(string NazivProcedure, List<SqlParameter> parametri)
        {
            using (SqlConnection Veza = new SqlConnection(pStringKonekcije))
            {
                Veza.Open();
                using (SqlCommand Komanda = new SqlCommand(NazivProcedure, Veza))
                {
                    Komanda.CommandType = CommandType.StoredProcedure;
                    Komanda.Parameters.AddRange(parametri.ToArray());
                    Komanda.ExecuteNonQuery();
                }
            }
            return true;
        }
        public System.Data.DataSet DajPodatke(string SelectUpit)
        {
            KreirajAdapter(SelectUpit, "", "", "");
            KreirajDataSet();
            return pDataSet;
        }

        public int DajBrojSlogova()
        {
            int BrojSlogova = pDataSet.Tables[0].Rows.Count;
            return BrojSlogova;
        }

        public bool IzvrsiAzuriranje(string Upit)
        {
            bool uspeh = false;
            SqlConnection mKonekcija;
            SqlCommand Komanda;
            SqlTransaction mTransakcija = null;
            try
            {
                mKonekcija = pKonekcija.DajKonekciju();

                Komanda = new SqlCommand();
                Komanda.Connection = mKonekcija;
                Komanda = mKonekcija.CreateCommand();
                // mKonekcija.Open(); ne treba jer je otvorena konekcija dobijena kroz konstruktor
                mTransakcija = mKonekcija.BeginTransaction();
                Komanda.Transaction = mTransakcija;
                Komanda.CommandText = Upit;
                Komanda.ExecuteNonQuery();
                mTransakcija.Commit();
                uspeh = true;
            }
            catch
            {
                mTransakcija.Rollback();
                uspeh = false;
            }
            return uspeh;
        }
    }
}