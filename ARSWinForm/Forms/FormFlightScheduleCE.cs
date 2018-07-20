using ARSWinForm.HelperClass;
using ARSWinForm.HelperClass.ModelHelper;
using ARSWinForm.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;

namespace ARSWinForm
{
    public partial class FormFlightScheduleCE : Form
    {
        FlightSchedule flightSchedule;
        FormMode mode;

        public FormFlightScheduleCE(FlightSchedule flightSchedule = null, FormMode mode = FormMode.CREATE)
        {
            InitializeComponent();
            // Luu flightSchedule account ben FormList truyen sang
            this.flightSchedule = flightSchedule;

            // Luu che do (tao moi hay chinh sua)
            this.mode = mode;
        }

        private async void FormFlightScheduleCE_Load(object sender, System.EventArgs e)
        {
            // Lay danh sach cac may bay ve
            AirplaneWrapper airplaneWrapper = new AirplaneWrapper();
            List<Airplane> lstAirplane = await airplaneWrapper.List();

            // Goi API lay danh sach cac Loai may bay ve
            AirplaneTypeWrapper airplaneTypeWrapper = new AirplaneTypeWrapper();
            List<AirplaneType> lstAirplaneType = await airplaneTypeWrapper.List();

            // Goi API lay danh sach cac Lich bay ve
            FlightScheduleWrapper flightScheduleWrapper = new FlightScheduleWrapper();
            List<FlightSchedule> lstFlightSchedule = await flightScheduleWrapper.List();

            // Goi API lay danh sach Route ve
            RouteWrapper routeWrapper = new RouteWrapper();
            List<Route> lstRoute = await routeWrapper.List();

            // Goi API lay danh sach City ve
            CityWrapper cityWrapper = new CityWrapper();
            List<City> lstCity = await cityWrapper.List();

            // Gan loai may bay vao danh sach may bay
            foreach (Airplane airplane in lstAirplane)
            {
                airplane.AirplaneType = lstAirplaneType.Where(at => at.ID == airplane.TypeID).Single();
            }

            // Gan city vao Route
            foreach (Route route in lstRoute)
            {
                route.CityA = lstCity.Where(c => c.ID == route.CityAID).Single();
                route.CityB = lstCity.Where(c => c.ID == route.CityBID).Single();
            }

            // Dua danh sach loai may bay len Combobox
            cboAirplane.DataSource = lstAirplane;
            cboAirplane.DisplayMember = "AirplaneCode";

            // Dua danh sach Route len Combobox
            cboRoute.DataSource = lstRoute;
            cboRoute.DisplayMember = "CityAID";

            // Neu la che do chinh sua (Edit) thi hien thi thong tin cua may bay len form
            if (mode == FormMode.EDIT)
            {
                // Dua airplane code len
                cboAirplane.SelectedItem = lstAirplane.Where(a => a.AirplaneCode == flightSchedule.AirplaneCode).Single();

                // Chon loai may bay (AirplaneType) tuong ung voi may bay nay
                cboRoute.SelectedItem = lstRoute.Where(r => r.ID == flightSchedule.RouteID).Single();

                // Chon ngay khoi hanh
                dateTimePicker1.Value = flightSchedule.DepartureDate;

                if (flightSchedule.IsActive)
                {
                    // Neu may bay nay dang active thi check vao radio button Active
                    rbtnActive.Checked = true;
                }
                else
                {
                    rbtnInActive.Checked = true;
                }
            }
            else
            {
                // Neu dang o che do them moi
                // Tao moi mot may bay
                flightSchedule = new FlightSchedule();

                // Set lich bay la ngay hien tai
                dateTimePicker1.Value = DateTime.Now;

                // Nhung gia tri khac se duoc gan vao may bay khi nguoi dung bam nut Submit
            }
        }

        private async void btnSubmit_Click(object sender, System.EventArgs e)
        {
            // Lay gia tri tren form gan vao 
            flightSchedule.AirplaneCode = ((Airplane)cboAirplane.SelectedItem).AirplaneCode;
            flightSchedule.RouteID = ((Route)cboRoute.SelectedItem).ID;
            flightSchedule.DepartureDate = dateTimePicker1.Value;
            flightSchedule.IsActive = rbtnActive.Checked;
            // Tao mot API
            FlightScheduleWrapper flightScheduleWrapper = new FlightScheduleWrapper();
            // Tao bien luu ket qua tra ve
            bool isSuccess;

            // Kiem tra xem dang o che do nao
            if (mode == FormMode.CREATE)
            {
                // Neu dang o che do them moi (CREATE)
                // POST account len server
                isSuccess = await flightScheduleWrapper.Post(flightSchedule);
            }
            else
            {
                // Neu dang o che do chinh sua (EDIT)
                // PUT account len server
                isSuccess = await flightScheduleWrapper.Put(flightSchedule.ID.ToString(), flightSchedule);
            }

            // Kiem tra ket qua tra ve
            if (isSuccess)
            {
                // Neu thanh cong
                MessageBox.Show("Operation completed successfully!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                // Tat form CE
                this.Close();
            }
            else
            {
                // Neu that bai, hien thong bao loi
                MessageBox.Show("An error has occurred:\n" + flightScheduleWrapper.GetErrorMessage(), "Failed", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnCancel_Click(object sender, System.EventArgs e)
        {
            Close();
        }

        private void cboAirplane_Format(object sender, ListControlConvertEventArgs e)
        {
            string airplaneCode = ((Airplane)e.ListItem).AirplaneCode;
            string airplaneTypeName = ((Airplane)e.ListItem).AirplaneType.Name;
            e.Value = String.Format("{0} ({1})", airplaneCode, airplaneTypeName);
        }

        private void cboRoute_Format(object sender, ListControlConvertEventArgs e)
        {
            string cityAName = ((Route)e.ListItem).CityA.Name;
            string cityBName = ((Route)e.ListItem).CityB.Name;
            e.Value = String.Format("From {0} to {1}", cityAName, cityBName);
        }
    }
}
