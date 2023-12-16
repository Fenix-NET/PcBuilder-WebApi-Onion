using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Core.Interfaces;
using Serilog;

namespace Infrastructure.LoggerService
{
    public class LoggerManager : ILoggerManager
    {
        private static ILogger _logger = Log.Logger;

        public LoggerManager()
        {

        }
        public void LogDebug(string message) => _logger.Debug(message); 
        public void LogError(string message) => _logger.Error(message); 
        public void LogInfo(string message) => _logger.Information(message); 
        public void LogWarn(string message) => _logger.Warning(message);
    }
}
