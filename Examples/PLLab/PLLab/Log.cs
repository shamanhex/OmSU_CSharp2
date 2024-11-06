using NLog;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PLLab
{
    public static class Log
    {
        private static Logger Logger = LogManager.GetCurrentClassLogger();

        private static bool IsVerbose = ArgParser.HasArg(ArgParser.ARG_VERBOSE);

        public static void Debug(string message, params object[] args)
        {
            if (!IsVerbose)
            {
                return;
            }
            Logger.Debug(string.Format(message, args));
        }

        public static void Info(string message, params object[] args)
        {
            Logger.Info(string.Format(message, args));
        }

        public static void Error(string message, params object[] args)
        {
            Logger.Error(string.Format(message, args));
        }
    }
}
