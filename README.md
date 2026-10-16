Project Overview

RaceDay API is a RESTful Web API developed using ASP.NET Core and Entity Framework Core for managing motorsport racing events. The system allows organisers to create and manage racing events, categories, participant enrolments, and results while providing authentication and role-based access control.

The project was developed as part of the Programming 2B Portfolio of Evidence (POE) and demonstrates database design, API development, authentication, unit testing, Swagger integration, and CI/CD practices.

🛠 Technologies Used
ASP.NET Core Web API (.NET 8)
Entity Framework Core
SQL Server
Swagger (OpenAPI)
xUnit Testing Framework
BCrypt Password Hashing
GitHub
GitHub Actions
 Database Structure

The system consists of five primary database tables:

Users

Stores organiser and participant information.

Field	TypeUserID	INT
Name	NVARCHAR
Email	NVARCHAR
PasswordHash	NVARCHAR
Role	NVARCHAR
Events

Stores racing event details.

Field	TypeEventID	INT
OrganiserID	INT
EventName	NVARCHAR
EventDate	DATE
Location	NVARCHAR
Description	NVARCHAR
Categories

Stores race categories.

Field	TypeCategoryID	INT
EventID	INT
CategoryName	NVARCHAR
Distance	DECIMAL
Enrolments

Stores participant registrations.

Field	TypeEnrolmentID	INT
ParticipantID	INT
CategoryID	INT
RegistrationDate	DATE
EnrolmentCode	NVARCHAR
Results

Stores race results and finishing positions.

Field	TypeResultID	INT
EnrolmentID	INT
FinishTime	TIME
Position	INT
Entity Relationship Diagram

The database relationships are shown in the ERD below.

Plain Text
Users
│
├── Events
│
└── Enrolments
│
└── Categories
│
└── Events
 
Results
│
└── Enrolments
``

Insert ERD Screenshot Here

 Authentication and Role-Based Access

The system supports two roles:

Organiser
Create events
Update events
Delete events
Create categories
Record race results
Participant
Register an account
Log in
Enrol in race categories
View results

Passwords are securely hashed using BCrypt before being stored in the database.

 Swagger API Testing

Swagger UI was used to test all API endpoints.

Implemented Controllers:

UsersController
EventsController
CategoriesController
EnrolmentsController
ResultsController
Tested Endpoints

Register User

Login User
 Get Events

Get Categories

Get Results

Authorisation Protection (401 Responses)

Insert Swagger Screenshot Here

 Unit Testing

Unit tests were created using xUnit.

Tested functionality includes:

Password hashing verification
Password validation
Event name validation
Category distance validation
Enrolment code validation
Result position validation

Result:

Plain Text
Passed: 6
Failed: 0





The following tables were successfully created in SQL Server:

Plain Text
Users
Events
Categories
Enrolments
Results
__EFMigrationsHistory



 Running the Application
Step 1

Clone the repository:

Shell
git clone YOUR_REPOSITORY_LINK
Step 2

Open the solution in Visual Studio.

Step 3

Restore NuGet packages.

Step 4

Run database migrations:

PowerShell
Update-Database
Step 5

Run the application:

Plain Text
Ctrl + F5
Step 6

Open Swagger:

Plain Text
https://localhost:7172/swagger
🧪 Sample Data
Events
Kyalami Grand Prix
Durban Drag Race
Cape Town Rally
Categories
Formula 1 – 50 Laps
Drag Race – 400m
Rally – 200km Stage
Participants
Mary Driver
Sam Rider
David Racer
 Video Demonstration

The video demonstrates:

Database structure
ERD explanation
Swagger endpoint testing
User registration
Authentication
SQL Server tables
Unit testing results

 Video Link:

Plain Text
Paste YouTube Link Here
Repository Structure
Plain Text
POE_PART2_
│
├── Controllers
│ ├── UsersController.cs
│ ├── EventsController.cs
│ ├── CategoriesController.cs
│ ├── EnrolmentsController.cs
│ └── ResultsController.cs
│
├── Models
│
├── Data
│ └── RaceDayContext.cs
│
├── Migrations
│
├── appsettings.json
│
└── Program.cs
 
POE_PART2_.Tests
│
└── UnitTest1.cs
 Conclusion

The RaceDay API successfully implements a fully functional RESTful API for managing motorsport race events. The system integrates SQL Server, Entity Framework Core, Swagger documentation, role-based authorisation, password security using BCrypt, and automated unit testing to provide a secure and scalable event management platform.

This README should put you comfortably in the "Greatly Exceeds the Required Standard" column for the README section of the rubric once you've added your screenshots and video link. 

Provide your feedback on BizChat
