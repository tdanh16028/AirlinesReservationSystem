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
    public partial class FormAirplaneClassList : Form
    {
        public FormAirplaneClassList()
        {
            InitializeComponent();
        }
    
           private void AirplaneClass_Load(object sender, EventArgs e)
            {
            LoadDataGridView();
            }

        private void btnSubmit_Click(object sender, EventArgs e)
        {
            FormAirplaneClassCE f = new FormAirplaneClassCE();
            // f.MdiParent = this.MdiParent;

            // Hien form Create len va doi cho den khi form bi tat di
            f.ShowDialog();

            // Load lai bang sau khi form Create da tat
            LoadDataGridView();
        }

        private void btnEdit_Click(object sender, EventArgs e)
        {

            // Lay class dang duoc chon trong bang
            AirplaneClass airplaneClass = GetSelectedAirplaneClass();

            // Neu hien tai khong co class  nao duoc chon thi hien thong bao
            if (airplaneClass == null)
            {
                MessageBox.Show("You must choose an account to edit!", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }

            // Neu co tai khoan dang duoc chon thi hien form chinh sua thong tin len, truyen du lieu qua
            FormAirplaneClassCE f = new FormAirplaneClassCE(airplaneClass, HelperClass.FormMode.EDIT);
            // f.MdiParent = this.MdiParent;

            // Hien form Edit len va doi cho den khi form bi tat di
            f.ShowDialog();

            // Load lai bang sau khi form Edit da tat
            LoadDataGridView();
        }

        private void btnReload_Click_1(object sender, EventArgs e)
        {
            LoadDataGridView();
        }
        private AirplaneClass GetSelectedAirplaneClass()
        {
            // Neu khong co dong nao dang duoc chon thi tra ve null
            if (dgvAirplaneClass.SelectedRows.Count != 1) return null;

            // Neu co 1 dong dang duoc chon thi lay dong do ra
            DataGridViewRow row = dgvAirplaneClass.SelectedRows[0];

            // Lay du lieu trong dong do va tao ra mot AirplaneClass moi
            AirplaneClass airplaneClass = new AirplaneClass()
            {
                ID = Convert.ToInt32(row.Cells["ID"].Value),
                Class = row.Cells["Class"].Value.ToString(),
                PriceRate = Convert.ToDouble(row.Cells["PriceRate"].Value)
            };

            // Tra AirplaneClass vua tao ve
            return airplaneClass;
        }

        public async void LoadDataGridView()
        {
            // Luu lai dong hien tai dang chon
            int currentRowIndex;

            // Neu hien tai khong co dong nao duoc chon thi mac dinh la dong so 0
            if (dgvAirplaneClass.SelectedRows.Count == 0)
            {
                currentRowIndex = 0;
            }
            else
            {
                currentRowIndex = dgvAirplaneClass.Rows.IndexOf(dgvAirplaneClass.SelectedRows[0]);
            }

            // Goi API lay du lieu ve
            AirplaneClassWrapper airplaneClassWrapper = new AirplaneClassWrapper();
            List<AirplaneClass> lstAirplaneClass = await airplaneClassWrapper.List();

            // Tao bang de chua du lieu tra ve tu API
            DataTable table = new DataTable();
            table.Columns.Add("ID");
            table.Columns.Add("Class");
            table.Columns.Add("PriceRate");

            // Kiem tra xem ket qua goi API co thanh cong hay khong
            if (lstAirplaneClass != null)
            {
                // Lap qua tung "dong` du lieu"
                foreach (AirplaneClass airplaneClass in lstAirplaneClass)
                {
                    // Tao mot dong` trong bang winForm
                    DataRow row = table.NewRow();

                    // Gan du lieu len dong moi tao
                    row["ID"] = airplaneClass.ID;
                    row["Class"] = airplaneClass.Class;
                    row["PriceRate"] = airplaneClass.PriceRate;
                    // Gan dong moi tao vao bang
                    table.Rows.Add(row);
                }

                // Sau khi lap qua het cac dong du lieu
                // Ta co bang WinForm hoan chinh
                // Gan bang WinForm len DataGridView
                dgvAirplaneClass.DataSource = table;

                // Chon lai dong ban dau duoc chon truoc khi reload
                dgvAirplaneClass.Rows[currentRowIndex].Selected = true;
            }
        }

    }
}
