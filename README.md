# Freelance Fusion
Freelance Fusion is a marketplace platform designed to bridge the gap between talented freelancers and clients. Built with a focus on seamless interaction, this application allows users to manage projects, submit proposals, and build professional relationships through a robust feedback system.

<img width="1353" height="926" alt="Screenshot 2026-02-04 115548" src="https://github.com/user-attachments/assets/18eb8e2a-1f6c-4051-a53b-63de6c5b7118" />

https://github.com/user-attachments/assets/c01be898-14ec-4ff2-ada3-8f733c61e96f


## Features

- **Dual-User System:** Separate, specialized experiences for both Clients and Freelancers.
- **Project Management:** Clients can post projects with specific budgets and skills, while freelancers can browse and bid on them.
- **Bid/Proposal System:** Allows freelancers to submit tailored applications for specific jobs.
- **Interactive Dashboards:** Personalized views for users to track ongoing work, earnings, and recommended projects.
- **Portfolio & Reviews:** Freelancers can showcase their work, and clients can leave ratings/feedback to build trust within the community.
- **Real-time Communication:** Integrated messaging system to handle the nuts and bolts of project collaboration.

## Getting Started

### Prerequisites
1. A PC running Windows OS.
2..NET Framework environment (compatible with NuGet package management).

### Installation
1. Download the Zip file from the latest releases section.
2. Unzip the contents to your preferred folder.
3. Run setup.exe.
4. The application should launch automatically; if not, search for Freelance Fusion in your Start menu.

## Usage
- Register: Create a new account and verify your credentials.
- Post/Browse: Clients can "Unlist/List" projects, while freelancers can "Browse" or "View Projects".
- Propose: Submit a bid on a project that matches your expertise.
- Collaborate: Use the messaging system and dashboard to manage deadlines and deliverables.
- Payment & Review: Handle payments through the integrated system and leave reviews upon project completion.

## Project Structure
- AuthManager.cs - Handles secure user authentication and registration logic.
- User.cs - The base class for identity, inherited by Client and Freelancer.
- Project.cs - The central hub for all job-related data, including budgets and status.
- Dashboard.cs - The "traffic cop" of the UI, directing users to their specific command centers.
- Message.cs - Manages the back-and-forth communication logic.

## Contributing
Contributions are what make the freelance community thrive! To contribute:

1. Fork the repository.
2. Ensure you have the following NuGet packages installed: Firebase, and standard UI frameworks.
3. Implement your changes (we recommend focusing on Code Refactoring or Dependency Updates for preventive maintenance).
4. Submit a pull request for review.

## License
This project is submitted as part of an NCC Education qualification by Ansh Maurya.

Would you like me to generate a specific list of technical requirements or a breakdown of the database schema based on the diagrams?
