using MovieDatabase.Shared.DTOs.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MovieDatabase.BL.Services.Interfaces
{
    public interface IRepositoryService
    {
        /// <summary>
        /// Create new repository with provided informations
        /// </summary>
        /// <param name="repository">Information to create repository with</param>
        /// <returns>neawly created repository</returns>
        RepositoryCreateDTO CreateRepository(RepositoryCreateDTO repository);

        /// <summary>
        /// Delete repository specified by id
        /// </summary>
        /// <param name="repositoryId">id of repostitory to be deleted</param>
        /// <returns></returns>
        Task DeleteRepository(int repositoryId);

        /// <summary>
        /// Update repository
        /// </summary>
        /// <param name="repository">repository to be updated</param>
        /// <returns>updated repository</returns>
        RepositoryUpdateDTO UpdateRepository(RepositoryUpdateDTO repository);

        /// <summary>
        /// Returns all repositories
        /// </summary>
        /// <returns>all repositories</returns>
        ICollection<RepositoryCreateDTO> ListRepositories();

        /// <summary>
        /// Returns paged repositories
        /// </summary>
        /// <param name="itemsOnPage">number of repositories on one page</param>
        /// <param name="page">current page</param>
        /// <returns>paged repositories</returns>
        Task<ICollection<RepositoryCreateDTO>> PageRepositories(int itemsOnPage, int page);
    }
}
