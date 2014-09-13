using System.Collections.Generic;
using System.Linq;

namespace InsuranceProblem.Models
{
    public class AgeGroupMix
    {
        public List<AgeGroupCount> AgeGroupCounts = new List<AgeGroupCount>();

        public decimal TotalVisits
        {
            get { return AgeGroupCounts.Sum(x => ( x.MemberCount * x.AgeGroup.Visit)); }
        }
        //public int TotalMix { get; set; }
    }
}