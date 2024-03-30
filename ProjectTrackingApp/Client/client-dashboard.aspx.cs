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
    public partial class client_dashboard : System.Web.UI.Page
    {
        LookUp lp = new LookUp("con");
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                getStats();
                getOngoing();
            }
        }

        private void getOngoing()
        {
            ClientProjects cli = new ClientProjects("con");
            DataSet ds = cli.getAllOngoingProjects(long.Parse(Session["userid"].ToString()));
            if (ds != null)
            {
                grdProjects.DataSource = ds;
                grdProjects.DataBind();
            }
        }

        private void getStats()
        {
            DataSet ds = lp.getStats();
            if (ds != null)
            {
                txtAllocatedTasks.Text = ds.Tables[1].Rows[0]["TotalTasks"].ToString();
                txtPendingTasks.Text = ds.Tables[2].Rows[0]["AllocatedTasks"].ToString();
                txtResources.Text = ds.Tables[0].Rows[0]["Projects"].ToString();
            }
            else
            {
                txtPendingTasks.Text = "0";
                txtAllocatedTasks.Text = "0";
                txtPendingTasks.Text = "0";
            }
        }
    }
}