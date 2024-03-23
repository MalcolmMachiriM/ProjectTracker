using Microsoft.Ajax.Utilities;
using ProjectTrackingApp.Classes;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace ProjectTrackingApp
{
    public partial class create_account : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
           
        }

        protected void btnRegister_Click(object sender, EventArgs e)
        {
            List<string> errorMessages = new List<string>();

            if (string.IsNullOrWhiteSpace(txtFirstName.Text))
            {
                errorMessages.Add("Email is required");
            }
            if (string.IsNullOrWhiteSpace(txtLastName.Text))
            {
                errorMessages.Add("Email is required");
            }
            if (string.IsNullOrWhiteSpace(txtEmail.Text))
            {
                errorMessages.Add("Email is required");
            }
            if (string.IsNullOrWhiteSpace(txtPassword.Text))
            {
                errorMessages.Add("Password is required");
            }
            if (string.IsNullOrWhiteSpace(txtConfirmPassword.Text))
            {
                errorMessages.Add("Confirm Password is required");
            }

            if (txtEmail.Text.Contains("'"))
            {
                txtEmail.Text = txtEmail.Text.Replace("'", "");
            }

            if (!txtEmail.Text.Contains("@"))
            {
                errorMessages.Add("Please enter a valid email address");
            }

            if (txtPassword.Text != txtConfirmPassword.Text)
            {
                errorMessages.Add("Passwords not matching");
            }

            if (errorMessages.Count > 0)
            {
                lblLoginError.Text = string.Join("<br>", errorMessages);
                return;
            }
            CreateAccount();
        }

        private void CreateAccount()
        {
            try
            {
                EncryptDecryptClass encryptDecrypt = new EncryptDecryptClass();
                UsersManagement user = new UsersManagement("con");

                // Validate and get required parameters
                int passwordLength = 6;
                // Password validation checks
                if (txtPassword.Text.Length < passwordLength)
                {
                    lblLoginError.Text = $"Minimum Password Length is {passwordLength}";
                    return;
                }


                bool containsSpecialChar = txtPassword.Text.Any(ch => !Char.IsLetterOrDigit(ch));
                if (!containsSpecialChar)
                {
                    lblLoginError.Text = "Password Must Contain at Least One Special Character!";
                    return;
                }
                string encryptedPassword = encryptDecrypt.EncryptPassword(txtPassword.Text);


                user.SaveClient(4, txtFirstName.Text, txtLastName.Text, txtEmail.Text, txtMobile.Text, encryptedPassword);
                lblSuccess.Text = "Account successfully registered";
                Clear();
            }
            catch (Exception)
            {

                lblLoginError.Text = "An error occured while saving data";
            }
        }

        private void Clear()
        {
            txtFirstName.Text=string.Empty; 
            txtLastName.Text=string.Empty;
            txtEmail.Text=string.Empty;
            txtMobile.Text=string.Empty;
            txtPassword.Text=string.Empty;
            txtConfirmPassword.Text=string.Empty;
            lblLoginError.Text=string.Empty;
        }
    }
}