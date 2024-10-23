using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ex01.Files
{
    public abstract class EmployeeLoaderCore
    {
        public abstract List<Employee> LoadFrom(string path);
    }
}
