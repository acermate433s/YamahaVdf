using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace YamahaVdf.Tests
{
    [TestClass()]
    public class Os1Tests
    {
        [TestMethod()]
        public void Os1ValidStringTest()
        {
            const string CONTENT =
@"
A,7523100,82720,Fall Order,FALL2016,W40,P,R,D,1251510,YMUS,G,004
B,7523100,Flora Garibian,123 Main,,,,,,,,
C,7523100,Flora's Place,HURST,TX,780069218,US,2106068788,,,,
G,7523100,111-111-1111,111-111-1111,,,,,,,,
D,7523100,240,SXS14KIT0103,1,0.01,20161202,576,,,,
D,7523100,250,SXS14KIT0103,1,0.01,20161202,576,,,,
A,7535444,53100,Fall,FALL2016,W30,P,R,D,1251510,YMUS,G,009
B,7535444,Stephen Brown,123 Main,,,,,,,,
C,7535444,Browns Place,MANSFIELD,TX,275378269,US,2524928553,,,,
G,7535444,111-111-1111,111-111-1111,,,,,,,,
D,7535444,50,ATV14KIT0101,2,0.01,20160819,509,,,,
D,7535444,60,SXS14KIT0101,1,0.01,20160819,509,,,,
";

            var contents = CONTENT.Split(new[] { System.Environment.NewLine }, StringSplitOptions.RemoveEmptyEntries);
            try
            {
                var target = new Os1(contents);
            }
            catch
            {
                Assert.Fail("Error parsing valid string");
            }
        }

        [TestMethod()]
        public void Os1InvalidIndicatorsTest()
        {
            const string CONTENT =
@"
X,7523100,82720,Fall Order,FALL2016,W40,P,R,D,1251510,YMUS,G
X,7523100,Flora Garibian,123 Main,,,,,,,,
X,7523100,Flora's Place,HURST,TX,780069218,US,2106068788,,,,
X,7523100,111-111-1111,111-111-1111,,,,,,,,
X,7523100,240,SXS14KIT0103,1,0.01,20161202,576,,,,
X,7523100,250,SXS14KIT0103,1,0.01,20161202,576,,,,
X,7535444,53100,Fall,FALL2016,W30,P,R,D,1251510,YMUS,G
X,7535444,Stephen Brown,123 Main,,,,,,,,
X,7535444,Browns Place,MANSFIELD,TX,275378269,US,2524928553,,,,
X,7535444,111-111-1111,111-111-1111,,,,,,,,
X,7535444,50,ATV14KIT0101,2,0.01,20160819,509,,,,
X,7535444,60,SXS14KIT0101,1,0.01,20160819,509,,,,
";

            var contents = CONTENT.Split(new[] { System.Environment.NewLine }, StringSplitOptions.RemoveEmptyEntries);
            var target = new Os1(contents);
            Assert.IsTrue(
                (target.Header1s != null && target.Header1s.Count == 0)
                && (target.Header2s != null && target.Header2s.Count == 0)
                && (target.Header3s != null && target.Header3s.Count == 0)
                && (target.Details != null && target.Details.Count == 0)
            );
        }
    }
}