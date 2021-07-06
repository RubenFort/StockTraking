using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StockTracking.DAL.DAO
{
    //T => Tipo de dato, modelo, clase del modelo
    //K => Clase que vamos a utilizar, clase del detalle del modelo
    interface IDAO<T, K> where T: class where K: class
    {
        List<K> Select();
        bool Insert(T entity);
        bool Update(T entity);
        bool Delete(T entity);
        bool GetBack(int Id);
    }
}
