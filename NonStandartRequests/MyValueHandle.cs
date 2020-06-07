using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NonStandartRequests
{
    class MyValueHandle
    {
        public object Value { get; }
        public string DBType { get; }

        public MyValueHandle(object value, string DBType)
        {
            Value = value;
            this.DBType = DBType.ToLower();
        }

        public override string ToString()
        {
            //if (Value == null || Value == DBNull.Value) return "<null>";

            //if (DBType == "date")
            //    return ((DateTime)Value).ToString("dd.MM.yyyy");

            //if (DBType == "interval")
            //    return ((TimeSpan)Value).ToString(@"ddd\ \д\.\ hh\ \ч\.\ mm\ \м\.\ ss\ \с\.");

            ////if (Value.GetType() == typeof(byte[])) return Convert.ToBase64String((byte[])Value);
            //if (DBType == "bytea") return Convert.ToBase64String((byte[])Value);

            //return Value.ToString();
            return GetFormattedValue(Value, DBType);
        }

        public static string GetFormattedValue(object value, string type)
        {
            if (value == null || value == DBNull.Value) return "<null>";

            if (type == "date")
                return ((DateTime)value).ToString("dd.MM.yyyy");

            if (type == "interval")
                return ((TimeSpan)value).ToString(@"ddd\ \д\.\ hh\ \ч\.\ mm\ \м\.\ ss\ \с\.");

            //if (Value.GetType() == typeof(byte[])) return Convert.ToBase64String((byte[])Value);
            if (type == "bytea") return Convert.ToBase64String((byte[])value);

            return value.ToString();
        }

    }
}
