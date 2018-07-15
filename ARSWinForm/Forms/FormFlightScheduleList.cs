using System;
using System.Windows.Forms;

namespace ARSWinForm
{
    public partial class FormFlightScheduleList : Form
    {
        public FormFlightScheduleList()
        {
            InitializeComponent();
        }

        private void FormFlightSchedule_Load(object sender, EventArgs e)
        {

        }

        private void btnCreate_Click(object sender, EventArgs e)
        {
            FormFlightScheduleCE f = new FormFlightScheduleCE();
            f.Show();
        }

        private void Edit_Click(object sender, EventArgs e)
        {
            FormFlightScheduleCE f = new FormFlightScheduleCE();
            f.Show();
        }
    }
}
