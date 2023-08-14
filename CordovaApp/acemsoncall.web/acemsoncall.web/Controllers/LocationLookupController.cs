﻿using acemsoncall.web.Models.EntityModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Data.Entity;

namespace acemsoncall.web.Controllers
{
    public class LocationLookupController : Controller
    {
        private acemsEntities db = new acemsEntities();

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        // GET: LocationLookup
        public ActionResult Index()
        {
            var eMSContents = db.EMSContents.Where(e=>e.contenttype=="Location").OrderByDescending(e=>e.id).Include(e => e.AspNetUser).Include(e => e.AspNetUser1);
            return View(eMSContents.ToList());
        }
    }
}