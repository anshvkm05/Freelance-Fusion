using System;
using System.Collections.Generic;
using Newtonsoft.Json;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Freelance_Fusion.FreelancerClientDetailsEnter
{
    public class UserProfile
    {
        [JsonProperty("UserType")]
        public string UserType { get; set; }

        [JsonProperty("IsProfileComplete")]
        public bool IsProfileComplete { get; set; }

        // --- Basic Information ---

        /// <summary>
        /// The user's first name.
        /// </summary>
        [JsonProperty("FirstName")]
        public string FirstName { get; set; }

        /// <summary>
        /// The user's last name.
        /// </summary>
        [JsonProperty("LastName")]
        public string LastName { get; set; }

        /// <summary>
        /// The user's selected gender (e.g., "Male", "Female", "Others").
        /// </summary>
        [JsonProperty("Gender")]
        public string Gender { get; set; }

        /// <summary>
        /// The user's age. Stored as an integer for calculations if needed.
        /// </summary>
        [JsonProperty("Age")]
        public int? Age { get; set; }

        /// <summary>
        /// The user's email address.
        /// </summary>
        [JsonProperty("Email")]
        public string Email { get; set; }

        /// <summary>
        /// The user's phone number. Stored as a string to accommodate characters like '+', '(', ')', and '-'.
        /// </summary>
        [JsonProperty("PhoneNumber")]
        public string PhoneNumber { get; set; }

        // --- Skills and Education ---

        /// <summary>
        /// A list of skills provided as keywords.
        /// You would populate this by splitting the text from the "Skills in Keyword" textbox by commas.
        /// </summary>
        [JsonProperty("KeywordSkills")]
        public List<string> KeywordSkills { get; set; }

        /// <summary>
        /// A list of detailed skill descriptions.
        /// You would populate this by splitting the text from the "Skills in Detail" textbox by new lines.
        /// </summary>
        [JsonProperty("DetailedSkills")]
        public List<string> DetailedSkills { get; set; }

        /// <summary>
        /// The user's educational background (e.g., Degree or Course name).
        /// </summary>
        [JsonProperty("Education")]
        public string Education { get; set; }

        // --- About and Projects ---

        /// <summary>
        /// A short, one-line bio about the freelancer.
        /// </summary>
        [JsonProperty("ShortBio")]
        public string ShortBio { get; set; }

        /// <summary>
        /// A longer, more detailed description of the freelancer.
        /// </summary>
        [JsonProperty("LongBio")]
        public string LongBio { get; set; }

        /// <summary>
        /// A list of URLs pointing to the freelancer's projects or portfolio.
        /// </summary>
        [JsonProperty("ProjectLinks")]
        public List<string> ProjectLinks { get; set; }

        /// <summary>
        /// Constructor to initialize the lists, preventing errors if you try to add items to them before they are created.
        /// </summary>
        public UserProfile()
        {
            KeywordSkills = new List<string>();
            DetailedSkills = new List<string>();
            ProjectLinks = new List<string>();
        }
    }
}