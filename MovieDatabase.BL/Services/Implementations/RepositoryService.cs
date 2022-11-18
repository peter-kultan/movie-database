using AutoMapper;
using MovieDatabase.BL.Services.Interfaces;
using MovieDatabase.DAL.EfCore.Models;
using MovieDatabase.Infrastructure.Query;
using MovieDatabase.Infrastructure.Repository;
using MovieDatabase.Shared.DTOs.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MovieDatabase.BL.Services.Implementations
{
    internal class RepositoryService : IRepositoryService
    {
        private readonly IMapper _mapper;
        private readonly IRepository<Repository> _repositoryRepository;
        private readonly IQueryObject<Repository> _queryObject;

        public RepositoryService(IMapper mapper, IRepository<Repository> repositoryRepository, IQueryObject<Repository> queryObject)
        {
            _mapper = mapper;
            _repositoryRepository = repositoryRepository;
            _queryObject = queryObject;
        }

        public RepositoryCreateDTO CreateRepository(RepositoryCreateDTO repository)
        {
            _repositoryRepository.Insert(_mapper.Map<Repository>(repository));
            return repository;
        }

        public async Task DeleteRepository(int repositoryId)
        {
            await _repositoryRepository.DeleteAsync(repositoryId);
        }

        public ICollection<RepositoryCreateDTO> ListRepositories()
        {
            return _mapper.Map<ICollection<RepositoryCreateDTO>>(_repositoryRepository.GetAll());
        }

        public async Task<ICollection<RepositoryCreateDTO>> PageRepositories(int itemsOnPage, int page)
        {
            return _mapper.Map<ICollection<RepositoryCreateDTO>>(await _queryObject.Page(itemsOnPage, page).ExecuteAsync());
        }

        public RepositoryUpdateDTO UpdateRepository(RepositoryUpdateDTO repository)
        {
            _repositoryRepository.Update(_mapper.Map<Repository>(repository));

            return repository;
        }
    }
}
