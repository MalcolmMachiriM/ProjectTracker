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
                getTasks();
            }
        }
        private void getTasks()
        {
            long id = long.Parse(Session["userid"].ToString());
            DataSet ds = tasks.getProjectTasks();
            if (ds != null)
            {
                grdTasks.DataSource = ds;
                grdTasks.DataBind();
            }
        }
    }
}