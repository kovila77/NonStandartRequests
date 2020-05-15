﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SQLite;
using Npgsql;
using TranslationColumns.Properties;
using System.Text.RegularExpressions;
using System.Runtime.InteropServices.WindowsRuntime;
using System.Xml;

namespace TranslationColumns
{
    public partial class fTranslationColumns : Form
    {
        string sPostgresConn;

        string sLiteConn;

        private readonly string strColumnName = "column_name";
        private readonly string strTableName = "table_name";
        private readonly string strTranslation = "translation";

        public enum FormType
        {
            NeedExit,
            NeedChanges
        }
        FormType formType;

        public fTranslationColumns(FormType ft)
        {
            formType = ft;
            InitializeComponent();

            XmlDocument doc = new XmlDocument();
            //doc.Load(@"NonStandartRequests.exe.config"); 
            //doc.Load(@"C:\Users\35498\source\repos\NonStandartRequests\NonStandartRequests\bin\Debug\NonStandartRequests.exe.config");
            doc.Load(conficN.Default.nonstandartrequestConfigPath);
            var settings = doc.ChildNodes.Cast<XmlNode>()
              .FirstOrDefault(x => x.Name == "configuration").ChildNodes.Cast<XmlNode>()
              .FirstOrDefault(x => x.Name == "userSettings").Cast<XmlNode>()
              .FirstOrDefault(x => x.Name == "NonStandartRequests.Settings").ChildNodes.Cast<XmlNode>()
              .Select(x => new
              {
                  Name = x.Attributes.Cast<XmlAttribute>().FirstOrDefault(y => y.Name.ToLower() == "name").FirstChild.Value,
                  Value = x.FirstChild.FirstChild.Value,
              });

            sPostgresConn = new NpgsqlConnectionStringBuilder()
            {
                Database = settings.FirstOrDefault(x => x.Name == "DatabaseName").Value,
                Host = settings.FirstOrDefault(x => x.Name == "Host").Value,
                Port = Convert.ToInt32(settings.FirstOrDefault(x => x.Name == "Port").Value),
                Username = settings.FirstOrDefault(x => x.Name == "User").Value,
                Password = settings.FirstOrDefault(x => x.Name == "Password").Value,
            }.ConnectionString;

            sLiteConn = new SQLiteConnectionStringBuilder()
            {
                DataSource = settings.FirstOrDefault(x => x.Name == "TranslationPath").Value,
            }.ConnectionString;

            dataGridView1.Columns[dataGridView1.Columns.Add(strColumnName, "Название поля")].ReadOnly = true;
            dataGridView1.Columns[dataGridView1.Columns.Add(strTableName, "Название таблицы")].ReadOnly = true;
            dataGridView1.Columns[dataGridView1.Columns.Add(strTranslation, "Переведённое название")].ValueType = typeof(string);
            dataGridView1.AllowUserToDeleteRows = false;
            dataGridView1.AllowUserToAddRows = false;
            ComplementTable();
        }

