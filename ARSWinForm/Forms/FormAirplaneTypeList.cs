using ARSWinForm.HelperClass.ModelHelper;
using ARSWinForm.Model;
using Newtonsoft.Json.Linq;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Windows.Forms;

namespace ARSWinForm
{
    public partial class FormAirplaneTypeList : Form
    {

        public FormAirplaneTypeList()
        {
            InitializeComponent();
        }

        private void AirplaneType_Load(object sender, EventArgs e)
        {
            LoadDataGridView();
        }

        private void btnSubmit_Click(object sender, EventArgs e)
        {
            FormAirplaneTypeCE f = new FormAirplaneTypeCE();
            // f.MdiParent = this.MdiParent;

            // Hien form Create len va doi cho den khi form bi tat di
            f.ShowDialog();

            // Load lai bang sau khi form Create da tat
            LoadDataGridView();
        }

        private void btnEdit_Click(object sender, EventArgs e)
        {
            // Lay tai khoan admin dang duoc chon trong bang
            AirplaneType airplaneType = GetSelectedAirplaneType();

            // Neu hien tai khong co tai khoan nao duoc chon thi hien thong bao
            if (airplaneType == null)
            {
                MessageBox.Show("You must choose an aiplane to edit!", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }

            // Neu co tai khoan dang duoc chon thi hien form chinh sua thong tin len, truyen du lieu qua
            FormAirplaneTypeCE f = new FormAirplaneTypeCE(airplaneType, HelperClass.FormMode.EDIT);
            // f.MdiParent = this.MdiParent;

            // Hien form Edit len va doi cho den khi form bi tat di
            f.ShowDialog();

            // Load lai bang sau khi form Edit da tat
            LoadDataGridView();
        }

        private async void btnDelete_Click(object sender, EventArgs e)
        {
            // Lay may bay dang duoc chon trong bang
            AirplaneType airplaneType = GetSelectedAirplaneType();

            // Neu hien tai khong co may bay nao duoc chon thi hien thong bao
            if (airplaneType == null)
            {
                MessageBox.Show("You must choose an airplane to edit!", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }

            // Neu co may bay dang duoc chon thi sua cot IsActive lai thanh False
            airplaneType.IsActive = false;

            // Gui len server de cap nhat lai cot IsActive trong CSDL
            AirplaneTypeWrapper airplaneTypeWrapper = new AirplaneTypeWrapper();
            bool isSuccess = await airplaneTypeWrapper.Put(airplaneType.ID, airplaneType);

            // Kiem tra ket qua tra ve
            if (isSuccess)
            {
                // Neu ket qua la thanh cong, hien thong bao thanh cong
                MessageBox.Show("Airplane type was set to inactive!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);

                // Load lai bang
                LoadDataGridView();

            }
            else
            {
                // Neu ket qua that bai, hien thong bao loi
                MessageBox.Show("An error has occurred!\n" + airplaneTypeWrapper.GetErrorMessage(), "Failed", MessageBoxButtons.OK, MessageBoxIcon.Error);
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
            if (dgvAirplaneType.SelectedRows.Count == 0)
            {
                currentRowIndex = 0;
            }
            else
            {
                currentRowIndex = dgvAirplaneType.Rows.IndexOf(dgvAirplaneType.SelectedRows[0]);
            }

            // Luu lai dong hien tai dang o dau` bang? trong dataGridView
            int firstRowIndex = dgvAirplaneType.FirstDisplayedScrollingRowIndex;
            if (firstRowIndex == -1) firstRowIndex = 0;

            // Goi API lay du lieu ve
            AirplaneTypeWrapper airplaneTypeWrapper = new AirplaneTypeWrapper();
            List<AirplaneType> lstAirplaneType = await airplaneTypeWrapper.List();

            AirplaneInfoWrapper airplaneInfoWrapper = new AirplaneInfoWrapper();
            List<AirplaneInfo> lstAirplaneInfo = await airplaneInfoWrapper.List();

            // Tao bang de chua du lieu tra ve tu API
            DataTable table = new DataTable();
            table.Columns.Add("ID");
            table.Columns.Add("Name");
            table.Columns.Add("FirstClassSeat");
            table.Columns.Add("BusinessClassSeat");
            table.Columns.Add("ClubClassSeat");
            table.Columns.Add("IsActive");

            // Kiem tra xem ket qua goi API co thanh cong hay khong
            if (lstAirplaneType != null)
            {
                // Lap qua tung "dong` du lieu"
                foreach (AirplaneType airplaneType in lstAirplaneType)
                {
                    // Tao mot dong` trong bang winForm
                    DataRow row = table.NewRow();

                    // Gan du lieu len dong moi tao
                    row["ID"] = airplaneType.ID;;
                    row["Name"] = airplaneType.Name;
                    row["FirstClassSeat"] = lstAirplaneInfo.Find(ai => ai.AirplaneTypeID == airplaneType.ID && ai.ClassID == 1).SeatCount;
                    row["BusinessClassSeat"] = lstAirplaneInfo.Find(ai => ai.AirplaneTypeID == airplaneType.ID && ai.ClassID == 2).SeatCount;
                    row["ClubClassSeat"] = lstAirplaneInfo.Find(ai => ai.AirplaneTypeID == airplaneType.ID && ai.ClassID == 3).SeatCount;
                    row["IsActive"] = airplaneType.IsActive;

                    // Gan dong moi tao vao bang
                    table.Rows.Add(row);
                }

                // Sau khi lap qua het cac dong du lieu
                // Ta co bang WinForm hoan chinh
                // Gan bang WinForm len DataGridView
                dgvAirplaneType.DataSource = table;

                // Chon lai dong ban dau duoc chon truoc khi reload
                dgvAirplaneType.Rows[currentRowIndex].Selected = true;

                // Cuon. toi' dong` duoc. chon.
                dgvAirplaneType.FirstDisplayedScrollingRowIndex = firstRowIndex;
            }
        }

        private AirplaneType GetSelectedAirplaneType()
        {
            // Neu khong co dong nao dang duoc chon thi tra ve null
            if (dgvAirplaneType.SelectedRows.Count != 1) return null;

            // Neu co 1 dong dang duoc chon thi lay dong do ra
            DataGridViewRow row = dgvAirplaneType.SelectedRows[0];

            // Lay du lieu trong dong do va tao ra mot Airplane moi
            AirplaneType airplaneType = new AirplaneType()
            {
                ID = Convert.ToInt32(row.Cells["ID"].Value),
                Name = row.Cells["Name"].Value.ToString(),
                AirplaneInfoes = new List<AirplaneInfo>()
                {
                    new AirplaneInfo()
                    {
                        AirplaneTypeID = Convert.ToInt32(row.Cells["ID"].Value),
                        ClassID = 1,
                        SeatCount = Convert.ToInt32(row.Cells["FirstClassSeat"].Value),
                    },
                    new AirplaneInfo()
                    {
                        AirplaneTypeID = Convert.ToInt32(row.Cells["ID"].Value),
                        ClassID = 2,
                        SeatCount = Convert.ToInt32(row.Cells["BusinessClassSeat"].Value),
                    },
                    new AirplaneInfo()
                    {
                        AirplaneTypeID = Convert.ToInt32(row.Cells["ID"].Value),
                        ClassID = 3,
                        SeatCount = Convert.ToInt32(row.Cells["ClubClassSeat"].Value),
                    }
                },
                IsActive = Convert.ToBoolean(row.Cells["IsActive"].Value)
            };

            // Tra Airplane vua tao ve
            return airplaneType;
        }

    }
}
