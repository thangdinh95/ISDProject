using ISD.CommonEntity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ISD.Areas.ProductManagement.Models.ProductStatusRepositoryFolder
{
    interface ProductStatusRepository
    {
        RespondingRequest create(Products ps);
        RespondingRequest update(Products ps);
        RespondingRequest remove(int productId);
    }
}
