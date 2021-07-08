using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using StockTracking.DAL.DTO;
using StockTracking.DAL;

namespace StockTracking.DAL.DAO
{
    class SalesDAO : StockContext, IDAO<SALE, SalesDetailDTO>
    {
        public bool Delete(SALE entity)
        {
            throw new NotImplementedException();
        }

        public bool GetBack(int Id)
        {
            throw new NotImplementedException();
        }

        public bool Insert(SALE entity)
        {
            throw new NotImplementedException();
        }

        public List<SalesDetailDTO> Select()
        {
            throw new NotImplementedException();
        }

        public bool Update(SALE entity)
        {
            throw new NotImplementedException();
        }
    }
}
