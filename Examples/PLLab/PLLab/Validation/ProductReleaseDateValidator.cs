using PLLab.DB;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PLLab.Validation
{
    public class ProductReleaseDateValidator : IValidator<Product>
    {
        public void IsValid(Product value)
        {
            if (value.LastRelease > DateTime.Now)
            {
                throw new ValidateException("Product release date can't be more then today.");
            }
        }
    }
}
