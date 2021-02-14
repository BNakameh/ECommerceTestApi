using ECommerceTestApi.Aplication.Queries.Report;
using ECommerceTestApi.Controllers;
using Microsoft.AspNetCore;
using Microsoft.AspNetCore.Hosting;
using System;

namespace Storeak.Demo.Api
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var startTimeSpan = TimeSpan.Zero;
            var periodTimeSpan = TimeSpan.FromMinutes(60);

            var timer = new System.Threading.Timer((e) =>
            {
                ReportQuery.GetReportOrder();
                ReportQuery.GetReportItem();
            }, null, startTimeSpan, periodTimeSpan);
        }

        public static IWebHostBuilder CreateWebHostBuilder(string[] args) =>
            WebHost.CreateDefaultBuilder(args)
                .UseStartup<Startup>();

        
    }
}
