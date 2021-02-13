using ECommerceTestApi.Infrastructure;
using ECommerceTestApi.Models.Category;
using StoreakApiService.Core.Responses;
using System.Linq;

namespace ECommerceTestApi.Aplication.Queries.Category
{
    public class CategoryQuery
    {
        #region Properties And Constractor

        private  UnitOfWork _unitOfWork;
        private ResponseMessages _responsMessages;

        public CategoryQuery(IResponseMessages responsMessages,
                             UnitOfWork unitOfWork)
        {
            _responsMessages = responsMessages as ResponseMessages;
            _unitOfWork = unitOfWork;
        }
        #endregion


        public CustomResponse GetAllCategoryWithChild()
        {

            return new OkResponse("");
        }
    }
}
