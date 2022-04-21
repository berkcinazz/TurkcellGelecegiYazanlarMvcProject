using Core.Extensions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Utilities.Helpers
{
    public static class CreditCardTypeHelper
    {
        private static string[] VisaTypes = new string[] { "49", "44", "47" };
        private static string[] VisaElectronTypes = new string[] { "42", "45", "48" };
        private static string[] MasterCardTypes = new string[] { "51", "52", "53", "54", "55" };

        public static string FindCreditCardType(string input)
        {
            var output = input.Substring(0, 2);
            return VisaTypes.ContainsString(input) ? "Visa" : VisaElectronTypes.ContainsString(input) ? "Visa Electron" : MasterCardTypes.ContainsString(input) ? "Master Card" : "Other Card";
        }
    }
}
