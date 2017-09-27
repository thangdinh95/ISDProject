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
        private const string SELECT_ALL_DATA = "SELECT * FROM ADMINS";
        private const string SELECT_DATA_BY_ID = "SELECT * FROM ADMINS WHERE ADMINID = @ADMINID";
        private const string SELECT_DATA_BY_ACC_PSS = "SELECT * FROM ADMINS " +
           " WHERE ACCOUNT = @ACCOUNT AND PASSWORD = @PASSWORD";
        private const string CREATE_ACC = "INSERT INTO ADMINS([ACCOUNT], [PASSWORD]" +
          ",[NAME],[BIRTHDAY],[PHONE],[MAIL],[ADDRESS],[ROLE],[CREATEDBY],[CREATEDDATE])"+
          " VALUES(@ACCOUNT, @PASSWORD, @NAME, @BIRTHDAY, @PHONE, @MAIL, @ADDRESS, " +
          " @ROLE, @CREATEDBY, @CREATEDDATE)";
        private const string UPDATE_ACC = "";
        private const string REMOVE_ACC = "";
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
            throw new NotImplementedException();
        }

        public RespondingRequest update(Admins admin)
        {
            throw new NotImplementedException();
        }

        private Admins toObject(DataRow dr)
        {
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
                createdDate = !dr.IsNull("CREATEDDATE") ? DateTime.Parse(dr["CREATEDDATE"].ToString()) : DateTime.Now,
                modifiedBy = !dr.IsNull("MODIFIEDBY") ? Int16.Parse(dr["MODIFIEDBY"].ToString()) : -1,
                modifiedDate = !dr.IsNull("MODIFIEDDATE") ? DateTime.Parse(dr["MODIFIEDDATE"].ToString()) : DateTime.Now
            };
            return admin;
        }
    }
}