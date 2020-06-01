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

        private string sqlQuery;
        ListViewItem lvConditionSelectedItem = null;

        NpgsqlCommandBuilder npgsqlCommandBuilder = new NpgsqlCommandBuilder();
        private ColumnHeader sortingColumn = null;

        delegate void myFieldDelegate(MyField deletedItem);
        event myFieldDelegate SelectedItemAdded;
        event myFieldDelegate SelectedItemRemoved;

        MyFieldController myFieldController;

        public fNonStandartRequests()
        {
            InitializeComponent();
        }

        private void fNonStandartRequests_Load(object sender, EventArgs e)
        {
            myFieldController = new MyFieldController();
            foreach (var item in myFieldController.Fields)
            {
                lbAllFields.Items.Add(item);
                cbFieldName.Items.Add(item);
            }
            lbAllFields.Sorted = true;
            SelectedItemAdded += FieldAddTo_LBSelectedFieldsOrder;
            SelectedItemRemoved += FieldRemoveFrom_LBSelectedFieldsOrder;
            SelectedItemRemoved += FieldRemoveFrom_LBOrder;

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

            SelectedItemAdded?.Invoke((MyField)tmp);
        }

        private void btLeftFieldFields_Click(object sender, EventArgs e)
        {
            if (lbSelectedFieldsFields.SelectedItem == null) return;
            var tmp = lbSelectedFieldsFields.SelectedItem;
            lbSelectedFieldsFields.Items.Remove(tmp);
            lbAllFields.Items.Add(tmp);

            SelectedItemRemoved?.Invoke((MyField)tmp);
        }

        private void btAllRightFieldFields_Click(object sender, EventArgs e)
        {
            foreach (var itm in lbAllFields.Items)
            {
                lbSelectedFieldsFields.Items.Add(itm);
                SelectedItemAdded?.Invoke((MyField)itm);
            }
            lbAllFields.Items.Clear();
        }

        private void btAllLeftFieldFields_Click(object sender, EventArgs e)
        {
            foreach (var itm in lbSelectedFieldsFields.Items)
            {
                lbAllFields.Items.Add(itm);
                SelectedItemRemoved?.Invoke((MyField)itm);
            }
            lbSelectedFieldsFields.Items.Clear();
        }

        private void btShowSQL_Click(object sender, EventArgs e) => CreateQuery(false);

        private void btExecute_Click(object sender, EventArgs e) => CreateQuery(true);

        private void btCancel_Click(object sender, EventArgs e)
        {
            lvResult.Clear();
            lvConditions.Items.Clear();
            btAllLeftFieldFields_Click(null, null);
        }
    }
}