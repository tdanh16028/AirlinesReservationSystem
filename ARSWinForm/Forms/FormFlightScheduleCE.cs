using ARSWinForm.HelperClass;
using ARSWinForm.HelperClass.ModelHelper;
using ARSWinForm.Model;
using System.Collections.Generic;
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

            // Goi API lay danh sach cac Loai may bay ve
            FlightScheduleWrapper flightScheduleWrapper = new FlightScheduleWrapper();
            List<FlightSchedule> lstAirplaneType = await flightScheduleWrapper.List();

            // Dua danh sach loai may bay len Combobox
            cboAirplaneCode.DataSource = lstAirplaneType;
            cboAirplaneCode.DisplayMember = "AirplaneCode";

            // Neu la che do chinh sua (Edit) thi hien thi thong tin cua may bay len form
            if (mode == FormMode.EDIT)
            {
                // Dua airplane code len
                cboAirplaneCode.SelectedItem = flightSchedule.AirplaneCode;

                // Chon loai may bay (AirplaneType) tuong ung voi may bay nay
                cboRoute.SelectedItem = lstAirplaneType.Where(at => at.ID == airplane.TypeID).Single();

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

                // Nhung gia tri khac se duoc gan vao may bay khi nguoi dung bam nut Submit
            }
        }

        private async void btnSubmit_Click(object sender, System.EventArgs e)
        {
            // Lay gia tri tren form gan vao account
            flightSchedule.AirplaneCode =((Airplane)cboAirplaneCode.SelectedItem).ID.ToString();
            flightSchedule.RouteID = ((Route)cboRoute.SelectedItem).ID;
            flightSchedule.DepartureDate = DateTimePicker.
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
                isSuccess = await flightScheduleWrapper.Put(flightSchedule.AirplaneCode, flightSchedule);
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
    }
}
