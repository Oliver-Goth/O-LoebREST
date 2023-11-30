using Microsoft.VisualStudio.TestTools.UnitTesting;
using O_LoebREST.Class;
using O_LoebREST.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace O_LoebREST.Class.Tests
{
    [TestClass()]
    public class PostTest
    {
        Question Q10Char = new Question()
        {
            Question = "hvad er 2 + 2 ?",
            Awnsers = new List<string>() { "1", "2", "3", "4" },
            CorrectAwsner = 2
        };

        [TestMethod()]
        public void validateTest_no_false()
        {
            PostTest post = new PostTest()
            {
                Name = "ros",
                CordidateNS = 50,
                CordidateWE = 45,
                PostQuestion = Q10Char
            };

            post.validate();
        }

        [TestMethod()]
        public void validateTest_false_name()
        {
            PostTest post = new PostTest()
            {
                Name = null,
                CordidateNS = 50,
                CordidateWE = 45,
                PostQuestion = Q10Char
            };

            Assert.ThrowsException<ArgumentNullException>(() =>
            post.validate());
            post.Name = "";
            Assert.ThrowsException<ArgumentNullException>(() =>
            post.validate());

        }

        [TestMethod()]
        public void validateTest_Cord_NS()
        {
            PostTest post = new PostTest()
            {
                Name = "ros",
                //CordidateNS = 50,
                CordidateWE = 45,
                PostQuestion = Q10Char
            };

            Assert.ThrowsException<ArgumentNullException>(() =>
            post.validate());

            post.CordidateNS = 90;
            post.validate();

            post.CordidateNS = -90;
            post.validate();

            post.CordidateNS = 91;
            Assert.ThrowsException<ArgumentOutOfRangeException>(() =>
            post.validate());

            post.CordidateNS = -91;
            Assert.ThrowsException<ArgumentOutOfRangeException>(() =>
            post.validate());
        }

        [TestMethod()]
        public void validateTest_Cord_WE()
        {
            PostTest post = new PostTest()
            {
                Name = "ros",
                CordidateNS = 50,
                //CordidateWE = 45,
                PostQuestion = Q10Char
            };

            Assert.ThrowsException<ArgumentNullException>(() =>
            post.validate());

            post.CordidateWE = 180;
            post.validate();

            post.CordidateWE = -180;
            post.validate();

            post.CordidateWE = 181;
            Assert.ThrowsException<ArgumentOutOfRangeException>(() =>
            post.validate());

            post.CordidateWE = -181;
            Assert.ThrowsException<ArgumentOutOfRangeException>(() =>
            post.validate());
        }

    }
}