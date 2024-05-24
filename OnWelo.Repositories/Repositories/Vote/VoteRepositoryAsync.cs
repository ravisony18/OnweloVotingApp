using Newtonsoft.Json;
using OnWelo.Models.Interfaces.Vote;
using OnWelo.Models.Models;
using System;
using System.Collections.Generic;
using System.Diagnostics.Metrics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnWelo.Repositories.Repositories.Vote
{
    public class VoteRepositoryAsync : IVoteRepositoryAsync
    {
        public async Task<int> Createvote(string VoterId, string CandidateId, string jsonPath)
        {
            // To update Voterlist that voter has cast the vote.
            var jsonVotersData = System.IO.File.ReadAllText(jsonPath + @"\OnweloData\Voters.json");
            // De-serialize to object or create new list
            var votersList = JsonConvert.DeserializeObject<List<Models.Models.Voter>>(jsonVotersData)
            ?? new List<Models.Models.Voter>();
            var itemToEdit = votersList.Find(x => x.VoterId.Equals(VoterId));
            if(itemToEdit!=null)
                itemToEdit.HasVoted = true;
            string updatedJson = JsonConvert.SerializeObject(votersList, Formatting.Indented);
            System.IO.File.WriteAllText(jsonPath + @"\OnweloData\Voters.json", updatedJson);


            // Adding records into Votes.json file.
            var jsonVoteData = System.IO.File.ReadAllText(jsonPath + @"\OnweloData\Votes.json");
            // De-serialize to object or create new list
            var voteList = JsonConvert.DeserializeObject<List<Models.Models.Vote>>(jsonVoteData)
                                  ?? new List<Models.Models.Vote>();
            // Add any new votes
            voteList.Add(new Models.Models.Vote()
            {
                voteid = Guid.NewGuid().ToString("N").Substring(0, 10).ToUpper(),
                candidateid = CandidateId,
                voterId = VoterId
            });
            // Update json data string
            jsonVoteData = JsonConvert.SerializeObject(voteList);
            System.IO.File.WriteAllText(jsonPath + @"\OnweloData\Votes.json", jsonVoteData);


            return 1;

        }

        public async Task<List<Models.Models.VoteResult>> GetAllVotes(string jsonPath)
        {
            List<Models.Models.Candidate> lstCandidate = new();
            List<Models.Models.VoteResult> voteResults = new();
            List<Models.Models.Vote> lstVotes = new();
            var CandidatejsonData = File.ReadAllText(jsonPath + @"\OnweloData\Candidates.json");
            lstCandidate = JsonConvert.DeserializeObject<List<Models.Models.Candidate>>(CandidatejsonData);

            var VotejsonData = File.ReadAllText(jsonPath + @"\OnweloData\Votes.json");
            lstVotes = JsonConvert.DeserializeObject<List<Models.Models.Vote>>(VotejsonData);

            foreach ( var cand in lstCandidate)
            {
                voteResults.Add(new VoteResult()
                {
                    VoteResultId= Guid.NewGuid().ToString("N").Substring(0, 10).ToUpper(),
                    CandidateId = cand.CandidateId,
                    CandidateName = cand.CandidateName,
                    VoteCounts = lstVotes.Where(x => x.candidateid.Equals(cand.CandidateId)).Count()
                }) ;
            }




            return voteResults;
        }
    }
}
