namespace FestivalManager.Entities.Instruments
{
    public class Microphone : Instrument
    {
	    private const int RepairAm = 80;

        public Microphone() 
            : base(RepairAm)
        {
        }
    }
}
