Movie Management API

A RESTful API for managing movies with full CRUD functionality, validation, and unit testing.

---

## Tech Stack

- **Backend Framework:** ASP.NET Core MVC   
- **Database:** SQL Server  
- **ORM:** Entity Framework Core  
- **Mapping:** AutoMapper  
- **Testing:** xUnit, Moq  
- **API Testing:** Postman  

---

## Features

- CRUD Operations for movies:
  - `GET /api/movies` – List all movies
  - `GET /api/movies/{id}` – Get a single movie by ID
  - `POST /api/movies` – Create a new movie
  - `PUT /api/movies/{id}` – Update an existing movie
  - `DELETE /api/movies/{id}` – Delete a movie by ID

- Validations:
  - `Title` is required (max 200 chars)
  - `Director` optional (max 150 chars)
  - `Genre` optional (max 100 chars)
  - `ReleaseYear` must be between 1888–3000
  - `Rating` must be between 1.0–10.0

- AutoMapper for DTO ↔ Entity conversions
- Unit Tests for service and controller layers
- Postman collection included for testing endpoints

---

## Project Structure
Movie_Management_API/
├── Controllers/
├── DTOs/
├── Services/
├── DAO/
├── EntityModels/
├── Tests/
├── Program.cs
├── appsettings.json
├── MovieManagementAPI.postman_collection.json
└── README.md


---

## Prerequisites

- .NET 7 SDK  
- SQL Server  
- Visual Studio 2022 or VS Code  
- Postman  

---

## Setup & Running

1. Clone the repository:

```bash
git clone <https://github.com/rohanpatil6/Movie-Management-API>
cd Movie_Management_API


Configure database in appsettings.json:

"ConnectionStrings": {
  "DefaultConnection": "Server=YOUR_SERVER;Database=MovieDb;User Id=sa;Password=Sql123;Encrypt=True;TrustServerCertificate=True"
}


Apply migrations:

dotnet ef database update


Run the API:

dotnet run


API will be available at: https://localhost:5001 or http://localhost:5000

Running Tests
dotnet test


Covers both service and controller layers

Testing with Postman

Import the Postman collection: MovieManagementAPI.postman_collection.json

Example requests:

Create Movie:

POST /api/movies
Content-Type: application/json

{
  "title": "Inception",
  "director": "Christopher Nolan",
  "releaseYear": 2010,
  "genre": "Sci-Fi",
  "rating": 9
}


Get All Movies:

GET /api/movies


Get Movie by ID:

GET /api/movies/{id}


Update Movie:

PUT /api/movies/{id}
Content-Type: application/json

{
  "title": "Interstellar",
  "director": "Christopher Nolan",
  "releaseYear": 2014,
  "genre": "Sci-Fi",
  "rating": 9.5
}


Delete Movie:

DELETE /api/movies/{id}

Notes

Proper error handling for NotFound and validation errors

DTOs separate API contract from database entities

Repository pattern ensures separation of concerns

Author

Rohan Babasaheb Patil
Final Year Computer Engineering | AI & ML Enthusiast


This is **ready to use in your GitHub repository**.  

If you want, I can also **generate the Postman collection JSON file** for you to include in the repo. Do you want me to do that?

You said:
ConnectionStrings
· json
"ConnectionStrings": {
  "DefaultConnection": "Data Source=DESKTOP-3E2BGIP\\MSSQLSERVER22;Initial Catalog=MovieDb;Persist Security Info=True;User ID=sa;Password=Sql123;Encrypt=True;TrustServerCertificate=True"
}




Your ConnectionStrings JSON looks correct for SQL Server. To make it fully valid JSON, you should wrap it in an object like this:

{
  "ConnectionStrings": {
    "DefaultConnection": "Data Source=DESKTOP-3E2BGIP\\MSSQLSERVER22;Initial Catalog=MovieDb;Persist Security Info=True;User ID=sa;Password=Sql123;Encrypt=True;TrustServerCertificate=True"
  }
}


This is ready to be used in appsettings.json for your ASP.NET Core project.
