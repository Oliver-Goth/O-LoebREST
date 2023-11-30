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
using Microsoft.EntityFrameworkCore;

namespace O_LoebREST.Class.Tests
{
    [TestClass()]
    public class RunRepoTest
    {
        private static DataBaseContext? _dataBaseContext;
        private static IRunRepo _repo;

        [ClassInitialize]

        // Creating a temp table in the DB

        public static void InitOnce(TestContext context)
        {
            var optionsBuilder = new DbContextOptionsBuilder<DataBaseContext>();
            optionsBuilder.UseSqlServer("Data Source=mssql3.unoeuro.com;Initial Catalog=philipv_dk_db_solar;User ID=philipv_dk;Password=wa5pyrtbnRmHEh4fAg6k;Integrated Security=False;Encrypt=True;TrustServerCertificate=True");

            _dataBaseContext = new DataBaseContext(optionsBuilder.Options);

            _dataBaseContext.Database.ExecuteSqlRaw("TRUNCATE TABLE dbo.Runs");

            _repo = new RunRepoDB(_dataBaseContext);


        }

        [TestMethod()]

        public void AddTest()
        {

            Run runNameNull = new Run() { Id = 0, Name = null, RunType = "o-løb"};
            Run runNameLongerThan40 = new Run() { Id = 0, Name = "abcdefstndhfjghfjsifjdasdfghiddjfrtasjcir", RunType = "o-løb" };
            Run runTypeNull = new Run() { Id = 0, Name = "test", RunType = null };


            // Test if it throws agrumentnull ex

            Assert.ThrowsException<ArgumentNullException>(() => _repo.AddRun(runNameNull));

            // Test if it throws arguement out of range ex

            Assert.ThrowsException<ArgumentOutOfRangeException>(() => _repo.AddRun(runNameLongerThan40));

            // Test if it throws agrumentnull ex

            Assert.ThrowsException<ArgumentNullException>(() => _repo.AddRun(runTypeNull));


        }

    }
}
