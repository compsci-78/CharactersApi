﻿using CharactersApi.Models;

namespace CharactersApi.Services.Movies
{
    public interface IMovieService
    {
        Task<IEnumerable<Movie>> GetAllMovies();
        Task<Movie> GetMovieById(int id);
        Task<Movie> AddMovie(Movie movie);
        Task DeleteMovie(int id);
        Task<Movie> UpdateMovie(Movie movie);
    }
}