using AutoMapper;
using ECommerceTestApi.Infrastructure;
using ECommerceTestApi.Models.Category;
using StoreakApiService.Core.Responses;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace ECommerceTestApi.Aplication.Queries.Category
{
    public class CategoryQuery
    {
        #region Properties And Constractor

        private IMapper _mapper;
        private UnitOfWork _unitOfWork;
        private ResponseMessages _responsMessages;

        public CategoryQuery(IResponseMessages responsMessages,
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
            var data = _unitOfWork.CategoryRepository.GetAll()
                                                     .Where(par => !par.ChildCategoryId.HasValue)
                                                     .ToList()
                                                     .Select(par => new GetAllCategoryModel()
                                                     {
                                                         Id = par.Id,
                                                         Name = par.Name,
                                                         GetSecondLevelCategories = _unitOfWork.CategoryRepository.GetAll()
                                                                                                                 .Where(levl1 => levl1.LevelDeep == 2 && levl1.ChildCategoryId.Value == par.Id)
                                                                                                                 .ToList()
                                                                                                                 .Select(levl1 => new GetSecondLevelCategoryModel()
                                                                                                                 {
                                                                                                                     Id = levl1.Id,
                                                                                                                     Name = levl1.Name,
                                                                                                                     GetThirdLevelCategories = _unitOfWork.CategoryRepository.GetAll()
                                                                                                                                                                            .Where(levl2 => levl2.LevelDeep == 3 && levl2.ChildCategoryId.Value == levl2.Id)
                                                                                                                                                                            .ToList()
                                                                                                                                                                            .Select(levl2 => new GetThirdLevelCategoryModel()
                                                                                                                                                                            {
                                                                                                                                                                                Id = levl2.Id,
                                                                                                                                                                                Name = levl2.Name
                                                                                                                                                                            })
                                                                                                                 })


                                                     });
            return new OkResponse(data);
        }

        public async Task<CustomResponse> Get(Guid id)
        {
            var data = await _unitOfWork.CategoryRepository.FindAsync(id);
            if (data is null)
            {
                return _responsMessages.NotFound;
            }

            var result = _mapper.Map<GetCategoryModel>(data);

            return new OkResponse(result);
        }
    }
}
