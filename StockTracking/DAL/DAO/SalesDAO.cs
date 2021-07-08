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
            try
            {
                if (entity.Id != 0)
                {
                    SALE sales = db.SALES.First(x => x.Id == entity.Id);
                    sales.isDeleted = true;
                    sales.DeletedDate = DateTime.Today;
                    db.SaveChanges();
                }
                else if (entity.ProductId != 0)
                {
                    List<SALE> sales = db.SALES.Where(x => x.ProductId == entity.ProductId).ToList();
                    foreach (var item in sales)
                    {
                        item.isDeleted = true;
                        item.DeletedDate = DateTime.Today;
                    }
                    db.SaveChanges();
                }
                else if (entity.CustomerId != 0)
                {
                    List<SALE> sales = db.SALES.Where(x => x.CustomerId == entity.CustomerId).ToList();
                    foreach (var item in sales)
                    {
                        item.isDeleted = true;
                        item.DeletedDate = DateTime.Today;
                    }
                    db.SaveChanges();
                }
                return true;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public bool GetBack(int Id)
        {
            throw new NotImplementedException();
        }

        public bool Insert(SALE entity)
        {
            try
            {
                db.SALES.Add(entity);
                db.SaveChanges();
                return true;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public List<SalesDetailDTO> Select()
        {
            try
            {
                List<SalesDetailDTO> sales = new List<SalesDetailDTO>();
                var list = (from s in db.SALES.Where(x => x.isDeleted == false)
                            join p in db.PRODUCTs on s.ProductId equals p.Id
                            join c in db.CUSTOMERs on s.CustomerId equals c.Id
                            join category in db.CATEGORies on s.CategoryId equals category.Id
                            select new
                            {
                                productName = p.ProductName,
                                customerName = c.CustomerName,
                                categoryName = category.CategoryName,
                                productId = s.ProductId,
                                customerId = s.CustomerId,
                                salesId = s.Id,
                                categoryId = s.CategoryId,
                                salesPrice = s.ProductSalesPrice,
                                salesAmount = s.ProductSalesAmount,
                                salesDate = s.SalesDate
                            }).OrderBy(x => x.salesDate).ToList();
                foreach (var item in list)
                {
                    SalesDetailDTO dto = new SalesDetailDTO();
                    dto.productName = item.productName;
                    dto.customerName = item.customerName;
                    dto.categoryName = item.categoryName;
                    dto.productId = item.productId;
                    dto.customerId = item.customerId;
                    dto.salesId = item.salesId;
                    dto.categoryId = item.categoryId;
                    dto.price = item.salesPrice;
                    dto.salesAmount = item.salesAmount;
                    dto.salesDate = item.salesDate;
                    sales.Add(dto);
                }
                return sales;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public bool Update(SALE entity)
        {
            try
            {
                SALE sales = db.SALES.First(x => x.Id == entity.Id);
                sales.ProductSalesAmount = entity.ProductSalesAmount;
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
