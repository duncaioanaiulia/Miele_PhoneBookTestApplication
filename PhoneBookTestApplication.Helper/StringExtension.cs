using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PhoneBookTestApplication.Helper
{
    public static class StringExtension
    {
        public static string Build(this string model, params string[] list)
        {
            StringBuilder stringBuilder = new StringBuilder();
            foreach (var item in list)
            {
                stringBuilder.Append(item);
            }
            return stringBuilder.ToString();
        }
    }
}
