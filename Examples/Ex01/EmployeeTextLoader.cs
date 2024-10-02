using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ex01
{
    public static class EmployeeTextLoader
    {
        public static List<Employee> LoadFrom(string path)
        {
            List<Employee> list = new List<Employee>();

            string[] lines = File.ReadAllLines(path);
            foreach (string line in lines)
            {
                string[] values = line.Split(';');

                if (values.Length < 3) 
                {
                    Console.WriteLine("Ошибка в строке: "+line);
                    continue;
                }

                Employee emp = new Employee();
                emp.Salary = Convert.ToDouble(values[0]);
                emp.Birthday = Convert.ToDateTime(values[1]);
                emp.Name = string.Join(';', values.Skip(2));

                list.Add(emp);
            }

            return list;
        }
    }
}
