using System;
using Dxc.Pace.Infrastructure.Core.HttpClient.Contracts;
using Dxc.Pace.Infrastructure.Core.HttpClient.Policy;

namespace Dxc.Pace.Orchestrator.Client.DependencyInjection.Models
{
    public class OrchestratorClientOptions
    {
        private const string NotSetErrorMessage = "{0} is not set. Invoke options. Use {0} method to set I{0} implementation.";

        public Type JwtTokenProvider { get; private set; }
        public Type LogCorrelationIdProvider { get; private set; }
        public Type TracerProvider { get; private set; }
        public Type PolicyHandlingProvider { get; private set; }

        public OrchestratorClientOptions UsePolicyHandlingProvider<TPolicyHandlingProvider>()
            where TPolicyHandlingProvider : IPolicyHandlingProvider
        {
            PolicyHandlingProvider = typeof(TPolicyHandlingProvider);
            return this;
        }

        public OrchestratorClientOptions UseTracerProvider<TTracingHandlerProvider>()
            where TTracingHandlerProvider : ITracingHandlerProvider
        {
            TracerProvider = typeof(TTracingHandlerProvider);
            return this;
        }

        public OrchestratorClientOptions UseJwtTokenProvider<TJwtTokenProvider>()
            where TJwtTokenProvider : IJwtTokenProvider
        {
            JwtTokenProvider = typeof(TJwtTokenProvider);
            return this;
        }

        public OrchestratorClientOptions UseLogCorrelationIdProvider<TLogCorrelationIdProvider>()
            where TLogCorrelationIdProvider : ILogCorrelationIdProvider
        {
            LogCorrelationIdProvider = typeof(TLogCorrelationIdProvider);
            return this;
        }

        public void Validate()
        {
            AssertProviderIsSet(JwtTokenProvider, nameof(JwtTokenProvider));
            AssertProviderIsSet(LogCorrelationIdProvider, nameof(LogCorrelationIdProvider));
            AssertProviderIsSet(TracerProvider, nameof(TracerProvider));
            AssertProviderIsSet(PolicyHandlingProvider, nameof(PolicyHandlingProvider));
        }

        private void AssertProviderIsSet(Type providerType, string providerName)
        {
            if (providerType == null)
            {
                throw new InvalidOperationException(string.Format(NotSetErrorMessage, providerName));
            }
        }
    }
}
