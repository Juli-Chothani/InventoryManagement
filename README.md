# Inventory Accounting System
 
It is a fully structured **Inventory Accounting System** including:

- Items  
- Accounts  
- Suppliers  
- Purchases  
- Sales  
- Ledger  
- Receipts  
- Payments  

Built using **.NET Core MVC / Web API, SQL Server, Dapper, Repository Pattern, and Unit of Work**.

---

## Features

### ✔ Master Modules  
- Account Master
- Item Master
- Supplier Master

### ✔ Transaction Modules  
- Purchase Entry
- Sales Entry
- Receipt Entry
- Payment Entry

### ✔ Ledger & Accounting  
- Auto posting of:
  - Debit entry  
  - Credit entry  
- Ledger view  
- Account balance calculation  

---

# Technologies Used

| Technology | Usage |
|-----------|--------|
| .NET | Web API | Backend API |
| C# | Core development |
| SQL Server | Database |
| Dapper ORM | Data access |
| Repository Pattern | Clean separation |
| Unit of Work Pattern | Transaction management |
| Swagger | API Testing | API Collection |

---

# Project Structure

```
InventoryAccounting/
│
├── InventoryAccounting.API         → Web API Layer
│   ├── Controllers
│   └── Program.cs
│
├── InventoryAccounting.Core        → Core Business Layer
│   ├── Entities
│   ├── Interfaces
│   └── DTOs
│
├── InventoryAccounting.Service     → Service Layer
│   ├── Services
│
├── InventoryAccounting.Infrastructure
│   ├── Database (DbConnectionFactory)
│   ├── UnitOfWork
│   ├── Repositories

# Setup Instructions (Local System)

## Clone Repo

```
git clone https://github.com/<your-username>/InventoryAccounting.git
```

## Open Solution

Open the `.sln` file using **Visual Studio 2022**.

---

# Database Setup

### 1. Update the connection string in `appsettings.json`:

```json
"ConnectionStrings": {
  "DefaultConnection": "Server=YOUR_SERVER;Database=InventoryDB;Trusted_Connection=True;TrustServerCertificate=True;"
}
```

### 2. Run SQL Tables Script

Create required tables:

- AccountMaster  
- ItemMaster  
- SupplierMaster  
- PurchaseHeader
- PurchaseItem  
- SaleHeader
- SaleItem  
- Ledger  
- ReceiptHeader  
- PaymentHeader  
---

# Run the API

```
dotnet run
```
https://localhost:xxxx/swagger
```

# POSTMAN Collection

Postman collection includes:

- Account APIs
- Item APIs
- Supplier APIs
- Purchase APIs
- Sale APIs
- Receipt APIs
- Payment APIs
- Ledger APIs
---

# Sample API Endpoints

### ✔ Create Account

```
POST /api/AccountMaster
```

Body:
```json
{
  "accountCode": "INV",
  "name": "Inventory",
  "type": "Asset"
}
```

### ✔ Get All Accounts
```
GET /api/AccountMaster/all
```

### ✔ Create Item
```
POST /api/ItemMaster
```

### ✔ Create Purchase
```
POST /api/Purchase
```

---

# Architecture Diagram

```
Controller → Service → UnitOfWork → Repository → Database
```

# About

**Juli Chothani**  
Software Developer  

---

---

