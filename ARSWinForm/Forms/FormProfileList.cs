using ARSWinForm.HelperClass.ModelHelper;
using ARSWinForm.Model;
using System;
using System.Collections.Generic;
using System.Data;
using System.Windows.Forms;

namespace ARSWinForm
{
    public partial class FormProfileList : Form
    {
        public FormProfileList()
        {
            InitializeComponent();
        }

        private void FormProfileList_Load(object sender, System.EventArgs e)
        {
            LoadDataGridView();
        }
        private void btnSubmit_Click(object sender, EventArgs e)
        {
            FormProfileCE f = new FormProfileCE();
            // f.MdiParent = this.MdiParent;

            // Hien form Create len va doi cho den khi form bi tat di
            f.ShowDialog();

            // Load lai bang sau khi form Create da tat
            LoadDataGridView();

        }
        private void btnEdit_Click(object sender, EventArgs e)
        {
            // Lay tai khoan admin dang duoc chon trong bang
            Profile profile = GetSelectedProfile();

            // Neu hien tai khong co tai khoan nao duoc chon thi hien thong bao
            if (profile == null)
            {
                MessageBox.Show("You must choose an account to edit!", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }

            // Neu co tai khoan dang duoc chon thi hien form chinh sua thong tin len, truyen du lieu qua
            FormProfileCE f = new FormProfileCE(profile, HelperClass.FormMode.EDIT);
            // f.MdiParent = this.MdiParent;

            // Hien form Edit len va doi cho den khi form bi tat di
            f.ShowDialog();

            // Load lai bang sau khi form Edit da tat
            LoadDataGridView();
        }

        private async void btnDelete_Click(object sender, System.EventArgs e)
        {
            // Lay tai khoan admin dang duoc chon trong bang
            Profile profile = GetSelectedProfile();

            // Neu hien tai khong co tai khoan nao duoc chon thi hien thong bao
            if (profile == null)
            {
                MessageBox.Show("You must choose an account to edit!", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }

            // Neu co tai khoan dang duoc chon thi sua cot IsActive lai thanh False
            profile.IsActive = false;

            // Gui len server de cap nhat lai cot IsActive trong CSDL
            ProfileWrapper profileWrapper = new ProfileWrapper();
            bool isSuccess = await profileWrapper.Put(Convert.ToInt32(profile.ID), profile);

            // Kiem tra ket qua tra ve
            if (isSuccess)
            {
                // Neu ket qua la thanh cong, hien thong bao thanh cong
                MessageBox.Show("Account status was set to inactive!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);

                // Load lai bang
                LoadDataGridView();

            }
            else
            {
                // Neu ket qua that bai, hien thong bao loi
                MessageBox.Show("An error has occurred!", "Failed", MessageBoxButtons.OK, MessageBoxIcon.Error);
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
            if (dgvProfile.SelectedRows.Count == 0)
            {
                currentRowIndex = 0;
            }
            else
            {
                currentRowIndex = dgvProfile.Rows.IndexOf(dgvProfile.SelectedRows[0]);
            }

            // Goi API lay du lieu ve
            ProfileWrapper profileWrapper = new ProfileWrapper();
            List<Profile> lstProfile = await profileWrapper.List();

            // Tao bang de chua du lieu tra ve tu API
            DataTable table = new DataTable();
            table.Columns.Add("ID");
            table.Columns.Add("UserID");
            table.Columns.Add("Password");
            table.Columns.Add("FirstName");
            table.Columns.Add("LastName");
            table.Columns.Add("Address");
            table.Columns.Add("PhoneNumber");
            table.Columns.Add("EmailAddress");
            table.Columns.Add("Sex");
            table.Columns.Add("Age");
            table.Columns.Add("CreditCard");
            table.Columns.Add("SkyMiles");
            table.Columns.Add("IsActive");

            // Kiem tra xem ket qua goi API co thanh cong hay khong
            if (lstProfile != null)
            {
                // Lap qua tung "dong` du lieu"
                foreach (Profile profile in lstProfile)
                {
                    // Tao mot dong` trong bang winForm
                    DataRow row = table.NewRow();

                    // Gan du lieu len dong moi tao
                    row["ID"] = profile.ID;
                    row["UserID"] = profile.UserID;
                    row["Password"] = profile.Password;
                    row["FirstName"] = profile.FirstName;
                    row["LastName"] = profile.LastName;
                    row["Address"] = profile.Address;
                    row["PhoneNumber"] = profile.PhoneNumber;
                    row["EmailAddress"] = profile.EmailAddress;
                    row["Sex"] = profile.Sex;
                    row["Age"] = profile.Age;
                    row["CreditCard"] = profile.CreditCard;
                    row["SkyMiles"] = profile.SkyMiles;
                    row["IsActive"] = profile.IsActive;

                    // Gan dong moi tao vao bang
                    table.Rows.Add(row);
                }

                // Sau khi lap qua het cac dong du lieu
                // Ta co bang WinForm hoan chinh
                // Gan bang WinForm len DataGridView
                dgvProfile.DataSource = table;

                // Chon lai dong ban dau duoc chon truoc khi reload
                dgvProfile.Rows[currentRowIndex].Selected = true;
            }
        }
        private Profile GetSelectedProfile()
        {
            // Neu khong co dong nao dang duoc chon thi tra ve null
            if (dgvProfile.SelectedRows.Count != 1) return null;

            // Neu co 1 dong dang duoc chon thi lay dong do ra
            DataGridViewRow row = dgvProfile.SelectedRows[0];

            // Lay du lieu trong dong do va tao ra mot AdminAccount moi
            Profile profile = new Profile()
            {
                ID = Convert.ToInt32(row.Cells["ID"].Value),
                UserID = row.Cells["UserID"].Value.ToString(),
                Password = row.Cells["Password"].Value.ToString(),
                FirstName = row.Cells["FirstName"].Value.ToString(),
                LastName = row.Cells["LastName"].Value.ToString(),
                Address = row.Cells["Address"].Value.ToString(),
                PhoneNumber = row.Cells["PhoneNumber"].Value.ToString(),
                EmailAddress = row.Cells["EmailAddress"].Value.ToString(),
                Sex = Convert.ToBoolean(row.Cells["Sex"].Value),
                Age = Convert.ToInt32(row.Cells["Age"].Value),
                CreditCard = row.Cells["CreditCard"].Value.ToString(),
                SkyMiles = Convert.ToInt32(row.Cells["SkyMiles"].Value),
                IsActive = Convert.ToBoolean(row.Cells["IsActive"].Value)
            };

            // Tra AdminAccount vua tao ve
            return profile;
        }

        private void button1_Click(object sender, EventArgs e)
        {

        }
    }
}
