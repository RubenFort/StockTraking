using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StockTracking.BLL
{
    //T => xxxDetailDTO
    //K => xxxDTO
    interface IBLL<T, K> where T : class where K : class
    {
        K Select();
        bool Insert(T entity);
        bool Update(T entity);
        bool Delete(T entity);
        bool GetBack(T entity);
    }
}
