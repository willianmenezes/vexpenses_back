using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace vexpenses.library.Helpers
{
    public static class ObjectExt
    {
        public static void Validate<TEntity>(this TEntity obj) where TEntity : class
        {
            var context = new ValidationContext(obj, serviceProvider: null, items: null);
            var results = new List<ValidationResult>();

            if (!Validator.TryValidateObject(obj, context, results))
            {
                string errorMessage = string.Empty;

                foreach (var error in results)
                {
                    errorMessage = $"{error.MemberNames}";
                }

                throw new Exception(errorMessage);
            }
        }
    }
}
