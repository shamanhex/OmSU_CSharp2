using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PLLab
{
    //ex01.exe --name "Ivanov I.I." --version
    //"--name", "Ivanov I.I.", "--version"
    public static class ArgParser
    {
        public static readonly string ARG_NAME = "--name";
        public static readonly string ARG_COUNT = "--count";
        public static readonly string ARG_RELEASE = "--release";

        public static readonly string ARG_ADD = "--add";
        public static readonly string ARG_LIST = "--list";
        public static readonly string ARG_SHOW = "--show";
        public static readonly string ARG_UPDATE = "--update";
        public static readonly string ARG_REMOVE = "--remove";

        public static readonly string ARG_VERBOSE = "--verbose";


        private static string[] _args = null;

        static ArgParser()
        {
            _args = Environment.GetCommandLineArgs();
            Log.Debug("Loaded {0} args from command line", _args.Length);
            Log.Debug("Args loaded: "+String.Join(';', _args));
        }

        public static void SetArgs(params string[] args)
        {
            _args = args;
            Log.Debug("Loaded {0} args", _args.Length);
            Log.Debug("Args loaded: " + String.Join(';', _args));
        }
        
        public static bool HasArg(string argName)
        {
            Log.Debug("Check arg '{0}'", argName);
            for (int i = 0; i < _args.Length; i++)
            {
                if (string.Compare(_args[i], argName, ignoreCase: true) == 0)
                {
                    Log.Debug("Arg '{0}' was found", argName);
                    return true;
                }
            }
            Log.Debug("Arg '{0}' was NOT found", argName);
            return false;
        }

        public static string GetArgAsString(string argName)
        {
            return GetArgAsString(argName, true, null);
        }

        public static string GetArgAsStringOrDefault(string argName, string defaultValue)
        {
            return GetArgAsString(argName, false, defaultValue);
        }

        public static string GetArgAsString(string argName, bool isRequired, string defaultValue)
        {
            Log.Debug("Found string argument '{0}'", argName);
            for (int i = 0; i < _args.Length; i++)
            {
                if (string.Compare(_args[i], argName, ignoreCase: true) == 0)
                {
                    if (i + 1 > _args.Length - 1)
                    {
                        if (isRequired)
                        {
                            Log.Error("Argument '{0}' found without value", argName);
                            throw new InvalidOperationException(string.Format("ERROR: String argument '{0}' found without value", argName));
                        }
                        else
                        {
                            return defaultValue;
                        }
                    }
                    Log.Debug("String argument '{0}' was found", argName);
                    return _args[i+1];
                }
            }
            if (isRequired)
            {
                Log.Error("ERROR: String argument '{0}' was NOT found", argName);
                throw new InvalidOperationException(string.Format("ERROR: String argument '{0}' was NOT found", argName));
            }
            else
            {
                return defaultValue;
            }
        }

        internal static double GetArgAsDouble(string argName)
        {
            Log.Debug("Found string argument '{0}'", argName);
            for (int i = 0; i < _args.Length; i++)
            {
                if (string.Compare(_args[i], argName, ignoreCase: true) == 0)
                {
                    if (i + 1 > _args.Length - 1)
                    {
                        Log.Debug("Argument '{0}' found without value", argName);
                        return 0;
                    }
                    Log.Debug("String argument '{0}' was found", argName);
                    string sValue = _args[i + 1];
                    double value;
                    if (!Double.TryParse(sValue, out value))
                    {
                        Log.Error("ERROR: Argument '{0}'. Incorrect number format of value '{1}'.", argName, sValue);
                        throw new InvalidOperationException(string.Format("ERROR: Argument '{0}'. Incorrect number format of value '{1}'.", argName, sValue));
                    }
                    return value;
                }
            }
            Log.Error("ERROR: Argument '{0}' was NOT found", argName);
            throw new InvalidOperationException(string.Format("ERROR: Argument '{0}' was NOT found", argName));
        }

        public static DateTime GetArgAsDateTimeOrDefault(string argName, DateTime defaultValue = default(DateTime))
        {
            return GetArgAsDateTime(argName, false, defaultValue);
        }

        public static DateTime GetArgAsDateTime(string argName)
        {
            return GetArgAsDateTime(argName, true);
        }

        public static DateTime GetArgAsDateTime(string argName, bool isRequired, DateTime defaultValue = default(DateTime))
        {
            Log.Debug("Found string argument '{0}'", argName);
            for (int i = 0; i < _args.Length; i++)
            {
                if (string.Compare(_args[i], argName, ignoreCase: true) == 0)
                {
                    if (i + 1 > _args.Length - 1)
                    {
                        Log.Debug("Argument '{0}' found without value", argName);
                        return defaultValue;
                    }
                    Log.Debug("String argument '{0}' was found", argName);
                    string sValue = _args[i + 1];
                    DateTime value;
                    if (!DateTime.TryParseExact(sValue, "dd.MM.yyyy", CultureInfo.InvariantCulture, DateTimeStyles.None, out value))
                    {
                        Log.Error("ERROR: Argument '{0}'. Incorrect date format of value '{1}'.", argName, sValue);
                        throw new InvalidOperationException(string.Format("ERROR: Argument '{0}'. Incorrect date format of value '{1}'.", argName, sValue));
                    }
                    return value;
                }
            }
            if (isRequired)
            {
                Log.Error("ERROR: Argument '{0}' was NOT found", argName);
                throw new InvalidOperationException(string.Format("ERROR: Argument '{0}' was NOT found", argName));
            }
            else
            {
                Log.Debug("Argument '{0}' was NOT found", argName);
                return defaultValue;
            }
        }
    }
}
