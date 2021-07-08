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
            SALE sales = new SALE();
            PRODUCT product = new PRODUCT();

            sales.CategoryId = entity.categoryId;
            sales.ProductId = entity.productId;
            sales.CustomerId = entity.customerId;
            sales.ProductSalesPrice = entity.price;
            sales.ProductSalesAmount = entity.salesAmount;
            sales.SalesDate = entity.salesDate;
            sales.CategoryId = entity.categoryId;
            bool boolInsert = salesDao.Insert(sales);
            product.Id = entity.productId;
            product.StockAmout = entity.stockAmount - entity.salesAmount;
            ProductDAO.Update(product);
            return boolInsert;
        }

        public SalesDTO Select()
        {
            SalesDTO dto = new SalesDTO();
            dto.products = ProductDAO.Select();
            dto.customers = customerDAO.Select();
            dto.categories = categoryDAO.Select();
            dto.sales = salesDao.Select();
            return dto;
        }

        public bool Update(SalesDetailDTO entity)
        {
            throw new NotImplementedException();
        }
    }
}
