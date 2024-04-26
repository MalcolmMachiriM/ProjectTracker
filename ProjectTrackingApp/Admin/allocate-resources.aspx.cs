using ProjectTrackingApp.Classes;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Net.NetworkInformation;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace ProjectTrackingApp.Admin
{
    public partial class allocate_resources : System.Web.UI.Page
    {
        readonly LookUp lp = new LookUp("con");
        readonly QueryStringModule qn = new QueryStringModule();
        Resources res = new Resources("con");
        ResourceMembers rm = new ResourceMembers("con");

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
            DataSet ds = res.getResource(int.Parse(txtid.Value));
            DataSet dataSet = lp.getProjectByID(int.Parse(txtid.Value));
            if (ds != null)
            {

                DataRow dt = ds.Tables[0].Rows[0];
                txtProjectName.Text = dt["ProjectName"].ToString();
                txtResource.Text = dt["Name"].ToString();
                drpProjectManager.SelectedValue = dt["ProjectManagerID"].ToString();
                txtProjectID.Text = txtid.Value;
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
            rm.UserId = long.Parse(drpTeamMember.SelectedValue);
            rm.ResourceId = long.Parse(txtid.Value);
            if (rm.Save())
            {
                msgbox("Assigned resources successfully");
            }
            else
            {
                msgbox("failed to assign");
            }
        }

        protected void grdMember_RowCommand(object sender, GridViewCommandEventArgs e)
        {

        }
    }
}