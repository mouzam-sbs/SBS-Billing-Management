using BOL.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Interface
{
    public interface IDesignation
    {
        List<DesignationModel> DesignationList();

        DesignationModel GetDetails(DesignationModel model);

        int Save(DesignationModel model);

        DesignationModel GetById(int id);
    }
}
