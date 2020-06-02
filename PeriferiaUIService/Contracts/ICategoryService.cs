using PeriferiaData.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace PeriferiaUIService
{
    public interface ICategoryService
    {
        /// <summary>
        /// Método que consulta todos los registros de la entidad
        /// </summary>
        /// <returns>Lista de registros</returns>
        public Task<List<Category>> GetCategories();

        /// <summary>
        /// Método que agrega en registro de la entidad
        /// </summary>
        public Task AddCategory(Category category);

        /// <summary>
        /// Método que actualiza en registro de la entidad
        /// </summary>
        public Task<Category> UpdateCategory(Guid ID, string JCategory);

        /// <summary>
        /// Método que elimina en registro de la entidad
        /// </summary>
        public Task DeleteCategory(Guid ID);
    }
}