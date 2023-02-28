using CharactersApi.Models;

namespace CharactersApi.Services.Franchises
{
    public interface IFranchiseService
    {
        Task<IEnumerable<Franchise>> GetAllFranchises();
        Task<Franchise> GetFranchiseById(int id);
        Task<Franchise> AddFranchise(Franchise franchise);
        Task DeleteFranchise(int id);
        Task<Franchise> UpdateFranchise(Franchise franchise);
        Task UpdateFranchiseMovies(int id, List<int>moviesId);
        
    }
}
