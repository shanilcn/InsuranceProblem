using System;
using System.Linq;
using System.Web;
using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace InsuranceProblem.Models
{
    public class AgeGroupVisit
    {
        [BsonId]
        public ObjectId AgeGroupId { get; set; }
        public string AgeGroupDescription { get; set; }
        public decimal Visit { get; set; }          
    }
}