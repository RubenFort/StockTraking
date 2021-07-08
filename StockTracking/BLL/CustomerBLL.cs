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

        public bool Delete(CustomerDetailDTO entity)
        {
            throw new NotImplementedException();
        }

        public bool GetBack(int Id)
        {
            throw new NotImplementedException();
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
