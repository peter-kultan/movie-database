using MovieDatabase.Shared.DTOs.Movie;
using MovieDatabaseShared.DTOs.Movie;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MovieDatabase.BL.Services.Interfaces
{
    public interface IMovieService
    {
        /// <summary>
        /// Returns all Movies stored in database
        /// </summary>
        /// <returns>all movies stored in database</returns>
        ICollection<MovieAlbumViewDTO> GetMovieAlbumsAsync();

        /// <summary>
        /// Returns paged movies
        /// </summary>
        /// <param name="itemsInPage">nomber of items in one page</param>
        /// <param name="page">current page</param>
        /// <returns>paged movies</returns>
        Task<ICollection<MovieAlbumViewDTO>> GetMovieAlbumsPaged(int itemsInPage, int page);

        /// <summary>
        /// Returns detail of movie specified by id
        /// </summary>
        /// <param name="id">id of movie to get details</param>
        /// <returns>detail of movie</returns>
        MovieDetailDTO GetMovieDetail(int id);

        /// <summary>
        /// Returns detail of movie from MovieAlbumView
        /// </summary>
        /// <param name="movieAlbumView">movie to get details</param>
        /// <returns>detail of movie</returns>
        MovieDetailDTO GetMovieDetail(MovieAlbumViewDTO movieAlbumView);
    }
}
