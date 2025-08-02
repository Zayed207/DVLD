DVLD - Driving and Vehicle Licensing Department System

Project Overview

DVLD is a Windows Forms application developed in C# that simulates a Driving and Vehicle Licensing Department system. This application is designed to manage various aspects of driving licenses,
vehicle registrations, and related services. It demonstrates a multi-layered architecture,
separating the User Interface (UI), Business Logic, and Data Access layers for better maintainability, scalability, and testability.

Features

• User Management: Secure login system with user authentication and role-based access control.

• Person Management: Create, view, update, and delete person records with detailed personal information.

• Driver Management: Link persons to driver records.

• License Management: Handle different types of driving licenses (local and international), including application, issuance, renewal, and replacement.

• Test Management: Manage driving tests (theory and practical) and appointments.

• Application Management: Track various application types (e.g., new license, renewal, international license).

• International License: Manage international driving licenses.

• Detained Licenses: Handle detained licenses.

• Country Management: Manage country information.

Technologies Used

• Programming Language: C#

• Framework: .NET Framework (Windows Forms)

• Database: SQL Server 

• Data Access: ADO.NET

Project Structure

The project is organized into several key components:

• DVLD (UI Layer): Contains the Windows Forms user interface, including forms for login, main dashboard, person management, license management, etc.

• DVLD_Buisness (Business Logic Layer): Encapsulates the business rules and logic of the application. This layer interacts with the Data Access Layer to retrieve and manipulate data, and provides methods for the UI layer to consume.

• DVLD_DataAccess (Data Access Layer): Responsible for all interactions with the database. It contains methods for CRUD (Create, Read, Update, Delete) operations on the database tables.

• DataAccessSettings: Likely contains configuration settings for database connection strings.

• DataBase: May contain SQL scripts for database schema and initial data.

Getting Started

Prerequisites

• Visual Studio (2019 or later recommended)

• SQL Server 

• .NET Framework (appropriate version for the project)

Installation

1. Clone the repository:

2. Set up the database:

• Locate the DataBase folder in the cloned repository. It should contain SQL scripts to create the database schema and possibly populate initial data.

• Execute these SQL scripts in your SQL Server instance to create the DVLD database and its tables.

• Update the connection string in DataAccessSettings (or similar configuration file) to point to your SQL Server instance.



3. Open the project in Visual Studio:

• Navigate to the DVLD folder and open the DVLD.sln solution file.



4. Restore NuGet Packages:

• In Visual Studio, right-click on the solution in the Solution Explorer and select
Restore NuGet Packages.

5.  Build the solution:
*   Build the entire solution in Visual Studio to ensure all dependencies are resolved and the project compiles successfully.

Running the Application

•
After building, you can run the application directly from Visual Studio by pressing F5 or clicking the Start button.

Contributing

Contributions are welcome! If you have suggestions for improvements or find any issues, please open an issue or submit a pull request.



Contact

For any questions or inquiries, please contact [Zayed/zayedofficial20@gmail.com].

