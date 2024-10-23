using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Reflection;
using System.IO;

namespace Ex01.Files
{
    public static class EmployeeLoader
    {
        public static List<Employee> LoadFrom(string path)
        {
            string ext = Path.GetExtension(path).ToUpper();

            EmployeeLoaderCore loader = GetLoader(ext);

            return loader.LoadFrom(path);
        }

        public static EmployeeLoaderCore GetLoader(string ext)
        {
            Assembly assembly = Assembly.GetExecutingAssembly();

            foreach (Type t in assembly.GetTypes())
            {
                if (!t.IsClass || t.IsAbstract)
                    continue;

                ConstructorInfo ci = t.GetConstructor(new Type[] { });
                if (ci == null)
                    continue;

                foreach (FileExtensionAttribute fExtAttr in
                        t.GetCustomAttributes<FileExtensionAttribute>())
                {
                    if (string.Compare(fExtAttr.Extension, ext, ignoreCase: true) == 0)
                    {
                        EmployeeLoaderCore loader = ci.Invoke(null) as EmployeeLoaderCore;

                        if (loader == null)
                        {
                            throw new InvalidOperationException(string.Format("Class {0} error loading.", t.FullName));
                        }

                        return loader;
                    }
                }
            }

            throw new InvalidOperationException(string.Format("Loader for {0} not found", ext));
        }
    }
}
