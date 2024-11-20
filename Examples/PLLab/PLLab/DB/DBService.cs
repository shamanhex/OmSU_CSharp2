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
                    if (product.Count != 0)
                    {
                        Log.Info("Count updated");
                        record.Count += product.Count;
                    }
                    if (record.LastRelease.Date != product.LastRelease.Date)
                    {
                        Log.Info("Release updated");
                        record.LastRelease = product.LastRelease.Date;
                    }
                    break;
                }
            }
            if (!isExist) 
            {
                Log.Debug("Add product. Product {0} was NOT found. Create new.", product.Name);
                product.LastRelease = product.LastRelease.Date;
                records.Add(product);
            }
            Current.SaveAll(records);
        }

        public Product GetByName(string name)
        {
            List<Product> records = Current.GetAll();
            foreach (Product record in records)
            {
                if (string.Compare(record.Name, name, true) == 0)
                {
                    Log.Debug("Product with name '{0}' was found", name);
                    return record;
                }
            }
            Log.Debug("Product with name '{0}' was not found", name);
            return null;
        }

        public void RemoveByName(string name)
        {
            List<Product> records = Current.GetAll();
            for (int i = 0; i < records.Count; i++)
            {
                Product record = records[i];
                if (string.Compare(record.Name, name, true) == 0)
                {
                    Log.Debug("Product with name '{0}' was found and remove.", name);
                    records.Remove(record);
                    SaveAll(records);
                    return;
                }
            }
            Log.Debug("Product with name '{0}' was not found. Remove not necessary.", name);
        }

    }
}
