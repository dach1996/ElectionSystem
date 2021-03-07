using log4net;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.IO;
using System.Reflection;
using System.Text;
using System.Xml;

namespace Dach.ElectionSystem.Services.Logger
{
    /// <summary>
    /// Clase Logger personalizada
    /// </summary>
    public class LoggerCustom : ILoggerCustom
    {
        private readonly IConfiguration _configuration;
        private readonly string _pathLogConfigFile;
        private readonly ILog _log;
        public LoggerCustom(IConfiguration configuration)
        {
            _configuration = configuration;
            _pathLogConfigFile = @"log4net.config";
            _log = LogManager.GetLogger(typeof(LoggerCustom));
            this.SetLog4NetConfiguration();
        }

        public void WriteLoggerDebug(string logModule, string message, string logName = null)
        {
            _log.DebugFormat("{0} - {1}", logModule, message);
        }

        public void WriteLoggerError(string logModule, string message, string logName = null)
        {
            _log.ErrorFormat("{0} - {1}", logModule, message);
        }

        public void WriteLoggerInfo(string logModule, string message, string logName = null)
        {
            _log.InfoFormat("{0} - {1}", logModule, message);
        }

        public void WriteLoggerWarning(string logModule, string message, string logName = null)
        {
            _log.WarnFormat("{0} - {1}", logModule, message);
        }

        private void SetLog4NetConfiguration()
        {
            try
            {
                XmlDocument log4netConfig = new XmlDocument();
                log4netConfig.Load(File.OpenRead(_pathLogConfigFile));
                var repo = LogManager.CreateRepository(
                Assembly.GetEntryAssembly(), typeof(log4net.Repository.Hierarchy.Hierarchy));
                log4net.Config.XmlConfigurator.Configure(repo, log4netConfig["log4net"]);
            }
            catch (Exception)
            {
                throw new Exception("Error al Cargar Log4net");
            }
        }

    }
}
