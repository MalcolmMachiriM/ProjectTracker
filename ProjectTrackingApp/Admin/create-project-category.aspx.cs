using ProjectTrackingApp.Classes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace ProjectTrackingApp.Admin
{
    public partial class create_project_category : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            
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
            ProjectCategory pc = new ProjectCategory("con");
            pc.Category = txtProjectCategory.Text;
            if (pc.Save())
            {
                msgbox("Category Saved Successfully");
            }
            else
            {
                msgbox("Failed to save");
            }
        }
    }
}