namespace PLLab
{
    public class Program
    {

        public static void Main(string[] args)
        {
            Log.Debug("Start");

            string name = ArgParser.GetArgAsString(ArgParser.ARG_NAME);
            Log.Debug("Name is '{0}'", name);
            if (string.IsNullOrWhiteSpace(name))
            {
                Log.Error("ERROR: Name not specified. Please, specify --name argument.");
                return;
            }
            string sHired = ArgParser.GetArgAsString(ArgParser.ARG_HIRED);
            Log.Debug("Hired string is '{0}'", sHired);
            if (string.IsNullOrWhiteSpace(sHired))
            {
                Log.Error("ERROR: Hired date not specified. Please, specify --hired argument.");
                return;
            }
            try
            {
                DateTime hired = DateTime.ParseExact(sHired, "dd.MM.yyyy", null);
                Log.Debug("Hired date is '{0}'", hired);
                string message = Cfg.ReadString("Message");
                Log.Debug("Message from config '{0}'", message);
                message = message.Replace("%name%", name);
                message = message.Replace("%hired%", hired.ToString("dd.MM.yyyy"));
                Log.Info(message);
            }
            catch (FormatException ex)
            {
                Log.Error("ERROR: Hired date is incorrect. Please, use the format DD.MM.YYYY. ({0})", ex.Message);
                return;
            }
            Log.Debug("Finish");
        }
    }
}