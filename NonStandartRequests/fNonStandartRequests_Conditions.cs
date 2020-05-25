using Npgsql;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace NonStandartRequests
{
    public partial class fNonStandartRequests : Form
    {
        private void cbFieldName_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cbFieldName.SelectedItem == null) return;
            cbCriterion.Items.Clear();
            //cbExpression.Items.Clear();
            cbCriterion.Items.Add("=");
            cbCriterion.Items.Add("<>");
            cbCriterion.SelectedIndex = 0;

            //    string fieldType;
            //    using (var pCon = new NpgsqlConnection(sPostgresConn))
            //    {
            //        pCon.Open();
            //        var cmd = new NpgsqlCommand() { Connection = pCon };

            //        cmd.CommandText = $@"
            //SELECT data_type
            //FROM information_schema.columns
            //WHERE table_schema NOT IN ('information_schema', 'pg_catalog')
            //  AND table_name = @tn
            //  AND column_name = @cn;";

            //        cmd.Parameters.Add(new NpgsqlParameter("@tn", ((MyField)cbFieldName.SelectedItem).TableName));
            //        cmd.Parameters.Add(new NpgsqlParameter("@cn", ((MyField)cbFieldName.SelectedItem).ColumnName));

            //        fieldType = cmd.ExecuteScalar().ToString().ToLower();
            //    }

            string fieldType;
            List<object> expressionList =
                GetDistinctValueOfField(((MyField)cbFieldName.SelectedItem).ColumnName,
                                        ((MyField)cbFieldName.SelectedItem).TableName,
                                        out fieldType);

            if (fieldType == "integer" || fieldType == "date" || fieldType == "interval")
            {
                cbCriterion.Items.Add(">");
                cbCriterion.Items.Add(">=");
                cbCriterion.Items.Add("<");
                cbCriterion.Items.Add("<=");
            }

            //if (fieldType == "date")
            //{
            //    foreach (var date in expressionList.Cast<DateTime>())
            //    {
            //        date.for
            //    }
            //}

            //cbExpression.Items.Clear();
            expressionList.Sort(new MyComparerForFields(SortOrder.Ascending, fieldType));
            cbExpression.DataSource = expressionList.Select(x => new MyValueHandle(x, fieldType)).ToList();

            //foreach (var item in expressionList)
            //{
            //    cbExpression.Items.Add(new MyValueHandle(item, fieldType));
            //}
        }

        private List<object> GetDistinctValueOfField(string fieldName, string tableName, out string fieldType)
        {
            List<object> res = new List<object>();
            using (var pCon = new NpgsqlConnection(sPostgresConn))
            {
                pCon.Open();
                var cmd = new NpgsqlCommand() { Connection = pCon };

                cmd.CommandText = $@"
        SELECT data_type
        FROM information_schema.columns
        WHERE table_schema NOT IN ('information_schema', 'pg_catalog')
          AND table_name = @tn
          AND column_name = @cn;";

                cmd.Parameters.Add(new NpgsqlParameter("@tn", ((MyField)cbFieldName.SelectedItem).TableName));
                cmd.Parameters.Add(new NpgsqlParameter("@cn", ((MyField)cbFieldName.SelectedItem).ColumnName));

                fieldType = cmd.ExecuteScalar().ToString().ToLower();

                cmd.CommandText = $@"SELECT DISTINCT {npgsqlCommandBuilder.QuoteIdentifier(fieldName)}
                                    FROM {npgsqlCommandBuilder.QuoteIdentifier(tableName)};";

                using (var rd = cmd.ExecuteReader())
                {
                    while (rd.Read())
                    {
                        res.Add(rd[fieldName]);
                    }
                }
            }
            return res;
        }

        private void btAddCondition_Click(object sender, EventArgs e)
        {
            if (cbFieldName.SelectedItem == null)
            {
                MessageBox.Show("Вы должны выбрать поле!");
                return;
            }
            if (cbCriterion.SelectedItem == null)
            {
                MessageBox.Show("Вы должны выбрать критерий сравнения!");
                return;
            }
            if (cbExpression.SelectedItem == null)
            {
                MessageBox.Show("Вы должны выбрать значение, с которым будет происходить сравнение!");
                return;
            }

            if (lvConditions.Items.Count > 0)
            {
                lvConditions.Items[lvConditions.Items.Count - 1].SubItems[3].Text = "И";
            }

            var newLvi = new ListViewItem(new[] {
                cbFieldName.SelectedItem.ToString(),
                cbCriterion.SelectedItem.ToString(),
                cbExpression.SelectedItem.ToString(),
                cbLigament.SelectedItem == null? "":cbLigament.SelectedItem.ToString()
            });
            //newLvi.Tag = cbFieldName.SelectedItem;
            newLvi.Tag = new KeyValuePair<MyField, object>((MyField)cbFieldName.SelectedItem, cbExpression.SelectedItem);
            //newLvi.Tag = new
            //{
            //    Field = (MyField)cbFieldName.SelectedItem,
            //    Expression = cbExpression.SelectedItem,

            //};

            //foreach (ListViewItem lvi in lvConditions.Items)
            //{
            //    if (lvi.SubItems[0].Text == newLvi.SubItems[0].Text && lvi.SubItems[2].Text == newLvi.SubItems[2].Text)
            //    {
            //        MessageBox.Show("Выражения для поля уже использовалось в другом условии!");
            //        return;
            //    }
            //}


            lvConditions.Items.Add(newLvi);
            lvConditions.AutoResizeColumns(ColumnHeaderAutoResizeStyle.ColumnContent);
            lvConditions.AutoResizeColumns(ColumnHeaderAutoResizeStyle.HeaderSize);
        }

        private void btDeleteCondition_Click(object sender, EventArgs e)
        {
            foreach (ListViewItem item in lvConditions.SelectedItems)
            {
                lvConditions.Items.Remove(item);
            }
            if (lvConditions.Items.Count > 0)
            {
                lvConditions.Items[lvConditions.Items.Count - 1].SubItems[3].Text = "";
            }

        }

        private class MyComparerForFields : IComparer<object>
        {
            private static int sortOrderModifier = 1;
            string fieldType;

            public MyComparerForFields(SortOrder sortOrder, string fieldType)
            {
                this.fieldType = fieldType;
                if (sortOrder == SortOrder.Descending)
                {
                    sortOrderModifier = -1;
                }
                else if (sortOrder == SortOrder.Ascending)
                {
                    sortOrderModifier = 1;
                }
            }

            public int Compare(object x, object y)
            {
                //throw new Exception();

                if (x == null || x == DBNull.Value) return -1 * sortOrderModifier;
                if (y == null || y == DBNull.Value) return 1 * sortOrderModifier;

                int CompareResult = 0;

                if (fieldType == "integer")
                {
                    var v1 = (int)x;
                    var v2 = (int)y;
                    CompareResult = v1.CompareTo(v2);
                    //CompareResult = v1 > v2 ? 1 : (v1 == v2 ? 0 : -1);
                }
                else if (fieldType == "date")
                {
                    var v1 = (DateTime)x;
                    var v2 = (DateTime)y;
                    CompareResult = v1.CompareTo(v2);
                }
                else if (fieldType == "bytea")
                {
                    var v1 = Convert.ToBase64String((byte[])x);
                    var v2 = Convert.ToBase64String((byte[])y);
                    CompareResult = v1.CompareTo(v2);
                }
                else
                {
                    CompareResult = x.ToString().CompareTo(y.ToString());
                }
                return CompareResult * sortOrderModifier;
            }
        }

        private void lvConditions_Click(object sender, EventArgs e)
        {
            if (lvConditions.SelectedItems == null) return;

            var selectedLvi = lvConditions.SelectedItems[0];

            cbFieldName.SelectedItem = ((KeyValuePair<MyField, object>)selectedLvi.Tag).Key;
            cbCriterion.SelectedItem = selectedLvi.SubItems[1].Text;
            cbExpression.SelectedItem = selectedLvi.SubItems[1].;sdfrgtawerwgaedrth
            cbLigament.SelectedItem = selectedLvi.SubItems[3];
        }
    }
}
