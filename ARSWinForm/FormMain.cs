using ARSWinForm.Forms;
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
        public bool isLoggedIn = false;

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

        private void airplaneToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            OpenChildForm(new FormAirplaneList());
        }

        private void classOfSeatToolStripMenuItem_Click(object sender, EventArgs e)
        {
            OpenChildForm(new FormAirplaneClassList());
        }

        private void routeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            OpenChildForm(new FormRouteList());
        }

        private void flightScheduleToolStripMenuItem_Click(object sender, EventArgs e)
        {
            OpenChildForm(new FormFlightScheduleList());
        }

        private void FormMain_Load(object sender, EventArgs e)
        {
            
        }

        private void logoutToolStripMenuItem_Click(object sender, EventArgs e)
        {
            foreach (Form f in MdiChildren)
            {
                f.Close();
            }

            managementToolStripMenuItem.Enabled = false;
            loginToolStripMenuItem.Enabled = true;
            logoutToolStripMenuItem.Enabled = false;

            isLoggedIn = false;
            loginToolStripMenuItem.PerformClick();
        }

        private void loginToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FormLogin f = new FormLogin(this);
            f.ShowDialog();
            if (!isLoggedIn) return;

            managementToolStripMenuItem.Enabled = true;
            loginToolStripMenuItem.Enabled = false;
            logoutToolStripMenuItem.Enabled = true;
        }

        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void FormMain_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (MessageBox.Show("Are you sure to exit?", "Confirm", MessageBoxButtons.YesNo, MessageBoxIcon.Exclamation) == DialogResult.No)
            {
                e.Cancel = true;
            }
        }

        private void ticketToolStripMenuItem_Click(object sender, EventArgs e)
        {
            OpenChildForm(new FormTicketList());
        }

        private void airplaneTypeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            OpenChildForm(new FormAirplaneTypeList());
        }
    }
}
