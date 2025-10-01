using Freelance_Fusion.CardsForClientDashboards;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Freelance_Fusion.AllProjectsUCandForm
{
    public partial class ProjectDetailUC : UserControl
    {
        public ProjectDetailUC(CardsForClientDashboards.ProjectClient project)
        {
            InitializeComponent();
            PopulateDetails(project);
        }

        private void PopulateDetails(ProjectClient project)
        {
            RTProjectTitle.Text = project.Title;
            ProjectDesRichTB.Text = project.Description; // Brief description

            // Populate Tags
            flpTags.Controls.Clear();
            foreach (var tag in project.KeySkillsTags)
            {
                Label tagLabel = new Label
                {
                    Text = tag,
                    AutoSize = true,
                    BackColor = Color.FromArgb(224, 224, 224),
                    ForeColor = Color.FromArgb(64, 64, 64),
                    Margin = new Padding(3),
                    Padding = new Padding(5, 3, 5, 3),
                    Font = new Font("Segoe UI", 8F)
                };
                flpTags.Controls.Add(tagLabel);
            }

            // --- CORRECTED DATA BINDING ---
            // Now we use the new properties from the updated ProjectClient model.
            RTDetailProjectDescription.Text = project.DetailedDescription;

            // Format lists with bullet points for clean display
            RTRequiredSkiils.Text = "• " + string.Join("\n• ", project.RequiredSkills);
            RTDeliverables.Text = "• " + string.Join("\n• ", project.Deliverables);

            RTStartDate.Text = $"Start Date: {project.StartDate:dd MMM yyyy}";
            RTDeadline.Text = $"Deadline: {project.Deadline:dd MMM yyyy}";
            RTExpectedPrice.Text = $"{project.ExpectedPrice:N0}";
            progressBar.Text = project.Progress.ToString() + "%";
        }
    }
}
