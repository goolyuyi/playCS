using System;
using System.ComponentModel;
using System.Drawing;
using System.Globalization;
using Newtonsoft.Json.Serialization;

namespace playCS.PlayConvert
{
    public class Alcohol
    {
        public double Degree { get; set; }
        public string Type { get; set; }
    }

    //NOTE hooks any convert from Vodka or to Vodka
    [TypeConverter(typeof(VodkaConvert))]
    public class Vodka : Alcohol
    {
        public string Brand { get; set; }

        public override string ToString()
        {
            return $"Vodka:::{nameof(Brand)}: {Brand} {nameof(Degree)}:{Degree} {nameof(Type)}: {Type}";
        }
    }

    //NOTE used for convert to primitive type
    public class Gin : Alcohol, IConvertible
    {
        public TypeCode GetTypeCode()
        {
            throw new NotImplementedException();
        }

        public bool ToBoolean(IFormatProvider? provider)
        {
            throw new NotImplementedException();
        }

        public byte ToByte(IFormatProvider? provider)
        {
            throw new NotImplementedException();
        }

        public char ToChar(IFormatProvider? provider)
        {
            throw new NotImplementedException();
        }

        public DateTime ToDateTime(IFormatProvider? provider)
        {
            throw new NotImplementedException();
        }

        public decimal ToDecimal(IFormatProvider? provider)
        {
            throw new NotImplementedException();
        }

        public double ToDouble(IFormatProvider? provider)
        {
            throw new NotImplementedException();
        }

        public short ToInt16(IFormatProvider? provider)
        {
            throw new NotImplementedException();
        }

        public int ToInt32(IFormatProvider? provider)
        {
            throw new NotImplementedException();
        }

        public long ToInt64(IFormatProvider? provider)
        {
            throw new NotImplementedException();
        }

        public sbyte ToSByte(IFormatProvider? provider)
        {
            throw new NotImplementedException();
        }

        public float ToSingle(IFormatProvider? provider)
        {
            throw new NotImplementedException();
        }

        public string ToString(IFormatProvider? provider)
        {
            throw new NotImplementedException();
        }

        public object ToType(Type conversionType, IFormatProvider? provider)
        {
            throw new NotImplementedException();
        }

        public ushort ToUInt16(IFormatProvider? provider)
        {
            throw new NotImplementedException();
        }

        public uint ToUInt32(IFormatProvider? provider)
        {
            throw new NotImplementedException();
        }

        public ulong ToUInt64(IFormatProvider? provider)
        {
            throw new NotImplementedException();
        }
    }

    //NOTE custom converter
    public class VodkaConvert : TypeConverter
    {
        public override bool CanConvertFrom(ITypeDescriptorContext context, Type sourceType)
        {
            return sourceType == typeof(string) || sourceType == typeof(int) ||
                   base.CanConvertFrom(context, sourceType);
        }


        public override object ConvertFrom(ITypeDescriptorContext context, CultureInfo culture, object value)
        {
            if (value is string vs)
            {
                var v = new Vodka();
                v.Brand = vs;
                return v;
            }

            if (value is int vi)
            {
                var v = new Vodka();
                v.Degree = vi;
                return v;
            }

            return base.ConvertFrom(context, culture, value);
        }
    }


    public class PlayConvert
    {
        // official doc
        // introduced all converting method of c#
        // https://docs.microsoft.com/zh-cn/dotnet/standard/base-types/type-conversion

        // convert table
        //https://docs.microsoft.com/zh-cn/dotnet/standard/base-types/conversion-tables

        public static void Play()
        {
            //NOTE kind of raw way of convert
            object a = Convert.ChangeType("123", typeof(int));

            //NOTE TypeConverter more raw convert
            var vodkaConverter = TypeDescriptor.GetConverter(typeof(Vodka));
            var toString = vodkaConverter.CanConvertTo(typeof(string));
            var fromString = vodkaConverter.CanConvertFrom(typeof(string));

            Console.WriteLine(vodkaConverter.IsValid(5));
            Console.WriteLine(toString);
            Console.WriteLine(fromString);

            Console.WriteLine(vodkaConverter.ConvertFrom("yuyi"));
            Console.WriteLine(vodkaConverter.ConvertFrom(99));

            var vodka = new Vodka() {Degree = 70, Brand = "life", Type = "drink"};

            Console.WriteLine(vodka);
            Console.WriteLine(vodkaConverter.ConvertToString(vodka));

            foreach (Color c in TypeDescriptor.GetConverter(typeof(Color)).GetStandardValues())
            {
                Console.WriteLine(TypeDescriptor.GetConverter(c).ConvertToString(c));
            }

            var d = Convert.ChangeType(vodka, typeof(string));
        }
    }
}