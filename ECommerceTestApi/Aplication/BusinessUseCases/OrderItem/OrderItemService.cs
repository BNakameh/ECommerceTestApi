using ECommerceTestApi.Infrastructure;
using ECommerceTestApi.Models.OrderItem;
using StoreakApiService.Core.Responses;
using System;
using System.Threading.Tasks;

namespace ECommerceTestApi.Aplication.BusinessUseCases.OrderItem
{
    public class OrderItemService : IOrderItemService
    {
        #region Properties And Constructor

        private readonly ResponseMessages _responsMessages;
        private readonly UnitOfWork _unitOfWork;

        public OrderItemService(
                           IResponseMessages responsMessages,
                           UnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
            _responsMessages = responsMessages as ResponseMessages;
        }
        #endregion

        #region Methods

        public async Task<CustomResponse> Delete(Guid id)
        {
            try
            {
                var entity = _unitOfWork.OrderItempository.Find(id);
                if (entity is null)
                {
                    return _responsMessages.NotFound;
                }

                _unitOfWork.OrderItempository.Remove(entity);
                await _unitOfWork.SaveChangesAsync();

                var itemEntity = _unitOfWork.ItemRepository.Find(entity.Id);

                itemEntity.Count += entity.Count;

                await _unitOfWork.SaveChangesAsync();

                return _responsMessages.DeletedSuccessfully;
            }
            catch
            {
                return _responsMessages.DeletedFaield;
            }
        }

        public async Task<CustomResponse> Update(Guid id, ActionOrderItemModel request)
        {
            try
            {
                var entity = _unitOfWork.OrderItempository.Find(id);

                var itemEntity = _unitOfWork.ItemRepository.Find(entity.ItemId);

                if (request.Count > itemEntity.Count && request.Count - entity.Count >= 0)
                {
                    return _responsMessages.UpdatedFaield;
                }

                itemEntity.Count += request.Count - entity.Count;
                entity.Count = request.Count;

                await _unitOfWork.SaveChangesAsync();
                return _responsMessages.UpdatedSuccessfully;

            }
            catch
            {
                return _responsMessages.UpdatedFaield;
            }
        }
        #endregion
    }
}
