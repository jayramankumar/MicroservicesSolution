# MicroservicesSolution

Microservices solution for e-commerce application

## What's incide? 

![alt text](https://github.com/user-nik/MicroservicesSolution/blob/master/1.png?raw=true)

### Catalog microservice
- Mongo DB NoSQL database
- Dockerfile implementation

### Basket microservice
- Redis as a DB
- RabbitMQ event sourcing
- Swagger Open API implementation

### RabbitMQ messaging library
- Base EventBus implementation and add references Microservices

### Order microservice
- ASP.NET Core Web API application
- Dockerfile implementation
- Consuming RabbitMQ messages

### WebUI ShoppingApp microservice which includes;
- Asp.net Core Web Application with Razor template
- Aspnet core razor tools: View Components, partial Views, Tag Helpers, Model Bindings and Validations


# How to start?
- docker-compose -f docker-compose.yml -f docker-compose.override.yml up –d

- RabbitMQ -> http://localhost:15672/ (guest/guest)
- Catalog API -> http://localhost:8000/swagger/index.html
- Basket API -> http://localhost:8001/swagger/index.html
- Order API -> http://localhost:8002/swagger/index.html
- Web UI -> http://localhost:8003/

![alt text](https://github.com/user-nik/MicroservicesSolution/blob/master/2.png?raw=true)
