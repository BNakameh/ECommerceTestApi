using ECommerceTestApi.Aplication.BusinessUseCases.Category;
using ECommerceTestApi.Aplication.Queries.Category;
using ECommerceTestApi.Models.Category;
using Microsoft.AspNetCore.Mvc;
using StoreakApiService.Core.Controllers;
using StoreakApiService.Core.Security;
using System;
using System.Security.Claims;
using System.Threading.Tasks;

namespace ECommerceTestApi.Controllers
{
    public class CategoryController : StoreakController
    {
        private ICategoryService ICategoryService { get; }
        private readonly CategoryQuery _categoryQuery;

        public CategoryController(CategoryQuery categoryQuery,
                                  ICategoryService icategoryService)
        {
            _categoryQuery = categoryQuery;
            ICategoryService = icategoryService;
        }

        [HttpGet]
        [Route("api/v1/Category/GetAllCategoryWithChildren")]
        public IActionResult GetAllCategoryWithChildren()
        {
            var result = _categoryQuery.GetAllCategoryWithChild();
            return result;
        }

        [ClaimRequirement(ClaimTypes.Role, "StoreAdmin")]
        [HttpPost]
        [Route("api/v1/Category/Create")]
        public async Task<IActionResult> Create([FromBody] ActionCategoryModel model)
        {
            return await ICategoryService.Create(model);
        }

        [ClaimRequirement(ClaimTypes.Role, "StoreAdmin")]
        [HttpPut]
        [Route("api/v1/Category/Update")]
        public async Task<IActionResult> Update(Guid id, [FromBody] ActionCategoryModel model)
        {
            return await ICategoryService.Update(id, model);
        }

        [ClaimRequirement(ClaimTypes.Role, "StoreAdmin")]
        [Route("api/v1/Employees/{id}")]
        [HttpDelete]
        public async Task<ActionResult> Delete(Guid id)
        {
            return await ICategoryService.Delete(id);
        }
    }
}