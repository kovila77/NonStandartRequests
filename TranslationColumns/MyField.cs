using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace NonStandartRequests
{
    public class MyField
    {
        public string Name { get; set; }
        //public string Value { get => Name; set => Name = value; }
        public string ColumnName { get; set; }
        public string TableName { get; set; }
        public string FieldType { get; set; }

        public SortOrder SortOrder = SortOrder.Ascending;

        public override string ToString()
        {
            return Name;
        }
    }
}
