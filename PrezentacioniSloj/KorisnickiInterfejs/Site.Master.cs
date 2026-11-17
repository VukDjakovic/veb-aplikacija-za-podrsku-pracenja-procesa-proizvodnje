using System;
using System.Web;
using System.Web.UI;

namespace KorisnickiInterfejs
{
    public partial class Site : System.Web.UI.MasterPage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            NavigacioniMeni.Visible = false;

            if (Page is KorisnickiInterfejs.Login)
            {
                btnOdjava.Visible = false;
                return;
            }

            if (Session["KorisnickoIme"] == null)
            {
                Response.Redirect("~/Login.aspx");
                return;
            }

            if (Session["Uloga"] != null && Session["Uloga"].ToString() == "Admin")
            {
                NavigacioniMeni.Visible = true;
            }
        }

        protected void btnOdjava_Click(object sender, EventArgs e)
        {
            Session.Clear();
            Session.Abandon();
            Response.Redirect("~/Login.aspx");
        }
    }
}
