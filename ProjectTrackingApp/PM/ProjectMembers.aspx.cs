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
    public partial class ProjectMembers : System.Web.UI.Page
    {
        QueryStringModule qn = new QueryStringModule();
        readonly LookUp lp = new LookUp("con");
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                if (Request.QueryString["ID"] !=null)
                {
                    txtid.Value = HttpUtility.UrlDecode(qn.Decrypt(Request.QueryString["ID"].ToString()));
                }

                getMembers();
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

        private void getMembers()
        {
            DataSet ds = lp.GetTeamMember(long.Parse(txtid.Value));
            if (ds != null)
            {
                grdMembers.DataSource = ds;
                grdMembers.DataBind();
            }
            else
            {
                msgbox("No members found");
            }
        }

        protected void grdTasks_RowCommand(object sender, GridViewCommandEventArgs e)
        {

        }
    }
}