# EVDMS - Electric Vehicle Dealership Management System

This is a comprehensive management system for an electric vehicle dealership, built with .NET.

## Technology Stack

- **.NET 9**: The core framework for building the application.
- **ASP.NET Core**: For building the web application.
- **Entity Framework Core**: For data access and database management.
- **SQL Server**: The database used to store the application data.

## Project Structure

The solution is divided into several projects, each with a specific responsibility:

- `EVDMS.sln`: The solution file that contains all the projects.
- `EVDMS.Core`: Contains the core entities and common models of the application.
  - `Entities`: Defines the database models (e.g., `Account`, `Customer`, `VehicleModel`).
  - `CommonEntities`: Contains common properties for entities like `CreatedCommon` and `UpdatedCommon`.
- `EVDMS.DAL`: The Data Access Layer, responsible for all database interactions.
  - `Database`: Contains the `ApplicationDbContext` and database migrations.
  - `Configuration`: Handles dependency injection for the DAL.
- `EVDMS.BLL`: The Business Logic Layer, containing the application's business logic and services.
  - `WrapConfiguration`: Handles dependency injection for the BLL.
- `EVDMS.Presentation`: The presentation layer, which is an ASP.NET Core MVC web application.
  - `Controllers`: Handle user requests.
  - `Views`: The UI of the application.
  - `wwwroot`: Contains static assets like CSS, JavaScript, and images.

## Getting Started

To get the project up and running on your local machine, follow these steps:

### Prerequisites

- [.NET 9 SDK](https://dotnet.microsoft.com/download/dotnet/9.0)
- [SQL Server](https://www.microsoft.com/en-us/sql-server/sql-server-downloads) (or another compatible database)

### Installation

1.  **Clone the repository:**

    ```sh
    git clone https://github.com/TieHung23/LAB_1_PRN222.git
    cd LAB_1_PRN222
    ```

2.  **Configure the database connection:**

    - Open `EVDMS.Presentation/appsettings.json`.
    - Modify the `ConnectionString` to point to your database.

3.  **Apply database migrations:**

    - Open a terminal in the root of the project.
    - Run the following command to apply the migrations:
      ```sh
      dotnet ef database update --project EVDMS.DAL --startup-project EVDMS.Presentation
      ```

4.  **Run the application:**
    - Navigate to the presentation project: `cd EVDMS.Presentation`
    - In the same terminal, run the application:
      ```sh
      dotnet run
      ```
    - The application will be available at `https://localhost:5001` or `http://localhost:5000`.

    ## Account Information
 1. Administrator Account:
    - Username: admin
    - Password: 12345  

 2. Staff Account:
    - Username: staff1
    - Password: 12345

3.Manager Account:
    - Username: manager1
    - Password: 12345