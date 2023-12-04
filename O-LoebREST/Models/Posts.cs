namespace O_LoebREST.Models
{
    public class Posts
    {
        public string Name { get; set; }
        public int SequenceNumber { get; set; }
        public int Radius { get; set; }
        public double GpsLatitude { get; set; }
        public double GpsLongitude { get; set; }

        public void ValidateName()
        {
            if (Name == null)
            {
                throw new ArgumentNullException(nameof(Name), "Name cannot be null");
            }
            if (Name.Length > 40)
            {
                throw new ArgumentOutOfRangeException(nameof(Name), "Name cannot be longer than 40 characters");
            }
        }
    }
}
