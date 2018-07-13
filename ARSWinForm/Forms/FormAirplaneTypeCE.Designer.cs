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
            ((System.ComponentModel.ISupportInitialize)(this.numFirstClassSeat)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numBusinessClassSeat)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numClubClassSeat)).BeginInit();
            this.SuspendLayout();
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(17, 50);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(45, 17);
            this.label2.TabIndex = 1;
            this.label2.Text = "Name";
            // 
            // txtName
            // 
            this.txtName.Location = new System.Drawing.Point(131, 47);
            this.txtName.Name = "txtName";
            this.txtName.Size = new System.Drawing.Size(156, 22);
            this.txtName.TabIndex = 4;
            // 
            // btnSubmit
            // 
            this.btnSubmit.Location = new System.Drawing.Point(45, 363);
            this.btnSubmit.Name = "btnSubmit";
            this.btnSubmit.Size = new System.Drawing.Size(75, 23);
            this.btnSubmit.TabIndex = 7;
            this.btnSubmit.Text = "Submit";
            this.btnSubmit.UseVisualStyleBackColor = true;
            this.btnSubmit.Click += new System.EventHandler(this.btnSubmit_Click);
            // 
            // btnCancel
            // 
            this.btnCancel.Location = new System.Drawing.Point(176, 363);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(75, 23);
            this.btnCancel.TabIndex = 8;
            this.btnCancel.Text = "Cancel";
            this.btnCancel.UseVisualStyleBackColor = true;
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(17, 113);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(73, 17);
            this.label1.TabIndex = 9;
            this.label1.Text = "First Class";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(17, 188);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(103, 17);
            this.label3.TabIndex = 10;
            this.label3.Text = "Business Class";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(17, 256);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(74, 17);
            this.label4.TabIndex = 11;
            this.label4.Text = "Club Class";
            // 
            // numFirstClassSeat
            // 
            this.numFirstClassSeat.Location = new System.Drawing.Point(131, 113);
            this.numFirstClassSeat.Name = "numFirstClassSeat";
            this.numFirstClassSeat.Size = new System.Drawing.Size(156, 22);
            this.numFirstClassSeat.TabIndex = 12;
            // 
            // numBusinessClassSeat
            // 
            this.numBusinessClassSeat.Location = new System.Drawing.Point(131, 182);
            this.numBusinessClassSeat.Name = "numBusinessClassSeat";
            this.numBusinessClassSeat.Size = new System.Drawing.Size(156, 22);
            this.numBusinessClassSeat.TabIndex = 13;
            // 
            // numClubClassSeat
            // 
            this.numClubClassSeat.Location = new System.Drawing.Point(131, 256);
            this.numClubClassSeat.Name = "numClubClassSeat";
            this.numClubClassSeat.Size = new System.Drawing.Size(156, 22);
            this.numClubClassSeat.TabIndex = 14;
            // 
            // cboActive
            // 
            this.cboActive.AutoSize = true;
            this.cboActive.Location = new System.Drawing.Point(45, 315);
            this.cboActive.Name = "cboActive";
            this.cboActive.Size = new System.Drawing.Size(67, 21);
            this.cboActive.TabIndex = 15;
            this.cboActive.TabStop = true;
            this.cboActive.Text = "Active";
            this.cboActive.UseVisualStyleBackColor = true;
            // 
            // cboInActive
            // 
            this.cboInActive.AutoSize = true;
            this.cboInActive.Location = new System.Drawing.Point(177, 315);
            this.cboInActive.Name = "cboInActive";
            this.cboInActive.Size = new System.Drawing.Size(78, 21);
            this.cboInActive.TabIndex = 16;
            this.cboInActive.TabStop = true;
            this.cboInActive.Text = "InActive";
            this.cboInActive.UseVisualStyleBackColor = true;
            // 
            // CE_AirplaneType
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(329, 421);
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
            this.Name = "CE_AirplaneType";
            this.Text = "Create_AirplaneType";
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
    }
}