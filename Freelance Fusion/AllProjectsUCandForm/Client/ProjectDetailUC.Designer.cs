namespace Freelance_Fusion.AllProjectsUCandForm
{
    partial class ProjectDetailUC
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ProjectDetailUC));
            this.RTProjectTitle = new System.Windows.Forms.RichTextBox();
            this.ProjectDesRichTB = new System.Windows.Forms.RichTextBox();
            this.flpTags = new System.Windows.Forms.FlowLayoutPanel();
            this.RTDetailProjectDescription = new System.Windows.Forms.RichTextBox();
            this.RTDeadline = new System.Windows.Forms.RichTextBox();
            this.RTStartDate = new System.Windows.Forms.RichTextBox();
            this.RTReviews = new System.Windows.Forms.RichTextBox();
            this.RTDeliverables = new System.Windows.Forms.RichTextBox();
            this.RTExpectedPrice = new System.Windows.Forms.RichTextBox();
            this.RTAveragePrice = new System.Windows.Forms.RichTextBox();
            this.flpBids = new System.Windows.Forms.FlowLayoutPanel();
            this.progressBar = new System.Windows.Forms.RichTextBox();
            this.RTRequiredSkiils = new Guna.UI2.WinForms.Guna2TextBox();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // RTProjectTitle
            // 
            this.RTProjectTitle.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(240)))), ((int)(((byte)(240)))), ((int)(((byte)(240)))));
            this.RTProjectTitle.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.RTProjectTitle.Cursor = System.Windows.Forms.Cursors.Arrow;
            this.RTProjectTitle.DetectUrls = false;
            this.RTProjectTitle.Font = new System.Drawing.Font("Microsoft Sans Serif", 36F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.RTProjectTitle.Location = new System.Drawing.Point(117, 145);
            this.RTProjectTitle.Multiline = false;
            this.RTProjectTitle.Name = "RTProjectTitle";
            this.RTProjectTitle.ReadOnly = true;
            this.RTProjectTitle.ScrollBars = System.Windows.Forms.RichTextBoxScrollBars.None;
            this.RTProjectTitle.Size = new System.Drawing.Size(1072, 59);
            this.RTProjectTitle.TabIndex = 1;
            this.RTProjectTitle.Text = "Project Name ";
            // 
            // ProjectDesRichTB
            // 
            this.ProjectDesRichTB.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(240)))), ((int)(((byte)(240)))), ((int)(((byte)(240)))));
            this.ProjectDesRichTB.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.ProjectDesRichTB.Cursor = System.Windows.Forms.Cursors.Arrow;
            this.ProjectDesRichTB.Font = new System.Drawing.Font("Arial", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ProjectDesRichTB.Location = new System.Drawing.Point(117, 210);
            this.ProjectDesRichTB.Name = "ProjectDesRichTB";
            this.ProjectDesRichTB.ReadOnly = true;
            this.ProjectDesRichTB.ScrollBars = System.Windows.Forms.RichTextBoxScrollBars.Horizontal;
            this.ProjectDesRichTB.Size = new System.Drawing.Size(1072, 76);
            this.ProjectDesRichTB.TabIndex = 3;
            this.ProjectDesRichTB.Text = "Project description";
            this.ProjectDesRichTB.TextChanged += new System.EventHandler(this.ProjectDesRichTB_TextChanged);
            // 
            // flpTags
            // 
            this.flpTags.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(240)))), ((int)(((byte)(240)))), ((int)(((byte)(240)))));
            this.flpTags.Location = new System.Drawing.Point(117, 292);
            this.flpTags.Name = "flpTags";
            this.flpTags.Size = new System.Drawing.Size(1072, 92);
            this.flpTags.TabIndex = 11;
            this.flpTags.Paint += new System.Windows.Forms.PaintEventHandler(this.flpTags_Paint);
            // 
            // RTDetailProjectDescription
            // 
            this.RTDetailProjectDescription.BackColor = System.Drawing.Color.White;
            this.RTDetailProjectDescription.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.RTDetailProjectDescription.Cursor = System.Windows.Forms.Cursors.Arrow;
            this.RTDetailProjectDescription.Font = new System.Drawing.Font("Arial", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.RTDetailProjectDescription.Location = new System.Drawing.Point(117, 432);
            this.RTDetailProjectDescription.Name = "RTDetailProjectDescription";
            this.RTDetailProjectDescription.ReadOnly = true;
            this.RTDetailProjectDescription.ScrollBars = System.Windows.Forms.RichTextBoxScrollBars.Horizontal;
            this.RTDetailProjectDescription.Size = new System.Drawing.Size(1091, 140);
            this.RTDetailProjectDescription.TabIndex = 12;
            this.RTDetailProjectDescription.Text = "Project description";
            this.RTDetailProjectDescription.TextChanged += new System.EventHandler(this.RTDetailProjectDescription_TextChanged);
            // 
            // RTDeadline
            // 
            this.RTDeadline.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(240)))), ((int)(((byte)(240)))), ((int)(((byte)(240)))));
            this.RTDeadline.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.RTDeadline.Cursor = System.Windows.Forms.Cursors.Default;
            this.RTDeadline.Font = new System.Drawing.Font("Arial", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.RTDeadline.ForeColor = System.Drawing.Color.Red;
            this.RTDeadline.Location = new System.Drawing.Point(209, 821);
            this.RTDeadline.Name = "RTDeadline";
            this.RTDeadline.ReadOnly = true;
            this.RTDeadline.ScrollBars = System.Windows.Forms.RichTextBoxScrollBars.Horizontal;
            this.RTDeadline.Size = new System.Drawing.Size(151, 24);
            this.RTDeadline.TabIndex = 14;
            this.RTDeadline.Text = "None";
            this.RTDeadline.TextChanged += new System.EventHandler(this.RTDeadline_TextChanged);
            // 
            // RTStartDate
            // 
            this.RTStartDate.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(240)))), ((int)(((byte)(240)))), ((int)(((byte)(240)))));
            this.RTStartDate.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.RTStartDate.Cursor = System.Windows.Forms.Cursors.Default;
            this.RTStartDate.Font = new System.Drawing.Font("Arial", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.RTStartDate.ForeColor = System.Drawing.Color.Black;
            this.RTStartDate.Location = new System.Drawing.Point(222, 798);
            this.RTStartDate.Name = "RTStartDate";
            this.RTStartDate.ReadOnly = true;
            this.RTStartDate.ScrollBars = System.Windows.Forms.RichTextBoxScrollBars.Horizontal;
            this.RTStartDate.Size = new System.Drawing.Size(151, 24);
            this.RTStartDate.TabIndex = 15;
            this.RTStartDate.Text = "None";
            this.RTStartDate.TextChanged += new System.EventHandler(this.RTStartDate_TextChanged);
            // 
            // RTReviews
            // 
            this.RTReviews.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(240)))), ((int)(((byte)(240)))), ((int)(((byte)(240)))));
            this.RTReviews.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.RTReviews.Cursor = System.Windows.Forms.Cursors.Default;
            this.RTReviews.Font = new System.Drawing.Font("Arial", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.RTReviews.ForeColor = System.Drawing.Color.Black;
            this.RTReviews.Location = new System.Drawing.Point(205, 845);
            this.RTReviews.Name = "RTReviews";
            this.RTReviews.ReadOnly = true;
            this.RTReviews.ScrollBars = System.Windows.Forms.RichTextBoxScrollBars.Horizontal;
            this.RTReviews.Size = new System.Drawing.Size(984, 24);
            this.RTReviews.TabIndex = 16;
            this.RTReviews.Text = "None";
            this.RTReviews.TextChanged += new System.EventHandler(this.RTReviews_TextChanged);
            // 
            // RTDeliverables
            // 
            this.RTDeliverables.BackColor = System.Drawing.Color.White;
            this.RTDeliverables.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.RTDeliverables.Cursor = System.Windows.Forms.Cursors.Arrow;
            this.RTDeliverables.Font = new System.Drawing.Font("Arial", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.RTDeliverables.Location = new System.Drawing.Point(117, 920);
            this.RTDeliverables.Name = "RTDeliverables";
            this.RTDeliverables.ReadOnly = true;
            this.RTDeliverables.ScrollBars = System.Windows.Forms.RichTextBoxScrollBars.Horizontal;
            this.RTDeliverables.Size = new System.Drawing.Size(1072, 154);
            this.RTDeliverables.TabIndex = 17;
            this.RTDeliverables.Text = "All project Deliverables";
            this.RTDeliverables.TextChanged += new System.EventHandler(this.RTDeliverables_TextChanged);
            // 
            // RTExpectedPrice
            // 
            this.RTExpectedPrice.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(240)))), ((int)(((byte)(240)))), ((int)(((byte)(240)))));
            this.RTExpectedPrice.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.RTExpectedPrice.Cursor = System.Windows.Forms.Cursors.Default;
            this.RTExpectedPrice.Font = new System.Drawing.Font("Arial", 24F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.RTExpectedPrice.ForeColor = System.Drawing.Color.Black;
            this.RTExpectedPrice.Location = new System.Drawing.Point(140, 1121);
            this.RTExpectedPrice.Name = "RTExpectedPrice";
            this.RTExpectedPrice.ReadOnly = true;
            this.RTExpectedPrice.ScrollBars = System.Windows.Forms.RichTextBoxScrollBars.Horizontal;
            this.RTExpectedPrice.Size = new System.Drawing.Size(200, 43);
            this.RTExpectedPrice.TabIndex = 18;
            this.RTExpectedPrice.Text = "None";
            this.RTExpectedPrice.TextChanged += new System.EventHandler(this.RTExpectedPrice_TextChanged);
            // 
            // RTAveragePrice
            // 
            this.RTAveragePrice.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(240)))), ((int)(((byte)(240)))), ((int)(((byte)(240)))));
            this.RTAveragePrice.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.RTAveragePrice.Cursor = System.Windows.Forms.Cursors.Default;
            this.RTAveragePrice.Font = new System.Drawing.Font("Arial", 24F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.RTAveragePrice.ForeColor = System.Drawing.Color.Black;
            this.RTAveragePrice.Location = new System.Drawing.Point(375, 1121);
            this.RTAveragePrice.Name = "RTAveragePrice";
            this.RTAveragePrice.ReadOnly = true;
            this.RTAveragePrice.ScrollBars = System.Windows.Forms.RichTextBoxScrollBars.Horizontal;
            this.RTAveragePrice.Size = new System.Drawing.Size(202, 43);
            this.RTAveragePrice.TabIndex = 19;
            this.RTAveragePrice.Text = "None";
            this.RTAveragePrice.TextChanged += new System.EventHandler(this.RTAveragePrice_TextChanged);
            // 
            // flpBids
            // 
            this.flpBids.BackColor = System.Drawing.Color.White;
            this.flpBids.Location = new System.Drawing.Point(117, 1487);
            this.flpBids.Name = "flpBids";
            this.flpBids.Size = new System.Drawing.Size(1146, 319);
            this.flpBids.TabIndex = 12;
            // 
            // progressBar
            // 
            this.progressBar.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(240)))), ((int)(((byte)(240)))), ((int)(((byte)(240)))));
            this.progressBar.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.progressBar.Cursor = System.Windows.Forms.Cursors.Default;
            this.progressBar.Font = new System.Drawing.Font("Arial", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.progressBar.ForeColor = System.Drawing.Color.Black;
            this.progressBar.Location = new System.Drawing.Point(627, 1344);
            this.progressBar.Name = "progressBar";
            this.progressBar.ReadOnly = true;
            this.progressBar.ScrollBars = System.Windows.Forms.RichTextBoxScrollBars.Horizontal;
            this.progressBar.Size = new System.Drawing.Size(58, 27);
            this.progressBar.TabIndex = 20;
            this.progressBar.Text = "None";
            // 
            // RTRequiredSkiils
            // 
            this.RTRequiredSkiils.Animated = true;
            this.RTRequiredSkiils.AutoScroll = true;
            this.RTRequiredSkiils.BackColor = System.Drawing.Color.White;
            this.RTRequiredSkiils.BorderColor = System.Drawing.Color.Silver;
            this.RTRequiredSkiils.BorderRadius = 5;
            this.RTRequiredSkiils.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.RTRequiredSkiils.DefaultText = "";
            this.RTRequiredSkiils.DisabledState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(208)))), ((int)(((byte)(208)))), ((int)(((byte)(208)))));
            this.RTRequiredSkiils.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(226)))), ((int)(((byte)(226)))), ((int)(((byte)(226)))));
            this.RTRequiredSkiils.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.RTRequiredSkiils.DisabledState.PlaceholderForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.RTRequiredSkiils.FocusedState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(51)))), ((int)(((byte)(43)))), ((int)(((byte)(1)))));
            this.RTRequiredSkiils.Font = new System.Drawing.Font("Arial", 15.75F);
            this.RTRequiredSkiils.ForeColor = System.Drawing.Color.Black;
            this.RTRequiredSkiils.HoverState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.RTRequiredSkiils.Location = new System.Drawing.Point(117, 613);
            this.RTRequiredSkiils.Margin = new System.Windows.Forms.Padding(6, 5, 6, 5);
            this.RTRequiredSkiils.Multiline = true;
            this.RTRequiredSkiils.Name = "RTRequiredSkiils";
            this.RTRequiredSkiils.PasswordChar = '\0';
            this.RTRequiredSkiils.PlaceholderText = "Tell about your experience, and services, etc.";
            this.RTRequiredSkiils.SelectedText = "";
            this.RTRequiredSkiils.Size = new System.Drawing.Size(1091, 140);
            this.RTRequiredSkiils.TabIndex = 23;
            this.RTRequiredSkiils.TextChanged += new System.EventHandler(this.RTRequiredSkiils_TextChanged);
            // 
            // pictureBox1
            // 
            this.pictureBox1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pictureBox1.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox1.Image")));
            this.pictureBox1.Location = new System.Drawing.Point(0, 0);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(1334, 1828);
            this.pictureBox1.TabIndex = 0;
            this.pictureBox1.TabStop = false;
            // 
            // ProjectDetailUC
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.RTRequiredSkiils);
            this.Controls.Add(this.progressBar);
            this.Controls.Add(this.flpBids);
            this.Controls.Add(this.RTAveragePrice);
            this.Controls.Add(this.RTExpectedPrice);
            this.Controls.Add(this.RTDeliverables);
            this.Controls.Add(this.RTReviews);
            this.Controls.Add(this.RTStartDate);
            this.Controls.Add(this.RTDeadline);
            this.Controls.Add(this.RTDetailProjectDescription);
            this.Controls.Add(this.flpTags);
            this.Controls.Add(this.ProjectDesRichTB);
            this.Controls.Add(this.RTProjectTitle);
            this.Controls.Add(this.pictureBox1);
            this.Name = "ProjectDetailUC";
            this.Size = new System.Drawing.Size(1334, 1828);
            this.Load += new System.EventHandler(this.ProjectDetailUC_Load);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.RichTextBox RTProjectTitle;
        private System.Windows.Forms.RichTextBox ProjectDesRichTB;
        private System.Windows.Forms.FlowLayoutPanel flpTags;
        private System.Windows.Forms.RichTextBox RTDetailProjectDescription;
        private System.Windows.Forms.RichTextBox RTDeadline;
        private System.Windows.Forms.RichTextBox RTStartDate;
        private System.Windows.Forms.RichTextBox RTReviews;
        private System.Windows.Forms.RichTextBox RTDeliverables;
        private System.Windows.Forms.RichTextBox RTExpectedPrice;
        private System.Windows.Forms.RichTextBox RTAveragePrice;
        private System.Windows.Forms.FlowLayoutPanel flpBids;
        private System.Windows.Forms.RichTextBox progressBar;
        private Guna.UI2.WinForms.Guna2TextBox RTRequiredSkiils;
    }
}
