using DataAccess;
using DataAccess.Entety;
using DataAccess.Repo;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Reflection;
using System.Web;

namespace HelthSystem.ValidationAtribute
{
    public class GenericUnique: ValidationAttribute
    {
        private string entityTypeName;

        public GenericUnique(string entityTypeName)
        {
            this.entityTypeName = entityTypeName;
        }

        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            Type entityType = Assembly.GetAssembly(typeof(BaseEntety)).GetType(entityTypeName);

            var repo = CreateRepo(entityType);

            PropertyInfo pi = entityType.GetProperty(validationContext.MemberName);

            object entity = repo.GetType().GetMethod("GetAll").Invoke(repo, null);

            if (entity != null)
            {
                return new ValidationResult("E-mail already exist.");
            }

            return ValidationResult.Success;
        }

        private object CreateRepo(Type entityType)
        {
            if (entityType.Name == typeof(User).Name)
            {
                return new UserRepo();
            }
            else if (entityType.Name == typeof(Doctor).Name)
            {
                return new DoctorRepo();
            }
            else if (entityType.Name == typeof(Appointment).Name)
            {
                return new AppointmentRepo();
            }
            return null;
        }
    }
}