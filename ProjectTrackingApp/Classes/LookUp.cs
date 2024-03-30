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
    public class LookUp
    {
        #region "Variables"

        protected DataSet mUserDetails;
        protected long mID;
        protected string mMsgFlg;
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

        public DataSet GetFilePath(int id)
        {
            string str = "Select FilePath from EmailAttachments where BroadcastMessagesListID=" + id + ";";
            return ReturnDs(str);
        }


        #region "Constructors"


        public LookUp(string ConnectionName)
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

        public void SaveAcademicRecords(int UserID, string SchoolName, int SchoolLevel, string StartDateMonth, string StartDateYear, string EndDateMonth, string EndDateYear,
            int SubjectsPassedNo, int ExaminationBody, string Activities)
        {
            string constr = ConfigurationManager.ConnectionStrings["con"].ConnectionString;
            SqlConnection sqlCon = null;
            using (sqlCon = new SqlConnection(constr))
            {
                sqlCon.Open();
                SqlCommand sql_cmnd = new SqlCommand("AcademicHistory_Ins", sqlCon);
                sql_cmnd.CommandType = CommandType.StoredProcedure;
                sql_cmnd.Parameters.AddWithValue("@UserID", SqlDbType.Int).Value = UserID;
                sql_cmnd.Parameters.AddWithValue("@SchoolName", SqlDbType.NVarChar).Value = SchoolName;
                sql_cmnd.Parameters.AddWithValue("@SchoolLevel", SqlDbType.Int).Value = SchoolLevel;
                sql_cmnd.Parameters.AddWithValue("@StartDateMonth", SqlDbType.NVarChar).Value = StartDateMonth;
                sql_cmnd.Parameters.AddWithValue("@StartDateYear", SqlDbType.NVarChar).Value = StartDateYear;
                sql_cmnd.Parameters.AddWithValue("@EndDateMonth", SqlDbType.NVarChar).Value = EndDateMonth;
                sql_cmnd.Parameters.AddWithValue("@EndDateYear", SqlDbType.DateTime).Value = EndDateYear;
                sql_cmnd.Parameters.AddWithValue("@SubjectsPassedNo", SqlDbType.Int).Value = SubjectsPassedNo;
                sql_cmnd.Parameters.AddWithValue("@ExaminationBody", SqlDbType.Int).Value = ExaminationBody;
                sql_cmnd.Parameters.AddWithValue("@Activities", SqlDbType.NVarChar).Value = Activities;
                sql_cmnd.ExecuteNonQuery();
                sqlCon.Close();
            }
        }
        //public DataSet getSearchColleges(int Criteria,string Value)
        //{

        //    DataSet ds = null;

        //    string str = "sp_SearchCollege";
        //    System.Data.Common.DbCommand cmd = db.GetStoredProcCommand(str);
        //    db.AddInParameter(cmd, "@Criteria", DbType.Int32, Criteria);
        //    db.AddInParameter(cmd, "@Value", DbType.String, Value);
        //    ds = db.ExecuteDataSet(cmd);



        //    if (ds != null && ds.Tables.Count > 0 && ds.Tables[0].Rows.Count > 0)
        //    {
        //        return ds;

        //    }
        //    else
        //    {
        //        return null;
        //    }


        //}

        public DataSet getStats()
        {
            string str = "sp_getDashStats";
            System.Data.Common.DbCommand cmd = db.GetStoredProcCommand(str);
            //db.AddInParameter(cmd, "@Criteria", DbType.Int32, Criteria);
            //db.AddInParameter(cmd, "@RoleID", DbType.Int32, RoleID);
            //db.AddInParameter(cmd, "@Value", DbType.String, Value);
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
        public DataSet getSearchUsers(int Criteria, int RoleID, string Value)
        {
            string str = "sp_SearchUsers";
            System.Data.Common.DbCommand cmd = db.GetStoredProcCommand(str);
            db.AddInParameter(cmd, "@Criteria", DbType.Int32, Criteria);
            db.AddInParameter(cmd, "@RoleID", DbType.Int32, RoleID);
            db.AddInParameter(cmd, "@Value", DbType.String, Value);
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
        public DataSet getStatus()
        {
            string str = "sp_getStatus";
            System.Data.Common.DbCommand cmd = db.GetStoredProcCommand(str);
            //db.AddInParameter(cmd, "@Criteria", DbType.Int32, Criteria);
            //db.AddInParameter(cmd, "@RoleID", DbType.Int32, RoleID);
            //db.AddInParameter(cmd, "@Value", DbType.String, Value);
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
        public DataSet SearchProgramByCollege(int CollegeID, string Value)
        {
            string str = "sp_SearchProgramByCollege";
            System.Data.Common.DbCommand cmd = db.GetStoredProcCommand(str);
            db.AddInParameter(cmd, "@ProgramName", DbType.String, Value);
            db.AddInParameter(cmd, "@UserID", DbType.Int32, CollegeID);
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
        public DataSet SearchProgram(string Value)
        {
            string str = "sp_SearchProgram";
            System.Data.Common.DbCommand cmd = db.GetStoredProcCommand(str);
            db.AddInParameter(cmd, "@ProgramName", DbType.String, Value);
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


        public DataSet getSearchPayments(int Criteria, int RoleID, string Value)
        {

            DataSet ds = null;

            string str = "sp_SearchUsers";
            System.Data.Common.DbCommand cmd = db.GetStoredProcCommand(str);
            db.AddInParameter(cmd, "@Criteria", DbType.Int32, Criteria);
            db.AddInParameter(cmd, "@RoleID", DbType.Int32, RoleID);
            db.AddInParameter(cmd, "@Value", DbType.String, Value);
            ds = db.ExecuteDataSet(cmd);



            if (ds != null && ds.Tables.Count > 0 && ds.Tables[0].Rows.Count > 0)
            {
                return ds;

            }
            else
            {
                return null;
            }


        }

        public bool IsProgramApplied(int ApplicantID, int CollegeID, int PeriodID, int ProgramID)
        {
            try
            {
                string str = "sp_ValidateApplications";
                System.Data.Common.DbCommand cmd = db.GetStoredProcCommand(str);

                db.AddInParameter(cmd, "@ApplicantID", DbType.Int32, ApplicantID);
                db.AddInParameter(cmd, "@CollegeID", DbType.Int32, CollegeID);
                db.AddInParameter(cmd, "@PeriodID", DbType.Int32, PeriodID);
                db.AddInParameter(cmd, "@ProgramID", DbType.Int32, ProgramID);

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
        
        public void SaveEmailList(DateTime DateSent, string EmailAddress, string Subject, string Target, int StatusID, string Message)
        {
            string constr = ConfigurationManager.ConnectionStrings["con"].ConnectionString;
            SqlConnection sqlCon = null;
            using (sqlCon = new SqlConnection(constr))
            {
                sqlCon.Open();
                SqlCommand sql_cmnd = new SqlCommand("SaveBroadCastMessage_Ins", sqlCon);
                sql_cmnd.CommandType = CommandType.StoredProcedure;
                sql_cmnd.Parameters.AddWithValue("@DateSent", SqlDbType.Date).Value = DateSent;
                sql_cmnd.Parameters.AddWithValue("@EmailAddress", SqlDbType.NVarChar).Value = EmailAddress;
                sql_cmnd.Parameters.AddWithValue("@Subject", SqlDbType.NVarChar).Value = Subject;
                sql_cmnd.Parameters.AddWithValue("@Target", SqlDbType.NVarChar).Value = Target;
                sql_cmnd.Parameters.AddWithValue("@StatusID", SqlDbType.Int).Value = StatusID;
                sql_cmnd.Parameters.AddWithValue("@Message", SqlDbType.Int).Value = Message;
                sql_cmnd.ExecuteNonQuery();
                sqlCon.Close();
            }
        }
        public void SaveSmsList(int ID, int StatusID)
        {
            string constr = ConfigurationManager.ConnectionStrings["con"].ConnectionString;
            SqlConnection sqlCon = null;
            using (sqlCon = new SqlConnection(constr))
            {
                sqlCon.Open();
                SqlCommand sql_cmnd = new SqlCommand("SaveBroadCastSms_Upd", sqlCon);
                sql_cmnd.CommandType = CommandType.StoredProcedure;
                sql_cmnd.Parameters.AddWithValue("@ID", SqlDbType.Int).Value = ID;
                sql_cmnd.Parameters.AddWithValue("@StatusID", SqlDbType.Int).Value = StatusID;
                sql_cmnd.ExecuteNonQuery();
                sqlCon.Close();
            }
        }

        public void SaveProject(int ID,string ProjectName,string Location,DateTime StartDate,DateTime EndDate
            ,int StatusID,int TypeID, double Budget,int CurrencyID, string ClientName, string ClientMobile
            ,int ProjectManagerID, int AddedBy, long ProjectCategory)
        {
            string constr = ConfigurationManager.ConnectionStrings["con"].ConnectionString;
            SqlConnection sqlCon = null;
            using (sqlCon = new SqlConnection(constr))
            {
                sqlCon.Open();
                SqlCommand sql_cmnd = new SqlCommand("Project_Ins", sqlCon);
                sql_cmnd.CommandType = CommandType.StoredProcedure;
                sql_cmnd.Parameters.AddWithValue("@ID", SqlDbType.Int).Value = ID;
                sql_cmnd.Parameters.AddWithValue("@ProjectName", SqlDbType.NVarChar).Value = ProjectName;
                sql_cmnd.Parameters.AddWithValue("@ProjectCategory", SqlDbType.Int).Value = ProjectCategory;
                sql_cmnd.Parameters.AddWithValue("@ProjectLocation", SqlDbType.NVarChar).Value = Location;
                sql_cmnd.Parameters.AddWithValue("@StartDate", SqlDbType.Date).Value = StartDate;
                sql_cmnd.Parameters.AddWithValue("@EndDate", SqlDbType.Date).Value = EndDate;
                sql_cmnd.Parameters.AddWithValue("@ProjectStatusID", SqlDbType.Int).Value = StatusID;
                sql_cmnd.Parameters.AddWithValue("@ProjectTypeID", SqlDbType.Int).Value = TypeID;
                sql_cmnd.Parameters.AddWithValue("@Budegt", SqlDbType.Float).Value = Budget;
                sql_cmnd.Parameters.AddWithValue("@CurrencyID", SqlDbType.Int).Value = CurrencyID;
                sql_cmnd.Parameters.AddWithValue("@ClientName", SqlDbType.NVarChar).Value = ClientName;
                sql_cmnd.Parameters.AddWithValue("@ClientMobile", SqlDbType.NVarChar).Value = ClientMobile;
                sql_cmnd.Parameters.AddWithValue("@ProjectManagerID", SqlDbType.Int).Value = ProjectManagerID;
                sql_cmnd.Parameters.AddWithValue("@AddedBy", SqlDbType.Int).Value = AddedBy;
                sql_cmnd.ExecuteNonQuery();
                sqlCon.Close();
            }
        }
        public void SaveTeamMember(int ProjectID, int TeamMemberID ,int AddedBy)
        {
            string constr = ConfigurationManager.ConnectionStrings["con"].ConnectionString;
            SqlConnection sqlCon = null;
            using (sqlCon = new SqlConnection(constr))
            {
                sqlCon.Open();
                SqlCommand sql_cmnd = new SqlCommand("ProjectTeamMember_Ins", sqlCon);
                sql_cmnd.CommandType = CommandType.StoredProcedure;
                sql_cmnd.Parameters.AddWithValue("@ProjectID", SqlDbType.Int).Value = ProjectID;
                sql_cmnd.Parameters.AddWithValue("@TeamMemberID", SqlDbType.Int).Value = TeamMemberID;
                sql_cmnd.Parameters.AddWithValue("@AddedBy", SqlDbType.Int).Value = AddedBy;
                sql_cmnd.ExecuteNonQuery();
                sqlCon.Close();
            }
        }

        public void SaveEmailSettings(int UserID, string Email, string Password, string Host, int Port)
        {
            string constr = ConfigurationManager.ConnectionStrings["con"].ConnectionString;
            SqlConnection sqlCon = null;
            using (sqlCon = new SqlConnection(constr))
            {
                sqlCon.Open();
                SqlCommand sql_cmnd = new SqlCommand("SaveEmail_Ins", sqlCon);
                sql_cmnd.CommandType = CommandType.StoredProcedure;
                sql_cmnd.Parameters.AddWithValue("@UserID", SqlDbType.Int).Value = UserID;
                sql_cmnd.Parameters.AddWithValue("@Email", SqlDbType.NVarChar).Value = Email;
                sql_cmnd.Parameters.AddWithValue("@Password", SqlDbType.NVarChar).Value = Password;
                sql_cmnd.Parameters.AddWithValue("@Host", SqlDbType.NVarChar).Value = Host;
                sql_cmnd.Parameters.AddWithValue("@Port", SqlDbType.Int).Value = Port;
                sql_cmnd.ExecuteNonQuery();
                sqlCon.Close();
            }
        }
        public void SaveSmsSettings(int UserID, string SenderName, string Password, string SenderNumber)
        {
            string constr = ConfigurationManager.ConnectionStrings["con"].ConnectionString;
            SqlConnection sqlCon = null;
            using (sqlCon = new SqlConnection(constr))
            {
                sqlCon.Open();
                SqlCommand sql_cmnd = new SqlCommand("SaveSms_Ins", sqlCon);
                sql_cmnd.CommandType = CommandType.StoredProcedure;
                sql_cmnd.Parameters.AddWithValue("@UserID", SqlDbType.Int).Value = UserID;
                sql_cmnd.Parameters.AddWithValue("@SenderName", SqlDbType.NVarChar).Value = SenderName;
                sql_cmnd.Parameters.AddWithValue("@Password", SqlDbType.NVarChar).Value = Password;
                sql_cmnd.Parameters.AddWithValue("@SenderNumber", SqlDbType.NVarChar).Value = SenderNumber;

                sql_cmnd.ExecuteNonQuery();
                sqlCon.Close();
            }
        }

        public bool SaveClientImage(long UserID, Byte[] bytes)
        {
            try
            {

                string constr = ConfigurationManager.ConnectionStrings["con"].ConnectionString;
                SqlConnection sqlCon = null;
                using (sqlCon = new SqlConnection(constr))
                {
                    sqlCon.Open();
                    SqlCommand sql_cmnd = new SqlCommand("sp_SaveInage", sqlCon);
                    sql_cmnd.CommandType = CommandType.StoredProcedure;
                    sql_cmnd.Parameters.AddWithValue("@UserID", SqlDbType.Int).Value = UserID;
                    sql_cmnd.Parameters.AddWithValue("@Image", SqlDbType.VarBinary).Value = bytes;
                    sql_cmnd.ExecuteNonQuery();
                    sqlCon.Close();
                }

                return true;
            }
            catch (Exception ex)
            {
                mMsgFlg = ex.Message;
                return false;
            }
        }
        public void DeleteUploadedDocument(int ID)
        {

            string str = "sp_DeleteUploadedDocument";
            System.Data.Common.DbCommand cmd = db.GetStoredProcCommand(str);
            db.AddInParameter(cmd, "@ID", DbType.Int32, ID);

            DataSet ds = db.ExecuteDataSet(cmd);

        }
        public void RemoveAcademicHistory(int ID)
        {
            string constr = ConfigurationManager.ConnectionStrings["con"].ConnectionString;
            SqlConnection sqlCon = null;
            using (sqlCon = new SqlConnection(constr))
            {
                sqlCon.Open();
                SqlCommand sql_cmnd = new SqlCommand("AcademicHistory_Del", sqlCon);
                sql_cmnd.CommandType = CommandType.StoredProcedure;
                sql_cmnd.Parameters.AddWithValue("@ID", SqlDbType.Int).Value = ID;
                sql_cmnd.ExecuteNonQuery();
                sqlCon.Close();
            }
        }
        public void RemoveAcademicCalendar(int ID)
        {
            string constr = ConfigurationManager.ConnectionStrings["con"].ConnectionString;
            SqlConnection sqlCon = null;
            using (sqlCon = new SqlConnection(constr))
            {
                sqlCon.Open();
                SqlCommand sql_cmnd = new SqlCommand("AcademicCalendar_Del", sqlCon);
                sql_cmnd.CommandType = CommandType.StoredProcedure;
                sql_cmnd.Parameters.AddWithValue("@ID", SqlDbType.Int).Value = ID;
                sql_cmnd.ExecuteNonQuery();
                sqlCon.Close();
            }
        }
        public void RemoveFaculty(int ID)
        {
            string constr = ConfigurationManager.ConnectionStrings["con"].ConnectionString;
            SqlConnection sqlCon = null;
            using (sqlCon = new SqlConnection(constr))
            {
                sqlCon.Open();
                SqlCommand sql_cmnd = new SqlCommand("Faculty_Del", sqlCon);
                sql_cmnd.CommandType = CommandType.StoredProcedure;
                sql_cmnd.Parameters.AddWithValue("@ID", SqlDbType.Int).Value = ID;
                sql_cmnd.ExecuteNonQuery();
                sqlCon.Close();
            }
        }
        public void RemoveProgram(int ID)
        {
            string constr = ConfigurationManager.ConnectionStrings["con"].ConnectionString;
            SqlConnection sqlCon = null;
            using (sqlCon = new SqlConnection(constr))
            {
                sqlCon.Open();
                SqlCommand sql_cmnd = new SqlCommand("Program_Del", sqlCon);
                sql_cmnd.CommandType = CommandType.StoredProcedure;
                sql_cmnd.Parameters.AddWithValue("@ID", SqlDbType.Int).Value = ID;

                sql_cmnd.ExecuteNonQuery();
                sqlCon.Close();
            }
        }
        public void ApproveApplication(int ApplicationID)
        {
            string constr = ConfigurationManager.ConnectionStrings["con"].ConnectionString;
            SqlConnection sqlCon = null;
            using (sqlCon = new SqlConnection(constr))
            {
                sqlCon.Open();
                SqlCommand sql_cmnd = new SqlCommand("sp_ApproveApplication", sqlCon);
                sql_cmnd.CommandType = CommandType.StoredProcedure;
                sql_cmnd.Parameters.AddWithValue("@ApplicationID", SqlDbType.Int).Value = ApplicationID;

                sql_cmnd.ExecuteNonQuery();
                sqlCon.Close();
            }
        }
        public void ApproveAgentCommision(int ID)
        {
            string constr = ConfigurationManager.ConnectionStrings["con"].ConnectionString;
            SqlConnection sqlCon = null;
            using (sqlCon = new SqlConnection(constr))
            {
                sqlCon.Open();
                SqlCommand sql_cmnd = new SqlCommand("sp_ApproveAgentCommission", sqlCon);
                sql_cmnd.CommandType = CommandType.StoredProcedure;
                sql_cmnd.Parameters.AddWithValue("@ID", SqlDbType.Int).Value = ID;

                sql_cmnd.ExecuteNonQuery();
                sqlCon.Close();
            }
        }
        public void DeleteUser(int ID)
        {
            string constr = ConfigurationManager.ConnectionStrings["con"].ConnectionString;
            SqlConnection sqlCon = null;
            using (sqlCon = new SqlConnection(constr))
            {
                sqlCon.Open();
                SqlCommand sql_cmnd = new SqlCommand("sp_UserDel", sqlCon);
                sql_cmnd.CommandType = CommandType.StoredProcedure;
                sql_cmnd.Parameters.AddWithValue("@ID", SqlDbType.Int).Value = ID;

                sql_cmnd.ExecuteNonQuery();
                sqlCon.Close();
            }
        }
        public void DeleteProject(int ID)
        {
            string constr = ConfigurationManager.ConnectionStrings["con"].ConnectionString;
            SqlConnection sqlCon = null;
            using (sqlCon = new SqlConnection(constr))
            {
                sqlCon.Open();
                SqlCommand sql_cmnd = new SqlCommand("sp_ProjectDel", sqlCon);
                sql_cmnd.CommandType = CommandType.StoredProcedure;
                sql_cmnd.Parameters.AddWithValue("@ID", SqlDbType.Int).Value = ID;

                sql_cmnd.ExecuteNonQuery();
                sqlCon.Close();
            }
        }
        public void RemoveMemberFromProject(int ID,int PojectID)
        {
            string constr = ConfigurationManager.ConnectionStrings["con"].ConnectionString;
            SqlConnection sqlCon = null;
            using (sqlCon = new SqlConnection(constr))
            {
                sqlCon.Open();
                SqlCommand sql_cmnd = new SqlCommand("sp_ProjectTeamMemberDel", sqlCon);
                sql_cmnd.CommandType = CommandType.StoredProcedure;
                sql_cmnd.Parameters.AddWithValue("@ID", SqlDbType.Int).Value = ID;
                sql_cmnd.Parameters.AddWithValue("@ProjectID", SqlDbType.Int).Value = PojectID;
                sql_cmnd.ExecuteNonQuery();
                sqlCon.Close();
            }
        }
        public void SuspendUser(int ID)
        {
            string constr = ConfigurationManager.ConnectionStrings["con"].ConnectionString;
            SqlConnection sqlCon = null;
            using (sqlCon = new SqlConnection(constr))
            {
                sqlCon.Open();
                SqlCommand sql_cmnd = new SqlCommand("sp_UserSuspend", sqlCon);
                sql_cmnd.CommandType = CommandType.StoredProcedure;
                sql_cmnd.Parameters.AddWithValue("@ID", SqlDbType.Int).Value = ID;

                sql_cmnd.ExecuteNonQuery();
                sqlCon.Close();
            }
        }
        public void ActivateUser(int ID)
        {
            string constr = ConfigurationManager.ConnectionStrings["con"].ConnectionString;
            SqlConnection sqlCon = null;
            using (sqlCon = new SqlConnection(constr))
            {
                sqlCon.Open();
                SqlCommand sql_cmnd = new SqlCommand("sp_UserActivate", sqlCon);
                sql_cmnd.CommandType = CommandType.StoredProcedure;
                sql_cmnd.Parameters.AddWithValue("@ID", SqlDbType.Int).Value = ID;

                sql_cmnd.ExecuteNonQuery();
                sqlCon.Close();
            }
        }
        public void RejectApplication(int ApplicationID)
        {
            string constr = ConfigurationManager.ConnectionStrings["con"].ConnectionString;
            SqlConnection sqlCon = null;
            using (sqlCon = new SqlConnection(constr))
            {
                sqlCon.Open();
                SqlCommand sql_cmnd = new SqlCommand("sp_RejectApplication", sqlCon);
                sql_cmnd.CommandType = CommandType.StoredProcedure;
                sql_cmnd.Parameters.AddWithValue("@ApplicationID", SqlDbType.Int).Value = ApplicationID;

                sql_cmnd.ExecuteNonQuery();
                sqlCon.Close();
            }
        }
        public DataSet getSavedEmailSettings(int UserID)
        {
            string str = "sp_getEmailSettings";
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

        public DataSet getApplicationStatus()
        {
            string str = "sp_getApplicationStatus";
            System.Data.Common.DbCommand cmd = db.GetStoredProcCommand(str);
            //db.AddInParameter(cmd, "@UserID", DbType.Int32, UserID);

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


        public DataSet getSavedSmsSettings(int UserID)
        {
            string str = "sp_getSmsSettings";
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

        public DataSet getCertificateFileUploads(int UserID)
        {

            string str = "sp_getCertificateFileUploads";
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
      
 
        public DataSet getFaculty(int UserID)
        {

            string str = "sp_getFaculty";
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

        public bool IsVerificationCodeExists(int Code)
        {
            try
            {
                string str = "sp_IsVerificationCodeExists";
                System.Data.Common.DbCommand cmd = db.GetStoredProcCommand(str);
                db.AddInParameter(cmd, "@Code", DbType.Int32, Code);
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
        public string getUserByCode(int Code)
        {

            try
            {
                string str = "sp_getUserByCode";
                System.Data.Common.DbCommand cmd = db.GetStoredProcCommand(str);
                db.AddInParameter(cmd, "@code", DbType.Int32, Code);
                DataSet ds = db.ExecuteDataSet(cmd);
                if (ds != null && ds.Tables.Count > 0 && ds.Tables[0].Rows.Count > 0)
                {
                    return ds.Tables[0].Rows[0][0].ToString();
                }
                else
                {
                    return "0";
                }
            }
            catch (Exception ex)
            {
                mMsgFlg = ex.Message;
                return "0";
            }
        }


        public DataSet getAllUsers()
        {
            string str = "sp_getAllUsers";
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
        public DataSet getAllClients()
        {
            string str = "sp_getClients";
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
        public DataSet getAllProjects()
        {
            string str = "sp_getAllProjects";
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
        public DataSet getAllProjects(long UserId)
        {
            string str = "sp_getPMProjects";
            System.Data.Common.DbCommand cmd = db.GetStoredProcCommand(str);
            db.AddInParameter(cmd, "@ProjectManagerId", DbType.Int32, UserId);

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
        public DataSet getProjectMembers(int ProjectID)
        {
            string str = "sp_getProjectMembers";
            System.Data.Common.DbCommand cmd = db.GetStoredProcCommand(str);
            db.AddInParameter(cmd, "@ProjectID", DbType.Int32, ProjectID);

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
        public DataSet getUsersByUserID(int UserID)
        {
            string str = "sp_getUsersByUserID";
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

        public DataSet getProjectByID(int ID)
        {
            string str = "sp_getProjectByID";
            System.Data.Common.DbCommand cmd = db.GetStoredProcCommand(str);
            db.AddInParameter(cmd, "@ID", DbType.Int32, ID);

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




        public DataSet getDocumentTypes()
        {

            string str = "sp_getDocumentType";
            System.Data.Common.DbCommand cmd = db.GetStoredProcCommand(str);
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
       
       
        public DataSet getProjectStatus()
        {

            string str = "sp_getProjectStatus";
            System.Data.Common.DbCommand cmd = db.GetStoredProcCommand(str);
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
        public DataSet getProjectType()
        {

            string str = "sp_getProjectType";
            System.Data.Common.DbCommand cmd = db.GetStoredProcCommand(str);
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
        public DataSet getCurrency()
        {

            string str = "sp_getCurrency";
            System.Data.Common.DbCommand cmd = db.GetStoredProcCommand(str);
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
        public DataSet getProjectManagers()
        {

            string str = "sp_getProjectManagers";
            System.Data.Common.DbCommand cmd = db.GetStoredProcCommand(str);
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
        public DataSet getTeamMembers()
        {

            string str = "sp_getTeamMembers";
            System.Data.Common.DbCommand cmd = db.GetStoredProcCommand(str);
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
        public DataSet getClients()
        {

            string str = "sp_getClientType";
            System.Data.Common.DbCommand cmd = db.GetStoredProcCommand(str);
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
        public DataSet getRoles()
        {

            string str = "sp_getRoles";
            System.Data.Common.DbCommand cmd = db.GetStoredProcCommand(str);
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

        public static class RandomGenerator
        {
            private static readonly Random random = new Random();

            public static int GenerateRandom6DigitNumber()
            {
                return random.Next(100000, 999999);
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