using System;
using System.Data;
using System.Web.UI;
using PrezentacionaLogika;

namespace KorisnickiInterfejs
{
    public partial class Login : Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
        }

        protected void btnPrijava_Click(object sender, EventArgs e)
        {
            string KorisnickoIme = txtKorisnickoIme.Text.Trim();
            string Lozinka = txtLozinka.Text.Trim();

            FormaLogin formaLogin = new FormaLogin();
            DataSet ds = formaLogin.ValidacijaKorisnika(KorisnickoIme, Lozinka);

            if (ds.Tables.Count > 0 && ds.Tables[0].Rows.Count > 0)
            {
                string Uloga = ds.Tables[0].Rows[0]["Uloga"].ToString();

                Session["KorisnickoIme"] = KorisnickoIme;
                Session["Uloga"] = Uloga;

                Response.Redirect("PlanUnos.aspx");
            }
            else
            {
                lblGreska.Text = "Pogrešno korisničko ime ili lozinka.";
            }
        }
    }
}
