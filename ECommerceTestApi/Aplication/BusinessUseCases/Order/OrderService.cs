using ECommerceTestApi.Infrastructure;
using ECommerceTestApi.Infrastructure.DataModel;
using ECommerceTestApi.Models.Order;
using StoreakApiService.Core.Responses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ECommerceTestApi.Aplication.BusinessUseCases.Order
{
    public class OrderService : IOrderService
    {
        #region Properties And Constructor

        private readonly ResponseMessages _responsMessages;
        private readonly UnitOfWork _unitOfWork;

        public OrderService(
                           IResponseMessages responsMessages,
                           UnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
            _responsMessages = responsMessages as ResponseMessages;
        }
        #endregion

        #region Methods

        public async Task<CustomResponse> Create(ActionOrderModel request)
        {
            bool allRight = true;
            if (!request.OrderItems.Any())
            {
                return _responsMessages.ColdNotAddOrderWithoutItems;
            }
            var dic = new Dictionary<Guid, long>();

            foreach (var item in request.OrderItems)
            {
                if (dic.ContainsKey(item.ItemId)) dic[item.ItemId] += item.Count;
                else dic.Add(item.ItemId, item.Count);
            }

            foreach (var itemDic in dic)
            {
                var c = _unitOfWork.ItemRepository.Find(itemDic.Key);
                var countEntity = _unitOfWork.ItemRepository.Find(itemDic.Key).Count;
                allRight &= itemDic.Value <= countEntity;
            }

            if (!allRight)
            {
                return _responsMessages.AddedFaield;
            }

            try
            {
                var entity = new OrderDto()
                {
                    SerialNum = request.SerialNum
                };

                entity.OrderDate = DateTime.Now;

                _unitOfWork.Orderpository.Add(entity);
                await _unitOfWork.SaveChangesAsync();

                foreach (var itemDic in dic)
                {
                    var countEntity = _unitOfWork.ItemRepository.Find(itemDic.Key);
                    countEntity.Count -= itemDic.Value;

                    await _unitOfWork.SaveChangesAsync();
                }

                foreach (var itemDic in dic)
                {
                    var orderItemEntity = new OrderItemDto()
                    {
                        ItemId = itemDic.Key,
                        OrderId = entity.Id,
                        Count = itemDic.Value
                    };

                    _unitOfWork.OrderItempository.Add(orderItemEntity);
                    await _unitOfWork.SaveChangesAsync();
                }

                return new OkResponse(entity.Id);
            }
            catch
            {
                return _responsMessages.AddedFaield;
            }
        }

        public async Task<CustomResponse> Delete(Guid id)
        {
            try
            {
                var entity = _unitOfWork.Orderpository.Find(id);
                if (entity is null)
                {
                    return _responsMessages.NotFound;
                }

                _unitOfWork.Orderpository.Remove(entity);
                await _unitOfWork.SaveChangesAsync();

                var orderItemEntities = _unitOfWork.OrderItempository.GetAll().Where(x => x.OrderId == id);


                foreach (var record in orderItemEntities)
                {
                    _unitOfWork.OrderItempository.Remove(record);
                    await _unitOfWork.SaveChangesAsync();
                }

                return _responsMessages.DeletedSuccessfully;
            }
            catch
            {
                return _responsMessages.DeletedFaield;
            }
        }

        public async Task<CustomResponse> Update(Guid id, long storId)
        {
            try
            {
                var entity = _unitOfWork.Orderpository.Find(id);

                if (entity is null)
                {
                    return _responsMessages.NotFound;
                }

                if (storId != entity.StoreId)
                {
                    return _responsMessages.NotFound;
                }

                _unitOfWork.Orderpository.Remove(entity);
                await _unitOfWork.SaveChangesAsync();

                var orderItemEntities = _unitOfWork.OrderItempository.GetAll().Where(x => x.OrderId == id);


                foreach (var record in orderItemEntities)
                {
                    _unitOfWork.OrderItempository.Remove(record);
                    await _unitOfWork.SaveChangesAsync();
                }

                return _responsMessages.DeletedSuccessfully;
            }
            catch
            {
                return _responsMessages.GlobalInternalServerError();
            }
        }
        #endregion

    }
}
