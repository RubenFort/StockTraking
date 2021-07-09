using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using StockTracking.DAL;
using StockTracking.DAL.DTO;

namespace StockTracking.DAL.DAO
{
    class ProductDAO : StockContext, IDAO<PRODUCT, ProductDetailDTO>
    {
        public bool Delete(PRODUCT entity)
        {
            try
            {
                if (entity.Id != 0)
                {
                    PRODUCT product = db.PRODUCTs.First(x => x.Id == entity.Id);
                    product.isDeleted = true;
                    product.DeletedDate = DateTime.Today;
                    db.SaveChanges();
                }
                else if (entity.CategoryId != 0)
                {
                    List<PRODUCT> list = db.PRODUCTs.Where(x => x.CategoryId == entity.CategoryId).ToList();
                    foreach (var item in list)
                    {
                        item.isDeleted = true;
                        item.DeletedDate = DateTime.Today;
                        IList<SALE> sales = db.SALES.Where(x => x.ProductId == item.Id).ToList();
                        foreach (var item2 in sales)
                        {
                            item2.isDeleted = true;
                            item2.DeletedDate = DateTime.Today;
                        }
                        db.SaveChanges();
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

        public bool Insert(PRODUCT entity)
        {
            try
            {
                db.PRODUCTs.Add(entity);
                db.SaveChanges();
                return true;
            }
            catch (Exception es)
            {
                throw es;
            }
        }

        public List<ProductDetailDTO> Select()
        {
            try
            {
                List<ProductDetailDTO> products = new List<ProductDetailDTO>();
                var list = (from p in db.PRODUCTs.Where(x => x.isDeleted == false)
                            join c in db.CATEGORies on p.CategoryId equals c.Id
                            select new
                            {
                                productName = p.ProductName,
                                categoryName = c.CategoryName,
                                stockAmount = p.StockAmout,
                                price = p.Price,
                                productId = p.Id,
                                categoryId = c.Id
                            }).OrderBy(x => x.productName).ToList();
                foreach (var item in list)
                {
                    ProductDetailDTO dto = new ProductDetailDTO();
                    dto.productName = item.productName;
                    dto.categoryName = item.categoryName;
                    dto.stockAmount = item.stockAmount;
                    dto.price = item.price;
                    dto.productId = item.productId;
                    dto.categoryId = item.categoryId;
                    products.Add(dto);
                }
                return products;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public List<ProductDetailDTO> Select(bool isDeleted)
        {
            try
            {
                List<ProductDetailDTO> products = new List<ProductDetailDTO>();
                var list = (from p in db.PRODUCTs.Where(x => x.isDeleted == isDeleted)
                            join c in db.CATEGORies on p.CategoryId equals c.Id
                            select new
                            {
                                productName = p.ProductName,
                                categoryName = c.CategoryName,
                                stockAmount = p.StockAmout,
                                price = p.Price,
                                productId = p.Id,
                                categoryId = c.Id
                            }).OrderBy(x => x.productName).ToList();
                foreach (var item in list)
                {
                    ProductDetailDTO dto = new ProductDetailDTO();
                    dto.productName = item.productName;
                    dto.categoryName = item.categoryName;
                    dto.stockAmount = item.stockAmount;
                    dto.price = item.price;
                    dto.productId = item.productId;
                    dto.categoryId = item.categoryId;
                    products.Add(dto);
                }
                return products;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public bool Update(PRODUCT entity)
        {
            try
            {
                PRODUCT product = db.PRODUCTs.First(x => x.Id == entity.Id);
                if (entity.CategoryId == 0)
                    product.StockAmout = entity.StockAmout;
                else
                {
                    product.ProductName = entity.ProductName;
                    product.Price = entity.Price;
                    product.CategoryId = entity.CategoryId;
                }
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
