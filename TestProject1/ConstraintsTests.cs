using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;

namespace TestProject1
{
    [TestClass]
    public class ConstraintsTests
    {
        [TestMethod]
        public void Even1True()
        {
            var c1 = new NumberFinder.Constraint1("A", a => a % 2 == 0);
            List<int> numbers = new() { 2, 1 };
            Assert.IsTrue(c1.Evaluate(numbers));
        }
        [TestMethod]
        public void Even1False()
        {
            var c1 = new NumberFinder.Constraint1("B", a => a % 2 == 0);
            List<int> numbers = new() { 2, 1 };
            Assert.IsFalse(c1.Evaluate(numbers));
        }
        [TestMethod]
        public void Even2()
        {
            var c1 = new NumberFinder.Constraint1("AAA", a => a % 2 == 0);
            List<int> numbers = new() { 2, 1 };
            Assert.IsTrue(c1.Evaluate(numbers));
        }
        [TestMethod]
        public void Even3()
        {
            var c1 = new NumberFinder.Constraint1("A,B", a => a % 2 == 0);
            List<int> numbers = new() { 2, 4 };
            Assert.IsTrue(c1.Evaluate(numbers));
        }
        [TestMethod]
        public void Even4False()
        {
            var c1 = new NumberFinder.Constraint1("A,B,C,D", a => a % 2 == 0);
            List<int> numbers = new() { 2, 4, 6, 7 };
            Assert.IsFalse(c1.Evaluate(numbers));
        }
        [TestMethod]
        public void Even5()
        {
            var c1 = new NumberFinder.Constraint1("A, BB, CDDA, D", a => a % 2 == 0);
            List<int> numbers = new() { 2, 4, 6, 8 };
            Assert.IsTrue(c1.Evaluate(numbers));
        }
        [TestMethod]
        public void EvenAdd()
        {
            var c1 = new NumberFinder.Constraint1("A+A", a => a % 2 == 0);
            List<int> numbers = new() { 2, 4, 6, 8 };
            Assert.IsTrue(c1.Evaluate(numbers));
        }

        [TestMethod]
        public void EqualAdd1()
        {
            var c1 = new NumberFinder.Constraint2("A+B,B+A", (a, b) => a == b);
            List<int> numbers = new() { 2, 4, 6, 8 };
            Assert.IsTrue(c1.Evaluate(numbers));
        }
        [TestMethod]
        public void EqualAdd2()
        {
            var c1 = new NumberFinder.Constraint2("A+D,B+C", (a, b) => a == b);
            List<int> numbers = new() { 2, 4, 6, 8 };
            Assert.IsTrue(c1.Evaluate(numbers));
        }
        [TestMethod]
        public void EqualSubtract1()
        {
            var c1 = new NumberFinder.Constraint2("B-A,D-C", (a, b) => a == b);
            List<int> numbers = new() { 2, 4, 6, 8 };
            Assert.IsTrue(c1.Evaluate(numbers));
        }
        [TestMethod]
        public void EqualDivide1()
        {
            var c1 = new NumberFinder.Constraint2("B/A,D/B", (a, b) => a == b);
            List<int> numbers = new() { 2, 4, 6, 8 };
            Assert.IsTrue(c1.Evaluate(numbers));
        }
        [TestMethod]
        public void EqualMultiply1()
        {
            var c1 = new NumberFinder.Constraint2("A*B,D", (a, b) => a == b);
            List<int> numbers = new() { 2, 4, 6, 8 };
            Assert.IsTrue(c1.Evaluate(numbers));
        }
        [TestMethod]
        public void EqualMultiply2()
        {
            var c1 = new NumberFinder.Constraint2("D*C,BD", (a, b) => a == b);
            List<int> numbers = new() { 2, 4, 6, 8 };
            Assert.IsTrue(c1.Evaluate(numbers));
        }
    }
}