using ProjectTrackingApp.Classes;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace ProjectTrackingApp.RiskManagement
{
    public partial class RiskModelling : System.Web.UI.Page
    {
        readonly ProjectCategory pc = new ProjectCategory("con");
        readonly Risks risk = new Risks("con");
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                getSettings();
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
        private void getSettings()
        {
            
            DataSet ds = pc.getAllCategories();
            if (ds != null )
            {
                ListItem li = new ListItem("Select Category", "0");
                drpCategory.DataSource = ds;
                drpCategory.DataTextField = "Category";
                drpCategory.DataValueField = "ID";
                drpCategory.DataBind();
                drpCategory.Items.Insert(0, li);
            }
            else
            {
                ListItem li = new ListItem("No Categories Found", "0");
                drpCategory.DataSource = ds;
                drpCategory.DataBind();
                drpCategory.Items.Insert(0, li);
            }
        }

        protected void btnSave_Click(object sender, EventArgs e)
        {
            risk.ProjectCategory = long.Parse(drpCategory.SelectedValue);
            risk.Risk = txtRisk.Text;
            if (risk.Save())
            {
                msgbox("Successfully Saved the data");
                Clear();
            }
            else
            {
                msgbox("Oops, something happened"+"\n"+risk.MsgFlg);
            }
        }

        private void Clear()
        {
            txtRisk.Text = string.Empty;
            drpCategory.SelectedIndex = 0;
        }
    }
}