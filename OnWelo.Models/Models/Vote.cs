using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnWelo.Models.Models
{
    public class Vote
    {
        public required string voteid { get; set; }
        public required string candidateid { get; set; }
        public required string voterId { get; set; }
    }

   

}
