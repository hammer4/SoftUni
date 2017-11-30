namespace PhotoShare.Models.Validation
{
    using System;
    using System.ComponentModel.DataAnnotations;
    using System.Text.RegularExpressions;

    [AttributeUsage(AttributeTargets.Property, AllowMultiple = true)]
    internal class TagAttribute : ValidationAttribute
    {
        public override bool IsValid(object value)
        {
            string pattern = "#[a-zA-Z0-9]{2,20}";
            Regex regex = new Regex(pattern);
            if (!regex.IsMatch(value.ToString()))
            {
                return false;
            }

            return true;
        }
    }
}
