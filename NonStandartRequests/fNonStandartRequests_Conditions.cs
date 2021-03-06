﻿using Npgsql;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace NonStandartRequests
{
    public partial class fNonStandartRequests : Form
    {
        private string[] comparedFieldTypes = new string[]
        {
            "smallint", "integer", "bigint", "decimal", "numeric", "real", "double precision", "smallserial", "serial", "bigserial",
            "date",
            "interval",
        };

        private string[] textFieldTypes = new string[]
        {
            "text", "varchar", "character varying", "char", "character",
        };

        private void cbFieldName_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cbFieldName.SelectedItem == null) return;

            lvConditionSelectedItem = null;
            lvConditions.SelectedItems.Clear();
            //btAddCondition.Text = "Добавить";
            btChangeCond.Enabled = false;

            PrepareCBCriterionAndExpression();
        }

        private void cbCriterion_SelectedIndexChanged(object sender, EventArgs e)
        {
            if ((string)cbCriterion.SelectedItem == strBeginsFromConditionText || (string)cbCriterion.SelectedItem == strContainsConditionText)
            {
                cbExpression.DropDownStyle = ComboBoxStyle.Simple;
                cbExpression.AllowDrop = false;
            }
            else
            {
                cbExpression.DropDownStyle = ComboBoxStyle.DropDownList;
                cbExpression.AllowDrop = true;
            }
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

            //if (fieldType == "integer" || fieldType == "numeric" || fieldType == "date" || fieldType == "interval")
            if (comparedFieldTypes.Contains(fieldType))
            {
                cbCriterion.Items.Add(">");
                cbCriterion.Items.Add(">=");
                cbCriterion.Items.Add("<");
                cbCriterion.Items.Add("<=");
            }
            else if (textFieldTypes.Contains(fieldType))
            {
                cbCriterion.Items.Add(strContainsConditionText);
                cbCriterion.Items.Add(strBeginsFromConditionText);
            }

            expressionList.Sort(new MyComparerForFields(SortOrder.Ascending, fieldType));
            cbExpression.DropDownStyle = ComboBoxStyle.DropDownList;
            cbExpression.AllowDrop = true;
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

        private bool IsNewConditionReady()
        {
            if (cbFieldName.SelectedItem == null)
            {
                MessageBox.Show("Вы должны выбрать поле!");
                return false;
            }
            if (cbCriterion.SelectedItem == null)
            {
                MessageBox.Show("Вы должны выбрать критерий сравнения!");
                return false;
            }
            if (cbExpression.DropDownStyle == ComboBoxStyle.Simple)
            {
                if (RmvExtrSpaces(cbExpression.Text) == "" && checkBoxGetOutSpace.Checked || cbExpression.Text == "" && !checkBoxGetOutSpace.Checked)
                {
                    MessageBox.Show("Вы должны выбрать не пустое значение для поиска в строке!");
                    return false;
                }
            }
            else if (cbExpression.SelectedItem == null)
            {
                if (cbExpression.Items.Count > 0)
                    MessageBox.Show("Вы должны выбрать значение, с которым будет происходить сравнение!");
                else
                    MessageBox.Show("Данное поле нельзя добавить, так как нет значений для выбора!");
                return false;
            }
            return true;
        }

       

        private void btAddCondition_Click(object sender, EventArgs e)
        {
            if (!IsNewConditionReady()) return;

            if (lvConditions.Items.Count > 0)
            {
                lvConditions.Items[lvConditions.Items.Count - 1].SubItems[3].Text = "И";
                ((MyCondition)lvConditions.Items[lvConditions.Items.Count - 1].Tag).LigamentIndex = 0;
            }

            //if (lvConditionSelectedItem != null && lvConditions.Items.Count - 1 == lvConditionSelectedItem.Index && string.IsNullOrEmpty(cbLigament.Text))
            //{
            //    lvConditionSelectedItem.SubItems[3].Text = "И";
            //    cbLigament.Items.Add("И");
            //    cbLigament.Items.Add("ИЛИ");
            //    ((MyCondition)lvConditionSelectedItem.Tag).LigamentIndex = 0;
            //}
            string strExpr;
            string strViewExpr;
            if (cbExpression.DropDownStyle == ComboBoxStyle.Simple)
            {
                strExpr = checkBoxGetOutSpace.Checked ? RmvExtrSpaces(cbExpression.Text) : cbExpression.Text;
                if (useQuotions) strViewExpr = "<" + strExpr + ">";
                else strViewExpr = strExpr;
            }
            else
            {
                strExpr = null;
                strViewExpr = cbExpression.SelectedItem.ToString();
                if (((MyValueHandle)cbExpression.SelectedItem).Value == null || ((MyValueHandle)cbExpression.SelectedItem).Value == DBNull.Value)
                    strViewExpr = "null";
                else if (useQuotions) strViewExpr = "<" + strViewExpr + ">";
            }

            var myCnd = new MyCondition(
                cbFieldName.SelectedIndex,
                (MyField)cbFieldName.SelectedItem,
                cbExpression.SelectedIndex,
                strExpr,
                cbExpression.DropDownStyle == ComboBoxStyle.Simple ? new MyValueHandle(strExpr, "text") : (MyValueHandle)cbExpression.SelectedItem,
                cbCriterion.SelectedIndex,
                -1
                );

            var newLvi = new ListViewItem(new[] {
                    cbFieldName.SelectedItem.ToString(),
                    cbCriterion.SelectedItem.ToString(),
                    strViewExpr,
                    ""
                });
            newLvi.Tag = myCnd;
            lvConditions.SelectedItems.Clear();
            lvConditions.Items.Add(newLvi).Selected = true;

            lvConditions.AutoResizeColumns(ColumnHeaderAutoResizeStyle.ColumnContent);
            lvConditions.AutoResizeColumns(ColumnHeaderAutoResizeStyle.HeaderSize);
        }



        private void btChangeCond_Click(object sender, EventArgs e)
        {
            if (lvConditionSelectedItem == null) return;

            if (!IsNewConditionReady()) return;

            string strExpr;
            string strViewExpr;
            if (cbExpression.DropDownStyle == ComboBoxStyle.Simple)
            {
                strExpr = checkBoxGetOutSpace.Checked ? RmvExtrSpaces(cbExpression.Text) : cbExpression.Text;
                if (useQuotions) strViewExpr = "<" + strExpr + ">";
                else strViewExpr = strExpr;
            }
            else
            {
                strExpr = null;
                strViewExpr = cbExpression.SelectedItem.ToString();
                if (((MyValueHandle)cbExpression.SelectedItem).Value == null || ((MyValueHandle)cbExpression.SelectedItem).Value == DBNull.Value)
                    strViewExpr = "null";
                else if (useQuotions) strViewExpr = "<" + strViewExpr + ">";
            }

            var myCnd = new MyCondition(
                cbFieldName.SelectedIndex,
                (MyField)cbFieldName.SelectedItem,
                cbExpression.SelectedIndex,
                strExpr,
                cbExpression.DropDownStyle == ComboBoxStyle.Simple ? new MyValueHandle(strExpr, "text") : (MyValueHandle)cbExpression.SelectedItem,
                cbCriterion.SelectedIndex,
                cbLigament.SelectedIndex
                );

            lvConditionSelectedItem.SubItems[0].Text = cbFieldName.SelectedItem.ToString();
            lvConditionSelectedItem.SubItems[1].Text = cbCriterion.SelectedItem.ToString();
            lvConditionSelectedItem.SubItems[2].Text = strViewExpr;
            lvConditionSelectedItem.SubItems[3].Text = cbLigament.SelectedItem == null ? "" : cbLigament.SelectedItem.ToString();
            lvConditionSelectedItem.Tag = myCnd;

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
                lvConditions.Items[0].Selected = true;
            }
            else
            {
                btChangeCond.Enabled = false;
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

        private void lvConditions_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (lvConditions.SelectedItems == null || lvConditions.SelectedItems.Count < 1)
            {
                btDeleteCondition.Enabled = false;
                btChangeCond.Enabled = false;
                return;
            }

            btDeleteCondition.Enabled = true;

            lvConditionSelectedItem = lvConditions.SelectedItems[0];
            //btAddCondition.Text = "Изменить";
            btChangeCond.Enabled = true;

            MyCondition myCnd = (MyCondition)lvConditions.SelectedItems[0].Tag;

            cbFieldName.SelectedIndexChanged -= cbFieldName_SelectedIndexChanged;
            cbFieldName.SelectedIndex = myCnd.FieldIndex;
            PrepareCBCriterionAndExpression();
            cbFieldName.SelectedIndexChanged += cbFieldName_SelectedIndexChanged;

            cbCriterion.SelectedIndex = myCnd.CriterionIndex;

            if (cbExpression.DropDownStyle == ComboBoxStyle.Simple)
            {
                //if (USE_QUOTIONS)
                //   cbExpression.Text = myCnd.cbExpressionText.Substring(1, myCnd.cbExpressionText.Length - 2);
                //else
                cbExpression.Text = myCnd.cbExpressionText;
            }
            else
                cbExpression.SelectedIndex = myCnd.ExpressionIndex;

            cbLigament.Items.Clear();
            if (myCnd.LigamentIndex >= 0)
            {
                cbLigament.Items.Add("И");
                cbLigament.Items.Add("ИЛИ");
            }
            cbLigament.SelectedIndex = myCnd.LigamentIndex;
        }

        public static string RmvExtrSpaces(string str)
        {
            if (str == null) return str;
            str = str.Trim();
            str = Regex.Replace(str, @"\s+", " ");
            return str;
        }
    }
}
