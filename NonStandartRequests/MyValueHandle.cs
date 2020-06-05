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
            if (Value == null || Value == DBNull.Value) return "<null>";

            if (DBType == "date")
                return ((DateTime)Value).ToString("dd.MM.yyyy");

            if (DBType == "interval")
                return ((TimeSpan)Value).ToString(@"ddd\ \д\.\ hh\ \ч\.\ mm\ \м\.\ ss\ \с\.");

            //if (Value.GetType() == typeof(byte[])) return Convert.ToBase64String((byte[])Value);
            if (DBType == "bytea") return Convert.ToBase64String((byte[])Value);

            return Value.ToString();
        }

        //public static string GetFormattedValue(object val)
        //{
        //    //val == null || val == DBNull.Value ? "" : val.ToString();
        //if (val == null || val == DBNull.Value) return "";
        //if (val.GetType() == typeof(byte[])) return Convert.ToBase64String((byte[]) val);

        //return val.ToString();
        //}

    }
}
