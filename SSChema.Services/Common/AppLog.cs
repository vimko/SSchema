using System;
using System.Collections.Generic;
using System.Text;
using NLog;

namespace SSChema.Services.Common
{
    class AppLog
    {
        private static Logger logger;

        //private AppLog()
        //{
        //    logger = LogManager.GetLogger("AppLog");
        //}

        public static Logger CreateAppLog()
        {
            if (logger == null)
                logger = LogManager.GetLogger("applog");

            return AppLog.logger;
        }
    }
}
