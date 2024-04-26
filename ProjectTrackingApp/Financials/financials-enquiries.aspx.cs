﻿using ProjectTrackingApp.Classes;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace ProjectTrackingApp.Financials
{
    public partial class financials_enquiries : System.Web.UI.Page
    {
        QueryStringModule qn = new QueryStringModule();
        readonly LookUp lp = new LookUp("con");
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                ViewProjects();
            }
        }
        private void ViewProjects()
        {
            DataSet Projects = lp.getAllProjects();
            if (Projects != null)
            {
                grdProject.DataSource = Projects;
                grdProject.DataBind();
            }
        }

        protected void grdProject_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            grdProject.PageIndex = e.NewPageIndex;

            this.BindGrid(e.NewPageIndex);
        }
        private void BindGrid(int page = 0)
        {
            DataSet Projects = lp.getAllProjects();
            if (Projects != null)
            {
                int maxPageIndex = grdProject.PageCount - 1;

                if (page < 0 || page > maxPageIndex)
                {
                    if (maxPageIndex >= 0)
                    {
                        // Navigate to the last available page
                        page = maxPageIndex;
                    }
                    else
                    {
                        // No data available, reset to the first page
                        page = 0;
                    }
                }
                grdProject.DataSource = Projects;
                grdProject.PageIndex = page;
                grdProject.DataBind();


            }
            else
            {
                grdProject.DataSource = null;
                grdProject.DataBind();
            }
        }
        protected void grdProject_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            try
            {

                int index;
                if (e.CommandName == "assignrecord")
                {
                    index = Convert.ToInt32(e.CommandArgument);
                    string EcryptedID = HttpUtility.UrlEncode(qn.Encrypt(index.ToString()));
                    Response.Redirect("./view-financials?ID=" + EcryptedID + "");

                }

            }
            catch (Exception)
            {

                throw;
            }
        }
    }
}