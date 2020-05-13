using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
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
        string sConn = new NpgsqlConnectionStringBuilder() {
            Database
        }.ConnectionString();

        public fNonStandartRequests()
        {
            InitializeComponent();
        }

        private void fNonStandartRequests_Load(object sender, EventArgs e)
        {
            using (var sConn)
        }
    }
}
