using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace O_LoebREST.Models
{
    public class Run
    {
        [Key]
        public int Id { get; set; }
        public string Name { get; set; }
        public string RunType { get; set; }
        public ICollection<PostRun> PostRuns { get; set; } = new List<PostRun>();

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
        public void ValidateRunType()
        {
            if (RunType == null)
            {
                throw new ArgumentNullException(nameof(Name), "Runtype cannot be null");
            }
        }

    }
}
