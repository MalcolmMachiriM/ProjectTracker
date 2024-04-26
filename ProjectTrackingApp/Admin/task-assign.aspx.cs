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
    public partial class task_assign : System.Web.UI.Page
    {
        readonly ProjectTask task = new ProjectTask("con");
        readonly TaskMembers mem = new TaskMembers("con");
        readonly LookUp lp = new LookUp("con");
        readonly QueryStringModule qn = new QueryStringModule();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                txtid.Value = "0";
                if (Request.QueryString["ID"] != null)
                {
                    txtid.Value = qn.Decrypt(HttpUtility.UrlDecode(Request.QueryString["ID"].ToString()));

                }

                getTaskDetails();
                getTaskMembers();
                getSettings();
            }
        }

        private void getSettings()
        {
            if (lp.getTeamMembers() != null)
            {
                ListItem li = new ListItem("Select a task team members", "0");
                drpTeamMember.DataSource = lp.getTeamMembers();
                drpTeamMember.DataValueField = "UserID";
                drpTeamMember.DataTextField = "FullNames";
                drpTeamMember.DataBind();
                drpTeamMember.Items.Insert(0, li);
            }
            else
            {
                ListItem li = new ListItem("There are no task team members", "0");
                drpTeamMember.DataSource = null;
                drpTeamMember.DataBind();
                drpTeamMember.Items.Insert(0, li);
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
        private void getTaskDetails()
        {
            try
            {
                DataSet ds = task.getTask(long.Parse(txtid.Value));
                txtProjectName.Text = ds.Tables[0].Rows[0]["ProjectName"].ToString();
                txtTaskName.Text = ds.Tables[0].Rows[0]["Name"].ToString();
                txtProjectManager.Text = ds.Tables[0].Rows[0]["FullName"].ToString();
                txtStatus.Text = ds.Tables[0].Rows[0]["Status"].ToString();

            }
            catch (Exception ex)
            {

                msgbox(ex.Message);
            }
        }

        private void getTaskMembers()
        {
            DataSet ds = mem.getTaskMembers(long.Parse(txtid.Value));
            if (ds!=null)
            {
                grdMember.DataSource = ds;
                grdMember.DataBind();
            }
            else
            {
                msgbox("No Members yet");
            }

        }

        protected void btnSave_Click(object sender, EventArgs e)
        {
            try
            {
                DataSet ds = task.getTask(long.Parse(txtid.Value));
                if (drpTeamMember.SelectedValue == "0")
                {
                    msgbox("Please select a team member");
                    return;
                }
                mem.Id = 0;
                mem.UserId = long.Parse(drpTeamMember.SelectedValue);
                mem.ProjectId = long.Parse(ds.Tables[0].Rows[0]["ProjectId"].ToString());
                mem.TaskId = long.Parse(txtid.Value);
                if (mem.Save())
                {
                    if (task.UpdateStatus(long.Parse(txtid.Value),(int)Statuses.Pending))
                    {
                        getTaskMembers();
                        msgbox("Team Member successfully added to project");
                        clear();
                    }
                    else
                    {
                        msgbox("failed to update status");
                    }
                    
                    
                }
                else
                {
                    msgbox("Assigning Failed!");
                }
                
            }
            catch (Exception)
            {

                throw;
            }
        }
        private void clear()
        {
            drpTeamMember.SelectedValue = "0";
        }

        protected void grdMember_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            try
            {

                int index;

                if (e.CommandName == "deleterecord")
                {

                    index = Convert.ToInt32(e.CommandArgument);
                    mem.RemoveMemberFromTask(index, int.Parse(txtid.Value));
                    if (task.UpdateStatus(long.Parse(txtid.Value),(int)Statuses.Unassigned))
                    {
                    }
                    else
                    {
                        msgbox("status failed to update");
                    }

                    msgbox("Member successfully removed");
                    getTaskMembers();

                }

            }
            catch (Exception)
            {

                throw;
            }
        }
    }

}