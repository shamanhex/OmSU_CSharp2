namespace PLLab
{
    public class Program
    {

        public static void Main(string[] args)
        {
            string name = ArgParser.GetArgAsString(ArgParser.ARG_NAME);
            if (string.IsNullOrWhiteSpace(name))
            {
                Console.WriteLine("ERROR: Name not specified. Please, specify --name argument.");
                return;
            }
            string sHired = ArgParser.GetArgAsString(ArgParser.ARG_HIRED);
            if (string.IsNullOrWhiteSpace(sHired))
            {
                Console.WriteLine("ERROR: Hired date not specified. Please, specify --hired argument.");
                return;
            }
            try
            {
                DateTime hired = DateTime.ParseExact(sHired, "dd.MM.yyyy", null);
                string message = Cfg.ReadString("Message");
                message = message.Replace("%name%", name);
                message = message.Replace("%hired%", hired.ToString("dd.MM.yyyy"));
                Console.WriteLine(message);
            }
            catch (FormatException ex)
            { 
                Console.WriteLine("ERROR: Hired date is incorrect. Please, use the format DD.MM.YYYY. ({0})", ex.Message);
                return;
            }            
        }
    }
}