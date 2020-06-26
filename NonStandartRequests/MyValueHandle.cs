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

            if (type == "decimal" || type == "numeric" || type == "real" || type == "double precision") return String.Format("{0:0.000}", value);

            return value.ToString();
        }

        public string ToStringWithBrakets()
        {
            if (Value == null || Value == DBNull.Value) return "NULL";

            if (DBType == "date")
                return "{" + ((DateTime)Value).ToString("dd.MM.yyyy") + "}";

            if (DBType == "interval")
                return ((TimeSpan)Value).ToString(@"\'ddd\ \d\a\y\s\ hh\:mm\:ss\'");

            //if (Value.GetType() == typeof(byte[])) return Convert.ToBase64String((byte[])Value);
            if (DBType == "bytea") return ("'" + Convert.ToBase64String((byte[])Value) + "'");

            if (Value.GetType() == typeof(string)) return ("'" + MyQuoteLiteral((string)Value) + "'");

            return Value.ToString();
        }

        private string MyQuoteLiteral(string val)
        {
            for (int i = 0; i < val.Length; i++)
                if (val[i] == '\'')
                    val = val.Insert(i++, "'");
            return val;
        }
    }
}
