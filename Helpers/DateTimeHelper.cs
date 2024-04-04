using System.Globalization;

namespace App.Helpers
{
    public class DateTimeHelper
    {
        public static DateTime ParseDateTime(string dateTime)
        {
            string format = "yyyyMMddHHmmss";
            if (DateTime.TryParseExact(dateTime, format, null, DateTimeStyles.None, out DateTime result))
            {
                return result;
            }
            else
            {
                throw new FormatException("Invalid DateTime format");
            }
        }
    }
}
