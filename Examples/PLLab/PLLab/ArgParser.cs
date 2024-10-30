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


        private static string[] _args = null;

        static ArgParser()
        {
            _args = Environment.GetCommandLineArgs();
        }

        public static void SetArgs(params string[] args)
        {
            _args = args;
        }
        
        public static bool HasArg(string argName) 
        {
            for (int i = 0; i < _args.Length; i++)
            {
                if (string.Compare(_args[i], argName, ignoreCase:true) == 0)
                    return true;
            }
            return false;
        }

        public static string GetArgAsString(string argName)
        {
            for (int i = 0; i < _args.Length; i++)
            {
                if (string.Compare(_args[i], argName, ignoreCase: true) == 0)
                {
                    if (i + 1 > _args.Length - 1)
                        return null;
                    return _args[i+1];
                }
            }
            return null;
        }
    }
}
