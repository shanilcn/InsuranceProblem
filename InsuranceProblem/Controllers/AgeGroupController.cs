using System.Net;
using InsuranceProblem.App_Start;
using InsuranceProblem.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MongoDB.Bson;

namespace InsuranceProblem.Controllers
{
    public class AgeGroupController : JsonController
    {
        public readonly InsuranceProblemContext context = new InsuranceProblemContext();

        public ActionResult Index()
        {
            return Json(context.AgeGroupVisitCollection.FindAll(), JsonRequestBehavior.AllowGet);
        }  

        [HttpPost]
        public ActionResult Save(AgeGroupVisit ageGroupVisit)
        {
            try
            {
                ageGroupVisit.AgeGroupId = ObjectId.GenerateNewId();   
                context.AgeGroupVisitCollection.Insert(ageGroupVisit);
                return new HttpStatusCodeResult(HttpStatusCode.OK);
            }
            catch (Exception ex)
            {
                return new HttpStatusCodeResult(HttpStatusCode.InternalServerError);
            }
        }
    }
}