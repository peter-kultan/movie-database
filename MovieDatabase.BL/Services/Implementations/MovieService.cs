using AutoMapper;
using MovieDatabase.BL.Services.Interfaces;
using MovieDatabase.DAL.EfCore.Models;
using MovieDatabase.Infrastructure.Query;
using MovieDatabase.Infrastructure.Repository;
using MovieDatabase.Infrastructure.UnitOfWork;
using MovieDatabase.Shared.DTOs.Movie;
using MovieDatabaseShared.DTOs.Movie;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MovieDatabase.BL.Services.Implementations
{
    public class MovieService : IMovieService
    {
        private readonly IMapper _mapper;
        private readonly IRepository<Movie> _movieRepository;
        private readonly IQueryObject<Movie> _movieQueryObject;

        public MovieService(IMapper mapper, IRepository<Movie> movieRepository, IQueryObject<Movie> movieQueryObject)
        {
            _mapper = mapper;
            _movieRepository = movieRepository;
            _movieQueryObject = movieQueryObject;
        }

        public ICollection<MovieAlbumViewDTO> GetMovieAlbumsAsync()
        {
            return _mapper.Map<ICollection<MovieAlbumViewDTO>>(_movieRepository.GetAll());
        }

        public async Task<ICollection<MovieAlbumViewDTO>> GetMovieAlbumsPaged(int itemsInPage, int page)
        {
            return _mapper.Map<ICollection<MovieAlbumViewDTO>>(await _movieQueryObject.Page(itemsInPage, page).ExecuteAsync());
        }

        public MovieDetailDTO GetMovieDetail(int id)
        {
            return _mapper.Map<MovieDetailDTO>(_movieRepository.GetById(id));
        }

        public MovieDetailDTO GetMovieDetail(MovieAlbumViewDTO movieAlbumView)
        {
            return _mapper.Map<MovieDetailDTO>(movieAlbumView);
        }
    }
}
