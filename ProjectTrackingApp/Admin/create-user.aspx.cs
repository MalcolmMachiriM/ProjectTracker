using ProjectTrackingApp.Classes;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Runtime.InteropServices;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace ProjectTrackingApp.Admin
{
    public partial class create_user : System.Web.UI.Page
    {
        readonly LookUp lp = new LookUp("con");
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                
                getRoles();
                getProjects();
            }
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

        private void getRoles()
        {
            try
            {
                if (lp.getRoles() != null)
                {
                    ListItem li = new ListItem("Select a role", "0");
                    drpRole.DataSource = lp.getRoles();
                    drpRole.DataValueField = "RoleID";
                    drpRole.DataTextField = "RoleName";
                    drpRole.DataBind();
                    drpRole.Items.Insert(0, li);
                }
                else
                {
                    ListItem li = new ListItem("There are no defined roles", "0");
                    drpRole.DataSource = null;
                    drpRole.DataBind();
                    drpRole.Items.Insert(0, li);
                }
               
            }
            catch (Exception ex)
            {
                throw;
            }
        }
        protected void RedAlert(string Err)
        {
            ScriptManager.RegisterStartupScript(this, typeof(Page), "Error", "<script>error('" + Err + "')</script>", false);
        }
        protected void SuccessMsg(string Msg)
        {
            ScriptManager.RegisterStartupScript(this, GetType(), "showSuccess", "Swal.fire('Success!', '" + Msg + "', 'success');", true);
        }
        protected void SuccessNotifyMsg(string Msg)
        {
            ScriptManager.RegisterStartupScript(this, typeof(Page), "Success", "<script>success('" + Msg + "')</script>", false);
        }
        protected void AmberAlert(string Err)
        {
            ScriptManager.RegisterStartupScript(this, typeof(Page), "Warning", "<script>warning('" + Err + "')</script>", false);
        }
        protected void btnSave_Click(object sender, EventArgs e)
        {
            
            UsersManagement user = new UsersManagement("con");
            if (string.IsNullOrEmpty(txtFirstName.Text))
            {
                msgbox("Please enter first name");
                return;
            }
            if (string.IsNullOrEmpty(txtLastName.Text))
            {
                msgbox("Please enter last name");
                return;
            }
            if (string.IsNullOrEmpty(txtEmail.Text))
            {
                msgbox("Please enter email");
                return;
            }
            if (txtEmail.Text.Contains("'"))
            {
                txtEmail.Text = txtEmail.Text.Replace("'", "");
            }

            if (!txtEmail.Text.Contains("@"))
            {
                msgbox("Please enter a valid email address");
                return;
            }

            if (drpRole.SelectedValue == "0")
            {
                msgbox("Please select role");
                return;
            }
            user.SaveClient(int.Parse(drpRole.SelectedValue), txtFirstName.Text, txtLastName.Text, txtEmail.Text, txtMobile.Text, "XC4G160UbpgbPhnnnYcKfw==");
            ScriptManager.RegisterStartupScript(this, this.GetType(), "alert", "alert('User successfully created');window.location ='./view-user.aspx';", true);
            Clear();

            //if (drpRole.SelectedValue == "4")
            //{
            //    ClientProjects cl = new ClientProjects("con");
            //    cl.UserId = long.Parse(Session["userid"].ToString());
            //    cl.ProjectId = long.Parse(drpProjects.SelectedValue);

            //    if (cl.Save())
            //    {
            //        msgbox("Client project saved ");

            //    }
            //    else
            //    {
            //        msgbox("Client project failed to save ");
            //    }
            //}


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
        private void Clear()
        {
            txtFirstName.Text = string.Empty;
            txtLastName.Text = string.Empty;
            txtEmail.Text = string.Empty;
            txtMobile.Text = string.Empty;
            drpRole.SelectedValue = "0";
            
        }

        protected void drpRole_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (drpRole.SelectedValue == "4")
            {
                pnlProject.Visible = true;
            }
        }
    }
}