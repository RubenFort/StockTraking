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
            throw new NotImplementedException();
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
                var list = (from p in db.PRODUCTs
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
