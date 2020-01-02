﻿using System;
using System.Net;
using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;

namespace ProxyKit.Recipes
{
    public class RoundRobinLoadBalancer
    {
        public class Startup
        {
            public void ConfigureServices(IServiceCollection services)
            {
                //Client timeouts if upstream host doesn't respond in 5 seconds
                services.AddProxy(
                    httpClientBuilder => httpClientBuilder
                        .ConfigureHttpClient(client => client.Timeout = TimeSpan.FromSeconds(5))); 
            }

            public void Configure(IApplicationBuilder app)
            {
                var roundRobin = new RoundRobin
                {
                    new UpstreamHost("http://localhost:5001", weight: 1),
                    new UpstreamHost("http://localhost:5002", weight: 2)
                };

                app.RunProxy(
                    async context =>
                    {
                        var host = roundRobin.Next();

                        var response = await context
                            .ForwardTo(host)
                            .AddXForwardedHeaders()
                            .Send();

                        // failover
                        if (response.StatusCode == HttpStatusCode.ServiceUnavailable)
                        {
                            return await context
                                .ForwardTo(host)
                                .AddXForwardedHeaders()
                                .Send();
                        }

                        return response;
                    });
            }
        }
    }
}