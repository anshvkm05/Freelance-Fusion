using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Freelance_Fusion.CardsForClientDashboards
{
    public class ProjectClient
    {
        public string ProjectID { get; set; } // Unique ID for the project
        public string ClientID { get; set; } // The UID of the client who posted it
        public string Title { get; set; }
        public string Description { get; set; }
        public List<string> KeySkillsTags { get; set; }
        public double ExpectedPrice { get; set; }
        public double FinalPrice { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime Deadline { get; set; }
        public int Progress { get; set; } // A value from 0 to 100
        public double Rating { get; set; } // A value from 0 to 5

        public string DetailedDescription { get; set; }
        public List<string> RequiredSkills { get; set; }
        public List<string> Deliverables { get; set; }

        public ProjectClient()
        {
            KeySkillsTags = new List<string>();
        }
    }
}
