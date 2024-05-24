using Microsoft.AspNetCore.Mvc.Rendering;

namespace OnWelo.Models.Interfaces.Voter
{
    public interface IVoterRepositoryAsync
    {
        Task<List<OnWelo.Models.Models.Voter>> GetAllVoters(string jsonPath);
        Task<List<SelectListItem>> GetAllVotersName(string jsonPath);

        Task<int> CreateVoters(OnWelo.Models.Models.Voter voter, string jsonPath);
    }
}
