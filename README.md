# JobSeeker API

A .NET 8 Web API for job seeking and recruitment management system.

## Architecture Overview

This project follows Clean Architecture principles with the following layers:

### 📁 Project Structure
```
JobSeekerAPI/
├── Controllers/          # API Controllers (Presentation Layer)
├── Services/            # Business Logic Layer
├── Repositories/        # Data Access Layer
├── Models/              # Domain Entities
├── Dtos/               # Data Transfer Objects
├── Validators/         # FluentValidation Rules
├── Data/               # Entity Framework Context
├── Middleware/         # Custom Middleware
└── Properties/         # Configuration
```

### 🏗️ Architecture Patterns

#### 1. **Repository Pattern**
- Generic `IRepository<T>` for common CRUD operations
- Specific repositories (e.g., `ICompanyRepository`) for custom queries
- Separation of data access logic from business logic

#### 2. **Service Layer Pattern**
- Business logic encapsulation
- Transaction management
- Data validation and transformation

#### 3. **DTO Pattern**
- Input/Output data transfer objects
- Separation of API contracts from domain models
- Validation at the API boundary

#### 4. **Dependency Injection**
- Constructor-based dependency injection
- Interface-based abstractions
- Testable and maintainable code

## 🚀 Features

### ✅ Implemented Features
- **User Management**: CRUD operations for users
- **Company Management**: CRUD operations for companies
- **Validation**: FluentValidation for input validation
- **Exception Handling**: Global exception handling middleware
- **Logging**: Structured logging with ILogger
- **API Documentation**: Swagger/OpenAPI integration
- **Consistent Responses**: Standardized API response format

### 🔄 API Endpoints

#### Users
- `GET /api/user` - Get all users
- `GET /api/user/{id}` - Get user by ID
- `POST /api/user` - Create new user
- `PUT /api/user/{id}` - Update user
- `DELETE /api/user/{id}` - Delete user
- `GET /api/user/email/{email}` - Get user by email

#### Companies
- `GET /api/company` - Get all companies
- `GET /api/company/{id}` - Get company by ID
- `POST /api/company` - Create new company
- `PUT /api/company/{id}` - Update company
- `DELETE /api/company/{id}` - Delete company
- `GET /api/company/name/{name}` - Get company by name

## 🛠️ Technologies Used

- **.NET 8** - Latest .NET framework
- **Entity Framework Core 8** - ORM for data access
- **SQL Server** - Database
- **FluentValidation** - Input validation
- **Swagger/OpenAPI** - API documentation
- **Dependency Injection** - Built-in .NET DI container

## 📋 Prerequisites

- .NET 8 SDK
- SQL Server (LocalDB or full instance)
- Visual Studio 2022 or VS Code

## 🔧 Setup Instructions

1. **Clone the repository**
   ```bash
   git clone <repository-url>
   cd JobSeekerAPI
   ```

2. **Configure Database**
   - Update connection string in `appsettings.json`
   - Run Entity Framework migrations:
   ```bash
   dotnet ef database update
   ```

3. **Run the application**
   ```bash
   dotnet run
   ```

4. **Access Swagger UI**
   - Navigate to `https://localhost:7001/swagger`

## 📝 API Usage Examples

### Create a Company
```http
POST /api/company
Content-Type: application/json

{
  "name": "Tech Corp",
  "description": "Leading technology company",
  "industry": "Technology"
}
```

### Create a User
```http
POST /api/user
Content-Type: application/json

{
  "firstName": "John",
  "lastName": "Doe",
  "email": "john.doe@example.com",
  "password": "securepassword123",
  "role": "applicant"
}
```

## 🔒 Security Considerations

- Input validation using FluentValidation
- Global exception handling
- Proper HTTP status codes
- Structured error responses

## 🧪 Testing

The project is structured to support unit testing:
- Service layer can be easily mocked
- Repository pattern enables test doubles
- DTOs provide clear input/output contracts

## 📈 Future Improvements

- [ ] Authentication & Authorization (JWT)
- [ ] Password hashing (BCrypt)
- [ ] API versioning
- [ ] Caching layer
- [ ] Rate limiting
- [ ] Background job processing
- [ ] Email notifications
- [ ] File upload functionality
- [ ] Advanced search and filtering
- [ ] Audit logging

## 🤝 Contributing

1. Fork the repository
2. Create a feature branch
3. Make your changes
4. Add tests if applicable
5. Submit a pull request

## 📄 License

This project is licensed under the MIT License. 