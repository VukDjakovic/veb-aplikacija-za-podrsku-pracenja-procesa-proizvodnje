using PrezentacionaLogika;
using SlojPoslovneLogike;
using System;
using System.Data;
using System.Web.UI.WebControls;

namespace KorisnickiInterfejs
{
    public partial class RealizacijaUnos : System.Web.UI.Page
    {
        private FormaPlanPregled formaPlan;
        private FormaRealizacijaUnos formaRealizacija;

        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["KorisnickoIme"] == null)
                Response.Redirect("Login.aspx");

            if (Session["Uloga"] == null || Session["Uloga"].ToString() != "Admin")
                Response.Redirect("Main.aspx");

            formaPlan = new FormaPlanPregled();
            formaRealizacija = new FormaRealizacijaUnos();

            if (!IsPostBack)
            {
                ddlSektorDelova.DataSource = formaRealizacija.SektorPrikaz().Tables[0];
                ddlSektorDelova.DataTextField = "NazivSektora";
                ddlSektorDelova.DataValueField = "SektorID";
                ddlSektorDelova.DataBind();

                ddlSektorProizvoda.DataSource = formaRealizacija.SektorPrikaz().Tables[0];
                ddlSektorProizvoda.DataTextField = "NazivSektora";
                ddlSektorProizvoda.DataValueField = "SektorID";
                ddlSektorProizvoda.DataBind();

                PlanPrikaz(0);
            }
        }

        private void PlanPrikaz(int planID)
        {
            var tabela = formaPlan.PlanPrikaz(planID);

            if (tabela != null && tabela.Tables.Count > 0)
            {
                DataView view = new DataView(tabela.Tables[0]);
                view.RowFilter = "StatusPlana = 'U toku'";

                gvPlanovi.DataSource = view;
                gvPlanovi.DataBind();
            }
        }

        protected void btnPretrazi_Click(object sender, EventArgs e)
        {
            if (int.TryParse(txtFilterPlan.Text, out int id))
                PlanPrikaz(id);
            else
                lblInfo.Text = "Unesite ispravan ID plana.";
        }

        protected void btnPrikaziSve_Click(object sender, EventArgs e)
        {
            txtFilterPlan.Text = "";
            PlanPrikaz(0);
        }

        protected void gvPlanovi_PromenaStrane(object sender, GridViewPageEventArgs e)
        {
            gvPlanovi.PageIndex = e.NewPageIndex;
            PlanPrikaz(0);
        }

        protected void gvPlanovi_PromenaIzabranogReda(object sender, EventArgs e)
        {
            GridViewRow red = gvPlanovi.SelectedRow;

            txtProizvodID.Text = red.Cells[3].Text;
            txtDeoID.Text = red.Cells[6].Text;
            lblInfo.Text = $"Odabran plan ID: {red.Cells[0].Text}";
        }

        protected void btnUnesiRealizacijuDelova_Click(object sender, EventArgs e)
        {
            try
            {
                int sektorID = int.Parse(ddlSektorDelova.SelectedValue);
                string deoIDText = txtDeoID.Text.Trim();
                string kolicinaText = txtKolicinaDelova.Text.Trim();
                string datumText = txtDatumDelova.Text.Trim();

                bool rezultat = formaRealizacija.RealizacijaDelovaUnos(
                    deoIDText,
                    kolicinaText,
                    datumText,
                    sektorID
                );

                lblInfoDelovi.ForeColor = System.Drawing.Color.Green;
                lblInfoDelovi.Text = "Realizacija delova uspešno sačuvana.";
            }
            catch (Exception ex)
            {
                lblInfoDelovi.ForeColor = System.Drawing.Color.Red;
                lblInfoDelovi.Text = ex.Message;
            }
        }


        protected void btnUnesiRealizacijuProizvoda_Click(object sender, EventArgs e)
        {
            try
            {
                int sektorID = int.Parse(ddlSektorProizvoda.SelectedValue);
                string proizvodIDText = txtProizvodID.Text.Trim();
                string kolicinaText = txtKolicinaProizvoda.Text.Trim();
                string datumText = txtDatumProizvoda.Text.Trim();

                bool rezultat = formaRealizacija.RealizacijaProizvodaUnos(
                    proizvodIDText,
                    kolicinaText,
                    datumText,
                    sektorID
                );

                lblInfoProizvod.ForeColor = System.Drawing.Color.Green;
                lblInfoProizvod.Text = "Realizacija proizvoda uspešno sačuvana.";
            }
            catch (Exception ex)
            {
                lblInfoProizvod.ForeColor = System.Drawing.Color.Red;
                lblInfoProizvod.Text = ex.Message;
            }
        }

    }
}
