using Freelance_Fusion.CardsForClientDashboards;
using Freelance_Fusion.Events;
using Freelance_Fusion.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Freelance_Fusion.CardsForFreelancerDashboard
{
    public partial class RecommendedProjectCard : UserControl
    {
        private ProjectClient _projectData;
        public event EventHandler<ProjectEventArgs> CardClicked;
        public RecommendedProjectCard()
        {
            InitializeComponent();
            this.Cursor = Cursors.Hand;
            this.Click += OnCard_Click;
        }
        public void WireClickEvents()
        {
            AttachClickEventRecursive(this);
        }
        private void AttachClickEventRecursive(Control parent)
        {
            parent.Click += OnCard_Click;
            foreach (Control control in parent.Controls)
            {
                AttachClickEventRecursive(control);
            }
        }
        public void Populate(CardsForClientDashboards.ProjectClient projectData)
        {
            _projectData = projectData;
            ProjectTitleRichTB.Text = projectData.Title;
            ProjectDesRichTB.Text = projectData.Description;
            MyPriceRichTB.Text = $"Rs. {projectData.ExpectedPrice:N0}"; // Format with commas
            StartDateRichTB.Text = projectData.StartDate.ToString("dd/MM/yyyy");
            DeadlineRichTB.Text = projectData.Deadline.ToString("dd/MM/yyyy");
            // Assuming you are using a Guna2RatingStar control
            // ratingControl.Value = (float)projectData.Rating;

            // Dynamically create and add tags
            flpTags.Controls.Clear();
            foreach (var tag in projectData.KeySkillsTags)
            {
                Label tagLabel = new Label
                {
                    Text = tag,
                    AutoSize = true,
                    BackColor = Color.FromArgb(224, 224, 224), // A light grey
                    ForeColor = Color.FromArgb(64, 64, 64),
                    Margin = new Padding(3),
                    Padding = new Padding(5, 3, 5, 3),
                    Font = new Font("Segoe UI", 8F)
                };
                flpTags.Controls.Add(tagLabel);
            }
        }
        private void OnCard_Click(object sender, EventArgs e)
        {
            if (_projectData != null)
            {
                CardClicked?.Invoke(this, new ProjectEventArgs(_projectData));
            }
        }

        private void BtnBid_Click(object sender, EventArgs e)
        {
            
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            if (_projectData != null)
            {
                CardClicked?.Invoke(this, new ProjectEventArgs(_projectData));
            }
        }
    }
}
