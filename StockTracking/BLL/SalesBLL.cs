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
        ProductDAO productDAO = new ProductDAO();
        CategoryDAO categoryDAO = new CategoryDAO();
        CustomerDAO customerDAO = new CustomerDAO();

        public bool Delete(SalesDetailDTO entity)
        {
            SALE sales = new SALE();
            sales.Id = entity.salesId;
            salesDao.Delete(sales);
            PRODUCT product = new PRODUCT();
            product.Id = entity.productId;
            product.StockAmout = entity.stockAmount + entity.salesAmount;
            productDAO.Update(product);
            return true;
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
            productDAO.Update(product);
            return boolInsert;
        }

        public SalesDTO Select()
        {
            SalesDTO dto = new SalesDTO();
            dto.products = productDAO.Select();
            dto.customers = customerDAO.Select();
            dto.categories = categoryDAO.Select();
            dto.sales = salesDao.Select();
            return dto;
        }

        public SalesDTO Select(bool isDeleted)
        {
            SalesDTO dto = new SalesDTO();
            dto.products = productDAO.Select(isDeleted);
            dto.customers = customerDAO.Select(isDeleted);
            dto.categories = categoryDAO.Select(isDeleted);
            dto.sales = salesDao.Select(isDeleted);
            return dto;
        }

        public bool Update(SalesDetailDTO entity)
        {
            SALE sales = new SALE();
            sales.Id = entity.salesId;
            sales.ProductSalesAmount = entity.salesAmount;
            salesDao.Update(sales);
            PRODUCT product = new PRODUCT();
            product.Id = entity.productId;
            product.StockAmout = entity.stockAmount;
            productDAO.Update(product);
            return true;
        }
    }
}
