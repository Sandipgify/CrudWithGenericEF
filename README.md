## .NET 7 Version - SQL Server 2019

This project is built using .NET 7 and utilizes SQL Server 2019 as its database backend. Below are the instructions to set up and use the application.

### Setup

1. **Connection String:**
   Update the connection string in the `appsettings.json` file to point to your SQL Server 2019 instance.

2. **Database Migration:**
   Execute the following command inside the project folder or open a terminal and run the command to apply migrations and create the database:

   dotnet ef database update

   # APIs

The application consists of 5 APIs for handling employee data:

## Get Single Data:

- Method: `GET`
- Endpoint: `/api/employee`

This API retrieves a single employee's data.

## Post Data:

- Method: `POST`
- Endpoint: `/api/employee`

Use this API to add new employee data. Send the employee details in the request body.

## Update Single Data:

- Method: `PUT`
- Endpoint: `/api/employee`

Update an existing employee's data using this API. Provide the updated details in the request body.

## Delete Data:

- Method: `DELETE`
- Endpoint: `/api/employee`

This API allows you to delete an employee's data. Provide the employee ID in the request.

## Get Multiple Data:

- Method: `GET`
- Endpoint: `/api/GetAll`

Retrieve data for all employees using this API.

# Project Structure

The project structure is organized into the following folders:

- **Domain:**
  - Contains entities representing the data model.

- **Data:**
  - Responsible for database changes and retrieving data.
  - Includes a generic repository for tracking changes and another for read-only operations.

## Generic Repository

In the `Data` folder, a **Generic Repository** pattern has been implemented to handle data operations. The repository design allows for a flexible and scalable approach to database interactions.

### Two Types of Generic Repositories

1. **Tracking Repository:**
   - This repository is responsible for tracking changes in the data and is used when modifications to the database are required.

2. **Read-Only Repository:**
   - Specifically designed for read-only operations.
   - It does not track changes made to entities, making it optimal for scenarios where read operations are frequent, and changes to the data are not necessary.

These generic repositories provide a clean separation of concerns, making the codebase more modular and maintainable. They can be extended or modified based on specific application requirements.

