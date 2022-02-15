using Microsoft.Extensions.Logging;
using Microsoft.JSInterop;
using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Threading.Tasks;

namespace MyCommunityBuilder.Client.Helpers
{
    public class ConsoleLogger : ILogger
    {
        private readonly IJSRuntime _jsRuntime;

        public ConsoleLogger(IJSRuntime jsRuntime)
        {
            _jsRuntime = jsRuntime ?? throw new ArgumentNullException(nameof(jsRuntime));
        }

        public IDisposable BeginScope<TState>(TState state)
        {
            return NoOpDisposable.Instance;
        }

        public bool IsEnabled(LogLevel logLevel)
        {
            return logLevel >= LogLevel.Warning;
        }

        public void Log<TState>(LogLevel logLevel, EventId eventId, TState state, Exception exception, Func<TState, Exception, string> formatter)
        {
            var formattedMessage = formatter(state, exception);
            switch (logLevel)
            {
                case LogLevel.Critical:
                case LogLevel.Error:
                    _jsRuntime.InvokeVoidAsync("console.error", formattedMessage);
                    break;
                case LogLevel.Warning:
                    _jsRuntime.InvokeVoidAsync("console.warn", formattedMessage);
                    break;
                case LogLevel.Information:
                    _jsRuntime.InvokeVoidAsync("console.info", formattedMessage);
                    break;
                case LogLevel.Trace:
                case LogLevel.Debug:
                    _jsRuntime.InvokeVoidAsync("console.debug", formattedMessage);
                    break;
                default:
                    _jsRuntime.InvokeVoidAsync("console.log", formattedMessage);
                    break;
            }
        }

        [SuppressMessage("Major Code Smell", "S3881:\"IDisposable\" should be implemented correctly", Justification = "From default console logger")]
        [SuppressMessage("Critical Code Smell", "S2223:Non-constant static fields should not be visible", Justification = "From default console logger")]
        [SuppressMessage("Critical Code Smell", "S1186:Methods should not be empty", Justification = "From default console logger")]
        private class NoOpDisposable : IDisposable
        {
            public static NoOpDisposable Instance = new NoOpDisposable();

            public void Dispose() { }
        }
    }
}
