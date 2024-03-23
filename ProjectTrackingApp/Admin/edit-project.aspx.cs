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
    public partial class edit_project : System.Web.UI.Page
    {
        readonly LookUp lp = new LookUp("con");
        readonly QueryStringModule qn = new QueryStringModule();
        readonly ProjectCategory pro = new ProjectCategory("con");
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
            }
        }
        private void getProjectDetails()
        {
            DataSet dataSet = lp.getProjectByID(int.Parse(txtid.Value));
            if (dataSet != null)
            {

                DataRow dt = dataSet.Tables[0].Rows[0];
                txtProjectName.Text = dt["ProjectName"].ToString();
                txtProjectLocation.Text = dt["ProjectLocation"].ToString();
                txtStartDate.Text = dt["StartDate"].ToString();
                txtEndDate.Text = dt["EndDate"].ToString();
                txtBudget.Text = dt["Budegt"].ToString();
                txtClientName.Text = dt["ClientName"].ToString();
                txtClientInfo.Text = dt["ClientMobile"].ToString();
                drpStatus.SelectedValue = dt["ProjectStatusID"].ToString();
                drpType.SelectedValue = dt["ProjectTypeID"].ToString();
                drpCurrency.SelectedValue = dt["CurrencyID"].ToString();
                drpProjectManager.SelectedValue = dt["ProjectManagerID"].ToString();
            }

        }

        private void getSettings()
        {
            try
            {
                if (pro.getAllCategories() != null)
                {
                    ListItem li = new ListItem("Select category", "0");
                    drpProjectCategory.DataSource = pro.getAllCategories();
                    drpProjectCategory.DataValueField = "ID";
                    drpProjectCategory.DataTextField = "Category";
                    drpProjectCategory.DataBind();
                    drpProjectCategory.Items.Insert(0, li);
                }
                else
                {
                    ListItem li = new ListItem("There are no defined categories", "0");
                    drpProjectCategory.DataSource = null;
                    drpProjectCategory.DataBind();
                    drpProjectCategory.Items.Insert(0, li);
                }
                if (lp.getCurrency() != null)
                {
                    ListItem li = new ListItem("Select currency", "0");
                    drpCurrency.DataSource = lp.getCurrency();
                    drpCurrency.DataValueField = "ID";
                    drpCurrency.DataTextField = "Name";
                    drpCurrency.DataBind();
                    drpCurrency.Items.Insert(0, li);
                }
                else
                {
                    ListItem li = new ListItem("There are no defined currencies", "0");
                    drpCurrency.DataSource = null;
                    drpCurrency.DataBind();
                    drpCurrency.Items.Insert(0, li);
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

                if (lp.getProjectType() != null)
                {
                    ListItem li = new ListItem("Select a project type", "0");
                    drpType.DataSource = lp.getProjectType();
                    drpType.DataValueField = "ID";
                    drpType.DataTextField = "Type";
                    drpType.DataBind();
                    drpType.Items.Insert(0, li);
                }
                else
                {
                    ListItem li = new ListItem("There are no defined project types", "0");
                    drpType.DataSource = null;
                    drpType.DataBind();
                    drpType.Items.Insert(0, li);
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
            if (string.IsNullOrEmpty(txtProjectName.Text))
            {
                msgbox("Please enter project name");
                return;
            }
            if (string.IsNullOrEmpty(txtProjectLocation.Text))
            {
                msgbox("Please enter project location");
                return;
            }
            if (string.IsNullOrEmpty(txtStartDate.Text))
            {
                msgbox("Please enter project location");
                return;
            }
            if (string.IsNullOrEmpty(txtEndDate.Text))
            {
                msgbox("Please enter project location");
                return;
            }
            if (drpType.SelectedValue == "0")
            {
                msgbox("Please enter project type");
                return;
            }
            if (drpStatus.SelectedValue == "0")
            {
                msgbox("Please enter project status");
                return;
            }
            if (string.IsNullOrEmpty(txtBudget.Text))
            {
                msgbox("Please enter project budget");
                return;
            }
            if (drpCurrency.SelectedValue == "0")
            {
                msgbox("Please enter budget currency");
                return;
            }
            if (string.IsNullOrEmpty(txtClientName.Text))
            {
                msgbox("Please enter client name");
                return;
            }
            if (string.IsNullOrEmpty(txtClientInfo.Text))
            {
                msgbox("Please enter client mobile");
                return;
            }
            if (drpProjectManager.SelectedValue == "0")
            {
                msgbox("Please enter project manager");
                return;
            }
            if (drpProjectCategory.SelectedValue == "0")
            {
                msgbox("Please enter project category");
                return;
            }
            Save();
        }


        private void Save()
        {
            lp.SaveProject(int.Parse(txtid.Value), txtProjectName.Text, txtProjectLocation.Text.ToLower(), Convert.ToDateTime(txtStartDate.Text), Convert.ToDateTime(txtEndDate.Text), int.Parse(drpStatus.SelectedValue), int.Parse(drpType.SelectedValue), double.Parse(txtBudget.Text), int.Parse(drpCurrency.SelectedValue), txtClientName.Text, txtClientInfo.Text, int.Parse(drpProjectManager.SelectedValue), int.Parse(Session["userid"].ToString()), long.Parse(drpProjectCategory.SelectedValue));
            ScriptManager.RegisterStartupScript(this, this.GetType(), "alert", "alert('Project successfully modified');window.location ='./view-projects';", true);

        }
    }
}