using ProjectTrackingApp.Classes;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Data;
using System.IO;
using System.Linq;
using System.Net.Mail;
using System.Net;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace ProjectTrackingApp.Member
{
    public partial class member_comms : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                txtID.Value = "0";
                mess.Visible = true;
            }

        }
        #region alert

        public void msgbox(string strMessage)
        {
            string strScript = "<script language=JavaScript>";
            strScript += "window.alert(\"" + strMessage + "\");";
            strScript += "</script>";
            System.Web.UI.WebControls.Label lbl = new System.Web.UI.WebControls.Label();
            lbl.Text = strScript;
            Page.Controls.Add(lbl);
        }
        #endregion

        #region methods

        protected void UploadFile(int ID, string filename, string filePath)
        {
            try
            {
                if (flRsvpUpload.HasFiles)
                {


                    string contentType = flRsvpUpload.PostedFile.ContentType;

                    using (Stream fs = flRsvpUpload.PostedFile.InputStream)
                    {
                        using (BinaryReader br = new BinaryReader(fs))
                        {
                            byte[] bytes = br.ReadBytes((Int32)fs.Length);
                            string constr = ConfigurationManager.ConnectionStrings["con"].ConnectionString;
                            using (SqlConnection con = new SqlConnection(constr))
                            {
                                string query = "insert into EmailAttachments([BroadcastMessagesListID],[FileName],[FilePath]) values(@BroadcastMessagesListID,@FileName,@FilePath)";
                                using (SqlCommand cmd = new SqlCommand(query))
                                {
                                    cmd.Connection = con;
                                    cmd.Parameters.Add("@BroadcastMessagesListID", SqlDbType.Int).Value = ID;
                                    cmd.Parameters.Add("@FileName", SqlDbType.NVarChar).Value = filename;
                                    cmd.Parameters.Add("@FilePath", SqlDbType.NVarChar).Value = filePath;

                                    con.Open();
                                    cmd.ExecuteNonQuery();
                                    con.Close();
                                }
                            }
                        }
                    }
                }
                else
                {
                    return;
                }
            }
            catch (Exception cv)
            {

                msgbox(cv.Message);
            }
        }

        private void SendHtmlFormattedEmail(string recepientEmail, string subject, string body, string MessageBody, int MemberId)
        {

            try
            {

                ServicePointManager.ServerCertificateValidationCallback = (s, certificate, chain, sslPolicyErrors) => true;


                SmtpClient Client = new SmtpClient()
                {
                    Credentials = new NetworkCredential("biguncleswae@gmail.com", "lalz vbkx sgam pqzf"),
                    Port = 587,
                    Host = "smtp.gmail.com",
                    EnableSsl = true,
                };



                MailMessage Message = new MailMessage();
                Message.From = new MailAddress("biguncleswae@gmail.com", "Project Tracker System");
                Message.To.Add(recepientEmail);
                Message.Subject = subject;
                Message.IsBodyHtml = true;


                LookUp fl = new LookUp("con");
                DataSet ds = fl.GetFilePath(int.Parse(txtID.Value));
                if (ds != null)
                {
                    foreach (DataRow item in ds.Tables[0].Rows)
                    {
                        string filePath = item["FilePath"].ToString();
                        Message.Attachments.Add(new Attachment(filePath));
                    }
                }

                AlternateView htmlView = AlternateView.CreateAlternateViewFromString(body, null, "text/html");

                Message.AlternateViews.Add(htmlView);
                try
                {

                    Client.Send(Message);
                }
                catch (Exception e)
                {

                    msgbox(e.Message);
                    return;
                }

                BroadcastMessagesList bc = new BroadcastMessagesList("con", 1);
                if (bc.UpdateEmailListStatus(int.Parse(txtID.Value), MemberId))
                {

                }
            }
            catch (Exception ex)
            {
                msgbox(ex.Message);
                BroadcastMessagesList bc = new BroadcastMessagesList("con", 1);
                if (bc.UpdateEmailListStatusFailed(int.Parse(txtID.Value), MemberId))
                {

                }
            }
        }

        protected void btnSave_Click(object sender, EventArgs e)
        {
            try
            {

                BroadcastMessagesList b = new BroadcastMessagesList("con", 1);
                b.ID = int.Parse(txtID.Value);
                b.StatusID = 1;
                b.BroadcastMessgeTitle = txtHeader.Text;

                b.Message = txtMessageBody.Text;
                if (b.Save())
                {
                    txtID.Value = b.ID.ToString();
                    foreach (HttpPostedFile postedFile in flRsvpUpload.PostedFiles)
                    {
                        if (postedFile.ContentLength > 0)
                        {
                            string fileName = Path.GetFileName(postedFile.FileName);
                            string filePath = Server.MapPath("~/Communication/Attachments/" + fileName); // Save to a folder
                            postedFile.SaveAs(filePath);

                            // Insert file information into the database
                            UploadFile(int.Parse(txtID.Value), fileName, filePath);

                            // Attach the file to the email
                            //Message.Attachments.Add(new Attachment(filePath));
                        }
                    }
                    getUnassignedContactstoTheMessage(int.Parse(txtID.Value));
                    getassignedContactstoTheMessage(int.Parse(txtID.Value));
                    msgbox("Broadcast Message Created, add contacts to the list below and send out your message");
                }
                else
                {
                    msgbox(b.MsgFlg);
                }

            }
            catch (Exception ex)
            {
                msgbox(ex.Message);
            }
        }

        protected void getUnassignedContactstoTheMessage(int BroadcastList)
        {
            try
            {
                BroadcastMessagesList b = new BroadcastMessagesList("con", 1);
                if (b.getUnassignedContacts(BroadcastList) != null)
                {
                    lstUnassigned.DataSource = b.getUnassignedContacts(BroadcastList);
                    lstUnassigned.DataValueField = "UserID";
                    lstUnassigned.DataTextField = "Member";
                    lstUnassigned.DataBind();

                }
                else
                {
                    lstUnassigned.Items.Clear();
                }
            }
            catch (Exception ex)
            {
                msgbox(ex.Message);
            }
        }

        protected void getassignedContactstoTheMessage(int BroadcastList)
        {
            try
            {
                BroadcastMessagesList b = new BroadcastMessagesList("con", 1);
                if (b.getassignedContacts(BroadcastList) != null)
                {
                    lstMailingList.DataSource = b.getassignedContacts(BroadcastList);
                    lstMailingList.DataValueField = "UserID";
                    lstMailingList.DataTextField = "Member";
                    lstMailingList.DataBind();

                }
                else
                {
                    lstMailingList.Items.Clear();
                }
            }
            catch (Exception ex)
            {
                msgbox(ex.Message);
            }
        }

        protected void btnAdd_Click(object sender, EventArgs e)
        {
            try
            {
                BroadcastContacts b = new BroadcastContacts("con", 1);
                if (int.Parse(txtID.Value) > 0)
                {
                    List<int> lipen = new List<int>();
                    foreach (ListItem item in lstUnassigned.Items)
                    {
                        if (item.Selected == true)
                        {
                            b.ID = 0;
                            b.BroadcastListID = int.Parse(txtID.Value);
                            b.MemberID = int.Parse(item.Value);
                            b.EmailAddress = item.Text;
                            b.MobileNo = item.Text;
                            b.StatusID = 1;
                            b.Save();
                        }
                    }
                    getUnassignedContactstoTheMessage(int.Parse(txtID.Value));
                    getassignedContactstoTheMessage(int.Parse(txtID.Value));

                    msgbox("Contacts added to the sending list");
                }
                else
                {
                    msgbox("Save a valid broadcast message first to enable the adding of pensioners to messaging list");
                    return;

                }
            }
            catch (Exception ex)
            {
                msgbox(ex.Message);
            }
        }

        protected void btnRemove_Click(object sender, EventArgs e)
        {

        }

        private void SendEmail(string email)
        {

            try
            {
                SmtpClient smtpServer = new SmtpClient();
                MailMessage mail = new MailMessage();

                smtpServer.Credentials = new NetworkCredential("ghostswae@gmail.co.zw", "cive15Um");
                smtpServer.Port = 587;
                smtpServer.Host = "smtp.gmail.com";
                smtpServer.EnableSsl = true;

                mail.From = new MailAddress("ghostswae@gmail.co.zw");
                mail.To.Add(email);
                mail.Subject = txtHeader.Text;

                string msgBody = "Good day , <br />  <hr /> <br />"
                    + "Password: " + txtMessageBody.Text + " <br />"
                    + "Thank you <br />"
                    + "Project Tracker System"
                    + "<hr />";

                mail.Body = msgBody;
                mail.IsBodyHtml = true;

                ServicePointManager.ServerCertificateValidationCallback = (s, certificate, chain, sslPolicyErrors) => true;
                try
                {
                    smtpServer.Send(mail);
                    msgbox("Message sent");
                    ClearFields();
                }
                catch (Exception exx)
                {
                    msgbox(exx.Message);
                    throw;
                }

            }
            catch (Exception ex)
            {
                msgbox("Someting went wrong\n" + ex.Message);
            }
        }
        private void ClearFields()
        {
            //txtEmailTo.Text = string.Empty;
            txtHeader.Text = string.Empty;
            txtMessageBody.Text = string.Empty;
        }
        protected void btnsend_Click(object sender, EventArgs e)
        {
            try
            {
                BroadcastContacts b = new BroadcastContacts("con", 1);
                if (b.getBroadCastContactDetails(int.Parse(txtID.Value)) != null)
                {
                    foreach (DataRow rw in b.getBroadCastContactDetails(int.Parse(txtID.Value)).Tables[0].Rows)
                    {
                        string email = rw["Email"].ToString();
                        //string messagebody = rw["Message"].ToString();
                        string messagebody = txtMessageBody.Text;
                        string header = txtHeader.Text;
                        SendHtmlFormattedEmail(recepientEmail: email, subject: header, body: messagebody, MessageBody: messagebody, MemberId: int.Parse(Session["userid"].ToString()));
                        msgbox("Message Sent");

                        //string msgbdy = PopulateBody();

                        if (b.checkContantsStatus(int.Parse(txtID.Value)))
                        {
                            if (b.updateContantsStatustoReadySend(int.Parse(txtID.Value)))
                            {
                                if (b.checkMessageStatus(int.Parse(txtID.Value)))
                                {
                                    if (b.updateMessageStatustoReadySend(int.Parse(txtID.Value)))
                                    {

                                    }
                                }
                                else
                                {
                                    msgbox("Already Sent");
                                }

                            }
                            else
                            {
                                msgbox("Couldnt Send");
                            }
                        }
                        else
                        {
                            msgbox("Email Already Sent");
                        }


                    }


                }


            }
            catch (Exception ex)
            {
                msgbox(ex.Message);
            }
        }
        #endregion
    }
}