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
    }
}
