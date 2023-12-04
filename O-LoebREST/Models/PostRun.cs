namespace O_LoebREST.Models
{
    public class PostRun
    {

        // This class is only for binding a many to many realtionship between the Run Model and the Post model, when using EF CORE
        public int RunId { get; set; }
        public Run Run { get; set; }

        public int PostId { get; set; }
        public Post Post { get; set; }
    }
}
