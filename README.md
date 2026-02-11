# MediatR Demo

A sample monolith project demonstrating the use of [MediatR](https://github.com/jbogard/MediatR) in a **CQRS (Command Query Responsibility Segregation)** pattern with .NET.  
It showcases how to structure commands, queries, and handlers, and how to integrate them with application infrastructure.

---

## 📂 Project Structure

```bash
MediatR.Demo/
├── Commands/          # Command definitions (e.g., Create, Update, Delete)
├── Queries/           # Query definitions (e.g., GetById, GetAll)
├── Handlers/          # Command and Query handlers
├── Entities/          # Domain models/entities
├── Infrastructure/    # Supporting services and repository abstractions
├── Properties/        # Launch settings
├── Program.cs         # Entry point for the application
├── appsettings.json   # Configuration file
├── Demo.csproj        # Project file
└── demo.sln           # Solution file
```

## 🚀 Features
- Implementation of **CQRS** using MediatR
- Separation of concerns with Commands, Queries, and Handlers
- Minimal setup to demonstrate MediatR usage

## ⚙️ Prerequisites
- [.NET 9 SDK](https://dotnet.microsoft.com/download/dotnet/9.0)
- Basic understanding of MediatR and CQRS

## 🛠️ Getting Started

1. **Clone the repository**

```bash
    git clone https://github.com/elcatbot/MediatR.Demo.git
    cd MediatR.Demo
```

2. **Restore dependencies**
```bash
    dotnet restore
```
2. **Restore dependencies**
```bash
    dotnet run
```

## 📡 Usage

MediatR decouples request handling by sending commands and queries through the mediator.

Use Demo.http file to send a Request. 

Example: Sending a Command

```bash
POST {{Demo.API_HostAddress}}/api/orders
Content-Type: application/json

{
  "CustomerName": "Test1",
  "OrderDate": "2024-01-01"
}
```

Example: Sending a Query

```bash
GET {{Demo.API_HostAddress}}/api/orders/1
Accept: application/json
```

## 🧪 Testing

Unit tests can be added using xUnit and Moq to validate command and query handlers. Example test structure:

```bash
MediatR.Demo.Tests/
├── Commands/
│   └── CreateOrderCommandHandlerTests.cs
|   └── UpdateOrderCommandHandlerTests.cs
├── Queries/
│   └── GetListOrderHandlerTests.cs
│   └── GetOrderHandlerTests.cs
```
