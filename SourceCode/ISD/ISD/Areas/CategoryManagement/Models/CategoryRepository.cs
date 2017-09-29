using ISD.CommonEntity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ISD.Areas.CategoryManagement.Models
{
    interface CategoryRepository
    {
        List<Categories> getAll();
        Categories getDataById(int id);
        RespondingRequest create(Categories category);
        RespondingRequest update(Categories category);
        RespondingRequest remove(int categoryId);
    }
}
