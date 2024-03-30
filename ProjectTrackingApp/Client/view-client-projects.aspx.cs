using ProjectTrackingApp.Classes;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace ProjectTrackingApp.Client
{
    public partial class view_client_projects : System.Web.UI.Page
    {
        QueryStringModule qn = new QueryStringModule();
        readonly LookUp lp = new LookUp("con");
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                ViewProjects();
            }
        }
        private void ViewProjects()
        {
            DataSet Projects = lp.getAllProjects();
            if (Projects != null)
            {
                grdProject.DataSource = Projects;
                grdProject.DataBind();
            }
        }
        protected void grdProject_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            try
            {

                int index;
                if (e.CommandName == "viewrecord")
                {
                    index = Convert.ToInt32(e.CommandArgument);
                    string EcryptedID = HttpUtility.UrlEncode(qn.Encrypt(index.ToString()));
                    Response.Redirect("../Client/view-client-tasks?ID=" + EcryptedID + "");

                }
                if (e.CommandName == "deleterecord")
                {

                    index = Convert.ToInt32(e.CommandArgument);

                    lp.DeleteProject(index);
                    ScriptManager.RegisterStartupScript(this, this.GetType(), "alert", "alert('Project successfully deleted');window.location ='./view-client-projects.aspx';", true);


                }

            }
            catch (Exception)
            {

                throw;
            }
        }
    }
}