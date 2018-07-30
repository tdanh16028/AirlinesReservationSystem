namespace ARSWinForm
{
    partial class FormTicketCE
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            this.lbTicketCode = new System.Windows.Forms.Label();
            this.lbPassengerInfo = new System.Windows.Forms.Label();
            this.lbTicketInfo = new System.Windows.Forms.Label();
            this.lbPassengerName = new System.Windows.Forms.Label();
            this.lbChildrenCount = new System.Windows.Forms.Label();
            this.lbAdultCount = new System.Windows.Forms.Label();
            this.lbSeniorCount = new System.Windows.Forms.Label();
            this.lbSeatClass = new System.Windows.Forms.Label();
            this.lbOrderDate = new System.Windows.Forms.Label();
            this.lbStatus = new System.Windows.Forms.Label();
            this.lbTotalCost = new System.Windows.Forms.Label();
            this.lbFlightSchedules = new System.Windows.Forms.Label();
            this.txtPassengerName = new System.Windows.Forms.TextBox();
            this.numChildrenCount = new System.Windows.Forms.NumericUpDown();
            this.numAdultCount = new System.Windows.Forms.NumericUpDown();
            this.numSeniorCount = new System.Windows.Forms.NumericUpDown();
            this.cboSeatClass = new System.Windows.Forms.ComboBox();
            this.cboStatus = new System.Windows.Forms.ComboBox();
            this.numTotalCost = new System.Windows.Forms.NumericUpDown();
            this.btnSubmit = new System.Windows.Forms.Button();
            this.btnCancel = new System.Windows.Forms.Button();
            this.dgvFlightSchedule = new System.Windows.Forms.DataGridView();
            this.lbTitle = new System.Windows.Forms.Label();
            this.dpOrderDate = new System.Windows.Forms.DateTimePicker();
            this.btnPassengerBrowse = new System.Windows.Forms.Button();
            this.lbFromTo = new System.Windows.Forms.Label();
            this.btnEditFlightSchedule = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.numChildrenCount)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numAdultCount)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numSeniorCount)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numTotalCost)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvFlightSchedule)).BeginInit();
            this.SuspendLayout();
            // 
            // lbTicketCode
            // 
            this.lbTicketCode.Font = new System.Drawing.Font("Segoe UI Semibold", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbTicketCode.Location = new System.Drawing.Point(59, 95);
            this.lbTicketCode.Margin = new System.Windows.Forms.Padding(50, 25, 10, 15);
            this.lbTicketCode.Name = "lbTicketCode";
            this.lbTicketCode.Size = new System.Drawing.Size(375, 29);
            this.lbTicketCode.TabIndex = 0;
            this.lbTicketCode.Text = "Ticket Code : #";
            this.lbTicketCode.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lbPassengerInfo
            // 
            this.lbPassengerInfo.Font = new System.Drawing.Font("Segoe UI Semibold", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbPassengerInfo.Location = new System.Drawing.Point(59, 154);
            this.lbPassengerInfo.Margin = new System.Windows.Forms.Padding(50, 15, 10, 15);
            this.lbPassengerInfo.Name = "lbPassengerInfo";
            this.lbPassengerInfo.Size = new System.Drawing.Size(375, 29);
            this.lbPassengerInfo.TabIndex = 1;
            this.lbPassengerInfo.Text = "Passenger Information";
            this.lbPassengerInfo.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lbTicketInfo
            // 
            this.lbTicketInfo.Font = new System.Drawing.Font("Segoe UI Semibold", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbTicketInfo.Location = new System.Drawing.Point(494, 154);
            this.lbTicketInfo.Margin = new System.Windows.Forms.Padding(50, 15, 10, 15);
            this.lbTicketInfo.Name = "lbTicketInfo";
            this.lbTicketInfo.Size = new System.Drawing.Size(375, 29);
            this.lbTicketInfo.TabIndex = 2;
            this.lbTicketInfo.Text = "Ticket Information";
            this.lbTicketInfo.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lbPassengerName
            // 
            this.lbPassengerName.Font = new System.Drawing.Font("Segoe UI Semibold", 12F, System.Drawing.FontStyle.Bold);
            this.lbPassengerName.Location = new System.Drawing.Point(59, 213);
            this.lbPassengerName.Margin = new System.Windows.Forms.Padding(50, 15, 10, 15);
            this.lbPassengerName.Name = "lbPassengerName";
            this.lbPassengerName.Size = new System.Drawing.Size(135, 29);
            this.lbPassengerName.TabIndex = 3;
            this.lbPassengerName.Text = "Passenger Name";
            this.lbPassengerName.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lbChildrenCount
            // 
            this.lbChildrenCount.Font = new System.Drawing.Font("Segoe UI Semibold", 12F, System.Drawing.FontStyle.Bold);
            this.lbChildrenCount.Location = new System.Drawing.Point(59, 272);
            this.lbChildrenCount.Margin = new System.Windows.Forms.Padding(50, 15, 10, 15);
            this.lbChildrenCount.Name = "lbChildrenCount";
            this.lbChildrenCount.Size = new System.Drawing.Size(135, 29);
            this.lbChildrenCount.TabIndex = 4;
            this.lbChildrenCount.Text = "Children Count";
            this.lbChildrenCount.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lbAdultCount
            // 
            this.lbAdultCount.Font = new System.Drawing.Font("Segoe UI Semibold", 12F, System.Drawing.FontStyle.Bold);
            this.lbAdultCount.Location = new System.Drawing.Point(59, 331);
            this.lbAdultCount.Margin = new System.Windows.Forms.Padding(50, 15, 10, 15);
            this.lbAdultCount.Name = "lbAdultCount";
            this.lbAdultCount.Size = new System.Drawing.Size(135, 29);
            this.lbAdultCount.TabIndex = 5;
            this.lbAdultCount.Text = "Adult Count";
            this.lbAdultCount.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lbSeniorCount
            // 
            this.lbSeniorCount.Font = new System.Drawing.Font("Segoe UI Semibold", 12F, System.Drawing.FontStyle.Bold);
            this.lbSeniorCount.Location = new System.Drawing.Point(59, 390);
            this.lbSeniorCount.Margin = new System.Windows.Forms.Padding(50, 15, 10, 15);
            this.lbSeniorCount.Name = "lbSeniorCount";
            this.lbSeniorCount.Size = new System.Drawing.Size(135, 29);
            this.lbSeniorCount.TabIndex = 6;
            this.lbSeniorCount.Text = "Senior Count";
            this.lbSeniorCount.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lbSeatClass
            // 
            this.lbSeatClass.Font = new System.Drawing.Font("Segoe UI Semibold", 12F, System.Drawing.FontStyle.Bold);
            this.lbSeatClass.Location = new System.Drawing.Point(494, 213);
            this.lbSeatClass.Margin = new System.Windows.Forms.Padding(50, 15, 10, 15);
            this.lbSeatClass.Name = "lbSeatClass";
            this.lbSeatClass.Size = new System.Drawing.Size(135, 29);
            this.lbSeatClass.TabIndex = 7;
            this.lbSeatClass.Text = "Class";
            this.lbSeatClass.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lbOrderDate
            // 
            this.lbOrderDate.Font = new System.Drawing.Font("Segoe UI Semibold", 12F, System.Drawing.FontStyle.Bold);
            this.lbOrderDate.Location = new System.Drawing.Point(494, 272);
            this.lbOrderDate.Margin = new System.Windows.Forms.Padding(50, 15, 10, 15);
            this.lbOrderDate.Name = "lbOrderDate";
            this.lbOrderDate.Size = new System.Drawing.Size(135, 29);
            this.lbOrderDate.TabIndex = 8;
            this.lbOrderDate.Text = "Order Date";
            this.lbOrderDate.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lbStatus
            // 
            this.lbStatus.Font = new System.Drawing.Font("Segoe UI Semibold", 12F, System.Drawing.FontStyle.Bold);
            this.lbStatus.Location = new System.Drawing.Point(494, 331);
            this.lbStatus.Margin = new System.Windows.Forms.Padding(50, 15, 10, 15);
            this.lbStatus.Name = "lbStatus";
            this.lbStatus.Size = new System.Drawing.Size(135, 29);
            this.lbStatus.TabIndex = 9;
            this.lbStatus.Text = "Status";
            this.lbStatus.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lbTotalCost
            // 
            this.lbTotalCost.Font = new System.Drawing.Font("Segoe UI Semibold", 12F, System.Drawing.FontStyle.Bold);
            this.lbTotalCost.Location = new System.Drawing.Point(494, 390);
            this.lbTotalCost.Margin = new System.Windows.Forms.Padding(50, 15, 10, 15);
            this.lbTotalCost.Name = "lbTotalCost";
            this.lbTotalCost.Size = new System.Drawing.Size(135, 29);
            this.lbTotalCost.TabIndex = 10;
            this.lbTotalCost.Text = "Total Cost";
            this.lbTotalCost.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lbFlightSchedules
            // 
            this.lbFlightSchedules.Font = new System.Drawing.Font("Segoe UI Semibold", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbFlightSchedules.Location = new System.Drawing.Point(59, 478);
            this.lbFlightSchedules.Margin = new System.Windows.Forms.Padding(50, 15, 10, 15);
            this.lbFlightSchedules.Name = "lbFlightSchedules";
            this.lbFlightSchedules.Size = new System.Drawing.Size(165, 29);
            this.lbFlightSchedules.TabIndex = 11;
            this.lbFlightSchedules.Text = "Flight Schedule(s)";
            this.lbFlightSchedules.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // txtPassengerName
            // 
            this.txtPassengerName.BackColor = System.Drawing.Color.White;
            this.txtPassengerName.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtPassengerName.Enabled = false;
            this.txtPassengerName.Location = new System.Drawing.Point(214, 215);
            this.txtPassengerName.Margin = new System.Windows.Forms.Padding(10, 15, 10, 15);
            this.txtPassengerName.Name = "txtPassengerName";
            this.txtPassengerName.Size = new System.Drawing.Size(192, 29);
            this.txtPassengerName.TabIndex = 12;
            // 
            // numChildrenCount
            // 
            this.numChildrenCount.BackColor = System.Drawing.Color.White;
            this.numChildrenCount.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.numChildrenCount.Enabled = false;
            this.numChildrenCount.Location = new System.Drawing.Point(214, 274);
            this.numChildrenCount.Margin = new System.Windows.Forms.Padding(10, 15, 10, 15);
            this.numChildrenCount.Maximum = new decimal(new int[] {
            10,
            0,
            0,
            0});
            this.numChildrenCount.Name = "numChildrenCount";
            this.numChildrenCount.Size = new System.Drawing.Size(220, 29);
            this.numChildrenCount.TabIndex = 20;
            this.numChildrenCount.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.numChildrenCount.ThousandsSeparator = true;
            // 
            // numAdultCount
            // 
            this.numAdultCount.BackColor = System.Drawing.Color.White;
            this.numAdultCount.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.numAdultCount.Enabled = false;
            this.numAdultCount.Location = new System.Drawing.Point(214, 333);
            this.numAdultCount.Margin = new System.Windows.Forms.Padding(10, 15, 10, 15);
            this.numAdultCount.Maximum = new decimal(new int[] {
            10,
            0,
            0,
            0});
            this.numAdultCount.Name = "numAdultCount";
            this.numAdultCount.Size = new System.Drawing.Size(220, 29);
            this.numAdultCount.TabIndex = 21;
            this.numAdultCount.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.numAdultCount.ThousandsSeparator = true;
            // 
            // numSeniorCount
            // 
            this.numSeniorCount.BackColor = System.Drawing.Color.White;
            this.numSeniorCount.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.numSeniorCount.Enabled = false;
            this.numSeniorCount.Location = new System.Drawing.Point(214, 392);
            this.numSeniorCount.Margin = new System.Windows.Forms.Padding(10, 15, 10, 15);
            this.numSeniorCount.Maximum = new decimal(new int[] {
            10,
            0,
            0,
            0});
            this.numSeniorCount.Name = "numSeniorCount";
            this.numSeniorCount.Size = new System.Drawing.Size(220, 29);
            this.numSeniorCount.TabIndex = 22;
            this.numSeniorCount.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.numSeniorCount.ThousandsSeparator = true;
            // 
            // cboSeatClass
            // 
            this.cboSeatClass.BackColor = System.Drawing.Color.White;
            this.cboSeatClass.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboSeatClass.Enabled = false;
            this.cboSeatClass.FormattingEnabled = true;
            this.cboSeatClass.Location = new System.Drawing.Point(649, 214);
            this.cboSeatClass.Margin = new System.Windows.Forms.Padding(10, 15, 10, 15);
            this.cboSeatClass.Name = "cboSeatClass";
            this.cboSeatClass.Size = new System.Drawing.Size(220, 29);
            this.cboSeatClass.TabIndex = 23;
            // 
            // cboStatus
            // 
            this.cboStatus.BackColor = System.Drawing.Color.White;
            this.cboStatus.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboStatus.FormattingEnabled = true;
            this.cboStatus.Items.AddRange(new object[] {
            "Blocked",
            "Reserved",
            "Cancelled"});
            this.cboStatus.Location = new System.Drawing.Point(649, 332);
            this.cboStatus.Margin = new System.Windows.Forms.Padding(10, 15, 10, 15);
            this.cboStatus.Name = "cboStatus";
            this.cboStatus.Size = new System.Drawing.Size(220, 29);
            this.cboStatus.TabIndex = 25;
            // 
            // numTotalCost
            // 
            this.numTotalCost.BackColor = System.Drawing.Color.White;
            this.numTotalCost.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.numTotalCost.Enabled = false;
            this.numTotalCost.Location = new System.Drawing.Point(649, 392);
            this.numTotalCost.Margin = new System.Windows.Forms.Padding(10, 15, 10, 15);
            this.numTotalCost.Maximum = new decimal(new int[] {
            99999999,
            0,
            0,
            0});
            this.numTotalCost.Name = "numTotalCost";
            this.numTotalCost.Size = new System.Drawing.Size(220, 29);
            this.numTotalCost.TabIndex = 26;
            this.numTotalCost.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.numTotalCost.ThousandsSeparator = true;
            // 
            // btnSubmit
            // 
            this.btnSubmit.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(150)))), ((int)(((byte)(136)))));
            this.btnSubmit.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(150)))), ((int)(((byte)(136)))));
            this.btnSubmit.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnSubmit.ForeColor = System.Drawing.Color.White;
            this.btnSubmit.Location = new System.Drawing.Point(609, 471);
            this.btnSubmit.Margin = new System.Windows.Forms.Padding(10, 35, 10, 10);
            this.btnSubmit.Name = "btnSubmit";
            this.btnSubmit.Size = new System.Drawing.Size(120, 45);
            this.btnSubmit.TabIndex = 27;
            this.btnSubmit.Text = "Submit";
            this.btnSubmit.UseVisualStyleBackColor = false;
            this.btnSubmit.Click += new System.EventHandler(this.btnSubmit_Click);
            // 
            // btnCancel
            // 
            this.btnCancel.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(229)))), ((int)(((byte)(57)))), ((int)(((byte)(53)))));
            this.btnCancel.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(229)))), ((int)(((byte)(57)))), ((int)(((byte)(53)))));
            this.btnCancel.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnCancel.ForeColor = System.Drawing.Color.White;
            this.btnCancel.Location = new System.Drawing.Point(749, 471);
            this.btnCancel.Margin = new System.Windows.Forms.Padding(10, 35, 10, 10);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(120, 45);
            this.btnCancel.TabIndex = 28;
            this.btnCancel.Text = "Cancel";
            this.btnCancel.UseVisualStyleBackColor = false;
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // dgvFlightSchedule
            // 
            this.dgvFlightSchedule.AllowUserToAddRows = false;
            this.dgvFlightSchedule.AllowUserToDeleteRows = false;
            this.dgvFlightSchedule.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells;
            this.dgvFlightSchedule.BackgroundColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(247)))), ((int)(((byte)(247)))));
            this.dgvFlightSchedule.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.dgvFlightSchedule.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.SingleHorizontal;
            this.dgvFlightSchedule.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(247)))), ((int)(((byte)(247)))));
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Segoe UI", 12F);
            dataGridViewCellStyle1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            dataGridViewCellStyle1.Padding = new System.Windows.Forms.Padding(5, 0, 0, 0);
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.Color.Black;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgvFlightSchedule.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.dgvFlightSchedule.ColumnHeadersHeight = 40;
            this.dgvFlightSchedule.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.Color.White;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Segoe UI", 12F);
            dataGridViewCellStyle2.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            dataGridViewCellStyle2.Padding = new System.Windows.Forms.Padding(5);
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(150)))), ((int)(((byte)(139)))));
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgvFlightSchedule.DefaultCellStyle = dataGridViewCellStyle2;
            this.dgvFlightSchedule.GridColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.dgvFlightSchedule.Location = new System.Drawing.Point(0, 530);
            this.dgvFlightSchedule.Margin = new System.Windows.Forms.Padding(4);
            this.dgvFlightSchedule.MultiSelect = false;
            this.dgvFlightSchedule.Name = "dgvFlightSchedule";
            this.dgvFlightSchedule.ReadOnly = true;
            this.dgvFlightSchedule.RowTemplate.DefaultCellStyle.BackColor = System.Drawing.Color.White;
            this.dgvFlightSchedule.RowTemplate.DefaultCellStyle.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.dgvFlightSchedule.RowTemplate.DefaultCellStyle.Padding = new System.Windows.Forms.Padding(5);
            this.dgvFlightSchedule.RowTemplate.DefaultCellStyle.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(150)))), ((int)(((byte)(139)))));
            this.dgvFlightSchedule.RowTemplate.DefaultCellStyle.SelectionForeColor = System.Drawing.Color.White;
            this.dgvFlightSchedule.RowTemplate.DefaultCellStyle.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgvFlightSchedule.RowTemplate.Height = 40;
            this.dgvFlightSchedule.RowTemplate.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.dgvFlightSchedule.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvFlightSchedule.Size = new System.Drawing.Size(940, 200);
            this.dgvFlightSchedule.TabIndex = 29;
            // 
            // lbTitle
            // 
            this.lbTitle.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lbTitle.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(150)))), ((int)(((byte)(136)))));
            this.lbTitle.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.lbTitle.Font = new System.Drawing.Font("Segoe UI", 15.75F, System.Drawing.FontStyle.Bold);
            this.lbTitle.ForeColor = System.Drawing.Color.White;
            this.lbTitle.Location = new System.Drawing.Point(0, 0);
            this.lbTitle.Margin = new System.Windows.Forms.Padding(0);
            this.lbTitle.Name = "lbTitle";
            this.lbTitle.Padding = new System.Windows.Forms.Padding(55, 0, 0, 0);
            this.lbTitle.Size = new System.Drawing.Size(940, 70);
            this.lbTitle.TabIndex = 30;
            this.lbTitle.Text = "TICKET";
            this.lbTitle.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // dpOrderDate
            // 
            this.dpOrderDate.CalendarForeColor = System.Drawing.Color.Black;
            this.dpOrderDate.CalendarMonthBackground = System.Drawing.Color.White;
            this.dpOrderDate.CalendarTitleBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(153)))), ((int)(((byte)(139)))));
            this.dpOrderDate.CalendarTitleForeColor = System.Drawing.Color.White;
            this.dpOrderDate.CustomFormat = "dd/MM/yyyy";
            this.dpOrderDate.Enabled = false;
            this.dpOrderDate.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dpOrderDate.Location = new System.Drawing.Point(649, 273);
            this.dpOrderDate.Margin = new System.Windows.Forms.Padding(10, 15, 10, 15);
            this.dpOrderDate.Name = "dpOrderDate";
            this.dpOrderDate.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.dpOrderDate.Size = new System.Drawing.Size(220, 29);
            this.dpOrderDate.TabIndex = 24;
            // 
            // btnPassengerBrowse
            // 
            this.btnPassengerBrowse.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnPassengerBrowse.FlatAppearance.BorderColor = System.Drawing.Color.Black;
            this.btnPassengerBrowse.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnPassengerBrowse.Location = new System.Drawing.Point(405, 215);
            this.btnPassengerBrowse.Margin = new System.Windows.Forms.Padding(0);
            this.btnPassengerBrowse.Name = "btnPassengerBrowse";
            this.btnPassengerBrowse.Size = new System.Drawing.Size(29, 29);
            this.btnPassengerBrowse.TabIndex = 31;
            this.btnPassengerBrowse.Text = "...";
            this.btnPassengerBrowse.UseVisualStyleBackColor = true;
            // 
            // lbFromTo
            // 
            this.lbFromTo.Font = new System.Drawing.Font("Segoe UI Semibold", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbFromTo.Location = new System.Drawing.Point(493, 95);
            this.lbFromTo.Margin = new System.Windows.Forms.Padding(50, 25, 10, 15);
            this.lbFromTo.Name = "lbFromTo";
            this.lbFromTo.Size = new System.Drawing.Size(375, 29);
            this.lbFromTo.TabIndex = 0;
            this.lbFromTo.Text = "From ... - to ...";
            this.lbFromTo.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // btnEditFlightSchedule
            // 
            this.btnEditFlightSchedule.BackColor = System.Drawing.Color.White;
            this.btnEditFlightSchedule.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(150)))), ((int)(((byte)(136)))));
            this.btnEditFlightSchedule.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnEditFlightSchedule.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(150)))), ((int)(((byte)(136)))));
            this.btnEditFlightSchedule.Location = new System.Drawing.Point(244, 471);
            this.btnEditFlightSchedule.Margin = new System.Windows.Forms.Padding(10, 35, 10, 10);
            this.btnEditFlightSchedule.Name = "btnEditFlightSchedule";
            this.btnEditFlightSchedule.Size = new System.Drawing.Size(120, 45);
            this.btnEditFlightSchedule.TabIndex = 32;
            this.btnEditFlightSchedule.Text = "Edit Route";
            this.btnEditFlightSchedule.UseVisualStyleBackColor = false;
            // 
            // FormTicketCE
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 21F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(941, 732);
            this.Controls.Add(this.btnEditFlightSchedule);
            this.Controls.Add(this.btnPassengerBrowse);
            this.Controls.Add(this.lbTitle);
            this.Controls.Add(this.dgvFlightSchedule);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.btnSubmit);
            this.Controls.Add(this.numTotalCost);
            this.Controls.Add(this.cboStatus);
            this.Controls.Add(this.dpOrderDate);
            this.Controls.Add(this.cboSeatClass);
            this.Controls.Add(this.numSeniorCount);
            this.Controls.Add(this.numAdultCount);
            this.Controls.Add(this.numChildrenCount);
            this.Controls.Add(this.txtPassengerName);
            this.Controls.Add(this.lbFlightSchedules);
            this.Controls.Add(this.lbTotalCost);
            this.Controls.Add(this.lbStatus);
            this.Controls.Add(this.lbOrderDate);
            this.Controls.Add(this.lbSeatClass);
            this.Controls.Add(this.lbSeniorCount);
            this.Controls.Add(this.lbAdultCount);
            this.Controls.Add(this.lbChildrenCount);
            this.Controls.Add(this.lbPassengerName);
            this.Controls.Add(this.lbTicketInfo);
            this.Controls.Add(this.lbPassengerInfo);
            this.Controls.Add(this.lbFromTo);
            this.Controls.Add(this.lbTicketCode);
            this.Font = new System.Drawing.Font("Segoe UI", 12F);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.MaximizeBox = false;
            this.Name = "FormTicketCE";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Ticket";
            this.Load += new System.EventHandler(this.FormTicketCE_Load);
            ((System.ComponentModel.ISupportInitialize)(this.numChildrenCount)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numAdultCount)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numSeniorCount)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numTotalCost)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvFlightSchedule)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lbTicketCode;
        private System.Windows.Forms.Label lbPassengerInfo;
        private System.Windows.Forms.Label lbTicketInfo;
        private System.Windows.Forms.Label lbPassengerName;
        private System.Windows.Forms.Label lbChildrenCount;
        private System.Windows.Forms.Label lbAdultCount;
        private System.Windows.Forms.Label lbSeniorCount;
        private System.Windows.Forms.Label lbSeatClass;
        private System.Windows.Forms.Label lbOrderDate;
        private System.Windows.Forms.Label lbStatus;
        private System.Windows.Forms.Label lbTotalCost;
        private System.Windows.Forms.Label lbFlightSchedules;
        private System.Windows.Forms.TextBox txtPassengerName;
        private System.Windows.Forms.NumericUpDown numChildrenCount;
        private System.Windows.Forms.NumericUpDown numAdultCount;
        private System.Windows.Forms.NumericUpDown numSeniorCount;
        private System.Windows.Forms.ComboBox cboSeatClass;
        private System.Windows.Forms.ComboBox cboStatus;
        private System.Windows.Forms.NumericUpDown numTotalCost;
        private System.Windows.Forms.Button btnSubmit;
        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.DataGridView dgvFlightSchedule;
        private System.Windows.Forms.Label lbTitle;
        private System.Windows.Forms.DateTimePicker dpOrderDate;
        private System.Windows.Forms.Button btnPassengerBrowse;
        private System.Windows.Forms.Label lbFromTo;
        private System.Windows.Forms.Button btnEditFlightSchedule;
    }
}