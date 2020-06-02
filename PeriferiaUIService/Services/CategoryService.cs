using PeriferiaBusiness;
using PeriferiaData.Models;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace PeriferiaUIService
{
    /// <summary>
    /// Clase que opera como "Servicio" que consulta la capa de negocio
    /// </summary>
    public class CategoryService : ICategoryService
    {
        /// <summary>
        /// Objeto de negocio
        /// </summary>
        private CategoryBusiness categoryBusiness;

        /// <summary>
        /// Constructor de la clase que inicializa capa de negocio
        /// </summary>
        public CategoryService()
        {
            categoryBusiness = new CategoryBusiness();
        }

        /// <summary>
        /// Método que consulta todos los registros de la entidad
        /// </summary>
        /// <returns>Lista de registros</returns>
        public async Task<List<Category>> GetCategories()
        {
            List<Category> categories = categoryBusiness.GetCategories();
            return categories;
        }

        /// <summary>
        /// Método que agrega en registro de la entidad
        /// </summary>
        public async Task AddCategory(Category category)
        {
            categoryBusiness.AddCategory(category);
        }

        /// <summary>
        /// Método que actualiza en registro de la entidad
        /// </summary>
        public async Task<Category> UpdateCategory(Guid ID, string JCategory)
        {
            Category cat = categoryBusiness.UpdateCategory(ID, JCategory);
            return cat;
        }

        /// <summary>
        /// Método que elimina en registro de la entidad
        /// </summary>
        public async Task DeleteCategory(Guid ID)
        {
            categoryBusiness.DeleteCategory(ID);
        }

        /// <summary>
        /// Atributo que me permite determinar si la instancia debe cerrarse.
        /// </summary>
        private bool disposedValue = false;

        /// <summary>
        /// Método que me permite cerrar la instancia del proxy
        /// </summary>
        /// <param name="disposing"></param>
        protected virtual void Dispose(bool disposing)
        {
            if (!disposedValue)
            {
                if (disposing)
                {
                    this.categoryBusiness = null;
                }

                this.categoryBusiness = null;

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