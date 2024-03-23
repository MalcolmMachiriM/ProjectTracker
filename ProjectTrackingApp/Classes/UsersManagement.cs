﻿using Microsoft.Practices.EnterpriseLibrary.Data;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Web;

namespace ProjectTrackingApp.Classes
{
    public class UsersManagement
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




        #region "Constructors"


        public UsersManagement(string ConnectionName)
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
        public void SaveClient(int RoleID,string FirstName,string LastName,string Email,string Mobile,string Password)
        {
            string constr = ConfigurationManager.ConnectionStrings["con"].ConnectionString;
            SqlConnection sqlCon = null;
            using (sqlCon = new SqlConnection(constr))
            { 
                sqlCon.Open();
                SqlCommand sql_cmnd = new SqlCommand("Users_Ins", sqlCon);
                sql_cmnd.CommandType = CommandType.StoredProcedure;
                sql_cmnd.Parameters.AddWithValue("@RoleID ", SqlDbType.Int).Value = RoleID;
                sql_cmnd.Parameters.AddWithValue("@FirstName", SqlDbType.NVarChar).Value = FirstName;
                sql_cmnd.Parameters.AddWithValue("@LastName", SqlDbType.Int).Value = LastName;
                sql_cmnd.Parameters.AddWithValue("@Email", SqlDbType.NVarChar).Value = Email;
                sql_cmnd.Parameters.AddWithValue("@Mobile", SqlDbType.NVarChar).Value = Mobile;
                sql_cmnd.Parameters.AddWithValue("@Password", SqlDbType.NVarChar).Value = Password;
                sql_cmnd.ExecuteNonQuery();
                sqlCon.Close();
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
        public bool ValidateUserLoginCreds(string username, string password)
        {
            try
            {
                //string defaultpassword = "pass@123";
                string str = "sp_getUsers";
                System.Data.Common.DbCommand cmd = db.GetStoredProcCommand(str);
                db.AddInParameter(cmd, "@Email", DbType.String, username);
                DataSet ds = db.ExecuteDataSet(cmd);
                //DataSet ds = db.ExecuteDataSet(CommandType.Text, str);
                if (ds != null && ds.Tables.Count > 0 && ds.Tables[0].Rows.Count > 0)
                {
                    DataRow rw = ds.Tables[0].Rows[0];
                    EncryptDecryptClass ep = new EncryptDecryptClass();
                    if (password == ep.DecryptPassword(rw["password"].ToString()))
                    {
                        mUserDetails = ds;
                        return true;
                    }
                    else
                    {
                        //mLoginAttempts++;
                        mMsgFlg = "Invalid password";
                        return false;
                    }
                }
                else
                {
                    mMsgFlg = "Email does not exist";
                    return false;
                }
            }
            catch (Exception ex)
            {
                mMsgFlg = ex.Message;
                return false;
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
        public DataSet GetSystemUserByUserEmail(string Email)
        {

            string str = "sp_getUsers";
            System.Data.Common.DbCommand cmd = db.GetStoredProcCommand(str);
            db.AddInParameter(cmd, "@Email", DbType.String, Email);
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

        public void SaveAccount(string FirstName, string LastName, string Email, string Phone, string Password, string Address, DateTime DOB, int RoleID)
        {
            string constr = ConfigurationManager.ConnectionStrings["con"].ConnectionString;
            SqlConnection sqlCon = null;
            using (sqlCon = new SqlConnection(constr))
            {
                sqlCon.Open();
                SqlCommand sql_cmnd = new SqlCommand("Users_Ins", sqlCon);
                sql_cmnd.CommandType = CommandType.StoredProcedure;
                sql_cmnd.Parameters.AddWithValue("@RoleID", SqlDbType.Int).Value = RoleID;
                sql_cmnd.Parameters.AddWithValue("@FirstName", SqlDbType.NVarChar).Value = FirstName;
                sql_cmnd.Parameters.AddWithValue("@LastName", SqlDbType.NVarChar).Value = LastName;
                sql_cmnd.Parameters.AddWithValue("@Email", SqlDbType.NVarChar).Value = Email;
                sql_cmnd.Parameters.AddWithValue("@Mobile", SqlDbType.NVarChar).Value = Phone;
                sql_cmnd.Parameters.AddWithValue("@Address", SqlDbType.NVarChar).Value = Address;
                sql_cmnd.Parameters.AddWithValue("@DOB", SqlDbType.DateTime).Value = DOB;
                sql_cmnd.Parameters.AddWithValue("@Password", SqlDbType.NVarChar).Value = Password;
                sql_cmnd.ExecuteNonQuery();
                sqlCon.Close();
            }
        }
        public void UpdateUserDetails(string FirstName, string LastName, string Email, string Phone, string Address, DateTime DOB
            , int GenderID, int CountryID, int RaceID, int ReligionID, int TitleID, int DisabilityID, int NextKinRelationID, int IdentityDocumentTypeID,
            string NextKinNames, string NextKinMobile, string NextKinAddress, string IdentityNumber)
        {
            string constr = ConfigurationManager.ConnectionStrings["con"].ConnectionString;
            SqlConnection sqlCon = null;
            using (sqlCon = new SqlConnection(constr))
            {
                sqlCon.Open();
                SqlCommand sql_cmnd = new SqlCommand("Users_Update", sqlCon);
                sql_cmnd.CommandType = CommandType.StoredProcedure;
                sql_cmnd.Parameters.AddWithValue("@FirstName", SqlDbType.NVarChar).Value = FirstName;
                sql_cmnd.Parameters.AddWithValue("@LastName", SqlDbType.NVarChar).Value = LastName;
                sql_cmnd.Parameters.AddWithValue("@Email", SqlDbType.NVarChar).Value = Email;
                sql_cmnd.Parameters.AddWithValue("@Mobile", SqlDbType.NVarChar).Value = Phone;
                sql_cmnd.Parameters.AddWithValue("@Address", SqlDbType.NVarChar).Value = Address;
                sql_cmnd.Parameters.AddWithValue("@DOB", SqlDbType.DateTime).Value = DOB;
                sql_cmnd.Parameters.AddWithValue("@GenderID", SqlDbType.Int).Value = GenderID;
                sql_cmnd.Parameters.AddWithValue("@CountryID", SqlDbType.Int).Value = CountryID;
                sql_cmnd.Parameters.AddWithValue("@RaceID", SqlDbType.Int).Value = RaceID;
                sql_cmnd.Parameters.AddWithValue("@ReligionID", SqlDbType.Int).Value = ReligionID;
                sql_cmnd.Parameters.AddWithValue("@TitleID", SqlDbType.Int).Value = TitleID;
                sql_cmnd.Parameters.AddWithValue("@DisabilityID", SqlDbType.Int).Value = DisabilityID;
                sql_cmnd.Parameters.AddWithValue("@NextKinRelationID", SqlDbType.Int).Value = NextKinRelationID;
                sql_cmnd.Parameters.AddWithValue("@IdentityDocumentTypeID", SqlDbType.Int).Value = IdentityDocumentTypeID;
                sql_cmnd.Parameters.AddWithValue("@NextKinNames", SqlDbType.NVarChar).Value = NextKinNames;
                sql_cmnd.Parameters.AddWithValue("@NextKinMobile", SqlDbType.NVarChar).Value = NextKinMobile;
                sql_cmnd.Parameters.AddWithValue("@NextKinAddress", SqlDbType.NVarChar).Value = NextKinAddress;
                sql_cmnd.Parameters.AddWithValue("@IdentityNumber", SqlDbType.NVarChar).Value = IdentityNumber;
                sql_cmnd.ExecuteNonQuery();
                sqlCon.Close();
            }
        }
        public void UpdateInstituionDetails(string SchhoolName, string Email, string Phone, string Tel, string Address, int UniversityTypeID, int CountryID,
          string MissionStatement, string WebsiteUrl, string Facebooklink, string Twitterlink)
        {
            string constr = ConfigurationManager.ConnectionStrings["con"].ConnectionString;
            SqlConnection sqlCon = null;
            using (sqlCon = new SqlConnection(constr))
            {
                sqlCon.Open();
                SqlCommand sql_cmnd = new SqlCommand("Institution_Update", sqlCon);
                sql_cmnd.CommandType = CommandType.StoredProcedure;
                sql_cmnd.Parameters.AddWithValue("@SchoolName", SqlDbType.NVarChar).Value = SchhoolName;
                sql_cmnd.Parameters.AddWithValue("@Email", SqlDbType.NVarChar).Value = Email;
                sql_cmnd.Parameters.AddWithValue("@Mobile", SqlDbType.NVarChar).Value = Phone;
                sql_cmnd.Parameters.AddWithValue("@Address", SqlDbType.NVarChar).Value = Address;
                sql_cmnd.Parameters.AddWithValue("@Tel", SqlDbType.NVarChar).Value = Tel;
                sql_cmnd.Parameters.AddWithValue("@CountryID", SqlDbType.Int).Value = CountryID;
                sql_cmnd.Parameters.AddWithValue("@UniversityType", SqlDbType.Int).Value = UniversityTypeID;
                sql_cmnd.Parameters.AddWithValue("@MissionStatement", SqlDbType.NVarChar).Value = MissionStatement;
                sql_cmnd.Parameters.AddWithValue("@WebSiteUrl", SqlDbType.NVarChar).Value = WebsiteUrl;
                sql_cmnd.Parameters.AddWithValue("@Facebooklink", SqlDbType.NVarChar).Value = Facebooklink;
                sql_cmnd.Parameters.AddWithValue("@Twitterlink", SqlDbType.NVarChar).Value = Twitterlink;

                sql_cmnd.ExecuteNonQuery();
                sqlCon.Close();
            }
        }


        public void InsertAdminDetails(int RoleID, int UserID, string Email, string FirstName, string LastName, string Address, string Mobile, string Password)
        {
            string constr = ConfigurationManager.ConnectionStrings["con"].ConnectionString;
            SqlConnection sqlCon = null;
            using (sqlCon = new SqlConnection(constr))
            {
                sqlCon.Open();
                SqlCommand sql_cmnd = new SqlCommand("Admin_Ins", sqlCon);
                sql_cmnd.CommandType = CommandType.StoredProcedure;
                sql_cmnd.Parameters.AddWithValue("@UserID", SqlDbType.Int).Value = UserID;
                sql_cmnd.Parameters.AddWithValue("@RoleID", SqlDbType.Int).Value = RoleID;
                sql_cmnd.Parameters.AddWithValue("@Email", SqlDbType.NVarChar).Value = Email;
                sql_cmnd.Parameters.AddWithValue("@FirstName", SqlDbType.NVarChar).Value = FirstName;
                sql_cmnd.Parameters.AddWithValue("@LastName", SqlDbType.NVarChar).Value = LastName;
                sql_cmnd.Parameters.AddWithValue("@Address ", SqlDbType.NVarChar).Value = Address;
                sql_cmnd.Parameters.AddWithValue("@Mobile", SqlDbType.NVarChar).Value = Mobile;
                sql_cmnd.Parameters.AddWithValue("@Password", SqlDbType.Int).Value = Password;
                sql_cmnd.ExecuteNonQuery();
                sqlCon.Close();
            }
        }
        public void InsertAgentDetails(int RoleID, int UserID, string Email, string FirstName, string LastName, string Address, string Mobile, int CountryID)
        {
            string constr = ConfigurationManager.ConnectionStrings["con"].ConnectionString;
            SqlConnection sqlCon = null;
            using (sqlCon = new SqlConnection(constr))
            {
                sqlCon.Open();
                SqlCommand sql_cmnd = new SqlCommand("Agent_Ins", sqlCon);
                sql_cmnd.CommandType = CommandType.StoredProcedure;
                sql_cmnd.Parameters.AddWithValue("@UserID", SqlDbType.Int).Value = UserID;
                sql_cmnd.Parameters.AddWithValue("@RoleID", SqlDbType.Int).Value = RoleID;
                sql_cmnd.Parameters.AddWithValue("@Email", SqlDbType.NVarChar).Value = Email;
                sql_cmnd.Parameters.AddWithValue("@FirstName", SqlDbType.NVarChar).Value = FirstName;
                sql_cmnd.Parameters.AddWithValue("@LastName", SqlDbType.NVarChar).Value = LastName;
                sql_cmnd.Parameters.AddWithValue("@Address ", SqlDbType.NVarChar).Value = Address;
                sql_cmnd.Parameters.AddWithValue("@Mobile", SqlDbType.NVarChar).Value = Mobile;
                sql_cmnd.Parameters.AddWithValue("@CountryID", SqlDbType.Int).Value = CountryID;

                sql_cmnd.ExecuteNonQuery();
                sqlCon.Close();
            }
        }


        public void UpdatePassword(int UserID, string Password)
        {
            string constr = ConfigurationManager.ConnectionStrings["con"].ConnectionString;
            SqlConnection sqlCon = null;
            using (sqlCon = new SqlConnection(constr))
            {
                sqlCon.Open();
                SqlCommand sql_cmnd = new SqlCommand("Upd_Password", sqlCon);
                sql_cmnd.CommandType = CommandType.StoredProcedure;
                sql_cmnd.Parameters.AddWithValue("@UserID", SqlDbType.Int).Value = UserID;
                sql_cmnd.Parameters.AddWithValue("@Password", SqlDbType.VarChar).Value = Password;
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