using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace NonStandartRequests
{
    public class ListViewComparer : System.Collections.IComparer
    {
        private int ColumnNumber;
        private SortOrder SortOrder;

        public ListViewComparer(int column_number, SortOrder sort_order)
        {
            ColumnNumber = column_number;
            SortOrder = sort_order;
        }

        public int Compare(object x, object y)
        {
            ListViewItem itemFirst = x as ListViewItem;
            ListViewItem itemSecond = y as ListViewItem;

            string string_x = itemFirst.SubItems[ColumnNumber].Text;

            string string_y = itemSecond.SubItems[ColumnNumber].Text;

            int result;
            double double_x, double_y;
            if (double.TryParse(string_x, out double_x) && double.TryParse(string_y, out double_y))
            {
                result = double_x.CompareTo(double_y);
            }
            else
            {
                DateTime date_x, date_y;
                if (DateTime.TryParse(string_x, out date_x) && DateTime.TryParse(string_y, out date_y))
                {
                    result = date_x.CompareTo(date_y);
                }
                else
                {
                    result = string_x.CompareTo(string_y);
                }
            }

            return SortOrder == SortOrder.Ascending ? result : -result;
        }
    }
}
