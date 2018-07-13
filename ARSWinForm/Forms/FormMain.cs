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
        public FormMain()
        {
            InitializeComponent();
        }

        private void btnAdmin_Click(object sender, EventArgs e)
        {
            FormAdminAccountList f = new FormAdminAccountList();
            f.Show();
        }

        private void btnAirplane_Click(object sender, EventArgs e)
        {
            FormAirplaneList f = new FormAirplaneList();
            f.Show();
        }

        private void btnAirplaneClass_Click(object sender, EventArgs e)
        {
            FormAirplaneClassList f = new FormAirplaneClassList();
            f.Show();
        }

        private void btnAirplaneInfo_Click(object sender, EventArgs e)
        {
            FormAirplaneInfoList f = new FormAirplaneInfoList();
            f.Show();
        }

        private void btnAirplaneType_Click(object sender, EventArgs e)
        {
            FormAirplaneTypeList f = new FormAirplaneTypeList();
            f.Show();
        }

        private void btnCity_Click(object sender, EventArgs e)
        {
            FormCityList f = new FormCityList();
            f.Show();
        }

        private void btnFlightSchedule_Click(object sender, EventArgs e)
        {
            FormFlightScheduleList f = new FormFlightScheduleList();
            f.Show();
        }

        private void btnRoute_Click(object sender, EventArgs e)
        {
            FormRouteList f = new FormRouteList();
            f.Show();
        }
    }
}
