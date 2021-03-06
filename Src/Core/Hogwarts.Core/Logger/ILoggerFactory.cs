namespace Hogwarts.Core.Logger
{
    using Microsoft.Extensions.Logging;
    using System;

    public interface ILoggerFactory : IDisposable
    {
        ILogger CreateLogger(string categoryName);
        void AddProvider(ILoggerProvider provider);
    }
}
