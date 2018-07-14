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
    public partial class FormMain : Form
    {
        private Dictionary<string, Form> listChildForm = new Dictionary<string, Form>();

        public FormMain()
        {
            InitializeComponent();
        }

        private void OpenChildForm<T>(T form) where T : Form
        {
            foreach (Form child in this.MdiChildren)
            {
                if (child is T) {
                    child.Activate();
                    child.BringToFront();
                    return;
                }
            }

            form.MdiParent = this;
            form.Show();
        }

        private void adminToolStripMenuItem_Click(object sender, EventArgs e)
        {
            OpenChildForm(new FormAdminAccountList());
        }

        private void customerProfileToolStripMenuItem_Click(object sender, EventArgs e)
        {
            OpenChildForm(new FormProfileList());
        }

        private void cityToolStripMenuItem_Click(object sender, EventArgs e)
        {
            OpenChildForm(new FormCityList());
        }
    }
}
