# Multi-Service Repository

This repository contains three microservices built with ASP.NET Core 7.0:

## Services

### 1. NotificationService (src/)
A user management service that provides:
- Delete user functionality
- User retrieval by ID
- PostgreSQL database integration

**Endpoints:**
- `DELETE /v1/user/{id}` - Delete a user by ID

**Port:** 5001 (HTTP), 7001 (HTTPS)

### 2. MessagingService (messaging-service/)
A messaging service that provides:
- Send messages/notifications
- Get message by ID
- Delete messages
- PostgreSQL database integration

**Endpoints:**
- `POST /v1/message` - Send a new message
- `GET /v1/message/{id}` - Get message by ID
- `DELETE /v1/message/{id}` - Delete message by ID

**Port:** 5002 (HTTP), 7002 (HTTPS)

### 3. PaymentService (payment-service/)
A payment processing service that provides:
- Process payments
- Get payment by ID
- Refund payments
- PostgreSQL database integration

**Endpoints:**
- `POST /v1/payment` - Process a new payment
- `GET /v1/payment/{id}` - Get payment by ID
- `POST /v1/payment/refund/{id}` - Refund a payment

**Port:** 5003 (HTTP), 7003 (HTTPS)

## Architecture

All services follow the same architectural patterns:
- **Repository Pattern** for data access
- **MediatR** for CQRS (Command Query Responsibility Segregation)
- **FluentValidation** for input validation
- **Entity Framework Core** with PostgreSQL
- **Swagger/OpenAPI** documentation
- **Clean Architecture** with separate layers

## Database Configuration

Each service uses its own PostgreSQL database:
- NotificationService: `UserDb`
- MessagingService: `MessageDb`
- PaymentService: `PaymentDb`

Update connection strings in `appsettings.json` for each service.

## Running the Services

### Build All Services
```bash
dotnet build
```

### Run Individual Services
```bash
# Notification Service
cd src && dotnet run

# Messaging Service
cd messaging-service && dotnet run

# Payment Service
cd payment-service && dotnet run
```

### Access Swagger Documentation
- NotificationService: https://localhost:7001/swagger
- MessagingService: https://localhost:7002/swagger
- PaymentService: https://localhost:7003/swagger

## Development

Each service can be developed independently and has its own:
- Models and entities
- Repository interfaces and implementations
- MediatR command/query handlers
- FluentValidation validators
- API endpoints
- Database migrations
- Configuration files