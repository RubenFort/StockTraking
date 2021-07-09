using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using StockTracking.DAL;
using StockTracking.DAL.DAO;
using StockTracking.DAL.DTO;

namespace StockTracking.DAL.DAO
{
    class CustomerDAO : StockContext, IDAO<CUSTOMER, CustomerDetailDTO>
    {
        public bool Delete(CUSTOMER entity)
        {
            try
            {
                CUSTOMER customer = db.CUSTOMERs.First(x => x.Id == entity.Id);
                customer.isDeleted = true;
                customer.DeletedDate = DateTime.Today;
                db.SaveChanges();
                return true;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public bool GetBack(int Id)
        {
            try
            {
                CUSTOMER customer = db.CUSTOMERs.First(x => x.Id == Id);
                customer.isDeleted = false;
                customer.DeletedDate = null;
                db.SaveChanges();
                return true;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public bool Insert(CUSTOMER entity)
        {
            try
            {
                db.CUSTOMERs.Add(entity);
                db.SaveChanges();
                return true;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public List<CustomerDetailDTO> Select()
        {
            try
            {
                List<CustomerDetailDTO> customers = new List<CustomerDetailDTO>();
                var list = db.CUSTOMERs.Where(x => x.isDeleted == false).ToList();
                foreach (var item in list)
                {
                    CustomerDetailDTO dto = new CustomerDetailDTO();
                    dto.customerName = item.CustomerName;
                    dto.id = item.Id;
                    customers.Add(dto);
                }
                return customers;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public List<CustomerDetailDTO> Select(bool isDeleted)
        {
            try
            {
                List<CustomerDetailDTO> customers = new List<CustomerDetailDTO>();
                var list = db.CUSTOMERs.Where(x => x.isDeleted == isDeleted).ToList();
                foreach (var item in list)
                {
                    CustomerDetailDTO dto = new CustomerDetailDTO();
                    dto.customerName = item.CustomerName;
                    dto.id = item.Id;
                    customers.Add(dto);
                }
                return customers;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public bool Update(CUSTOMER entity)
        {
            try
            {
                CUSTOMER customer = db.CUSTOMERs.First(x => x.Id == entity.Id);
                customer.CustomerName = entity.CustomerName;
                db.SaveChanges();
                return true;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
