using System;
using System.Linq;

namespace YamahaVdf
{
    public class Os2
    {
        public Os2(string content)
        {
            if (String.IsNullOrEmpty(content))
                throw new ArgumentNullException(nameof(content), "Content cannot be an empty string");

            var contents =
                content
                .Split(new[] { Constants.DELIMITER }, StringSplitOptions.None)
                .ToArray();

            int index = 0;
            SupplierCode = contents[index++];
            SalesOrderNo = double.Parse(contents[index++]);
            SalesOrderLineNo = int.Parse(contents[index++]);
            PartNo = contents[index++];
            AllocatedQuantity = double.Parse(contents[index++]);
            ExpectedShipDate = DateTime.ParseExact(contents[index++], "yyyyMMdd", null);
        }

        public string SupplierCode { get; set; }
        public double SalesOrderNo { get; set; }
        public int SalesOrderLineNo { get; set; }
        public string PartNo { get; set; }
        public double AllocatedQuantity { get; set; }
        public DateTime ExpectedShipDate { get; set; }
    }
}
