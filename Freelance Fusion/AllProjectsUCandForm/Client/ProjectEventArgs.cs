using Freelance_Fusion.CardsForClientDashboards;
using System;

namespace Freelance_Fusion.Events
{
    public class ProjectEventArgs : EventArgs
    {
        public ProjectClient Project { get; }

        public ProjectEventArgs(ProjectClient project)
        {
            Project = project;
        }
    }
}

