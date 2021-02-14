using ECommerceTestApi.Infrastructure;
using ECommerceTestApi.Infrastructure.DataModel;
using StoreakApiService.Core.Context;
using System.Threading.Tasks;

namespace ECommerceTestApi.Aplication
{
    public class UnitOfWork
    {
        #region Properties And Constructor

        private readonly ECommerceTestApiContext _context;

        public UnitOfWork(ECommerceTestApiContext context)
        {
            _context = context;
        }
        #endregion

        #region Repositories

        public GenericRepository<CategoryDto> CategoryRepository
        {
            get
            {
                return new GenericRepository<CategoryDto>(_context.Categories);
            }
        }

        public GenericRepository<ItemDto> ItemRepository
        {
            get
            {
                return new GenericRepository<ItemDto>(_context.Items);
            }
        }

        public GenericRepository<OrderDto> Orderpository
        {
            get
            {
                return new GenericRepository<OrderDto>(_context.Orders);
            }
        }

        public GenericRepository<OrderItemDto> OrderItempository
        {
            get
            {
                return new GenericRepository<OrderItemDto>(_context.OrderItems);
            }
        }

        #endregion

        #region Save Changes Methods

        public void SaveChanges()
        {
            _context.SaveChanges();
        }

        public async Task SaveChangesAsync()
        {
            await _context.SaveChangesAsync();
        }
        #endregion
    }
}
