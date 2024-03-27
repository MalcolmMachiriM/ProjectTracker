using ProjectTrackingApp.Classes;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace ProjectTrackingApp
{
    public partial class ProjectDashboard : System.Web.UI.MasterPage
    {
        LookUp lp = new LookUp("con");
        UsersManagement um = new UsersManagement("con");

        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["username"] != null)
            {
                DataRow rw = um.getUserByUserID(int.Parse(Session["userid"].ToString())).Tables[0].Rows[0];
                lblUsername.Text = $"{rw["FirstName"]} {rw["LastName"]}";

                getStats();
                //LoadClientImage();
            }
            else
            {

                Response.Redirect("../login.aspx");
            }
        }

        private void getStats()
        {
            DataSet ds = lp.getStats();
            if (ds!=null)
            {
                txtAdmins.Text = ds.Tables[3].Rows[0]["Admins"].ToString();
                txtMembers.Text = ds.Tables[5].Rows[0]["TM"].ToString();
                txtPMS.Text = ds.Tables[4].Rows[0]["PM"].ToString();
                txtTotalTasks.Text = ds.Tables[1].Rows[0]["TotalTasks"].ToString();
                txtAllocatedTasks.Text = ds.Tables[2].Rows[0]["AllocatedTasks"].ToString();
                txtProjects.Text = ds.Tables[0].Rows[0]["Projects"].ToString();
                txtPendingTasks.Text = (int.Parse(txtTotalTasks.Text) - int.Parse(txtAllocatedTasks.Text)).ToString();
                txtCategory.Text = ds.Tables[6].Rows[0]["Category"].ToString();
            }
            else
            {
                txtAdmins.Text = "0";
                txtMembers.Text = "0";
                txtPMS.Text = "0";
                txtTotalTasks.Text = "0";
                txtAllocatedTasks.Text = "0";
                txtProjects.Text = "0";
                txtPendingTasks.Text = "0";
                txtCategory.Text = "0";
            }
        }

        //protected void LoadClientImage()
        //{
        //    try
        //    {


        //        ClientPic.ImageUrl = string.Format("~/ImageHandler.ashx?UserID={0}", int.Parse(Session["userid"].ToString()));
        //    }
        //    catch (Exception ex)
        //    {
        //        //DangerAlert(ex.Message);
        //    }
        //}
    }
}