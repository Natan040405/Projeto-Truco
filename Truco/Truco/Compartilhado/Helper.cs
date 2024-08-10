using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Truco.Compartilhado
{
    public static class Helper
    {
        public static T Pop<T> (this List<T> list)
        {
            T lastItem = list[list.Count - 1];
            list.RemoveAt(list.Count - 1);
            return lastItem;
        }

    }
}
