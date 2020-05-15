﻿using Npgsql;
using System;
using System.Collections.Generic;
using System.ComponentModel;
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
        private static readonly string strTranslation = "translation";

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

        private BindingList<MyField> _fields;

        public BindingList<MyField> Fields { get => _fields; }

        public MyFieldController()
        {
            _fields = new BindingList<MyField>();
            Initialize();
        }

        public void Initialize()
        {
            _fields.Clear();
            using (var liteConn = new SQLiteConnection(sLiteConn))
            {
                liteConn.Open();

                var cmd = new SQLiteCommand() { Connection = liteConn };

                cmd.CommandText = @"SELECT translation FROM translation WHERE column_name = @cn AND table_name = @tn;";

                using (var postConn = new NpgsqlConnection(sPostgresConn))
                {
                    postConn.Open();

                    var pCom = new NpgsqlCommand()
                    {
                        Connection = postConn,
                        CommandText = @"SELECT column_name, table_name
                                    FROM information_schema.columns
                                    WHERE table_schema = 'public'
                                      AND NOT exists(SELECT 1
                                            FROM information_schema.table_constraints AS tc
                                                    JOIN information_schema.key_column_usage AS kcu
                                                        ON tc.constraint_name = kcu.constraint_name
                                                            AND tc.table_schema = kcu.table_schema
                                                    JOIN information_schema.constraint_column_usage AS ccu
                                                        ON ccu.constraint_name = tc.constraint_name
                                                            AND ccu.table_schema = tc.table_schema
                                            WHERE tc.constraint_type = 'FOREIGN KEY'
                                            AND ccu.column_name = columns.column_name AND columns.table_name <> ccu.table_name);",
                    };
                    using (var rdr = pCom.ExecuteReader())
                    {
                        while (rdr.Read())
                        {
                            string column = ((string)rdr[strColumnName]).ToLower();
                            string table = ((string)rdr[strTableName]).ToLower();

                            cmd.Parameters.AddWithValue("cn", column);
                            cmd.Parameters.AddWithValue("tn", table);
                            var temp = cmd.ExecuteScalar();
                            string transl = temp == null ? null : temp.ToString();
                            if (transl == null)
                                transl = column;

                            _fields.Add(new MyField() { Name = transl, TableName = table, ColumnName = column });
                        }
                    }
                }
            }
        }
    }
}