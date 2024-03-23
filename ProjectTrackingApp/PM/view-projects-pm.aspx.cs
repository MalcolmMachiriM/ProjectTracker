using Microsoft.Ajax.Utilities;
using ProjectTrackingApp.Classes;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace ProjectTrackingApp.PM
{
    public partial class view_projects_pm : System.Web.UI.Page
    {
        readonly Risks risk = new Risks("con");
        readonly ProjectCategory pro = new ProjectCategory("con");
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
                getPredicatedRisks();
            }
        }

        private void getPredicatedRisks()
        {
            DataSet ds = risk.getRisks(long.Parse(drpProjectCategory.SelectedValue));
            if (ds!=null)
            {
                grdPredictedRisks.DataSource = ds;
                grdPredictedRisks.DataBind();
            }
            else
            {
                grdPredictedRisks.DataSource = null;
                grdPredictedRisks.DataBind();
            }
        }

        private void getSettings()
        {
            try
            {


                if (pro.getAllCategories() != null)
                {
                    ListItem li = new ListItem("Select a project categories", "0");
                    drpProjectCategory.DataSource = pro.getAllCategories();
                    drpProjectCategory.DataValueField = "ID";
                    drpProjectCategory.DataTextField = "Category";
                    drpProjectCategory.DataBind();
                    drpProjectCategory.Items.Insert(0, li);
                }
                else
                {
                    ListItem li = new ListItem("There are no project categories", "0");
                    drpProjectCategory.DataSource = null;
                    drpProjectCategory.DataBind();
                    drpProjectCategory.Items.Insert(0, li);
                }
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
        private void getProjectDetails()
        {
            DataSet dataSet = lp.getProjectByID(int.Parse(txtid.Value));
            if (dataSet != null)
            {

                DataRow dt = dataSet.Tables[0].Rows[0];
                txtProjectName.Text = dt["ProjectName"].ToString();
                drpStatus.SelectedValue = dt["ProjectStatusID"].ToString();
                drpProjectManager.SelectedValue = dt["ProjectManagerID"].ToString();
                drpProjectCategory.SelectedValue = dt["ProjectCategory"].ToString();
            }

        }

        protected void btnSave_Click(object sender, EventArgs e)
        {
            if (txtRisk.Text.IsNullOrWhiteSpace())
            {
                msgbox("Can not save empty field");
            }
            else
            {
                risk.Risk = txtRisk.Text;
                risk.ProjectCategory = long.Parse(drpProjectCategory.SelectedValue);
                if (risk.Save())
                {
                    msgbox("Risk Added to Model");
                    Clear();
                    getPredicatedRisks();
                }
                else
                {
                    msgbox("Failed to save");
                }
            }
            
        }

        private void Clear()
        {
            drpProjectCategory.SelectedIndex=0;
            txtRisk.Text= string.Empty;
        }

        protected void grdPredictedRisks_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            int index;
            if (e.CommandName == "selectrecord")
            {
                index = Convert.ToInt32(e.CommandArgument);
                string EcryptedID = HttpUtility.UrlEncode(qn.Encrypt(index.ToString()));
                Response.Redirect("../Admin/edit-project?ID=" + EcryptedID + "");

            }
        }
    }
}