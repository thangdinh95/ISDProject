using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using ISD.CommonEntity;
using System.Data;
using ISD.Helper;
using System.Data.SqlClient;

namespace ISD.Areas.AccountManagement.Models
{
    public class AdminRepositoryImpl : AdminRepository
    {
        private const string SELECT_ALL_DATA = "SELECT A.*, B.ACCOUNT AS CREATEDBYACCOUNT, "
            + " C.ACCOUNT AS MODIFIEDBYACCOUNT FROM ADMINS A LEFT JOIN ADMINS B ON"
            + " A.CREATEDBY = B.ADMINID LEFT JOIN ADMINS C ON A.MODIFIEDBY = C.ADMINID";
        private const string SELECT_DATA_BY_ID = "SELECT A.*, B.ACCOUNT AS CREATEDBYACCOUNT,"
            + " C.ACCOUNT AS MODIFIEDBYACCOUNT FROM ADMINS A LEFT JOIN ADMINS B ON"
            + " A.CREATEDBY = B.ADMINID LEFT JOIN ADMINS C ON A.MODIFIEDBY = C.ADMINID"
            + " WHERE A.ADMINID = @ADMINID";
        private const string SELECT_DATA_BY_ACC_PSS = "SELECT A.*, B.ACCOUNT AS CREATEDBYACCOUNT,"
            + " C.ACCOUNT AS MODIFIEDBYACCOUNT FROM ADMINS A LEFT JOIN ADMINS B ON"
            + " A.CREATEDBY = B.ADMINID LEFT JOIN ADMINS C ON A.MODIFIEDBY = C.ADMINID"
            + " WHERE A.ACCOUNT = @ACCOUNT AND A.PASSWORD = @PASSWORD";
        private const string CREATE_ACC = "INSERT INTO ADMINS([ACCOUNT], [PASSWORD]" +
          ",[NAME],[BIRTHDAY],[PHONE],[MAIL],[ADDRESS],[ROLE],[CREATEDBY],[CREATEDDATE])"+
          " VALUES(@ACCOUNT, @PASSWORD, @NAME, @BIRTHDAY, @PHONE, @MAIL, @ADDRESS, " +
          " @ROLE, @CREATEDBY, @CREATEDDATE)";
        private const string UPDATE_ACC = "UPDATE ADMINS SET NAME = @NAME, BIRTHDAY = @BIRTHDAY,"
            + " PHONE = @PHONE, ADDRESS = @ADDRESS, MODIFIEDBY = @MODIFIEDBY,"
            + " MODIFIEDDATE = @MODIFIEDDATE WHERE ADMINID = @ADMINID";
        private const string REMOVE_ACC = "DELETE ADMINS WHERE ADMINID = @ADMINID";
        private const string COUNT_ACCOUNT = "SELECT COUNT(*) FROM ADMINS WHERE ACCOUNT = @ACCOUNT";
        public RespondingRequest create(Admins admin)
        {
            RespondingRequest respondingRequest = SqlHelper.update(CREATE_ACC
                , new SqlParameter("@ACCOUNT", admin.account)
                , new SqlParameter("@PASSWORD", admin.password)
                , new SqlParameter("@NAME", admin.name)
                , new SqlParameter("@BIRTHDAY", admin.birthday)
                , new SqlParameter("@PHONE", admin.phone)
                , new SqlParameter("@MAIL", admin.mail)
                , new SqlParameter("@ADDRESS", admin.address)
                , new SqlParameter("@ROLE", (int)admin.role)
                , new SqlParameter("@CREATEDBY", admin.createdBy)
                , new SqlParameter("@CREATEDDATE", admin.createdDate)
                );
            return respondingRequest;
        }

        public List<Admins> getData()
        {
            List<Admins> lstAdmins = new List<Admins>();
            DataTable dt = SqlHelper.getData(SELECT_ALL_DATA);
            foreach(DataRow dr in dt.Rows)
                lstAdmins.Add(toObject(dr));
            return lstAdmins;
        }

