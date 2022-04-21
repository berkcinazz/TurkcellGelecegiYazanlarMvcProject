using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Extensions
{
    public static class ArrayExtensions
    {
        public static bool ContainsString(this string[] arr, string objToSearch)
        {
            foreach (string str in arr)
                if (str == objToSearch) return true;
            return false;
        }
    }
}
