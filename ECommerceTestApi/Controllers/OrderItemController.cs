using ECommerceTestApi.Aplication.BusinessUseCases.OrderItem;
using ECommerceTestApi.Aplication.Queries.OrderItem;
using ECommerceTestApi.Models.OrderItem;
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
    public class OrderItemController : StoreakController
    {
        private IOrderItemService IOrderItemService { get; }
        private readonly OrderItemQuery _orderItemQuery;

        public OrderItemController(OrderItemQuery orderItemQuery,
                                   IOrderItemService iOrderItemService)
        {
            _orderItemQuery = orderItemQuery;
            IOrderItemService = iOrderItemService;
        }

        [Authorize]
        [ClaimRequirement(ClaimTypes.Role, "StoreAdmin")]
        [Route("api/v1/OrderItems")]
        [HttpGet]
        [ApiDocumentation("a19d0fe8-4bf9-4c0c-934d-37f9a8cbb4b6", "Get All Order Item.")]
        public IActionResult GetAll()
        {
            return _orderItemQuery.GetAll();
        }

        [Authorize]
        [ClaimRequirement(ClaimTypes.Role, "StoreAdmin")]
        [Route("api/v1/OrderItems/{id}")]
        [HttpPut]
        [ApiDocumentation("a19d0fe8-4bf9-4c0c-934d-37f9a8cbb4b6", "Update Order Item.")]
        public async Task<IActionResult> Update(Guid id, [FromBody] ActionOrderItemModel model)
        {
            return await IOrderItemService.Update(id, model);
        }

        [Authorize]
        [ClaimRequirement(ClaimTypes.Role, "StoreAdmin")]
        [Route("api/v1/Items/{id}")]
        [HttpDelete]
        [ApiDocumentation("a19d0fe8-4bf9-4c0c-934d-37f9a8cbb4b6", "Delete  Item.")]
        public async Task<ActionResult> Delete(Guid id)
        {
            return await IOrderItemService.Delete(id);
        }
    }
}
