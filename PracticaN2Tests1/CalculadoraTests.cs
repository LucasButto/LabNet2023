using Microsoft.VisualStudio.TestTools.UnitTesting;
using PracticaN2;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PracticaN2.Tests
{
    [TestClass()]
    public class CalculadoraTests
    {
        [TestMethod()]
        [ExpectedException(typeof(DivideByZeroException))]
        public void RealizarDivisionTest()
        {
            Calculadora calculadora = new Calculadora();

            calculadora.RealizarDivision(10, 0);
        }

        [TestMethod()]
        public void RealizarDivisionConValidacionTest()
        {
            Calculadora calculadora = new Calculadora();

            calculadora.RealizarDivisionConValidacion("10", "2");
        }
    }
}