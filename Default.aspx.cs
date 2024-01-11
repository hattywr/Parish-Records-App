using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace WebApplication1
{
    public partial class _Default : Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["authenticated"] != null)
            {
                bool authenticated = (bool)Session["authenticated"];

                if (authenticated != true)
                {
                    Response.Redirect("AdminAuthentication.aspx");
                }
                else
                {
                    MAIN_Table_of_Contents.Visible = true;
                }
            }
            else
            {
                Response.Redirect("AdminAuthentication.aspx");
            }
        }

        protected void logout_button_Click(object sender, EventArgs e)
        {
            Session["authenticated"] = null;
            Response.Redirect("AdminAuthentication.aspx");
        }
    }
}