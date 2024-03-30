using ProjectTrackingApp.Classes;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace ProjectTrackingApp.Admin
{
    public partial class view_resources : System.Web.UI.Page
    {
        QueryStringModule qn = new QueryStringModule();
        Resources res = new Resources("con");
        protected void Page_Load(object sender, EventArgs e)
        {
            
            if (!IsPostBack)
            {
                getResources();
            }
        }

        private void getResources()
        {
            DataSet ds = res.getAllResources();
            if (ds!=null)
            {
                grdResources.DataSource = ds;
                grdResources.DataBind();
            }
        }

        protected void grdResources_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            int index;
            
            if (e.CommandName == "assignrecord")
            {
                index = Convert.ToInt32(e.CommandArgument);
                string EcryptedID = HttpUtility.UrlEncode(qn.Encrypt(index.ToString()));
                Response.Redirect("../Admin/assign-memnbers?ID=" + EcryptedID + "");

            }
            if (e.CommandName == "deleterecord")
            {

                index = Convert.ToInt32(e.CommandArgument);

                res.DeleteResource(index);
                ScriptManager.RegisterStartupScript(this, this.GetType(), "alert", "alert('Resource successfully deleted');window.location ='./view-resources.aspx';", true);
                getResources();

            }
        }
    }
}