using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PLLab.DB
{
    public class DBService
    {
        public const string DB_FILE_NAME = "data.json";

        public static DBService Current { get; private set; }

        public string FileName { get; private set; }

        private DBService(string fileName) 
        { 
            FileName = fileName;
        }

        public static void Init(string fileName = DB_FILE_NAME)
        {
            Log.Debug("Init DB with filename: "+fileName);
            Current = new DBService(fileName);
        }

        public List<Product> GetAll()
        {
            if (!File.Exists(FileName)) 
            {
                Log.Debug("GetAll(): DB file not found");
                return new List<Product>();
            }
            string json = File.ReadAllText(FileName);
            List<Product> result = JsonConvert.DeserializeObject<List<Product>>(json);
            Log.Debug("GetAll(): From file loaded {0} records.", result.Count);
            return result;
        }

        public void SaveAll(List<Product> products)
        {
            string json = JsonConvert.SerializeObject(products);
            File.WriteAllText(FileName, json);
            Log.Debug("SaveAll(): Saved {0} records.", products.Count);
        }

        public void Add(Product product)
        {
            List<Product> records = Current.GetAll();
            bool isExist = false;
            foreach (Product record in records)
            {
                if (string.Compare(record.Name, product.Name, true) == 0)
                {
                    Log.Debug("Add product. Product {0} was found.", product.Name);
                    isExist = true;
                    record.Count += product.Count;
                    record.LastRelease = product.LastRelease;
                    break;
                }
            }
            if (!isExist) 
            {
                Log.Debug("Add product. Product {0} was NOT found. Create new.", product.Name);
                records.Add(product);
            }
            Current.SaveAll(records);
        }
    }
}
