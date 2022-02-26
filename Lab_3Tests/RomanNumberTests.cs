using Microsoft.VisualStudio.TestTools.UnitTesting;
using RomanNumb;
using RomanEx;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RomanNumb.Tests
{
    [TestClass()]
    public class RomanNumberTests
    {
        [TestMethod()]
        public void RomanNumberTest()
        {
            ushort n = 1;
            ushort uncorrectValue = 0;
            RomanNumber number = new RomanNumber(n);
            RomanNumber? nullObject = null;

            var value = number.Number == 1;
            try
            {
                nullObject = new RomanNumber(uncorrectValue);
            }

            catch (RomanNumberException)
            {
                Assert.IsNull(nullObject);
            }
            Assert.IsTrue(value);
            Assert.IsNotNull(number);
        }

        [TestMethod()]
        public void ToStringTest()
        {
            string[] values = {"XXV", "XL", "L", "LVII", "LXII"};
            string?[] buffer = { "" , "", "", "", ""};
            Array myArr = Array.CreateInstance(typeof(RomanNumber), 5);

            int lower = myArr.GetLowerBound(0), upper = myArr.GetUpperBound(0);
            for (int i = lower; i <= upper; i++)
            {
                RomanNumber tmp = new RomanNumber((ushort)((i + 1) * 100 / ((i + 1)+3)));
                myArr.SetValue(tmp, i);
                buffer[i] = myArr.GetValue(i).ToString();
            }

            for (int i = lower; i <= upper; i++)
            {

                Assert.AreEqual(values[i], buffer[i]); 
            }
            
        }

        [TestMethod()]
        public void CloneTest()
        {
            RomanNumber firstValue = new RomanNumber(12);
            RomanNumber secondValue;

            secondValue = (RomanNumber)firstValue.Clone();

            Assert.AreNotEqual(firstValue, secondValue);
            Assert.AreEqual(firstValue.Number, secondValue.Number);
        }

        [TestMethod()]
        public void CompareToTest()
        {
            ushort n = 1, value = 12;
            RomanNumber number = new RomanNumber(n);
            RomanNumber object1 = new RomanNumber(value);

            var finalValue = number.CompareTo(object1);

          
            Assert.IsTrue(finalValue == -11);
        }

        [TestMethod()]
        public void AddTest()
        {
            ushort n = 1, value = 12;
            RomanNumber number = new RomanNumber(n);
            RomanNumber object1 = new RomanNumber(value);

            number = number + object1;

            Assert.AreEqual(number.Number, n + value);
        }

        [TestMethod()]
        public void SubTest()
        {
            ushort n = 1, value = 12;
            RomanNumber number = new RomanNumber(n);
            RomanNumber object1 = new RomanNumber(value);
            

            RomanNumber finalValue = object1 - number;

            /*Assert.ThrowsException<RomanNumberException>(() => RomanNumber.Sub(number, object1));*/
            Assert.ThrowsException<OverflowException>(() => RomanNumber.Sub(number, object1));
            Assert.AreEqual(finalValue.Number, value - n);
        }

        [TestMethod()]
        public void DivTest()
        {
            ushort n = 1, value = 12;
            RomanNumber number = new RomanNumber(n);
            RomanNumber object1 = new RomanNumber(value);

            RomanNumber newNumber = object1 / number;

            Assert.ThrowsException<RomanNumberException>(() => RomanNumber.Div(number, object1));
            Assert.AreEqual(newNumber.Number, value / n);
        }

        [TestMethod()]
        public void MutTest()
        {
            ushort n = 1, value = 12, maxValue = 3999;
            RomanNumber throwExceptionValue = new RomanNumber(maxValue);
            RomanNumber number = new RomanNumber(n);
            RomanNumber object1 = new RomanNumber(value);


            number = number * object1;

            Assert.AreEqual(number.Number, n * value);
            Assert.ThrowsException<OverflowException>(() => RomanNumber.Mul(throwExceptionValue, throwExceptionValue));
        }
    }
}