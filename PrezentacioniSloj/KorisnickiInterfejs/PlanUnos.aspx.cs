using PrezentacionaLogika;
using SlojPoslovneLogike;
using System;
using System.Data;
using System.Web.UI.WebControls;

namespace KorisnickiInterfejs
{
    public partial class PlanUnos : System.Web.UI.Page
    {
        private FormaPorudzbinaPregled formaPorudzbina;
        private FormaPlanUnos formaPlan;

        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["KorisnickoIme"] == null)
                Response.Redirect("Login.aspx");

            if (Session["Uloga"] == null || Session["Uloga"].ToString() != "Admin")
                Response.Redirect("Main.aspx");

            formaPorudzbina = new FormaPorudzbinaPregled();
            formaPlan = new FormaPlanUnos();

            if (!IsPostBack)
            {
                PoslovnaPravila pravila = new PoslovnaPravila();
                ddlStatusPlana.DataSource = pravila.DajSveStatusePlana();
                ddlStatusPlana.DataBind();

                PorudzbinePrikaz(0);
            }
        }

        private void PorudzbinePrikaz(int porudzbinaID)
        {
            try
            {
                DataSet ds = formaPorudzbina.PorudzbinaPrikaz(porudzbinaID);
                gvPorudzbine.DataSource = ds.Tables[0];
                gvPorudzbine.DataBind();
            }
            catch (Exception ex)
            {
                lblInfo.Text = $"Greška prilikom učitavanja podataka: {ex.Message}";
            }
        }

        protected void btnPretrazi_Click(object sender, EventArgs e)
        {
            if (int.TryParse(txtFilterPorudzbina.Text, out int id))
                PorudzbinePrikaz(id);
            else
                lblInfo.Text = "Unesite ispravan ID porudžbine.";
        }

        protected void btnPrikaziSve_Click(object sender, EventArgs e)
        {
            txtFilterPorudzbina.Text = "";
            PorudzbinePrikaz(0);
        }

        protected void gvPorudzbine_PromenaStrane(object sender, GridViewPageEventArgs e)
        {
            gvPorudzbine.PageIndex = e.NewPageIndex;
            PorudzbinePrikaz(0);
        }

        protected void gvPorudzbine_PromenaIzabranogReda(object sender, EventArgs e)
        {
            string id = gvPorudzbine.SelectedDataKey.Value.ToString();
            txtPorudzbinaID.Text = id;
        }

        protected void btnUnesiPlan_Click(object sender, EventArgs e)
        {
            try
            {
                bool planDodat = formaPlan.PlanUnos(
                    txtDatumRokaIzrade.Text.Trim(),
                    txtPorudzbinaID.Text.Trim(),
                    ddlStatusPlana.SelectedValue
                );

                if (planDodat)
                {
                    lblInfoPlan.ForeColor = System.Drawing.Color.Green;
                    lblInfoPlan.Text = "Plan je uspešno dodat! Detaljni plan je generisan automatski.";
                }
                else
                {
                    lblInfoPlan.ForeColor = System.Drawing.Color.Red;
                    lblInfoPlan.Text = "Došlo je do greške pri unosu plana.";
                }
            }
            catch (Exception ex)
            {
                lblInfoPlan.ForeColor = System.Drawing.Color.Red;
                lblInfoPlan.Text = ex.Message;
            }
        }

        protected void btnNazad_Click(object sender, EventArgs e)
        {
            Response.Redirect("PlanPregled.aspx");
        }
    }
}
