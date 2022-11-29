using Microsoft.AspNetCore.Mvc.Testing;
using Microsoft.Extensions.DependencyInjection;
using RestSharpTest.Base;

namespace RestSharpTest
{
    public class Startup
    {
        public static void ConfigureServices(IServiceCollection services)
        {
            services
                .AddSingleton<IRest>(new Rest(new WebApplicationFactory<GraphQLProductApp.Startup>()))
                .AddScoped<IRestFactory, RestFactory>()
                .AddScoped<IRestBuilder, RestBuilder>();
        }
    }
}
