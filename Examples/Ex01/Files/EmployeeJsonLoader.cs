using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace Ex01.Files
{
    [FileExtension(".JSON")]
    public class EmployeeJsonLoader : EmployeeLoaderCore
    {
        public override List<Employee> LoadFrom(string path)
        {
            string json = File.ReadAllText(path);
            return JsonConvert.DeserializeObject<List<Employee>>(json);
        }

        public static void SaveTo(string path, List<Employee> employees)
        {
            string json = JsonConvert.SerializeObject(employees);
            File.WriteAllText(path, json);
        }
    }
}
