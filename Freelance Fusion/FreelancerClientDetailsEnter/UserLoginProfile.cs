using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Freelance_Fusion.FreelancerClientDetailsEnter
{
    internal class UserLoginProfile
    {
        [JsonProperty("Email")]
        public string Email { get; set; }

        [JsonProperty("UserType")]
        public string UserType { get; set; }

        [JsonProperty("IsProfileComplete")]
        public bool IsProfileComplete { get; set; }
    }
}
