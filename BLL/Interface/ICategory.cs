using BOL.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Interface
{
    public interface ICategory
    {
        CategoryModel GetCategoryDetails(CategoryModel model);
        List<CategoryModel> CategoryList();
        int SaveCategory(CategoryModel model);        
        CategoryModel Getbyid(int id);
    }
}
