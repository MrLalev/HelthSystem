using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace HelthSystem.ValidationAtribute
{
    public class MatchValue: ValidationAttribute
    {
        private string targetProperty;

        public MatchValue(string targetProperty)
        {
            this.targetProperty = targetProperty;
        }

        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            var otherPropertyInfo = validationContext.ObjectType.GetProperty(this.targetProperty);
            var referenceProperty = (string)otherPropertyInfo.GetValue(validationContext.ObjectInstance, null);

            if (value == null)
                value = "";

            if (value.ToString() != referenceProperty)
                return new ValidationResult("Do not match");

            return base.IsValid(value, validationContext);
        }

        public override bool IsValid(object value)
        {
            return String.IsNullOrEmpty(this.ErrorMessage);
        }
    }
}