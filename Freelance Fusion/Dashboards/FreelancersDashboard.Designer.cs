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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FreelancersDashboard));
            this.ClientBtn = new Guna.UI2.WinForms.Guna2Button();
            this.BtnProfile = new Guna.UI2.WinForms.Guna2CircleButton();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.pnlOngoingProjectsContainer = new System.Windows.Forms.Panel();
            this.flpOngoingProjects = new System.Windows.Forms.FlowLayoutPanel();
            this.pnlRecommendedProjectsContainer = new System.Windows.Forms.Panel();
            this.flpRecommendedProjects = new System.Windows.Forms.FlowLayoutPanel();
            this.pnlCompletedProjects = new System.Windows.Forms.Panel();
            this.flpCompletedProjects = new System.Windows.Forms.FlowLayoutPanel();
            this.btnRecScrollRight = new Guna.UI2.WinForms.Guna2TileButton();
            this.btnRecScrollLeft = new Guna.UI2.WinForms.Guna2TileButton();
            this.scrollTimer = new System.Windows.Forms.Timer(this.components);
            this.OngoingScroll = new Guna.UI2.WinForms.Guna2TileButton();
            this.ongoingScrollTimer = new System.Windows.Forms.Timer(this.components);
            this.lblClicktoLogout = new System.Windows.Forms.Label();
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
            // BtnProfile
            // 
            this.BtnProfile.BackgroundImage = global::Freelance_Fusion.Properties.Resources.Vector;
            this.BtnProfile.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.BtnProfile.DisabledState.BorderColor = System.Drawing.Color.DarkGray;
            this.BtnProfile.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray;
            this.BtnProfile.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
            this.BtnProfile.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(141)))), ((int)(((byte)(141)))), ((int)(((byte)(141)))));
            this.BtnProfile.FillColor = System.Drawing.Color.Transparent;
            this.BtnProfile.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.BtnProfile.ForeColor = System.Drawing.Color.White;
            this.BtnProfile.Location = new System.Drawing.Point(1248, 15);
            this.BtnProfile.Name = "BtnProfile";
            this.BtnProfile.ShadowDecoration.Mode = Guna.UI2.WinForms.Enums.ShadowMode.Circle;
            this.BtnProfile.Size = new System.Drawing.Size(58, 61);
            this.BtnProfile.TabIndex = 39;
            this.BtnProfile.Click += new System.EventHandler(this.BtnProfile_Click);
            this.BtnProfile.MouseLeave += new System.EventHandler(this.BtnProfile_MouseLeave);
            this.BtnProfile.MouseHover += new System.EventHandler(this.BtnProfile_MouseHover);
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
            this.pictureBox1.DoubleClick += new System.EventHandler(this.pictureBox1_DoubleClick);
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
            this.pnlRecommendedProjectsContainer.Size = new System.Drawing.Size(1182, 499);
            this.pnlRecommendedProjectsContainer.TabIndex = 41;
            // 
            // flpRecommendedProjects
            // 
            this.flpRecommendedProjects.AutoScroll = true;
            this.flpRecommendedProjects.Dock = System.Windows.Forms.DockStyle.Fill;
            this.flpRecommendedProjects.Location = new System.Drawing.Point(0, 0);
            this.flpRecommendedProjects.Name = "flpRecommendedProjects";
            this.flpRecommendedProjects.Size = new System.Drawing.Size(1182, 499);
            this.flpRecommendedProjects.TabIndex = 0;
            this.flpRecommendedProjects.WrapContents = false;
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
            // btnRecScrollRight
            // 
            this.btnRecScrollRight.Animated = true;
            this.btnRecScrollRight.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnRecScrollRight.BackgroundImage")));
            this.btnRecScrollRight.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.btnRecScrollRight.DisabledState.BorderColor = System.Drawing.Color.DarkGray;
            this.btnRecScrollRight.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray;
            this.btnRecScrollRight.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
            this.btnRecScrollRight.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(141)))), ((int)(((byte)(141)))), ((int)(((byte)(141)))));
            this.btnRecScrollRight.FillColor = System.Drawing.Color.Transparent;
            this.btnRecScrollRight.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.btnRecScrollRight.ForeColor = System.Drawing.Color.White;
            this.btnRecScrollRight.Location = new System.Drawing.Point(1275, 1553);
            this.btnRecScrollRight.Name = "btnRecScrollRight";
            this.btnRecScrollRight.Size = new System.Drawing.Size(24, 57);
            this.btnRecScrollRight.TabIndex = 43;
            this.btnRecScrollRight.MouseDown += new System.Windows.Forms.MouseEventHandler(this.btnRecScrollRight_MouseDown);
            this.btnRecScrollRight.MouseUp += new System.Windows.Forms.MouseEventHandler(this.btnRecScrollRight_MouseUp);
            // 
            // btnRecScrollLeft
            // 
            this.btnRecScrollLeft.Animated = true;
            this.btnRecScrollLeft.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnRecScrollLeft.BackgroundImage")));
            this.btnRecScrollLeft.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.btnRecScrollLeft.DisabledState.BorderColor = System.Drawing.Color.DarkGray;
            this.btnRecScrollLeft.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray;
            this.btnRecScrollLeft.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
            this.btnRecScrollLeft.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(141)))), ((int)(((byte)(141)))), ((int)(((byte)(141)))));
            this.btnRecScrollLeft.FillColor = System.Drawing.Color.Transparent;
            this.btnRecScrollLeft.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.btnRecScrollLeft.ForeColor = System.Drawing.Color.White;
            this.btnRecScrollLeft.Location = new System.Drawing.Point(57, 1554);
            this.btnRecScrollLeft.Name = "btnRecScrollLeft";
            this.btnRecScrollLeft.Size = new System.Drawing.Size(24, 56);
            this.btnRecScrollLeft.TabIndex = 44;
            // 
            // scrollTimer
            // 
            this.scrollTimer.Tick += new System.EventHandler(this.scrollTimer_Tick);
            // 
            // OngoingScroll
            // 
            this.OngoingScroll.Animated = true;
            this.OngoingScroll.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("OngoingScroll.BackgroundImage")));
            this.OngoingScroll.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.OngoingScroll.DisabledState.BorderColor = System.Drawing.Color.DarkGray;
            this.OngoingScroll.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray;
            this.OngoingScroll.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
            this.OngoingScroll.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(141)))), ((int)(((byte)(141)))), ((int)(((byte)(141)))));
            this.OngoingScroll.FillColor = System.Drawing.Color.Transparent;
            this.OngoingScroll.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.OngoingScroll.ForeColor = System.Drawing.Color.White;
            this.OngoingScroll.Location = new System.Drawing.Point(1275, 468);
            this.OngoingScroll.Name = "OngoingScroll";
            this.OngoingScroll.Size = new System.Drawing.Size(24, 57);
            this.OngoingScroll.TabIndex = 45;
            this.OngoingScroll.MouseDown += new System.Windows.Forms.MouseEventHandler(this.OngoingScroll_MouseDown);
            this.OngoingScroll.MouseUp += new System.Windows.Forms.MouseEventHandler(this.OngoingScroll_MouseUp);
            // 
            // ongoingScrollTimer
            // 
            this.ongoingScrollTimer.Tick += new System.EventHandler(this.ongoingScrollTimer_Tick);
            // 
            // lblClicktoLogout
            // 
            this.lblClicktoLogout.AutoSize = true;
            this.lblClicktoLogout.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblClicktoLogout.Location = new System.Drawing.Point(1127, 38);
            this.lblClicktoLogout.Name = "lblClicktoLogout";
            this.lblClicktoLogout.Size = new System.Drawing.Size(115, 18);
            this.lblClicktoLogout.TabIndex = 46;
            this.lblClicktoLogout.Text = "Click to Log Out";
            this.lblClicktoLogout.Visible = false;
            // 
            // FreelancersDashboard
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.lblClicktoLogout);
            this.Controls.Add(this.OngoingScroll);
            this.Controls.Add(this.btnRecScrollLeft);
            this.Controls.Add(this.btnRecScrollRight);
            this.Controls.Add(this.pnlCompletedProjects);
            this.Controls.Add(this.pnlRecommendedProjectsContainer);
            this.Controls.Add(this.pnlOngoingProjectsContainer);
            this.Controls.Add(this.BtnProfile);
            this.Controls.Add(this.ClientBtn);
            this.Controls.Add(this.pictureBox1);
            this.Name = "FreelancersDashboard";
            this.Size = new System.Drawing.Size(1334, 2560);
            this.Load += new System.EventHandler(this.FreelancersDashboard_Load);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.pnlOngoingProjectsContainer.ResumeLayout(false);
            this.pnlRecommendedProjectsContainer.ResumeLayout(false);
            this.pnlCompletedProjects.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PictureBox pictureBox1;
        private Guna.UI2.WinForms.Guna2Button ClientBtn;
        private Guna.UI2.WinForms.Guna2CircleButton BtnProfile;
        private System.Windows.Forms.Panel pnlOngoingProjectsContainer;
        private System.Windows.Forms.FlowLayoutPanel flpOngoingProjects;
        private System.Windows.Forms.Panel pnlRecommendedProjectsContainer;
        private System.Windows.Forms.FlowLayoutPanel flpRecommendedProjects;
        private System.Windows.Forms.Panel pnlCompletedProjects;
        private System.Windows.Forms.FlowLayoutPanel flpCompletedProjects;
        private Guna.UI2.WinForms.Guna2TileButton btnRecScrollRight;
        private Guna.UI2.WinForms.Guna2TileButton btnRecScrollLeft;
        private System.Windows.Forms.Timer scrollTimer;
        private Guna.UI2.WinForms.Guna2TileButton OngoingScroll;
        private System.Windows.Forms.Timer ongoingScrollTimer;
        private System.Windows.Forms.Label lblClicktoLogout;
    }
}
