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
            this.cboActive = new System.Windows.Forms.RadioButton();
            this.cboIsActive = new System.Windows.Forms.RadioButton();
            this.cboAirplane = new System.Windows.Forms.ComboBox();
            this.cboRoute = new System.Windows.Forms.ComboBox();
            this.btnSubmit = new System.Windows.Forms.Button();
            this.btnCancel = new System.Windows.Forms.Button();
            this.dateTimePicker1 = new System.Windows.Forms.DateTimePicker();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(13, 60);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(97, 17);
            this.label1.TabIndex = 0;
            this.label1.Text = "Airplane Code";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(13, 149);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(46, 17);
            this.label2.TabIndex = 1;
            this.label2.Text = "Route";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(13, 224);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(106, 17);
            this.label3.TabIndex = 2;
            this.label3.Text = "Departure Date";
            // 
            // cboActive
            // 
            this.cboActive.AutoSize = true;
            this.cboActive.Location = new System.Drawing.Point(78, 337);
            this.cboActive.Name = "cboActive";
            this.cboActive.Size = new System.Drawing.Size(67, 21);
            this.cboActive.TabIndex = 4;
            this.cboActive.TabStop = true;
            this.cboActive.Text = "Active";
            this.cboActive.UseVisualStyleBackColor = true;
            // 
            // cboIsActive
            // 
            this.cboIsActive.AutoSize = true;
            this.cboIsActive.Location = new System.Drawing.Point(251, 337);
            this.cboIsActive.Name = "cboIsActive";
            this.cboIsActive.Size = new System.Drawing.Size(81, 21);
            this.cboIsActive.TabIndex = 5;
            this.cboIsActive.TabStop = true;
            this.cboIsActive.Text = "Is Active";
            this.cboIsActive.UseVisualStyleBackColor = true;
            // 
            // cboAirplane
            // 
            this.cboAirplane.FormattingEnabled = true;
            this.cboAirplane.Location = new System.Drawing.Point(166, 57);
            this.cboAirplane.Name = "cboAirplane";
            this.cboAirplane.Size = new System.Drawing.Size(166, 24);
            this.cboAirplane.TabIndex = 6;
            // 
            // cboRoute
            // 
            this.cboRoute.FormattingEnabled = true;
            this.cboRoute.Location = new System.Drawing.Point(166, 146);
            this.cboRoute.Name = "cboRoute";
            this.cboRoute.Size = new System.Drawing.Size(166, 24);
            this.cboRoute.TabIndex = 7;
            // 
            // btnSubmit
            // 
            this.btnSubmit.Location = new System.Drawing.Point(78, 455);
            this.btnSubmit.Name = "btnSubmit";
            this.btnSubmit.Size = new System.Drawing.Size(75, 23);
            this.btnSubmit.TabIndex = 8;
            this.btnSubmit.Text = "Submit";
            this.btnSubmit.UseVisualStyleBackColor = true;
            // 
            // btnCancel
            // 
            this.btnCancel.Location = new System.Drawing.Point(257, 455);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(75, 23);
            this.btnCancel.TabIndex = 9;
            this.btnCancel.Text = "Cancel";
            this.btnCancel.UseVisualStyleBackColor = true;
            // 
            // dateTimePicker1
            // 
            this.dateTimePicker1.CustomFormat = "dd/MM/yyyy";
            this.dateTimePicker1.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dateTimePicker1.Location = new System.Drawing.Point(166, 224);
            this.dateTimePicker1.Name = "dateTimePicker1";
            this.dateTimePicker1.Size = new System.Drawing.Size(166, 22);
            this.dateTimePicker1.TabIndex = 10;
            // 
            // CE_FlightSchedule
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(391, 509);
            this.Controls.Add(this.dateTimePicker1);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.btnSubmit);
            this.Controls.Add(this.cboRoute);
            this.Controls.Add(this.cboAirplane);
            this.Controls.Add(this.cboIsActive);
            this.Controls.Add(this.cboActive);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Name = "CE_FlightSchedule";
            this.Text = "CE_FlightSchedule";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.RadioButton cboActive;
        private System.Windows.Forms.RadioButton cboIsActive;
        private System.Windows.Forms.ComboBox cboAirplane;
        private System.Windows.Forms.ComboBox cboRoute;
        private System.Windows.Forms.Button btnSubmit;
        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.DateTimePicker dateTimePicker1;
    }
}