# ASP.NET Car Stock Web API with Swagger
### Requirements
- NET 8.0
- Swashbuckle.AspNetCore 6.4

### Run
Run project in Visual Studio\
`dotnet run` in Visual Studio Code\
Open brower and visit:`http://localhost:5264/swagger/index.html`

### How To Use
In order to ensure each dealer can only have access to their own stock, api key authentication is implemented. Call GetAllApiKeys to view existing dealers or Register a new dealer.\
An api key is generated after registering a dealer with a unique dealerId. This api key can be entered via Authorisation button to get access to all the other apis, including:
- get all cars of the dealer
- get a car by make
- edit a car by id
- add a car by id
- remove a car by id