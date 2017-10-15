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
        private static string sqlConnection = ConfigurationManager.ConnectionStrings["conStr"].ConnectionString;//khai bao cau lenh string connect giua file va data
        private static SqlConnection con;//khai bao connection
        private static SqlCommand cmd;//khai bao command để tương tác csdl
        private static DataTable dtReturn;//khai báo datatable để chua dl
        private static RespondingRequest responding;//khai báo đối tượng respond
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
                if (con.State == ConnectionState.Closed)
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
                if (con.State == ConnectionState.Open)
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
                if (con.State == ConnectionState.Closed)
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
                if (con.State == ConnectionState.Open)
                    con.Close();
            }
            return responding;
        }
        #endregion
    }
}