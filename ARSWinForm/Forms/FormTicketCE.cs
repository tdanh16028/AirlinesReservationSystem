using ARSWinForm.HelperClass;
using ARSWinForm.HelperClass.ModelHelper;
using ARSWinForm.Model;
using System;
using System.Collections.Generic;
using System.Windows.Forms;
using System.Linq;
using System.Data;

namespace ARSWinForm
{
    public partial class FormTicketCE : Form
    {
        Ticket ticket;
        FormMode formMode;

        public FormTicketCE(Ticket ticket = null, FormMode formMode = FormMode.CREATE)
        {
            InitializeComponent();

            this.ticket = ticket;
            this.formMode = formMode;
        }

        private async void FormTicketCE_Load(object sender, System.EventArgs e)
        {
            ProfileWrapper profileWrapper = new ProfileWrapper();
            List<Profile> lstProfile = await profileWrapper.List();

            AirplaneClassWrapper airplaneClassWrapper = new AirplaneClassWrapper();
            List<AirplaneClass> lstAirplaneClass = await airplaneClassWrapper.List();

            FlightScheduleWrapper flightScheduleWrapper = new FlightScheduleWrapper();
            //List<FlightSchedule> lstFlightSchedule = await flightScheduleWrapper.List();

            cboSeatClass.DataSource = lstAirplaneClass;
            cboSeatClass.DisplayMember = "Class";

            if (formMode == FormMode.EDIT)
            {
                ticket.AirplaneClass = lstAirplaneClass.Find(ac => ac.ID == ticket.AirplaneClassID);
                ticket.FlightSchedules = await flightScheduleWrapper.List(ticket.ID);
                ticket.Profile = lstProfile.Find(p => p.ID == ticket.ProfileID);

                lbTicketCode.Text = "Ticket Code: " + ticket.TicketCode;
                txtPassengerName.Text = ticket.Profile.FirstName + " " + ticket.Profile.LastName;
                numChildrenCount.Value = ticket.ChildrenCount;
                numAdultCount.Value = ticket.AdultCount;
                numSeniorCount.Value = ticket.SeniorCount;

                cboSeatClass.SelectedItem = ticket.AirplaneClass;
                dpOrderDate.Value = ticket.OrderDate;
                cboStatus.SelectedItem = ticket.Status;
                numTotalCost.Value = Convert.ToDecimal(ticket.TotalCost);

                LoadDataGridView(ticket.FlightSchedules.ToList());

                // If the ticket status is cancelled, not allow to edit
                if (ticket.Status == "Cancelled")
                {
                    DisableEditMode();
                }

            } else
            {
                ticket = new Ticket();
            }
        }

