namespace O_LoebREST.Models
{
    public class Run
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string RunType { get; set; }
        //public List<Posts> PostList { get; set; }

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
