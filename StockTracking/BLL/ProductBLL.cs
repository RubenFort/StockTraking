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

        public bool Delete(ProductDetailDTO entity)
        {
            throw new NotImplementedException();
        }

        public bool GetBack(int Id)
        {
            throw new NotImplementedException();
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
            return dto;
        }

        public bool Update(ProductDetailDTO entity)
        {
            throw new NotImplementedException();
        }
    }
}
