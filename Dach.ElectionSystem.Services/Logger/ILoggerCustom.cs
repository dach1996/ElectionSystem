using System;
using System.Collections.Generic;
using System.Text;

namespace Dach.ElectionSystem.Services.Logger
{
    public interface ILoggerCustom
    {
        public void WriteLoggerWarning(string logModule, string message, string logName = null);
        public void WriteLoggerError(string logModule, string message, string logName = null);
        public void WriteLoggerInfo(string logModule, string message, string logName = null);
        public void WriteLoggerDebug(string logModule, string message, string logName = null);
    }
}
