using Microsoft.Practices.EnterpriseLibrary.Data;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Net.NetworkInformation;
using System.Web;
using System.Xml.Linq;

namespace ProjectTrackingApp.Classes
{
    public class ProjectTask
    {
        #region "Variables"
        public enum Statuses
        {
            Unassigned = 1, Pending = 2 , Complete = 3 , Failed = 4
        }
        protected DataSet mUserDetails;
        protected long mID;
        protected long mProjectId;
        protected string mMsgFlg;
        protected string mName;
        protected string mDescription;
        protected int mStatus;
        protected DateTime mStartDate;
        protected DateTime mEndDate;
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
        public int Status
        {
            get { return mStatus; }
            set { mStatus = value; }
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
        public DateTime StartDate
        {
            get { return mStartDate; }
            set { mStartDate = value; }
        }
        public DateTime EndDate
        {
            get { return mEndDate; }
            set { mEndDate = value; }
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
        public DataSet getAllTasks()
        {
            string str = "sp_getAllTasks";
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
            string str = "sp_getTask";
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


        public ProjectTask(string ConnectionName)
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
            db.AddInParameter(cmd, "@StartDate", DbType.Date, mStartDate);
            db.AddInParameter(cmd, "@EndDate", DbType.Date, mEndDate);
            db.AddInParameter(cmd, "@Status", DbType.Int32, mStatus);
        }
        public virtual bool Save()
        {

            System.Data.Common.DbCommand cmd = db.GetStoredProcCommand("Task_Ins");

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
        #endregion
    }

    public class TaskMembers
    {
        #region "Variables"
        
        protected DataSet mUserDetails;
        protected long mID;
        protected long mProjectId;
        protected string mMsgFlg;
        protected long mUserId;
        protected long mTaskId;
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
        public long TaskId
        {
            get { return mTaskId; }
            set { mTaskId = value; }
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
                SqlCommand sql_cmnd = new SqlCommand("sp_TaskTeamMemberDel", sqlCon);
                sql_cmnd.CommandType = CommandType.StoredProcedure;
                sql_cmnd.Parameters.AddWithValue("@ID", SqlDbType.Int).Value = ID;
                sql_cmnd.Parameters.AddWithValue("@TaskId", SqlDbType.Int).Value = TaskId;
                sql_cmnd.ExecuteNonQuery();
                sqlCon.Close();
            }
        }
        public DataSet getAllMembers()
        {
            string str = "sp_getTaskMembers";
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
            string str = "sp_getTask";
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


        public TaskMembers(string ConnectionName)
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
            db.AddInParameter(cmd, "@TaskId", DbType.Int64, mTaskId);
            db.AddInParameter(cmd, "@UserId", DbType.Int64, mUserId);
        }
        public virtual bool Save()
        {

            System.Data.Common.DbCommand cmd = db.GetStoredProcCommand("sp_Save_Task_Members");

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
                SqlCommand sql_cmnd = new SqlCommand("Users_Upd", sqlCon);
                sql_cmnd.CommandType = CommandType.StoredProcedure;
                sql_cmnd.Parameters.AddWithValue("@UserID ", SqlDbType.Int).Value = UserID;
                sql_cmnd.Parameters.AddWithValue("@RoleID ", SqlDbType.Int).Value = RoleID;
                sql_cmnd.Parameters.AddWithValue("@FirstName", SqlDbType.NVarChar).Value = FirstName;
                sql_cmnd.Parameters.AddWithValue("@LastName", SqlDbType.Int).Value = LastName;
                sql_cmnd.Parameters.AddWithValue("@Mobile", SqlDbType.NVarChar).Value = Mobile;
                sql_cmnd.ExecuteNonQuery();
                sqlCon.Close();
            }
        }
       
        public bool CheckEmailExists(string Email)
        {
            try
            {
                string str = "sp_getUsers";
                System.Data.Common.DbCommand cmd = db.GetStoredProcCommand(str);
                db.AddInParameter(cmd, "@Email", DbType.String, Email);

                DataSet ds = db.ExecuteDataSet(cmd);
                if (ds != null && ds.Tables.Count > 0 && ds.Tables[0].Rows.Count > 0)
                {
                    return true;

                }
                else
                {
                    return false;
                }
            }
            catch (Exception ex)
            {
                mMsgFlg = ex.Message;
                return false;
            }
        }
        
        public DataSet getUserByUserID(int UserID)
        {

            string str = "sp_getUserByUserID";
            System.Data.Common.DbCommand cmd = db.GetStoredProcCommand(str);
            db.AddInParameter(cmd, "@UserID", DbType.Int32, UserID);
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



        #endregion

        protected void SetErrorDetails(string str)
        {
            mMsgFlg = str;
        }
        #endregion
    }
}