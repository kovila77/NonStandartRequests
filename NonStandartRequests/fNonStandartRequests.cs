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
using Npgsql;
using TranslationColumns;

namespace NonStandartRequests
{
    public partial class fNonStandartRequests : Form
    {
        string sPostgresConn = new NpgsqlConnectionStringBuilder()
        {
            Database = dbSettings.Default.DatabaseName,
            Host = dbSettings.Default.Host,
            Port = dbSettings.Default.Port,
            Username = dbSettings.Default.User,
            Password = dbSettings.Default.Password,
        }.ConnectionString;

        string sLiteConn = new SQLiteConnectionStringBuilder()
        {
            DataSource = dbSettings.Default.TranslationPath,
        }.ConnectionString;

        private string sqlQuery;

        NpgsqlCommandBuilder npgsqlCommandBuilder = new NpgsqlCommandBuilder();
        private ColumnHeader sortingColumn = null;

        private readonly string strColumnName = "column_name";
        private readonly string strTableName = "table_name";
        private readonly string strTranslation = "translation";

        MyFieldController myFieldController;

        public fNonStandartRequests()
        {
            InitializeComponent();
        }

        private void fNonStandartRequests_Load(object sender, EventArgs e)
        {
            myFieldController = new MyFieldController();
            //foreach (var item in myFieldController.Fields)
            //{
            //    lbAllFields.Items.Add(item.Name);
            //}
            foreach (var item in myFieldController.Fields)
            {
                lbAllFields.Items.Add(item);
            }
            lbAllFields.Sorted = true;

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
        }

        private void btLeftFieldFields_Click(object sender, EventArgs e)
        {
            if (lbSelectedFieldsFields.SelectedItem == null) return;
            var tmp = lbSelectedFieldsFields.SelectedItem;
            lbSelectedFieldsFields.Items.Remove(tmp);
            lbAllFields.Items.Add(tmp);
        }

        private void btAllRightFieldFields_Click(object sender, EventArgs e)
        {
            foreach (var itm in lbAllFields.Items)
                lbSelectedFieldsFields.Items.Add(itm);
            lbAllFields.Items.Clear();
        }

        private void btAllLeftFieldFields_Click(object sender, EventArgs e)
        {
            foreach (var itm in lbSelectedFieldsFields.Items)
                lbAllFields.Items.Add(itm);
            lbSelectedFieldsFields.Items.Clear();
        }

        //private void btTransl_Click(object sender, EventArgs e)
        //{
        //    throw new Exception("Отключенный модуль");
        //    var tf = new fTranslationColumns(fTranslationColumns.FormType.NeedChanges);
        //    tf.Show();
        //}

        private void btShowSQL_Click(object sender, EventArgs e) => createQuery(false);

        private void btExecute_Click(object sender, EventArgs e) => createQuery(true);

        private string GetColumnsToSelect(string[] columns)
        {
            string strColumns = "";
            for (int i = 0; i < columns.Length; i++)
            {
                // strColumns += columns[i] + " AS " + npgsqlCommandBuilder.QuoteIdentifier(columns[i]) + (i == columns.Length - 1 ? "" : ", ");
                strColumns += columns[i] + (i == columns.Length - 1 ? "" : ", ");
            }
            return strColumns;
        }

        private string GetAreaFrom(string[] tables)
        {
            string result = "FROM ";
            for (int i = 0; i < tables.Length; i++)
            {
                result += npgsqlCommandBuilder.QuoteIdentifier(tables[i]) + (i == tables.Length - 1 ? " " : ", ");
            }
            return result;
        }

        private string GetTablesRulesConnection(string[] tables)
        {
            List<MyTableFKeyLinked> myTableFKeyLinkeds = new List<MyTableFKeyLinked>();

            using (var pCon = new NpgsqlConnection(sPostgresConn))
            {
                pCon.Open();
                var cmd = new NpgsqlCommand() { Connection = pCon };

                cmd.CommandText = $@"
            SELECT table_constraints.table_name         AS tn1,
                    key_column_usage.column_name        AS cn1,
                    constraint_column_usage.table_name  AS tn2,
                    constraint_column_usage.column_name AS cn2
            FROM information_schema.table_constraints
                        JOIN information_schema.key_column_usage
                            ON table_constraints.constraint_name = key_column_usage.constraint_name
                                AND table_constraints.table_schema = key_column_usage.table_schema
                        JOIN information_schema.constraint_column_usage
                            ON constraint_column_usage.constraint_name = table_constraints.constraint_name
                                AND constraint_column_usage.constraint_schema = table_constraints.constraint_schema
                                AND constraint_column_usage.table_name = ANY (@tables)
            WHERE table_constraints.table_name = ANY (@tables)
                AND constraint_type = 'FOREIGN KEY';";

                cmd.Parameters.Add(new NpgsqlParameter("@tables", DbType.Object) { Value = tables });


                using (var rd = cmd.ExecuteReader())
                {
                    string res = "";
                    while (rd.Read())
                    {
                        res += rd["tn1"].ToString() + " " + rd["cn1"].ToString() + " " + rd["tn2"].ToString() + " " + rd["cn2"].ToString() + "\n";
                        myTableFKeyLinkeds.Add(new MyTableFKeyLinked()
                        {
                            TableFirstName = rd["tn1"].ToString(),
                            TableSecondName = rd["tn2"].ToString(),
                            ColumnFirstName = rd["cn1"].ToString(),
                            ColumnSecondName = rd["cn2"].ToString(),
                        });
                    }
                }
            }

            var ribs = myTableFKeyLinkeds.Select(x => new Rib(x.TableFirstName, x.TableSecondName)).ToList();
            string rulesConnection = "";

            //if (ribs.Count < 1) return rulesConnection;

            while (ribs.Count > 0)
            {
                var ostoveTree = OstoveTree.GetOstoveListToConnect(ribs);

                for (int i = 0; i < ostoveTree.Count; i++)
                {
                    var myTableLink = myTableFKeyLinkeds
                        .FirstOrDefault(x => x.TableFirstName == ostoveTree[i].from && x.TableSecondName == ostoveTree[i].to
                                            || x.TableFirstName == ostoveTree[i].to && x.TableSecondName == ostoveTree[i].from);

                    rulesConnection += myTableLink.GetStringToLink(npgsqlCommandBuilder)
                        + " AND ";

                    var fordel = ribs.Where(x => x.from == ostoveTree[i].from && x.to == ostoveTree[i].to
                                            || x.from == ostoveTree[i].to && x.to == ostoveTree[i].from).ToArray();
                    if (fordel.Count() > 0)
                        foreach (var item in fordel)
                            ribs.Remove(item);
                }
            }
            if (rulesConnection.Length > 1) return rulesConnection.Remove(rulesConnection.Length - 4);

            return rulesConnection;
        }

