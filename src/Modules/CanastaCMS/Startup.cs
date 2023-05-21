using CanastaCMS.Drivers;
using CanastaCMS.Handlers;
using CanastaCMS.Migrations;
using CanastaCMS.Models;
using Fluid;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Routing;
using Microsoft.Extensions.DependencyInjection;
using OrchardCore.ContentManagement;
using OrchardCore.ContentManagement.Display.ContentDisplay;
using OrchardCore.Data.Migration;
using OrchardCore.Modules;

namespace CanastaCMS
{
    public class Startup : StartupBase
    {
        public override void ConfigureServices(IServiceCollection services)
        {
            services
                .AddContentPart<ResultPart>()
                .UseDisplayDriver<ResultPartDisplayDriver>()
                .AddHandler<ResultPartHandler>();
            services.AddScoped<IDataMigration, ResultMigrations>();
        }

        public override void Configure(IApplicationBuilder builder, IEndpointRouteBuilder routes, IServiceProvider serviceProvider)
        {
            routes.MapAreaControllerRoute(
                name: "Home",
                areaName: "CanastaCMS",
                pattern: "Home/Index",
                defaults: new { controller = "Home", action = "Index" }
            );

            routes.MapAreaControllerRoute(
                name: "ResultController",
                areaName: "CanastaCMS",
                pattern: "Result/List",
                defaults: new { controller = "Result", action = "List" }
            );
        }
    }
}
