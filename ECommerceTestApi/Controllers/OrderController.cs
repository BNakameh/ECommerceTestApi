using ECommerceTestApi.Aplication.BusinessUseCases.Order;
using ECommerceTestApi.Aplication.Queries.Order;
using ECommerceTestApi.Models.Order;
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
    public class OrderController : StoreakController
    {
        private IOrderService IOrderService { get; }
        private readonly OrderQuery _orderQuery;

        public OrderController(IOrderService iOrderService,
                              OrderQuery orderQuery)
        {
            _orderQuery = orderQuery;
            IOrderService = iOrderService;
        }

        [Route("api/v1/Orders")]
        [HttpGet]
        [ApiDocumentation("a19d0fe8-4bf9-4c0c-934d-37f9a8cbb4b6", "Get All Order By Paging.")]
        public async Task<IActionResult> GetAll([FromBody] SearchOrder searchItem)
        {
            return await _orderQuery.GetAll(searchItem);
        }

        [Route("api/v1/Orders")]
        [HttpGet]
        [ApiDocumentation("a19d0fe8-4bf9-4c0c-934d-37f9a8cbb4b6", "Get Order By Id.")]
        public async Task<IActionResult> Get(Guid id)
        {
            return await _orderQuery.Get(id);
        }

        [Authorize]
        [ClaimRequirement(ClaimTypes.Role, "Customer")]
        [Route("api/v1/Orders")]
        [HttpPost]
        [ApiDocumentation("a19d0fe8-4bf9-4c0c-934d-37f9a8cbb4b6", "Create New Order.")]
        public async Task<IActionResult> Create([FromBody] ActionOrderModel model)
        {
            return await IOrderService.Create(model);
        }

        [Authorize]
        [ClaimRequirement(ClaimTypes.Role, "Customer")]
        [Route("api/v1/Orders/{id}")]
        [HttpPut]
        [ApiDocumentation("a19d0fe8-4bf9-4c0c-934d-37f9a8cbb4b6", "Cancel Order.")]
        public async Task<IActionResult> Update(Guid id)
        {
            var storId = ApplicationClient.StoreId;
            return await IOrderService.Update(id, storId);
        }

        [Authorize]
        [ClaimRequirement(ClaimTypes.Role, "StoreAdmin")]
        [Route("api/v1/Orders/{id}")]
        [HttpDelete]
        [ApiDocumentation("a19d0fe8-4bf9-4c0c-934d-37f9a8cbb4b6", "Delete  Order.")]
        public async Task<ActionResult> Delete(Guid id)
        {
            return await IOrderService.Delete(id);
        }
    }
}
