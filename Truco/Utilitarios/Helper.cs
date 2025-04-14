using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Truco.Utilitarios
{
    public static class Helper
    {
        public static T Pop<T>(this List<T> list)
        {
            T lastItem = list[list.Count - 1];
            list.RemoveAt(list.Count - 1);
            return lastItem;
        }

        public static int mCint(object value)
        {
            if (value == null)
            {
                return 0;
            }
            if (value is bool boolvalue)
            {
                return boolvalue ? 1 : 0;
            }
            if (value is string strValue)
            {
                if (string.IsNullOrEmpty(strValue))
                {
                    return 0;
                }
                if (int.TryParse(strValue, out int intvalue))
                {
                    return intvalue;
                }

                return 0;
            }

            if (int.TryParse(value.ToString(), out int numericValue))
            {
                return numericValue;
            }

            return 0;
        }

    }
}