        public Admins getDataByAccount(string account, string password)
        {
            DataTable dt = SqlHelper.getData(SELECT_DATA_BY_ACC_PSS,
                new SqlParameter("@ACCOUNT", account),
                new SqlParameter("@PASSWORD", password));
            if(dt.Rows.Count > 0)
            {
                Admins admin = toObject(dt.Rows[0]);
                return admin;
            }
            return null;
        }

        public Admins getDataById(int id)
        {
            DataTable dt = SqlHelper.getData(SELECT_DATA_BY_ID,
               new SqlParameter("@ADMINID", id));
            if (dt.Rows.Count > 0)
            {
                Admins admin = toObject(dt.Rows[0]);
                return admin;
            }
            return null;
        }

        public RespondingRequest remove(int id)
        {
            RespondingRequest respondingRequest = SqlHelper.update(REMOVE_ACC
                , new SqlParameter("@ADMINID", id)
                );
            return respondingRequest;
        }

        public RespondingRequest update(Admins admin)
        {
            RespondingRequest respondingRequest = SqlHelper.update(UPDATE_ACC
                , new SqlParameter("@NAME", admin.name)
                , new SqlParameter("@BIRTHDAY", admin.birthday)
                , new SqlParameter("@PHONE", admin.phone)
                , new SqlParameter("@MAIL", admin.mail)
                , new SqlParameter("@ADDRESS", admin.address)
                , new SqlParameter("@MODIFIEDBY", admin.modifiedBy)
                , new SqlParameter("@MODIFIEDDATE", admin.modifiedDate)
                , new SqlParameter("@ADMINID", admin.adminId)
                );
            return respondingRequest;
        }

        private Admins toObject(DataRow dr)

        {
            /*
             * if(a > b)
             * {cv dung}
             * else{cv sai}
             * 
             * 
             * 
             * a>b?(cv dung):(cv sai)
             */
            Admins admin = new Admins()
            {
                adminId = Int16.Parse(dr["ADMINID"].ToString()),
                account = dr["ACCOUNT"].ToString(),
                password = dr["PASSWORD"].ToString(),
                name = dr["NAME"].ToString(),
                birthday = DateTime.Parse(dr["BIRTHDAY"].ToString()),
                phone = dr["PHONE"].ToString(),
                mail = dr["MAIL"].ToString(),
                address = dr["ADDRESS"].ToString(),
                role = Int16.Parse(dr["ROLE"].ToString()) == 1 ? ROLES.SUPERADMIN : ROLES.ADMIN,
                createdBy = !dr.IsNull("CREATEDBY") ? Int16.Parse(dr["CREATEDBY"].ToString()) : -1,
                createdByAccount = !dr.IsNull("CREATEDBYACCOUNT") ? dr["CREATEDBYACCOUNT"].ToString() : "",
                createdDate = !dr.IsNull("CREATEDDATE") ? DateTime.Parse(dr["CREATEDDATE"].ToString()) : DateTime.Now,
                modifiedBy = !dr.IsNull("MODIFIEDBY") ? Int16.Parse(dr["MODIFIEDBY"].ToString()) : -1,
                modifiedByAccount = !dr.IsNull("MODIFIEDBYACCOUNT") ? dr["MODIFIEDBYACCOUNT"].ToString() : "",
                modifiedDate = !dr.IsNull("MODIFIEDDATE") ? DateTime.Parse(dr["MODIFIEDDATE"].ToString()) : DateTime.Now
            };
            return admin;
        }

        public bool checkAccountExist(string account)
        {
            DataTable dt = SqlHelper.getData(COUNT_ACCOUNT,
                new SqlParameter("@ACCOUNT", account));
            return Int16.Parse(dt.Rows[0][0].ToString()) > 0;
        }
    }
}