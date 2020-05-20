using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NonStandartRequests
{
    class MyWay
    {
        public List<string> tables = new List<string>();
        public List<MyTableFLink> fKeyLinkeds = new List<MyTableFLink>();
        public string curTable;
        //public MyWay() { }
        //public MyWay(MyWay existsWay, string table)
        //{
        //    tables.AddRange(existsWay.tables);
        //    fKeyLinkeds.AddRange(existsWay.fKeyLinkeds);
        //    curTable = table;
        //}
    }
}
