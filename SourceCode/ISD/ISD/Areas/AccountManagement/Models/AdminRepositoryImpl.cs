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
        public RespondingRequest create(Admins admin)
        {
            throw new NotImplementedException();
        }

        public List<Admins> getData()
        {
            throw new NotImplementedException();
        }

        public Admins getDataByAccount(string account, string password)
        {
            DataTable dt = SqlHelper.getData("SELECT * FROM ADMINS WHERE ACCOUNT = @ACCOUNT AND PASSWORD = @PASSWORD",
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
            DataTable dt = SqlHelper.getData("SELECT * FROM ADMINS WHERE ADMINID = @ADMINID",
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