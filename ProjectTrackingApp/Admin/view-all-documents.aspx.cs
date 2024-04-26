using ProjectTrackingApp.Classes;
using System;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Web;
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
                getDocx();
                ScriptManager.RegisterStartupScript(this, this.GetType(), "alert", "alert('Document successfully deleted');window.location ='./view-all-documents.aspx';", true);
               
            }
            if (e.CommandName== "downloadrecord")
            {
                byte[] bytes = null;
                string fileName = null;
                string contentType = null;
                string constr = ConfigurationManager.ConnectionStrings["con"].ConnectionString;
                using (SqlConnection con = new SqlConnection(constr))
                {
                    using (SqlCommand cmd = new SqlCommand())
                    {
                        cmd.CommandText = "SELECT FileName, Data,ContentType FROM Documents";
                        cmd.Connection = con;
                        con.Open();
                        using (SqlDataReader sdr = cmd.ExecuteReader())
                        {
                            sdr.Read();
                            if ((sdr.HasRows))
                            {
                                bytes = (byte[])sdr["Data"];
                                contentType = sdr["ContentType"].ToString();
                                fileName = sdr["FileName"].ToString();
                            }
                            else
                            {
                                bytes = null;
                                contentType = null;
                                fileName = string.Empty;
                            }

                        }
                        con.Close();
                    }
                    Response.Buffer = true;
                    Response.Charset = "";
                    Response.Cache.SetCacheability(HttpCacheability.NoCache);
                    Response.ContentType = contentType;
                    Response.AddHeader("content-disposition", "attachment;filename=\"" + fileName + "");
                    Response.BinaryWrite(bytes);
                    Response.Flush();
                    Response.End();
                }
            }
        }
    }
}