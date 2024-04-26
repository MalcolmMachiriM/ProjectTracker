using Microsoft.Ajax.Utilities;
using ProjectTrackingApp.Classes;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using static ProjectTrackingApp.Classes.ProjectTask;

namespace ProjectTrackingApp.Admin
{
    public partial class create_task : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                getProjects();
                if (!Request.QueryString["TaskId"].IsNullOrWhiteSpace())
                {
                    txtID.Value = Request.QueryString["TaskId"].ToString();
                }
                else
                {
                    txtID.Value = "0";
                }
            }
        }

        private void getProjects()
        {
            LookUp lp = new LookUp("con");
            DataSet Projects = lp.getAllProjects();
            if (Projects != null)
            {
                ListItem li = new ListItem("Select Project", "0");
                drpProjectId.DataSource = Projects;
                drpProjectId.DataValueField = "ID";
                drpProjectId.DataTextField = "ProjectName";
                drpProjectId.DataBind();
                drpProjectId.Items.Insert(0, li);
            }
            else
            {
                ListItem li = new ListItem("There are no defined projects", "0");
                drpProjectId.DataSource = null;
                drpProjectId.DataBind();
                drpProjectId.Items.Insert(0, li);
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
            if (drpProjectId.SelectedIndex == 0 || txtName.Text.IsNullOrWhiteSpace() || txtDescription.Text.IsNullOrWhiteSpace() || 
                txtStartDate.Text.IsNullOrWhiteSpace() || txtEndDate.Text.IsNullOrWhiteSpace())
            {
                msgbox("All Fields are required");

            }
            else
            {

                SaveTask();
            }
        }

        private void SaveTask()
        {
            ProjectTask task = new ProjectTask("con");
            task.Id = long.Parse(txtID.Value);
            task.Name = txtName.Text;
            task.ProjectId = long.Parse(drpProjectId.SelectedValue);
            task.Description = txtDescription.Text;
            task.StartDate = DateTime.Parse(txtStartDate.Text);
            task.EndDate = DateTime.Parse(txtEndDate.Text);
            task.Status = (int)Statuses.Unassigned;
            task.Price = double.Parse(txtPrice.Text);
            if (task.Save())
            {
                ScriptManager.RegisterStartupScript(this, this.GetType(), "alert", "alert('Task successfully created');window.location ='./view-tasks';", true);
            }
            else
            {
                msgbox($"Oops, something went wrong!\n error:{task.MsgFlg}");
            }
        }
    }
}