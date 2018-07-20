using ARSWinForm.HelperClass.ModelHelper;
using ARSWinForm.Model;
using System.Collections.Generic;
using System.Data;
using System.Windows.Forms;
using System.Linq;
using System;

namespace ARSWinForm
{
    public partial class FormTicketList : Form
    {
        public FormTicketList()
        {
            InitializeComponent();
        }

        private void btnCreate_Click(object sender, System.EventArgs e)
        {
            FormTicketCE f = new FormTicketCE();
            f.ShowDialog();
            LoadDataGridView();
        }

        private void btnEdit_Click(object sender, System.EventArgs e)
        {
            Ticket ticket = GetSelectedTicket();
            FormTicketCE f = new FormTicketCE(ticket, HelperClass.FormMode.EDIT);
            f.ShowDialog();
            LoadDataGridView();
        }

        private async void btnDelete_Click(object sender, System.EventArgs e)
        {
            Ticket ticket = GetSelectedTicket();

            // Neu hien tai khong co may bay nao duoc chon thi hien thong bao
            if (ticket == null)
            {
                MessageBox.Show("You must choose a ticket to delete!", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }

            // Neu co may bay dang duoc chon thi sua cot IsActive lai thanh False
            ticket.Status = "Cancelled";

            // Gui len server de cap nhat lai cot IsActive trong CSDL
            TicketWrapper ticketWrapper = new TicketWrapper();
            bool isSuccess = await ticketWrapper.Put(ticket.ID.ToString(), ticket);

            // Kiem tra ket qua tra ve
            if (isSuccess)
            {
                // Neu ket qua la thanh cong, hien thong bao thanh cong
                MessageBox.Show("Airplane status was set to inactive!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);

                // Load lai bang
                LoadDataGridView();

            }
            else
            {
                // Neu ket qua that bai, hien thong bao loi
                MessageBox.Show("An error has occurred!\n" + ticketWrapper.GetErrorMessage(), "Failed", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnReload_Click(object sender, System.EventArgs e)
        {
            LoadDataGridView();
        }

        public async void LoadDataGridView()
        {
            // Luu lai dong hien tai dang chon
            int currentRowIndex;

            // Neu hien tai khong co dong nao duoc chon thi mac dinh la dong so 0
            if (dgvTicket.SelectedRows.Count == 0)
            {
                currentRowIndex = 0;
            }
            else
            {
                currentRowIndex = dgvTicket.Rows.IndexOf(dgvTicket.SelectedRows[0]);
            }

            // Luu lai dong hien tai dang o dau` bang? trong dataGridView
            int firstRowIndex = dgvTicket.FirstDisplayedScrollingRowIndex;
            if (firstRowIndex == -1) firstRowIndex = 0;

            // Goi API lay du lieu ve
            ProfileWrapper profileWrapper = new ProfileWrapper();
            List<Profile> lstProfile = await profileWrapper.List();

            TicketWrapper ticketWrapper = new TicketWrapper();
            List<Ticket> lstTicket = await ticketWrapper.List();

            AirplaneClassWrapper airplaneClassWrapper = new AirplaneClassWrapper();
            List<AirplaneClass> lstAirplaneClass = await airplaneClassWrapper.List();

            FlightScheduleWrapper flightScheduleWrapper = new FlightScheduleWrapper();
            //List<FlightSchedule> lstFlightSchedule = await flightScheduleWrapper.List();

            RouteWrapper routeWrapper = new RouteWrapper();
            List<Route> lstRoute = await routeWrapper.List();

            CityWrapper cityWrapper = new CityWrapper();
            List<City> lstCity = await cityWrapper.List();


            // Tao bang de chua du lieu tra ve tu API
            DataTable table = new DataTable();
            table.Columns.Add("ID");
            table.Columns.Add("TicketCode");
            table.Columns.Add("ProfileID");
            table.Columns.Add("PassengerName");
            table.Columns.Add("From");
            table.Columns.Add("To");
            table.Columns.Add("Status");
            table.Columns.Add("ChildrenCount");
            table.Columns.Add("AdultCount");
            table.Columns.Add("SeniorCount");
            table.Columns.Add("AirplaneClassID");
            table.Columns.Add("AirplaneClassName");
            table.Columns.Add("OrderDate");
            table.Columns.Add("TotalCost");

            // Kiem tra xem ket qua goi API co thanh cong hay khong
            if (lstTicket != null)
            {
                // Lap qua tung "dong` du lieu"
                foreach (Ticket ticket in lstTicket)
                {
                    // Gan them du lieu len cho day du
                    ticket.AirplaneClass = lstAirplaneClass.Find(ac => ac.ID == ticket.AirplaneClassID);
                    ticket.FlightSchedules = await flightScheduleWrapper.List(ticket.ID);
                    ticket.Profile = lstProfile.Find(p => p.ID == ticket.ProfileID);

                    foreach (FlightSchedule fs in ticket.FlightSchedules)
                    {
                        fs.Route = lstRoute.Find(r => r.ID == fs.RouteID);
                        fs.Route.CityA = lstCity.Find(c => c.ID == fs.Route.CityAID);
                        fs.Route.CityB = lstCity.Find(c => c.ID == fs.Route.CityBID);
                    }

                    // Tao mot dong` trong bang winForm
                    DataRow row = table.NewRow();

                    // Gan du lieu len dong moi tao
                    row["ID"] = ticket.ID;
                    row["TicketCode"] = ticket.TicketCode;
                    row["ProfileID"] = ticket.ProfileID;
                    row["PassengerName"] = ticket.Profile.FirstName + ticket.Profile.LastName;
                    row["From"] = ticket.FlightSchedules.First().Route.CityA.Name;
                    row["To"] = ticket.FlightSchedules.Last().Route.CityB.Name;
                    row["Status"] = ticket.Status;
                    row["ChildrenCount"] = ticket.ChildrenCount;
                    row["AdultCount"] = ticket.AdultCount;
                    row["SeniorCount"] = ticket.SeniorCount;
                    row["AirplaneClassID"] = ticket.AirplaneClassID;
                    row["AirplaneClassName"] = ticket.AirplaneClass.Class;
                    row["OrderDate"] = ticket.OrderDate;
                    row["TotalCost"] = ticket.TotalCost;

                    // Gan dong moi tao vao bang
                    table.Rows.Add(row);
                }

                // Sau khi lap qua het cac dong du lieu
                // Ta co bang WinForm hoan chinh
                // Gan bang WinForm len DataGridView
                dgvTicket.DataSource = table;

                // An cac cot khong can thiet hien thi
                dgvTicket.Columns["ID"].Visible = false;
                dgvTicket.Columns["ProfileID"].Visible = false;
                dgvTicket.Columns["ChildrenCount"].Visible = false;
                dgvTicket.Columns["AdultCount"].Visible = false;
                dgvTicket.Columns["SeniorCount"].Visible = false;
                dgvTicket.Columns["AirplaneClassID"].Visible = false;

                // Chon lai dong ban dau duoc chon truoc khi reload
                dgvTicket.Rows[currentRowIndex].Selected = true;

                // Cuon. toi' dong` duoc. chon.
                dgvTicket.FirstDisplayedScrollingRowIndex = firstRowIndex;
            }
        }

        private Ticket GetSelectedTicket()
        {
            // Neu khong co dong nao dang duoc chon thi tra ve null
            if (dgvTicket.SelectedRows.Count != 1) return null;

            // Neu co 1 dong dang duoc chon thi lay dong do ra
            DataGridViewRow row = dgvTicket.SelectedRows[0];

            // Lay du lieu trong dong do va tao ra mot Airplane moi
            Ticket ticket = new Ticket()
            {
                ID = Convert.ToInt32(row.Cells["ID"].Value),
                ProfileID = Convert.ToInt32(row.Cells["ProfileID"].Value),
                TicketCode = row.Cells["TicketCode"].Value.ToString(),
                ChildrenCount = Convert.ToInt32(row.Cells["ChildrenCount"].Value),
                AdultCount = Convert.ToInt32(row.Cells["AdultCount"].Value),
                SeniorCount = Convert.ToInt32(row.Cells["SeniorCount"].Value),
                AirplaneClassID = Convert.ToInt32(row.Cells["AirplaneClassID"].Value),
                OrderDate = Convert.ToDateTime(row.Cells["OrderDate"].Value),
                Status = row.Cells["Status"].Value.ToString(),
                TotalCost = Convert.ToDouble(row.Cells["TotalCost"].Value)
            };

            // Tra Airplane vua tao ve
            return ticket;
        }

        private void FormTicketList_Load(object sender, System.EventArgs e)
        {
            LoadDataGridView();
        }
    }
}
