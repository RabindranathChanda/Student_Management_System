# 🎓 Student Management System

![GitHub issues](https://img.shields.io/github/issues/RabindranathChanda/Student_Management_System)
![GitHub forks](https://img.shields.io/github/forks/RabindranathChanda/Student_Management_System)
![GitHub stars](https://img.shields.io/github/stars/RabindranathChanda/Student_Management_System)
![GitHub license](https://img.shields.io/github/license/RabindranathChanda/Student_Management_System)
![.NET Framework](https://img.shields.io/badge/.NET%20Framework-4.8.1-blue)
![SQL Server](https://img.shields.io/badge/SQL%20Server-2021-red)
![Build](https://img.shields.io/badge/build-passing-brightgreen)
![Platform](https://img.shields.io/badge/platform-Windows-blue)

> ⚠️ **Development Status:** This project is actively being developed. Features are being added regularly!

A comprehensive Windows desktop application for managing student records, library operations, and school administrative tasks efficiently.

---

## 📖 Overview

**Student Management System** is a feature-rich Windows Forms application built with C# and .NET Framework 4.8.1. It provides an intuitive interface for educational institutions to manage student admissions, library book circulation, student records, and administrative operations from a single unified platform.

**Perfect for:** Small to medium-sized schools, colleges, and training institutes looking for a reliable desktop solution for student data management.

---

## ⚡ Quick Start (5 Minutes)

Want to get up and running fast? Follow these steps:

1. **Clone the repo:**
   ```bash
   git clone https://github.com/RabindranathChanda/Student_Management_System.git
   cd Student_Management_System
   ```

2. **Import database:** Open SSMS and import `Database/School.bacpac` (set database name to "School")

3. **Update connection string:** Edit connection string in `DatabaseSetup.cs` and other `*.cs` files to match your SQL Server instance

4. **Build and run:** Open `SMS.sln` in Visual Studio 2022, press `F5`

5. **Login/Register:** Create an account and start exploring the modules!

> 📖 For detailed setup instructions, see the [full installation guide](#-getting-started) below.

---

## ✨ Key Features

### Core Modules

- 📝 **Student Admission** – Register new students with comprehensive details
- 👨‍🎓 **Student Management** – View, update, and manage student records
- ✏️ **Student Rectification** – Correct and update existing student information
- 🚫 **Student Termination** – Process student exits and archive records

### Library Management

- 📚 **Book Issue** – Issue books to students with tracking
- 📖 **Book Return** – Process book returns and manage due dates
- 📊 **Library Dashboard** – Overview of book circulation and availability

### Administration

- 🔐 **Login/Register System** – Secure authentication for staff members
- 🎯 **Dashboard** – Centralized view of key metrics and quick actions
- ⚙️ **Database Setup** – Built-in database configuration utility
- 🔔 **Toaster Notifications** – User-friendly popup messages for actions

### Additional Features

- 🎨 **Modern UI** – Clean and intuitive Windows Forms interface
- 🔍 **Search & Filter** – Quickly locate student and library records
- 🆔 **Unique ID Generation** – Automatic library card/student ID generation
- 🎨 **Custom Controls** – Enhanced UI components for better user experience

> 🎉 **Open Source & Hacktoberfest Friendly!**  
> We welcome contributions from developers of all skill levels. Join us in making this project better!

---

## 🛠️ Technology Stack

| Component | Technology |
|-----------|-----------|
| **Frontend** | Windows Forms |
| **Language** | C# |
| **Framework** | .NET Framework 4.8.1 |
| **Database** | SQL Server 2019+ |
| **IDE** | Visual Studio 2022 (Recommended) |
| **Version Control** | Git & GitHub |

**Project Structure:**
```
Student_Management_System/
├── SMS/                      # Main application source code
│   ├── AdmissionUC.cs       # Student admission module
│   ├── Student.cs           # Student management module
│   ├── BkIssue.cs          # Library book issue
│   ├── BkReturn.cs         # Library book return
│   ├── Dashboard.cs        # Main dashboard
│   └── DatabaseSetup.cs    # Database configuration
├── Database/                # Database files
│   ├── School.bacpac       # Database backup
│   └── Schema/             # SQL schema and seed data
├── logo/                    # Application icons and logos
└── README.md
```

---

## 📸 Application Preview

### Database Setup in SSMS
<img width="600" height="500" alt="Database Import in SSMS" src="https://github.com/user-attachments/assets/03dd02a2-b7a0-4328-bc86-4360637c53bc" />

### Application Interface
> 📌 **Screenshots Coming Soon!**  
> Help us capture the application interface! Run the project and contribute screenshots by opening a PR.

**Expected Views:**
- 🖥️ Main Dashboard with quick actions and statistics
- 📝 Student Admission Form with validation
- 🔍 Student Management and Search Interface
- 📚 Library Book Issue/Return Forms
- 🔐 Login and Registration Screens
- 🔔 Toaster notification messages

---

## 🚀 Getting Started

### Prerequisites

Ensure you have the following installed on your Windows system:

| Software | Version | Download Link |
|----------|---------|---------------|
| **Windows OS** | 10 or 11 | - |
| **SQL Server** | 2021 (or 2019+) | [Download](https://www.microsoft.com/en-us/sql-server/sql-server-downloads) |
| **SSMS** | Latest | [Download](https://learn.microsoft.com/en-us/sql/ssms/download-sql-server-management-studio-ssms) |
| **Visual Studio** | 2022 | [Download](https://visualstudio.microsoft.com/vs/) |
| **.NET Framework** | 4.8.1 | [Download](https://dotnet.microsoft.com/download/dotnet-framework/net481) |
| **Git** | Latest | [Download](https://git-scm.com/downloads) |

> 💡 **Note:** SQL Server Express (free edition) is sufficient for development and testing.

### 📥 Installation Guide

#### Step 1: Clone the Repository

```bash
git clone https://github.com/RabindranathChanda/Student_Management_System.git
cd Student_Management_System
```

#### Step 2: Database Setup

**Option A: Import using .bacpac file (Recommended)**

1. Open **SQL Server Management Studio (SSMS)**
2. Connect to your SQL Server instance
3. In **Object Explorer**, right-click on **Databases**
4. Select **Import Data-tier Application...**
5. Click **Next** in the wizard
6. Browse to `Database/School.bacpac` in the project folder
7. Set database name as: **`School`**
8. Click **Next** and complete the wizard

**Option B: Run SQL scripts manually**

1. In SSMS, create a new database named `School`
2. Navigate to `Database/Schema/` folder
3. Execute scripts in order:
   - `01-tables.sql` – Creates all tables
   - `02-constraints-indexes.sql` – Adds constraints and indexes
   - `Seed/10-minimal-lookup.sql` – Adds lookup data

**Verify Database Import:**
- Expand the **School** database in Object Explorer
- Confirm that tables are present
- Check sample data if using seed scripts

> ⚠️ **Troubleshooting:** If import fails, ensure SQL Server allows data-tier application imports and you have sufficient permissions.

#### Step 3: Configure Database Connection

1. Open `SMS.sln` in **Visual Studio 2022**
2. Locate connection string in the following files:
   - `DatabaseSetup.cs`
   - Any `*.cs` files that contain `Data Source=` or `SqlConnection`
3. Update the connection string with your SQL Server details:

```csharp
// Standard connection string format for Windows Authentication
"Data Source=YOUR_SERVER_NAME;Initial Catalog=School;Integrated Security=True;"

// Example for local SQL Server Express:
"Data Source=localhost\\SQLEXPRESS;Initial Catalog=School;Integrated Security=True;"

// Example with SQL Server Authentication:
"Data Source=YOUR_SERVER;Initial Catalog=School;User Id=YOUR_USERNAME;Password=YOUR_PASSWORD;"
```

**Finding Your Server Name:**
- Open SSMS → Look at the server name in the connection dialog
- Common formats: `localhost`, `localhost\SQLEXPRESS`, `.\SQLEXPRESS`, or your machine name

> 🔒 **Security Note:** Never commit real database credentials to the repository. Use placeholders and document how to configure them.

#### Step 4: Build and Run

1. **Restore NuGet Packages:** 
   - Right-click solution → Restore NuGet Packages
   - Or: Tools → NuGet Package Manager → Restore

2. **Build Solution:** 
   - Press `Ctrl + Shift + B`
   - Or: Build → Build Solution

3. **Run Application:** 
   - Press `F5`
   - Or: Click the Start button (green play icon)

> ✅ **Success!** If everything is configured correctly, the login/register screen should appear.

### 🐛 Common Issues & Solutions

| Issue | Possible Cause | Solution |
|-------|---------------|----------|
| **"Cannot connect to database"** | SQL Server not running | Open SQL Server Configuration Manager and start SQL Server service |
| **"Login failed for user"** | Incorrect credentials or authentication mode | Check connection string and SQL Server authentication settings |
| **"Database 'School' does not exist"** | Database not imported | Re-import the `.bacpac` file or run SQL scripts |
| **Build errors** | Missing packages | Restore NuGet packages and ensure .NET Framework 4.8.1 SDK is installed |
| **Missing tables/columns** | Incomplete database import | Drop and re-import the database completely |
| **Application crashes on startup** | Wrong connection string | Verify server name, database name, and credentials |

> 💬 **Still stuck?** Check existing [Issues](https://github.com/RabindranathChanda/Student_Management_System/issues) or create a new one with the "help wanted" label.

---

## 📚 Usage Guide

### First-Time Setup

1. **Launch the application** by running `SMS.exe` from Visual Studio or the build folder
2. **Register/Login** using the authentication screen
3. **Explore the Dashboard** to see available modules
4. **Configure database** using the built-in DatabaseSetup utility if needed

### Main Modules Explained

#### 📝 Student Admission
- Add new students to the system
- Capture student details: name, contact, address, guardian info, etc.
- Generate unique student IDs automatically
- Validate data before submission

#### 👨‍🎓 Student Management
- View all enrolled students
- Search by name, ID, or other criteria
- Update student information
- View detailed student profiles

#### ✏️ Student Rectification
- Correct errors in existing student records
- Update outdated information
- Maintain audit trail of changes

#### 🚫 Student Termination
- Process student exits (graduation, transfer, dropout)
- Archive student records
- Maintain historical data

#### 📚 Library Management
- **Book Issue:** 
  - Issue books to students
  - Track issue dates and due dates
  - Generate library card numbers
- **Book Return:**
  - Process book returns
  - Calculate overdue fines (if applicable)
  - Update book availability status

#### 🎯 Dashboard
- View key statistics and metrics
- Quick access to frequently used modules
- Recent activities overview
- System notifications

> 📖 **Need more help?** Check the [CONTRIBUTING.md](CONTRIBUTING.md) file for detailed setup instructions.

---

## 🤝 Contributing

We welcome contributions from everyone! Whether you're fixing bugs, adding features, improving documentation, or suggesting enhancements, your input is valuable.

### Quick Start for Contributors

1. **Fork** this repository to your GitHub account
2. **Clone** your fork locally
3. **Create a branch:** `git checkout -b feat/your-feature-name`
4. **Make changes** and test thoroughly
5. **Commit:** `git commit -m "Add: Description of changes"`
6. **Push:** `git push origin feat/your-feature-name`
7. **Open a Pull Request** with detailed description

### 🎯 Good First Issues

Perfect for beginners or first-time contributors:

- 🐛 Fix UI alignment issues
- 📝 Add input validation to forms
- 🎨 Improve form layouts and styling
- 📄 Add XML documentation comments to methods
- 🧪 Write unit tests for business logic
- 📸 Capture and add application screenshots
- 📖 Improve code comments and documentation

### 💡 Contribution Ideas

- Add attendance management module
- Implement fee collection and receipt generation
- Create exam and grade management system
- Add email/SMS notification support
- Implement role-based access control
- Create PDF report generation
- Add data export functionality (CSV, Excel)
- Implement automated database backup
- Add parent portal for viewing student info
- Create mobile-responsive admin panel

### 📋 Code Guidelines

- Follow C# naming conventions (PascalCase for types, camelCase for locals)
- Use parameterized queries to prevent SQL injection
- Add XML documentation for public methods
- Keep methods small and focused (Single Responsibility)
- Test changes manually before submitting PR
- Update README if adding new features
- Never commit connection strings with real credentials

> 📄 **Full Guidelines:** See [CONTRIBUTING.md](CONTRIBUTING.md) for detailed contribution guidelines.

---

## 🗺️ Roadmap

### 🚧 In Progress
- [ ] Enhanced UI/UX improvements
- [ ] Additional validation for forms
- [ ] Comprehensive error handling

### 📅 Planned Features

**Version 2.0**
- [ ] **Attendance Management** – Daily attendance tracking with reports
- [ ] **Fee Management** – Fee collection, receipts, and payment tracking
- [ ] **Exam Management** – Schedule exams and record results
- [ ] **Grade Management** – Calculate and store student grades
- [ ] **Report Cards** – Generate printable report cards

**Version 2.5**
- [ ] **Email Notifications** – Automated alerts for important events
- [ ] **SMS Integration** – Send notifications via SMS gateway
- [ ] **PDF Generation** – Export reports and documents to PDF
- [ ] **Data Export** – Export to CSV, Excel formats
- [ ] **Advanced Search** – Full-text search across all modules

**Version 3.0**
- [ ] **Role-Based Access Control** – Granular permissions system
- [ ] **Automated Backups** – Scheduled database backups
- [ ] **Parent Portal** – Web-based portal for parents
- [ ] **Mobile App** – Companion mobile application
- [ ] **Analytics Dashboard** – Charts, graphs, and insights
- [ ] **Multi-language Support** – Localization for different languages

### ✅ Completed Features
- ✅ Student admission module
- ✅ Student management (view, update, terminate)
- ✅ Library book issue and return
- ✅ Authentication system (login/register)
- ✅ Dashboard with quick actions
- ✅ Unique ID generation system
- ✅ Toaster notifications

> 💡 **Have an idea?** Open an [issue](https://github.com/RabindranathChanda/Student_Management_System/issues/new) with the "enhancement" label!

---

## 📁 Project Structure

```
Student_Management_System/
│
├── SMS/                          # Main application source
│   ├── *.cs                     # C# code files
│   ├── *.Designer.cs            # Form designer files
│   ├── *.resx                   # Resource files
│   ├── App.config               # Application configuration
│   ├── Resources/               # Images, icons, assets
│   └── Properties/              # Assembly info and settings
│
├── Database/                     # Database files
│   ├── School.bacpac            # Database backup file
│   └── Schema/                  # SQL scripts
│       ├── 01-tables.sql        # Table definitions
│       ├── 02-constraints-indexes.sql
│       └── Seed/                # Sample data scripts
│
├── logo/                        # Application logos and icons
│   ├── logo1/
│   ├── logo2/
│   └── logo3/
│
├── SMS.sln                      # Visual Studio solution file
├── README.md                    # This file
├── CONTRIBUTING.md              # Contribution guidelines
├── LICENSE                      # MIT License
└── ProjectTree.txt              # Project structure documentation
```

---

## 📝 License

This project is licensed under the **MIT License** – see the [LICENSE](LICENSE) file for details.

**What this means:**
- ✅ Free to use, modify, and distribute
- ✅ Can be used for commercial purposes
- ✅ Can be used in private projects
- ✅ Liability and warranty disclaimer
- ⚠️ License and copyright notice must be included

---

## 🌟 Contributors

Thanks to these amazing people who have contributed to this project:

<a href="https://github.com/RabindranathChanda/Student_Management_System/graphs/contributors">
  <img src="https://contrib.rocks/image?repo=RabindranathChanda/Student_Management_System" alt="Contributors" />
</a>

Made with [contrib.rocks](https://contrib.rocks).

Want to see your face here? Check out our [contribution guidelines](#-contributing)!

---

## 🙌 Acknowledgements

- **Project Creator & Maintainer:** [Rabindra Nath Chanda](https://github.com/RabindranathChanda)
- **Contributors:** Thanks to all contributors who help improve this project! ⭐
- **Inspiration:** Real-world needs of educational institutions
- **Community:** Special thanks to:
  - Hacktoberfest participants
  - Open-source enthusiasts
  - Early adopters and testers
  - Bug reporters and feature requesters

---

## 📞 Contact & Support

### Get Help

- 🐛 **Bug Reports:** [Report a Bug](https://github.com/RabindranathChanda/Student_Management_System/issues/new?labels=bug)
- 💡 **Feature Requests:** [Suggest a Feature](https://github.com/RabindranathChanda/Student_Management_System/issues/new?labels=enhancement)
- ❓ **Questions:** [Start a Discussion](https://github.com/RabindranathChanda/Student_Management_System/discussions)
- 🆘 **Help Wanted:** [Issues labeled "help wanted"](https://github.com/RabindranathChanda/Student_Management_System/issues?q=is%3Aissue+is%3Aopen+label%3A%22help+wanted%22)

### Stay Connected

- ⭐ **Star this repository** to show your support
- 👀 **Watch** for updates and new releases
- 🔔 **Follow** [@RabindranathChanda](https://github.com/RabindranathChanda) on GitHub
- 📧 **Email:** Check GitHub profile for contact information

### For Contributors

- 📋 Read [CONTRIBUTING.md](CONTRIBUTING.md) for contribution guidelines
- 🎯 Check "good first issue" labeled issues
- 💬 Comment on issues before starting work to avoid duplication

---

## 📊 Project Statistics

![GitHub commit activity](https://img.shields.io/github/commit-activity/m/RabindranathChanda/Student_Management_System)
![GitHub last commit](https://img.shields.io/github/last-commit/RabindranathChanda/Student_Management_System)
![GitHub contributors](https://img.shields.io/github/contributors/RabindranathChanda/Student_Management_System)
![Lines of code](https://img.shields.io/tokei/lines/github/RabindranathChanda/Student_Management_System)

---

## 🎓 Learning Resources

New to C# or Windows Forms? Here are some helpful resources:

- [Microsoft C# Documentation](https://docs.microsoft.com/en-us/dotnet/csharp/)
- [Windows Forms Documentation](https://docs.microsoft.com/en-us/dotnet/desktop/winforms/)
- [SQL Server Tutorial](https://www.sqlservertutorial.net/)
- [Git Handbook](https://guides.github.com/introduction/git-handbook/)
- [How to Contribute to Open Source](https://opensource.guide/how-to-contribute/)

---

<div align="center">

### ⭐ If you find this project helpful, please give it a star!

**Made with ❤️ by [Rabindra Nath Chanda](https://github.com/RabindranathChanda)**

*Empowering educational institutions through efficient student management*

---

**🎉 Hacktoberfest 2025 Friendly • 🔓 Open Source • 🤝 Contributions Welcome**

[Report Bug](https://github.com/RabindranathChanda/Student_Management_System/issues) • [Request Feature](https://github.com/RabindranathChanda/Student_Management_System/issues) • [View Demo](#-screenshots--demo)

</div>