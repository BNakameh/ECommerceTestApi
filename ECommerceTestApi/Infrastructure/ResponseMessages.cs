using ECommerceTestApi.SharedResources;
using StoreakApiService.Core.Responses;

namespace ECommerceTestApi.Infrastructure
{
    public class ResponseMessages : IResponseMessages
    {
        IResponsesManager _responsesManager;

        public ResponseMessages(IResponsesManager responsesManager)
        {
            _responsesManager = responsesManager;
        }

        public CustomResponse NotFound
        {
            get { return _responsesManager.GetResponce(ResponseResource.NotFound); }
        }

        public CustomResponse UpdatedSuccessfully
        {
            get { return _responsesManager.GetResponce(ResponseResource.UpdatedSuccessfully); }
        }

        public CustomResponse AddedSuccessfully
        {
            get { return _responsesManager.GetResponce(ResponseResource.AddedSuccessfully); }
        }

        public CustomResponse DeletedSuccessfully
        {
            get { return _responsesManager.GetResponce(ResponseResource.DeletedSuccessfully); }
        }

        public CustomResponse ColdNotAddChildMore
        {
            get { return _responsesManager.GetResponce(ResponseResource.ColdNotAddChildMore); }
        }

        public CustomResponse GlobalInternalServerError()
        {
            return _responsesManager.GetResponce(ResponseResource.InternalServerError);
        }
    }
}