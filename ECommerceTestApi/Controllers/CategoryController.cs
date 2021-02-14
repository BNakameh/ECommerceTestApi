using ECommerceTestApi.Aplication.BusinessUseCases.Category;
using ECommerceTestApi.Aplication.Queries.Category;
using ECommerceTestApi.Models.Category;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using StoreakApiService.Core.Attributes;
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

        [Route("api/v1/Categories")]
        [HttpGet]
        [ApiDocumentation("a19d0fe8-4bf9-4c0c-934d-37f9a8cbb4b6", "Get All Category With Children.")]
        public IActionResult GetAll()
        {
            var result = _categoryQuery.GetAll();
            return result;
        }

        [Route("api/v1/Categories")]
        [HttpGet]
        [ApiDocumentation("a19d0fe8-4bf9-4c0c-934d-37f9a8cbb4b6", "Get Category By Id.")]
        public async Task<IActionResult> Get(Guid id)
        {
            return await _categoryQuery.Get(id);
        }

        [Authorize]
        [ClaimRequirement(ClaimTypes.Role, "StoreAdmin")]
        [Route("api/v1/Categories")]
        [HttpPost]
        [ApiDocumentation("a19d0fe8-4bf9-4c0c-934d-37f9a8cbb4b6", "Create New Category.")]
        public async Task<IActionResult> Create([FromBody] ActionCategoryModel model)
        {
            return await ICategoryService.Create(model);
        }

        [Authorize]
        [ClaimRequirement(ClaimTypes.Role, "StoreAdmin")]
        [Route("api/v1/Categories/{id}")]
        [HttpPut]
        [ApiDocumentation("a19d0fe8-4bf9-4c0c-934d-37f9a8cbb4b6", "Update Category.")]
        public async Task<IActionResult> Update(Guid id, [FromBody] ActionCategoryModel model)
        {
            return await ICategoryService.Update(id, model);
        }

        [Authorize]
        [ClaimRequirement(ClaimTypes.Role, "StoreAdmin")]
        [Route("api/v1/Categories/{id}")]
        [HttpDelete]
        [ApiDocumentation("a19d0fe8-4bf9-4c0c-934d-37f9a8cbb4b6", "Delete  Category.")]
        public async Task<ActionResult> Delete(Guid id)
        {
            return await ICategoryService.Delete(id);
        }
    }
}