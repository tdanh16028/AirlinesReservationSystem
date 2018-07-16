namespace ARSWinForm
{
    partial class FormMain
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.msMainMenu = new System.Windows.Forms.MenuStrip();
            this.authenticationToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.loginToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.logoutToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.managementToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.accountToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.adminToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.customerProfileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.airplaneToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.airplaneToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.airplaneTypeToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.classOfSeatToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.flightScheduleTicketToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.cityToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.routeToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.flightScheduleToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.ticketToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.exitToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.msMainMenu.SuspendLayout();
            this.SuspendLayout();
            // 
            // msMainMenu
            // 
            this.msMainMenu.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.msMainMenu.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.authenticationToolStripMenuItem,
            this.managementToolStripMenuItem,
            this.exitToolStripMenuItem});
            this.msMainMenu.Location = new System.Drawing.Point(0, 0);
            this.msMainMenu.Name = "msMainMenu";
            this.msMainMenu.Padding = new System.Windows.Forms.Padding(8, 2, 0, 2);
            this.msMainMenu.Size = new System.Drawing.Size(1605, 28);
            this.msMainMenu.TabIndex = 1;
            this.msMainMenu.Text = "menuStrip1";
            // 
            // authenticationToolStripMenuItem
            // 
            this.authenticationToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.loginToolStripMenuItem,
            this.logoutToolStripMenuItem});
            this.authenticationToolStripMenuItem.Image = global::ARSWinForm.Properties.Resources.icons8_administrator_male_26;
            this.authenticationToolStripMenuItem.Name = "authenticationToolStripMenuItem";
            this.authenticationToolStripMenuItem.Size = new System.Drawing.Size(138, 24);
            this.authenticationToolStripMenuItem.Text = "Authentication";
            // 
            // loginToolStripMenuItem
            // 
            this.loginToolStripMenuItem.Image = global::ARSWinForm.Properties.Resources.icons8_import_50;
            this.loginToolStripMenuItem.Name = "loginToolStripMenuItem";
            this.loginToolStripMenuItem.Size = new System.Drawing.Size(216, 26);
            this.loginToolStripMenuItem.Text = "Login";
            this.loginToolStripMenuItem.Click += new System.EventHandler(this.loginToolStripMenuItem_Click);
            // 
            // logoutToolStripMenuItem
            // 
            this.logoutToolStripMenuItem.Enabled = false;
            this.logoutToolStripMenuItem.Image = global::ARSWinForm.Properties.Resources.icons8_export_50;
            this.logoutToolStripMenuItem.Name = "logoutToolStripMenuItem";
            this.logoutToolStripMenuItem.Size = new System.Drawing.Size(216, 26);
            this.logoutToolStripMenuItem.Text = "Logout";
            this.logoutToolStripMenuItem.Click += new System.EventHandler(this.logoutToolStripMenuItem_Click);
            // 
            // managementToolStripMenuItem
            // 
            this.managementToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.accountToolStripMenuItem,
            this.airplaneToolStripMenuItem,
            this.flightScheduleTicketToolStripMenuItem});
            this.managementToolStripMenuItem.Enabled = false;
            this.managementToolStripMenuItem.Image = global::ARSWinForm.Properties.Resources.icons8_business_32;
            this.managementToolStripMenuItem.Name = "managementToolStripMenuItem";
            this.managementToolStripMenuItem.Size = new System.Drawing.Size(129, 24);
            this.managementToolStripMenuItem.Text = "Management";
            // 
            // accountToolStripMenuItem
            // 
            this.accountToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.adminToolStripMenuItem,
            this.customerProfileToolStripMenuItem});
            this.accountToolStripMenuItem.Image = global::ARSWinForm.Properties.Resources.icons8_administrator_male_26;
            this.accountToolStripMenuItem.Name = "accountToolStripMenuItem";
            this.accountToolStripMenuItem.Size = new System.Drawing.Size(244, 26);
            this.accountToolStripMenuItem.Text = "Account";
            // 
            // adminToolStripMenuItem
            // 
            this.adminToolStripMenuItem.Image = global::ARSWinForm.Properties.Resources.icons8_administrator_male_26;
            this.adminToolStripMenuItem.Name = "adminToolStripMenuItem";
            this.adminToolStripMenuItem.Size = new System.Drawing.Size(194, 26);
            this.adminToolStripMenuItem.Text = "Admin";
            this.adminToolStripMenuItem.Click += new System.EventHandler(this.adminToolStripMenuItem_Click);
            // 
            // customerProfileToolStripMenuItem
            // 
            this.customerProfileToolStripMenuItem.Image = global::ARSWinForm.Properties.Resources.icons8_administrator_male_26;
            this.customerProfileToolStripMenuItem.Name = "customerProfileToolStripMenuItem";
            this.customerProfileToolStripMenuItem.Size = new System.Drawing.Size(194, 26);
            this.customerProfileToolStripMenuItem.Text = "Customer Profile";
            this.customerProfileToolStripMenuItem.Click += new System.EventHandler(this.customerProfileToolStripMenuItem_Click);
            // 
            // airplaneToolStripMenuItem
            // 
            this.airplaneToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.airplaneToolStripMenuItem1,
            this.airplaneTypeToolStripMenuItem,
            this.classOfSeatToolStripMenuItem});
            this.airplaneToolStripMenuItem.Image = global::ARSWinForm.Properties.Resources.icons8_airport_24;
            this.airplaneToolStripMenuItem.Name = "airplaneToolStripMenuItem";
            this.airplaneToolStripMenuItem.Size = new System.Drawing.Size(244, 26);
            this.airplaneToolStripMenuItem.Text = "Airplane";
            // 
            // airplaneToolStripMenuItem1
            // 
            this.airplaneToolStripMenuItem1.Image = global::ARSWinForm.Properties.Resources.icons8_airport_24;
            this.airplaneToolStripMenuItem1.Name = "airplaneToolStripMenuItem1";
            this.airplaneToolStripMenuItem1.Size = new System.Drawing.Size(216, 26);
            this.airplaneToolStripMenuItem1.Text = "Airplane";
            this.airplaneToolStripMenuItem1.Click += new System.EventHandler(this.airplaneToolStripMenuItem1_Click);
            // 
            // airplaneTypeToolStripMenuItem
            // 
            this.airplaneTypeToolStripMenuItem.Image = global::ARSWinForm.Properties.Resources.icons8_airport_24;
            this.airplaneTypeToolStripMenuItem.Name = "airplaneTypeToolStripMenuItem";
            this.airplaneTypeToolStripMenuItem.Size = new System.Drawing.Size(216, 26);
            this.airplaneTypeToolStripMenuItem.Text = "Airplane Type";
            // 
            // classOfSeatToolStripMenuItem
            // 
            this.classOfSeatToolStripMenuItem.Image = global::ARSWinForm.Properties.Resources.icons8_passenger_26;
            this.classOfSeatToolStripMenuItem.Name = "classOfSeatToolStripMenuItem";
            this.classOfSeatToolStripMenuItem.Size = new System.Drawing.Size(216, 26);
            this.classOfSeatToolStripMenuItem.Text = "Class of Seat";
            this.classOfSeatToolStripMenuItem.Click += new System.EventHandler(this.classOfSeatToolStripMenuItem_Click);
            // 
            // flightScheduleTicketToolStripMenuItem
            // 
            this.flightScheduleTicketToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.cityToolStripMenuItem,
            this.routeToolStripMenuItem,
            this.flightScheduleToolStripMenuItem,
            this.ticketToolStripMenuItem});
            this.flightScheduleTicketToolStripMenuItem.Image = global::ARSWinForm.Properties.Resources.icons8_calendar_16;
            this.flightScheduleTicketToolStripMenuItem.Name = "flightScheduleTicketToolStripMenuItem";
            this.flightScheduleTicketToolStripMenuItem.Size = new System.Drawing.Size(244, 26);
            this.flightScheduleTicketToolStripMenuItem.Text = "Flight Schedule && Ticket";
            // 
            // cityToolStripMenuItem
            // 
            this.cityToolStripMenuItem.Image = global::ARSWinForm.Properties.Resources.icons8_city_50;
            this.cityToolStripMenuItem.Name = "cityToolStripMenuItem";
            this.cityToolStripMenuItem.Size = new System.Drawing.Size(216, 26);
            this.cityToolStripMenuItem.Text = "City";
            this.cityToolStripMenuItem.Click += new System.EventHandler(this.cityToolStripMenuItem_Click);
            // 
            // routeToolStripMenuItem
            // 
            this.routeToolStripMenuItem.Image = global::ARSWinForm.Properties.Resources.icons8_route_32;
            this.routeToolStripMenuItem.Name = "routeToolStripMenuItem";
            this.routeToolStripMenuItem.Size = new System.Drawing.Size(216, 26);
            this.routeToolStripMenuItem.Text = "Route";
            this.routeToolStripMenuItem.Click += new System.EventHandler(this.routeToolStripMenuItem_Click);
            // 
            // flightScheduleToolStripMenuItem
            // 
            this.flightScheduleToolStripMenuItem.Image = global::ARSWinForm.Properties.Resources.icons8_calendar_16;
            this.flightScheduleToolStripMenuItem.Name = "flightScheduleToolStripMenuItem";
            this.flightScheduleToolStripMenuItem.Size = new System.Drawing.Size(216, 26);
            this.flightScheduleToolStripMenuItem.Text = "Flight Schedule";
            this.flightScheduleToolStripMenuItem.Click += new System.EventHandler(this.flightScheduleToolStripMenuItem_Click);
            // 
            // ticketToolStripMenuItem
            // 
            this.ticketToolStripMenuItem.Image = global::ARSWinForm.Properties.Resources.icons8_two_tickets_32;
            this.ticketToolStripMenuItem.Name = "ticketToolStripMenuItem";
            this.ticketToolStripMenuItem.Size = new System.Drawing.Size(216, 26);
            this.ticketToolStripMenuItem.Text = "Ticket";
            // 
            // exitToolStripMenuItem
            // 
            this.exitToolStripMenuItem.Image = global::ARSWinForm.Properties.Resources.icons8_delete_48;
            this.exitToolStripMenuItem.Name = "exitToolStripMenuItem";
            this.exitToolStripMenuItem.Size = new System.Drawing.Size(65, 24);
            this.exitToolStripMenuItem.Text = "Exit";
            this.exitToolStripMenuItem.Click += new System.EventHandler(this.exitToolStripMenuItem_Click);
            // 
            // FormMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1605, 855);
            this.Controls.Add(this.msMainMenu);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.IsMdiContainer = true;
            this.MainMenuStrip = this.msMainMenu;
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "FormMain";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Airlines Reversation System";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.FormMain_FormClosing);
            this.Load += new System.EventHandler(this.FormMain_Load);
            this.msMainMenu.ResumeLayout(false);
            this.msMainMenu.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip msMainMenu;
        private System.Windows.Forms.ToolStripMenuItem authenticationToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem loginToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem logoutToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem managementToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem accountToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem adminToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem customerProfileToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem airplaneToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem airplaneToolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem airplaneTypeToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem classOfSeatToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem flightScheduleTicketToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem cityToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem routeToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem flightScheduleToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem ticketToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem exitToolStripMenuItem;
    }
}

