using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnWelo.Models.Interfaces.Candidate
{
    public interface ICandidateRepositoryAsync
    {
        Task<List<OnWelo.Models.Models.Candidate>> GetAllCandidates(string jsonPath);
        Task<List<SelectListItem>> GetAllCandidatesName(string jsonPath);
        Task<int> CreateCandidate(OnWelo.Models.Models.Candidate candidate, string jsonPath);
    }
}
