using ECommerceTestApi.Infrastructure;
using ECommerceTestApi.Infrastructure.DataModel;
using ECommerceTestApi.Models.Item;
using StoreakApiService.Core.Responses;
using System;
using System.Threading.Tasks;

namespace ECommerceTestApi.Aplication.BusinessUseCases.Item
{
    public class ItemService : IItemService
    {
        #region Properties And Constructor

        private readonly ResponseMessages _responsMessages;
        private readonly UnitOfWork _unitOfWork;

        public ItemService(
                           IResponseMessages responsMessages,
                           UnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
            _responsMessages = responsMessages as ResponseMessages;
        }
        #endregion

        #region Methods

        public async Task<CustomResponse> Create(ActionItemModel request)
        {
            try
            {
                var entity = new ItemDto()
                {
                    Name = request.Name,
                    Count = request.Count,
                    SellPrice = request.SellPrice,
                    BuyPrice = request.BuyPrice,
                    CategoryId = request.CategoryId
                };

                _unitOfWork.ItemRepository.Add(entity);
                await _unitOfWork.SaveChangesAsync();

                return new OkResponse(entity.Id);
            }
            catch
            {
                return _responsMessages.GlobalInternalServerError();
            }
        }

        public async Task<CustomResponse> Delete(Guid id)
        {

            try
            {
                var entity = _unitOfWork.ItemRepository.Find(id);
                if (entity is null)
                {
                    return _responsMessages.NotFound;
                }

                _unitOfWork.ItemRepository.Remove(entity);
                await _unitOfWork.SaveChangesAsync();


                return _responsMessages.DeletedSuccessfully;
            }
            catch
            {
                return _responsMessages.DeletedFaield;
            }


        }

        public async Task<CustomResponse> Update(Guid id, ActionItemModel request)
        {
            try
            {
                var entity = _unitOfWork.ItemRepository.Find(id);

                if (entity is null)
                {
                    return _responsMessages.NotFound;
                }

                entity.Name = request.Name;
                entity.BuyPrice = request.BuyPrice;
                entity.SellPrice = request.SellPrice;
                entity.Count = request.Count;
                entity.CategoryId = request.CategoryId;

                await _unitOfWork.SaveChangesAsync();

                return new OkResponse(entity.Id);
            }
            catch
            {
                return _responsMessages.GlobalInternalServerError();
            }
        }
        #endregion
    }
}
