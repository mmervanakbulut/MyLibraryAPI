# MyLibraryAPI
MyLibraryAPI is a RESTful API built with ASP.NET Core that allows you to manage a library of books, authors, and publishers.

## Features
- Get all books with their authors and publishers
- Add a new book
- Update an existing book
- Delete a book

## Technologies Used
- ASP.NET Core 8
- Entity Framework Core
- C# 12.0

## Getting Started

### Prerequisites
- .NET 8 SDK
- Visual Studio 2022

### Installation               
1. Clone the repository:
    git clone https://github.com/yourusername/MyLibraryAPI.git

2. Navigate to the project directory:
    cd MyLibraryAPI

3. Restore the dependencies:
    dotnet restore

### Running the Application
1. Update the `appsettings.json` file with your database connection string.
2. Apply the migrations to create the database:
    dotnet ef database update
3. Run the application:
    dotnet run


### API Endpoints
- `GET /api/book` - Get all books
- `POST /api/book` - Add a new book
- `PUT /api/book/{id}` - Update an existing book
- `DELETE /api/book/{id}` - Delete a book

### Models
#### Book
#### Author
#### Publisher
#### BookCreate

## License
This project is licensed under the MIT License.