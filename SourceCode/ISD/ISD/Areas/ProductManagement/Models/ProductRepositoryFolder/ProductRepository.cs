using ISD.CommonEntity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ISD.Areas.ProductManagement.Models.ProductRepositoryFolder
{
    interface ProductRepository
    {
        List<Products> getData();
        Products getDataById(int id);
        RespondingRequest create(Products product);
        RespondingRequest update(Products product);
        RespondingRequest remove(Products product);
    }
}
