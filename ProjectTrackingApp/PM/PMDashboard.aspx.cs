using ProjectTrackingApp.Classes;
using System;
using System.Data;

namespace ProjectTrackingApp.PM
{
    public partial class PMDashboard : System.Web.UI.Page
    {
        LookUp lp = new LookUp("con");
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                getStats();
            }
        }
        private void getStats()
        {
            DataSet ds = lp.getStats();
            if (ds != null)
            {
                txtMembers.Text = ds.Tables[5].Rows[0]["TM"].ToString();
                txtCompletedTasks.Text = ds.Tables[7].Rows[0]["CompletedTasks"].ToString();
                txtPendingTasks.Text = ds.Tables[2].Rows[0]["AllocatedTasks"].ToString();
                txtProjects.Text = ds.Tables[0].Rows[0]["Projects"].ToString();
            }
            else
            {
                txtPendingTasks.Text = "0";
                txtCompletedTasks.Text = "0";
                txtMembers.Text = "0";
                txtProjects.Text = "0";
            }
        }
       
    }
}