using ModelValidation.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ModelValidation.Controllers
{
    public class HomeController : Controller
    {
        public ViewResult MakeBooking()
        {
            return View(new Appointment { Date = DateTime.Now });
        }
        [HttpPost]
        public ViewResult MakeBooking(Appointment appt)
        {
            return (ModelState.IsValid) 
                ? View("Completed", appt) 
                : View();
        }

        public JsonResult ValidateDate(string Date)
        {
            DateTime parsedDate;
            if (DateTime.TryParse(Date, out parsedDate))
            {
                return Json("Please enter a valid data (mm/dd/yyyy)", 
                    JsonRequestBehavior.AllowGet);
            }
            else if (DateTime.Now > parsedDate)
            {
                return Json("Please enter a date in the future", 
                    JsonRequestBehavior.AllowGet);
            }
            else
            {
                return Json(true, JsonRequestBehavior.AllowGet);
            }
        }
    }
}