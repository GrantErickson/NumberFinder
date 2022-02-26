using Microsoft.VisualStudio.TestTools.UnitTesting;
using NumberFinder;
using System.Collections.Generic;
using System.Linq;

namespace TestProject1
{
    [TestClass]
    public class ComputerTests
    {
        [TestMethod]
        public void Unknowns1()
        {
            Computer c = new();
            c.Even("A,B,C")
             .Odd("D,E");
            Assert.AreEqual("ABCDE", c.Unknowns);
        }
        [TestMethod]
        public void Unknowns2()
        {
            Computer c = new();
            c.Even("A,B,C")
             .Odd("D,E")
             .Unique("FADB")
             .Equal("AB,D+E,F+G");
            Assert.AreEqual("ABCDEFG", c.Unknowns);
        }

        [TestMethod]
        public void SimpleEven()
        {
            Computer c = new();
            c.Even("A");
            var results = c.Calculate();
            Assert.AreEqual(5, results.Count);
        }


        [TestMethod]
        public void SimpleEqual()
        {
            Computer c = new();
            c.Equal("A,B");
            var results = c.Calculate();
            Assert.AreEqual(10, results.Count);
        }
        [TestMethod]
        public void SimpleAdd1()
        {
            Computer c = new();
            c.Equal("A,B")
             .Equal("A+B,4");
            var results = c.Calculate();
            Assert.AreEqual(1, results.Count);
        }
        [TestMethod]
        public void SimpleAdd2()
        {
            Computer c = new();
            c.Equal("A,B")
             .Equal("A+B,6");
            var results = c.Calculate();
            Assert.AreEqual(1, results.Count);
        }
        [TestMethod]
        public void SimpleAddEven1()
        {
            Computer c = new();
            c.Equal("A,B")
             .Equal("A+B,6")
             .Even("A,B");
            var results = c.Calculate();
            Assert.AreEqual(0, results.Count);
        }
        [TestMethod]
        public void SimpleAddEven2()
        {
            Computer c = new();
            c.Equal("A,B")
             .Equal("A+B,8")
             .Even("A,B");
            var results = c.Calculate();
            Assert.AreEqual(1, results.Count);
        }

        [TestMethod]
        public void Unknowns31()
        {
            Computer c = new();
            c
             .Equal("AB,22")
             .Equal("BC,22")
             .Equal("ABC,222")
             .Equal("AD,22")
             .Equal("A+B,B+C")
             .Equal("A*B,B*C")
             .Even("A,B");
             ;
            var results = c.Calculate();
            Assert.AreEqual(1, results.Count);
        }
        [TestMethod]
        public void Unknowns32()
        {
            Computer c = new();
            c.Equal("A+B,B+C")
             .Equal("A*B,B*C")
             .Equal("A,B,C")
             .Even("A,B");
            var results = c.Calculate();
            Assert.AreEqual(5, results.Count);
        }
    }
}