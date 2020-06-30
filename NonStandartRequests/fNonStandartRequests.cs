using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SQLite;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml;
using Npgsql;
using TranslationColumns;

namespace NonStandartRequests
{
    public partial class fNonStandartRequests : Form
    {

        string sPostgresConn = new NpgsqlConnectionStringBuilder()
        {
            Database = Properties.Settings.Default.Database,
            Host = Properties.Settings.Default.Host,
            Port = Properties.Settings.Default.Port,
            Username = Properties.Settings.Default.User,
            Password = Properties.Settings.Default.Password,
        }.ConnectionString;

        private string sqlQuery;
        ListViewItem lvConditionSelectedItem = null;

        private string strContainsConditionText = "Содержит";
        private string strBeginsFromConditionText = "Начинается с";
        private bool useQuotions = false;

        NpgsqlCommandBuilder npgsqlCommandBuilder = new NpgsqlCommandBuilder();
        private ColumnHeader sortingColumn = null;

        public delegate void myFieldDelegate(MyField deletedItem);
        public event myFieldDelegate SelectedItemAdded;
        public event myFieldDelegate SelectedItemRemoved;

        MyFieldController myFieldController;

        int listBoxBiginDraggingIndex = -1;
        object lbValueDragging = null;
        int yListBoxMouseDragging;
        public fNonStandartRequests()
        {
            InitializeComponent();
            //this.Font = new Font(this.Font,);
        }

        private void fNonStandartRequests_Load(object sender, EventArgs e)
        {
            myFieldController = new MyFieldController();
            foreach (var item in myFieldController.Fields)
            {
                lbAllFields.Items.Add(item);
                cbFieldName.Items.Add(item);
            }
            lbAllFields.Sorted = true;
            SelectedItemAdded += FieldAddTo_LBSelectedFieldsOrder;
            SelectedItemRemoved += FieldRemoveFrom_LBSelectedFieldsOrder;
            SelectedItemRemoved += FieldRemoveFrom_LBOrder;

            cbFieldName.Sorted = true;

            lvConditions.Columns.Add("Имя поля");
            lvConditions.Columns.Add("Критерий");
            lvConditions.Columns.Add("Значение");
            lvConditions.Columns.Add("Связка");
            lvConditions.AutoResizeColumns(ColumnHeaderAutoResizeStyle.ColumnContent);
            lvConditions.AutoResizeColumns(ColumnHeaderAutoResizeStyle.HeaderSize);

            ToolTip tt = new ToolTip();
            tt.SetToolTip(checkBoxGetOutSpace,"Если отмечено, при иземении/добалении в начале и конце строки убераются пробелы. Кроме того исключаются дублирующие пробелы");
            tt.SetToolTip(checkBoxUseBracked, "Если отмечено, обрамляет значения в условиях знаками < и >");
        }
        private void lbAllFields_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            btRightFieldFields_Click(null, null);
        }

