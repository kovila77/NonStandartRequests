using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace NonStandartRequests
{
    public partial class fNonStandartRequests : Form
    {

        private void FieldAddTo_LBSelectedFieldsOrder(MyField field)
        {
            lbSelectedFieldsOrder.Items.Add(field);
        }

        private void FieldRemoveFrom_LBSelectedFieldsOrder(MyField field)
        {
            lbSelectedFieldsOrder.Items.Remove(field);
        }

        private void FieldRemoveFrom_LBOrder(MyField field)
        {
            lbOrder.Items.Remove(field);
        }

        private void btRightFieldOrder_Click(object sender, EventArgs e)
        {
            if (lbSelectedFieldsOrder.SelectedItem == null) return;
            var tmp = lbSelectedFieldsOrder.SelectedItem;
            lbSelectedFieldsOrder.Items.Remove(tmp);
            lbOrder.Items.Add(tmp);
        }

        private void btLeftFieldOrder_Click(object sender, EventArgs e)
        {
            if (lbOrder.SelectedItem == null) return;
            var tmp = lbOrder.SelectedItem;
            lbOrder.Items.Remove(tmp);
            lbSelectedFieldsOrder.Items.Add(tmp);
        }

        private void btAllRightFieldOrder_Click(object sender, EventArgs e)
        {
            foreach (var itm in lbSelectedFieldsOrder.Items)
            {
                lbOrder.Items.Add(itm);
            }
            lbSelectedFieldsOrder.Items.Clear();
        }

        private void btAllLeftFieldOrder_Click(object sender, EventArgs e)
        {
            foreach (var itm in lbOrder.Items)
            {
                lbSelectedFieldsOrder.Items.Add(itm);
            }
            lbOrder.Items.Clear();
        }

        private void lbSelectedFieldsOrder_DoubleClick(object sender, EventArgs e)
        {
            btRightFieldOrder_Click(null, null);
        }

        private void lbOrder_DoubleClick(object sender, EventArgs e)
        {
            btLeftFieldOrder_Click(null, null);
        }

        private void btUp_Click(object sender, EventArgs e)
        {
            if (lbOrder.Items.Count > 0 && lbOrder.SelectedIndex > 0)
            {
                var sItm = lbOrder.SelectedItem;
                var sIimIndex = lbOrder.SelectedIndex;
                lbOrder.Items.Remove(sItm);
                lbOrder.Items.Insert(sIimIndex - 1, sItm);
                lbOrder.SelectedItem = sItm;
            }
        }

        private void btDown_Click(object sender, EventArgs e)
        {
            if (lbOrder.Items.Count > 0 && lbOrder.SelectedItem != null && lbOrder.SelectedIndex != lbOrder.Items.Count - 1)
            {
                var sItm = lbOrder.SelectedItem;
                var sIimIndex = lbOrder.SelectedIndex;
                lbOrder.Items.Remove(sItm);
                lbOrder.Items.Insert(sIimIndex + 1, sItm);
                lbOrder.SelectedItem = sItm;
            }
        }

        private void lbOrder_SelectedIndexChanged(object sender, EventArgs e)
        {
            rbIncreasing.Enabled = lbOrder.SelectedItem != null;
            rbDecreasing.Enabled = lbOrder.SelectedItem != null;

            if (lbOrder.SelectedItem == null) return;
            if (((MyField)lbOrder.SelectedItem).SortOrder == SortOrder.Ascending)
            {
                rbIncreasing.Checked = true;
            }
            else
            {
                rbDecreasing.Checked = true;
            }
        }


        private void rbIncreasing_CheckedChanged(object sender, EventArgs e)
        {
            if (rbIncreasing.Checked && lbOrder.SelectedItem != null)
            {
                ((MyField)lbOrder.SelectedItem).SortOrder = SortOrder.Ascending;
            }
        }

        private void rbDecreasing_CheckedChanged(object sender, EventArgs e)
        {
            if (rbDecreasing.Checked && lbOrder.SelectedItem != null)
            {
                ((MyField)lbOrder.SelectedItem).SortOrder = SortOrder.Descending;
            }
        }
    }
}
