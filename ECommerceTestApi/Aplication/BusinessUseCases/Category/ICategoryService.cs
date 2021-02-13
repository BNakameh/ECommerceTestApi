using ECommerceTestApi.Models.Category;
using StoreakApiService.Core.Responses;
using System;
using System.Threading.Tasks;

namespace ECommerceTestApi.Aplication.BusinessUseCases.Category
{
    public interface ICategoryService
    {
        Task<CustomResponse> Create(ActionCategoryModel request);
        Task<CustomResponse> Update(Guid id, ActionCategoryModel request);
        Task<CustomResponse> Delete(Guid id);
    }
}
