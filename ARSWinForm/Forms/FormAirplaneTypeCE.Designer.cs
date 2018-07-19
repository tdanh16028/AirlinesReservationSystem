namespace ARSWinForm
{
    partial class FormAirplaneTypeCE
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
            this.label2 = new System.Windows.Forms.Label();
            this.txtName = new System.Windows.Forms.TextBox();
            this.btnSubmit = new System.Windows.Forms.Button();
            this.btnCancel = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.numFirstClassSeat = new System.Windows.Forms.NumericUpDown();
            this.numBusinessClassSeat = new System.Windows.Forms.NumericUpDown();
            this.numClubClassSeat = new System.Windows.Forms.NumericUpDown();
            this.cboActive = new System.Windows.Forms.RadioButton();
            this.cboInActive = new System.Windows.Forms.RadioButton();
            this.label5 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.numFirstClassSeat)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numBusinessClassSeat)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numClubClassSeat)).BeginInit();
            this.SuspendLayout();
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Segoe UI Semibold", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(13, 102);
            this.label2.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(66, 28);
            this.label2.TabIndex = 1;
            this.label2.Text = "Name";
            this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // txtName
            // 
            this.txtName.Location = new System.Drawing.Point(180, 99);
            this.txtName.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.txtName.Name = "txtName";
            this.txtName.Size = new System.Drawing.Size(254, 34);
            this.txtName.TabIndex = 4;
            // 
            // btnSubmit
            // 
            this.btnSubmit.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(150)))), ((int)(((byte)(136)))));
            this.btnSubmit.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnSubmit.ForeColor = System.Drawing.Color.White;
            this.btnSubmit.Location = new System.Drawing.Point(98, 635);
            this.btnSubmit.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.btnSubmit.Name = "btnSubmit";
            this.btnSubmit.Size = new System.Drawing.Size(103, 40);
            this.btnSubmit.TabIndex = 7;
            this.btnSubmit.Text = "Submit";
            this.btnSubmit.UseVisualStyleBackColor = false;
            this.btnSubmit.Click += new System.EventHandler(this.btnSubmit_Click);
            // 
            // btnCancel
            // 
            this.btnCancel.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(229)))), ((int)(((byte)(57)))), ((int)(((byte)(13)))));
            this.btnCancel.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnCancel.ForeColor = System.Drawing.Color.White;
            this.btnCancel.Location = new System.Drawing.Point(242, 635);
            this.btnCancel.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(103, 40);
            this.btnCancel.TabIndex = 8;
            this.btnCancel.Text = "Cancel";
            this.btnCancel.UseVisualStyleBackColor = false;
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Segoe UI Semibold", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(13, 204);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(101, 28);
            this.label1.TabIndex = 9;
            this.label1.Text = "First Class";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Segoe UI Semibold", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(13, 329);
            this.label3.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(142, 28);
            this.label3.TabIndex = 10;
            this.label3.Text = "Business Class";
            this.label3.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Segoe UI Semibold", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(13, 448);
            this.label4.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(104, 28);
            this.label4.TabIndex = 11;
            this.label4.Text = "Club Class";
            this.label4.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // numFirstClassSeat
            // 
            this.numFirstClassSeat.Font = new System.Drawing.Font("Segoe UI Semibold", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.numFirstClassSeat.Location = new System.Drawing.Point(180, 202);
            this.numFirstClassSeat.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.numFirstClassSeat.Name = "numFirstClassSeat";
            this.numFirstClassSeat.Size = new System.Drawing.Size(214, 34);
            this.numFirstClassSeat.TabIndex = 12;
            // 
            // numBusinessClassSeat
            // 
            this.numBusinessClassSeat.Location = new System.Drawing.Point(180, 327);
            this.numBusinessClassSeat.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.numBusinessClassSeat.Name = "numBusinessClassSeat";
            this.numBusinessClassSeat.Size = new System.Drawing.Size(214, 34);
            this.numBusinessClassSeat.TabIndex = 13;
            // 
            // numClubClassSeat
            // 
            this.numClubClassSeat.Location = new System.Drawing.Point(180, 446);
            this.numClubClassSeat.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.numClubClassSeat.Name = "numClubClassSeat";
            this.numClubClassSeat.Size = new System.Drawing.Size(214, 34);
            this.numClubClassSeat.TabIndex = 14;
            // 
            // cboActive
            // 
            this.cboActive.AutoSize = true;
            this.cboActive.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.cboActive.Location = new System.Drawing.Point(98, 544);
            this.cboActive.Margin = new System.Windows.Forms.Padding(10, 15, 10, 15);
            this.cboActive.Name = "cboActive";
            this.cboActive.Size = new System.Drawing.Size(86, 32);
            this.cboActive.TabIndex = 15;
            this.cboActive.TabStop = true;
            this.cboActive.Text = "Active";
            this.cboActive.UseVisualStyleBackColor = true;
            // 
            // cboInActive
            // 
            this.cboInActive.AutoSize = true;
            this.cboInActive.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.cboInActive.Location = new System.Drawing.Point(242, 544);
            this.cboInActive.Margin = new System.Windows.Forms.Padding(10, 15, 10, 15);
            this.cboInActive.Name = "cboInActive";
            this.cboInActive.Size = new System.Drawing.Size(102, 32);
            this.cboInActive.TabIndex = 16;
            this.cboInActive.TabStop = true;
            this.cboInActive.Text = "InActive";
            this.cboInActive.UseVisualStyleBackColor = true;
            // 
            // label5
            // 
            this.label5.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.label5.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(150)))), ((int)(((byte)(136)))));
            this.label5.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.label5.Font = new System.Drawing.Font("Segoe UI", 16.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.ForeColor = System.Drawing.Color.White;
            this.label5.Location = new System.Drawing.Point(-1, -2);
            this.label5.Margin = new System.Windows.Forms.Padding(0);
            this.label5.Name = "label5";
            this.label5.Padding = new System.Windows.Forms.Padding(50, 0, 0, 0);
            this.label5.Size = new System.Drawing.Size(454, 79);
            this.label5.TabIndex = 17;
            this.label5.Text = "AirplaneTypeCE";
            this.label5.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // FormAirplaneTypeCE
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(11F, 28F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(452, 737);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.cboInActive);
            this.Controls.Add(this.cboActive);
            this.Controls.Add(this.numClubClassSeat);
            this.Controls.Add(this.numBusinessClassSeat);
            this.Controls.Add(this.numFirstClassSeat);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.btnSubmit);
            this.Controls.Add(this.txtName);
            this.Controls.Add(this.label2);
            this.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.Name = "FormAirplaneTypeCE";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "AirplaneTypeCE";
            this.Load += new System.EventHandler(this.Create_AirplaneType_Load);
            ((System.ComponentModel.ISupportInitialize)(this.numFirstClassSeat)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numBusinessClassSeat)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numClubClassSeat)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtName;
        private System.Windows.Forms.Button btnSubmit;
        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.NumericUpDown numFirstClassSeat;
        private System.Windows.Forms.NumericUpDown numBusinessClassSeat;
        private System.Windows.Forms.NumericUpDown numClubClassSeat;
        private System.Windows.Forms.RadioButton cboActive;
        private System.Windows.Forms.RadioButton cboInActive;
        private System.Windows.Forms.Label label5;
    }
}