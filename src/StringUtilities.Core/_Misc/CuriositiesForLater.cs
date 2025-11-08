using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StringUtilities.Core.Misc
{
    internal class CuriositiesForLater
    {

        public void Example_StringComparison()
        {
            string str3 = "i";
            string str4 = "I";
            string str5 = "İ";

            // Set the current culture to Turkish
            CultureInfo.CurrentCulture = new CultureInfo("tr-TR");


            // CurrentCulture case-insensitive comparison
            bool resultCurrentCultureIgnoreCase = string.Equals(str3, str4, StringComparison.CurrentCultureIgnoreCase);
            Console.WriteLine($"CurrentCulture case-insensitive comparison (i vs I in Turkish): {resultCurrentCultureIgnoreCase}"); // False

            // InvariantCulture case-insensitive comparison
            bool resultInvariantCultureIgnoreCase = string.Equals(str3, str4, StringComparison.InvariantCultureIgnoreCase);
            Console.WriteLine($"InvariantCulture case-insensitive comparison (i vs I): {resultInvariantCultureIgnoreCase}"); // True


            // CurrentCulture case-insensitive comparison
            bool resultCurrentCultureIgnoreCase2 = string.Equals(str3, str5, StringComparison.CurrentCultureIgnoreCase);
            Console.WriteLine($"CurrentCulture case-insensitive comparison (i vs İ in Turkish): {resultCurrentCultureIgnoreCase2}"); // True 

            // InvariantCulture case-insensitive comparison
            bool resultInvariantCultureIgnoreCase2 = string.Equals(str3, str5, StringComparison.InvariantCultureIgnoreCase);
            Console.WriteLine($"InvariantCulture case-insensitive comparison (i vs İ): {resultInvariantCultureIgnoreCase2}"); // False
        }

    }
}
