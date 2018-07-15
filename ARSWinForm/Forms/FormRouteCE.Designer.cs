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
            ((System.ComponentModel.ISupportInitialize)(this.numSkyMiles)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numBasePrice)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(16, 46);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(67, 17);
            this.label1.TabIndex = 0;
            this.label1.Text = "From City";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(16, 115);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(52, 17);
            this.label2.TabIndex = 1;
            this.label2.Text = "To City";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(16, 198);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(67, 17);
            this.label3.TabIndex = 2;
            this.label3.Text = "Sky Miles";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(16, 284);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(76, 17);
            this.label4.TabIndex = 3;
            this.label4.Text = "Base Price";
            // 
            // cboFromCity
            // 
            this.cboFromCity.FormattingEnabled = true;
            this.cboFromCity.Location = new System.Drawing.Point(163, 46);
            this.cboFromCity.Name = "cboFromCity";
            this.cboFromCity.Size = new System.Drawing.Size(121, 24);
            this.cboFromCity.TabIndex = 5;
            // 
            // cboToCity
            // 
            this.cboToCity.FormattingEnabled = true;
            this.cboToCity.Location = new System.Drawing.Point(163, 106);
            this.cboToCity.Name = "cboToCity";
            this.cboToCity.Size = new System.Drawing.Size(121, 24);
            this.cboToCity.TabIndex = 6;
            // 
            // numSkyMiles
            // 
            this.numSkyMiles.Location = new System.Drawing.Point(164, 196);
            this.numSkyMiles.Maximum = new decimal(new int[] {
            9999999,
            0,
            0,
            0});
            this.numSkyMiles.Name = "numSkyMiles";
            this.numSkyMiles.Size = new System.Drawing.Size(120, 22);
            this.numSkyMiles.TabIndex = 7;
            // 
            // numBasePrice
            // 
            this.numBasePrice.Location = new System.Drawing.Point(164, 279);
            this.numBasePrice.Maximum = new decimal(new int[] {
            9999999,
            0,
            0,
            0});
            this.numBasePrice.Name = "numBasePrice";
            this.numBasePrice.Size = new System.Drawing.Size(120, 22);
            this.numBasePrice.TabIndex = 8;
            // 
            // rbtnActive
            // 
            this.rbtnActive.AutoSize = true;
            this.rbtnActive.Location = new System.Drawing.Point(55, 356);
            this.rbtnActive.Name = "rbtnActive";
            this.rbtnActive.Size = new System.Drawing.Size(67, 21);
            this.rbtnActive.TabIndex = 9;
            this.rbtnActive.TabStop = true;
            this.rbtnActive.Text = "Active";
            this.rbtnActive.UseVisualStyleBackColor = true;
            // 
            // rbtnInActive
            // 
            this.rbtnInActive.AutoSize = true;
            this.rbtnInActive.Location = new System.Drawing.Point(184, 356);
            this.rbtnInActive.Name = "rbtnInActive";
            this.rbtnInActive.Size = new System.Drawing.Size(78, 21);
            this.rbtnInActive.TabIndex = 10;
            this.rbtnInActive.TabStop = true;
            this.rbtnInActive.Text = "InActive";
            this.rbtnInActive.UseVisualStyleBackColor = true;
            // 
            // btnSubmit
            // 
            this.btnSubmit.Location = new System.Drawing.Point(72, 415);
            this.btnSubmit.Name = "btnSubmit";
            this.btnSubmit.Size = new System.Drawing.Size(75, 23);
            this.btnSubmit.TabIndex = 11;
            this.btnSubmit.Text = "Submit";
            this.btnSubmit.UseVisualStyleBackColor = true;
            this.btnSubmit.Click += new System.EventHandler(this.btnSubmit_Click);
            // 
            // btnCancel
            // 
            this.btnCancel.Location = new System.Drawing.Point(184, 415);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(75, 23);
            this.btnCancel.TabIndex = 12;
            this.btnCancel.Text = "Cancel";
            this.btnCancel.UseVisualStyleBackColor = true;
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // FormRouteCE
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(342, 450);
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
            this.Name = "FormRouteCE";
            this.Text = "CE_Route";
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
    }
}