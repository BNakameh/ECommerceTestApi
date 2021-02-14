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
            get { return _responsesManager.GetResponce("NotFound"); }
        }

        public CustomResponse UpdatedSuccessfully
        {
            get { return _responsesManager.GetResponce("UpdatedSuccessfully"); }
        }

        public CustomResponse UpdatedFaield
        {
            get { return _responsesManager.GetResponce("UpdatedFaield"); }
        }

        public CustomResponse AddedSuccessfully
        {
            get { return _responsesManager.GetResponce("AddedSuccessfully"); }
        }

        public CustomResponse AddedFaield
        {
            get { return _responsesManager.GetResponce("AddedFaield"); }
        }

        public CustomResponse DeletedSuccessfully
        {
            get { return _responsesManager.GetResponce("DeletedSuccessfully"); }
        }

        public CustomResponse DeletedFaield
        {
            get { return _responsesManager.GetResponce("DeletedFaield"); }
        }

        public CustomResponse ColdNotAddChildMore
        {
            get { return _responsesManager.GetResponce("ColdNotAddChildMore"); }
        }



        public CustomResponse ColdNotAddOrderWithoutItems
        {
            get { return _responsesManager.GetResponce("ColdNotAddOrderWithoutItems"); }
        }



        public CustomResponse GlobalInternalServerError()
        {
            return _responsesManager.GetResponce("InternalServerError");
        }
    }
}