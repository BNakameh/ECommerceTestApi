using ECommerceTestApi.Aplication;
using ECommerceTestApi.Aplication.BusinessUseCases.Category;
using ECommerceTestApi.Aplication.Queries.Category;
using ECommerceTestApi.Infrastructure;
using ECommerceTestApi.MapperProfile;
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
        public Startup(IConfiguration configuration, IHostingEnvironment env)
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
            #endregion

            #region Services

            services.AddScoped<UnitOfWork>();

            services.AddScoped<ICategoryService, CategoryService>();
            services.AddScoped<CategoryQuery>();

            services.AddSingleton<IResponseMessages, ResponseMessages>();
            #endregion

            base.ConfigureDatabase<ECommerceTestApiContext>(services);
        }
    }
}
