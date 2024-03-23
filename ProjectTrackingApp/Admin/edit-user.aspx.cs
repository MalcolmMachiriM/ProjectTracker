using ProjectTrackingApp.Classes;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace ProjectTrackingApp.Admin
{
    public partial class edit_user : System.Web.UI.Page
    {
        readonly LookUp lp = new LookUp("con");
        readonly QueryStringModule qn = new QueryStringModule();
        protected void Page_Load(object sender, EventArgs e)
        {
            if(!IsPostBack)
            {
                txtid.Value = "0";
                if (Request.QueryString["ID"] != null)
                {
                    txtid.Value = qn.Decrypt(HttpUtility.UrlDecode(Request.QueryString["ID"].ToString()));
                    
                }
                getRoles();
                getUserDetails();
            }
        }

        private void getUserDetails()
        {
            DataSet dataSet = lp.getUsersByUserID(int.Parse(txtid.Value));
            if (dataSet != null)
            {

                DataRow dt = dataSet.Tables[0].Rows[0];
                txtFirstName.Text = dt["FirstName"].ToString();
                txtLastName.Text = dt["LastName"].ToString();
                txtEmail.Text = dt["Email"].ToString();
                txtMobile.Text = dt["Mobile"].ToString();
                drpRole.SelectedValue = dt["RoleID"].ToString();

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

            if (drpRole.SelectedValue == "0")
            {
                msgbox("Please select role");
                return;
            }

            user.UpdateClient(int.Parse(txtid.Value),int.Parse(drpRole.SelectedValue), txtFirstName.Text, txtLastName.Text, txtMobile.Text);
            ScriptManager.RegisterStartupScript(this, this.GetType(), "alert", "alert('User details successfully modified');window.location ='./view-user.aspx';", true);
          
        }
    }
}