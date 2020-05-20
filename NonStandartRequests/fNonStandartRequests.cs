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

        private string GetStringColumnsToSelect(string[] columns)
        {
            if (columns.Length < 1) return "";
            string strColumns = "";
            for (int i = 0; i < columns.Length - 1; i++)
            {
                // strColumns += columns[i] + " AS " + npgsqlCommandBuilder.QuoteIdentifier(columns[i]) + (i == columns.Length - 1 ? "" : ", ");
                strColumns += columns[i] + ", ";
            }
            strColumns += columns[columns.Length - 1];
            return strColumns;
        }

        private string GetStringAreaFrom(string[] tables)
        {
            if (tables.Length < 1) return "";
            string result = "";
            for (int i = 0; i < tables.Length - 1; i++)
            {
                result += npgsqlCommandBuilder.QuoteIdentifier(tables[i]) + ", ";
            }
            result += npgsqlCommandBuilder.QuoteIdentifier(tables[tables.Length - 1]);
            return result;
        }

        private List<MyTableFLink> GetMyTableLinks()
        {
            List<MyTableFLink> allMyTableLinks = new List<MyTableFLink>();
            using (var pCon = new NpgsqlConnection(sPostgresConn))
            {
                pCon.Open();
                var cmd = new NpgsqlCommand() { Connection = pCon };

                cmd.CommandText = $@"
        SELECT table_constraints.table_name        AS tn1,
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
        WHERE constraint_type = 'FOREIGN KEY';";

                using (var rd = cmd.ExecuteReader())
                {
                    while (rd.Read())
                    {
                        allMyTableLinks.Add(new MyTableFLink()
                        {
                            TableFirstName = rd["tn1"].ToString().ToLower(),
                            TableSecondName = rd["tn2"].ToString().ToLower(),
                            ColumnFirstName = rd["cn1"].ToString().ToLower(),
                            ColumnSecondName = rd["cn2"].ToString().ToLower(),
                        });
                    }
                }
            }
            return allMyTableLinks;
        }

        private List<MyTableFLink> GetPossibleLinks(string table, List<MyTableFLink> allMyTableLinks)
        {
            List<MyTableFLink> posibleRibs = new List<MyTableFLink>();

            foreach (var link in allMyTableLinks)
            {
                if (link.TableFirstName == table)
                {
                    posibleRibs.Add(link);
                }
                else if (link.TableSecondName == table)
                {
                    posibleRibs.Add(link.GetSwaped());
                }
            }
            return posibleRibs;
        }


        class MyGroupTables
        {
            public List<string> tables;
            public List<MyTableFLink> fKeyLinkeds;
            public MyGroupTables()
            {
                tables = new List<string>();
                fKeyLinkeds = new List<MyTableFLink>();
            }
            public bool ExistsTable(string table)
            {
                return table.Contains(table);
            }
        }

        private List<MyGroupTables> FindGroupsTables(List<string> tables, List<MyTableFLink> allMyTableLinks)
        {
            List<MyGroupTables> myGroupsTables = new List<MyGroupTables>();
            List<string> visited = new List<string>();
            MyGroupTables myGroupTables;
            string curTable;
            Queue<string> queue1 = new Queue<string>();

            while (tables.Count > 0)
            {
                myGroupTables = new MyGroupTables();
                curTable = tables.First();

                queue1.Clear();
                queue1.Enqueue(curTable);
                myGroupTables.tables.Add(curTable);

                while (queue1.Count > 0)
                {
                    curTable = queue1.Dequeue();
                    var possibleRibs = GetPossibleLinks(curTable, allMyTableLinks);
                    foreach (var rib in possibleRibs)
                    {
                        if (myGroupTables.fKeyLinkeds.FirstOrDefault(x => x.EqualSomeSide(rib)) == null && tables.Contains(rib.TableSecondName))
                        {
                            if (!myGroupTables.tables.Contains(rib.TableSecondName))
                            {
                                queue1.Enqueue(rib.TableSecondName);
                                myGroupTables.tables.Add(rib.TableSecondName);
                            }
                            myGroupTables.fKeyLinkeds.Add(rib);
                        }
                    }
                }
                foreach (var tbl in myGroupTables.tables)
                    tables.Remove(tbl);
                myGroupsTables.Add(myGroupTables);
            }
            return myGroupsTables;
        }

        private List<MyGroupTables> ConnectGroupsTables(List<MyGroupTables> myGroupsTables, List<MyTableFLink> allMyTableLinks)
        {
            string curTable;
            Queue<MyWay> queue2 = new Queue<MyWay>();
            List<KeyValuePair<string, MyGroupTables>> AllTablesInOtherGroup = new List<KeyValuePair<string, MyGroupTables>>();
            MyWay curWay;
            List<string> visited = new List<string>();

            for (int i = 0; i < myGroupsTables.Count() - 1; i++)
            {
                queue2.Clear();
                visited.Clear();
                AllTablesInOtherGroup.Clear();
                foreach (var item in myGroupsTables.Where(x => myGroupsTables.IndexOf(x) > i))
                    AllTablesInOtherGroup.AddRange(item.tables.Select(x => new KeyValuePair<string, MyGroupTables>(x, item)));
                var curGroup = myGroupsTables[i];
                foreach (var x in curGroup.tables)
                {
                    curWay = new MyWay();
                    curWay.curTable = x;

                    queue2.Enqueue(curWay);
                    visited.Add(x);
                }

                bool ready = false;
                while (queue2.Count > 0)
                {
                    curWay = queue2.Dequeue();
                    curTable = curWay.curTable;

                    var possibleRibs = GetPossibleLinks(curTable, allMyTableLinks);
                    foreach (var rib in possibleRibs)
                    {
                        if (AllTablesInOtherGroup.Select(x => x.Key).Contains(rib.TableSecondName))
                        {
                            var secondGroup = AllTablesInOtherGroup.FirstOrDefault(x => x.Key == rib.TableSecondName).Value;
                            curGroup.fKeyLinkeds.AddRange(curWay.fKeyLinkeds);
                            curGroup.fKeyLinkeds.Add(rib);
                            curGroup.tables.AddRange(secondGroup.tables);
                            curGroup.tables.AddRange(curWay.tables);
                            curGroup.fKeyLinkeds.AddRange(secondGroup.fKeyLinkeds);
                            myGroupsTables.Remove(secondGroup);
                            ready = true;
                            i--;
                            break;
                        }
                        if (!visited.Contains(rib.TableSecondName))
                        {
                            visited.Add(curTable);
                            var newWay = new MyWay();
                            newWay.tables.AddRange(curWay.tables);
                            newWay.tables.Add(rib.TableSecondName);
                            newWay.fKeyLinkeds.AddRange(curWay.fKeyLinkeds);
                            newWay.fKeyLinkeds.Add(rib);
                            newWay.curTable = rib.TableSecondName;
                            queue2.Enqueue(newWay);
                        }
                    }
                    if (ready) break;
                }
            }
            return myGroupsTables;
        }

        private string GetTablesRulesConnection(ref string[] tablesArray, List<MyTableFLink> allMyTableLinks)
        {
            string rulesConnection = "";
            if (tablesArray.Length < 1) return rulesConnection;

            List<MyGroupTables> myGroupsTables = FindGroupsTables(((string[])tablesArray.Clone()).ToList(),  allMyTableLinks);
            myGroupsTables = ConnectGroupsTables(myGroupsTables, allMyTableLinks);

            List<string> tables = new List<string>();
            foreach (var group in myGroupsTables)
            {
                foreach (var myTableLink in group.fKeyLinkeds)
                {
                    rulesConnection += myTableLink.GetStringToLink(npgsqlCommandBuilder)
                        + " AND ";
                }
                tables.AddRange(group.tables);
            }
            tablesArray = tables.ToArray();
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
            string[] columns = lbSelectedFieldsFields.Items.Cast<MyField>().Select(x => npgsqlCommandBuilder.QuoteIdentifier(x.TableName) + "." +
                            npgsqlCommandBuilder.QuoteIdentifier(x.ColumnName)).ToArray();
            string[] tables = lbSelectedFieldsFields.Items.Cast<MyField>().Select(x => x.TableName).Distinct().ToArray();

            if (columns.Length < 1 || tables.Length < 1)
            {
                MessageBox.Show("Вы ничего не выбрали на вкладке \"Поля\"");
                return;
            }

            sqlQuery = "SELECT " + GetStringColumnsToSelect(columns) + " ";

            List<MyTableFLink> allMyTableLinks = GetMyTableLinks();

            if (tables.Count() > 1)
            {
                string rules = GetTablesRulesConnection(ref tables, allMyTableLinks);
                sqlQuery += "FROM " + GetStringAreaFrom(tables) + " ";
                if (!string.IsNullOrWhiteSpace(rules))
                {
                    sqlQuery += "WHERE ";
                    sqlQuery += rules;
                }
            }
            else
            {
                sqlQuery += "FROM " + GetStringAreaFrom(tables) + " ";
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

        private void btConfigurateTranslation_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Все изменения будут сброшены", "", MessageBoxButtons.OKCancel) == DialogResult.OK)
            {
                var tf = new fTranslationColumns(fTranslationColumns.FormType.NeedChanges);
                if (tf.ShowDialog() != DialogResult.Cancel)
                {
                    tf.Dispose();
                }
                MessageBox.Show("Ты чо забыл??!?!??!?!?!");
            }
        }
    }
}