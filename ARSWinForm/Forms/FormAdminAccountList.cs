﻿using ARSWinForm.HelperClass.ModelHelper;
using ARSWinForm.Model;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Data;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Windows.Forms;

namespace ARSWinForm
{
    public partial class FormAdminAccountList : Form
    {
        public FormAdminAccountList()
        {
            InitializeComponent();
        }

        private void AdminAccount_Load(object sender, EventArgs e)
        {
            LoadDataGridView();
        }

        private void btnCreate_Click(object sender, EventArgs e)
        {
            FormAdminAccountCE f = new FormAdminAccountCE();
            f.MdiParent = this.MdiParent;
            f.Show();
        }

        private void btnEdit_Click(object sender, EventArgs e)
        {
            // Lay tai khoan admin dang duoc chon trong bang
            AdminAccount adminAccount = GetSelectedAdminAccount();

            // Neu hien tai khong co tai khoan nao duoc chon thi hien thong bao
            if (adminAccount == null)
            {
                MessageBox.Show("You must choose an account to edit!", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }

            // Neu co tai khoan dang duoc chon thi hien form chinh sua thong tin len, truyen du lieu qua
            FormAdminAccountCE f = new FormAdminAccountCE(adminAccount, HelperClass.FormMode.EDIT);
            f.MdiParent = this.MdiParent;
            f.Show();
        }
        
        private async void btnDelete_Click(object sender, EventArgs e)
        {
            // Lay tai khoan admin dang duoc chon trong bang
            AdminAccount adminAccount = GetSelectedAdminAccount();

            // Neu hien tai khong co tai khoan nao duoc chon thi hien thong bao
            if (adminAccount == null)
            {
                MessageBox.Show("You must choose an account to edit!", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }

            // Neu co tai khoan dang duoc chon thi sua cot IsActive lai thanh False
            adminAccount.IsActive = false;

            // Gui len server de cap nhat lai cot IsActive trong CSDL
            AdminAccountWrapper adminAccountWrapper = new AdminAccountWrapper();
            bool isSuccess = await adminAccountWrapper.Put(adminAccount.ID, adminAccount);

            // Kiem tra ket qua tra ve
            if (isSuccess)
            {
                // Neu ket qua la thanh cong, hien thong bao thanh cong
                MessageBox.Show("Account status was set to inactive!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
            } else
            {
                // Neu ket qua that bai, hien thong bao loi
                MessageBox.Show("An error has occurred!", "Failed", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnReload_Click(object sender, EventArgs e)
        {
            LoadDataGridView();
        }

        private async void LoadDataGridView()
        {
            // Goi API lay du lieu ve
            AdminAccountWrapper adminAccountWrapper = new AdminAccountWrapper();
            List<AdminAccount> lstAdminAccount = await adminAccountWrapper.List();

            // Tao bang de chua du lieu tra ve tu API
            DataTable table = new DataTable();
            table.Columns.Add("ID");
            table.Columns.Add("Username");
            table.Columns.Add("Password");
            table.Columns.Add("Name");
            table.Columns.Add("Role");
            table.Columns.Add("IsActive");

            // Kiem tra xem ket qua goi API co thanh cong hay khong
            if (lstAdminAccount != null)
            {
                // Lap qua tung "dong` du lieu"
                foreach (AdminAccount adminAccount in lstAdminAccount)
                {
                    // Tao mot dong` trong bang winForm
                    DataRow row = table.NewRow();

                    // Gan du lieu len dong moi tao
                    row["ID"] = adminAccount.ID;
                    row["Username"] = adminAccount.Username;
                    row["Password"] = adminAccount.Password;
                    row["Name"] = adminAccount.Name;
                    row["Role"] = adminAccount.Role;
                    row["IsActive"] = adminAccount.IsActive;

                    // Gan dong moi tao vao bang
                    table.Rows.Add(row);
                }

                // Sau khi lap qua het cac dong du lieu
                // Ta co bang WinForm hoan chinh
                // Gan bang WinForm len DataGridView
                dgvAdmin.DataSource = table;
            }
        }

        private AdminAccount GetSelectedAdminAccount()
        {
            // Neu khong co dong nao dang duoc chon thi tra ve null
            if (dgvAdmin.SelectedRows.Count != 1) return null;

            // Neu co 1 dong dang duoc chon thi lay dong do ra
            DataGridViewRow row = dgvAdmin.SelectedRows[0];

            // Lay du lieu trong dong do va tao ra mot AdminAccount moi
            AdminAccount adminAccount = new AdminAccount() {
                ID = Convert.ToInt32(row.Cells["ID"].Value),
                Username = row.Cells["Username"].Value.ToString(),
                Password = row.Cells["Password"].Value.ToString(),
                Name = row.Cells["Name"].Value.ToString(),
                Role = row.Cells["Role"].Value.ToString(),
                IsActive = Convert.ToBoolean(row.Cells["IsActive"].Value)
            };

            // Tra AdminAccount vua tao ve
            return adminAccount;
        }
    }
}
