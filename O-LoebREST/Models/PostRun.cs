namespace O_LoebREST.Models
{
    public class PostRun
    {
        public int RunId { get; set; }
        public Run Run { get; set; }

        public int PostId { get; set; }
        public Post Post { get; set; }
    }
}
