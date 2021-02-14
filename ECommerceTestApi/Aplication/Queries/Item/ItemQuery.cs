using AutoMapper;
using ECommerceTestApi.Infrastructure;
using ECommerceTestApi.Infrastructure.DataModel;
using ECommerceTestApi.Models.Item;
using StoreakApiService.Core.Context;
using StoreakApiService.Core.Responses;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace ECommerceTestApi.Aplication.Queries.Item
{
    public class ItemQuery
    {
        #region Properties And Constractor

        private IMapper _mapper;
        private UnitOfWork _unitOfWork;
        private ResponseMessages _responsMessages;

        public ItemQuery(IResponseMessages responsMessages,
                         UnitOfWork unitOfWork,
                         IMapper mapper)
        {
            _responsMessages = responsMessages as ResponseMessages;
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }
        #endregion

        public async Task<CustomResponse> GetAll(SearchItem searchItem)
        {
            var result = await _unitOfWork.ItemRepository
                                          .GetAll()
                                          .Where(entity => entity.Name == searchItem.Name && entity.Count == searchItem.Count && entity.SellPrice == searchItem.SellPrice)
                                          .GetPagedAsync<ItemDto, GetItem>(searchItem.pagingParams, _mapper);
            return new OkResponse(result);
        }

        public async Task<CustomResponse> Get(Guid id)
        {
            var data = await _unitOfWork.ItemRepository.FindAsync(id);
            if (data is null)
            {
                return _responsMessages.NotFound;
            }

            var result = _mapper.Map<GetItem>(data);

            return new OkResponse(result);
        }
    }
}