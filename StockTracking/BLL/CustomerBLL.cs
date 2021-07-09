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
    public class CustomerBLL : IBLL<CustomerDetailDTO, CustomerDTO>
    {
        CustomerDAO dao = new CustomerDAO();
        SalesDAO salesDao = new SalesDAO();

        public bool Delete(CustomerDetailDTO entity)
        {
            CUSTOMER customer = new CUSTOMER();
            customer.Id = entity.id;
            dao.Delete(customer);
            SALE sale = new SALE();
            sale.CustomerId = entity.id;
            salesDao.Delete(sale);
            return true;
        }

        public bool GetBack(CustomerDetailDTO entity)
        {
            return dao.GetBack(entity.id);
        }

        public bool Insert(CustomerDetailDTO entity)
        {
            CUSTOMER customer = new CUSTOMER();
            customer.CustomerName = entity.customerName;
            return dao.Insert(customer);
        }

        public CustomerDTO Select()
        {
            CustomerDTO dto = new CustomerDTO();
            dto.customers = dao.Select();
            return dto;
        }

        public bool Update(CustomerDetailDTO entity)
        {
            CUSTOMER customer = new CUSTOMER();
            customer.Id = entity.id;
            customer.CustomerName = entity.customerName;
            return dao.Update(customer);
        }
    }
}
