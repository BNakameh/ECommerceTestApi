using AutoMapper;
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

        private readonly IMapper _mapper;
        private readonly ResponseMessages _responsMessages;
        private readonly UnitOfWork _unitOfWork;

        public CategoryService(IMapper mapper,
                               IResponseMessages responsMessages,
                               UnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
            _responsMessages = responsMessages as ResponseMessages;
        }
        #endregion

        #region Methods

        public async Task<CustomResponse> Create(ActionCategoryModel request)
        {
            var NumOfChild = _unitOfWork.CategoryRepository.GetAll().Count(x => request.ChildCategoryId.HasValue && x.ChildCategoryId.Value == request.ChildCategoryId.Value);
            if (NumOfChild > 0)
            {
                return _responsMessages.ColdNotAddChildMore;
            }

            var entity = _mapper.Map<CategoryDto>(request);
            _unitOfWork.CategoryRepository.Add(entity);

            await _unitOfWork.SaveChangesAsync();

            return _responsMessages.AddedSuccessfully;
        }

        public async Task<CustomResponse> Update(Guid id, ActionCategoryModel request)
        {
            var entity = _unitOfWork.CategoryRepository.Find(id);

            if (entity is null)
            {
                return _responsMessages.NotFound;
            }

            var NumOfChild = _unitOfWork.CategoryRepository.GetAll().Count(x => request.ChildCategoryId.HasValue && x.ChildCategoryId.Value == request.ChildCategoryId.Value);
            if (NumOfChild > 0)
            {
                return _responsMessages.ColdNotAddChildMore;
            }

            entity.Name = request.Name;
            entity.ChildCategoryId = request.ChildCategoryId.Value;

            await _unitOfWork.SaveChangesAsync();

            return _responsMessages.UpdatedSuccessfully;
        }

        public async Task<CustomResponse> Delete(Guid id)
        {
            var entity = _unitOfWork.CategoryRepository.Find(id);

            if (entity is null)
            {
                return _responsMessages.NotFound;
            }

            var NumOfChild = _unitOfWork.CategoryRepository.GetAll().Count(x => x.ChildCategoryId == id);
            if (NumOfChild > 0)
            {
                return _responsMessages.ColdNotAddChildMore;
            }

            _unitOfWork.CategoryRepository.Remove(entity);
            await _unitOfWork.SaveChangesAsync();

            return _responsMessages.DeletedSuccessfully;
        }
        #endregion

    }
}
