using ECommerceTestApi.Infrastructure.DataModel;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using StoreakApiService.Core.Context;

namespace ECommerceTestApi.Infrastructure
{
    public class ECommerceTestApiContext : StoreDbContext
    {
        #region Constructor

        public ECommerceTestApiContext(IHttpContextAccessor accessor)
           : base(accessor)
        {
        }
        #endregion

        #region DbSet

        public virtual  DbSet<CategoryDto> Categories { get; set; }
        public virtual DbSet<ItemDto> Items { get; set; }
        public virtual DbSet<OrderDto> Orders { get; set; }
        public virtual DbSet<OrderItemDto> OrderItems { get; set; }
        #endregion

        #region Method Helper

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {

            modelBuilder.Entity<OrderItemDto>().HasQueryFilter(x =>
              EF.Property<long>(x, "StoreId") == Client.StoreId);

            modelBuilder.Entity<OrderDto>().HasQueryFilter(x =>
             EF.Property<long>(x, "StoreId") == Client.StoreId);

            modelBuilder.Entity<ItemDto>().HasQueryFilter(x =>
            EF.Property<long>(x, "StoreId") == Client.StoreId);

            modelBuilder.Entity<CategoryDto>().HasQueryFilter(x =>
            EF.Property<long>(x, "StoreId") == Client.StoreId);

            base.OnModelCreating(modelBuilder);
        }
        #endregion
    }
}
