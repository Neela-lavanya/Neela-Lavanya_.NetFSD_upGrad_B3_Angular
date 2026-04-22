ShopEZ – E-Commerce Backend API
📌 Project Overview

ShopEZ is a backend REST API developed using ASP.NET Core Web API and Entity Framework Core.
It provides a complete backend solution for managing products, users, and orders in an e-commerce system.

This project transforms a static frontend application into a dynamic, database-driven system using SQL Server.

🎯 Features
User Registration & Login (JWT Authentication)
Product Management (CRUD Operations)
Order Processing System
Role-based Authorization (Admin/User)
Secure APIs with JWT Token
Database integration using Entity Framework Core
Layered Architecture (Controller → Service → Repository)
🛠️ Technology Stack
Layer	Technology
Backend	ASP.NET Core Web API
ORM	Entity Framework Core
Database	SQL Server
Tools	Visual Studio, Postman
Auth	JWT Authentication
🏗️ Project Architecture

The project follows a layered architecture:

Controller → Service → Repository → DbContext
Responsibilities:
Controller → Handles HTTP requests & responses
Service → Business logic (validation, calculations)
Repository → Database operations
DbContext → EF Core database interaction
🗂️ Project Structure
BackendProject
│
├── Controllers
│   ├── ProductsController.cs
│   ├── OrdersController.cs
│   └── AuthenticateController.cs
│
├── Models
│   ├── Product.cs
│   ├── Order.cs
│   ├── OrderItem.cs
│   └── User.cs
│
├── DTOs
│   ├── ProductDTO.cs
│   ├── OrderDTO.cs
│   ├── OrderItemDTO.cs
│   ├── LoginDTO.cs
│   └── RegisterDTO.cs
│
├── Data
│   └── ApplicationDbContext.cs
│
├── Repositories
│   ├── ProductRepository.cs
│   ├── OrderRepository.cs
│   ├── IProductRepository.cs
│   └── IOrderRepository.cs
│
├── Services
│   ├── ProductService.cs
│   ├── OrderService.cs
│   ├── JwtService.cs
│   ├── IProductService.cs
│   └── IOrderService.cs
│
└── Program.cs
🗄️ Database Design
Users Table
UserId (int)
Name (varchar)
Email (varchar)
Password (varchar)
Role (varchar)
Products Table
ProductId (int)
Name (varchar)
Description (varchar)
Price (decimal)
ImageUrl (varchar)
Stock (int)
Orders Table
OrderId (int)
UserId (int)
OrderDate (datetime)
TotalAmount (decimal)
OrderItems Table
OrderItemId (int)
OrderId (int)
ProductId (int)
Quantity (int)
Price (decimal)
🔗 Relationships
One User → Many Orders
One Order → Many OrderItems
One Product → Many OrderItems
🔐 Authentication APIs
Register User
POST /api/authenticate/register
Login User
POST /api/authenticate/login

Response:

{
  "token": "JWT_TOKEN"
}
📦 Product APIs
Method	Endpoint	Description
GET	/api/products	Get all products
GET	/api/products/{id}	Get product by ID
POST	/api/products	Add product (Admin)
PUT	/api/products/{id}	Update product
DELETE	/api/products/{id}	Delete product
🛒 Order APIs
Method	Endpoint	Description
POST	/api/orders	Create order
GET	/api/orders	Get all orders
GET	/api/orders/{id}	Get order by ID
⚙️ Order Processing Logic

When creating an order:

Validate input data
Check if product exists
Validate quantity
Check stock availability
Reduce product stock
Calculate total amount using LINQ
Save Order and OrderItems
⚡ Asynchronous Programming

All database operations use async/await:

await _context.Products.ToListAsync();
🧪 API Testing

Use Postman to test APIs:
Register
{
  "name": "Admin",
  "email": "admin@test.com",
  "password": "Admin123",
  "role": "Admin"
}
1. Login as Admin
{
  "email": "admin@test.com",
  "password": "Admin123"
}

👉 Token contains:

Role = Admin

2. Login as User
{
  "email": "user@test.com",
  "password": "User123"
}

Add JWT Token in Header:
Authorization: Bearer <your_token>
▶️ How to Run the Project
Step 1: Clone Project
git clone <your-repo-link>
Step 2: Open in Visual Studio
Open solution file (.sln)
Step 3: Configure Database

Update appsettings.json:

"ConnectionStrings": {
  "DefaultConnection": "Server=.;Database=ShopEZDb;Trusted_Connection=True;"
}
Step 4: Run Migrations
Add-Migration InitialCreate
Update-Database
Step 5: Run Application
Press F5 or click Run
Step 6: Open Swagger
https://localhost:<port>/swagger
🔑 JWT Configuration

Add in appsettings.json:

"Jwt": {
  "Key": "ThisIsMySuperSecretKey1234567890@123",
  "Issuer": "ShopEZ",
  "Audience": "ShopEZUsers"
}
✅ Validation & Error Handling

Null checks implemented
Quantity validation
Product existence validation
Proper HTTP status codes returned

📌 Deliverables

REST APIs for Products & Orders
SQL Server Database
CRUD Operations
JWT Authentication
Swagger Documentation
Clean Architecture