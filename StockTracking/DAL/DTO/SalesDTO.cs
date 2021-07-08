using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StockTracking.DAL.DTO
{
    public class SalesDTO
    {
        public List<SalesDetailDTO> sales { get; set; }
        public List<CustomerDetailDTO> customers { get; set; }
        public List<ProductDetailDTO> products { get; set; }
        public List<CategoryDetailDTO> categories { get; set; }
    }
}
