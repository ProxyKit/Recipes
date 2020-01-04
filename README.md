# ProxyKit Recipes

![Image](logo.png)

Recipes are code samples that help you create proxy solutions for your needs.
If you have any ideas for a recipe, or can spot any improvements to the ones
below, please send a pull request! Recipes that stand test of time may be
promoted to an out-of-the-box feature in a future version of ProxyKit.

<!-- TOC depthFrom:2 -->

- [1. Simple Forwarding](#1-simple-forwarding)
- [2. Proxy Paths](#2-proxy-paths)
- [3. Claims Based Tenant Routing](#3-claims-based-tenant-routing)
- [4. Authentication offloading with Identity Server](#4-authentication-offloading-with-identity-server)
- [5. Weighted Round Robin Load Balancing](#5-weighted-round-robin-load-balancing)
- [6. In-memory Testing](#6-in-memory-testing)
- [7. Customise Upstream Requests](#7-customise-upstream-requests)
- [8. Customise Upstream Responses](#8-customise-upstream-responses)
- [9. Consul Service Discovery](#9-consul-service-discovery)
- [10. Copy X-Forwarded Headers](#10-copy-x-forwarded-headers)
- [11. Caching Upstream Responses with CacheCow](#11-caching-upstream-responses-with-cachecow)
- [12. Conditional Proxying](#12-conditional-proxying)
- [13. Client Certificate](#13-client-certificate)
- [14. Source IP Blocking](#14-source-ip-blocking)
- [15. WebSockets](#15-websockets)
- [16. SignalR](#16-signalr)
- [17. SignalR with Path](#17-signalr-with-path)
- [18. Automatic Decompression](#18-automatic-decompression)

<!-- /TOC -->

Recipes are code samples that help you create proxy solutions for your needs.
If you have any ideas for a recipe, or can spot any improvements to the ones
below, please send a pull request! Recipes that stand test of time may be
promoted to an out-of-the-box feature in a future version of ProxyKit.

## 1. Simple Forwarding

Forward request to a single upstream host.

[Recipes/01_Simple.cs](Recipes/01_Simple.cs)

## 2. Proxy Paths

Hosting multiple proxies on separate paths.

[Recipes/02_Paths.cs](Recipes/02_Paths.cs)

## 3. Claims Based Tenant Routing

Routing to a specific upstream host based on a `TenantId` claim for an
authenticated user.

[Recipes/03_TenantRouting.cs](Recipes/03_TenantRouting.cs)

## 4. Authentication offloading with Identity Server

Using [IdentityServer](https://identityserver.io/) to handle authentication
before forwarding to upstream host.

[Recipes/04_IdSrv.cs](Recipes/04_IdSrv.cs)

## 5. Weighted Round Robin Load Balancing

Weighted Round Robin load balancing to two upstream hosts.

[Recipes/05_RoundRobin.cs](Recipes/05_RoundRobin.cs)

## 6. In-memory Testing

Testing behaviour or your ASP.NET Core application by running two instances
behind round robin proxy. Really useful if your application has eventually
consistent aspects.

[Recipes/06_Testing.cs](Recipes/06_Testing.cs)

## 7. Customise Upstream Requests

Customise the upstream request by adding a header.

[Recipes/07_CustomiseUpstreamRequest.cs](Recipes/07_CustomiseUpstreamRequest.cs)

## 8. Customise Upstream Responses

Customise the upstream response by removing a header.

[Recipes/08_CustomiseUpstreamResponse.cs](Recipes/08_CustomiseUpstreamResponse.cs)

## 9. Consul Service Discovery

Service discovery for an upstream host using [Consul](https://www.consul.io/).

[Recipes/09_ConsulServiceDisco.cs](Recipes/09_ConsulServiceDisco.cs)

## 10. Copy X-Forwarded Headers

Copies `X-Forwarded-For`, `X-Forwarded-Host`, `X-Forwarded-Proto` and
`X-Forwarded-PathBase` headers from the incoming request. Typically only done
when the proxy is in a chain of known proxies. Is it NOT recommended that you
blindly accept these headers from the public Internet.

[Recipes/10_CopyXForwarded.cs](Recipes/10_CopyXForwarded.cs)

## 11. Caching Upstream Responses with CacheCow

Using [CacheCow.Client](https://github.com/aliostad/CacheCow) to cache responses
from upstream servers using standard HTTP caching headers.

[Recipes/11_CachingWithCacheCow.cs](Recipes/11_CachingWithCacheCow.cs)

## 12. Conditional Proxying

Using `app.UseWhen()` to conditionally forward the request based on asserting a
value on `HttpContext`.

[Recipes/12_ConditionalProxying.cs](Recipes/12_ConditionalProxying.cs)

## 13. Client Certificate

Using a client certificate in requests to upstream hosts.

[Recipes/13_ClientCertificate.cs](Recipes/13_ClientCertificate.cs)

## 14. Source IP Blocking

Block requests from sources whose IP addresses is not allowed.

[Recipes/14_SourceIPBlocking.cs](Recipes/14_SourceIPBlocking.cs)

## 15. WebSockets

How to proxy WebSocket connections.

[Recipes/14_WebSockets.cs](Recipes/15_WebSockets.cs)

## 16. SignalR

Proxying for SignalR whose protocol requires both HTTP and WebSocket forwarding
to upstream hosts.

[Recipes/16_SignalR.cs](Recipes/16_SignalR.cs)

## 17. SignalR with Path

Proxying for SignalR on a specific path.

[Recipes/17_SignalROnPath.cs](Recipes/17_SignalROnPath.cs)

## 18. Automatic Decompression

Automatic decompression of responses from upstream hosts allowing response body
manipulation.

[Recipes/18_AutomaticDecompression.cs](Recipes/18_AutomaticDecompression.cs)
