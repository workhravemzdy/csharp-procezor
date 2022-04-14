using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HraveMzdy.Procezor.Registry.Constants
{
    public class EnumConstUtils<T> where T : struct, Enum
    {
        public static string GetSymbol(Int32 symbol) 
        {
            var enumValue = (T)Enum.ToObject(typeof(T), symbol);
            return Enum.GetName<T>(enumValue);
        }
    }
}
