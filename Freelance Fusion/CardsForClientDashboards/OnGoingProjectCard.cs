using Guna.UI2.AnimatorNS;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace Freelance_Fusion.CardsForDashboards
{
    public partial class OnGoingProjectCard : UserControl
    {
        public OnGoingProjectCard()
        {
            InitializeComponent();
        }

        public void Populate(CardsForClientDashboards.ProjectClient projectData)
        {
            ProjectTitleRichTB.Text = projectData.Title;
            ProjectDesRichTB.Text = projectData.Description;
            MyPriceRichTB.Text = $"Rs. {projectData.ExpectedPrice:N0}"; // Format with commas
            ToPayRichTB.Text = $"Rs. {projectData.FinalPrice:N0}";
            StartDateRichTB.Text = projectData.StartDate.ToString("dd/MM/yyyy");
            DeadlineRichTB.Text = projectData.Deadline.ToString("dd/MM/yyyy");
            ProgressPercentageRichTB.Text = projectData.Progress.ToString() + "%";
            // Assuming you are using a Guna2RatingStar control
            // ratingControl.Value = (float)projectData.Rating;

            // Dynamically create and add tags
            flpTags.Controls.Clear();
            foreach (var tag in projectData.KeySkillsTags)
            {
                Label tagLabel = new Label();
                tagLabel.Text = tag;
                tagLabel.AutoSize = true;
                tagLabel.BackColor = Color.LightGray;
                tagLabel.Margin = new Padding(3);
                flpTags.Controls.Add(tagLabel);
            }
        }
    }
}
