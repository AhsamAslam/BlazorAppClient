using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Microsoft.JSInterop;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MyCommunityBuilder.Client.Helpers
{
    public class ConsoleLoggerProvider : ILoggerProvider
    {
        private readonly IServiceCollection _services;
        ILogger _logger;
        public ConsoleLoggerProvider(IServiceCollection services)
        {
            _services = services ?? throw new ArgumentNullException(nameof(services));
        }

        public ILogger CreateLogger(string categoryName)
        {
            if (_logger != null)
            {
                return _logger;
            }

            using var provider = _services.BuildServiceProvider();
            var jsRuntime = provider.GetRequiredService<IJSRuntime>();
            _logger = new ConsoleLogger(jsRuntime);
            return _logger;
        }

        public void Dispose()
        {
            // nothing to dispose.
        }
    }
}
