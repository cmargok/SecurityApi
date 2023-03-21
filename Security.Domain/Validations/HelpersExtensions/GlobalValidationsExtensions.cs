using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Security.Domain.Validations.HelpersExtensions
{
    public static class GlobalValidationsExtensions
    {
        public static void CheckNull<T>(T obj)
        {
            if (obj is null) throw new ArgumentNullException(nameof(obj));
        }
    }
}
