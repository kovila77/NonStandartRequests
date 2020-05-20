using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Npgsql;

namespace NonStandartRequests
{
    class MyTableFLink
    {
        public string TableFirstName;
        public string TableSecondName;
        public string ColumnFirstName;
        public string ColumnSecondName;

        //public void SwapTables()
        //{
        //    (TableFirstName, ColumnFirstName, TableSecondName, ColumnSecondName) = (TableSecondName, ColumnSecondName, TableFirstName, ColumnFirstName);
        //}

        public MyTableFLink GetSwaped()
        {
            return new MyTableFLink()
            {
                TableFirstName = TableSecondName,
                ColumnFirstName = ColumnSecondName,
                TableSecondName = TableFirstName,
                ColumnSecondName = ColumnFirstName,
            };
        }

        public bool EqualSomeSide(MyTableFLink myTableFKeyLinked)
        {
            return this.TableFirstName == myTableFKeyLinked.TableSecondName
                && this.TableSecondName == myTableFKeyLinked.TableFirstName
                || this.TableSecondName == myTableFKeyLinked.TableSecondName
                && this.TableFirstName == myTableFKeyLinked.TableFirstName;
        }

        public string GetStringToLink(NpgsqlCommandBuilder npgsqlCommandBuilder)
        {
            return npgsqlCommandBuilder.QuoteIdentifier(TableFirstName) + "."
                + npgsqlCommandBuilder.QuoteIdentifier(ColumnFirstName) + " = "
                + npgsqlCommandBuilder.QuoteIdentifier(TableSecondName) + "."
                + npgsqlCommandBuilder.QuoteIdentifier(ColumnSecondName);
        }
    }
}
