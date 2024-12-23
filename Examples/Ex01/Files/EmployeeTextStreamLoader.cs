﻿using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ex01.Files
{
    public static class EmployeeTextStreamLoader
    {
        public static List<Employee> LoadFrom(string path)
        {
            List<Employee> list = new List<Employee>();

            try
            {
                using (StreamReader reader = new StreamReader(path))
                {
                    while (true)
                    {
                        string line = reader.ReadLine();
                        if (line == null) break;

                        string[] values = line.Split(';');

                        if (values.Length < 3)
                        {
                            Console.WriteLine("Ошибка в строке: " + line);
                            continue;
                        }

                        Employee emp = new Employee();
                        emp.Salary = Convert.ToDouble(values[0]);
                        emp.Birthday = Convert.ToDateTime(values[1]);
                        emp.Name = string.Join(';', values.Skip(2));

                        list.Add(emp);
                    }

                    reader.Close();
                }
            }
            catch (Exception ex)
            {
                if (ex is FileNotFoundException ||
                    ex is DirectoryNotFoundException)
                {
                    Console.WriteLine(ex.Message);

                    Console.WriteLine(Convert.ToString(ex));

                    return list;
                }
                if (ex is IOException)
                {
                    Console.WriteLine(ex.Message);

                    list.Clear();
                    return list;
                }

                throw new InvalidOperationException("Employee load error: " + ex.Message, ex);
            }

            return list;
        }
    }
}
