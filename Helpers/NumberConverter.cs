using System.Globalization;

namespace App.Helpers
{
    public class NumberConverter
    {
        public static int ConvertFloatToInt(float floatValue)
        {
            return (int)(floatValue * 100);
        }
    }
}
