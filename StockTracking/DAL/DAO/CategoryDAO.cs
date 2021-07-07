﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using StockTracking.DAL.DTO;

namespace StockTracking.DAL.DAO
{
    public class CategoryDAO : StockContext, IDAO<CATEGORY, CategoryDetailDTO>
    {
        public bool Delete(CATEGORY entity)
        {
            throw new NotImplementedException();
        }

        public bool GetBack(int Id)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// Usamos LINQ para conexion e insertar(select, update, delete) datos
        /// </summary>
        /// <param name="entity"></param>
        /// <returns></returns>
        public bool Insert(CATEGORY entity)
        {
            try
            {
                db.CATEGORies.Add(entity);
                db.SaveChanges();
                return true;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public List<CategoryDetailDTO> Select()
        {
            List<CategoryDetailDTO> categories = new List<CategoryDetailDTO>();
            var list = db.CATEGORies;
            foreach (var item in list)
            {
                CategoryDetailDTO dto = new CategoryDetailDTO();
                dto.Id = item.Id;
                dto.CategoryName = item.CategoryName;
                categories.Add(dto);
            }
            return categories;
        }

        public bool Update(CATEGORY entity)
        {
            throw new NotImplementedException();
        }
    }
}
