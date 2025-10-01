using Firebase.Database;
using Firebase.Database.Query;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Freelance_Fusion.PostProjectandSeeProjects
{
    public partial class AddProjectClient : UserControl
    {
        private readonly FirebaseClient _authenticatedClient;
        private readonly string _uid; // This is the Client's User ID

        // Event to signal that a new project has been successfully posted
        public event EventHandler ProjectPosted; // You can enhance this with ProjectEventArgs later

        public AddProjectClient(FirebaseClient authenticatedClient, string uid)
        {
            InitializeComponent();
            _authenticatedClient = authenticatedClient;
            _uid = uid;
        }

        private async void Post_Project_Click(object sender, EventArgs e)
        {
            // You can add validation logic here later, similar to the Register form.
            // For now, we will proceed directly to saving.

            try
            {

                string skillsInput = "C#, .NET core, React, SQL Server, Firebase"; // This would come from your textbox, txtTags.Text
                List<string> skillsList = skillsInput.Split(',').Select(s => s.Trim()).ToList();
                // 1. Create a Dictionary to hold all the project data, just like in Freelancer_questionaries.
                // The values are preset with sample data based on your screenshot.
                var projectData = new Dictionary<string, object>
                {
                    // --- Core Information ---
                    ["ClientID"] = _uid, // Links the project to the currently logged-in client
                    ["Title"] = FirstNameTB.Text,
                    ["Description"] = "Create a fast and responsive online store for selling handmade crafts.",
                    ["KeySkillsTags"] = skillsList,
                    ["DetailedDescription"] = "The project involves developing a full-stack web application. The frontend should be built with a modern framework like React or Vue, and the backend needs to handle product management, orders, and user authentication.",

                    // --- Skills & Deliverables ---
                    // The UI suggests these are multi-line, so we'll store them as a list of strings.
                    ["RequiredSkills"] = new List<string> {
    "Proficient in Kotlin or Java for native Android app development, including experience with Android Studio and modern Android architecture components (ViewModel, LiveData, Navigation)",
    "UI/UX design for fitness applications, with skills in Material Design principles and custom view creation for interactive fitness tracking interfaces",
    "Integration of fitness tracking sensors and APIs, including Google Fit API, accelerometer, gyroscope, and heart rate sensor for real-time activity monitoring",
    "Implementation of Firebase for user authentication, real-time database, cloud messaging (push notifications), analytics, and cloud storage",
    "RESTful API integration for synchronizing workout data, fetching exercise recommendations, and connecting with health/wellness databases",
    "Knowledge of local storage solutions such as Room Database for offline fitness progress tracking and workout history",
    "Experience with wearable device integration (e.g., Wear OS, Bluetooth LE devices) for advanced fitness tracking and synchronization",
    "Skills in building personalized workout algorithms and progress analytics using Android's background processing tools and dedicated services",
    "Implementation of gamification elements (badges, points, leaderboards) to enhance user engagement in the fitness app",
    "Applying security and privacy best practices, including data encryption, secure storage of fitness/health data, and compliance with privacy regulations (GDPR, HIPAA if supporting medical data)" },

                    ["Deliverables"] = new List<string> { "Complete Source Code", "Deployment to a live server", "User documentation" },

                    // --- Timeline & Price ---
                    ["StartDate"] = DateTime.UtcNow.ToString("o"), // Use ISO 8601 format for consistency
                    ["Deadline"] = DateTime.UtcNow.AddDays(60).ToString("o"),
                    ["ExpectedPrice"] = 75000,

                    // --- Project State ---
                    ["Status"] = "Open", // Initial status for a newly posted project
                    ["PostDate"] = DateTime.UtcNow.ToString("o"),
                    ["Progress"] = 0, // New projects start at 0% progress
                    ["Rating"] = 0.0 // New projects have no rating yet
                };

                // 2. Save the Project to Firebase using PostAsync.
                // This creates a new entry in a "projects" collection with a unique random ID.
                var result = await _authenticatedClient
                    .Child("projects")
                    .PostAsync(projectData);

                // 3. (Recommended) Add the new unique ID back into the project data itself.
                // This makes it easier to find and manage the project later.
                string newProjectId = result.Key;
                await _authenticatedClient
                    .Child("projects")
                    .Child(newProjectId)
                    .PatchAsync(new Dictionary<string, object> { { "ProjectID", newProjectId } });

                // --- NEW SCALABLE APPROACH ---
                // Step 3: Add a reference (the Project ID) to the client's own list of posted projects.
                // This creates an index for efficient fetching later.
                await _authenticatedClient
                    .Child("users")
                    .Child(_uid) // The current client's user ID
                    .Child("postedProjects") // A new node to store their project IDs
                    .Child(newProjectId) // Use the project ID as the key
                    .PutAsync(true); // Store a simple boolean 'true' as the value

                MessageBox.Show("Your project has been posted successfully!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                ProjectPosted?.Invoke(this, EventArgs.Empty);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"An error occurred while posting the project: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
