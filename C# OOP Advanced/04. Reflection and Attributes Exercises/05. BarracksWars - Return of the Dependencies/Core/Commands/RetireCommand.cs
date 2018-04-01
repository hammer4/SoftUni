using System;
using System.Collections.Generic;
using System.Text;
using _03BarracksFactory.Contracts;
using _03BarracksFactory.CustomAttributes;

namespace _03BarracksFactory.Core.Commands
{
    public class RetireCommand : Command
    {
        [Inject]
        private IRepository repository;

        public RetireCommand(string[] data) 
            : base(data)
        {
        }

        public override string Execute()
        {
            var typeOfUnit = Data[1];

            try
            {
                this.repository.RemoveUnit(typeOfUnit);
                return $"{typeOfUnit} retired!";
            }
            catch(ArgumentException ae)
            {
                return ae.Message;
            }
        }
    }
}
