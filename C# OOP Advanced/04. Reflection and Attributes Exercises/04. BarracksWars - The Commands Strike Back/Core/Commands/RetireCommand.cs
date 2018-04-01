using System;
using System.Collections.Generic;
using System.Text;
using _03BarracksFactory.Contracts;

namespace _03BarracksFactory.Core.Commands
{
    public class RetireCommand : Command
    {
        public RetireCommand(string[] data, IRepository repository, IUnitFactory unitFactory) 
            : base(data, repository, unitFactory)
        {
        }

        public override string Execute()
        {
            var typeOfUnit = Data[1];

            try
            {
                this.Repository.RemoveUnit(typeOfUnit);
                return $"{typeOfUnit} retired!";
            }
            catch(ArgumentException ae)
            {
                return ae.Message;
            }
        }
    }
}
