using DataAccess;
using DataAccess.Entety;
using DataAccess.Repo;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Reflection;
using System.Web;
using HelthSystem.Models;
namespace HelthSystem.ValidationAtribute
{
    public class Unique : ValidationAttribute
    {

        private string targetProperty;

        public Unique(string targetProperty)
        {
            this.targetProperty = targetProperty;
        }

        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            var otherPropertyInfo = validationContext.ObjectType.GetProperty(this.targetProperty);
            var referenceProperty = (int)otherPropertyInfo.GetValue(validationContext.ObjectInstance, null);

            AppointmentRepo appointmentRepo = new AppointmentRepo();
            List<Appointment> all = appointmentRepo.GetAll().ToList();
            List<Appointment> result = new List<Appointment>();

            foreach (var item in all)
            {
                if (item.Doctor.UserId == referenceProperty)
                {
                    result.Add(item);
                }
            }

            foreach (var item in result)
            {
                if (item.Date.ToString() == value.ToString())
                {
                    return new ValidationResult("This Date is already set");
                }
            }

            return base.IsValid(value, validationContext);
        }

        public override bool IsValid(object value)
        {
            return String.IsNullOrEmpty(this.ErrorMessage);
        }

    }
}