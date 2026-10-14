# 🎓 Student Registration System

### 🚀 A Simple and Efficient Student Registration Web Application

A web-based **Student Registration System** built using **ASP.NET Core MVC (.NET 8), C#, Entity Framework Core, and Microsoft SQL Server**. This project demonstrates how a web application can collect student information and store it in a relational database using modern .NET technologies.

<p align="center">
  <img src="https://img.shields.io/badge/.NET-8.0-512BD4?style=for-the-badge&logo=dotnet&logoColor=white" alt=".NET 8" />
  <img src="https://img.shields.io/badge/C%23-Backend-239120?style=for-the-badge&logo=csharp&logoColor=white" alt="C Sharp" />
  <img src="https://img.shields.io/badge/ASP.NET%20Core-MVC-512BD4?style=for-the-badge&logo=dotnet&logoColor=white" alt="ASP.NET Core MVC" />
  <img src="https://img.shields.io/badge/SQL%20Server-Database-CC2927?style=for-the-badge&logo=microsoftsqlserver&logoColor=white" alt="SQL Server" />
</p>

---

## ✨ Features

- 📝 **Student Registration** — Register student information through a web interface.
- 🗄️ **Database Integration** — Store student records in Microsoft SQL Server.
- 🔗 **Entity Framework Core** — Interact with the database using an ORM.
- 🔄 **Database Migrations** — Manage database schema changes using EF Core migrations.
- 🏗️ **MVC Architecture** — Keep application logic, data models, and UI organized.
- ✅ **Form Validation** — Validate user input where validation rules are configured.
- 💻 **Local Development** — Build and run the application locally using the .NET CLI.

## 🛠️ Tech Stack

| Technology | Purpose |
|---|---|
| 🟣 C# | Backend programming language |
| ⚙️ ASP.NET Core MVC | Web application framework |
| 🚀 .NET 8 | Application platform |
| 🔗 Entity Framework Core 8 | Object-relational mapping |
| 🗄️ Microsoft SQL Server Express | Database |
| 🎨 HTML, CSS, Bootstrap, Razor | User interface, where included |
| 💙 Visual Studio Code | Development environment |

## 📸 Application Preview

> 🖼️ *Add screenshots of your student registration form and student list here to showcase the application.*

Once you have screenshots, you can add them like this:

```markdown
![Student Registration Form](screenshots/registration-form.png)

![Student List](screenshots/student-list.png)
```

## ⚙️ Getting Started

Follow these steps to run the project on your local machine.

### 📋 Prerequisites

Make sure you have installed:

- [.NET 8 SDK](https://dotnet.microsoft.com/download/dotnet/8.0)
- [Visual Studio Code](https://code.visualstudio.com/)
- Microsoft SQL Server Express
- Entity Framework Core CLI (`dotnet-ef`)

### 1️⃣ Clone the Repository

```bash
git clone <YOUR_GITHUB_REPOSITORY_URL>
cd StudentRegistrationSystem
```

Alternatively, open the existing project folder directly in VS Code.

### 2️⃣ Configure the Database

Open `appsettings.json` and configure the SQL Server connection string.

```json
{
  "ConnectionStrings": {
    "DefaultConnection": "Server=.\\SQLEXPRESS;Database=StudentRegistrationDB;Integrated Security=True;TrustServerCertificate=True;"
  }
}
```

📌 **Note:** Ensure that the connection string name matches the configuration used in `Program.cs` and your database context.

### 3️⃣ Restore Dependencies

Open a terminal in the project directory and run:

```bash
dotnet restore
```

### 4️⃣ Apply Database Migrations

Install the EF Core CLI tool if required:

```bash
dotnet tool install --global dotnet-ef --version 8.0.22
```

Apply the existing migrations:

```bash
dotnet ef database update
```

✅ This applies the database migrations and creates the required schema in `StudentRegistrationDB`.

### 5️⃣ Build the Application

```bash
dotnet build
```

### 6️⃣ Run the Application

```bash
dotnet run
```

🌐 Open the local URL displayed in your terminal, for example:

`http://localhost:5089`

The port may vary depending on your configuration. Navigate to the configured Students page to access the registration interface.

## 🗄️ Database

**Database Name:** `StudentRegistrationDB`

**Main Table:** `Students`

The project uses Entity Framework Core migrations to manage the database schema.

To view registered student records, execute:

```sql
USE StudentRegistrationDB;

SELECT * FROM Students;
```

To list the database tables:

```sql
USE StudentRegistrationDB;

SELECT TABLE_NAME
FROM INFORMATION_SCHEMA.TABLES
WHERE TABLE_TYPE = 'BASE TABLE';
```

## 📁 Project Structure

```text
StudentRegistrationSystem/
│
├── Controllers/
│   └── StudentsController.cs
│
├── Models/
│   └── Student.cs
│
├── Data/
│   └── ApplicationDbContext.cs
│
├── Views/
│   └── Students/
│
├── Migrations/
│
├── Properties/
├── appsettings.json
├── Program.cs
├── StudentRegistrationSystem.csproj
└── README.md
```

📌 *The structure above is illustrative. Actual folders and files may differ in your repository.*

## 🎯 Learning Outcomes

Through this project, I practiced:

- 💡 Building web applications with ASP.NET Core MVC.
- 💻 Writing backend logic in C#.
- 🗄️ Connecting an application to SQL Server.
- 🔄 Managing database changes with Entity Framework Core migrations.
- 🏗️ Understanding the Model-View-Controller architectural pattern.
- 🧩 Organizing a .NET application into maintainable components.

## 🚀 Future Enhancements

Possible improvements for future versions:

- ✏️ Edit existing student records.
- 🗑️ Delete student records.
- 🔍 Search and filter students.
- 📄 Add pagination for large student lists.
- 🔐 Introduce authentication and authorization.
- 📱 Improve responsive UI and user experience.

*These are planned enhancements, not claims about features already implemented.*

## 🤝 Contributing

Suggestions and improvements are welcome! Feel free to fork the repository and submit a pull request.

## 👨‍💻 Author

**Ankit Pasvan**

💻 Full Stack Developer | Java & .NET Learner | Problem Solver

🔗 GitHub: [ankitpasvan](https://github.com/ankitpasvan)

---

<p align="center">
  ⭐ If you find this project interesting, consider giving the repository a star!
  <br/>
  💙 Built with passion and a continuous learning mindset.
</p>
