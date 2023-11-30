using Microsoft.VisualStudio.TestTools.UnitTesting;
using O_LoebREST.Class;
using O_LoebREST.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using O_LoebREST.Repository;
using O_LoebREST.DBContext;
using Microsoft.AspNetCore.DataProtection;

namespace O_LoebREST.Class.Tests
{
    [TestClass()]
    public class Repositorytest
    {
        private readonly RunRepoDB _runRepo = new() { Id = 1, Name = "Katedral", RunType = "Oløb" };

        private const bool useDataBase = true;
        private static IRun _repo;

        [ClassInitialize]
        public static void InitOnce(TestContext context)
        {
            if (useDataBase == true)
            {
                var optionsBuilder = new DbContextOptionsBuilder<RunsDbContext>();
                optionsBuilder.UseSqlServer(Secrets.ConnectionString);
                RunsDbContext _dbContext = new(optionsBuilder.Options);
                _dbContext.Database.ExecutesqlRaw("TRUNCATE TABLE dbo.Runs");

                _repo = new RunRepo(_dbContext);
            }
            else
            {
                _repo = new RunRepoDB();
            }
        }

        [TestMethod()]
        public void validateAddTest()
        {
            int runCount = _runRepo.Runs.Length();
            _runRepo.Add(new Run { Id = 1, Name = "Roskilde Domkirke", RunType = "Stjerneløb" });
            Assert.IsTrue(runCount < _run.Runs.Length());
        }
    }
}
