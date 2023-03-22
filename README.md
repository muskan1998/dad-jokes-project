# dad-jokes-project

The solution involves creating a C#/.NET backend service that communicates with the "I can haz dad joke" (https://icanhazdadjoke.com/api)  API to fetch jokes and prepares them for display. The backend service will expose two endpoints, one for fetching a random joke, and the other for searching and displaying jokes based on a search term.

The following steps outline the solution:

1. Create a new C#/.NET project using Visual Studio.
2. Install the required NuGet packages for HTTP client and JSON serialization.
3. Create a class to represent the joke object returned by the API.
4. Create a class to handle the communication with the API, including methods for fetching a random joke and searching for jokes based on a search term.
5. Create a controller to handle HTTP requests and responses, including endpoints for fetching a random joke and searching for jokes.
6. Implement the logic for searching and grouping jokes by length (short, medium, long).
5. Implement some simple way of emphasizing the search term in the matching jokes (e.g. using Upper Case text in this case.).

This solution should provide a simple and easy-to-use API for fetching dad jokes.
