namespace PhotoShare.Models.Validation
{
    using System;
    using System.ComponentModel.DataAnnotations;
    [AttributeUsage(AttributeTargets.Property, AllowMultiple = true)]
    internal class AgeAttribute : ValidationAttribute
    {
        private const int MinAge = 0;
        private const int MaxAge = 150;

        public override bool IsValid(object value)
        {
            if (value == null)
            {
                return true;
            }

            int age = int.Parse(value.ToString());
            return age >= MinAge && age <= MaxAge;
        }
    }
}
