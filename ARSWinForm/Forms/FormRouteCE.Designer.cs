namespace ARSWinForm
{
    partial class FormRouteCE
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
            this.label4 = new System.Windows.Forms.Label();
            this.cboFromCity = new System.Windows.Forms.ComboBox();
            this.cboToCity = new System.Windows.Forms.ComboBox();
            this.numSkyMiles = new System.Windows.Forms.NumericUpDown();
            this.numBasePrice = new System.Windows.Forms.NumericUpDown();
            this.rbtnActive = new System.Windows.Forms.RadioButton();
            this.rbtnInActive = new System.Windows.Forms.RadioButton();
            this.btnSubmit = new System.Windows.Forms.Button();
            this.btnCancel = new System.Windows.Forms.Button();
            this.label5 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.numSkyMiles)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numBasePrice)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Segoe UI Semibold", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(41, 108);
            this.label1.Margin = new System.Windows.Forms.Padding(50, 15, 10, 15);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(80, 21);
            this.label1.TabIndex = 0;
            this.label1.Text = "From City";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Segoe UI Semibold", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(42, 166);
            this.label2.Margin = new System.Windows.Forms.Padding(50, 15, 10, 15);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(61, 21);
            this.label2.TabIndex = 1;
            this.label2.Text = "To City";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Segoe UI Semibold", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(41, 224);
            this.label3.Margin = new System.Windows.Forms.Padding(50, 15, 10, 15);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(78, 21);
            this.label3.TabIndex = 2;
            this.label3.Text = "Sky Miles";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Segoe UI Semibold", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(41, 282);
            this.label4.Margin = new System.Windows.Forms.Padding(50, 15, 10, 15);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(84, 21);
            this.label4.TabIndex = 3;
            this.label4.Text = "Base Price";
            // 
            // cboFromCity
            // 
            this.cboFromCity.FormattingEnabled = true;
            this.cboFromCity.Location = new System.Drawing.Point(152, 105);
            this.cboFromCity.Margin = new System.Windows.Forms.Padding(10, 15, 10, 15);
            this.cboFromCity.Name = "cboFromCity";
            this.cboFromCity.Size = new System.Drawing.Size(220, 29);
            this.cboFromCity.TabIndex = 5;
            // 
            // cboToCity
            // 
            this.cboToCity.FormattingEnabled = true;
            this.cboToCity.Location = new System.Drawing.Point(152, 160);
            this.cboToCity.Margin = new System.Windows.Forms.Padding(10, 15, 10, 15);
            this.cboToCity.Name = "cboToCity";
            this.cboToCity.Size = new System.Drawing.Size(220, 29);
            this.cboToCity.TabIndex = 6;
            // 
            // numSkyMiles
            // 
            this.numSkyMiles.Location = new System.Drawing.Point(152, 219);
            this.numSkyMiles.Margin = new System.Windows.Forms.Padding(10, 15, 10, 15);
            this.numSkyMiles.Maximum = new decimal(new int[] {
            9999999,
            0,
            0,
            0});
            this.numSkyMiles.Name = "numSkyMiles";
            this.numSkyMiles.Size = new System.Drawing.Size(220, 29);
            this.numSkyMiles.TabIndex = 7;
            // 
            // numBasePrice
            // 
            this.numBasePrice.Location = new System.Drawing.Point(152, 277);
            this.numBasePrice.Margin = new System.Windows.Forms.Padding(10, 15, 10, 15);
            this.numBasePrice.Maximum = new decimal(new int[] {
            9999999,
            0,
            0,
            0});
            this.numBasePrice.Name = "numBasePrice";
            this.numBasePrice.Size = new System.Drawing.Size(220, 29);
            this.numBasePrice.TabIndex = 8;
            // 
            // rbtnActive
            // 
            this.rbtnActive.AutoSize = true;
            this.rbtnActive.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.rbtnActive.Location = new System.Drawing.Point(152, 336);
            this.rbtnActive.Margin = new System.Windows.Forms.Padding(10, 15, 10, 15);
            this.rbtnActive.Name = "rbtnActive";
            this.rbtnActive.Size = new System.Drawing.Size(73, 25);
            this.rbtnActive.TabIndex = 9;
            this.rbtnActive.TabStop = true;
            this.rbtnActive.Text = "Active";
            this.rbtnActive.UseVisualStyleBackColor = true;
            // 
            // rbtnInActive
            // 
            this.rbtnInActive.AutoSize = true;
            this.rbtnInActive.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.rbtnInActive.Location = new System.Drawing.Point(259, 336);
            this.rbtnInActive.Margin = new System.Windows.Forms.Padding(10, 15, 10, 15);
            this.rbtnInActive.Name = "rbtnInActive";
            this.rbtnInActive.Size = new System.Drawing.Size(87, 25);
            this.rbtnInActive.TabIndex = 10;
            this.rbtnInActive.TabStop = true;
            this.rbtnInActive.Text = "InActive";
            this.rbtnInActive.UseVisualStyleBackColor = true;
            // 
            // btnSubmit
            // 
            this.btnSubmit.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(150)))), ((int)(((byte)(136)))));
            this.btnSubmit.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnSubmit.ForeColor = System.Drawing.Color.White;
            this.btnSubmit.Location = new System.Drawing.Point(81, 386);
            this.btnSubmit.Margin = new System.Windows.Forms.Padding(10);
            this.btnSubmit.Name = "btnSubmit";
            this.btnSubmit.Size = new System.Drawing.Size(120, 45);
            this.btnSubmit.TabIndex = 11;
            this.btnSubmit.Text = "Submit";
            this.btnSubmit.UseVisualStyleBackColor = false;
            this.btnSubmit.Click += new System.EventHandler(this.btnSubmit_Click);
            // 
            // btnCancel
            // 
            this.btnCancel.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(229)))), ((int)(((byte)(57)))), ((int)(((byte)(13)))));
            this.btnCancel.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnCancel.ForeColor = System.Drawing.Color.White;
            this.btnCancel.Location = new System.Drawing.Point(221, 387);
            this.btnCancel.Margin = new System.Windows.Forms.Padding(10);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(120, 45);
            this.btnCancel.TabIndex = 12;
            this.btnCancel.Text = "Cancel";
            this.btnCancel.UseVisualStyleBackColor = false;
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // label5
            // 
            this.label5.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.label5.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(150)))), ((int)(((byte)(136)))));
            this.label5.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.label5.Font = new System.Drawing.Font("Segoe UI", 16.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.ForeColor = System.Drawing.Color.White;
            this.label5.Location = new System.Drawing.Point(-1, 0);
            this.label5.Margin = new System.Windows.Forms.Padding(0);
            this.label5.Name = "label5";
            this.label5.Padding = new System.Windows.Forms.Padding(50, 0, 0, 0);
            this.label5.Size = new System.Drawing.Size(419, 70);
            this.label5.TabIndex = 13;
            this.label5.Text = "ROUTE";
            this.label5.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // FormRouteCE
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 21F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(419, 459);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.btnSubmit);
            this.Controls.Add(this.rbtnInActive);
            this.Controls.Add(this.rbtnActive);
            this.Controls.Add(this.numBasePrice);
            this.Controls.Add(this.numSkyMiles);
            this.Controls.Add(this.cboToCity);
            this.Controls.Add(this.cboFromCity);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Font = new System.Drawing.Font("Segoe UI Semibold", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.Name = "FormRouteCE";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Route";
            this.Load += new System.EventHandler(this.FormRouteCE_Load);
            ((System.ComponentModel.ISupportInitialize)(this.numSkyMiles)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numBasePrice)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.ComboBox cboFromCity;
        private System.Windows.Forms.ComboBox cboToCity;
        private System.Windows.Forms.NumericUpDown numSkyMiles;
        private System.Windows.Forms.NumericUpDown numBasePrice;
        private System.Windows.Forms.RadioButton rbtnActive;
        private System.Windows.Forms.RadioButton rbtnInActive;
        private System.Windows.Forms.Button btnSubmit;
        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.Label label5;
    }
}