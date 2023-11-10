using System;
using System.Reflection;
using ClassesLib;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace unitTesting
{
    [TestClass]
    public class UnitTest1
    {
      private controller CT;


        [TestInitialize]
        public void TestInitialize()
        {

            var type = typeof(controller);
            var field = type.GetField("instance", BindingFlags.Static | BindingFlags.NonPublic);
            field.SetValue(null, null);

            
            CT = controller.Instance;

        }
        
        [TestMethod()]
        public void IsLendingPast30DaysTest()
        {
         
            DateTime currentDate = DateTime.Now;
            DateTime fortyDaysAgo = currentDate.AddDays(-40);
            users user = new users();
            bookss book = new bookss();
            lendings lending = new lendings(fortyDaysAgo,user,book,1);
            bool v = CT.IsLendingPast30Days(lending);
            Assert.IsTrue(v);
        }
        [TestMethod()]
        public void addLendingTest124()
        {
           
            users user = new users();
            bookss book = new bookss();
        
            lendings lending = new lendings(DateTime.Now, user,book,1);
     
            try
            {
                CT.addLending(lending, user);

                Assert.IsTrue(true);
            }
            catch (Exception ex)
            {

                Assert.Fail($"An error occurred: {ex.Message}");
            }

        }
    }
}
