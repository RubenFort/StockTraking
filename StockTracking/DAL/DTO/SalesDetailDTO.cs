using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StockTracking.DAL.DTO
{
    public class SalesDetailDTO
    {
        public string customerName { get; set; }
        public string productName { get; set; }
        public string categoryName { get; set; }
        public int customerId { get; set; }
        public int productId { get; set; }
        public int categoryId { get; set; }
        public int salesAmount { get; set; }
        public int price { get; set; }
        public DateTime salesDate { get; set; }
        public int stockAmount { get; set; }
        public int salesId { get; set; }
        public bool isCategoyDeleted { get; set; }
        public bool isCustomerDeleted { get; set; }
        public bool isProductDeleted { get; set; }
    }
}