        private string GetFormattedValue(object val)
        {
            //val == null || val == DBNull.Value ? "" : val.ToString();
            if (val == null || val == DBNull.Value) return "";
            if (val.GetType() == typeof(byte[])) return Convert.ToBase64String((byte[])val);

            return val.ToString();
        }

        private void createQuery(bool executeQuery)
        {
            //string[] columns = (from field in myFieldController.Fields
            //                    where lbSelectedFieldsFields.Items.Contains(field.Name)
            //                    select npgsqlCommandBuilder.QuoteIdentifier(field.TableName) + "." +
            //                    npgsqlCommandBuilder.QuoteIdentifier(field.ColumnName)).ToArray();
            //List<string> tempForColumns = new List<string>();
            //for (int i = 0; i < lbSelectedFieldsFields.Items.Count; i++)
            //{
            //    var field = myFieldController.Fields.FirstOrDefault(x => x.Name == lbSelectedFieldsFields.Items[i].ToString());
            //    tempForColumns.Add(npgsqlCommandBuilder.QuoteIdentifier(field.TableName) + "." +
            //                npgsqlCommandBuilder.QuoteIdentifier(field.ColumnName));
            //}
            //string[] columns = tempForColumns.ToArray();
            string[] columns = lbSelectedFieldsFields.Items.Cast<MyField>().Select(x => npgsqlCommandBuilder.QuoteIdentifier(x.TableName) + "." +
                            npgsqlCommandBuilder.QuoteIdentifier(x.ColumnName)).ToArray();
            //string[] tables = (from field in myFieldController.Fields
            //                   where lbSelectedFieldsFields.Items.Contains(field.Name)
            //                   select (field.TableName)).Distinct().ToArray();
            string[] tables = lbSelectedFieldsFields.Items.Cast<MyField>().Select(x => x.TableName).Distinct().ToArray();

            if (columns.Length < 1 || tables.Length < 1)
            {
                MessageBox.Show("Вы ничего не выбрали на вкладке \nПоля\n");
                return;
            }

            sqlQuery = "SELECT " + GetColumnsToSelect(columns) + " ";

            sqlQuery += GetAreaFrom(tables);

            if (tables.Count() > 1)
            {
                string rules = GetTablesRulesConnection(tables);
                if (!string.IsNullOrWhiteSpace(rules))
                {
                    sqlQuery += "WHERE ";
                    sqlQuery += rules;
                }
            }
            if (!executeQuery)
            {
                MessageBox.Show(sqlQuery);
                return;
            }

            lvResult.Clear();
            sortingColumn = null;
            for (int i = 0; i < lbSelectedFieldsFields.Items.Count; i++)
            {
                lvResult.Columns.Add(lbSelectedFieldsFields.Items[i].ToString());
            }

            using (var pConn = new NpgsqlConnection(sPostgresConn))
            {
                pConn.Open();
                var cmd = new NpgsqlCommand() { Connection = pConn };
                cmd.CommandText = sqlQuery;

                using (var rd = cmd.ExecuteReader())
                {
                    while (rd.Read())
                    {
                        List<string> fields = new List<string>();
                        //foreach (var field_name in columns)
                        //{
                        //    fields.Add(rd[field_name] == null || rd[field_name] == DBNull.Value ? "" : rd[field_name].ToString());
                        //}
                        for (int i = 0; i < columns.Length; i++)
                        {
                            var val = rd[i];
                            fields.Add(GetFormattedValue(val));
                        }
                        lvResult.Items.Add(new ListViewItem(fields.ToArray()));
                    }
                }

                tcQuery.SelectTab(tcQuery.TabPages.Count - 1);
                lvResult.AutoResizeColumns(ColumnHeaderAutoResizeStyle.ColumnContent);
                lvResult.AutoResizeColumns(ColumnHeaderAutoResizeStyle.HeaderSize);
            }
        }


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
}