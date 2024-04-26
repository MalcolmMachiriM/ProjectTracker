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
    public partial class view_client_tasks : System.Web.UI.Page
    {
        readonly ProjectTask tasks = new ProjectTask("con");
        QueryStringModule qn = new QueryStringModule();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                
                if (Request.QueryString["ID"]!=null)
                {
                    projectId.Value = qn.Decrypt(HttpUtility.UrlDecode(Request.QueryString["ID"].ToString()));
                }
                else
                {
                    projectId.Value = "0";
                }
                getTasks();
            }
        }
        private void getTasks()
        {
            DataSet ds = tasks.getProjectTasks(long.Parse(projectId.Value));
            if (ds != null)
            {
                grdTasks.DataSource = ds;
                grdTasks.DataBind();
            }
        }
    }
}