using System;
using System.Windows.Forms;

namespace ARSWinForm
{
    public partial class FormRouteList : Form
    {
        public FormRouteList()
        {
            InitializeComponent();
        }

        private void FormRoute_Load(object sender, EventArgs e)
        {

        }

        private void btnCreate_Click(object sender, EventArgs e)
        {
            FormRouteCE f = new FormRouteCE();
            f.Show();
        }

        private void Edit_Click(object sender, EventArgs e)
        {
            FormRouteCE f = new FormRouteCE();
            f.Show();

        }
        
    }
}
