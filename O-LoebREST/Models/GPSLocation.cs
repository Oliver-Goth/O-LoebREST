namespace O_LoebREST.Models
{
    public class GPSLocation
    {
        public int Id { get; set; }
        public decimal Latitude { get; set; }
        public decimal Longitude { get; set; }
        public DateTime ReceivedOn { get; set; }
    }
}
