//using Npgsql;
//using System;
//using System.Collections.Generic;
//using System.Data.SQLite;
//using System.Linq;
//using System.Text;
//using System.Threading.Tasks;

//namespace NonStandartRequests
//{
//    static class FreshFieldLoader
//    {
//        private static readonly string strColumnName = "column_name";
//        private static readonly string strTableName = "table_name";
//        private static readonly string strTranslation = "translation";

//        public Dictionary<string, KeyValuePair<string, string>> GetFreshFields(string sPostgresConn, string sLiteConn)
//        {
//            var res = new Dictionary<string, KeyValuePair<string, string>>();

//            using (var liteConn = new SQLiteConnection(sLiteConn))
//            {
//                liteConn.Open();

//                var cmd = new SQLiteCommand() { Connection = liteConn, CommandText = @"SELECT column_name, table_name, translation FROM translation;" };
//                using (var rd = cmd.ExecuteReader())
//                {
//                    while (rd.Read())
//                        dataGridView1.Rows.Add(rd[strColumnName], rd[strTableName], rd[strTranslation]);
//                }

//                cmd.CommandText = @"BEGIN TRANSACTION;";
//                cmd.ExecuteNonQuery();
//                cmd.CommandText = @"INSERT INTO translation (column_name, table_name, translation) VALUES (@cn, @tn, @tr);";

//                using (var postConn = new NpgsqlConnection(sPostgresConn))
//                {
//                    postConn.Open();

//                    var pCom = new NpgsqlCommand()
//                    {
//                        Connection = postConn,
//                        CommandText = @"SELECT column_name, table_name
//                                    FROM information_schema.columns
//                                    WHERE table_schema = 'public'
//                                      AND NOT exists(SELECT 1
//                                            FROM information_schema.table_constraints AS tc
//                                                    JOIN information_schema.key_column_usage AS kcu
//                                                        ON tc.constraint_name = kcu.constraint_name
//                                                            AND tc.table_schema = kcu.table_schema
//                                                    JOIN information_schema.constraint_column_usage AS ccu
//                                                        ON ccu.constraint_name = tc.constraint_name
//                                                            AND ccu.table_schema = tc.table_schema
//                                            WHERE tc.constraint_type = 'FOREIGN KEY'
//                                            AND ccu.column_name = columns.column_name AND columns.table_name <> ccu.table_name);",
//                    };
//                    using (var rdr = pCom.ExecuteReader())
//                    {
//                        while (rdr.Read())
//                        {
//                            string column = ((string)rdr[strColumnName]).ToLower();
//                            string table = ((string)rdr[strTableName]).ToLower();
//                            int index = -1;
//                            if (dataGridView1.Rows.Count > 0)
//                            {
//                                if (dataGridView1.Rows.Cast<DataGridViewRow>().FirstOrDefault(x => x.Cells[strTableName].FormattedValue.ToString().ToLower() == table && x.Cells[strColumnName].FormattedValue.ToString().ToLower() == column) == null)
//                                {
//                                    foreach (DataGridViewRow row1 in dataGridView1.Rows)
//                                    {
//                                        if (row1.Cells[strTranslation].FormattedValue.ToString() == column)
//                                        {
//                                            MessageBox.Show("Значение перевода уже существует! Измените его и повторно запустите процесс!");
//                                            this.Visible = true;
//                                            formType = FormType.NeedChanges;
//                                            dataGridView1.ClearSelection();
//                                            dataGridView1[dataGridView1.Columns[strTranslation].Index, row1.Index].Selected = true;
//                                            dataGridView1[dataGridView1.Columns[strTranslation].Index, row1.Index].Style.BackColor = Color.Red;
//                                            cmd.CommandText = @"COMMIT;";
//                                            cmd.ExecuteNonQuery();
//                                            return;
//                                        }
//                                    }
//                                    index = dataGridView1.Rows.Add(column, table, column);
//                                }
//                                else continue;
//                            }
//                            else
//                            {
//                                index = dataGridView1.Rows.Add(column, table, column);
//                            }
//                            if (index == -1) throw new Exception("Такого не должно было случиться!");
//                            var row = dataGridView1.Rows[index];
//                            cmd.Parameters.AddWithValue("cn", row.Cells[strColumnName].FormattedValue.ToString());
//                            cmd.Parameters.AddWithValue("tn", row.Cells[strTableName].FormattedValue.ToString());
//                            cmd.Parameters.AddWithValue("tr", row.Cells[strTranslation].FormattedValue.ToString());


//                            cmd.ExecuteNonQuery();
//                        }
//                    }
//                }

//                cmd.CommandText = @"COMMIT;";
//                cmd.ExecuteNonQuery();
//            }
//        }
//    }
//}
