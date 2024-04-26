using Microsoft.Practices.EnterpriseLibrary.Data;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace ProjectTrackingApp.Classes
{
    public class Resources
    {
        #region "Variables"
        protected DataSet mUserDetails;
        protected long mID;
        protected long mProjectId;
        protected string mMsgFlg;
        protected string mName;
        protected string mDescription;
        protected string mCount;
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
        public string Name
        {
            get { return mName; }
            set { mName = value; }
        }
        public string Description
        {
            get { return mDescription; }
            set { mDescription = value; }
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
        public DataSet getResources(long TeamMemberId)
        {
            string str = "sp_getMemberResources";
            System.Data.Common.DbCommand cmd = db.GetStoredProcCommand(str);
            db.AddInParameter(cmd, "@UserId", DbType.Int32, TeamMemberId);

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
        public DataSet getAllResources()
        {
            string str = "sp_getAllResources";
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
        public DataSet getProjectResources()
        {
            string str = "sp_getProjectResources";
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
        public DataSet getResource(long ResourceId)
        {
            string str = "sp_getResource";
            System.Data.Common.DbCommand cmd = db.GetStoredProcCommand(str);
            db.AddInParameter(cmd, "@ID", DbType.Int32, ResourceId);

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


        public Resources(string ConnectionName)
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
            db.AddInParameter(cmd, "@Name", DbType.String, mName);
            db.AddInParameter(cmd, "@Description", DbType.String, mDescription);
        }
        public virtual bool Save()
        {

            System.Data.Common.DbCommand cmd = db.GetStoredProcCommand("Resource_Ins");

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

        #endregion

        protected void SetErrorDetails(string str)
        {
            mMsgFlg = str;
        }

        internal void DeleteResource(int index)
        {
            string constr = ConfigurationManager.ConnectionStrings["con"].ConnectionString;
            SqlConnection sqlCon = null;
            using (sqlCon = new SqlConnection(constr))
            {
                sqlCon.Open();
                SqlCommand sql_cmnd = new SqlCommand("sp_ResourceDelete", sqlCon);
                sql_cmnd.CommandType = CommandType.StoredProcedure;
                sql_cmnd.Parameters.AddWithValue("@ID", SqlDbType.Int).Value = Id;

                sql_cmnd.ExecuteNonQuery();
                sqlCon.Close();
            };
        }
        #endregion
    }
    public class ResourceMembers
    {
        #region "Variables"
        protected DataSet mUserDetails;
        protected long mID;
        protected long mResourceId;
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
        
        public long ResourceId
        {
            get { return mResourceId; }
            set { mResourceId = value; }
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
        public DataSet getResources(long TeamMemberId)
        {
            string str = "sp_getMemberResources";
            System.Data.Common.DbCommand cmd = db.GetStoredProcCommand(str);
            db.AddInParameter(cmd, "@UserId", DbType.Int32, TeamMemberId);

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
        public DataSet getAllResources()
        {
            string str = "sp_getAllResources";
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
        public DataSet getProjectResources()
        {
            string str = "sp_getProjectResources";
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
        public DataSet getResource(long ResourceId)
        {
            string str = "sp_getResource";
            System.Data.Common.DbCommand cmd = db.GetStoredProcCommand(str);
            db.AddInParameter(cmd, "@ID", DbType.Int32, ResourceId);

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


        public ResourceMembers(string ConnectionName)
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
            db.AddInParameter(cmd, "@ResourceId", DbType.Int64, mResourceId);
            db.AddInParameter(cmd, "@UserId", DbType.String, mUserId);
        }
        public virtual bool Save()
        {

            System.Data.Common.DbCommand cmd = db.GetStoredProcCommand("ResourceMembers_Ins");

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

        #endregion

        protected void SetErrorDetails(string str)
        {
            mMsgFlg = str;
        }

        internal void DeleteResource(int index)
        {
            string constr = ConfigurationManager.ConnectionStrings["con"].ConnectionString;
            SqlConnection sqlCon = null;
            using (sqlCon = new SqlConnection(constr))
            {
                sqlCon.Open();
                SqlCommand sql_cmnd = new SqlCommand("sp_ResourceDelete", sqlCon);
                sql_cmnd.CommandType = CommandType.StoredProcedure;
                sql_cmnd.Parameters.AddWithValue("@ID", SqlDbType.Int).Value = Id;

                sql_cmnd.ExecuteNonQuery();
                sqlCon.Close();
            };
        }
        #endregion
    }
}