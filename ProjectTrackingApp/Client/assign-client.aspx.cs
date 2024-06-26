﻿using ProjectTrackingApp.Classes;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace ProjectTrackingApp.Client
{
    public partial class assign_client : System.Web.UI.Page
    {
        readonly LookUp lp = new LookUp("con");
        readonly QueryStringModule qn = new QueryStringModule();
        ClientProjects cli = new ClientProjects("con");
        protected void Page_Load(object sender, EventArgs e)
        {
            MaintainScrollPositionOnPostBack = true;
            txtid.Value = "0";
            if (Request.QueryString["ID"] != null)
            {
                txtid.Value = qn.Decrypt(HttpUtility.UrlDecode(Request.QueryString["ID"].ToString()));

            }
            getSettings();
            getProjects();

            getUserDetails();
        }

        private void getUserDetails()
        {
            DataSet dataSet = lp.getUsersByUserID(int.Parse(txtid.Value));
            if (dataSet != null)
            {

                DataRow dt = dataSet.Tables[0].Rows[0];
                txtClientName.Text = dt["FirstName"].ToString();
                txtClientSurname.Text = dt["LastName"].ToString();

            }

        }
        private void getProjects()
        {
            DataSet ds = cli.getAllProjects(long.Parse(txtid.Value));
            if (ds!=null)
            {
                grdProjects.DataSource = ds;
                grdProjects.DataBind();
            }
        }

        private void getSettings()
        {
            try
            {
                if (lp.getProjectStatus() != null)
                {
                    
                    ListItem li = new ListItem("Select a project", "0");
                    drpProjects.DataSource = lp.getAllProjects();
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
            if (drpProjects.SelectedValue == "0")
            {
                msgbox("Please select a project");
                return;
            }
            long ps = long.Parse(drpProjects.SelectedValue); 
            cli.ProjectId = ps;
            cli.UserId = long.Parse(txtid.Value);
            if (cli.Save())
            {
                msgbox("Client assigned");
                getProjects();
                Clear();
            }
            else
            {
                msgbox("Failed to assign client");
            }
        }

        private void Clear()
        {
            drpProjects.SelectedIndex = 0;
        }

        protected void grdMember_RowCommand(object sender, GridViewCommandEventArgs e)
        {

        }
    }
}