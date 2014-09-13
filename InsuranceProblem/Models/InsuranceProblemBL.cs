using System;
using System.Collections.Generic;
using System.Diagnostics.Eventing.Reader;
using System.Linq;
using System.Security.AccessControl;
using System.Web;
using InsuranceProblem.App_Start;
using MongoDB.Driver.Linq;

namespace InsuranceProblem.Models
{
    public class InsuranceProblemBl
    {
        public int TargetPhysicianVisit { get; set; }
        public List<AgeGroupVisit> SortedAgeGroupVisits = new List<AgeGroupVisit>();
        public List<AgeGroupMix> ResultSet = new List<AgeGroupMix>();
        public readonly InsuranceProblemContext context = new InsuranceProblemContext();


        public List<AgeGroupMix> FindAgeGroupMix(int targetPhysicianVisit)
        {
            TargetPhysicianVisit = targetPhysicianVisit;
            SortedAgeGroupVisits = (from agv in context.AgeGroupVisitCollection.FindAll()
                                    orderby agv.Visit  
                                    select agv).ToList();
            Combination(0, new AgeGroupMix());
            return ResultSet;
        }

        private void Combination(int index, AgeGroupMix calculatedAgeGroupMix)
        {
            if (index == SortedAgeGroupVisits.Count)
                return;
            
            var ageGroupCount = new AgeGroupCount
            {
                AgeGroup = SortedAgeGroupVisits[index]
            };
            for (var i = 0;; i++)
            {
                var existingAgeGroup =
                    calculatedAgeGroupMix.AgeGroupCounts.Find(
                        cag => cag.AgeGroup.AgeGroupId == ageGroupCount.AgeGroup.AgeGroupId);
               
                if (existingAgeGroup != null)
                    existingAgeGroup.MemberCount = i;
                else
                {
                    ageGroupCount.MemberCount = i;
                    calculatedAgeGroupMix.AgeGroupCounts.Add(ageGroupCount);
                }

                if (calculatedAgeGroupMix.TotalVisits == TargetPhysicianVisit)
                {
                    calculatedAgeGroupMix.AgeGroupCounts.RemoveAll(agc => agc.MemberCount == 0);
                    ResultSet.Add(CopyCalculatedAgeGroupMix(calculatedAgeGroupMix));
                    calculatedAgeGroupMix.AgeGroupCounts.Remove(ageGroupCount);
                    return;
                }
                else if (calculatedAgeGroupMix.TotalVisits < TargetPhysicianVisit)
                    Combination(index + 1, calculatedAgeGroupMix);
                else if (calculatedAgeGroupMix.TotalVisits > TargetPhysicianVisit)
                {
                    calculatedAgeGroupMix.AgeGroupCounts.Remove(ageGroupCount);
                    return;
                }
            }

        }

        private AgeGroupMix CopyCalculatedAgeGroupMix(AgeGroupMix calculatedAgeGroupMix)
        {
            var ageGroupCounts = new List<AgeGroupCount>();
            

            foreach (var ageGroupCount in calculatedAgeGroupMix.AgeGroupCounts)
            {
                var _ageGroupCount = new AgeGroupCount
                {
                    AgeGroup = ageGroupCount.AgeGroup,
                    MemberCount = ageGroupCount.MemberCount
                };
                ageGroupCounts.Add(_ageGroupCount);
            }

            var addCalculatedAgeGroupMix = new AgeGroupMix
            {
                AgeGroupCounts = ageGroupCounts
            };
            return addCalculatedAgeGroupMix;
        }
    }
}