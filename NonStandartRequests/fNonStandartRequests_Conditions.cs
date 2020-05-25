using Npgsql;
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
        private void cbFieldName_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cbFieldName.SelectedItem == null) return;
            cbCriterion.Items.Clear();
            cbExpression.Items.Clear();
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

            cbExpression.Items.Clear();

            foreach (var item in expressionList)
            {
                cbExpression.Items.Add(new MyValueHandle(item, fieldType));
            }
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

                cmd.CommandText = $@"SELECT DISTINCT {fieldName}
                                    FROM {tableName};";

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
            var newLvi = new ListViewItem(new[] {
                cbFieldName.SelectedItem.ToString(),
                cbCriterion.SelectedItem.ToString(),
                cbExpression.SelectedItem.ToString(),
                cbLigament.SelectedItem.ToString()
            });
            //newLvi.Tag = cbFieldName.SelectedItem;
            newLvi.Tag = new KeyValuePair<MyField, object>((MyField)cbFieldName.SelectedItem, cbExpression.SelectedItem);

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
        }
    }
}
