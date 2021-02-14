using AutoMapper;
using ECommerceTestApi.Infrastructure;
using ECommerceTestApi.Models.Item;
using ECommerceTestApi.Models.Order;
using StoreakApiService.Core.Responses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ECommerceTestApi.Aplication.Queries.Report
{
    public static class ReportQuery
    {
        #region Properties And Constractor

        private static IMapper _mapper;
        private static UnitOfWork _unitOfWork;

        
        #endregion

        public static CustomResponse GetReportOrder()
        {
            var data = _unitOfWork.Orderpository.GetAll();
            var result = _mapper.Map<GetAllOrderModel>(data);

            return new OkResponse(result);
        }

        public static CustomResponse GetReportItem()
        {
            var date = new GetItemReportModel();

            date.SellPrice = _unitOfWork.OrderItempository.GetAll().Select(entity => entity.Item.SellPrice).ToList();
            date.BuyPrice = _unitOfWork.OrderItempository.GetAll().Select(entity => entity.Item.BuyPrice).ToList();
            date.Count = _unitOfWork.OrderItempository.GetAll().Select(entity => entity.Count).ToList();

            return new OkResponse(date);
        }
    }
}
