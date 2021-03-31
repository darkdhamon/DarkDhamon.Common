using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;

namespace DarkDhamon.Common.Extensions
{
    public static class EnumExtension
    {
        public static string ToString<TEnum>(this TEnum value, bool useDescriptionAttribute) where TEnum : struct, IConvertible
        {
            if (!typeof(TEnum).IsEnum)
            {
                throw new ArgumentException("Must be called on an Enum");
            }
            string returnValue;
            if (useDescriptionAttribute)
            {
                var enumType = typeof(TEnum);
                var stringValue = value.ToString();
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
