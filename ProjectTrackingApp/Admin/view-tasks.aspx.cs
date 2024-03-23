using ProjectTrackingApp.Classes;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace ProjectTrackingApp.Admin
{
    public partial class view_tasks : System.Web.UI.Page
    {
        readonly ProjectTask tasks = new ProjectTask("con");
        QueryStringModule qn = new QueryStringModule();

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                getTasks();
            }
        }

        private void getTasks()
        {
            DataSet ds = tasks.getAllTasks();
            if (ds != null)
            {
                grdTasks.DataSource = ds;
                grdTasks.DataBind();
            }
        }

        protected void grdTasks_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            try
            {

                int index;
                if (e.CommandName == "editrecord")
                {
                    index = Convert.ToInt32(e.CommandArgument);
                    string EcryptedID = HttpUtility.UrlEncode(qn.Encrypt(index.ToString()));
                    //Response.Redirect("../Admin/edit-project?ID=" + EcryptedID + "");

                }
                if (e.CommandName == "assignrecord")
                {
                    index = Convert.ToInt32(e.CommandArgument);
                    string EcryptedID = HttpUtility.UrlEncode(qn.Encrypt(index.ToString()));
                    Response.Redirect("../Admin/task-assign?ID=" + EcryptedID + "");

                }
                if (e.CommandName == "deleterecord")
                {

                    index = Convert.ToInt32(e.CommandArgument);

                    //lp.DeleteProject(index);
                    //ScriptManager.RegisterStartupScript(this, this.GetType(), "alert", "alert('Project successfully deleted');window.location ='./view-projects.aspx';", true);


                }

            }
            catch (Exception)
            {

                throw;
            }
        }

        protected void grdTasks_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            
            grdTasks.PageIndex = e.NewPageIndex;

            this.BindGrid(e.NewPageIndex);
            
            
        }
        private void BindGrid(int page = 0)
        {
            DataSet Projects = tasks.getAllTasks();
            if (Projects != null)
            {
                int maxPageIndex = grdTasks.PageCount - 1;

                if (page < 0 || page > maxPageIndex)
                {
                    if (maxPageIndex >= 0)
                    {
                        // Navigate to the last available page
                        page = maxPageIndex;
                    }
                    else
                    {
                        // No data available, reset to the first page
                        page = 0;
                    }
                }
                grdTasks.DataSource = Projects;
                grdTasks.PageIndex = page;
                grdTasks.DataBind();


            }
            else
            {
                grdTasks.DataSource = null;
                grdTasks.DataBind();
            }
        }
    }
}