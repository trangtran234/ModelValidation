using ModelValidation.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace ModelValidation.Infrastructure
{
    public class NoJoeOnMondaysAttribute : ValidationAttribute
    {
        public NoJoeOnMondaysAttribute()
        {
            ErrorMessage = "Joe cannot book appointments on Monday";
        }
        public override bool IsValid(object value)
        {
            Appointment app = value as Appointment;

            return (app == null || string.IsNullOrEmpty(app.ClientName) || app.Date == null) 
                ? true 
                : !(app.ClientName == "Joe" && app.Date.DayOfWeek == DayOfWeek.Monday);
        }
    }
}