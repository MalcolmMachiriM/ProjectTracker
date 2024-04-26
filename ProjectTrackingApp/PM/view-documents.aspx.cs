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
    public partial class view_documents : System.Web.UI.Page
    {
        Documents doc = new Documents("con");
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                getDocuments();
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
        private void getDocuments()
        {
            DataSet ds = doc.getAllDocuments(long.Parse(Session["userid"].ToString()));

            if (ds!=null)
            {
                grdDocuments.DataSource = ds;
                grdDocuments.DataBind();
            }
            else
            {
                msgbox("No documents");
            }
        }

        protected void grdDocuments_RowCommand(object sender, GridViewCommandEventArgs e)
        {

        }

        protected void grdDocuments_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {

        }
    }
}