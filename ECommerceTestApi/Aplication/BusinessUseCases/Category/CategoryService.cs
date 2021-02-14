using ECommerceTestApi.Infrastructure;
using ECommerceTestApi.Infrastructure.DataModel;
using ECommerceTestApi.Models.Category;
using StoreakApiService.Core.Responses;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace ECommerceTestApi.Aplication.BusinessUseCases.Category
{
    public class CategoryService : ICategoryService
    {
        #region Properties And Constructor

        private readonly ResponseMessages _responsMessages;
        private readonly UnitOfWork _unitOfWork;

        public CategoryService(
                               IResponseMessages responsMessages,
                               UnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
            _responsMessages = responsMessages as ResponseMessages;
        }
        #endregion

        #region Methods

        public async Task<CustomResponse> Create(ActionCategoryModel request)
        {
            var NumOfChild = 0;
            if (request.ChildCategoryId.HasValue)
            {
                var entity = _unitOfWork.CategoryRepository.Find(request.ChildCategoryId.Value);

                if (entity is null)
                {
                    return _responsMessages.NotFound;
                }
                NumOfChild = _unitOfWork.CategoryRepository.Find(request.ChildCategoryId.Value).LevelDeep;
            }
            if (NumOfChild > 2)
            {
                return _responsMessages.ColdNotAddChildMore;
            }

            try
            {
                var entity = new CategoryDto()
                {
                    Name = request.Name,
                    ChildCategoryId = request.ChildCategoryId,
                    LevelDeep = NumOfChild + 1
                };

                _unitOfWork.CategoryRepository.Add(entity);

                await _unitOfWork.SaveChangesAsync();

                return new OkResponse(entity.Id);
            }
            catch
            {
                return _responsMessages.NotFound;
            }

        }

        public async Task<CustomResponse> Update(Guid id, ActionCategoryModel request)
        {
            var entity = _unitOfWork.CategoryRepository.Find(id);

            if (entity is null)
            {
                return _responsMessages.NotFound;
            }

            var NumOfChild = request.ChildCategoryId.HasValue ? _unitOfWork.CategoryRepository.Find(request.ChildCategoryId.Value).LevelDeep : 1;
            if (NumOfChild > 2)
            {
                return _responsMessages.ColdNotAddChildMore;
            }

            entity.Name = request.Name;
            entity.ChildCategoryId = request.ChildCategoryId.Value;
            entity.LevelDeep = NumOfChild;

            await _unitOfWork.SaveChangesAsync();

            return _responsMessages.UpdatedSuccessfully;
        }

        public async Task<CustomResponse> Delete(Guid id)
        {
            try
            {
                var entity = _unitOfWork.CategoryRepository.Find(id);
                if (entity is null)
                {
                    return _responsMessages.NotFound;
                }

                if (entity.Items.Any())
                {
                    return _responsMessages.DeletedFaield;
                }

                var isParent = _unitOfWork.CategoryRepository.GetAll().Any(x => x.ChildCategoryId.Value == id);
                if (isParent)
                {
                    return _responsMessages.DeletedFaield;
                }

                _unitOfWork.CategoryRepository.Remove(entity);
                await _unitOfWork.SaveChangesAsync();

                return _responsMessages.DeletedSuccessfully;
            }
            catch
            {
                return _responsMessages.DeletedFaield;
            }
        }
        #endregion
    }
}
