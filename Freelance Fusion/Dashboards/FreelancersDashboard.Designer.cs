namespace Freelance_Fusion.Dashboards
{
    partial class FreelancersDashboard
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

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FreelancersDashboard));
            this.ClientBtn = new Guna.UI2.WinForms.Guna2Button();
            this.guna2CircleButton1 = new Guna.UI2.WinForms.Guna2CircleButton();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.pnlOngoingProjectsContainer = new System.Windows.Forms.Panel();
            this.flpOngoingProjects = new System.Windows.Forms.FlowLayoutPanel();
            this.pnlRecommendedProjectsContainer = new System.Windows.Forms.Panel();
            this.flpRecommendedProjects = new System.Windows.Forms.FlowLayoutPanel();
            this.pnlCompletedProjects = new System.Windows.Forms.Panel();
            this.flpCompletedProjects = new System.Windows.Forms.FlowLayoutPanel();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.pnlOngoingProjectsContainer.SuspendLayout();
            this.pnlRecommendedProjectsContainer.SuspendLayout();
            this.pnlCompletedProjects.SuspendLayout();
            this.SuspendLayout();
            // 
            // ClientBtn
            // 
            this.ClientBtn.Animated = true;
            this.ClientBtn.BackColor = System.Drawing.Color.Transparent;
            this.ClientBtn.BorderRadius = 4;
            this.ClientBtn.DisabledState.BorderColor = System.Drawing.Color.DarkGray;
            this.ClientBtn.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray;
            this.ClientBtn.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
            this.ClientBtn.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(141)))), ((int)(((byte)(141)))), ((int)(((byte)(141)))));
            this.ClientBtn.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(240)))), ((int)(((byte)(240)))), ((int)(((byte)(240)))));
            this.ClientBtn.Font = new System.Drawing.Font("Arial", 12F);
            this.ClientBtn.ForeColor = System.Drawing.Color.Black;
            this.ClientBtn.Location = new System.Drawing.Point(1173, 131);
            this.ClientBtn.Name = "ClientBtn";
            this.ClientBtn.Size = new System.Drawing.Size(113, 36);
            this.ClientBtn.TabIndex = 25;
            this.ClientBtn.Text = "Client";
            // 
            // guna2CircleButton1
            // 
            this.guna2CircleButton1.BackgroundImage = global::Freelance_Fusion.Properties.Resources.Vector;
            this.guna2CircleButton1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.guna2CircleButton1.DisabledState.BorderColor = System.Drawing.Color.DarkGray;
            this.guna2CircleButton1.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray;
            this.guna2CircleButton1.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
            this.guna2CircleButton1.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(141)))), ((int)(((byte)(141)))), ((int)(((byte)(141)))));
            this.guna2CircleButton1.FillColor = System.Drawing.Color.Transparent;
            this.guna2CircleButton1.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.guna2CircleButton1.ForeColor = System.Drawing.Color.White;
            this.guna2CircleButton1.Location = new System.Drawing.Point(1248, 15);
            this.guna2CircleButton1.Name = "guna2CircleButton1";
            this.guna2CircleButton1.ShadowDecoration.Mode = Guna.UI2.WinForms.Enums.ShadowMode.Circle;
            this.guna2CircleButton1.Size = new System.Drawing.Size(58, 61);
            this.guna2CircleButton1.TabIndex = 39;
            // 
            // pictureBox1
            // 
            this.pictureBox1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pictureBox1.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox1.Image")));
            this.pictureBox1.Location = new System.Drawing.Point(0, 0);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(1334, 2560);
            this.pictureBox1.TabIndex = 0;
            this.pictureBox1.TabStop = false;
            this.pictureBox1.Click += new System.EventHandler(this.pictureBox1_Click);
            // 
            // pnlOngoingProjectsContainer
            // 
            this.pnlOngoingProjectsContainer.Controls.Add(this.flpOngoingProjects);
            this.pnlOngoingProjectsContainer.Location = new System.Drawing.Point(87, 268);
            this.pnlOngoingProjectsContainer.Name = "pnlOngoingProjectsContainer";
            this.pnlOngoingProjectsContainer.Size = new System.Drawing.Size(1182, 454);
            this.pnlOngoingProjectsContainer.TabIndex = 40;
            // 
            // flpOngoingProjects
            // 
            this.flpOngoingProjects.Dock = System.Windows.Forms.DockStyle.Fill;
            this.flpOngoingProjects.Location = new System.Drawing.Point(0, 0);
            this.flpOngoingProjects.Name = "flpOngoingProjects";
            this.flpOngoingProjects.Size = new System.Drawing.Size(1182, 454);
            this.flpOngoingProjects.TabIndex = 0;
            // 
            // pnlRecommendedProjectsContainer
            // 
            this.pnlRecommendedProjectsContainer.Controls.Add(this.flpRecommendedProjects);
            this.pnlRecommendedProjectsContainer.Location = new System.Drawing.Point(87, 1350);
            this.pnlRecommendedProjectsContainer.Name = "pnlRecommendedProjectsContainer";
            this.pnlRecommendedProjectsContainer.Size = new System.Drawing.Size(1182, 454);
            this.pnlRecommendedProjectsContainer.TabIndex = 41;
            // 
            // flpRecommendedProjects
            // 
            this.flpRecommendedProjects.Dock = System.Windows.Forms.DockStyle.Fill;
            this.flpRecommendedProjects.Location = new System.Drawing.Point(0, 0);
            this.flpRecommendedProjects.Name = "flpRecommendedProjects";
            this.flpRecommendedProjects.Size = new System.Drawing.Size(1182, 454);
            this.flpRecommendedProjects.TabIndex = 0;
            // 
            // pnlCompletedProjects
            // 
            this.pnlCompletedProjects.Controls.Add(this.flpCompletedProjects);
            this.pnlCompletedProjects.Location = new System.Drawing.Point(87, 1983);
            this.pnlCompletedProjects.Name = "pnlCompletedProjects";
            this.pnlCompletedProjects.Size = new System.Drawing.Size(1182, 454);
            this.pnlCompletedProjects.TabIndex = 42;
            // 
            // flpCompletedProjects
            // 
            this.flpCompletedProjects.Dock = System.Windows.Forms.DockStyle.Fill;
            this.flpCompletedProjects.Location = new System.Drawing.Point(0, 0);
            this.flpCompletedProjects.Name = "flpCompletedProjects";
            this.flpCompletedProjects.Size = new System.Drawing.Size(1182, 454);
            this.flpCompletedProjects.TabIndex = 0;
            // 
            // FreelancersDashboard
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.pnlCompletedProjects);
            this.Controls.Add(this.pnlRecommendedProjectsContainer);
            this.Controls.Add(this.pnlOngoingProjectsContainer);
            this.Controls.Add(this.guna2CircleButton1);
            this.Controls.Add(this.ClientBtn);
            this.Controls.Add(this.pictureBox1);
            this.Name = "FreelancersDashboard";
            this.Size = new System.Drawing.Size(1334, 2560);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.pnlOngoingProjectsContainer.ResumeLayout(false);
            this.pnlRecommendedProjectsContainer.ResumeLayout(false);
            this.pnlCompletedProjects.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.PictureBox pictureBox1;
        private Guna.UI2.WinForms.Guna2Button ClientBtn;
        private Guna.UI2.WinForms.Guna2CircleButton guna2CircleButton1;
        private System.Windows.Forms.Panel pnlOngoingProjectsContainer;
        private System.Windows.Forms.FlowLayoutPanel flpOngoingProjects;
        private System.Windows.Forms.Panel pnlRecommendedProjectsContainer;
        private System.Windows.Forms.FlowLayoutPanel flpRecommendedProjects;
        private System.Windows.Forms.Panel pnlCompletedProjects;
        private System.Windows.Forms.FlowLayoutPanel flpCompletedProjects;
    }
}
