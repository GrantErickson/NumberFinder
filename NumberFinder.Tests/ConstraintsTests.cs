using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;
using System.Linq;

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
            Assert.IsTrue(c1.Evaluate(numbers).Success);
        }
        [TestMethod]
        public void Even1False()
        {
            var c1 = new NumberFinder.Constraint1("A,B", a => a % 2 == 0);
            List<int> numbers = new() { 2, 1 };
            Assert.IsFalse(c1.Evaluate(numbers).Success);
            Assert.AreEqual('B', c1.Evaluate(numbers).EvaluatedChars.First());
        }
        [TestMethod]
        public void Even2()
        {
            var c1 = new NumberFinder.Constraint1("AAA", a => a % 2 == 0);
            List<int> numbers = new() { 2, 1 };
            Assert.IsTrue(c1.Evaluate(numbers).Success);
        }
        [TestMethod]
        public void Even3()
        {
            var c1 = new NumberFinder.Constraint1("A,B", a => a % 2 == 0);
            List<int> numbers = new() { 2, 4 };
            Assert.IsTrue(c1.Evaluate(numbers).Success);
        }
        [TestMethod]
        public void Even4False()
        {
            var c1 = new NumberFinder.Constraint1("A,B,C,D", a => a % 2 == 0);
            List<int> numbers = new() { 2, 4, 6, 7 };
            Assert.IsFalse(c1.Evaluate(numbers).Success);
            Assert.AreEqual('D', c1.Evaluate(numbers).EvaluatedChars.First());
            Assert.AreEqual(1, c1.Evaluate(numbers).EvaluatedChars.Count());
        }
        [TestMethod]
        public void Even5()
        {
            var c1 = new NumberFinder.Constraint1("A, BB, CDDA, D", a => a % 2 == 0);
            List<int> numbers = new() { 2, 4, 6, 8 };
            Assert.IsTrue(c1.Evaluate(numbers).Success);
        }
        [TestMethod]
        public void EvenAdd()
        {
            var c1 = new NumberFinder.Constraint1("A+A", a => a % 2 == 0);
            List<int> numbers = new() { 2, 4, 6, 8 };
            Assert.IsTrue(c1.Evaluate(numbers).Success);
        }

        [TestMethod]
        public void EqualAdd1()
        {
            var c1 = new NumberFinder.Constraint2("A+B,B+A", (a, b) => a == b);
            List<int> numbers = new() { 2, 4, 6, 8 };
            Assert.IsTrue(c1.Evaluate(numbers).Success);
        }
        [TestMethod]
        public void EqualAdd2()
        {
            var c1 = new NumberFinder.Constraint2("A+D,B+C", (a, b) => a == b);
            List<int> numbers = new() { 2, 4, 6, 8 };
            Assert.IsTrue(c1.Evaluate(numbers).Success);
        }
        [TestMethod]
        public void EqualSubtract1()
        {
            var c1 = new NumberFinder.Constraint2("B-A,D-C", (a, b) => a == b);
            List<int> numbers = new() { 2, 4, 6, 8 };
            Assert.IsTrue(c1.Evaluate(numbers).Success);
        }
        [TestMethod]
        public void EqualDivide1()
        {
            var c1 = new NumberFinder.Constraint2("B/A,D/B", (a, b) => a == b);
            List<int> numbers = new() { 2, 4, 6, 8 };
            Assert.IsTrue(c1.Evaluate(numbers).Success);
        }
        [TestMethod]
        public void EqualMultiply1()
        {
            var c1 = new NumberFinder.Constraint2("A*B,D", (a, b) => a == b);
            List<int> numbers = new() { 2, 4, 6, 8 };
            Assert.IsTrue(c1.Evaluate(numbers).Success);
        }
        [TestMethod]
        public void EqualMultiply2()
        {
            var c1 = new NumberFinder.Constraint2("D*C,BD", (a, b) => a == b);
            List<int> numbers = new() { 2, 4, 6, 8 };
            Assert.IsTrue(c1.Evaluate(numbers).Success);
        }
        [TestMethod]
        public void EqualCombine1False()
        {
            var c1 = new NumberFinder.Constraint2("A,B,C,D", (a, b) => a == b);
            List<int> numbers = new() { 2, 2, 4, 4 };
            Assert.IsFalse(c1.Evaluate(numbers).Success);
            Assert.AreEqual('B', c1.Evaluate(numbers).EvaluatedChars.First());
            Assert.AreEqual('C', c1.Evaluate(numbers).EvaluatedChars.Last());
        }

        [TestMethod]
        public void EqualCombine2False()
        {
            var c1 = new NumberFinder.Constraint2("B+A,C,D", (a, b) => a == b);
            List<int> numbers = new() { 1, 2, 4, 3 };
            Assert.IsFalse(c1.Evaluate(numbers).Success);
            Assert.AreEqual('B', c1.Evaluate(numbers).EvaluatedChars.First());
            Assert.AreEqual('A', c1.Evaluate(numbers).EvaluatedChars.Skip(1).First());
            Assert.AreEqual('C', c1.Evaluate(numbers).EvaluatedChars.Last());
        }
        [TestMethod]
        public void EqualCombine3False()
        {
            var c1 = new NumberFinder.Constraint2("B+A,C,D", (a, b) => a == b);
            List<int> numbers = new() { 1, 2, 3, 4 };
            Assert.IsFalse(c1.Evaluate(numbers).Success);
            Assert.AreEqual('C', c1.Evaluate(numbers).EvaluatedChars.First());
            Assert.AreEqual('D', c1.Evaluate(numbers).EvaluatedChars.Skip(1).First());
        }
    }
}