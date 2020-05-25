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
                cbFieldName.Items.Add(item);
            }
            lbAllFields.Sorted = true;
            //cbLigament.Items.Add("И");
            //cbLigament.Items.Add("");
            //cbLigament.SelectedIndex = 0;
            //cbLigament.Items.Add("ИЛИ");

            cbFieldName.Sorted = true;

            lvConditions.Columns.Add("Имя поля");
            lvConditions.Columns.Add("Критерий");
            lvConditions.Columns.Add("Значение");
            lvConditions.Columns.Add("Связка");
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

        private void btShowSQL_Click(object sender, EventArgs e) => CreateQuery(false);

        private void btExecute_Click(object sender, EventArgs e) => CreateQuery(true);

        ////public static string GetFormattedValue(object val)
        ////{
        ////    //val == null || val == DBNull.Value ? "" : val.ToString();
        ////    if (val == null || val == DBNull.Value) return "";
        ////    if (val.GetType() == typeof(byte[])) return Convert.ToBase64String((byte[])val);

        ////    return val.ToString();
        ////}


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