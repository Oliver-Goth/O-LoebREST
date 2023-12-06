using O_LoebREST.Models;

public interface IRunRepo
{
    Run AddRun(Run run);
    Run GetRunById(int id);
    IEnumerable<Run> GetAll();
}

