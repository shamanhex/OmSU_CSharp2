using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace Ex01
{
    public class Employee : Object
    {
        public String Name { get; set; }

        private double _Salary;

        public double Salary
        {
            get { return _Salary; }
            set { _Salary = value; }
        }

        private DateTime _Birthday;

        public DateTime Birthday
        {
            get { return _Birthday; }
            set { _Birthday = value; }
        }

        public Employee() { }

        public Employee(string name, double salary, DateTime birthday)
        {
            Name = name;
            Salary = salary;
            Birthday = birthday;
        }

        public override string ToString()
        {
            return string.Format("{0} ({1})", Name, Birthday);
        }

        protected void Do()
        {
            Console.WriteLine("Something doing...");
        }
    }
}
