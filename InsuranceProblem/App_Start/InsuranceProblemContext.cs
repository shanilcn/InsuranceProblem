using InsuranceProblem.Models;
using InsuranceProblem.Properties;
using MongoDB.Driver;


namespace InsuranceProblem.App_Start
{
    public class InsuranceProblemContext
    {
        public MongoDatabase db;
        public InsuranceProblemContext()
        {
            var client = new MongoClient(Settings.Default.InsuranceProblemConnectionString);
            var server = client.GetServer();
            db = server.GetDatabase(Settings.Default.InsuranceProblem);
        }

        public MongoCollection<AgeGroupVisit> AgeGroupVisitCollection
        {
            get
            {
                return db.GetCollection<AgeGroupVisit>("AgeGroupVisits");
            }
        }
        
    }
}