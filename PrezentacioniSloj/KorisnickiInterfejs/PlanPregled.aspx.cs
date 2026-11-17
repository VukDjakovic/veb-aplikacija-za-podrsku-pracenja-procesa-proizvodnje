using Microsoft.Ajax.Utilities;
using PrezentacionaLogika;
using System;
using System.Data;
using System.Web.UI.WebControls;

namespace KorisnickiInterfejs
{
    public partial class PlanPregled : System.Web.UI.Page
    {
        private readonly FormaPlanPregled formaPregled = new FormaPlanPregled();
        private readonly FormaPlanUnos formaUnos = new FormaPlanUnos();

        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["KorisnickoIme"] == null)
                Response.Redirect("Login.aspx");

            if (!IsPostBack)
                PlanoviPrikaz(0);
        }

        private void PlanoviPrikaz(int planID)
        {
            try
            {
                DataSet ds = formaPregled.PlanPrikaz(planID);
                gvPlanovi.DataSource = ds.Tables[0];
                gvPlanovi.DataBind();
            }
            catch (Exception ex)
            {
                lblInfo.Text = $"Greška: {ex.Message}";
            }
        }

        protected void btnPretrazi_Click(object sender, EventArgs e)
        {
            if (int.TryParse(txtFilterPlan.Text.Trim(), out int id))
                PlanoviPrikaz(id);
            else
                lblInfo.Text = "Unesite ispravan ID plana.";
        }

        protected void btnPrikaziSve_Click(object sender, EventArgs e)
        {
            txtFilterPlan.Text = "";
            PlanoviPrikaz(0);
        }

        protected void gvPlanovi_PromenaStrane(object sender, GridViewPageEventArgs e)
        {
            gvPlanovi.PageIndex = e.NewPageIndex;
            PlanoviPrikaz(0);
        }


        protected void gvPlanovi_IzmenaReda(object sender, GridViewEditEventArgs e)
        {
            gvPlanovi.EditIndex = e.NewEditIndex;
            PlanoviPrikaz(0);
        }

        protected void gvPlanovi_OtkazIzmene(object sender, GridViewCancelEditEventArgs e)
        {
            gvPlanovi.EditIndex = -1;
            PlanoviPrikaz(0);
        }

        protected void gvPlanovi_AzuriranjeReda(object sender, GridViewUpdateEventArgs e)
        {
            try
            {
                int id = Convert.ToInt32(gvPlanovi.DataKeys[e.RowIndex].Value);
                GridViewRow row = gvPlanovi.Rows[e.RowIndex];

                var txtDatum = (TextBox)row.FindControl("txtDatum");
                var ddlStatus = (DropDownList)row.FindControl("ddlStatus");

                DateTime rokIzrade = DateTime.Parse(txtDatum.Text);
                string status = ddlStatus.SelectedValue;

                formaUnos.PlanIzmena(id, rokIzrade.ToString("dd-MM-yyyy"), status);

                gvPlanovi.EditIndex = -1;
                PlanoviPrikaz(0);
                lblInfo.Text = "Plan uspešno izmenjen.";
            }
            catch (Exception ex)
            {
                lblInfo.Text = "Greška pri izmeni: " + ex.Message;
            }
        }

        protected void gvPlanovi_BrisanjeReda(object sender, GridViewDeleteEventArgs e)
        {
            try
            {
                int id = Convert.ToInt32(gvPlanovi.DataKeys[e.RowIndex].Value);
                formaUnos.PlanBrisanje(id);
                PlanoviPrikaz(0);
                lblInfo.Text = "Plan uspešno obrisan.";
            }
            catch (Exception ex)
            {
                lblInfo.Text = "Greška pri brisanju: " + ex.Message;
            }
        }
    }
}
