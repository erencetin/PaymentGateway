# PaymentGateway API
PaymentGateway solution has been developed as part of the Checkout.com technical assesment test.
API allows the merchant to offer a way for their customers to pay for their shopping.

# Installation
## Prerequisites
.Net 6.0

## Running the application
With Visual Studio 2022 run Checkout.sln
OR
With command prompt Checkout.Payment.Api > dotnet run
You can access swagger documentation with this url 
https://localhost:7209/swagger

# Project structure

The solution consists of three different layers and one test project.

## Checkout.Payment.Core
This is the core layer of the application and the center of the architecture. All other project dependencies will point towards it.

The Core layer includes the types such as:
Interfaces,
DTO classes,
DB Entity models,
Enums

## Checkout.Payment.Infrastructure
Infrastructure layer contains classes for accessing external resources like databases and api's. These classes are be based on interfaces defined within the core layer.
The Acquiring Bank integration has been established in this layer.  To store payment summary it uses Entity Framwork to connect InMemory Db.


