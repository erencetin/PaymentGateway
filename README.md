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

## Checkout.Payment.Api
Web Api project consists of two entpoints; SendTransaction and GetTransaction.
Below is the simple request body to send a payment.

```json
{
  "merchantId": "8ee7751b-c2f1-4307-b871-bee34e3ba35b",
  "customerName": "James Dean",
  "cardName": "James Dean",
  "cardNumber": "5674112123432345",
  "cvv": 116,
  "expireDate": "2026-12-01T00:00:00",
  "amount": 16.7,
  "currency": 1,
  "transactionTime": "2022-11-16T13:45:11.0401262+01:00"
}
```
And a sample response body: 
```json
{
  "paymentId": "a3bb224d-a909-4379-a14c-bc3f40351732",
  "merchantId": "ed6ce9e9-a573-45af-963d-8bc724a09161",
  "customerName": "James Dean",
  "cardName": "James Dean",
  "amount": 16.7,
  "currency": 1,
  "transactionTime": "2022-11-16T12:57:01.2975535+01:00",
  "status": 0
}
```

