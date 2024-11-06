using System;
using System.Collections.Generic;
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
        public static readonly string ARG_HIRED = "--hired";
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
            Log.Debug("Found string argument '{0}'", argName);
            for (int i = 0; i < _args.Length; i++)
            {
                if (string.Compare(_args[i], argName, ignoreCase: true) == 0)
                {
                    if (i + 1 > _args.Length - 1)
                    {
                        Log.Debug("Argument '{0}' found without value", argName);
                        return null;
                    }
                    Log.Debug("String argument '{0}' was found", argName);
                    return _args[i+1];
                }
            }
            Log.Debug("String argument '{0}' was NOT found", argName);
            return null;
        }
    }
}
