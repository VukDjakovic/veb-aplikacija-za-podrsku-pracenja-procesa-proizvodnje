using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.Services;
using KlasePodataka;

namespace WebServis
{
    /// <summary>
    /// Summary description for WebService1
    /// </summary>
    [WebService(Namespace = "http://tempuri.org/")]
    [WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
    [System.ComponentModel.ToolboxItem(false)]
    // To allow this Web Service to be called from script, using ASP.NET AJAX, uncomment the following line. 
    // [System.Web.Script.Services.ScriptService]
    public class WebService1 : System.Web.Services.WebService
    {

        [WebMethod]
        public List<string> DajSveStatusePlana()
        {
            DataSet ds = new DataSet();
            ds.ReadXml(Server.MapPath("~/XML/OgranicenjePlana.xml"));

            List<string> statusi = new List<string>();

            if (ds.Tables["StatusPlana"] != null)
            {
                foreach (DataRow row in ds.Tables["StatusPlana"].Rows)
                {
                    statusi.Add(row[0].ToString());
                }
            }
            return statusi;
        }

        [WebMethod]
        public List<SektorOgranicenjeDTO> DajOgranicenjaPoSektorima()
        {
            DataSet ds = new DataSet();
            ds.ReadXml(Server.MapPath("~/XML/OgranicenjeProizvodnje.xml"));

            List<SektorOgranicenjeDTO> rezultat = new List<SektorOgranicenjeDTO>();

            if (ds.Tables["Sektor"] != null)
            {
                foreach (DataRow row in ds.Tables["Sektor"].Rows)
                {
                    rezultat.Add(new SektorOgranicenjeDTO
                    {
                        NazivSektora = row["NazivSektora"].ToString(),
                        MaksimalnaDnevnaKolicina = int.Parse(row["MaksimalnaDnevnaKolicina"].ToString())
                    });
                }
            }

            return rezultat;
        }
    }
}
