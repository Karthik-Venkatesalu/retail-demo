# online-retail-demo-api

## Introduction

Sample API implementation to demostrate the end to end flow of a platform service. Demo service includes the APIs below.

- GET /products
- GET /products/{id}
- POST /products
- PATCH /products/{id}

- GET /orders/{id}
- POST /orders

## Technical Architecture

Demo retail API includes following components:

- .net core web api
- Amazon ECS - Fargate
- Amazon Aurora PostgreSQL
- Jenkins / Github Actions

Code flow is strucutred using Clean Architecture principle. 
