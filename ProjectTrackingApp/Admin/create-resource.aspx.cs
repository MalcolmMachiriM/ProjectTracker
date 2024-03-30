using Microsoft.Ajax.Utilities;
using ProjectTrackingApp.Classes;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace ProjectTrackingApp.Admin
{
    public partial class create_resource : System.Web.UI.Page
    {
        Resources res = new Resources("con");
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                getProjects();
            }
        }


        private void getProjects()
        {
            LookUp lp = new LookUp("con");
            DataSet Projects = lp.getAllProjects();
            if (Projects != null)
            {
                ListItem li = new ListItem("Select Project", "0");
                drpProject.DataSource = Projects;
                drpProject.DataValueField = "ID";
                drpProject.DataTextField = "ProjectName";
                drpProject.DataBind();
                drpProject.Items.Insert(0, li);
            }
            else
            {
                ListItem li = new ListItem("There are no defined projects", "0");
                drpProject.DataSource = null;
                drpProject.DataBind();
                drpProject.Items.Insert(0, li);
            }
        }
        public void msgbox(string strMessage)
        {
            string strScript = "<script language=JavaScript>";
            strScript += "window.alert(\"" + strMessage + "\");";
            strScript += "</script>";
            System.Web.UI.WebControls.Label lbl = new System.Web.UI.WebControls.Label();
            lbl.Text = strScript;
            Page.Controls.Add(lbl);
        }

        protected void btnSave_Click(object sender, EventArgs e)
        {
            if (txtDescription.Text.IsNullOrWhiteSpace() || txtName.Text.IsNullOrWhiteSpace() || drpProject.SelectedIndex==0)
            {
                msgbox("All fields are required");
            }
            else
            {
                res.Name = txtName.Text;
                res.Description = txtDescription.Text;
                res.ProjectId = long.Parse(drpProject.SelectedValue);
                res.Id = 0;

                if (res.Save())
                {
                    msgbox("Successfully saved resource");
                    Clear();
                }
            }
        }

        private void Clear()
        {
            txtName.Text= string.Empty;
            txtDescription.Text= string.Empty;
        }
    }
}