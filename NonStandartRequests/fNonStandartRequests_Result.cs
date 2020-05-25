using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using TranslationColumns;

namespace NonStandartRequests
{
    public partial class fNonStandartRequests : Form
    {

        private void lvResult_ColumnClick(object sender, ColumnClickEventArgs e)
        {
            ColumnHeader newSortingColumn = lvResult.Columns[e.Column];

            SortOrder sortOrder;
            if (sortingColumn == null || sortingColumn != newSortingColumn || (SortOrder)sortingColumn.Tag == SortOrder.Descending)
            {
                sortOrder = SortOrder.Ascending;
                newSortingColumn.Tag = SortOrder.Ascending;
            }
            else
            {
                sortOrder = SortOrder.Descending;
                newSortingColumn.Tag = SortOrder.Descending;
            }

            sortingColumn = newSortingColumn;
            lvResult.ListViewItemSorter =
                new ListViewComparer(e.Column, sortOrder);
            lvResult.Sort();
        }

    }
}
