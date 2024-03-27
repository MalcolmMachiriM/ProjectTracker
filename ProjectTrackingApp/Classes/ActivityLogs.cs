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
    public class ActivityLogs
    {
        #region "Variables"

        protected DataSet mUserDetails;
        protected long mID;
        protected long mActivityId;
        protected string mActivityLog;
        protected Database db;
        protected string mConnectionName;

        protected string mMsgFlg;
        protected long mObjectUserID;
        #endregion

        #region "Properties"
        public DataSet UserDetails
        {
            get { return mUserDetails; }
            set { mUserDetails = value; }
        }
        public string MsgFlg
        {
            get { return mMsgFlg; }
            set { mMsgFlg = value; }
        }
        public long Id
        {
            get { return mID; }
            set { mID = value; }
        }
        public long ActivityId
        {
            get { return mActivityId; }
            set { mActivityId = value; }
        }
        
        public string ActivityLog
        {
            get { return mActivityLog; }
            set { mActivityLog = value; }
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
        #region "Constructors"


        public ActivityLogs(string ConnectionName)
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
        public DataSet getLogs(long ActivityId)
        {
            string str = "sp_getLogs";
            System.Data.Common.DbCommand cmd = db.GetStoredProcCommand(str);
            db.AddInParameter(cmd, "@ActivityId", DbType.Int64, ActivityId);

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

        #region "Save"
        public virtual void GenerateSaveParameters(ref Database db, ref System.Data.Common.DbCommand cmd)
        {
            db.AddInParameter(cmd, "@ActivityId", DbType.Int64, mActivityId);
            db.AddInParameter(cmd, "@ActivityLog", DbType.String, mActivityLog);
        }
        public virtual bool Save()
        {

            System.Data.Common.DbCommand cmd = db.GetStoredProcCommand("Log_Ins");

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
        public void RemoveLog(int ID, int ActivityId)
        {
            string constr = ConfigurationManager.ConnectionStrings["con"].ConnectionString;
            SqlConnection sqlCon = null;
            using (sqlCon = new SqlConnection(constr))
            {
                sqlCon.Open();
                SqlCommand sql_cmnd = new SqlCommand("sp_ActivityLogDel", sqlCon);
                sql_cmnd.CommandType = CommandType.StoredProcedure;
                sql_cmnd.Parameters.AddWithValue("@ID", SqlDbType.Int).Value = ID;
                sql_cmnd.Parameters.AddWithValue("@ActivityId", SqlDbType.Int).Value = ActivityId;
                sql_cmnd.ExecuteNonQuery();
                sqlCon.Close();
            }
        }
        #endregion
    }
}