using Microsoft.EntityFrameworkCore;
using O_LoebREST.DBContext;
using O_LoebREST.Models;

namespace O_LoebREST.Repository
{
    public class RunRepoDB : IRunRepo
    {
        private readonly DataBaseContext _context;

        public RunRepoDB(DataBaseContext DbContext)
        {
            _context = DbContext;
        }
        public Run AddRun(Run run)
        {
            run.ValidateName();
            run.ValidateRunType();
            _context.Runs.Add(run);
            _context.SaveChanges();

            return run;

            
        }
    }
}
