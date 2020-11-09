using System;
using System.Globalization;
using System.Text.Json;

namespace playCS
{
    public class Temperature : IFormattable
    {
        private decimal m_Temp;

        public Temperature(decimal temperature)
        {
            this.m_Temp = temperature;
        }

        public decimal Celsius
        {
            get { return this.m_Temp; }
        }

        public decimal Kelvin
        {
            get { return this.m_Temp + 273.15m; }
        }

        public decimal Fahrenheit
        {
            get { return Math.Round((decimal) this.m_Temp * 9 / 5 + 32, 2); }
        }

        public override string ToString()
        {
            return this.ToString("G", null);
        }

        public string ToString(string format)
        {
            return this.ToString(format, null);
        }

        public string ToString(string format, IFormatProvider provider)
        {
            // Handle null or empty arguments.
            if (String.IsNullOrEmpty(format))
                format = "G";
            // Remove any white space and covert to uppercase.
            format = format.Trim().ToUpperInvariant();

            if (provider == null)
                provider = NumberFormatInfo.CurrentInfo;

            switch (format)
            {
                // Convert temperature to Fahrenheit and return string.
                case "F":
                    return this.Fahrenheit.ToString("N2", provider) + "°F";
                // Convert temperature to Kelvin and return string.
                case "K":
                    return this.Kelvin.ToString("N2", provider) + "K";
                // Return temperature in Celsius.
                case "C":
                case "G":
                    return this.Celsius.ToString("N2", provider) + "°C";
                default:
                    throw new FormatException(String.Format("The '{0}' format string is not supported.", format));
            }
        }
    }

    public class PlayStringFormatter
    {
        static void PlayTemperature()
        {
            Temperature temp = new Temperature(16m);

            Console.WriteLine($"{temp,12:F},aaaa");
            Console.WriteLine("{0,12:F},aaaa", temp);
            Console.WriteLine($"{temp,-12},aaaa");
            Console.WriteLine($"{temp,-12},{12,20},aaaa");
            // Console.WriteLine();
        }

        static void PlayBasic()
        {
            var dc = CultureInfo.CurrentCulture;
            var us = CultureInfo.GetCultureInfo("en-us");
            var zh = CultureInfo.GetCultureInfo("zh-cn");

            var ci = new CultureInfo("en-us");
            var x = 123;

            var f = x.ToString("C3", ci);
            Console.WriteLine(f);

            Console.WriteLine($"{x:n}");
        }

        public static void Play()
        {
            PlayBasic();
            PlayTemperature();
        }
    }
}