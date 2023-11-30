using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace O_LoebRESTTests.Models
{
    public class QuestionTest
    {


        [TestMethod()]
        public void validateTest_Q()
        {
            QuestionTest Q = new QuestionTest()
            {
                //Question = "hvad er 2 + 2",
                Awnsers = new List<String>() { "2", "3", "5", "4" },
                CorrectAwsner = 3
            };

            Assert.ThrowsException<ArgumentNullException>(() =>
            Q.validate());

            Q.Queston = "";
            Assert.ThrowsException<ArgumentNullException>(() =>
            Q.validate());

            Q.Queston = "12";
            Assert.ThrowsException<ArgumentOutOfRangeException>(() =>
            Q.validate());

            Q.Queston = "1111,1111,1111,1111,1111,1111,1111,1111,1111,1111,1111,1111,1111,1111,1111,1111,1111,1111,1111,1111,"; // 100 tegn
            Q.validate();

            Q.Queston = "1111,1111,1111,1111,1111,1111,1111,1111,1111,1111,1111,1111,1111,1111,1111,1111,1111,1111,1111,1111,1"; // 101 tegn
            Assert.ThrowsException<ArgumentOutOfRangeException>(() =>
            Q.validate());
        }

        [TestMethod()]
        public void validateTest_Awnsers_list()
        {
            QuestionTest Q = new QuestionTest()
            {
                Question = "hvad er 2 + 2",
                //Awnsers = new List<String>() { "2", "3", "5", "4" },
                CorrectAwsner = 3
            };

            Assert.ThrowsException<ArgumentNullException>(() =>
            Q.validate());

            Q.Awnsers = new List<String>();
            Assert.ThrowsException<ArgumentNullException>(() =>
            Q.validate());

            Q.Awnsers = new List<String>() { "2", "3", "4", };
            Assert.ThrowsException<ArgumentOutOfRangeException>(() =>
            Q.validate());

            Q.Awnsers = new List<String>() {"1" ,"2", "3", "4", "5"};
            Assert.ThrowsException<ArgumentOutOfRangeException>(() =>
            Q.validate());
        }

        [TestMethod()]
        public void validateTest_CorrectAwsner()
        {
            QuestionTest Q = new QuestionTest()
            {
                Question = "hvad er 2 + 2",
                Awnsers = new List<String>() { "2", "3", "5", "4" },
                //CorrectAwsner = 3
            };

            Assert.ThrowsException<ArgumentNullException>(() =>
            Q.validate());

            Q.CorrectAwsner = -1;
            Assert.ThrowsException<ArgumentOutOfRangeException>(() =>
            Q.validate());

            Q.CorrectAwsner = 5;
            Assert.ThrowsException<ArgumentOutOfRangeException>(() =>
            Q.validate());
        }

    }
}
}
