using System;
using System.Collections.Generic;
using System.Linq;

namespace YamahaVdf
{ 
    public class Os2
    {
        public class Detail
        {
            public string SupplierCode { get; set; }
            public double SalesOrderNo { get; set; }
            public int SalesOrderLineNo { get; set; }
            public string PartNo { get; set; }
            public DateTime ConfirmedReceiptDate { get; set; }
            public double AllocatedQuantity { get; set; }
            public DateTime ExpectedShipDate { get; set; }

            internal Detail(string content)
            {
                if(String.IsNullOrEmpty(content))
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
                ConfirmedReceiptDate = DateTime.ParseExact(contents[index++], "yyyyMMdd", null);
                AllocatedQuantity = double.Parse(contents[index++]);
                ExpectedShipDate = DateTime.ParseExact(contents[index++], "yyyyMMdd", null);
            }
        }

        public Os2(string[] contents)
        {
            foreach(var content in contents)
            {
                Details.Add(new Detail(content));
            }
        }

        public List<Detail> Details { get; } = new List<Detail>();
    }
}
