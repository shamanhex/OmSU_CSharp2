using PLLab.DB;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PLLab.Validation
{
    public class ProductNameValidator : IValidator<Product>
    {
        public void IsValid(Product value)
        {
            if (string.IsNullOrWhiteSpace(value.Name))
            {
                throw new ValidateException("Product name must not be null or whitespace.");
            }
        }
    }
}
