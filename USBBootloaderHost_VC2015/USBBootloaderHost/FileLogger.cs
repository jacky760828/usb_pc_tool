using System;
using System.Collections.Generic;
using System.Text;
using System.IO;
using log4net;

namespace USBBootloaderHost
{
    public class FileLogger
    {
        #region "Private Data Members"

        private bool _enableLog = false;
        private ILog _infologger;

        #endregion // Private Data Members

        #region "Ctors"

        private static FileLogger instance = null;

        public static FileLogger Instance
        {
            get
            {
                return instance ?? new FileLogger();
            }
        }

        private FileLogger()
        {
            instance = this;
        }

        public void initFileLogger(string ConfigFilename, string LogPattern, bool EnableLog)
        {
            log4net.Config.XmlConfigurator.ConfigureAndWatch(new FileInfo(ConfigFilename));
            _infologger = LogManager.GetLogger(LogPattern);
            _enableLog = EnableLog;
        }

        public FileLogger(string ConfigFilename, string LogPattern, bool EnableLog)
            : this()
        {
            log4net.Config.XmlConfigurator.ConfigureAndWatch(new FileInfo(ConfigFilename));
            _infologger = LogManager.GetLogger(LogPattern);
            _enableLog = EnableLog;
        }

        #endregion // Ctors.

        public void WriteLog(string Log)
        {
            if (_enableLog == false) return;
            _infologger.Info(Log);
        }

        public void d(string tag, string log)
        {
            WriteLog(tag + ": " + log);
        }

        public bool EnableLog
        {
            get { return _enableLog; }
            set { _enableLog = true; }
        }
    }
}
