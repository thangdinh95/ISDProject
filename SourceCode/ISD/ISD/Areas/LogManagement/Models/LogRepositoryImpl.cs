using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using ISD.CommonEntity;
using System.Data;
using ISD.Helper;
using System.Data.SqlClient;

namespace ISD.Areas.LogManagement.Models
{
    public class LogRepositoryImpl : LogRepository
    {
        private const string GET_DATA = "SELECT A.*, B.ACCOUNT AS CREATEDBYACCOUNT "+
            " FROM LOGS A LEFT JOIN ADMINS B ON A.CREATEDBY = B.ADMINID ORDER BY A.CREATEDDATE DESC";
        private const string CREATE = "INSERT INTO LOGS(TYPE, [CONTENT], CREATEDBY, CREATEDDATE)"
            + " VALUES(@TYPE, @CONTENT, @CREATEDBY, @CREATEDDATE)";
        public RespondingRequest create(Logs log)
        {
            return SqlHelper.update(CREATE,
                new SqlParameter("@TYPE", (int)log.type), 
                new SqlParameter("@CONTENT", log.content),
                new SqlParameter("@CREATEDBY", log.createdBy),
                new SqlParameter("CREATEDDATE", log.createdDate));
        }

        public List<Logs> getData()
        {
            DataTable dt = SqlHelper.getData(GET_DATA);
            List<Logs> lstLogs = new List<Logs>();
            foreach (DataRow dr in dt.Rows)
            {
                lstLogs.Add(new Logs() {
                    type =(LOGTYPE) Enum.ToObject(typeof(LOGTYPE),Int16.Parse(dr["TYPE"].ToString())),
                    content = dr["CONTENT"].ToString(),
                    createdByAccount = dr["CREATEDBYACCOUNT"].ToString(),
                    createdDate = !dr.IsNull("CREATEDDATE")? DateTime.Parse(dr["CREATEDDATE"].ToString()) : DateTime.Now
                });
            }
            return lstLogs;
        }

        public RespondingRequest print()
        {
            throw new NotImplementedException();
        }

        public string logContent(LOGTYPE type, string objName, string account)
        {
            return type.ToString()+ " " + objName + " - executed by " + account + " - in " + DateTime.Now; 
        }
    }
}