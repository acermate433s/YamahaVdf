using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace YamahaVdf.Tests
{
    [TestClass()]
    public class Os5Tests
    {
        [TestMethod()]
        public void Os5ValidStringTest()
        {
            const string CONTENT =
@"H,0001250582,215389,441778,20180525,0.00,,292661615962559
D,9435011,10,271290107000,052,1,13.81
";

            var contents = CONTENT.Split(new[] { System.Environment.NewLine }, StringSplitOptions.RemoveEmptyEntries);
            try
            {
                var target = new Os5(contents);
            }
            catch
            {
                Assert.Fail("Error parsing valid string");
            }
        }
    }
}
