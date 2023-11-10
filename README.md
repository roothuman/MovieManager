# Movie Manager API

This API allows you to manage movies.

## API Documentation

To explore the API documentation and test the endpoints, visit the Swagger UI:

[Swagger Documentation](https://localhost:<your_port>/swagger)

## Endpoints

- **POST /api/movies**: Create a new movie.
- **GET /api/movies/{id}**: Get a movie by ID.
- **PUT /api/movies/{id}**: Update a movie by ID.
- **DELETE /api/movies/{id}**: Delete a movie by ID.
- **GET /api/movies**: Get all movies.

##sample payload to add a movie

{
  "name": "The Matrix",
  "description": "A groundbreaking sci-fi film",
  "releaseDate": "2023-11-10T10:16:11.708Z",
  "rating": 5,
  "ticketPrice": 14.99,
  "country": "USA",
  "genres": [
    {
      "id": 1,
      "name": "Sci-Fi"
    },
    {
      "id": 2,
      "name": "Action"
    }
  ],
  "photo": "matrix.jpg"
}