        private void lbSelectedFieldsFields_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            btLeftFieldFields_Click(null, null);
        }

        private void btRightFieldFields_Click(object sender, EventArgs e)
        {
            if (lbAllFields.SelectedItem == null) return;
            var tmp = lbAllFields.SelectedItem;
            lbAllFields.Items.Remove(tmp);
            lbSelectedFieldsFields.Items.Add(tmp);

            SelectedItemAdded?.Invoke((MyField)tmp);
        }

        private void btLeftFieldFields_Click(object sender, EventArgs e)
        {
            if (lbSelectedFieldsFields.SelectedItem == null) return;
            var tmp = lbSelectedFieldsFields.SelectedItem;
            lbSelectedFieldsFields.Items.Remove(tmp);
            lbAllFields.Items.Add(tmp);

            SelectedItemRemoved?.Invoke((MyField)tmp);
        }

        private void btAllRightFieldFields_Click(object sender, EventArgs e)
        {
            foreach (var itm in lbAllFields.Items)
            {
                lbSelectedFieldsFields.Items.Add(itm);
                SelectedItemAdded?.Invoke((MyField)itm);
            }
            lbAllFields.Items.Clear();
        }

        private void btAllLeftFieldFields_Click(object sender, EventArgs e)
        {
            foreach (var itm in lbSelectedFieldsFields.Items)
            {
                lbAllFields.Items.Add(itm);
                SelectedItemRemoved?.Invoke((MyField)itm);
            }
            lbSelectedFieldsFields.Items.Clear();
        }

        private void btShowSQL_Click(object sender, EventArgs e) => CreateQuery(false);

        private void btExecute_Click(object sender, EventArgs e)
        {
            lvResult.Sorting = SortOrder.None;
            CreateQuery(true);
        }

        private void btCancel_Click(object sender, EventArgs e)
        {
            lvResult.Clear();
            lvConditions.Items.Clear();
            btDeleteCondition.Enabled = false;
            btChangeCond.Enabled = false;
            btAllLeftFieldFields_Click(null, null);
            cbExpression.DataSource = null;
            cbLigament.Items.Clear();
            cbCriterion.Items.Clear();
            cbFieldName.SelectedIndex = -1;

            cbExpression.DropDownStyle = ComboBoxStyle.DropDownList;
        }

        private void btFieldNameChange_Click(object sender, EventArgs e)
        {
            var tc = new fTranslationColumns(myFieldController.Fields);
            tc.FieldNameChanged += OnFieldNameChange;
            tc.ShowDialog();
            tc.FieldNameChanged -= OnFieldNameChange;
        }

        private void OnFieldNameChange(MyField newField)
        {
            //myFieldController.SetNewName(newField);
            var index = lbAllFields.Items.IndexOf(newField);
            if (index >= 0)
            {
                lbAllFields.Items.Remove(newField);
                lbAllFields.Items.Insert(index, newField);
            }
            index = cbFieldName.Items.IndexOf(newField);
            if (index >= 0)
            {
                if (index == cbFieldName.SelectedIndex)
                {
                    cbFieldName.Items.Remove(newField);
                    cbFieldName.Items.Insert(index, newField);
                    cbFieldName.SelectedIndex = index;
                }
                else
                {
                    cbFieldName.Items.Remove(newField);
                    cbFieldName.Items.Insert(index, newField);
                }
            }
            foreach (ListViewItem item in lvConditions.Items)
            {
                if (((MyCondition)item.Tag).Field == newField)
                {
                    item.SubItems[0].Text = newField.ToString();
                }
            }
        }


        private void lb_MouseDown(object sender, MouseEventArgs e)
        {
            lbValueDragging = ((ListBox)sender).SelectedItem;
            listBoxBiginDraggingIndex = ((ListBox)sender).SelectedIndex;
            yListBoxMouseDragging = e.Y;
        }

        private void lb_MouseMove(object sender, MouseEventArgs e)
        {
            if (lbValueDragging != null && listBoxBiginDraggingIndex > -1)
            {
                if (yListBoxMouseDragging - e.Y != 0)
                {
                    var lb = (ListBox)sender;
                    int curIndex = lb.SelectedIndex;
                    if (curIndex < 0 || listBoxBiginDraggingIndex == curIndex) return;
                    yListBoxMouseDragging = e.Y;
                    lb.Items.RemoveAt(listBoxBiginDraggingIndex);
                    lb.Items.Insert(curIndex, lbValueDragging);
                    lb.SelectedIndex = curIndex;
                    listBoxBiginDraggingIndex = curIndex;
                }
            }
        }

        private void lb_MouseUp(object sender, MouseEventArgs e)
        {
            listBoxBiginDraggingIndex = -1;
            lbValueDragging = null;
        }

        private void cbExpression_DropDownStyleChanged(object sender, EventArgs e)
        {
            checkBoxGetOutSpace.Enabled = cbExpression.DropDownStyle == ComboBoxStyle.Simple;
        }
        //private string GetListViewExpresion(string text)
        //{
        //    string strViewExpr;
        //    if (cbExpression.DropDownStyle == ComboBoxStyle.Simple)
        //    {
        //        strViewExpr = checkBoxGetOutSpace.Checked ? RmvExtrSpaces(cbExpression.Text) : cbExpression.Text;
        //        if (useQuotions) strViewExpr = "<" + strViewExpr + ">";
        //        else strViewExpr = strViewExpr;
        //    }
        //    else
        //    {
        //        strViewExpr = cbExpression.SelectedItem.ToString();
        //        if (((MyValueHandle)cbExpression.SelectedItem).Value == null || ((MyValueHandle)cbExpression.SelectedItem).Value == DBNull.Value)
        //            strViewExpr = "null";
        //        else if (useQuotions) strViewExpr = "<" + strViewExpr + ">";
        //    }
        //    return strViewExpr;
        //}
        private string GetListViewExpresion(string text, string operation, MyCondition mCnd)
        {
            if ((mCnd.Expression.Value == null || mCnd.Expression.Value == DBNull.Value) && useQuotions)
                return "null";

            if (useQuotions) 
                text = "<" + text + ">";
            else
                text = text.Substring(1, text.Length - 2);

            return text;
        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            useQuotions = checkBoxUseBracked.Checked;
            foreach (ListViewItem lvi in lvConditions.Items)
            {
                MyCondition mCnd = lvi.Tag as MyCondition;
                if (mCnd == null) continue;

                lvi.SubItems[2].Text = GetListViewExpresion(lvi.SubItems[2].Text, lvi.SubItems[1].Text, mCnd);
            }
        }
    }
}