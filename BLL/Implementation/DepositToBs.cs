using BLL.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BOL.Common;
using DAL.GenericPattern.Interface;
using DAL.GenericPattern.Implementation;
using DAL.DataModel;

namespace BLL.Implementation
{
    public class DepositToBs : IDepositTo
    {

        private readonly IGenericPattern<DepositTo> _depostiTo;

        public DepositToBs()
        {
            _depostiTo = new GenericPattern<DepositTo>();
        }
        public List<DepositToModel> DepositToList()
        {
            var res = _depostiTo.GetAll().ToList();

            List<DepositToModel> depositToList = new List<DepositToModel>();
            depositToList = (from item in res
                               select new DepositToModel
                               {
                                    Id=item.Id,
                                    Name=item.Name
                               }).ToList();
            return depositToList;
        }

        public DepositToModel Getbyid(int id)
        {
            throw new NotImplementedException();
        }

        public DepositToModel GetDepositToDetails(DepositToModel model)
        {
            throw new NotImplementedException();
        }

        public int SaveDepositTo(DepositToModel mode)
        {
            throw new NotImplementedException();
        }
    }
}
