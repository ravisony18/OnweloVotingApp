namespace OnWelo.Models.Models
{
    public class Voter
    {
        public required string VoterId { get; set; }
        public required string VoterName { get; set; }
        public bool HasVoted { get; set; }
    }
}
