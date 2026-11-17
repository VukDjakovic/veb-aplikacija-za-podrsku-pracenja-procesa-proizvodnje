using PrezentacionaLogika;
using System;
using System.Data;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace KorisnickiInterfejs
{
    public partial class RealizacijaPregled : System.Web.UI.Page
    {
        private readonly FormaRealizacijaPregled formaPregled = new FormaRealizacijaPregled();
        private readonly FormaRealizacijaUnos formaUnos = new FormaRealizacijaUnos();

        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["KorisnickoIme"] == null)
                Response.Redirect("Login.aspx");

            if (!IsPostBack)
            {
                RealizacijaDelovaPrikaz(0);
                RealizacijaProizvodaPrikaz(0);
            }
        }

        private void RealizacijaDelovaPrikaz(int realizacijaID)
        {
            try
            {
                DataSet ds = formaPregled.RealizacijaDelovaPrikaz(realizacijaID);
                gvRealizacijaDelova.DataSource = ds.Tables[0];
                gvRealizacijaDelova.DataBind();
            }
            catch (Exception ex)
            {
                lblInfoDelovi.Text = $"Greška: {ex.Message}";
            }
        }

        private void RealizacijaProizvodaPrikaz(int realizacijaID)
        {
            try
            {
                DataSet ds = formaPregled.RealizacijaProizvodaPrikaz(realizacijaID);
                gvRealizacijaProizvoda.DataSource = ds.Tables[0];
                gvRealizacijaProizvoda.DataBind();

            }
            catch (Exception ex)
            {
                lblInfoProizvodi.Text = $"Greška: {ex.Message}";
            }
        }

        protected void btnPretraziDelove_Click(object sender, EventArgs e)
        {
            if (int.TryParse(txtFilterDelova.Text.Trim(), out int id))
                RealizacijaDelovaPrikaz(id);
            else
                lblInfoDelovi.Text = "Unesite ispravan ID realizacije.";
        }

        protected void btnPrikaziSveDelove_Click(object sender, EventArgs e)
        {
            txtFilterDelova.Text = "";
            RealizacijaDelovaPrikaz(0);
        }

        protected void btnPretraziProizvode_Click(object sender, EventArgs e)
        {
            if (int.TryParse(txtFilterProizvoda.Text.Trim(), out int id))
                RealizacijaProizvodaPrikaz(id);
            else
                lblInfoProizvodi.Text = "Unesite ispravan ID realizacije.";
        }

        protected void btnPrikaziSveProizvode_Click(object sender, EventArgs e)
        {
            txtFilterProizvoda.Text = "";
            RealizacijaProizvodaPrikaz(0);
        }

        protected void gvRealizacijaDelova_PromenaStrane(object sender, GridViewPageEventArgs e)
        {
            gvRealizacijaDelova.PageIndex = e.NewPageIndex;
            RealizacijaDelovaPrikaz(0);
        }

        protected void gvRealizacijaProizvoda_PromenaStrane(object sender, GridViewPageEventArgs e)
        {
            gvRealizacijaProizvoda.PageIndex = e.NewPageIndex;
            RealizacijaProizvodaPrikaz(0);
        }


        private void PopuniDropDownSektor(DropDownList ddl)
        {
            try
            {
                DataSet ds = formaUnos.SektorPrikaz();
                ddl.DataSource = ds.Tables[0];
                ddl.DataTextField = "NazivSektora";
                ddl.DataValueField = "SektorID";
                ddl.DataBind();
            }
            catch (Exception ex)
            {
                throw new Exception("Greška pri učitavanju sektora: " + ex.Message);
            }
        }


        protected void gvRealizacijaDelova_IzmenaReda(object sender, GridViewEditEventArgs e)
        {
            gvRealizacijaDelova.EditIndex = e.NewEditIndex;
            RealizacijaDelovaPrikaz(0);
        }

        protected void gvRealizacijaDelova_OtkazIzmene(object sender, GridViewCancelEditEventArgs e)
        {
            gvRealizacijaDelova.EditIndex = -1;
            RealizacijaDelovaPrikaz(0);
        }

        protected void gvRealizacijaDelova_PopunjavanjeRedaPodacima(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.DataRow && e.Row.RowState.HasFlag(DataControlRowState.Edit))
            {
                DropDownList ddlSektor = (DropDownList)e.Row.FindControl("ddlSektorDelovi");
                if (ddlSektor != null)
                {
                    PopuniDropDownSektor(ddlSektor);
                    string nazivSektora = DataBinder.Eval(e.Row.DataItem, "NazivSektora").ToString();
                    ListItem item = ddlSektor.Items.FindByText(nazivSektora);
                    if (item != null)
                    {
                        ddlSektor.ClearSelection();
                        item.Selected = true;
                    }
                }
            }
        }

        protected void gvRealizacijaDelova_AzuriranjeReda(object sender, GridViewUpdateEventArgs e)
        {
            try
            {
                int id = Convert.ToInt32(gvRealizacijaDelova.DataKeys[e.RowIndex].Value);
                GridViewRow row = gvRealizacijaDelova.Rows[e.RowIndex];

                string datum = ((TextBox)row.Cells[1].Controls[0]).Text;
                string kolicina = ((TextBox)row.Cells[3].Controls[0]).Text;
                DropDownList ddlSektor = (DropDownList)row.FindControl("ddlSektorDelovi");
                int sektorID = int.Parse(ddlSektor.SelectedValue);

                formaUnos.RealizacijaDelovaIzmena(id, "1", kolicina, datum, sektorID);

                gvRealizacijaDelova.EditIndex = -1;
                RealizacijaDelovaPrikaz(0);
                lblInfoDelovi.Text = "Uspešno izmenjena realizacija dela.";
            }
            catch (Exception ex)
            {
                lblInfoDelovi.Text = "Greška pri izmeni: " + ex.Message;
            }
        }

        protected void gvRealizacijaDelova_BrisanjeReda(object sender, GridViewDeleteEventArgs e)
        {
            try
            {
                int id = Convert.ToInt32(gvRealizacijaDelova.DataKeys[e.RowIndex].Value);
                formaUnos.RealizacijaDelovaBrisanje(id);
                RealizacijaDelovaPrikaz(0);
                lblInfoDelovi.Text = "Realizacija dela uspešno obrisana.";
            }
            catch (Exception ex)
            {
                lblInfoDelovi.Text = "Greška pri brisanju: " + ex.Message;
            }
        }


        protected void gvRealizacijaProizvoda_IzmenaReda(object sender, GridViewEditEventArgs e)
        {
            gvRealizacijaProizvoda.EditIndex = e.NewEditIndex;
            RealizacijaProizvodaPrikaz(0);
        }

        protected void gvRealizacijaProizvoda_OtkazIzmene(object sender, GridViewCancelEditEventArgs e)
        {
            gvRealizacijaProizvoda.EditIndex = -1;
            RealizacijaProizvodaPrikaz(0);
        }

        protected void gvRealizacijaProizvoda_PopunjavanjeRedaPodacima(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.DataRow && e.Row.RowState.HasFlag(DataControlRowState.Edit))
            {
                DropDownList ddlSektor = (DropDownList)e.Row.FindControl("ddlSektorProizvodi");
                if (ddlSektor != null)
                {
                    PopuniDropDownSektor(ddlSektor);
                    string nazivSektora = DataBinder.Eval(e.Row.DataItem, "NazivSektora").ToString();
                    ListItem item = ddlSektor.Items.FindByText(nazivSektora);
                    if (item != null)
                    {
                        ddlSektor.ClearSelection();
                        item.Selected = true;
                    }
                }
            }
        }

        protected void gvRealizacijaProizvoda_AzuriranjeReda(object sender, GridViewUpdateEventArgs e)
        {
            try
            {
                int id = Convert.ToInt32(gvRealizacijaProizvoda.DataKeys[e.RowIndex].Value);
                GridViewRow row = gvRealizacijaProizvoda.Rows[e.RowIndex];

                string datum = ((TextBox)row.Cells[1].Controls[0]).Text;
                string kolicina = ((TextBox)row.Cells[3].Controls[0]).Text;
                DropDownList ddlSektor = (DropDownList)row.FindControl("ddlSektorProizvodi");
                int sektorID = int.Parse(ddlSektor.SelectedValue);

                formaUnos.RealizacijaProizvodaIzmena(id, "1", kolicina, datum, sektorID);

                gvRealizacijaProizvoda.EditIndex = -1;
                RealizacijaProizvodaPrikaz(0);
                lblInfoProizvodi.Text = "Uspešno izmenjena realizacija proizvoda.";
            }
            catch (Exception ex)
            {
                lblInfoProizvodi.Text = "Greška pri izmeni: " + ex.Message;
            }
        }

        protected void gvRealizacijaProizvoda_BrisanjeReda(object sender, GridViewDeleteEventArgs e)
        {
            try
            {
                int id = Convert.ToInt32(gvRealizacijaProizvoda.DataKeys[e.RowIndex].Value);
                formaUnos.RealizacijaProizvodaBrisanje(id);
                RealizacijaProizvodaPrikaz(0);
                lblInfoProizvodi.Text = "Realizacija proizvoda uspešno obrisana.";
            }
            catch (Exception ex)
            {
                lblInfoProizvodi.Text = "Greška pri brisanju: " + ex.Message;
            }
        }
    }
}
