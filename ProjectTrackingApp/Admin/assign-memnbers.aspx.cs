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
    public partial class assign_memnbers : System.Web.UI.Page
    {
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

                getSettings();
                getProjectDetails();
                getProjectMembers();
            }
        }
        private void getProjectDetails()
        {
            DataSet dataSet = lp.getProjectByID(int.Parse(txtid.Value));
            if (dataSet != null)
            {

                DataRow dt = dataSet.Tables[0].Rows[0];
                txtProjectName.Text = dt["ProjectName"].ToString();
                drpStatus.SelectedValue = dt["ProjectStatusID"].ToString();
                drpProjectManager.SelectedValue = dt["ProjectManagerID"].ToString();
                txtProjectID.Text = txtid.Value;
            }

        }



        private void getSettings()
        {
            try
            {
               

                if (lp.getProjectManagers() != null)
                {
                    ListItem li = new ListItem("Select a project manager", "0");
                    drpProjectManager.DataSource = lp.getProjectManagers();
                    drpProjectManager.DataValueField = "UserID";
                    drpProjectManager.DataTextField = "FullNames";
                    drpProjectManager.DataBind();
                    drpProjectManager.Items.Insert(0, li);
                }
                else
                {
                    ListItem li = new ListItem("There are no project managers", "0");
                    drpProjectManager.DataSource = null;
                    drpProjectManager.DataBind();
                    drpProjectManager.Items.Insert(0, li);
                }
                if (lp.getTeamMembers() != null)
                {
                    ListItem li = new ListItem("Select a project team members", "0");
                    drpTeamMember.DataSource = lp.getTeamMembers();
                    drpTeamMember.DataValueField = "UserID";
                    drpTeamMember.DataTextField = "FullNames";
                    drpTeamMember.DataBind();
                    drpTeamMember.Items.Insert(0, li);
                }
                else
                {
                    ListItem li = new ListItem("There are no project team members", "0");
                    drpTeamMember.DataSource = null;
                    drpTeamMember.DataBind();
                    drpProjectManager.Items.Insert(0, li);
                }


                if (lp.getProjectStatus() != null)
                {
                    ListItem li = new ListItem("Select a project status", "0");
                    drpStatus.DataSource = lp.getProjectStatus();
                    drpStatus.DataValueField = "ID";
                    drpStatus.DataTextField = "Status";
                    drpStatus.DataBind();
                    drpStatus.Items.Insert(0, li);
                }
                else
                {
                    ListItem li = new ListItem("There are no defined statuses", "0");
                    drpStatus.DataSource = null;
                    drpStatus.DataBind();
                    drpStatus.Items.Insert(0, li);
                }

            }
            catch (Exception ex)
            {
                throw;
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
            try
            {
                if (drpTeamMember.SelectedValue == "0")
                {
                    msgbox("Please select a team member");
                    return;
                }

                lp.SaveTeamMember(int.Parse(txtid.Value), int.Parse(drpTeamMember.SelectedValue), int.Parse(Session["userid"].ToString()));
                getProjectMembers();
                msgbox("Team Member successfully added to project");
                clear();
            }
            catch (Exception)
            {

                throw;
            }
            
        }
        private void getProjectMembers()
        {
            DataSet Projects = lp.getProjectMembers(int.Parse(txtid.Value));
            if (Projects != null)
            {
                grdMember.DataSource = Projects;
                grdMember.DataBind();
            }
        }
        private void clear()
        {
            drpTeamMember.SelectedValue = "0";
        }

        protected void grdMember_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            grdMember.PageIndex = e.NewPageIndex;

            this.BindGrid(e.NewPageIndex);
        }
        private void BindGrid(int page = 0)
        {
            DataSet Projects = lp.getProjectMembers(int.Parse(txtid.Value));
            if (Projects != null)
            {
                int maxPageIndex = grdMember.PageCount - 1;

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
                grdMember.DataSource = Projects;
                grdMember.PageIndex = page;
                grdMember.DataBind();


            }
            else
            {
                grdMember.DataSource = null;
                grdMember.DataBind();
            }
        }
        protected void grdMember_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            try
            {

                int index;
              
                if (e.CommandName == "deleterecord")
                {

                    index = Convert.ToInt32(e.CommandArgument);
                    lp.RemoveMemberFromProject(index,int.Parse(txtid.Value));
                    getProjectMembers();
                    msgbox("Member successfully removed");
                    
                }

            }
            catch (Exception)
            {

                throw;
            }
        }
    }
}