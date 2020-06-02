using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;

using DevExtreme.AspNet.Data;
using DevExtreme.AspNet.Mvc;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using PeriferiaData.Models;
using PeriferiaUIService;
using WebAppDevExpress.Models;

namespace WebAppDevExpress.Controllers
{
    public class DataMasterController : Controller
    {
        /// <summary>
        /// Servicio de categoría
        /// </summary>
        private ICategoryService categoryService;

        public DataMasterController(ICategoryService _categoryService)
        {
            categoryService = _categoryService;
        }

        public IActionResult Index()
        {
            return View();
        }

        /// <summary>
        /// Metodo que retorna la lista de registros para la rejilla de categorías
        /// </summary>
        /// <param name="loadOptions">Opciones de rejilla</param>
        /// <returns></returns>
        [HttpGet]
        public async Task<object> ReadCategory(DataSourceLoadOptions loadOptions)
        {
            try
            {
                List<Category> categories = new List<Category>();
                categories = await categoryService.GetCategories();
                return DataSourceLoader.Load(categories, loadOptions);
            }
            catch (Exception err)
            {
                throw new ApplicationException("error", err);
            }
        }

        /// <summary>
        /// Método que inserta un nuevo registro en la categoría
        /// </summary>
        /// <param name="values">Valores</param>
        /// <returns></returns>
        [HttpPost]
        public async Task<IActionResult> InsertCategory(string values)
        {
            try
            {
                var newCategory = new Category();
                JsonConvert.PopulateObject(values, newCategory);
                newCategory.CategoryId = Guid.NewGuid();
                await categoryService.AddCategory(newCategory);

                return Ok(newCategory);
            }
            catch (Exception err)
            {
                throw new ApplicationException("error", err);
            }
        }

        /// <summary>
        /// Método que actualiza registros de categoria
        /// </summary>
        /// <param name="key">ID</param>
        /// <param name="values">Valores a actualizar</param>
        /// <returns></returns>
        [HttpPut]
        public async Task<IActionResult> UpdateCategory(Guid key, string values)
        {
            try
            {
                Category cat = await categoryService.UpdateCategory(key, values);

                return Ok(cat);
            }
            catch (Exception err)
            {
                throw new ApplicationException("error", err);
            }
        }

        /// <summary>
        /// Método que elimina registros de la categoría
        /// </summary>
        /// <param name="key">Llave Primaria</param>
        /// <returns></returns>

        [HttpDelete]
        public async Task DeleteCategory(Guid key)
        {
            try
            {
                await categoryService.DeleteCategory(key);
            }
            catch (Exception err)
            {
                throw new ApplicationException("error", err);
            }
        }
    }
}