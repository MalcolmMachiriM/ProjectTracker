using ProjectTrackingApp.Classes;
using System;
using System.Data;
using System.IO;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace ProjectTrackingApp.Admin
{
    public partial class admin_add_document : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                getProjects();
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


        private void getProjects()
        {
            long id = long.Parse(Session["userid"].ToString());
            LookUp lp = new LookUp("con");
            DataSet Projects = lp.getAllProjects(); ;
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

        protected void btnSave_Click(object sender, EventArgs e)
        {
            string filename = Path.GetFileName(flDocx.PostedFile.FileName);
            string contentType = flDocx.PostedFile.ContentType;
            Documents dc = new Documents("con");
            using (Stream fs = flDocx.PostedFile.InputStream)
            {
                using (BinaryReader br = new BinaryReader(fs))
                {
                    byte[] bytes = br.ReadBytes((Int32)fs.Length);

                    dc.Data = bytes;
                    dc.ContentType = contentType;
                    dc.Description = txtDescription.Text;
                    dc.FileName = filename;
                    dc.Id = 0;
                    dc.ProjectId = long.Parse(drpProjects.SelectedValue);
                    dc.UserId = long.Parse(Session["userid"].ToString());

                    if (dc.Save())
                    {
                        msgbox("file saved");
                        Clear();
                        ScriptManager.RegisterStartupScript(this, this.GetType(), "alert", "alert('Document successfully added');window.location ='./view-all-documents.aspx';", true);
                        
                    }
                    else
                    {
                        msgbox("error in saving");
                    }
                }
            }


        }

        private void Clear()
        {
            txtDescription.Text = string.Empty;
            drpProjects.SelectedIndex = 0;
        }
    }
}