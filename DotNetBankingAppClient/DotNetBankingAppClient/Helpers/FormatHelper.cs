namespace DotNetBankingAppClient.Helpers;

public class FormatHelper
{
    public static string ReverseString(string input)
    {
        var inputArray = input.ToCharArray();
        Array.Reverse(inputArray);
        return new string(inputArray);
    }

    public static string FormatNumericValue(double value, int decimalScale = 2, string suffix = "")
    {
        string stringValue = value.ToString();
        stringValue = stringValue.Replace(".", ",");

        var split = stringValue.Split(",");

        //Something went wrong
        if (split.Length < 1)
        {
            return "Error";
        }

        //Handle Integer -------------------------------------------------------------------------------------
        string integerPart = split[0];
        string decimalPart = split.Length > 1 ? split[1] : "00";

        var integerPartReversed = ReverseString(integerPart);
        var formattedIntegerPart = "";

        //Apply the dots in every 3 numbers
        for (int i = 0; i < integerPartReversed.Length; i++)
        {
            if (i % 3 == 0 && i! >= 2)
            {
                formattedIntegerPart += ".";
            }
            formattedIntegerPart += integerPartReversed[i];

        }

        formattedIntegerPart = ReverseString(formattedIntegerPart);

        //Handle Decimal -------------------------------------------------------------------------------------

        if (decimalPart.Length < decimalScale)
        {
            int currentDecimalPartLenght = decimalPart.Length;
            for (int i = currentDecimalPartLenght; i < decimalScale; i++)
            {
                decimalPart += "0";
            }
        }
        else if (decimalPart.Length > decimalScale)
        {
            decimalPart = decimalPart.Substring(0, decimalScale);
        }

        return formattedIntegerPart + "," + decimalPart + suffix;
    }

    public static string FormatCardNumber(string cardNumber)
    {
        string formattedNumber = "";

        for (int i = 0; i < cardNumber.Length; i++)
        {
            if (i % 4 == 0 && i! > 1)
            {
                formattedNumber += " ";
            }

            if (i < cardNumber.Length - 4)
            {
                formattedNumber += "*";
            }
            else
            {
                formattedNumber += cardNumber[i];
            }

        }
        return formattedNumber;
    }

}

