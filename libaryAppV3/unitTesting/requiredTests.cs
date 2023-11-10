using ClassesLib;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace unitTesting
{
    [TestClass]
    public class requiredTests
    {
        
        [TestMethod]
        public void TestInstanceProperty()
        {
            // Arrange
            int aed = 2;

            // Act
            aed--;

            // Assert
            Assert.IsNotNull(aed);
        }
    }
}
