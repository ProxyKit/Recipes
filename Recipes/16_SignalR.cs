﻿using System;
using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;

namespace ProxyKit.Recipes
{
    public class SignalR
    {
        public class Startup
        {
            public void ConfigureServices(IServiceCollection services)
            {
                services.AddProxy();
            }

            public void Configure(IApplicationBuilder app)
            {
                // must first be able to handle incoming websocket requests
                app.UseWebSockets();

                // SignalR, as part of it's protocol, needs both http and ws traffic
                // to be forwarded to the servers hosting signalr hubs.
                app.UseWebSocketProxy(context => new Uri("ws://upstream-host:80"));
                app.RunProxy(context => context
                    .ForwardTo(new Uri($"http://localhost:80"))
                    .AddXForwardedHeaders()
                    .Send());
            }
        }
    }
}
