using PLLab.DB;

namespace PLLab
{
    public class Program
    {

        public static void Main(string[] args)
        {
            Log.Debug("Start");

            int opAdd = ArgParser.HasArg(ArgParser.ARG_ADD) ? 1 : 0;
            int opList = ArgParser.HasArg(ArgParser.ARG_LIST) ? 1 : 0;
            int opShow = ArgParser.HasArg(ArgParser.ARG_SHOW) ? 1 : 0;
            int opUpdate = ArgParser.HasArg(ArgParser.ARG_UPDATE) ? 1 : 0;
            int opRemove = ArgParser.HasArg(ArgParser.ARG_REMOVE) ? 1 : 0;

            int opSum = opAdd + opList + opShow + opUpdate + opRemove;

            if (opSum == 0)
            {
                Log.Error("ERROR: Please specify arguments.");
                return;
            }

            if (opSum > 1)
            {
                Log.Error("ERROR: Please specify only 1 operation.");
                return;
            }

            DBService.Init();

            if (opAdd == 1)
            {
                string name = ArgParser.GetArgAsString(ArgParser.ARG_NAME);
                double count = ArgParser.GetArgAsDouble(ArgParser.ARG_COUNT);
                DateTime releaseDate = ArgParser.GetArgAsDateTimeOrDefault(ArgParser.ARG_RELEASE, DateTime.Now);

                Product newProduct = new Product()
                {
                    Name = name,
                    Count = count,
                    LastRelease = releaseDate
                };

                DBService.Current.Add(newProduct);
            }

            Log.Debug("Finish");
        }
    }
}