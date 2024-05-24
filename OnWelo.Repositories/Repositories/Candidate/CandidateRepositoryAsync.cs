using Microsoft.AspNetCore.Mvc.Rendering;
using Newtonsoft.Json;
using OnWelo.Models.Interfaces.Candidate;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnWelo.Repositories.Repositories.Candidate
{
    public class CandidateRepositoryAsync : ICandidateRepositoryAsync
    {
        public async Task<int> CreateCandidate(Models.Models.Candidate candidate,string jsonPath)
        {
            var jsonData = System.IO.File.ReadAllText(jsonPath + @"\OnweloData\Candidates.json");
            // De-serialize to object or create new list
            var employeeList = JsonConvert.DeserializeObject<List<Models.Models.Candidate>>(jsonData)
                                  ?? new List<Models.Models.Candidate>();
            // Add any new employees
            employeeList.Add(new Models.Models.Candidate()
            {
                CandidateId= candidate.CandidateId,
                CandidateName= candidate.CandidateName,
                PartyName= candidate.PartyName
            });
            // Update json data string
            jsonData = JsonConvert.SerializeObject(employeeList);
            System.IO.File.WriteAllText(jsonPath + @"\OnweloData\Candidates.json", jsonData);
            return 1;
        }

        public async Task<List<Models.Models.Candidate>> GetAllCandidates(string jsonPath)
        { 
            List<Models.Models.Candidate> lstcandidates = new();
            var json = File.ReadAllText(jsonPath + @"\OnweloData\Candidates.json");
            lstcandidates = JsonConvert.DeserializeObject<List<Models.Models.Candidate>>(json);
            return lstcandidates;
        }

        public async Task<List<SelectListItem>> GetAllCandidatesName(string jsonPath)
        {
            List<Models.Models.Candidate> lstvoters = new();
            var json = File.ReadAllText(jsonPath + @"\OnweloData\Candidates.json");
            lstvoters = JsonConvert.DeserializeObject<List<Models.Models.Candidate>>(json);
            var result = lstvoters.Select(x => new SelectListItem
            { Value = x.CandidateId.ToString(), Text = x.CandidateName })
                                                .OrderBy(a => a.Text).ToList();
            return result;
        }
    }
}
