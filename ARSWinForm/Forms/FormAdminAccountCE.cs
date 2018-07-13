using ARSWinForm.Model;
using System;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ARSWinForm
{
    public partial class FormAdminAccountCE : Form
    {
        public FormAdminAccountCE()
        {
            InitializeComponent();
        }
        public async Task AddNewAdminAccount(int id, string username, string password, string name, string role )
        {
            string url = "http://localhost:61765/api/AdminAccounts";
            var client = new HttpClient();
            client.BaseAddress = new Uri(url);
            client.DefaultRequestHeaders.Accept.Clear();
            client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
            HttpResponseMessage response = await client.GetAsync(url);

            AdminAccount aa = new AdminAccount()
            {
                ID = id,
                Username = username,
                Password = password,
                Name = name,
                Role = role,
           

            };
            response = await client.PostAsJsonAsync(url, aa);
            if (response.IsSuccessStatusCode)
            {
                MessageBox.Show("OK", "Info", MessageBoxButtons.OK, MessageBoxIcon.Information);
                this.Close();
            }
            else
            {
                MessageBox.Show("Failed", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        public async Task AddNewAdmin(int id, string username, string password, string name, string role)
        {
            AddNewAdminAccount(id, username, password, name, role);
        }
        private void btnSave_Click(object sender, EventArgs e)
        {
            AddNewAdmin(0, txtUsername.Text, txtPassword.Text, txtName.Text, txtRole.Text);
        }

        private void btnReset_Click(object sender, EventArgs e)
        {
            txtID.Text = txtID.Text;
            txtUsername.Text = "";
            txtPassword.Text = "";
            txtName.Text = "";
            txtRole.Text = "";
        }
    }
}
