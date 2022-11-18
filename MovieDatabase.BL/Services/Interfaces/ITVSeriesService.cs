using MovieDatabase.Shared.DTOs.Movie;
using MovieDatabase.Shared.DTOs.TVSeries;
using MovieDatabaseShared.DTOs.Movie;
using MovieDatabaseShared.DTOs.TVSeries;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MovieDatabase.BL.Services.Interfaces
{
    public interface ITVSeriesService
    {
        /// <summary>
        /// Returns all TV Series
        /// </summary>
        /// <returns>all tv series</returns>
        Task<IEnumerable<TVSeriesAlbumViewDTO>> GetTVSeriesAlbumsAsync();

        /// <summary>
        /// Returns paged TV Series
        /// </summary>
        /// <param name="itemsInPage">number of items in one page</param>
        /// <param name="page">current page</param>
        /// <returns>paged TV Series</returns>
        IEnumerable<TVSeriesAlbumViewDTO> GetTVSeriesAlbumsPaged(int itemsInPage, int page);

        /// <summary>
        /// Returns TV Series detail
        /// </summary>
        /// <param name="id">Of TV Series to return detail of</param>
        /// <returns>TV Series detail</returns>
        TVSeriesDetailDTO GetTVSeriesDetail(int id);

        /// <summary>
        /// Returns TV Series detail from TVSeriesAlbumView
        /// </summary>
        /// <param name="tvSeriesAlbumView">album view of TV Series to return detail of</param>
        /// <returns>TV Series detail</returns>
        TVSeriesDetailDTO GetTVSeriesDetail(TVSeriesAlbumViewDTO tvSeriesAlbumView);
    }
}
