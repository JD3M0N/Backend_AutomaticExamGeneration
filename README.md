# Automatic Exam Generation

## Overview

This project is a .NET 8 web application designed to manage assignments, exams, and other academic activities. It uses Entity Framework Core for data access and follows a clean architecture pattern.

## Prerequisites

Before you begin, ensure you have met the following requirements:

- **.NET 8 SDK**: You can download it from the [.NET 8 SDK download page](https://dotnet.microsoft.com/download/dotnet/8.0).
- **SQL Server**: This project uses SQL Server as its database. You can use SQL Server Management Studio (SSMS) to manage your database.
- **Visual Studio 2022**: This is the recommended IDE for working with this project. You can download it from the [Visual Studio download page](https://visualstudio.microsoft.com/downloads/).

## Setting Up the Database

1. **Install SQL Server**: If you don't have SQL Server installed, you can download it from the [SQL Server download page](https://www.microsoft.com/en-us/sql-server/sql-server-downloads).

2. **Create a Database**:
   - Open SQL Server Management Studio (SSMS).
   - Connect to your SQL Server instance.
   - Right-click on the `Databases` folder and select `New Database...`.
   - Name your database (e.g., `AcademicDB`) and click `OK`.

3. **Update Connection String**:
   - Open the `appsettings.json` file in the root of the project.
   - Update the `DefaultConnection` string with your SQL Server instance name and database name.
## Installing Dependencies

1. **Restore NuGet Packages**:
   - Open the solution in Visual Studio.
   - Right-click on the solution in the Solution Explorer and select `Restore NuGet Packages`.

2. **Install Entity Framework Core Tools**:
   - Open the Package Manager Console in Visual Studio (`Tools` > `NuGet Package Manager` > `Package Manager Console`).
   - Run the following command to install the EF Core tools:
## Running the Application

1. **Apply Migrations**:
   - Open the Package Manager Console in Visual Studio.
   - Run the following commands to apply the migrations and create the database schema:
2. **Run the Application**:
   - Press `F5` or click the `Start` button in Visual Studio to run the application.
   - The application will start, and you can access it at `https://localhost:5001` (or the port specified in your launch settings).

## API Endpoints

The application exposes several API endpoints for managing assignments, exams, and other entities. You can explore the API using Swagger, which is available at `https://localhost:5001/swagger` when the application is running.

## Contributing

To contribute to this project, follow these steps:

1. Fork the repository.
2. Create a new branch (`git checkout -b feature-branch`).
3. Make your changes and commit them (`git commit -m 'Add some feature'`).
4. Push to the branch (`git push origin feature-branch`).
5. Create a new Pull Request.

## License

This project is licensed under the MIT License. See the `LICENSE` file for more details.

## Contact

If you have any questions or need further assistance, please contact the project maintainer at [email@example.com](mailto:email@example.com).
