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
    public partial class ProjectMain : System.Web.UI.MasterPage
    {
        //LookUp lp = new LookUp("con");
        UsersManagement um = new UsersManagement("con");

        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["username"] != null)
            {
                DataRow rw = um.getUserByUserID(int.Parse(Session["userid"].ToString())).Tables[0].Rows[0];
                lblUsername.Text = $"{rw["FirstName"]} {rw["LastName"]}";
                //LoadClientImage();
            }
            else
            {

                Response.Redirect("../login.aspx");
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