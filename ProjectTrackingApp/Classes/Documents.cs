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
    public class Documents
    {
        #region "Variables"

        protected DataSet mUserDetails;
        protected long mID;
        protected long mProjectId;
        protected string mMsgFlg;
        protected string mFileName;
        protected long mUserId;
        protected string mDescription;
        protected byte[] mData;
        protected string mContentType;
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
        public string Description
        {
            get { return mDescription; }
            set { mDescription = value; }
        }
        public string ContentType
        {
            get { return mContentType; }
            set { mContentType = value; }
        }
        public string FileName
        {
            get { return mFileName; }
            set { mFileName = value; }
        }
        public byte[] Data
        {
            get { return mData; }
            set { mData = value; }
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
        public void RemoveMemberFromTask(int ID, int TaskId)
        {
            string constr = ConfigurationManager.ConnectionStrings["con"].ConnectionString;
            SqlConnection sqlCon = null;
            using (sqlCon = new SqlConnection(constr))
            {
                sqlCon.Open();
                SqlCommand sql_cmnd = new SqlCommand("sp_DocumentDel", sqlCon);
                sql_cmnd.CommandType = CommandType.StoredProcedure;
                sql_cmnd.Parameters.AddWithValue("@ID", SqlDbType.Int).Value = ID;
                sql_cmnd.Parameters.AddWithValue("@TaskId", SqlDbType.Int).Value = TaskId;
                sql_cmnd.ExecuteNonQuery();
                sqlCon.Close();
            }
        }
        public DataSet getAllDocuments()
        {
            string str = "sp_getDocuments";
            System.Data.Common.DbCommand cmd = db.GetStoredProcCommand(str);
            //db.AddInParameter(cmd, "@AgentID", DbType.Int32, AgentID);

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
            string str = "sp_getDocument";
            System.Data.Common.DbCommand cmd = db.GetStoredProcCommand(str);
            db.AddInParameter(cmd, "@ID", DbType.Int32, TaskId);

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


        public Documents(string ConnectionName)
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
            db.AddInParameter(cmd, "@ID", DbType.Int64, mID);
            db.AddInParameter(cmd, "@ProjectId", DbType.Int64, mProjectId);
            db.AddInParameter(cmd, "@Description", DbType.String, mDescription);
            db.AddInParameter(cmd, "@UserId", DbType.Int64, mUserId);
            db.AddInParameter(cmd, "@ContentType", DbType.String, mContentType);
            db.AddInParameter(cmd, "@FileName", DbType.String, mFileName);
            db.AddInParameter(cmd, "@Data", DbType.Binary, mData);
        }
        public virtual bool Save()
        {

            System.Data.Common.DbCommand cmd = db.GetStoredProcCommand("sp_Save_Document");

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

        internal void DeleteProject(long index)
        {
            string constr = ConfigurationManager.ConnectionStrings["con"].ConnectionString;
            SqlConnection sqlCon = null;
            using (sqlCon = new SqlConnection(constr))
            {
                sqlCon.Open();
                SqlCommand sql_cmnd = new SqlCommand("sp_DocDelete", sqlCon);
                sql_cmnd.CommandType = CommandType.StoredProcedure;
                sql_cmnd.Parameters.AddWithValue("@ID", SqlDbType.Int).Value = Id;

                sql_cmnd.ExecuteNonQuery();
                sqlCon.Close();
            };
        }
        #endregion
    }
}