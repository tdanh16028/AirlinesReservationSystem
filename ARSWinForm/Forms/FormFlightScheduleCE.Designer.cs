namespace ARSWinForm
{
    partial class FormFlightScheduleCE
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
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.rbtnActive = new System.Windows.Forms.RadioButton();
            this.rbtnInActive = new System.Windows.Forms.RadioButton();
            this.cboAirplane = new System.Windows.Forms.ComboBox();
            this.cboRoute = new System.Windows.Forms.ComboBox();
            this.btnSubmit = new System.Windows.Forms.Button();
            this.btnCancel = new System.Windows.Forms.Button();
            this.dateTimePicker1 = new System.Windows.Forms.DateTimePicker();
            this.label13 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Segoe UI Semibold", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(18, 98);
            this.label1.Margin = new System.Windows.Forms.Padding(50, 15, 10, 15);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(87, 28);
            this.label1.TabIndex = 0;
            this.label1.Text = "Airplane";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Segoe UI Semibold", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(18, 156);
            this.label2.Margin = new System.Windows.Forms.Padding(50, 15, 10, 15);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(65, 28);
            this.label2.TabIndex = 1;
            this.label2.Text = "Route";
            this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Segoe UI Semibold", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(18, 221);
            this.label3.Margin = new System.Windows.Forms.Padding(50, 15, 10, 15);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(152, 28);
            this.label3.TabIndex = 2;
            this.label3.Text = "Departure Date";
            this.label3.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // rbtnActive
            // 
            this.rbtnActive.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.rbtnActive.Location = new System.Drawing.Point(120, 280);
            this.rbtnActive.Margin = new System.Windows.Forms.Padding(10, 15, 10, 15);
            this.rbtnActive.Name = "rbtnActive";
            this.rbtnActive.Size = new System.Drawing.Size(103, 29);
            this.rbtnActive.TabIndex = 4;
            this.rbtnActive.TabStop = true;
            this.rbtnActive.Text = "Active";
            this.rbtnActive.UseVisualStyleBackColor = true;
            // 
            // rbtnInActive
            // 
            this.rbtnInActive.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.rbtnInActive.Location = new System.Drawing.Point(243, 280);
            this.rbtnInActive.Margin = new System.Windows.Forms.Padding(10, 15, 10, 15);
            this.rbtnInActive.Name = "rbtnInActive";
            this.rbtnInActive.Size = new System.Drawing.Size(103, 29);
            this.rbtnInActive.TabIndex = 5;
            this.rbtnInActive.TabStop = true;
            this.rbtnInActive.Text = "InActive";
            this.rbtnInActive.UseVisualStyleBackColor = true;
            // 
            // cboAirplane
            // 
            this.cboAirplane.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboAirplane.FormattingEnabled = true;
            this.cboAirplane.Location = new System.Drawing.Point(145, 95);
            this.cboAirplane.Margin = new System.Windows.Forms.Padding(10, 15, 10, 15);
            this.cboAirplane.Name = "cboAirplane";
            this.cboAirplane.Size = new System.Drawing.Size(290, 36);
            this.cboAirplane.TabIndex = 6;
            this.cboAirplane.Format += new System.Windows.Forms.ListControlConvertEventHandler(this.cboAirplane_Format);
            // 
            // cboRoute
            // 
            this.cboRoute.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboRoute.FormattingEnabled = true;
            this.cboRoute.Location = new System.Drawing.Point(145, 153);
            this.cboRoute.Margin = new System.Windows.Forms.Padding(10, 15, 10, 15);
            this.cboRoute.Name = "cboRoute";
            this.cboRoute.Size = new System.Drawing.Size(290, 36);
            this.cboRoute.TabIndex = 7;
            this.cboRoute.Format += new System.Windows.Forms.ListControlConvertEventHandler(this.cboRoute_Format);
            // 
            // btnSubmit
            // 
            this.btnSubmit.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(150)))), ((int)(((byte)(136)))));
            this.btnSubmit.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnSubmit.ForeColor = System.Drawing.Color.White;
            this.btnSubmit.Location = new System.Drawing.Point(120, 334);
            this.btnSubmit.Margin = new System.Windows.Forms.Padding(10);
            this.btnSubmit.Name = "btnSubmit";
            this.btnSubmit.Size = new System.Drawing.Size(103, 40);
            this.btnSubmit.TabIndex = 8;
            this.btnSubmit.Text = "Submit";
            this.btnSubmit.UseVisualStyleBackColor = false;
            this.btnSubmit.Click += new System.EventHandler(this.btnSubmit_Click);
            // 
            // btnCancel
            // 
            this.btnCancel.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(229)))), ((int)(((byte)(57)))), ((int)(((byte)(13)))));
            this.btnCancel.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnCancel.ForeColor = System.Drawing.Color.White;
            this.btnCancel.Location = new System.Drawing.Point(243, 334);
            this.btnCancel.Margin = new System.Windows.Forms.Padding(10);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(103, 40);
            this.btnCancel.TabIndex = 9;
            this.btnCancel.Text = "Cancel";
            this.btnCancel.UseVisualStyleBackColor = false;
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // dateTimePicker1
            // 
            this.dateTimePicker1.CustomFormat = "dd/MM/yyyy";
            this.dateTimePicker1.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dateTimePicker1.Location = new System.Drawing.Point(208, 216);
            this.dateTimePicker1.Margin = new System.Windows.Forms.Padding(10, 15, 10, 15);
            this.dateTimePicker1.Name = "dateTimePicker1";
            this.dateTimePicker1.Size = new System.Drawing.Size(227, 34);
            this.dateTimePicker1.TabIndex = 10;
            // 
            // label13
            // 
            this.label13.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.label13.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(150)))), ((int)(((byte)(136)))));
            this.label13.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.label13.Font = new System.Drawing.Font("Segoe UI", 16.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label13.ForeColor = System.Drawing.Color.White;
            this.label13.Location = new System.Drawing.Point(-1, -1);
            this.label13.Margin = new System.Windows.Forms.Padding(0);
            this.label13.Name = "label13";
            this.label13.Padding = new System.Windows.Forms.Padding(50, 0, 0, 0);
            this.label13.Size = new System.Drawing.Size(455, 84);
            this.label13.TabIndex = 29;
            this.label13.Text = "FlightScheduleCE";
            this.label13.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // FormFlightScheduleCE
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(11F, 28F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(454, 390);
            this.Controls.Add(this.label13);
            this.Controls.Add(this.dateTimePicker1);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.btnSubmit);
            this.Controls.Add(this.cboRoute);
            this.Controls.Add(this.cboAirplane);
            this.Controls.Add(this.rbtnInActive);
            this.Controls.Add(this.rbtnActive);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.Name = "FormFlightScheduleCE";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "CE_FlightSchedule";
            this.Load += new System.EventHandler(this.FormFlightScheduleCE_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.RadioButton rbtnActive;
        private System.Windows.Forms.RadioButton rbtnInActive;
        private System.Windows.Forms.ComboBox cboAirplane;
        private System.Windows.Forms.ComboBox cboRoute;
        private System.Windows.Forms.Button btnSubmit;
        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.DateTimePicker dateTimePicker1;
        private System.Windows.Forms.Label label13;
    }
}