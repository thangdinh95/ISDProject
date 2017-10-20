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
        /*
         * Là thư viện hỗ trợ giúp tương tác giữa code .NET với DB. 
         * Thực hiện 4 thao tác chính: CRUD
         */
        #region Declare globle variable
<<<<<<< HEAD
        private static string sqlConnection = ConfigurationManager.ConnectionStrings["conStr"].ConnectionString;//khai bao cau lenh string connect giua file va data
        private static SqlConnection con;//khai bao connection
        private static SqlCommand cmd;//khai bao command để tương tác csdl
        private static DataTable dtReturn;//khai báo datatable để chua dl
        private static RespondingRequest responding;//khai báo đối tượng respond
=======
        private static string sqlConnection = ConfigurationManager.ConnectionStrings["conStr"].ConnectionString;
        private static SqlConnection con;//khai báo connection 
        private static SqlCommand cmd;// khai báo command để tương tác với csdl
        private static DataTable dtReturn;// khai báo data table để chứa dữ liệu
        private static RespondingRequest responding;// khai báo đối tượng response
>>>>>>> de28096d38dc0ef9dc130eb3083a604841bb6429
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
        /// <summary>
        /// lấy dữ liệu trong csdl
        /// [a, d, c, d], int a[] = new int[4]; int b[] = {3, 5, 5};
        /// add(int a, params int b ) -> add(4, 5) add(4,5 , 5, 5) add()
        /// </summary>
        /// <param name="query">chuỗi query</param>
        /// <param name="par">truyền tham số kiểu params(truyền một mảng có độ dài ko xác định trước - ko bị fix cứng)</param>
        /// <returns></returns>
        public static DataTable getData(string query, params SqlParameter[] par)// sql parameter la khai bao tham số
        {
            dtReturn = new DataTable();
            try
            {
                //ADO trong .NET
                cmd = new SqlCommand();
                cmd.Connection = getConection();
                if (query.Contains(" "))
                    cmd.CommandType = CommandType.Text;
                else cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = query;
                cmd.Parameters.AddRange(par);
                if (con.State != ConnectionState.Open)
                    con.Open();
                SqlDataAdapter adapter = new SqlDataAdapter(cmd);//kiểu trung gian kêt nối giữa Datatable và table trong db
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