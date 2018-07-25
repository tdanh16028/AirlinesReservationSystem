using ARSWinForm.Forms;
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
    public partial class FormMain : Form
    {
        private Dictionary<string, Form> listChildForm = new Dictionary<string, Form>();
        public bool isLoggedIn = false;

        public FormMain()
        {
            InitializeComponent();
        }

        private void FormMain_Load(object sender, EventArgs e)
        {
            // AutoGenerateFlightSchedule();
            
        }

        /// <summary>
        /// Only use for generate sample data of table FlightSchedule
        /// This function will generate flight schedule for all route in database, 
        /// each route will have <code>maxFlightSchedulePerRoute</code> flight schedules,
        /// each flight schedule of route will apart one day, starting from today.
        /// </summary>
        private async void AutoGenerateFlightSchedule()
        {
            DateTime startTime = DateTime.Now;
            Console.WriteLine("Start at {0}", startTime);

            FlightScheduleWrapper flightScheduleWrapper = new FlightScheduleWrapper();
            AirplaneWrapper airplaneWrapper = new AirplaneWrapper();
            AirplaneTypeWrapper airplaneTypeWrapper = new AirplaneTypeWrapper();
            AirplaneInfoWrapper airplaneInfoWrapper = new AirplaneInfoWrapper();
            RouteWrapper routeWrapper = new RouteWrapper();

            List<Airplane> lstAirplane = await airplaneWrapper.List();
            List<AirplaneType> lstAirplaneType = await airplaneTypeWrapper.List();
            List<AirplaneInfo> lstAirplaneInfo = await airplaneInfoWrapper.List();
            List<Route> lstRoute = await routeWrapper.List();

            int flightScheduleOfCurrentRoute = 0;
            int maxFlightSchedulePerRoute = 10;
            int currentAirplaneIndex = 0;
            int count = 0;

            for (int routeIndex = 0, maxRouteIndex = lstRoute.Count - 1; routeIndex <= maxRouteIndex; routeIndex++)
            {
                Route currentRoute = lstRoute[routeIndex];

                do
                {
                    Airplane currentAirplane = lstAirplane[currentAirplaneIndex++];
                    AirplaneType currentAirplaneType = lstAirplaneType.Find(at => at.ID == currentAirplane.TypeID);
                    List<AirplaneInfo> currentAirplaneInfo = lstAirplaneInfo.Where(ai => ai.AirplaneTypeID == currentAirplaneType.ID).ToList();
                    DateTime departureDate = DateTime.Now.AddDays(flightScheduleOfCurrentRoute);

                    FlightSchedule flightSchedule = new FlightSchedule()
                    {
                        AirplaneCode = currentAirplane.AirplaneCode,
                        RouteID = currentRoute.ID,
                        DepartureDate = departureDate,
                        FirstSeatAvail = currentAirplaneInfo.Find(ai => ai.ClassID == 1).SeatCount,
                        BusinessSeatAvail = currentAirplaneInfo.Find(ai => ai.ClassID == 2).SeatCount,
                        ClubSeatAvail = currentAirplaneInfo.Find(ai => ai.ClassID == 3).SeatCount,
                        IsActive = true
                    };

                    if (await flightScheduleWrapper.Post(flightSchedule))
                    {
                        Console.WriteLine("Add flight schedule #{0} success!", ++count);
                    }
                    else
                    {
                        Console.WriteLine("Add flight schedule #{0} failed!", ++count);
                    }

                    if (currentAirplaneIndex >= lstAirplane.Count) currentAirplaneIndex = 0;
                } while (++flightScheduleOfCurrentRoute < maxFlightSchedulePerRoute);

                flightScheduleOfCurrentRoute = 0;
            }

            DateTime endTime = DateTime.Now;
            Console.WriteLine("End at {0}", startTime);
            Console.WriteLine("Total time: {0}", (endTime - startTime).TotalSeconds);
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
