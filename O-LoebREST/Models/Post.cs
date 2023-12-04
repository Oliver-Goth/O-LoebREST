using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace O_LoebREST.Models
{
    public class Post
    {
        [Key]
        public int Id { get; set; }
        public string Name { get; set; }
        public int SequenceNumber { get; set; }
        public int Radius { get; set; }
        public double GpsLatitude { get; set; }
        public double GpsLongitude { get; set; }
        // Hack for not showing the RunPosts list in the json
        [JsonIgnore]
        public IEnumerable<PostRun> PostRuns { get; set; }


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
