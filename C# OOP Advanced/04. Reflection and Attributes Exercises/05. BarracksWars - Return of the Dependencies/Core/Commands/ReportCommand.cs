using System;
using System.Collections.Generic;
using System.Text;
using _03BarracksFactory.Contracts;
using _03BarracksFactory.CustomAttributes;

namespace _03BarracksFactory.Core.Commands
{
    public class ReportCommand : Command
    {
        [Inject]
        private IRepository repository;

        public ReportCommand(string[] data) 
            : base(data)
        {
        }

        public IRepository Repository
        {
            get { return repository; }
            set { repository = value; }
        }

        public override string Execute()
        {
            string output = this.Repository.Statistics;
            return output;
        }
    }
}
