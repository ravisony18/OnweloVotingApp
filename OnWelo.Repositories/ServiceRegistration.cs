using Microsoft.Extensions.DependencyInjection;
using OnWelo.Models.Interfaces.Voter;
using OnWelo.Repositories.Repositories.Voter;
using OnWelo.Models.Interfaces.Candidate;
using OnWelo.Repositories.Repositories.Candidate;
using OnWelo.Models.Interfaces.Vote;
using OnWelo.Repositories.Repositories.Vote;

namespace OnWelo.Repositories
{
    public static class ServiceRegistration
    {
        public static void AddPersistenceLayer(this IServiceCollection services)
        {
            #region Repositories
            /// Dependency Register for Classes.... 
            services.AddTransient(typeof(IVoterRepositoryAsync), typeof(VoterRepositoryAsync));
            services.AddTransient(typeof(ICandidateRepositoryAsync), typeof(CandidateRepositoryAsync));
            services.AddTransient(typeof(IVoteRepositoryAsync), typeof(VoteRepositoryAsync));
            #endregion
        }
    }
}