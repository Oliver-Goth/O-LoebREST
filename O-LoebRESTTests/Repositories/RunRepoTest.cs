﻿using Microsoft.VisualStudio.TestTools.UnitTesting;
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
            optionsBuilder.UseSqlServer("connection string");

            _dataBaseContext = new DataBaseContext(optionsBuilder.Options);

            _dataBaseContext.Database.ExecuteSqlRaw("TRUNCATE TABLE dbo.Runstest");

            _repo = new RunRepoDB(_dataBaseContext);


        }

        [TestMethod()]

        public void AddTest()
        {

            Run runNameNull = new Run() { Id = 1, Name = null, RunType = "o-løb"};
            Run runNameLongerThan40 = new Run() { Id = 2, Name = "abcdefstndhfjghfjsifjdasdfghiddjfrtasjcir", RunType = "o-løb" };
            Run runTypeNull = new Run() { Id = 2, Name = "test", RunType = null };

            // Test if it throws agrumentnull ex

            Assert.ThrowsException<ArgumentNullException>(() => _repo.AddRun(runNameNull));

            // Test if it throws arguement out of range ex

            Assert.ThrowsException<ArgumentOutOfRangeException>(() => _repo.AddRun(runNameLongerThan40));

            // Test if it throws agrumentnull ex

            Assert.ThrowsException<ArgumentNullException>(() => _repo.AddRun(runTypeNull));

            

        }

    }
}