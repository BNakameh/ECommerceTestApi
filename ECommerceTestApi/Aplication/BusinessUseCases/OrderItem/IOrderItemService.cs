using ECommerceTestApi.Models.OrderItem;
using StoreakApiService.Core.Responses;
using System;
using System.Threading.Tasks;

namespace ECommerceTestApi.Aplication.BusinessUseCases.OrderItem
{
    public interface IOrderItemService
    {
        Task<CustomResponse> Update(Guid id, ActionOrderItemModel request);
        Task<CustomResponse> Delete(Guid id);
    }
}
