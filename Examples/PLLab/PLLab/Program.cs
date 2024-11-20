using PLLab.DB;
using System.Numerics;
using System.Xml.Linq;

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
                AddNewProduct();
            } 
            else if (opShow == 1)
            {
                ShowProduct();
            }
            else if (opList == 1)
            {
                ListProduct();
            }
            else if (opRemove == 1)
            {
                RemoveProduct();
            }
            else if (opUpdate == 1)
            {
                UpdateProduct();
            }

            Log.Debug("Finish");
        }

        private static void ListProduct()
        {
            List<Product> products = DBService.Current.GetAll();
            PrintProductList(products);
        }

        private static void PrintProductList(List<Product> products)
        {
            Console.WriteLine("| Name            | Count     | Release    |");
            foreach (Product product in products)
            {
                string name = product.Name;
                if (name.Length < 15)
                {
                    name = name.PadRight(15, ' ');
                }
                if (name.Length > 15)
                {
                    name = name.Substring(0, 12) + "...";
                }

                string count = product.Count.ToString("0.000");
                if (count.Length < 9)
                {
                    count = count.PadLeft(9, ' ');
                }

                string release = product.LastRelease.ToString("dd.MM.yyyy");

                Console.WriteLine("| {0} | {1} | {2} |", name, count, release);
            }
        }

        private static void UpdateProduct()
        {
            string name = ArgParser.GetArgAsString(ArgParser.ARG_NAME);
            double count = ArgParser.GetArgAsDouble(ArgParser.ARG_COUNT);
            DateTime release = ArgParser.GetArgAsDateTimeOrDefault(ArgParser.ARG_RELEASE, DateTime.Now);

            Log.Info("Update product '{0}'", name);

            DBService.Current.Add(new Product()
            {
                Name = name,
                Count = count,
                LastRelease = release
            });

            Product p = DBService.Current.GetByName(name);
            Console.WriteLine();
            PrintProduct(p);
        }

        private static void RemoveProduct()
        {
            string name = ArgParser.GetArgAsString(ArgParser.ARG_NAME);
            Log.Info("Remove product '{0}'.", name);
            DBService.Current.RemoveByName(name);
        }

        private static void ShowProduct()
        {
            string name = ArgParser.GetArgAsString(ArgParser.ARG_NAME);
            Product product = DBService.Current.GetByName(name);
            if (product == null)
            {
                Log.Error("ERROR: Product with name '{0}' not found.", name);
                return;
            }
            PrintProduct(product);    
        }

        private static void PrintProduct(Product p) 
        {
            Console.WriteLine("   Name: {0}", p.Name);
            Console.WriteLine("  Count: {0:0.000}", p.Count);
            Console.WriteLine("Release: {0:dd.MM.yyyy}", p.LastRelease);        
        }

        private static void AddNewProduct()
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
    }
}