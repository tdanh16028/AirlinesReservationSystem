using System.Windows.Forms;

namespace ARSWinForm
{
    public partial class FormTicketList : Form
    {
        public FormTicketList()
        {
            InitializeComponent();
        }

        private void btnSubmit_Click(object sender, System.EventArgs e)
        {
            FormTicketCE f = new FormTicketCE();
            f.Show();
        }

        private void btnEdit_Click(object sender, System.EventArgs e)
        {
            FormTicketCE f = new FormTicketCE();
            f.Show();
        }

        private void btnDelete_Click(object sender, System.EventArgs e)
        {

        }

        private void button1_Click(object sender, System.EventArgs e)
        {

        }
    }
}
