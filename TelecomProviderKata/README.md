# Telecom Provider (asier aduriz)
This is my basic implementation of the Telecom Provider challenge covering the three endpoints

- `GET /api/TelecomProvider`
- `GET /api/TelecomProvider/X`
- `POST /api/TelecomProvider`

## Missing things
- Remove duplicate phones when getting all phones
- Find a way to having a factory for the repository pattern to have in memory for acceptance tests and real repository for production code
- Controller return object to be more complex with message to indicate an exception for example, than a status code
- Many more other things

## Running
- Not sure whether this command is needed, but navigate to the top level of the project, i.e. where the `README.md` is and in a command line type `dotnet build`
- To run the application type in a command line `dotnet run --project TelecomProvider`
- Every request should start with `http://localhost:5000`, i.e. `http://localhost:5000/api/TelecomProvider/`

### Accessing the endpoints
- To get all phones, make a GET request to `http://localhost:5000/api/TelecomProvider/`
- To activate a phone tied to a customer, make a post at `http://localhost:5000/api/TelecomProvider/` with the following body `{ "PhoneNumber": X, "CustomerId": Y }` where `X` and `Y` are integers of your choice.
- To get all phones related to a customer, make a GET request to `http://localhost:5000/api/TelecomProvider/X`
-- I've intentionately left an OK with an empty list instead of throwing an exception, which for me makes more sense to have an empty list for a customer
