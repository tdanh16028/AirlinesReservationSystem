using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ARSWinForm
{
    public partial class FormTest : Form
    {
        public FormTest()
        {
            InitializeComponent();
        }

        private void btnReload_Click(object sender, EventArgs e)
        {

        }

        private void LoadDataGridView()
        {
            DataTable table = new DataTable();
            table.Columns.Add("gv_ma");
            table.Columns.Add("gv_ten");
            table.Columns.Add("gv_email");
            table.Columns.Add("gv_sdt");
            table.Columns.Add("gv_bangcap");


        }
    }
}