        private async void LoadDataGridView(List<FlightSchedule> lstFlightSchedule)
        {

            AirplaneWrapper airplaneWrapper = new AirplaneWrapper();
            AirplaneTypeWrapper airplaneTypeWrapper = new AirplaneTypeWrapper();
            RouteWrapper routeWrapper = new RouteWrapper();
            CityWrapper cityWrapper = new CityWrapper();

            // Goi API lay du lieu ve
            List<Airplane> lstAirplane = await airplaneWrapper.List();
            List<AirplaneType> lstAirplaneType = await airplaneTypeWrapper.List();
            List<Route> lstRoute = await routeWrapper.List();
            List<City> lstCity = await cityWrapper.List();

            // Hien thi len label FromTo
            lbFromTo.Text = String.Format("From {0} - to {1}",
                    lstCity.Find(c => c.ID == lstRoute.Find(r => r.ID == lstFlightSchedule.First().RouteID).CityAID).Name,
                    lstCity.Find(c => c.ID == lstRoute.Find(r => r.ID == lstFlightSchedule.Last().RouteID).CityBID).Name
                );

            // Tao bang de chua du lieu tra ve tu API
            DataTable table = new DataTable();
            table.Columns.Add("ID"); // Ma chuyen bay
            table.Columns.Add("AirplaneCode"); // ID cua  may bay
            table.Columns.Add("AirplaneTypeName"); // ID cua  may bay
            table.Columns.Add("RouteID"); // ID cua chuyen bay
            table.Columns.Add("CityAName"); // ID cua  may bay 
            table.Columns.Add("CityBName"); // ID cua  may bay
            table.Columns.Add("DepartureDate"); // Ngay cat canh
            table.Columns.Add("FirstSeatAvail"); // So luong ghe hang Nhat con 
            table.Columns.Add("BusinessSeatAvail"); // So luong ghe hang Thuong gia con
            table.Columns.Add("ClubSeatAvail"); // So luong ghe hang Pho Thong con
            table.Columns.Add("IsActive"); // Trang thai cua chuyen bay


            // Kiem tra xem ket qua goi API co thanh cong hay khong
            if (lstFlightSchedule != null)
            {
                // Lap qua tung "dong` du lieu"
                foreach (FlightSchedule flightSchedule in lstFlightSchedule)
                {
                    // Goi API de lay So luong cua moi Loai ghe tren may bay nay
                    Airplane airplane = lstAirplane.Find(a => a.AirplaneCode == flightSchedule.AirplaneCode);
                    AirplaneType airplaneType = lstAirplaneType.Find(at => at.ID == airplane.TypeID);

                    // Goi API de lay ID cua chuyen  bay (Route)
                    Route route = lstRoute.Find(r => r.ID == flightSchedule.RouteID);
                    City cityA = lstCity.Find(c => c.ID == route.CityAID);
                    City cityB = lstCity.Find(c => c.ID == route.CityBID);


                    // Tao mot dong` trong bang winForm
                    DataRow row = table.NewRow();

                    // Gan du lieu len dong moi tao
                    row["ID"] = flightSchedule.ID;
                    row["AirplaneCode"] = airplane.AirplaneCode;
                    row["AirplaneTypeName"] = airplaneType.Name;
                    row["RouteID"] = flightSchedule.RouteID;
                    row["CityAName"] = cityA.Name;
                    row["CityBName"] = cityB.Name;
                    row["DepartureDate"] = flightSchedule.DepartureDate;
                    row["FirstSeatAvail"] = flightSchedule.FirstSeatAvail;
                    row["BusinessSeatAvail"] = flightSchedule.BusinessSeatAvail;
                    row["ClubSeatAvail"] = flightSchedule.ClubSeatAvail;
                    row["IsActive"] = flightSchedule.IsActive;

                    // Gan dong moi tao vao bang
                    table.Rows.Add(row);
                }

                // Sau khi lap qua het cac dong du lieu
                // Ta co bang WinForm hoan chinh
                // Gan bang WinForm len DataGridView
                dgvFlightSchedule.DataSource = table;

                // An? cot AirplaneTypeID di, khong hien cot nay
                dgvFlightSchedule.Columns["RouteID"].Visible = false;
                dgvFlightSchedule.Columns["IsActive"].Visible = false;

            }
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            Close();
        }

        private async void btnSubmit_Click(object sender, EventArgs e)
        {
            ticket.ChildrenCount = Convert.ToInt32(numChildrenCount.Value);
            ticket.AdultCount = Convert.ToInt32(numAdultCount.Value);
            ticket.SeniorCount = Convert.ToInt32(numSeniorCount.Value);
            ticket.AirplaneClassID = ((AirplaneClass)cboSeatClass.SelectedItem).ID;
            ticket.OrderDate = dpOrderDate.Value;
            ticket.Status = cboStatus.SelectedItem.ToString();
            ticket.TotalCost = Convert.ToDouble(numTotalCost.Value);


            // Tao mot API
            TicketWrapper ticketWrapper = new TicketWrapper();

            // Tao bien luu ket qua tra ve
            bool isSuccess;

            // Kiem tra xem dang o che do nao
            if (formMode == FormMode.CREATE)
            {
                // Neu dang o che do them moi (CREATE)
                // POST account len server
                isSuccess = await ticketWrapper.Post(ticket);
            }
            else
            {
                // Neu dang o che do chinh sua (EDIT)
                // PUT account len server
                isSuccess = await ticketWrapper.Put(ticket.ID.ToString(), ticket);
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
                MessageBox.Show("An error has occurred:\n" + ticketWrapper.GetErrorMessage(), "Failed", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void DisableEditMode()
        {
            btnPassengerBrowse.Enabled = false;
            numChildrenCount.Enabled = false;
            numAdultCount.Enabled = false;
            numSeniorCount.Enabled = false;

            cboSeatClass.Enabled = false;
            dpOrderDate.Enabled = false;
            cboStatus.Enabled = false;

            btnEditFlightSchedule.Enabled = false;
            btnSubmit.Enabled = false;
        }
    }
}
