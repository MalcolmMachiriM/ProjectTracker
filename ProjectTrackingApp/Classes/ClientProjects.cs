using Microsoft.Practices.EnterpriseLibrary.Data;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Web;

namespace ProjectTrackingApp.Classes
{
    public class ClientProjects
    {
        #region "Variables"

        protected DataSet mUserDetails;
        protected long mID;
        protected long mProjectId;
        protected string mMsgFlg;
        protected long mUserId;
        protected Database db;
        protected string mConnectionName;

        protected long mObjectUserID;
        #endregion

        #region "Properties"
        public DataSet UserDetails
        {
            get { return mUserDetails; }
            set { mUserDetails = value; }
        }
        public long Id
        {
            get { return mID; }
            set { mID = value; }
        }
        public long ProjectId
        {
            get { return mProjectId; }
            set { mProjectId = value; }
        }
        public long UserId
        {
            get { return mUserId; }
            set { mUserId = value; }
        }
        public string MsgFlg
        {
            get { return mMsgFlg; }
            set { mMsgFlg = value; }
        }

        public Database Database
        {
            get { return db; }
        }

        public string ConnectionName
        {
            get { return mConnectionName; }
        }

        #endregion

        #region "Methods"
        public void RemoveProjectFromClient(int ID, int ProjectId)
        {
            string constr = ConfigurationManager.ConnectionStrings["con"].ConnectionString;
            SqlConnection sqlCon = null;
            using (sqlCon = new SqlConnection(constr))
            {
                sqlCon.Open();
                SqlCommand sql_cmnd = new SqlCommand("sp_ClientProjectDel", sqlCon);
                sql_cmnd.CommandType = CommandType.StoredProcedure;
                sql_cmnd.Parameters.AddWithValue("@ID", SqlDbType.Int).Value = ID;
                sql_cmnd.Parameters.AddWithValue("@ProjectId", SqlDbType.Int).Value = ProjectId;
                sql_cmnd.ExecuteNonQuery();
                sqlCon.Close();
            }
        }
        public DataSet getAllProjects(long UserId)
        {
            string str = "sp_getAssignedClientProjects";
            System.Data.Common.DbCommand cmd = db.GetStoredProcCommand(str);
            db.AddInParameter(cmd, "@UserId", DbType.Int32, UserId);

            DataSet ds = db.ExecuteDataSet(cmd);
            if (ds != null && ds.Tables.Count > 0 && ds.Tables[0].Rows.Count > 0)
            {
                return ds;

            }
            else
            {
                return null;
            }
        }
        public DataSet getAllOngoingProjects(long UserId)
        {
            string str = "sp_getOngoingClientProjects";
            System.Data.Common.DbCommand cmd = db.GetStoredProcCommand(str);
            db.AddInParameter(cmd, "@UserId", DbType.Int32, UserId);

            DataSet ds = db.ExecuteDataSet(cmd);
            if (ds != null && ds.Tables.Count > 0 && ds.Tables[0].Rows.Count > 0)
            {
                return ds;

            }
            else
            {
                return null;
            }
        }
        public DataSet getTask(long TaskId)
        {
            string str = "sp_getClientProjects";
            System.Data.Common.DbCommand cmd = db.GetStoredProcCommand(str);
            db.AddInParameter(cmd, "@UserID", DbType.Int32, TaskId);

            DataSet ds = db.ExecuteDataSet(cmd);
            if (ds != null && ds.Tables.Count > 0 && ds.Tables[0].Rows.Count > 0)
            {
                return ds;

            }
            else
            {
                return null;
            }
        }



        #region "Constructors"


        public ClientProjects(string ConnectionName)
        {
            //mObjectUserID = ObjectUserID;
            mConnectionName = ConnectionName;
            db = new DatabaseProviderFactory().Create(ConnectionName);

        }

        #endregion
        protected DataSet ReturnDs(string str)
        {
            try
            {
                DataSet ds = db.ExecuteDataSet(CommandType.Text, str);
                if (ds != null && ds.Tables.Count > 0 && ds.Tables[0].Rows.Count > 0)
                {
                    return ds;

                }
                else
                {
                    return null;
                }
            }
            catch (Exception ex)
            {
                mMsgFlg = ex.Message;
                return null;
            }
        }



        #region "Save"
        public virtual void GenerateSaveParameters(ref Database db, ref System.Data.Common.DbCommand cmd)
        {
            //db.AddInParameter(cmd, "@ID", DbType.Int64, mID);
            db.AddInParameter(cmd, "@ProjectId", DbType.Int64, mProjectId);
            db.AddInParameter(cmd, "@UserId", DbType.Int64, mUserId);
        }
        public virtual bool Save()
        {

            System.Data.Common.DbCommand cmd = db.GetStoredProcCommand("sp_Save_ClientProject");

            GenerateSaveParameters(ref db, ref cmd);


            try
            {
                DataSet ds = db.ExecuteDataSet(cmd);


                if (ds != null && ds.Tables.Count > 0 && ds.Tables[0].Rows.Count > 0)
                {
                    mID = Convert.ToInt32(ds.Tables[0].Rows[0][0].ToString().ToString());

                }

                return true;


            }
            catch (Exception ex)
            {
                mMsgFlg = ex.Message;
                return false;

            }

        }
        public void UpdateClient(int UserID, int RoleID, string FirstName, string LastName, string Mobile)
        {
            string constr = ConfigurationManager.ConnectionStrings["con"].ConnectionString;
            SqlConnection sqlCon = null;
            using (sqlCon = new SqlConnection(constr))
            {
                sqlCon.Open();
                SqlCommand sql_cmnd = new SqlCommand("Documents_Upd", sqlCon);
                sql_cmnd.CommandType = CommandType.StoredProcedure;
                sql_cmnd.Parameters.AddWithValue("@UserID ", SqlDbType.Int).Value = UserID;
                sql_cmnd.Parameters.AddWithValue("@ProjectId ", SqlDbType.Int).Value = RoleID;
                sql_cmnd.Parameters.AddWithValue("@Description", SqlDbType.NVarChar).Value = FirstName;
                sql_cmnd.Parameters.AddWithValue("@ContentType", SqlDbType.Int).Value = LastName;
                sql_cmnd.Parameters.AddWithValue("@Data", SqlDbType.NVarChar).Value = Mobile;
                sql_cmnd.ExecuteNonQuery();
                sqlCon.Close();
            }
        }



        #endregion

        protected void SetErrorDetails(string str)
        {
            mMsgFlg = str;
        }
        #endregion
    }
}