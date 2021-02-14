using ECommerceTestApi.Aplication.BusinessUseCases.Item;
using ECommerceTestApi.Aplication.Queries.Item;
using ECommerceTestApi.Models.Item;
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
    public class ItemController : StoreakController
    {
        private IItemService IItemService { get; }
        private readonly ItemQuery _itemQuery;

        public ItemController(ItemQuery itemQuery,
                              IItemService iItemService)
        {
            _itemQuery = itemQuery;
            IItemService = iItemService;
        }

        [Route("api/v1/Items")]
        [HttpGet]
        [ApiDocumentation("a19d0fe8-4bf9-4c0c-934d-37f9a8cbb4b6", "Get All Item By Paging.")]
        public async Task<IActionResult> GetAll([FromBody] SearchItem searchItem)
        {
            return await _itemQuery.GetAll(searchItem);
        }

        [Route("api/v1/Items")]
        [HttpGet]
        [ApiDocumentation("a19d0fe8-4bf9-4c0c-934d-37f9a8cbb4b6", "Get Item By Id.")]
        public async Task<IActionResult> Get(Guid id)
        {
            return await _itemQuery.Get(id);
        }

        [Authorize]
        [ClaimRequirement(ClaimTypes.Role, "StoreAdmin")]
        [Route("api/v1/Items")]
        [HttpPost]
        [ApiDocumentation("a19d0fe8-4bf9-4c0c-934d-37f9a8cbb4b6", "Create New Item.")]
        public async Task<IActionResult> Create([FromBody] ActionItemModel model)
        {
            return await IItemService.Create(model);
        }

        [Authorize]
        [ClaimRequirement(ClaimTypes.Role, "StoreAdmin")]
        [Route("api/v1/Items/{id}")]
        [HttpPut]
        [ApiDocumentation("a19d0fe8-4bf9-4c0c-934d-37f9a8cbb4b6", "Update Item.")]
        public async Task<IActionResult> Update(Guid id, [FromBody] ActionItemModel model)
        {
            return await IItemService.Update(id, model);
        }

        [Authorize]
        [ClaimRequirement(ClaimTypes.Role, "StoreAdmin")]
        [Route("api/v1/Items/{id}")]
        [HttpDelete]
        [ApiDocumentation("a19d0fe8-4bf9-4c0c-934d-37f9a8cbb4b6", "Delete  Item.")]
        public async Task<ActionResult> Delete(Guid id)
        {
            return await IItemService.Delete(id);
        }
    }
}
