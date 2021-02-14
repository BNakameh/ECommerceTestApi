using ECommerceTestApi.Models.Item;
using StoreakApiService.Core.Responses;
using System;
using System.Threading.Tasks;

namespace ECommerceTestApi.Aplication.BusinessUseCases.Item
{
    public interface IItemService
    {
        Task<CustomResponse> Create(ActionItemModel request);
        Task<CustomResponse> Update(Guid id, ActionItemModel request);
        Task<CustomResponse> Delete(Guid id);
    }
}
