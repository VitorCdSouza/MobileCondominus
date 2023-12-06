using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
namespace TelaLogin.ViewModels.Dependentes
{
    public class DocumentValidator
    {
        public static string FormatDocument(string document)
        {
            return document.Replace(".", "").Replace("/", "").Replace("-", "");
        }
        public static bool ValidateDocument(string document)
        {
            // Only numbers
            if (!System.Text.RegularExpressions.Regex.IsMatch(document, "^[0-9]+$"))
            {
                return false; // invalid
            }
            int validatorDigit1 = 0;
            int validatorDigit2 = 0;
            int sum = 0;
            // CPF or CNPJ
            switch (document.Length)
            {
                case 11: // CPF
                         // 1st digit
                    for (int i = 0; i <= 8; i++)
                    {
                        if (!int.TryParse(document[i].ToString(), out int digit))
                        {
                            return false; // invalid
                        }
                        sum += digit * (10 - i);
                    }
                    int remainder1 = sum % 11;
                    validatorDigit1 = (remainder1 < 2) ? 0 : 11 - remainder1;
                    // Checking if 1st digit is correct
                    if (document[9] != validatorDigit1.ToString()[0])
                    {
                        return false; // invalid
                    }
                    // 2nd digit
                    sum = 0;
                    for (int i = 0; i <= 8; i++)
                    {
                        if (!int.TryParse(document[i].ToString(), out int digit))
                        {
                            return false; // invalid
                        }
                        sum += digit * (11 - i);
                    }
                    sum += validatorDigit1 * 2;
                    int remainder2 = sum % 11;
                    validatorDigit2 = (remainder2 < 2) ? 0 : 11 - remainder2;
                    // Checking if 2nd digit is correct
                    if (document[10] != validatorDigit2.ToString()[0])
                    {
                        return false; // invalid
                    }
                    break;
                case 14: // CNPJ
                    return false; // we will don't use CNPJ
                    // 1st digit
                    int multiplier1 = 5;
                    for (int i = 0; i <= 11; i++)
                    {
                        if (!int.TryParse(document[i].ToString(), out int digit))
                        {
                            return false; // invalid
                        }
                        sum += digit * multiplier1;
                        multiplier1--;
                        if (multiplier1 == 1)
                        {
                            multiplier1 = 9;
                        }
                    }
                    int remainder3 = sum % 11;
                    validatorDigit1 = (remainder3 < 2) ? 0 : 11 - remainder3;
                    // Checking if 1st digit is correct
                    if (document[12] != validatorDigit1.ToString()[0])
                    {
                        return false; // invalid
                    }
                    // 2nd digit
                    sum = 0;
                    int multiplier2 = 6;
                    for (int i = 0; i <= 11; i++)
                    {
                        if (!int.TryParse(document[i].ToString(), out int digit))
                        {
                            return false; // invalid
                        }
                        sum += digit * multiplier2;
                        multiplier2--;
                        if (multiplier2 == 1)
                        {
                            multiplier2 = 9;
                        }
                    }
                    sum += validatorDigit1 * 2;
                    int remainder4 = sum % 11;
                    validatorDigit2 = (remainder4 < 2) ? 0 : 11 - remainder4;
                    // Checking if 2nd digit is correct
                    if (document[13] != validatorDigit2.ToString()[0])
                    {
                        return false; // invalid
                    }
                    break;
                default:
                    // If it isn't 14 or 11 digits
                    return false; // invalid
            }
            return true;
        }
    }
}