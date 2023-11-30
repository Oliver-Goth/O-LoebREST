using Microsoft.VisualStudio.TestTools.UnitTesting;
using O_LoebREST.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace O_LoebRESTTests.Models
{
    [TestClass()]
    public class RunTest
    {
        private const bool useDataBase = true;

        private readonly Run _testRun = new() { Id = 1, Name = "Katedral", RunType = "Oløb" };

        

        // name tests
        [TestMethod()]
        public void validateNameTest()
        {
            _testRun.ValidateName();
        }
        [TestMethod()]
        public void validateNameTestIsNotNull()
        {
            Run _testrun2 = new Run() { Id = 1, RunType = "Oløb" };
            Assert.ThrowsException<ArgumentNullException>(() => _testrun2.ValidateName());
        }
        [TestMethod()]
        public void validateNameTestIsLengthException()
        {
            Run _testrun3 = new Run() { Id = 1, Name = "aaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaa", RunType = "Oløb" };
            Assert.IsTrue(_testrun3.Name.Length == 40); 
        }
        [TestMethod()]
        public void validateNameTestIsLengthExceptionFail()
        {
            Run _testrun4 = new Run() { Id = 1, Name = "aaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaa", RunType = "Oløb" };
            Assert.IsTrue(_testrun4.Name.Length == 40);
            Assert.ThrowsException<ArgumentException>(() => _testrun4.ValidateName());
        }


        // type test


        [TestMethod()]
        public void validateRunTypeTest()
        {
            _testRun.ValidateRunType();
        }
        [TestMethod()]
        public void validateRunTypeTestIsNull()
        {
            Run _testrun2 = new Run() { Id = 1, Name = "Domkirke" };
            Assert.ThrowsException<ArgumentNullException>(() => _testrun2.ValidateRunType());
        }
        [TestMethod()]
        public void validateRunTypeArgumentException()
        {
            Run _testrun2 = new Run() { Id = 1, Name = "Domkirke", RunType = "Dims" };
            Assert.ThrowsException<ArgumentException>(() => _testrun2.ValidateRunType());
        }

        // list tests

        [TestMethod()]
        public void validateListTest()
        {
            Run testRun = new Run() { Id = 1, RunType = "Olob", Name = "ros tur", PostList = new() { new Posts { Name = "post", cordidateX = 59, cordidateY = 78 } };
            Assert.IsNotNull(testRun);
            Assert.IsNotNull(testRun.PostList);
        }
    }
}