        public void ComplementTable()
        {
            dataGridView1.EndEdit();
            dataGridView1.Rows.Clear();
            using (var liteConn = new SQLiteConnection(sLiteConn))
            {
                liteConn.Open();

                var cmd = new SQLiteCommand() { Connection = liteConn, CommandText = @"SELECT column_name, table_name, translation FROM translation;" };
                using (var rd = cmd.ExecuteReader())
                {
                    while (rd.Read())
                        dataGridView1.Rows.Add(rd[strColumnName], rd[strTableName], rd[strTranslation]);
                }

                cmd.CommandText = @"BEGIN TRANSACTION;";
                cmd.ExecuteNonQuery();
                cmd.CommandText = @"INSERT INTO translation (column_name, table_name, translation) VALUES (@cn, @tn, @tr);";

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
                            int index = -1;
                            if (dataGridView1.Rows.Count > 0)
                            {
                                if (dataGridView1.Rows.Cast<DataGridViewRow>().FirstOrDefault(x => x.Cells[strTableName].FormattedValue.ToString().ToLower() == table && x.Cells[strColumnName].FormattedValue.ToString().ToLower() == column) == null)
                                {
                                    foreach (DataGridViewRow row1 in dataGridView1.Rows)
                                    {
                                        if (row1.Cells[strTranslation].FormattedValue.ToString() == column)
                                        {
                                            MessageBox.Show("Значение перевода уже существует! Измените его и повторно запустите процесс!");
                                            this.Visible = true;
                                            formType = FormType.NeedChanges;
                                            dataGridView1.ClearSelection();
                                            dataGridView1[dataGridView1.Columns[strTranslation].Index, row1.Index].Selected = true;
                                            dataGridView1[dataGridView1.Columns[strTranslation].Index, row1.Index].Style.BackColor = Color.Red;
                                            cmd.CommandText = @"COMMIT;";
                                            cmd.ExecuteNonQuery();
                                            return;
                                        }
                                    }
                                    index = dataGridView1.Rows.Add(column, table, column);
                                }
                                else continue;
                            }
                            else
                            {
                                index = dataGridView1.Rows.Add(column, table, column);
                            }
                            if (index == -1) throw new Exception("Такого не должно было случиться!");
                            var row = dataGridView1.Rows[index];
                            cmd.Parameters.AddWithValue("cn", row.Cells[strColumnName].FormattedValue.ToString());
                            cmd.Parameters.AddWithValue("tn", row.Cells[strTableName].FormattedValue.ToString());
                            cmd.Parameters.AddWithValue("tr", row.Cells[strTranslation].FormattedValue.ToString());


                            cmd.ExecuteNonQuery();
                        }
                    }
                }

                cmd.CommandText = @"COMMIT;";
                cmd.ExecuteNonQuery();
            }
            if (formType == FormType.NeedExit)
            {
                this.Close();
            }
        }

        private void dataGridView1_CellValidating(object sender, DataGridViewCellValidatingEventArgs e)
        {
            if (dataGridView1.Columns[e.ColumnIndex].Name != strTranslation) return;
            var cell = dataGridView1[e.ColumnIndex, e.RowIndex];
            if (string.IsNullOrEmpty(RmvExtrSpaces(e.FormattedValue.ToString())))
            {
                MessageBox.Show("Значение не может быть пустым!");
                dataGridView1.CancelEdit();
                return;
            }
            foreach (DataGridViewRow row in dataGridView1.Rows)
            {
                var c = row.Cells[strTranslation];
                if (cell != c && e.FormattedValue == c.FormattedValue)
                {
                    MessageBox.Show("Значение не может совпадать с другим!");
                    dataGridView1.CancelEdit();
                    return;
                }
            }
            if (!dataGridView1.IsCurrentCellDirty) return;
            using (var liteConn = new SQLiteConnection(sLiteConn))
            {
                liteConn.Open();
                var row = dataGridView1.Rows[e.RowIndex];
                var cmd = new SQLiteCommand() { Connection = liteConn };
                cmd.CommandText = @"UPDATE translation SET translation = @tr WHERE column_name = @cn AND table_name = @tn;";
                cmd.Parameters.AddWithValue("cn", row.Cells[strColumnName].Value);
                cmd.Parameters.AddWithValue("tn", row.Cells[strTableName].Value);
                cmd.Parameters.AddWithValue("tr", RmvExtrSpaces(e.FormattedValue.ToString()));
                cmd.ExecuteNonQuery().ToString();
            }
            if (cell.Style.BackColor == Color.Red) cell.Style.BackColor = dataGridView1.DefaultCellStyle.BackColor;
        }

        public string RmvExtrSpaces(string str)
        {
            if (str == null) return str;
            str = str.Trim();
            str = Regex.Replace(str, @"\s+", " ");
            return str;
        }


        private void dataGridView1_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {
            var cell = dataGridView1[e.ColumnIndex, e.RowIndex];
            var cellFormatedValue = RmvExtrSpaces(cell.FormattedValue.ToString());

            if (cell.ValueType == typeof(String))
            {
                cell.Value = cellFormatedValue;
            }
        }

        private void загрузитьToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ComplementTable();
        }
    }
}