namespace PhotoShare.Models.Validation
{
    using System;
    using System.ComponentModel.DataAnnotations;
    using System.Linq;

    [AttributeUsage(AttributeTargets.Property, AllowMultiple = true)]
    internal class PasswordAttribute : ValidationAttribute
    {
        private const string SpecialSymbols = "!@#$%^&*()_+<>,.?";
        private int minLength;
        private int maxLength;

        public PasswordAttribute(int minLength, int maxLength)
        {
            this.minLength = minLength;
            this.maxLength = maxLength;
        }

        public bool ContainsLowercase { get; set; }

        public bool ContainsUppercase { get; set; }

        public bool ContainsDigit { get; set; }

        public bool ContainsSpecialSymbol { get; set; }

        public override bool IsValid(object value)
        {
            string password = value.ToString();
            if (password.Length < this.minLength || password.Length > this.maxLength)
            {
                return false;
            }

            if (this.ContainsLowercase && !password.Any(c => char.IsLower(c)))
            {
                return false;
            }

            if (this.ContainsUppercase && !password.Any(c => char.IsUpper(c)))
            {
                return false;
            }

            if (this.ContainsDigit && !password.Any(c => char.IsDigit(c)))
            {
                return false;
            }

            if (this.ContainsSpecialSymbol && !password.Any(c => SpecialSymbols.Contains(c)))
            {
                return false;
            }

            return true;
        }
    }
}
