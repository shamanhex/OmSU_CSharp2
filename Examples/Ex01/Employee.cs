using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace Ex01
{
    public class Employee
    {
        private String _Name;

        public String Name
        {
            get
            {
                return _Name;
            }
            set
            { 
                _Name = value; 
            }
        }

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

        public override string ToString()
        {
            return string.Format("{0} ({1})", Name, Birthday);
        }
    }
}
