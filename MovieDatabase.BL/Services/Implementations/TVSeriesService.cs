using AutoMapper;
using MovieDatabase.BL.Services.Interfaces;
using MovieDatabase.DAL.EfCore.Models;
using MovieDatabase.Infrastructure.Query;
using MovieDatabase.Infrastructure.Repository;
using MovieDatabase.Shared.DTOs.TVSeries;
using MovieDatabaseShared.DTOs.TVSeries;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MovieDatabase.BL.Services.Implementations
{
    public class TVSeriesService : ITVSeriesService
    {
        private readonly IMapper _mapper;
        private readonly IRepository<TVSeries> _tvSeriesRepository;
        private readonly IQueryObject<TVSeries> _tvSeriesQueryObject;

        public TVSeriesService(IMapper mapper, IRepository<TVSeries> tvSeriesRepository, IQueryObject<TVSeries> tvSeriesQueryObject)
        {
            _mapper = mapper;
            _tvSeriesRepository = tvSeriesRepository;
            _tvSeriesQueryObject = tvSeriesQueryObject;
        }

        public ICollection<TVSeriesAlbumViewDTO> GetTVSeriesAlbumsAsync()
        {
            return _mapper.Map<ICollection<TVSeriesAlbumViewDTO>>(_tvSeriesRepository.GetAll());
        }

        public async Task<ICollection<TVSeriesAlbumViewDTO>> GetTVSeriesAlbumsPaged(int itemsInPage, int page)
        {
            return _mapper.Map<ICollection<TVSeriesAlbumViewDTO>>(await _tvSeriesQueryObject.Page(itemsInPage, page).ExecuteAsync());
        }

        public TVSeriesDetailDTO GetTVSeriesDetail(int id)
        {
            return _mapper.Map<TVSeriesDetailDTO>(_tvSeriesRepository.GetById(id));
        }

        public TVSeriesDetailDTO GetTVSeriesDetail(TVSeriesAlbumViewDTO tvSeriesAlbumView)
        {
            return _mapper.Map<TVSeriesDetailDTO>(tvSeriesAlbumView);
        }
    }
}
