using Newtonsoft.Json;
using PeriferiaData.Models;
using System;
using System.Collections.Generic;
using System.Linq;

namespace PeriferiaBusiness
{
    /// <summary>
    /// CLase que opera como capa de negocio para validaciones u operaciones interoperables antes y despúes de comunicarse con el acceso de Datos
    /// </summary>
    public class CategoryBusiness : IDisposable
    {
        /// <summary>
        /// Método que consulta todos los registros de la entidad
        /// </summary>
        /// <returns></returns>
        public List<Category> GetCategories()
        {
            try
            {
                List<Category> categories = new List<Category>();

                using (AppDbContext context = new AppDbContext())
                {
                    categories = context.Category.ToList();
                }

                return categories;
            }
            catch (Exception err)
            {
                throw new ApplicationException("error", err);
            }
        }

        /// <summary>
        /// Método que agrega en registro de la entidad
        /// </summary>
        public void AddCategory(Category category)
        {
            try
            {
                using (AppDbContext context = new AppDbContext())
                {
                    context.Add(category);
                    context.SaveChanges();
                }
            }
            catch (Exception err)
            {
                throw new ApplicationException("error", err);
            }
        }

        /// <summary>
        /// Método que actualiza en registro de la entidad
        /// </summary>
        public Category UpdateCategory(Guid ID, string JCategory)
        {
            try
            {
                using (AppDbContext context = new AppDbContext())
                {
                    var cat = context.Category.First(o => o.CategoryId == ID);
                    JsonConvert.PopulateObject(JCategory, cat);
                    context.SaveChanges();
                    return cat;
                }
            }
            catch (Exception err)
            {
                throw new ApplicationException("error", err);
            }
        }

        /// <summary>
        /// Método que elimina en registro de la entidad
        /// </summary>
        public void DeleteCategory(Guid ID)
        {
            try
            {
                using (AppDbContext context = new AppDbContext())
                {
                    var cat = context.Category.First(o => o.CategoryId == ID);
                    context.Remove(cat);
                    context.SaveChanges();
                }
            }
            catch (Exception err)
            {
                throw new ApplicationException("error", err);
            }
        }

        /// <summary>
        /// Atributo que me permite determinar si la instancia debe cerrarse.
        /// </summary>
        private bool disposedValue = false;

        /// <summary>
        /// Método que me permite cerrar la instancia del DAL
        /// </summary>
        /// <param name="disposing"></param>
        protected virtual void Dispose(bool disposing)
        {
            if (!disposedValue)
            {
                if (disposing)
                {
                }
                disposedValue = true;
            }
        }

        /// <summary>
        /// Método que me permite cerrar Instancia del objeto
        /// </summary>
        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }
    }
}