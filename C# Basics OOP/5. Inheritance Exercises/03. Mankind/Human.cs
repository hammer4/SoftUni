using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _03.Mankind
{
    public class Human
    {
        private string firstName;
        private string lastName;

        public Human(string firstName, string lastName)
        {
            this.FirstName = firstName;
            this.LastName = lastName;
        }

        public virtual string FirstName
        {
            get
            {
                return this.firstName;
            }

            protected set
            {
                if(!char.IsUpper(value[0]))
                {
                    throw new ArgumentException("Expected upper case letter! Argument: firstName");
                }

                this.firstName = value;
            }
        }

        public virtual string LastName
        {
            get
            {
                return this.lastName;
            }

            protected set
            {
                if (!char.IsUpper(value[0]))
                {
                    throw new ArgumentException("Expected upper case letter! Argument: lastName");
                }

                this.lastName = value;
            }
        }
    }
}
