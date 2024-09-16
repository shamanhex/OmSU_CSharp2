namespace Ex01
{
    public class Program
    {
        public static int Main(string[] args)
        {
            string name = ArgParser.GetArgAsString(ArgParser.ARG_NAME);

            if (name == null)
            {
                Console.WriteLine("ERROR: Please, specify --name");
                return 1;
            }

            Console.WriteLine("Hello, {0}!", name);

            if (ArgParser.HasArg(ArgParser.ARG_VERSION))
            {
                Console.WriteLine("1.0");
            }

            return 0;
        }
    }
}


