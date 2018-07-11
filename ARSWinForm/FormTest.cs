using ARSWinForm.HelperClass.ModelHelper;
using ARSWinForm.Model;
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
            LoadDataGridView();
        }

        private async void LoadDataGridView()
        {
            DataTable table = new DataTable();
            table.Columns.Add("ID");
            table.Columns.Add("Class");

            List<AirplaneClass> airplaneClasses = await (new AirplaneClassWrapper()).List();

            foreach (AirplaneClass airplaneClass in airplaneClasses)
            {
                DataRow row = table.NewRow();
                row["ID"] = airplaneClass.ID.ToString();
                row["Class"] = airplaneClass.Class;
                table.Rows.Add(row);
            }

            dgvAirplaneClass.DataSource = table;
        }

        private void FormTest_Load(object sender, EventArgs e)
        {
            LoadDataGridView();
        }
    }
}
