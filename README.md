# Online Retail Demo API

## Introduction

Sample API implementation to demostrate the end to end flow of a platform service. Demo service includes the APIs below.

- GET /products/{id}
- POST /products
- PUT /products/{id}
- DELETE /products/{id}

- DELETE /orders/{id}
- POST /orders

## Technical Architecture

Demo retail API includes following components:

- .net core web api
- xUnit 
- Dapper (Micro ORM)
- Amazon ECS - Fargate
- Amazon RDS - PostgreSQL
- Jenkins / Github Actions

Code flow is strucutred using Clean Architecture principle. 
