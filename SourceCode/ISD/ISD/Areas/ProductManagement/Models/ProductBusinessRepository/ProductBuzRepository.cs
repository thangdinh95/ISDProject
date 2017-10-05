using ISD.CommonEntity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ISD.Areas.ProductManagement.Models.ProductBusinessRepository
{
    interface ProductBuzRepository
    {
        RespondingRequest create(ProductBusinessObject obj);
        RespondingRequest update(ProductBusinessObject obj);
        RespondingRequest remove(ProductBusinessObject obj);
    }
}
