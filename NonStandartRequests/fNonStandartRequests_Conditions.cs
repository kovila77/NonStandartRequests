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

            lvConditionSelectedItem = null;
            btAddCondition.Text = "Добавить";

            PrepareCBCriterionAndExpression();
        }

        private void PrepareCBCriterionAndExpression()
        {
            cbCriterion.Items.Clear();
            cbCriterion.Items.Add("=");
            cbCriterion.Items.Add("<>");
            cbCriterion.SelectedIndex = 0;

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
            
            expressionList.Sort(new MyComparerForFields(SortOrder.Ascending, fieldType));
            cbExpression.DataSource = expressionList.Select(x => new MyValueHandle(x, fieldType)).ToList();
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

        class MyCondition
        {
            public readonly int FieldIndex;
            public readonly MyField Field;
            public readonly int ExpressionIndex;
            public readonly MyValueHandle Expression;
            public readonly int CriterionIndex;
            public int LigamentIndex;

            public MyCondition(int FieldIndex, MyField Field, int ExpressionIndex, MyValueHandle Expression, int CriterionIndex, int LigamentIndex)
            {
                this.FieldIndex = FieldIndex;
                this.Field = Field;
                this.ExpressionIndex = ExpressionIndex;
                this.Expression = Expression;
                this.CriterionIndex = CriterionIndex;
                this.LigamentIndex = LigamentIndex;
            }
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
                if (cbExpression.Items.Count > 0)
                    MessageBox.Show("Вы должны выбрать значение, с которым будет происходить сравнение!");
                else
                    MessageBox.Show("Данное поле нельзя добавить, так как нет значений для выбора!");
                return;
            }

            if (lvConditionSelectedItem != null)
            {
                lvConditionSelectedItem.SubItems[0].Text = cbFieldName.SelectedItem.ToString();
                lvConditionSelectedItem.SubItems[1].Text = cbCriterion.SelectedItem.ToString();
                lvConditionSelectedItem.SubItems[2].Text = cbExpression.SelectedItem.ToString();
                lvConditionSelectedItem.SubItems[3].Text = cbLigament.SelectedItem == null ? "" : cbLigament.SelectedItem.ToString();
                lvConditionSelectedItem.Tag = new MyCondition(
                    cbFieldName.SelectedIndex,
                    (MyField)cbFieldName.SelectedItem,
                    cbExpression.SelectedIndex,
                    (MyValueHandle)cbExpression.SelectedItem,
                    cbCriterion.SelectedIndex,
                    cbLigament.SelectedIndex
                    );

            }
            else
            {

                if (lvConditions.Items.Count > 0)
                {
                    lvConditions.Items[lvConditions.Items.Count - 1].SubItems[3].Text = "И";
                    ((MyCondition)lvConditions.Items[lvConditions.Items.Count - 1].Tag).LigamentIndex = 0;
                }

                var newLvi = new ListViewItem(new[] {
                    cbFieldName.SelectedItem.ToString(),
                    cbCriterion.SelectedItem.ToString(),
                    cbExpression.SelectedItem.ToString(),
                    cbLigament.SelectedItem == null? "":cbLigament.SelectedItem.ToString()
                });
                newLvi.Tag = new MyCondition(
                    cbFieldName.SelectedIndex,
                    (MyField)cbFieldName.SelectedItem,
                    cbExpression.SelectedIndex,
                    (MyValueHandle)cbExpression.SelectedItem,
                    cbCriterion.SelectedIndex,
                    cbLigament.SelectedIndex
                    );
                lvConditions.Items.Add(newLvi);
            }

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
                ((MyCondition)lvConditions.Items[lvConditions.Items.Count - 1].Tag).LigamentIndex = -1;
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

            lvConditionSelectedItem = lvConditions.SelectedItems[0];
            btAddCondition.Text = "Изменить";

            MyCondition myCnd = (MyCondition)lvConditions.SelectedItems[0].Tag;

            cbFieldName.SelectedIndexChanged -= cbFieldName_SelectedIndexChanged;
            cbFieldName.SelectedIndex = myCnd.FieldIndex;
            PrepareCBCriterionAndExpression();
            cbFieldName.SelectedIndexChanged += cbFieldName_SelectedIndexChanged;

            cbCriterion.SelectedIndex = myCnd.CriterionIndex;
            cbExpression.SelectedIndex = myCnd.ExpressionIndex;

            cbLigament.Items.Clear();
            if (myCnd.LigamentIndex >= 0)
            {
                cbLigament.Items.Add("И");
                cbLigament.Items.Add("ИЛИ");
            }
            cbLigament.SelectedIndex = myCnd.LigamentIndex;
        }
    }
}
