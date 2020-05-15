using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Npgsql;

namespace NonStandartRequests
{
    class MyTableFKeyLinked
    {
        public string TableFirstName;
        public string TableSecondName;
        public string ColumnFirstName;
        public string ColumnSecondName;

        public string GetStringToLink(NpgsqlCommandBuilder npgsqlCommandBuilder)
        {
            return npgsqlCommandBuilder.QuoteIdentifier(TableFirstName) + "."
                + npgsqlCommandBuilder.QuoteIdentifier(ColumnFirstName) + " = "
                + npgsqlCommandBuilder.QuoteIdentifier(TableSecondName) + "."
                + npgsqlCommandBuilder.QuoteIdentifier(ColumnSecondName);
        }
    }
}
