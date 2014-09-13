using System.Net;
using InsuranceProblem.Models;
using System.Web.Mvc;

namespace InsuranceProblem.Controllers
{
    public class CalculateMixtureController : JsonController
    {
        [HttpPost]
        public ActionResult Calculate(RequestResponse input)
        {
            try
            {
                InsuranceProblemBl bl = new InsuranceProblemBl();

                if (input.TargetVisit > 0 )
                    input.Result = bl.FindAgeGroupMix(input.TargetVisit).Count;

                return Json(input, JsonRequestBehavior.AllowGet);
            }
            catch (System.Exception ex)
            {
                 return new HttpStatusCodeResult(HttpStatusCode.InternalServerError);
            }
        }       
    }    
}