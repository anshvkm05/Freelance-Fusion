namespace Freelance_Fusion.Dashboards
{
    partial class ClientDashboard
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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ClientDashboard));
            this.AddProject = new Guna.UI2.WinForms.Guna2TileButton();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.pnlOngoingProjectsContainer = new System.Windows.Forms.Panel();
            this.flpOngoingProjects = new System.Windows.Forms.FlowLayoutPanel();
            this.ScrollOPBtn2 = new Guna.UI2.WinForms.Guna2TileButton();
            this.ScrollOPBtn1 = new Guna.UI2.WinForms.Guna2TileButton();
            this.ScrollTimer = new System.Windows.Forms.Timer(this.components);
            this.Profile = new Guna.UI2.WinForms.Guna2CircleButton();
            this.pnlRecommendedFreelancers = new System.Windows.Forms.Panel();
            this.flpRecommendedFreelancers = new System.Windows.Forms.FlowLayoutPanel();
            this.pnlPastProjects = new System.Windows.Forms.Panel();
            this.flpPastProjects = new System.Windows.Forms.FlowLayoutPanel();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.pnlOngoingProjectsContainer.SuspendLayout();
            this.pnlRecommendedFreelancers.SuspendLayout();
            this.pnlPastProjects.SuspendLayout();
            this.SuspendLayout();
            // 
            // AddProject
            // 
            this.AddProject.Animated = true;
            this.AddProject.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("AddProject.BackgroundImage")));
            this.AddProject.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.AddProject.DisabledState.BorderColor = System.Drawing.Color.DarkGray;
            this.AddProject.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray;
            this.AddProject.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
            this.AddProject.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(141)))), ((int)(((byte)(141)))), ((int)(((byte)(141)))));
            this.AddProject.FillColor = System.Drawing.Color.Transparent;
            this.AddProject.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.AddProject.ForeColor = System.Drawing.Color.White;
            this.AddProject.Location = new System.Drawing.Point(760, 275);
            this.AddProject.Name = "AddProject";
            this.AddProject.Size = new System.Drawing.Size(313, 395);
            this.AddProject.TabIndex = 1;
            this.AddProject.Click += new System.EventHandler(this.AddProject_Click);
            // 
            // pictureBox1
            // 
            this.pictureBox1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pictureBox1.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox1.Image")));
            this.pictureBox1.Location = new System.Drawing.Point(0, 0);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(1330, 2950);
            this.pictureBox1.TabIndex = 0;
            this.pictureBox1.TabStop = false;
            this.pictureBox1.Click += new System.EventHandler(this.pictureBox1_Click);
            this.pictureBox1.DoubleClick += new System.EventHandler(this.pictureBox1_DoubleClick);
            // 
            // pnlOngoingProjectsContainer
            // 
            this.pnlOngoingProjectsContainer.Controls.Add(this.flpOngoingProjects);
            this.pnlOngoingProjectsContainer.Location = new System.Drawing.Point(79, 917);
            this.pnlOngoingProjectsContainer.Name = "pnlOngoingProjectsContainer";
            this.pnlOngoingProjectsContainer.Size = new System.Drawing.Size(1182, 454);
            this.pnlOngoingProjectsContainer.TabIndex = 2;
            // 
            // flpOngoingProjects
            // 
            this.flpOngoingProjects.AutoScroll = true;
            this.flpOngoingProjects.Dock = System.Windows.Forms.DockStyle.Fill;
            this.flpOngoingProjects.Location = new System.Drawing.Point(0, 0);
            this.flpOngoingProjects.Name = "flpOngoingProjects";
            this.flpOngoingProjects.Size = new System.Drawing.Size(1182, 454);
            this.flpOngoingProjects.TabIndex = 0;
            this.flpOngoingProjects.WrapContents = false;
            // 
            // ScrollOPBtn2
            // 
            this.ScrollOPBtn2.Animated = true;
            this.ScrollOPBtn2.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("ScrollOPBtn2.BackgroundImage")));
            this.ScrollOPBtn2.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.ScrollOPBtn2.DisabledState.BorderColor = System.Drawing.Color.DarkGray;
            this.ScrollOPBtn2.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray;
            this.ScrollOPBtn2.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
            this.ScrollOPBtn2.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(141)))), ((int)(((byte)(141)))), ((int)(((byte)(141)))));
            this.ScrollOPBtn2.FillColor = System.Drawing.Color.Transparent;
            this.ScrollOPBtn2.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.ScrollOPBtn2.ForeColor = System.Drawing.Color.White;
            this.ScrollOPBtn2.Location = new System.Drawing.Point(1267, 1111);
            this.ScrollOPBtn2.Name = "ScrollOPBtn2";
            this.ScrollOPBtn2.Size = new System.Drawing.Size(24, 57);
            this.ScrollOPBtn2.TabIndex = 0;
            this.ScrollOPBtn2.MouseDown += new System.Windows.Forms.MouseEventHandler(this.ScrollOPBtn2_MouseDown);
            this.ScrollOPBtn2.MouseUp += new System.Windows.Forms.MouseEventHandler(this.ScrollOPBtn2_MouseUp);
            // 
            // ScrollOPBtn1
            // 
            this.ScrollOPBtn1.Animated = true;
            this.ScrollOPBtn1.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("ScrollOPBtn1.BackgroundImage")));
            this.ScrollOPBtn1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.ScrollOPBtn1.DisabledState.BorderColor = System.Drawing.Color.DarkGray;
            this.ScrollOPBtn1.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray;
            this.ScrollOPBtn1.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
            this.ScrollOPBtn1.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(141)))), ((int)(((byte)(141)))), ((int)(((byte)(141)))));
            this.ScrollOPBtn1.FillColor = System.Drawing.Color.Transparent;
            this.ScrollOPBtn1.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.ScrollOPBtn1.ForeColor = System.Drawing.Color.White;
            this.ScrollOPBtn1.Location = new System.Drawing.Point(49, 1112);
            this.ScrollOPBtn1.Name = "ScrollOPBtn1";
            this.ScrollOPBtn1.Size = new System.Drawing.Size(24, 56);
            this.ScrollOPBtn1.TabIndex = 3;
            // 
            // ScrollTimer
            // 
            this.ScrollTimer.Tick += new System.EventHandler(this.ScrollTimer_Tick);
            // 
            // Profile
            // 
            this.Profile.BackgroundImage = global::Freelance_Fusion.Properties.Resources.Vector;
            this.Profile.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.Profile.DisabledState.BorderColor = System.Drawing.Color.DarkGray;
            this.Profile.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray;
            this.Profile.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
            this.Profile.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(141)))), ((int)(((byte)(141)))), ((int)(((byte)(141)))));
            this.Profile.FillColor = System.Drawing.Color.Transparent;
            this.Profile.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.Profile.ForeColor = System.Drawing.Color.White;
            this.Profile.Location = new System.Drawing.Point(1249, 12);
            this.Profile.Name = "Profile";
            this.Profile.ShadowDecoration.Mode = Guna.UI2.WinForms.Enums.ShadowMode.Circle;
            this.Profile.Size = new System.Drawing.Size(58, 61);
            this.Profile.TabIndex = 40;
            this.Profile.Click += new System.EventHandler(this.Profile_Click);
            // 
            // pnlRecommendedFreelancers
            // 
            this.pnlRecommendedFreelancers.Controls.Add(this.flpRecommendedFreelancers);
            this.pnlRecommendedFreelancers.Location = new System.Drawing.Point(79, 1479);
            this.pnlRecommendedFreelancers.Name = "pnlRecommendedFreelancers";
            this.pnlRecommendedFreelancers.Size = new System.Drawing.Size(1182, 454);
            this.pnlRecommendedFreelancers.TabIndex = 41;
            // 
            // flpRecommendedFreelancers
            // 
            this.flpRecommendedFreelancers.Dock = System.Windows.Forms.DockStyle.Fill;
            this.flpRecommendedFreelancers.Location = new System.Drawing.Point(0, 0);
            this.flpRecommendedFreelancers.Name = "flpRecommendedFreelancers";
            this.flpRecommendedFreelancers.Size = new System.Drawing.Size(1182, 454);
            this.flpRecommendedFreelancers.TabIndex = 0;
            // 
            // pnlPastProjects
            // 
            this.pnlPastProjects.Controls.Add(this.flpPastProjects);
            this.pnlPastProjects.Location = new System.Drawing.Point(79, 2040);
            this.pnlPastProjects.Name = "pnlPastProjects";
            this.pnlPastProjects.Size = new System.Drawing.Size(1182, 454);
            this.pnlPastProjects.TabIndex = 42;
            // 
            // flpPastProjects
            // 
            this.flpPastProjects.Dock = System.Windows.Forms.DockStyle.Fill;
            this.flpPastProjects.Location = new System.Drawing.Point(0, 0);
            this.flpPastProjects.Name = "flpPastProjects";
            this.flpPastProjects.Size = new System.Drawing.Size(1182, 454);
            this.flpPastProjects.TabIndex = 0;
            // 
            // ClientDashboard
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.pnlPastProjects);
            this.Controls.Add(this.pnlRecommendedFreelancers);
            this.Controls.Add(this.Profile);
            this.Controls.Add(this.ScrollOPBtn1);
            this.Controls.Add(this.ScrollOPBtn2);
            this.Controls.Add(this.pnlOngoingProjectsContainer);
            this.Controls.Add(this.AddProject);
            this.Controls.Add(this.pictureBox1);
            this.Name = "ClientDashboard";
            this.Size = new System.Drawing.Size(1330, 2950);
            this.Load += new System.EventHandler(this.ClientDashboard_Load);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.pnlOngoingProjectsContainer.ResumeLayout(false);
            this.pnlRecommendedFreelancers.ResumeLayout(false);
            this.pnlPastProjects.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.PictureBox pictureBox1;
        private Guna.UI2.WinForms.Guna2TileButton AddProject;
        private System.Windows.Forms.Panel pnlOngoingProjectsContainer;
        private System.Windows.Forms.FlowLayoutPanel flpOngoingProjects;
        private Guna.UI2.WinForms.Guna2TileButton ScrollOPBtn2;
        private Guna.UI2.WinForms.Guna2TileButton ScrollOPBtn1;
        private System.Windows.Forms.Timer ScrollTimer;
        private Guna.UI2.WinForms.Guna2CircleButton Profile;
        private System.Windows.Forms.Panel pnlRecommendedFreelancers;
        private System.Windows.Forms.FlowLayoutPanel flpRecommendedFreelancers;
        private System.Windows.Forms.Panel pnlPastProjects;
        private System.Windows.Forms.FlowLayoutPanel flpPastProjects;
    }
}
