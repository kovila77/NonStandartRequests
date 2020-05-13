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
            DataSource = "transcription.sqlite",
        }.ConnectionString;

        private readonly string strColumnName = "column_name";
        private readonly string strTableName = "table_name";
        private readonly string strTranslation = "translation";

        public fNonStandartRequests()
        {
            InitializeComponent();
        }

        private void fNonStandartRequests_Load(object sender, EventArgs e)
        {
            using (var conn = new NpgsqlConnection(sPostgresConn))
            {
                conn.Open();

                var command = new NpgsqlCommand()
                {
                    Connection = conn,
                    CommandText = "select outpost_name from outposts",
                };
                var reader = command.ExecuteReader();
                while (reader.Read())
                {
                    //lvAllFields.Items.Add(new ListViewItem((string)reader["outpost_name"]));
                    listBox1.Items.Add((string)reader["outpost_name"]);
                }
            }
        }

        private void btRightFieldFields_Click(object sender, EventArgs e)
        {
            if (listBox1.SelectedItem == null) return;
            var tmp = listBox1.SelectedItem;
            listBox1.Items.Remove(tmp);
            listBox2.Items.Add(tmp);
        }

        private void btLeftFieldFields_Click(object sender, EventArgs e)
        {
            if (listBox2.SelectedItem == null) return;
            var tmp = listBox2.SelectedItem;
            listBox2.Items.Remove(tmp);
            listBox1.Items.Add(tmp);
        }

        private void btAllRightFieldFields_Click(object sender, EventArgs e)
        {
            foreach (var itm in listBox1.Items)
                listBox2.Items.Add(itm);
            listBox1.Items.Clear();
        }

        private void btAllLeftFieldFields_Click(object sender, EventArgs e)
        {
            foreach (var itm in listBox2.Items)
                listBox1.Items.Add(itm);
            listBox2.Items.Clear();
        }
    }
}
