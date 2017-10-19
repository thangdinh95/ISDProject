using ISD.CommonEntity;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ISD.Areas.ProductManagement.Models.ProductStatusRepositoryFolder
{
    interface ProductStatusRepository
    {
        RespondingRequest create(Products ps, SqlTransaction tran);
        RespondingRequest update(Products ps, SqlTransaction tran);
        RespondingRequest remove(int productId, SqlTransaction tran);
    }
}
