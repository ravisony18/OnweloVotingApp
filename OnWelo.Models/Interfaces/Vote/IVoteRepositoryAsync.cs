using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnWelo.Models.Interfaces.Vote
{
    public interface IVoteRepositoryAsync
    {
        Task<List<OnWelo.Models.Models.VoteResult>> GetAllVotes(string jsonPath);
        Task<int> Createvote(string VoterId,string CandidateId, string jsonPath);
    }
}
