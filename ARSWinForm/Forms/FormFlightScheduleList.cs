using ARSWinForm.HelperClass.ModelHelper;
using ARSWinForm.Model;
using System;
using System.Collections.Generic;
using System.Data;
using System.Windows.Forms;

namespace ARSWinForm
{
    public partial class FormFlightScheduleList : Form
    {
        public FormFlightScheduleList()
        {
            InitializeComponent();
        }

        private void FormFlightSchedule_Load(object sender, EventArgs e)
        {
            LoadDataGridView();
        }
        private void btnSubmit_Click(object sender, EventArgs e)
        {
            FormFlightScheduleCE f = new FormFlightScheduleCE();
            // f.MdiParent = this.MdiParent;

            // Hien form Create len va doi cho den khi form bi tat di
            f.ShowDialog();

            // Load lai bang sau khi form Create da tat
            LoadDataGridView();
        }

        private void btnEdit_Click(object sender, EventArgs e)
        {
            // Lay tai khoan admin dang duoc chon trong bang
            FlightSchedule flightSchedule = GetSelectedFlightSchedule();

            // Neu hien tai khong co tai khoan nao duoc chon thi hien thong bao
            if (flightSchedule == null)
            {
                MessageBox.Show("You must choose an aiplane to edit!", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }

            // Neu co tai khoan dang duoc chon thi hien form chinh sua thong tin len, truyen du lieu qua
            FormFlightScheduleCE f = new FormFlightScheduleCE(flightSchedule, HelperClass.FormMode.EDIT);
            // f.MdiParent = this.MdiParent;

            // Hien form Edit len va doi cho den khi form bi tat di
            f.ShowDialog();

            // Load lai bang sau khi form Edit da tat
            LoadDataGridView();
        }

        private async void btnDelete_Click(object sender, EventArgs e)
        {
            // Lay may bay dang duoc chon trong bang
            FlightSchedule flightSchedule = GetSelectedFlightSchedule();

            // Neu hien tai khong co may bay nao duoc chon thi hien thong bao
            if (flightSchedule == null)
            {
                MessageBox.Show("You must choose an airplane to edit!", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }

            // Neu co may bay dang duoc chon thi sua cot IsActive lai thanh False
            flightSchedule.IsActive = false;

            // Gui len server de cap nhat lai cot IsActive trong CSDL
            FlightScheduleWrapper flightScheduleWrapper = new FlightScheduleWrapper();
            bool isSuccess = await flightScheduleWrapper.Put(flightSchedule.ID.ToString(), flightSchedule);

            // Kiem tra ket qua tra ve
            if (isSuccess)
            {
                // Neu ket qua la thanh cong, hien thong bao thanh cong
                MessageBox.Show("Flight Schedule was set to inactive!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);

                // Load lai bang
                LoadDataGridView();

            }
            else
            {
                // Neu ket qua that bai, hien thong bao loi
                MessageBox.Show("An error has occurred!\n" + flightScheduleWrapper.GetErrorMessage(), "Failed", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnReload_Click(object sender, EventArgs e)
        {
            LoadDataGridView();
        }


        public async void LoadDataGridView()
        {
            // Luu lai dong hien tai dang chon
            int currentRowIndex;

            // Neu hien tai khong co dong nao duoc chon thi mac dinh la dong so 0
            if (dgvFlightSchedule.SelectedRows.Count == 0)
            {
                currentRowIndex = 0;
            }
            else
            {
                currentRowIndex = dgvFlightSchedule.Rows.IndexOf(dgvFlightSchedule.SelectedRows[0]);
            }

            // Luu lai dong hien tai dang o dau` bang? trong dataGridView
            int firstRowIndex = dgvFlightSchedule.FirstDisplayedScrollingRowIndex;
            if (firstRowIndex == -1) firstRowIndex = 0;
            // Goi API lay du lieu ve
            FlightScheduleWrapper flightScheduleWrapper = new FlightScheduleWrapper();
            List<FlightSchedule> lstFlightSchedule = await flightScheduleWrapper.List();

            // Khai bao API de lay du lieu cua bang City (City)
            // va Thong tin ve` so luong cua tung loai ghe (AirplaneInfo)
            AirplaneWrapper airplaneWrapper = new AirplaneWrapper();
            AirplaneTypeWrapper airplaneTypeWrapper = new AirplaneTypeWrapper();
            RouteWrapper routeWrapper = new RouteWrapper();
            CityWrapper cityWrapper = new CityWrapper();

            // Goi API lay du lieu ve
            List<Airplane> lstAirplane = await airplaneWrapper.List();
            List<AirplaneType> lstAirplaneType = await airplaneTypeWrapper.List();
            List<Route> lstRoute = await routeWrapper.List();
            List<City> lstCity = await cityWrapper.List();

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

                // Chon lai dong ban dau duoc chon truoc khi reload
                if (dgvFlightSchedule.Rows.Count > 0) dgvFlightSchedule.Rows[currentRowIndex].Selected = true;

                // Cuon. toi' dong` duoc. chon.
                dgvFlightSchedule.FirstDisplayedScrollingRowIndex = firstRowIndex;
            }
        }

        private FlightSchedule GetSelectedFlightSchedule()
        {
            // Neu khong co dong nao dang duoc chon thi tra ve null
            if (dgvFlightSchedule.SelectedRows.Count != 1) return null;

            // Neu co 1 dong dang duoc chon thi lay dong do ra
            DataGridViewRow row = dgvFlightSchedule.SelectedRows[0];

            // Lay du lieu trong dong do va tao ra mot Airplane moi
            FlightSchedule flightSchedule = new FlightSchedule()
            {
                ID = Convert.ToInt32(row.Cells["ID"].Value),
                AirplaneCode = row.Cells["AirplaneCode"].Value.ToString(),
                RouteID = Convert.ToInt32(row.Cells["RouteID"].Value),
                DepartureDate = Convert.ToDateTime(row.Cells["DepartureDate"].Value),
                FirstSeatAvail = Convert.ToInt32(row.Cells["FirstSeatAvail"].Value),
                BusinessSeatAvail = Convert.ToInt32(row.Cells["BusinessSeatAvail"].Value),
                ClubSeatAvail = Convert.ToInt32(row.Cells["ClubSeatAvail"].Value),
                IsActive = Convert.ToBoolean(row.Cells["IsActive"].Value)

            };

            // Tra Airplane vua tao ve
            return flightSchedule;
        }

    }
}
