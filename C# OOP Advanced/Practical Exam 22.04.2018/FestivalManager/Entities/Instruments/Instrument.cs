using System;

namespace FestivalManager.Entities.Instruments
{
	using Contracts;

	public abstract class Instrument : IInstrument
	{
		private double wear;
		private const int MaxWear = 100;

		protected Instrument(int repairAmount)
		{
			this.Wear = MaxWear;
            this.RepairAmount = repairAmount;
		}

		public double Wear
		{
			get
			{
				return this.wear;
			}
			private set
			{
                if(value < 0)
                {
                    this.wear = 0;
                }
                else if (value > 100)
                {
                    this.wear = 100;
                }
                else
                {
                    this.wear = value;
                }
			}
		}

		protected int RepairAmount { get; private set; }

		public void Repair() => this.Wear += this.RepairAmount;

		public void WearDown() => this.Wear -= this.RepairAmount;

		public bool IsBroken => this.Wear <= 0;

		public override string ToString()
		{
			var instrumentStatus = this.IsBroken ? "broken" : $"{this.Wear}%";

			return $"{this.GetType().Name} [{instrumentStatus}]";
		}
	}
}
