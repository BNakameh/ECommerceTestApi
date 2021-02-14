using ECommerceTestApi.Aplication;
using ECommerceTestApi.Aplication.BusinessUseCases.Category;
using ECommerceTestApi.Aplication.BusinessUseCases.Item;
using ECommerceTestApi.Aplication.BusinessUseCases.Order;
using ECommerceTestApi.Aplication.BusinessUseCases.OrderItem;
using ECommerceTestApi.Aplication.Queries.Category;
using ECommerceTestApi.Aplication.Queries.Item;
using ECommerceTestApi.Aplication.Queries.Order;
using ECommerceTestApi.Aplication.Queries.OrderItem;
using ECommerceTestApi.Infrastructure;
using ECommerceTestApi.MapperProfile;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using StoreakApiService.Core.Helper;
using StoreakApiService.Core.Projects;
using StoreakApiService.Core.Responses;

namespace Storeak.Demo.Api
{
    public class Startup : StoreakApiService.Core.Startup
    {
        public Startup(IConfiguration configuration, IHostingEnvironment env, IApplicationBuilder app)
            : base(configuration, env)
        {
            ApiProjectSettings.ProjectId = ProjectNames.demo;
            ApiProjectSettings.UseSession = true;
            ApiProjectSettings.Databasename = "ECommerceTestDB";

            ApiProjectSettings.EnvironmentType = ProjectEnvironmentType.LocalHost;
            ApiProjectSettings.UsePostFix = false;
            ApisUrl.LoadUrls(ProjectEnvironmentType.TestProduction);
            ApiProjectSettings.UseCache = false;
        }

        public override void ConfigureServices(IServiceCollection services)
        {
            base.ConfigureServices(services);

            #region Mapper Profiles

            base.ConfigureAutoMapper(services, new CategoryProfile());

            base.ConfigureAutoMapper(services, new ItemProfile());

            base.ConfigureAutoMapper(services, new OrderProfile());

            base.ConfigureAutoMapper(services, new OrderItemProfile());
            #endregion

            #region Services

            services.AddScoped<UnitOfWork>();

            services.AddScoped<ICategoryService, CategoryService>();
            services.AddScoped<CategoryQuery>();

            services.AddScoped<IItemService, ItemService>();
            services.AddScoped<ItemQuery>();

            services.AddScoped<IOrderService, OrderService>();
            services.AddScoped<OrderQuery>();

            services.AddScoped<IOrderItemService, OrderItemService>();
            services.AddScoped<OrderItemQuery>();


            services.AddSingleton<IResponseMessages, ResponseMessages>();
            #endregion

            base.ConfigureDatabase<ECommerceTestApiContext>(services);
        }
    }
}
