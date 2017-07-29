using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BOL.Common
{
   public class DesignationModel
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public List<DesignationModel> DesignationModelList { get; set; }
    }
}
