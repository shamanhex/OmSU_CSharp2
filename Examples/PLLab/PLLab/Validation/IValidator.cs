using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PLLab.Validation
{
    public interface IValidator<T>
    {
        void IsValid(T value);
    }
}
