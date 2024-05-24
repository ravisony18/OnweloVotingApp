using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnWelo.Models.Models
{
    public class VoteResult
    {
        public required string VoteResultId { get; set; }
        public required string CandidateId { get; set; }
        public required string CandidateName { get; set; }
        public int VoteCounts { get; set; }

    }
}
