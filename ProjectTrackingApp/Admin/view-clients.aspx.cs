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
    public partial class view_clients : System.Web.UI.Page
    {
        QueryStringModule qn = new QueryStringModule();
        readonly LookUp lp = new LookUp("con");
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                getClients();
            }
        }

        private void getClients()
        {
            DataSet Users = lp.getAllClients();
            if (Users != null)
            {
                grdClients.DataSource = Users;
                grdClients.DataBind();
            }
        }

        protected void grdClients_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {

        }

        protected void grdClients_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            long index = long.Parse(e.CommandArgument.ToString());

            if (e.CommandName == "assignrecord")
            {
                string EcryptedID = HttpUtility.UrlEncode(qn.Encrypt(index.ToString()));
                Response.Redirect("../Client/assign-client?ID=" + EcryptedID + "");
            }
        }
    }
}