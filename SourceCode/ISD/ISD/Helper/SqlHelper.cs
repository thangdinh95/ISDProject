using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using ISD.CommonEntity;

namespace ISD.Helper
{
    public class SqlHelper
    {
        #region Declare globle variable
        private static string sqlConnection = ConfigurationManager.ConnectionStrings["conStr"].ConnectionString;
        private static SqlConnection con;
        private static SqlCommand cmd;
        private static DataTable dtReturn;
        private static RespondingRequest responding;
        #endregion

        #region Get connection
        public static SqlConnection getConection()
        {
            if (con == null)
                con = new SqlConnection(sqlConnection);
            return con;
        }
        #endregion

        #region Get data
        public static DataTable getData(string query, params SqlParameter[] par)
        {
            dtReturn = new DataTable();
            try
            {
                cmd = new SqlCommand();
                cmd.Connection = getConection();
                if (query.Contains(" "))
                    cmd.CommandType = CommandType.Text;
                else cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = query;
                cmd.Parameters.AddRange(par);
                if (con.State != ConnectionState.Open)
                    con.Open();
                SqlDataAdapter adapter = new SqlDataAdapter(cmd);
                adapter.Fill(dtReturn);
                return dtReturn;
            }
            catch (Exception e)
            {
                string a = e.Message;
                return dtReturn;
            }
            finally
            {
                if (con.State != ConnectionState.Closed)
                    con.Close();
            }

        }
        #endregion

        #region Update data
        public static RespondingRequest update(string query, params SqlParameter[] par)
        {
            responding = new RespondingRequest();
            try
            {
                cmd = new SqlCommand();
                cmd.Connection = getConection();
                if (query.Contains(" "))
                    cmd.CommandType = CommandType.Text;
                else cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = query;
                cmd.Parameters.AddRange(par);
                if (con.State != ConnectionState.Open)
                    con.Open();
                int row = cmd.ExecuteNonQuery();
                if (row >= 1)
                {
                    responding.status = true;
                    responding.message = "Successful!";
                }
                else
                {
                    responding.status = false;
                    responding.message = "Fail. Please check again!";
                }
            }
            catch (Exception e)
            {
                responding.status = false;
                responding.message = e.Message;
            }
            return responding;
        }
        #endregion

        #region Update data tran
        public static RespondingRequest update(string query,SqlTransaction tran ,params SqlParameter[] par)
        {
            responding = new RespondingRequest();
            try
            {
                cmd = new SqlCommand();
                cmd.Connection = getConection();
                cmd.Transaction = tran;
                if (query.Contains(" "))
                    cmd.CommandType = CommandType.Text;
                else cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = query;
                cmd.Parameters.AddRange(par);
                if (con.State != ConnectionState.Open)
                    con.Open();
                int row = cmd.ExecuteNonQuery();
                if (row >= 1)
                {
                    responding.status = true;
                    responding.message = "Successful!";
                }
                else
                {
                    responding.status = false;
                    responding.message = "Fail. Please check again!";
                }
            }
            catch (Exception e)
            {
                responding.status = false;
                responding.message = e.Message;
            }
            finally
            {
                //if (con.State == ConnectionState.Open)
                //con.Close();
            }
            return responding;
        }
        #endregion

        #region Create and return data
        public static object exeScalar(string query, SqlTransaction tran, params SqlParameter[] par)
        {
            try
            {
                cmd = new SqlCommand();
                cmd.Connection = getConection();
                if (query.Contains(" "))
                    cmd.CommandType = CommandType.Text;
                else cmd.CommandType = CommandType.StoredProcedure;
                if (tran != null) cmd.Transaction = tran;
                cmd.CommandText = query;
                cmd.Parameters.AddRange(par);
                if (con.State != ConnectionState.Open)
                    con.Open();
                return cmd.ExecuteScalar(); 
            }
            catch(Exception e)
            {
                string a = e.Message;
                return null;
            }
        }
        #endregion
    }
}