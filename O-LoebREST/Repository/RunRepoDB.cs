using O_LoebREST.DBContext;
using O_LoebREST.Models;

namespace O_LoebREST.Repository
{
    public class RunRepoDB : IRunRepo
    {
        private readonly RunsDbContext _context;

        public RunRepoDB(RunsDbContext DbContext)
        {
            _context = DbContext;
        }
        public void Add(Run run)
        {
            
             run.ValidateName();
             _context.Add(run);
             _context.SaveChanges();
            
        }
    }
}
