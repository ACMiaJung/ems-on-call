using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using acemsoncall.web.Models.EntityModel;
using Microsoft.AspNet.Identity;

namespace acemsoncall.web.Controllers
{
    [Authorize]
    public class ShiftController : Controller
    {
        // GET: Shift
        public ActionResult Index()
        {
            return View();
        }
        [HttpGet]
        public ActionResult CheckIn()
        {
            return View();
        }
        [HttpPost]
        public ActionResult CheckIn(string MedicalRank)
        {
            using(acemsEntities db = new acemsEntities())
            {
                string _userId = User.Identity.GetUserId();
                var user = db.AspNetUsers.FirstOrDefault(u=>u.Id == _userId);
                if (user != null)
                {
                    var sameRankUsers = db.AspNetUsers.Where(u=>u.MedicalRank == MedicalRank && u.IsCheckedIn == true).ToList();
                    foreach(var sameUser in sameRankUsers)
                    {
                        sameUser.IsCheckedIn = false;
                    }
                    user.MedicalRank = MedicalRank;
                    user.IsCheckedIn = true;
                    user.CheckedInDT = DateTime.Now;
                    db.SaveChanges();
                }
            }
            return View();
        }
    }
}