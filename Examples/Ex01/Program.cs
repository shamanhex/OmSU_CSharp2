using System.Reflection.Metadata;
using System.Text;
using System.Text.RegularExpressions;
using Ex01.Files;

namespace Ex01
{
    public class Program
    {
        public static int Main(string[] args)
        {

            if (ArgParser.HasArg(ArgParser.ARG_VERSION))
            {
                Console.WriteLine("1.0");
            }

            List<Employee> employees = EmployeeLoader.LoadFrom("Employees.txt");

            /*List<Employee> employees = new List<Employee>();
            employees.Add(new Employee() 
            { 
                Name = "Ivanov I.I.", 
                Birthday = new DateTime(2000, 02, 01), 
                Salary = 150.0
            });*/

            EmployeeJsonLoader.SaveTo("employee.json", employees);
            List<Employee> loadedEmps = EmployeeLoader.LoadFrom("employee.json");

            Console.WriteLine("Loaded {0} employees", loadedEmps.Count);

            foreach (Employee employee in loadedEmps)
            {
                Console.WriteLine("Employee: "+Convert.ToString(employee));
            }

            return 0;
        }
    }

}


