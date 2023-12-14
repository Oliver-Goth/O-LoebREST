namespace O_LoebREST.Models
{
    public class GPSLocation
    {
        public int Id { get; set; }
        public double Latitude { get; set; }
        public double Longitude { get; set; }
        public DateTime ReceivedOn { get; set; }
    }
}
