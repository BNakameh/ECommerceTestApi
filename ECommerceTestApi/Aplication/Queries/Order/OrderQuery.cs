using AutoMapper;
using ECommerceTestApi.Infrastructure;
using ECommerceTestApi.Infrastructure.DataModel;
using ECommerceTestApi.Models.Order;
using StoreakApiService.Core.Context;
using StoreakApiService.Core.Responses;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace ECommerceTestApi.Aplication.Queries.Order
{
    public class OrderQuery
    {
        #region Properties And Constractor

        private IMapper _mapper;
        private UnitOfWork _unitOfWork;
        private ResponseMessages _responsMessages;

        public OrderQuery(IResponseMessages responsMessages,
                         UnitOfWork unitOfWork,
                         IMapper mapper)
        {
            _responsMessages = responsMessages as ResponseMessages;
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }
        #endregion

        public async Task<CustomResponse> GetAll(SearchOrder searchorder)
        {
            var result = await _unitOfWork.Orderpository
                                          .GetAll()
                                          .Where(entity => entity.SerialNum == searchorder.SerialNum)
                                          .GetPagedAsync<OrderDto, GetAllOrderModel>(searchorder.pagingParams, _mapper);
            return new OkResponse(result);
        }

        public async Task<CustomResponse> Get(Guid id)
        {
            var data = await _unitOfWork.Orderpository.FindAsync(id);
            if (data is null)
            {
                return _responsMessages.NotFound;
            }

            var result = _mapper.Map<GetOrderModel>(data);

            return new OkResponse(result);
        }
    }
}
