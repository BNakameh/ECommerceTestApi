using ECommerceTestApi.Models.Order;
using StoreakApiService.Core.Responses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ECommerceTestApi.Aplication.BusinessUseCases.Order
{
    public interface IOrderService
    {
        Task<CustomResponse> Create(ActionOrderModel request);
        Task<CustomResponse> Update(Guid id, long storId);
        Task<CustomResponse> Delete(Guid id);
    }
}
