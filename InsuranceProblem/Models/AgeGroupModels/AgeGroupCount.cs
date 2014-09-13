using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace InsuranceProblem.Models
{
    public class AgeGroupCount
    {
        public AgeGroupVisit AgeGroup = new AgeGroupVisit();
        public int MemberCount { get; set; }
    }
}
