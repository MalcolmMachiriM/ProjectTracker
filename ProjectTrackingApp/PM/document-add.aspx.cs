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
    public partial class document_add : System.Web.UI.Page
    {
        
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                getProjects();
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


        private void getProjects()
        {
            LookUp lp = new LookUp("con");
            DataSet Projects = lp.getAllProjects();
            if (Projects != null)
            {
                ListItem li = new ListItem("Select Project", "0");
                drpProjects.DataSource = Projects;
                drpProjects.DataValueField = "ID";
                drpProjects.DataTextField = "ProjectName";
                drpProjects.DataBind();
                drpProjects.Items.Insert(0, li);
            }
            else
            {
                ListItem li = new ListItem("There are no defined projects", "0");
                drpProjects.DataSource = null;
                drpProjects.DataBind();
                drpProjects.Items.Insert(0, li);
            }
        }

        protected void btnSave_Click(object sender, EventArgs e)
        {
            Documents dc = new Documents("con");
            
        }
    }
}