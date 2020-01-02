﻿using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;

namespace ProxyKit.Recipes
{
    public class CustomiseUpstreamResponse
    {
        public class Startup
        {
            public void ConfigureServices(IServiceCollection services)
            {
                services.AddProxy();
            }

            public void Configure(IApplicationBuilder app)
            {
                app.RunProxy(async context =>
                {
                    var response = await context
                        .ForwardTo("http://localhost:5001")
                        .AddXForwardedHeaders()
                        .Send();

                    response.Headers.Remove("MachineID");

                    return response;
                });
            }
        }
    }
}
