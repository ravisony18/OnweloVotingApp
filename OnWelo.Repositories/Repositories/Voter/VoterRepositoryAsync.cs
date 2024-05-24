using Microsoft.AspNetCore.Mvc.Rendering;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using OnWelo.Models.Interfaces.Voter;
using OnWelo.Models.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnWelo.Repositories.Repositories.Voter
{
    public class VoterRepositoryAsync : IVoterRepositoryAsync
    {
        public async Task<int> CreateVoters(Models.Models.Voter voter, string jsonPath)
        {
            var jsonData = System.IO.File.ReadAllText(jsonPath + @"\OnweloData\Voters.json");
            // De-serialize to object or create new list
            var employeeList = JsonConvert.DeserializeObject<List<Models.Models.Voter>>(jsonData)
                                  ?? new List<Models.Models.Voter>();
            // Add any new employees
            employeeList.Add(new Models.Models.Voter()
            {
                VoterId=voter.VoterId,
                VoterName=voter.VoterName,
                HasVoted=false
            });
            // Update json data string
            jsonData = JsonConvert.SerializeObject(employeeList);
            System.IO.File.WriteAllText(jsonPath + @"\OnweloData\Voters.json", jsonData);
            return 1;
        }

        public async Task<List<Models.Models.Voter>> GetAllVoters(string jsonPath)
        {
            List<Models.Models.Voter> lstvoters = new();
            var json = File.ReadAllText(jsonPath + @"\OnweloData\Voters.json");
            lstvoters = JsonConvert.DeserializeObject<List<Models.Models.Voter>>(json);
            return lstvoters;
        }

        public async Task<List<SelectListItem>> GetAllVotersName(string jsonPath)
        {
            List<Models.Models.Voter> lstvoters = new();
            var json = File.ReadAllText(jsonPath + @"\OnweloData\Voters.json");
            lstvoters = JsonConvert.DeserializeObject<List<Models.Models.Voter>>(json);
            var result= lstvoters.Where(x=>x.HasVoted==false).Select(x => new SelectListItem
            { Value = x.VoterId, Text = x.VoterName })
                                                .OrderBy(a => a.Text).ToList();
            return result;
        }
    }
}
