namespace FestivalManager.Entities.Instruments
{
    public class Guitar : Instrument
    {
	    private const int RepairAm = 60;

        public Guitar() 
            : base(RepairAm)
        {
        }
    }
}
