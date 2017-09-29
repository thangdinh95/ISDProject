using ISD.CommonEntity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ISD.Areas.AccountManagement.Models
{
    interface AdminRepository
    {
        List<Admins> getData();
        Admins getDataById(int id);
        Admins getDataByAccount(string account, string password);
        RespondingRequest create(Admins admin);
        RespondingRequest update(Admins admin);
        RespondingRequest remove(int id);
        bool checkAccountExist(string account);
    }
}
