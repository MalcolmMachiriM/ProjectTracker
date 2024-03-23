using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace ProjectTrackingApp.PM
{
    public partial class PMDashboard : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                getSettings();
            }
        }

        private void getSettings()
        {
            txtCompletedTasks.Text = "7";
            txtMembers.Text = "20";
            txtPendingTasks.Text = "19";
            txtProjects.Text = "2";
        }
    }
}