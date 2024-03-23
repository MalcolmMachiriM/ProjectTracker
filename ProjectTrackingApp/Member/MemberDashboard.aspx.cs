using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace ProjectTrackingApp.Member
{
    public partial class MemberDashboard : System.Web.UI.Page
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
            txtResources.Text = "5";
            txtPendingTasks.Text = "19";
        }
    }
}