using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _03.Mankind
{
    public class Worker : Human
    {
        private double weekSalary;
        private double workHoursPerDay;

        public Worker(string firstName, string lastName, double weekSalary, double workHoursPerDay)
            :base(firstName, lastName)
        {
            this.LastName = lastName;
            this.WeekSalary = weekSalary;
            this.WorkHoursPerDay = workHoursPerDay;
        }

        public override string LastName
        {
            get
            {
                return base.LastName;
            }

            protected set
            {
                if(value.Length < 3)
                {
                    throw new ArgumentException("Expected length at least 3 symbols! Argument: lastName");
                }
                base.LastName = value;
            }
        }

        public double WeekSalary
        {
            get
            {
                return this.weekSalary;
            }

            set
            {
                if(value <= 10)
                {
                    throw new ArgumentException("Expected value mismatch! Argument: weekSalary");
                }
                this.weekSalary = value;
            }
        }

        public double WorkHoursPerDay
        {
            get
            {
                return this.workHoursPerDay;
            }

            set
            {
                if(value < 1 || value > 12)
                {
                    throw new ArgumentException("Expected value mismatch! Argument: workHoursPerDay");
                }
                this.workHoursPerDay = value;
            }
        }

        private double GetSalaryPerHour()
        {
            return this.WeekSalary / (this.WorkHoursPerDay * 5);
        }

        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            sb.Append("First Name: ").Append(this.FirstName)
                    .Append(Environment.NewLine)
                    .Append("Last Name: ").Append(this.LastName)
                    .Append(Environment.NewLine)
                    .Append(String.Format("Week Salary: {0:F2}", this.WeekSalary))
                    .Append(Environment.NewLine)
                    .Append(String.Format("Hours per day: {0:F2}", this.WorkHoursPerDay))
                    .Append(Environment.NewLine)
                    .Append(String.Format("Salary per hour: {0:F2}", this.GetSalaryPerHour()));

            return sb.ToString();
        }
    }
}
