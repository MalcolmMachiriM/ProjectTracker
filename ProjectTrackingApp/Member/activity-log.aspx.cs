using ProjectTrackingApp.Classes;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace ProjectTrackingApp.Member
{
    public partial class activity_log : System.Web.UI.Page
    {
        readonly ProjectTask task = new ProjectTask("con");
        readonly TaskMembers mem = new TaskMembers("con");
        readonly LookUp lp = new LookUp("con");
        readonly ActivityLogs logs = new ActivityLogs("con");
        readonly QueryStringModule qn = new QueryStringModule();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                txtid.Value = "0";
                if (Request.QueryString["ID"] != null)
                {
                    txtid.Value = qn.Decrypt(HttpUtility.UrlDecode(Request.QueryString["ID"].ToString()));

                }

                getTaskDetails();
                getActivityLogs();
                getSettings();
            }
        }

        private void getSettings()
        {
            DataSet ds = lp.getStatus();
            if (ds !=null)
            {
                ListItem li = new ListItem("Select task status", "0");
                drpStatus.DataValueField = "ID";
                drpStatus.DataTextField= "Status";
                drpStatus.DataSource = ds;
                drpStatus.DataBind();
                drpStatus.Items.Insert(0,li);
            }
            else
            {
                ListItem li = new ListItem("no task status found", "0");
                drpStatus.DataSource = null;
                drpStatus.DataBind();
                drpStatus.Items.Insert(0, li);
            }
        }

        private void getActivityLogs()
        {
            DataSet ds = logs.getLogs(long.Parse(txtid.Value));
            if (ds!=null)
            {
                grdActivityLog.DataSource = ds;
                grdActivityLog.DataBind();
            }
            else
            {
                grdActivityLog.DataSource = null;
                grdActivityLog.DataBind();
            }
        }

        private void getTaskDetails()
        {
            try
            {
                DataSet ds = task.getTask(long.Parse(txtid.Value));
                txtProjectName.Text = ds.Tables[0].Rows[0]["ProjectName"].ToString();
                txtTaskName.Text = ds.Tables[0].Rows[0]["Name"].ToString();
                txtProjectManager.Text = ds.Tables[0].Rows[0]["FullName"].ToString();
                txtStatus.Text = ds.Tables[0].Rows[0]["Status"].ToString();

            }
            catch (Exception ex)
            {

                msgbox(ex.Message);
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
            if (txtLog.Text !=null && drpStatus.SelectedIndex  !=0)
            {
                logs.ActivityLog = txtLog.Text;
                logs.ActivityId = long.Parse(txtid.Value);
                if (logs.Save())
                {
                    clear();
                    msgbox("Daily Log Added");
                    getActivityLogs();

                }
                else
                {
                    msgbox("Failed to save");
                }
            }
            else
            {
                msgbox("Fill in all fields");
            }
        }

        private void clear()
        {
            txtLog.Text = string.Empty;
            drpStatus.SelectedIndex = 0;
        }

        protected void grdActivityLog_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            int index;

            if (e.CommandName == "deleterecord")
            {

                index = Convert.ToInt32(e.CommandArgument);
                logs.RemoveLog(index, int.Parse(txtid.Value));
                getActivityLogs();
                msgbox("Log successfully removed");

            }
        }
    }
}