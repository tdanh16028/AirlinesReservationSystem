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
            this.rbtnActive = new System.Windows.Forms.RadioButton();
            this.rbtnInActive = new System.Windows.Forms.RadioButton();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.numFirstClassSeat)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numBusinessClassSeat)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numClubClassSeat)).BeginInit();
            this.SuspendLayout();
            // 
            // label2
            // 
            this.label2.Font = new System.Drawing.Font("Segoe UI Semibold", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(59, 98);
            this.label2.Margin = new System.Windows.Forms.Padding(50, 15, 10, 15);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(120, 29);
            this.label2.TabIndex = 1;
            this.label2.Text = "Name";
            this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // txtName
            // 
            this.txtName.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtName.Location = new System.Drawing.Point(199, 100);
            this.txtName.Margin = new System.Windows.Forms.Padding(10, 15, 10, 15);
            this.txtName.Name = "txtName";
            this.txtName.Size = new System.Drawing.Size(220, 29);
            this.txtName.TabIndex = 4;
            // 
            // btnSubmit
            // 
            this.btnSubmit.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(150)))), ((int)(((byte)(136)))));
            this.btnSubmit.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnSubmit.ForeColor = System.Drawing.Color.White;
            this.btnSubmit.Location = new System.Drawing.Point(116, 388);
            this.btnSubmit.Margin = new System.Windows.Forms.Padding(10);
            this.btnSubmit.Name = "btnSubmit";
            this.btnSubmit.Size = new System.Drawing.Size(120, 45);
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
            this.btnCancel.Location = new System.Drawing.Point(256, 388);
            this.btnCancel.Margin = new System.Windows.Forms.Padding(10);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(120, 45);
            this.btnCancel.TabIndex = 8;
            this.btnCancel.Text = "Cancel";
            this.btnCancel.UseVisualStyleBackColor = false;
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // label1
            // 
            this.label1.Font = new System.Drawing.Font("Segoe UI Semibold", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(59, 157);
            this.label1.Margin = new System.Windows.Forms.Padding(50, 15, 10, 15);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(120, 29);
            this.label1.TabIndex = 9;
            this.label1.Text = "First Class";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label3
            // 
            this.label3.Font = new System.Drawing.Font("Segoe UI Semibold", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(59, 216);
            this.label3.Margin = new System.Windows.Forms.Padding(50, 15, 10, 15);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(120, 29);
            this.label3.TabIndex = 10;
            this.label3.Text = "Business Class";
            this.label3.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label4
            // 
            this.label4.Font = new System.Drawing.Font("Segoe UI Semibold", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(59, 275);
            this.label4.Margin = new System.Windows.Forms.Padding(50, 15, 10, 15);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(120, 29);
            this.label4.TabIndex = 11;
            this.label4.Text = "Club Class";
            this.label4.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // numFirstClassSeat
            // 
            this.numFirstClassSeat.BackColor = System.Drawing.Color.White;
            this.numFirstClassSeat.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.numFirstClassSeat.Font = new System.Drawing.Font("Segoe UI Semibold", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.numFirstClassSeat.Location = new System.Drawing.Point(199, 159);
            this.numFirstClassSeat.Margin = new System.Windows.Forms.Padding(10, 15, 10, 15);
            this.numFirstClassSeat.Maximum = new decimal(new int[] {
            500,
            0,
            0,
            0});
            this.numFirstClassSeat.Name = "numFirstClassSeat";
            this.numFirstClassSeat.Size = new System.Drawing.Size(220, 29);
            this.numFirstClassSeat.TabIndex = 12;
            this.numFirstClassSeat.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // numBusinessClassSeat
            // 
            this.numBusinessClassSeat.BackColor = System.Drawing.Color.White;
            this.numBusinessClassSeat.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.numBusinessClassSeat.Location = new System.Drawing.Point(199, 218);
            this.numBusinessClassSeat.Margin = new System.Windows.Forms.Padding(10, 15, 10, 15);
            this.numBusinessClassSeat.Maximum = new decimal(new int[] {
            500,
            0,
            0,
            0});
            this.numBusinessClassSeat.Name = "numBusinessClassSeat";
            this.numBusinessClassSeat.Size = new System.Drawing.Size(220, 29);
            this.numBusinessClassSeat.TabIndex = 13;
            this.numBusinessClassSeat.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // numClubClassSeat
            // 
            this.numClubClassSeat.BackColor = System.Drawing.Color.White;
            this.numClubClassSeat.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.numClubClassSeat.Location = new System.Drawing.Point(199, 277);
            this.numClubClassSeat.Margin = new System.Windows.Forms.Padding(10, 15, 10, 15);
            this.numClubClassSeat.Maximum = new decimal(new int[] {
            500,
            0,
            0,
            0});
            this.numClubClassSeat.Name = "numClubClassSeat";
            this.numClubClassSeat.Size = new System.Drawing.Size(220, 29);
            this.numClubClassSeat.TabIndex = 14;
            this.numClubClassSeat.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // rbtnActive
            // 
            this.rbtnActive.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.rbtnActive.Location = new System.Drawing.Point(199, 334);
            this.rbtnActive.Margin = new System.Windows.Forms.Padding(10, 15, 10, 15);
            this.rbtnActive.Name = "rbtnActive";
            this.rbtnActive.Size = new System.Drawing.Size(85, 29);
            this.rbtnActive.TabIndex = 15;
            this.rbtnActive.TabStop = true;
            this.rbtnActive.Text = "Active";
            this.rbtnActive.UseVisualStyleBackColor = true;
            // 
            // rbtnInActive
            // 
            this.rbtnInActive.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.rbtnInActive.Location = new System.Drawing.Point(304, 334);
            this.rbtnInActive.Margin = new System.Windows.Forms.Padding(10, 15, 10, 15);
            this.rbtnInActive.Name = "rbtnInActive";
            this.rbtnInActive.Size = new System.Drawing.Size(85, 29);
            this.rbtnInActive.TabIndex = 16;
            this.rbtnInActive.TabStop = true;
            this.rbtnInActive.Text = "InActive";
            this.rbtnInActive.UseVisualStyleBackColor = true;
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
            this.label5.Margin = new System.Windows.Forms.Padding(0, 0, 0, 15);
            this.label5.Name = "label5";
            this.label5.Padding = new System.Windows.Forms.Padding(50, 0, 0, 0);
            this.label5.Size = new System.Drawing.Size(492, 70);
            this.label5.TabIndex = 17;
            this.label5.Text = "AIRPLANE TYPE";
            this.label5.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label6
            // 
            this.label6.Font = new System.Drawing.Font("Segoe UI Semibold", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.Location = new System.Drawing.Point(59, 334);
            this.label6.Margin = new System.Windows.Forms.Padding(50, 15, 10, 15);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(120, 29);
            this.label6.TabIndex = 11;
            this.label6.Text = "Status";
            this.label6.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // FormAirplaneTypeCE
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 21F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(490, 467);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.rbtnInActive);
            this.Controls.Add(this.rbtnActive);
            this.Controls.Add(this.numClubClassSeat);
            this.Controls.Add(this.numBusinessClassSeat);
            this.Controls.Add(this.numFirstClassSeat);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.btnSubmit);
            this.Controls.Add(this.txtName);
            this.Controls.Add(this.label2);
            this.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.Name = "FormAirplaneTypeCE";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Airplane Type";
            this.Load += new System.EventHandler(this.AirplaneTypeCE_Load);
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
        private System.Windows.Forms.RadioButton rbtnActive;
        private System.Windows.Forms.RadioButton rbtnInActive;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
    }
}