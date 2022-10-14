using System;
using System.ComponentModel;
using System.Diagnostics;
using System.Linq;

namespace DarkDhamon.Common.Extensions
{
    public static class EnumExtension
    {
        public static string? ToString<TEnum>(this TEnum value, bool useDescriptionAttribute) where TEnum : struct, IConvertible
        {
            if (!typeof(TEnum).IsEnum)
            {
                throw new ArgumentException("Must be called on an Enum");
            }
            string? returnValue;
            if (useDescriptionAttribute)
            {
                var enumType = typeof(TEnum);
                var stringValue = value.ToString();
                Debug.Assert(stringValue != null, nameof(stringValue) + " != null");
                var memberData = enumType.GetMember(stringValue);
                var description =
                    (memberData[0].GetCustomAttributes(typeof(DescriptionAttribute), false).FirstOrDefault() as
                        DescriptionAttribute)?.Description;
                returnValue = description ?? stringValue;
            }
            else
            {
                returnValue = value.ToString();
            }

            return returnValue;
        }
    }
}
