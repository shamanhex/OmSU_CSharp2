using PLLab.DB;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace PLLab.Validation
{
    public static class Validator
    {
        public static List<ValidateException> Validate(object obj)
        {
            List<ValidateException> validateErrors = new List<ValidateException>();

            Type objType = obj.GetType();
            Type genericValidatorInterface = typeof(IValidator<>);

            foreach (Type t in Assembly.GetExecutingAssembly().GetTypes()) 
            {
                Type validatorInterface =
                    t.GetInterfaces().FirstOrDefault(
                        (i) => i.IsInterface &&
                        i.IsGenericType &&
                        i.GetGenericTypeDefinition() == genericValidatorInterface);
                if (t.IsClass && 
                    !t.IsAbstract &&
                    validatorInterface != null)
                {
                    if (validatorInterface.GetGenericArguments().Count() > 1)
                    {
                        continue;
                    }
                    Type validateType = validatorInterface.GetGenericArguments()[0];
                    if (!validateType.IsAssignableFrom(objType))
                    {
                        continue;
                    }
                    ConstructorInfo ctor = t.GetConstructor(new Type[] { });
                    Object validator = ctor.Invoke(null);
                    MethodInfo isValidMethod = t.GetMethod("IsValid");
                    try
                    {
                        isValidMethod.Invoke(validator, new object[] { obj });
                    }
                    catch (TargetInvocationException ex)
                    {
                        if (ex.InnerException is ValidateException)
                        {
                            validateErrors.Add((ValidateException) ex.InnerException);
                        }
                    }
                }
            }
            return validateErrors;
        }
    }
}
