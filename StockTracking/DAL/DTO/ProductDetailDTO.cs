using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StockTracking.DAL.DTO
{
    public class ProductDetailDTO
    {
        public string productName { get; set; }
        public string categoryName { get; set; }
        public int stockAmount { get; set; }
        public int price { get; set; }
        public int productId { get; set; }
        public int categoryId { get; set; }
    }
}
