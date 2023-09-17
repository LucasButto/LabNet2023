using Microsoft.VisualStudio.TestTools.UnitTesting;
using PracticaEF.Logic;
using PracticaEF.Entities;

namespace PracticaEF.Tests
{
    [TestClass]
    public class SuppliersLogicTests
    {
        [TestMethod]
        public void TestGetSupplierById()
        {
            var logic = new SuppliersLogic();
            int testSupplierID = 1;

            var result = logic.GetSupplierById(testSupplierID);

            Assert.IsNotNull(result);
            Assert.AreEqual(testSupplierID, result.SupplierID);
        }
    }
}
