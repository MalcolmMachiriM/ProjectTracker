using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace ProjectTrackingApp.PM
{
    public partial class view_documents : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                getDocuments();
            }
        }

        private void getDocuments()
        {
            throw new NotImplementedException();
        }

        protected void grdDocuments_RowCommand(object sender, GridViewCommandEventArgs e)
        {

        }

        protected void grdDocuments_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {

        }
    }
}