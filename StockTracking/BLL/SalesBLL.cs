using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using StockTracking.DAL.DTO;
using StockTracking.DAL.DAO;
using StockTracking.DAL;

namespace StockTracking.BLL
{
    public class SalesBLL : IBLL<SalesDetailDTO, SalesDTO>
    {
        SalesDAO salesDao = new SalesDAO();
        ProductDAO ProductDAO = new ProductDAO();
        CategoryDAO categoryDAO = new CategoryDAO();
        CustomerDAO customerDAO = new CustomerDAO();

        public bool Delete(SalesDetailDTO entity)
        {
            throw new NotImplementedException();
        }

        public bool GetBack(int Id)
        {
            throw new NotImplementedException();
        }

        public bool Insert(SalesDetailDTO entity)
        {
            throw new NotImplementedException();
        }

        public SalesDTO Select()
        {
            SalesDTO dto = new SalesDTO();
            dto.products = ProductDAO.Select();
            dto.customers = customerDAO.Select();
            dto.categories = categoryDAO.Select();
            //dto.sales = salesDao.Select();
            return dto;
        }

        public bool Update(SalesDetailDTO entity)
        {
            throw new NotImplementedException();
        }
    }
}
