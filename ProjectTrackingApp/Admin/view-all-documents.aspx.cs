﻿using ProjectTrackingApp.Classes;
using System;
using System.Data;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace ProjectTrackingApp.Admin
{
    public partial class view_all_documents : System.Web.UI.Page
    {
        Documents doc = new Documents("con");
        QueryStringModule qn = new QueryStringModule();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                getDocx();
            }
        }

        private void getDocx()
        {
            
            DataSet ds = doc.getAllDocuments();
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

        public void msgbox(string strMessage)
        {
            string strScript = "<script language=JavaScript>";
            strScript += "window.alert(\"" + strMessage + "\");";
            strScript += "</script>";
            System.Web.UI.WebControls.Label lbl = new System.Web.UI.WebControls.Label();
            lbl.Text = strScript;
            Page.Controls.Add(lbl);
        }


        protected void grdDocuments_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            long index = long.Parse(e.CommandArgument.ToString());
            if (e.CommandName== "deleterecord")
            {
                doc.DeleteProject(index);
                ScriptManager.RegisterStartupScript(this, this.GetType(), "alert", "alert('Project successfully deleted');window.location ='./view-projects.aspx';", true);
            }
            if (e.CommandName== "downloadrecord")
            {
                doc.DeleteProject(index);
                ScriptManager.RegisterStartupScript(this, this.GetType(), "alert", "alert('Project successfully deleted');window.location ='./view-projects.aspx';", true);
            }
        }
    }
}