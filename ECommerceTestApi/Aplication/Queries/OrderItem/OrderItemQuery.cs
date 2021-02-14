using AutoMapper;
using ECommerceTestApi.Infrastructure;
using ECommerceTestApi.Models.OrderItem;
using StoreakApiService.Core.Responses;

namespace ECommerceTestApi.Aplication.Queries.OrderItem
{
    public class OrderItemQuery
    {
        #region Properties And Constractor

        private IMapper _mapper;
        private UnitOfWork _unitOfWork;
        private ResponseMessages _responsMessages;

        public OrderItemQuery(IResponseMessages responsMessages,
                         UnitOfWork unitOfWork,
                         IMapper mapper)
        {
            _responsMessages = responsMessages as ResponseMessages;
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }
        #endregion

        public CustomResponse GetAll()
        {
            var data = _unitOfWork.OrderItempository.GetAll();
            var result = _mapper.Map<GetAllOrderItemModel>(data);

            return new OkResponse(result);
        }
    }
}
