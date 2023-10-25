using System;
using Dxc.Pace.Orchestrator.Client.DependencyInjection.Models;
using Dxc.Pace.Infrastructure.Core.HttpClient.Contracts;
using Dxc.Pace.Infrastructure.Core.HttpClient.Policy;
using Microsoft.Extensions.DependencyInjection;
using Dxc.Pace.Infrastructure.Core.HttpClient.Extensions;

namespace Dxc.Pace.Orchestrator.Client.DependencyInjection
{
    public static class DependencyInjectionExtensions
    {
        public static IServiceCollection AddOrchestratorClient(this IServiceCollection services, Action<OrchestratorClientOptions> configurator = null)
        {
            if (configurator != null)
                Register(services, configurator);

            services.AddScoped<IServiceName, ServiceName>();

            services.RegisterAllClients(typeof(DependencyInjectionExtensions).Assembly);

            return services;
        }

        private static void Register(IServiceCollection services, Action<OrchestratorClientOptions> configurator)
        {
            var options = new OrchestratorClientOptions();
            configurator(options);
            options.Validate();

            services.AddScoped(provider => options);

            services.AddScoped(typeof(IJwtTokenProvider), options.JwtTokenProvider);
            services.AddScoped(typeof(ILogCorrelationIdProvider), options.LogCorrelationIdProvider);

            services.AddSingleton(typeof(ITracingHandlerProvider), options.TracerProvider);
            services.AddSingleton(typeof(IPolicyHandlingProvider), options.PolicyHandlingProvider);

            services.RegisterAllClients(typeof(DependencyInjectionExtensions).Assembly);
        }
    }
}
