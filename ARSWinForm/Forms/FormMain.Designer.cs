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
            this.btnAdmin = new System.Windows.Forms.Button();
            this.btnAirplane = new System.Windows.Forms.Button();
            this.btnAirplaneClass = new System.Windows.Forms.Button();
            this.btnAirplaneInfo = new System.Windows.Forms.Button();
            this.btnAirplaneType = new System.Windows.Forms.Button();
            this.btnCity = new System.Windows.Forms.Button();
            this.btnFlightSchedule = new System.Windows.Forms.Button();
            this.btnRoute = new System.Windows.Forms.Button();
            this.btnLogout = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // btnAdmin
            // 
            this.btnAdmin.Location = new System.Drawing.Point(53, 102);
            this.btnAdmin.Name = "btnAdmin";
            this.btnAdmin.Size = new System.Drawing.Size(114, 93);
            this.btnAdmin.TabIndex = 0;
            this.btnAdmin.Text = "Admin";
            this.btnAdmin.UseVisualStyleBackColor = true;
            this.btnAdmin.Click += new System.EventHandler(this.btnAdmin_Click);
            // 
            // btnAirplane
            // 
            this.btnAirplane.Location = new System.Drawing.Point(247, 102);
            this.btnAirplane.Name = "btnAirplane";
            this.btnAirplane.Size = new System.Drawing.Size(113, 93);
            this.btnAirplane.TabIndex = 1;
            this.btnAirplane.Text = "Airplane";
            this.btnAirplane.UseVisualStyleBackColor = true;
            this.btnAirplane.Click += new System.EventHandler(this.btnAirplane_Click);
            // 
            // btnAirplaneClass
            // 
            this.btnAirplaneClass.Location = new System.Drawing.Point(440, 102);
            this.btnAirplaneClass.Name = "btnAirplaneClass";
            this.btnAirplaneClass.Size = new System.Drawing.Size(110, 93);
            this.btnAirplaneClass.TabIndex = 2;
            this.btnAirplaneClass.Text = "Airplane Class";
            this.btnAirplaneClass.UseVisualStyleBackColor = true;
            this.btnAirplaneClass.Click += new System.EventHandler(this.btnAirplaneClass_Click);
            // 
            // btnAirplaneInfo
            // 
            this.btnAirplaneInfo.Location = new System.Drawing.Point(53, 288);
            this.btnAirplaneInfo.Name = "btnAirplaneInfo";
            this.btnAirplaneInfo.Size = new System.Drawing.Size(114, 83);
            this.btnAirplaneInfo.TabIndex = 3;
            this.btnAirplaneInfo.Text = "Airplane Info";
            this.btnAirplaneInfo.UseVisualStyleBackColor = true;
            this.btnAirplaneInfo.Click += new System.EventHandler(this.btnAirplaneInfo_Click);
            // 
            // btnAirplaneType
            // 
            this.btnAirplaneType.Location = new System.Drawing.Point(247, 288);
            this.btnAirplaneType.Name = "btnAirplaneType";
            this.btnAirplaneType.Size = new System.Drawing.Size(113, 83);
            this.btnAirplaneType.TabIndex = 4;
            this.btnAirplaneType.Text = "Airplane Type";
            this.btnAirplaneType.UseVisualStyleBackColor = true;
            this.btnAirplaneType.Click += new System.EventHandler(this.btnAirplaneType_Click);
            // 
            // btnCity
            // 
            this.btnCity.Location = new System.Drawing.Point(440, 288);
            this.btnCity.Name = "btnCity";
            this.btnCity.Size = new System.Drawing.Size(110, 83);
            this.btnCity.TabIndex = 5;
            this.btnCity.Text = "City";
            this.btnCity.UseVisualStyleBackColor = true;
            this.btnCity.Click += new System.EventHandler(this.btnCity_Click);
            // 
            // btnFlightSchedule
            // 
            this.btnFlightSchedule.Location = new System.Drawing.Point(643, 102);
            this.btnFlightSchedule.Name = "btnFlightSchedule";
            this.btnFlightSchedule.Size = new System.Drawing.Size(107, 92);
            this.btnFlightSchedule.TabIndex = 6;
            this.btnFlightSchedule.Text = "Flight Schedule";
            this.btnFlightSchedule.UseVisualStyleBackColor = true;
            this.btnFlightSchedule.Click += new System.EventHandler(this.btnFlightSchedule_Click);
            // 
            // btnRoute
            // 
            this.btnRoute.Location = new System.Drawing.Point(643, 288);
            this.btnRoute.Name = "btnRoute";
            this.btnRoute.Size = new System.Drawing.Size(107, 82);
            this.btnRoute.TabIndex = 7;
            this.btnRoute.Text = "Route";
            this.btnRoute.UseVisualStyleBackColor = true;
            this.btnRoute.Click += new System.EventHandler(this.btnRoute_Click);
            // 
            // btnLogout
            // 
            this.btnLogout.Location = new System.Drawing.Point(713, 12);
            this.btnLogout.Name = "btnLogout";
            this.btnLogout.Size = new System.Drawing.Size(75, 35);
            this.btnLogout.TabIndex = 8;
            this.btnLogout.Text = "Log Out";
            this.btnLogout.UseVisualStyleBackColor = true;
            // 
            // FormMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.btnLogout);
            this.Controls.Add(this.btnRoute);
            this.Controls.Add(this.btnFlightSchedule);
            this.Controls.Add(this.btnCity);
            this.Controls.Add(this.btnAirplaneType);
            this.Controls.Add(this.btnAirplaneInfo);
            this.Controls.Add(this.btnAirplaneClass);
            this.Controls.Add(this.btnAirplane);
            this.Controls.Add(this.btnAdmin);
            this.Name = "FormMain";
            this.Text = "Manager ";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btnAdmin;
        private System.Windows.Forms.Button btnAirplane;
        private System.Windows.Forms.Button btnAirplaneClass;
        private System.Windows.Forms.Button btnAirplaneInfo;
        private System.Windows.Forms.Button btnAirplaneType;
        private System.Windows.Forms.Button btnCity;
        private System.Windows.Forms.Button btnFlightSchedule;
        private System.Windows.Forms.Button btnRoute;
        private System.Windows.Forms.Button btnLogout;
    }
}