using ISD.CommonEntity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ISD.Areas.ProductManagement.Models
{
    interface ImageRepository
    {
        List<Images> getAll(int pId);
        Images getDataById(int imageId);
        RespondingRequest create(Images image);
        RespondingRequest update(Images image);
        RespondingRequest remove(Images image);
    }
}
