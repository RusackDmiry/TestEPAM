using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;

namespace ClassLibrary1
{
    class TestOperation
    {
        [TestFixture]
        public class OperationTest
        {
            
            private double resultOperation;
            
            [Test]
            public void TestSum()
            {
                resultOperation = Operation.Sum(1, 2);
                Assert.AreEqual(3, resultOperation);

                resultOperation = Operation.Sum(-1, 2);
                Assert.AreEqual(1, resultOperation);

                resultOperation = Operation.Sum(0, 2);
                Assert.AreEqual(2, resultOperation);

                resultOperation = Operation.Sum(0.1, 2);
                Assert.AreEqual(2.1, resultOperation);

                resultOperation = Operation.Sum(-10, 2);
                Assert.AreEqual(-8, resultOperation);
            }

            [Test]
            public void TestRazn()
            {
                resultOperation = Operation.Razn(1, 1);
                Assert.AreEqual(0, resultOperation);

                resultOperation = Operation.Razn(0, 0);
                Assert.AreEqual(0, resultOperation);

                resultOperation = Operation.Razn(5, 1);
                Assert.AreEqual(4, resultOperation);

                resultOperation = Operation.Razn(1, 5);
                Assert.AreEqual(-4, resultOperation);

                resultOperation = Operation.Razn(1.1, 0.1);
                Assert.AreEqual(1, resultOperation);
            }

            [Test]
            public void TestDel()
            {
                resultOperation = Operation.Del(1, 1);
                Assert.AreEqual(1, resultOperation);

                resultOperation = Operation.Del(2, 1);
                Assert.AreEqual(2, resultOperation);

                resultOperation = Operation.Del(6, 3);
                Assert.AreEqual(2, resultOperation);

                resultOperation = Operation.Del(-2, 1);
                Assert.AreEqual(-2, resultOperation);

                resultOperation = Operation.Del(0, 1);
                Assert.AreEqual(0, resultOperation);
            }

            [Test]
            public void TestUmn()
            {
                resultOperation = Operation.Umn(2, 2);
                Assert.AreEqual(4, resultOperation);

                resultOperation = Operation.Umn(6, -2);
                Assert.AreEqual(-3, resultOperation);

                resultOperation = Operation.Umn(0, 2);
                Assert.AreEqual(0, resultOperation);

                resultOperation = Operation.Umn(10, 2);
                Assert.AreEqual(20, resultOperation);

                resultOperation = Operation.Umn(2, 0.5);
                Assert.AreEqual(1, resultOperation);
            }
        }

    }
}
