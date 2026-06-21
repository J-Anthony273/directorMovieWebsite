# Film Directors Website

A full stack web application for browsing film directors and their complete filmographies, built as a C# learning project.

## Overview

Select a director from the sidebar to browse their films in chronological order with poster images. Click any film to view its IMDb score, description, and top cast — all powered by live data from The Movie Database (TMDb) API.

## Features

- Browse a curated list of directors
- View a director's complete filmography in release order with poster images
- Click any film to see its IMDb score, overview, and top 5 cast members
- Live data fetched from the TMDb API

## Tech Stack

**Backend**
- C# / ASP.NET Core Web API (.NET 10)
- Entity Framework Core with SQL Server Express
- TMDb REST API integration

**Frontend**
- HTML, CSS, JavaScript (vanilla)
- Fetches data from the backend API using async/await

## Project Structure

```
FilmDirectorsApi/
├── Controllers/
│   ├── DirectorsController.cs
│   └── FilmsController.cs
├── Data/
│   └── AppDbContext.cs
├── DTOs/
│   ├── DirectorDto.cs
│   ├── FilmDto.cs
│   ├── FilmDetailDto.cs
│   └── CastMemberDto.cs
├── Models/
│   ├── Director.cs
│   └── Film.cs
├── Services/
│   ├── TmdbService.cs
│   └── TmdbFilmResult.cs
├── wwwroot/
│   ├── index.html
│   ├── style.css
│   └── app.js
├── appsettings.json
└── Program.cs
```

## API Endpoints

| Method | Endpoint | Description |
|--------|----------|-------------|
| GET | `/api/directors` | Returns all directors |
| GET | `/api/directors/{id}` | Returns a director with their full TMDb filmography |
| GET | `/api/films/{tmdbId}` | Returns film details, poster, score, and cast from TMDb |

## Getting Started

### Prerequisites

- [.NET 10 SDK](https://dotnet.microsoft.com/download)
- [SQL Server Express](https://www.microsoft.com/en-us/sql-server/sql-server-downloads)
- A free [TMDb API key](https://www.themoviedb.org/settings/api)

### Setup

1. Clone the repository:
   ```bash
   git clone https://github.com/J-Anthony273/directorMovieWebsite.git
   cd directorMovieWebsite/FilmDirectorsApi
   ```

2. Add your TMDb API key and database connection string to `appsettings.json`:
   ```json
   {
     "ConnectionStrings": {
       "DefaultConnection": "Server=localhost\\SQLEXPRESS;Database=FilmDirectorsDb;Trusted_Connection=True;TrustServerCertificate=True;"
     },
     "TmdbSettings": {
       "ApiKey": "your_tmdb_api_key_here",
       "BaseUrl": "https://api.themoviedb.org/3"
     }
   }
   ```

3. Apply database migrations:
   ```bash
   dotnet ef database update
   ```

4. Run the app:
   ```bash
   dotnet run
   ```

5. Open your browser at `http://localhost:5000`

## What I Learned

This project was built to learn C# and ASP.NET Core from scratch. Key concepts covered:

- C# classes, generics, and LINQ
- ASP.NET Core Web API with controllers and routing
- Entity Framework Core (code-first, migrations, seeding)
- Dependency injection and service classes
- Calling external REST APIs with HttpClient
- DTOs to control API response shape and avoid circular references
- Connecting a vanilla JS frontend to a C# backend