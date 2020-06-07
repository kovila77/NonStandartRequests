using Npgsql;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration;
using System.Data.SQLite;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NonStandartRequests
{
    internal class MyFieldController
    {
        private static readonly string strColumnName = "column_name";
        private static readonly string strTableName = "table_name";
        //private static readonly string strTranslation = "translation";

        string sPostgresConn = new NpgsqlConnectionStringBuilder()
        {
            Database = Properties.Settings.Default.Database,
            Host = Properties.Settings.Default.Host,
            Port = Properties.Settings.Default.Port,
            Username = Properties.Settings.Default.User,
            Password = Properties.Settings.Default.Password,
        }.ConnectionString;
        //string sPostgresConn = new NpgsqlConnectionStringBuilder()
        //{
        //    Database = Properties.Settings.Default.Properties["setting"],
        //    Host = ConfigurationManager.AppSettings["Host"],
        //    Port = Convert.ToInt32(ConfigurationManager.AppSettings["Port"]),
        //    Username = ConfigurationManager.AppSettings["User"],
        //    Password = ConfigurationManager.AppSettings["Password"],
        //}.ConnectionString;

        string sLiteConn = new SQLiteConnectionStringBuilder()
        {
            DataSource = Properties.Settings.Default.TranslationPath,
        }.ConnectionString;

        private BindingList<MyField> _fields;

        public BindingList<MyField> Fields { get => _fields; }

        public MyFieldController()
        {

            _fields = new BindingList<MyField>();
            Initialize();
        }

        private string GetFieldType(string tableName, string columnName)
        {
            using (var psgCon = new NpgsqlConnection(sPostgresConn))
            {
                psgCon.Open();
                var cmd = new NpgsqlCommand() { Connection = psgCon };

                cmd.CommandText = $@"
        SELECT data_type
        FROM information_schema.columns
        WHERE table_schema = 'public'
          AND table_name = @tn
          AND column_name = @cn;";

                cmd.Parameters.Add(new NpgsqlParameter("@tn", tableName));
                cmd.Parameters.Add(new NpgsqlParameter("@cn", columnName));

                return cmd.ExecuteScalar().ToString().ToLower();
            }
        }

        public void Initialize()
        {
            _fields.Clear();
            using (var liteConn = new SQLiteConnection(sLiteConn))
            {
                liteConn.Open();

                var sqliteCmd = new SQLiteCommand() { Connection = liteConn, CommandText = @"SELECT 1 FROM sqlite_master WHERE type = 'table' AND tbl_name = 'translation';" };

                if (sqliteCmd.ExecuteScalar() == null)
                {
                    sqliteCmd.CommandText = "CREATE TABLE translation"
                                      + "("
                                      + "    column_name text,"
                                      + "    table_name  text,"
                                      + "    translation text,"
                                      + "     constraint translation_pk"
                                      + "        primary key(column_name, table_name)"
                                      + ")";
                    sqliteCmd.ExecuteNonQuery();
                }

                using (var postConn = new NpgsqlConnection(sPostgresConn))
                {
                    postConn.Open();

                    var psgCmd = new NpgsqlCommand()
                    {
                        Connection = postConn,
                        //CommandText = @"SELECT column_name, table_name
                        //            FROM information_schema.columns
                        //            WHERE table_schema = 'public'
                        //              AND NOT exists(SELECT 1
                        //                    FROM information_schema.table_constraints AS tc
                        //                            JOIN information_schema.key_column_usage AS kcu
                        //                                ON tc.constraint_name = kcu.constraint_name
                        //                                    AND tc.table_schema = kcu.table_schema
                        //                            JOIN information_schema.constraint_column_usage AS ccu
                        //                                ON ccu.constraint_name = tc.constraint_name
                        //                                    AND ccu.table_schema = tc.table_schema
                        //                    WHERE tc.constraint_type = 'FOREIGN KEY'
                        //                    AND ccu.column_name = columns.column_name AND columns.table_name <> ccu.table_name);",
                        CommandText = @"SELECT DISTINCT column_name, table_name
                                        FROM information_schema.columns
                                        WHERE table_schema = 'public'; ",
                        //WHERE table_schema NOT IN ('information_schema', 'pg_catalog'); ",
                    };
                    using (var rdr = psgCmd.ExecuteReader())
                    {
                        while (rdr.Read())
                        {
                            string column = ((string)rdr[strColumnName]).ToLower();
                            string table = ((string)rdr[strTableName]).ToLower();

                            sqliteCmd.CommandText = @"SELECT translation FROM translation WHERE column_name = @cn AND table_name = @tn;";
                            sqliteCmd.Parameters.AddWithValue("cn", column);
                            sqliteCmd.Parameters.AddWithValue("tn", table);
                            var temp = sqliteCmd.ExecuteScalar();
                            string transl = temp == null ? null : temp.ToString();
                            if (transl == null)
                            {
                                transl = table + ": " + column;
                                sqliteCmd.Parameters.AddWithValue("tr", transl);
                                sqliteCmd.CommandText = @"INSERT INTO translation (column_name, table_name, translation) VALUES (@cn, @tn, @tr);";
                                sqliteCmd.ExecuteNonQuery();
                            }

                            _fields.Add(new MyField() { Name = transl, TableName = table, ColumnName = column, FieldType = GetFieldType(table, column) });
                        }
                    }
                }
            }
        }

        //internal void SetNewName(MyField newField)
        //{
        //    var oldField = _fields.FirstOrDefault(x => x.ColumnName == newField.ColumnName && x.TableName == newField.TableName);
        //    if (oldField != null)
        //    {
        //        oldField.Name = newField.Name;
        //    }
        //}
    }
}
