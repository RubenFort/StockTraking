using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using StockTracking.DAL.DAO;
using StockTracking.DAL.DTO;
using StockTracking.DAL;

namespace StockTracking.BLL
{
    class ProductBLL : IBLL<ProductDetailDTO, ProductDTO>
    {
        CategoryDAO categoryDao = new CategoryDAO();
        ProductDAO dao = new ProductDAO();
        SalesDAO salesDao = new SalesDAO(); 

        public bool Delete(ProductDetailDTO entity)
        {
            PRODUCT product = new PRODUCT();
            product.Id = entity.productId;
            dao.Delete(product);
            SALE sale = new SALE();
            sale.ProductId = entity.productId;
            salesDao.Delete(sale);
            return true;
        }

        public bool GetBack(ProductDetailDTO entity)
        {
            return dao.GetBack(entity.productId);
        }

        public bool Insert(ProductDetailDTO entity)
        {
            PRODUCT product = new PRODUCT();
            product.ProductName = entity.productName;
            product.CategoryId = entity.categoryId;
            product.Price = entity.price;
            return dao.Insert(product);
        }

        public ProductDTO Select()
        {
            ProductDTO dto = new ProductDTO();
            dto.categories = categoryDao.Select();
            dto.products = dao.Select();
            return dto;
        }

        public bool Update(ProductDetailDTO entity)
        {
            PRODUCT product = new PRODUCT();
            product.Id = entity.productId;
            product.Price = entity.price;
            product.ProductName = entity.productName;
            product.StockAmout = entity.stockAmount;
            product.CategoryId = entity.categoryId;
            return dao.Update(product);
        }
    }
}
