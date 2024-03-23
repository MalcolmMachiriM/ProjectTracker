using Antlr.Runtime.Misc;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.Common;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using ProjectTrackingApp.Classes;

namespace ProjectTrackingApp.Admin
{
    public partial class view_user : System.Web.UI.Page
    {
        QueryStringModule qn = new QueryStringModule();
        readonly LookUp lp = new LookUp("con");
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                ViewUsers();
            }
        }

        private void ViewUsers()
        {
            DataSet Users = lp.getAllUsers();
            if (Users != null)
            {
                grdUsers.DataSource = Users;
                grdUsers.DataBind();
            }
        }

        protected void grdUsers_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            grdUsers.PageIndex = e.NewPageIndex;

            this.BindGrid(e.NewPageIndex);
        }

        private void BindGrid(int page = 0)
        {
            DataSet Users = lp.getAllUsers();
            if (Users != null)
            {
                int maxPageIndex = grdUsers.PageCount - 1;

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
                grdUsers.DataSource = Users;
                grdUsers.PageIndex = page;
                grdUsers.DataBind();


            }
            else
            {
                grdUsers.DataSource = null;
                grdUsers.DataBind();
            }
        }

        protected void grdUsers_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            try
            {
              
                int index;
                if (e.CommandName == "editrecord")
                {
                    index = Convert.ToInt32(e.CommandArgument);
                    string EcryptedID = HttpUtility.UrlEncode(qn.Encrypt(index.ToString()));
                    Response.Redirect("../Admin/edit-user?ID=" + EcryptedID + "");

                }
                if (e.CommandName == "deleterecord")
                {

                    index = Convert.ToInt32(e.CommandArgument);

                    lp.DeleteUser(index);
                    ScriptManager.RegisterStartupScript(this, this.GetType(), "alert", "alert('User successfully deleted');window.location ='./view-user.aspx';", true);


                }
                if (e.CommandName == "suspendrecord")
                {

                    index = Convert.ToInt32(e.CommandArgument);

                    lp.SuspendUser(index);
                    ScriptManager.RegisterStartupScript(this, this.GetType(), "alert", "alert('User account successfully suspended');window.location ='./view-user.aspx';", true);


                }
                if (e.CommandName == "activaterecord")
                {

                    index = Convert.ToInt32(e.CommandArgument);

                    lp.ActivateUser(index);
                    ScriptManager.RegisterStartupScript(this, this.GetType(), "alert", "alert('User account successfully activated');window.location ='./view-user.aspx';", true);


                }
            }
            catch (Exception)
            {

                throw;
            }
        }
    }
}