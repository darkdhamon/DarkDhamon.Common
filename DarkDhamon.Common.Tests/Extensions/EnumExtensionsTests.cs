using System;
using DarkDhamon.Common.Extensions;
using NUnit.Framework;

namespace DarkDhamon.Common.Tests.Extensions
{
    public class EnumExtensionsTests
    {
        public enum UseDescriptionTest
        {
            [System.ComponentModel.Description("Uno")]
            One,
            [System.ComponentModel.Description("Dos")]
            Two,
            [System.ComponentModel.Description("Tres")]
            Three,
        }

        public struct NotAnEnum:IConvertible
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

        [Test]
        [TestCase(UseDescriptionTest.One,true, "Uno")]
        [TestCase(UseDescriptionTest.Two,true, "Dos")]
        [TestCase(UseDescriptionTest.One,false, "One")]
        [TestCase(UseDescriptionTest.Two,false, "Two")]
        public void ToStringUseDescriptionTest(UseDescriptionTest value, bool useDescription, string result)
        {
            Assert.AreEqual(result,value.ToString(useDescription));
        }

        [Test]
        public void ToStringUseDescriptionNotEnumTest()
        {
            void Code()
            {
                NotAnEnum failTest = new NotAnEnum();
                failTest.ToString(true);
            }

            Assert.Throws<ArgumentException>(Code);
        }
    }
}