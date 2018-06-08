using System;
using System.Collections.Generic;
using System.Linq;

namespace YamahaVdf
{
    public class Os5
    {
        const char INDICATOR_HEADER = 'H';
        const char INDICATOR_DETAIL = 'D';

        public class Header
        {
            internal Header(string content)
            {
                if(String.IsNullOrEmpty(content))
                    throw new ArgumentNullException(nameof(content), "Content cannot be an empty string");

                if(content[0] != Indicator)
                    throw new ArgumentException($"Invalid indicator.  Expecting {Indicator}");

                var contents =
                    content
                    .Split(new[] { Constants.DELIMITER }, StringSplitOptions.None)
                    .Skip(1)
                    .ToArray();

                int index = 0;
                SupplierCode = contents[index++];
                PackSlipNo = contents[index++];
                InvoiceNo = contents[index++];
                ShippedDate = DateTime.ParseExact(contents[index++], "yyyyMMdd", null);
                FreightAmount = double.Parse(contents[index++]);
                CarrierCode = contents[index++];
                CarrierTrackingNo = contents[index++];
            }

            public char Indicator { get; } = INDICATOR_HEADER;
            public string SupplierCode { get; set; }
            public string PackSlipNo { get; set; }
            public string InvoiceNo { get; set; }
            public DateTime ShippedDate { get; set; }
            public double FreightAmount { get; set; }
            public string CarrierCode { get; set; }
            public string CarrierTrackingNo { get; set; }
        }

        public class Detail
        {
            internal Detail(string content)
            {
                if(String.IsNullOrEmpty(content))
                    throw new ArgumentNullException(nameof(content), "Content cannot be an empty string");

                if(content[0] != Indicator)
                    throw new ArgumentException($"Invalid indicator.  Expecting {Indicator}");

                var contents =
                    content
                    .Split(new[] { Constants.DELIMITER }, StringSplitOptions.None)
                    .Skip(1)
                    .ToArray();

                int index = 0;
                SalesOrderNo = contents[index++];
                SalesOrderLineNo = contents[index++];
                PartNo = contents[index++];
                WarehouseCode = contents[index++];
                ShippedQuantity = int.Parse(contents[index++]);
                ShippedPrice = double.Parse(contents[index++]);
            }

            public char Indicator { get; } = INDICATOR_DETAIL;
            public string SalesOrderNo { get; set; }
            public string SalesOrderLineNo { get; set; }
            public string PartNo { get; set; }
            public string WarehouseCode { get; set; }
            public int ShippedQuantity { get; set; }
            public double ShippedPrice { get; set; }
        }

        public Os5(string[] contents)
        {
            foreach(var content in contents)
            {
                switch(content[0])
                {
                    case INDICATOR_HEADER:
                        Headers.Add(new Header(content));
                        break;
                    case INDICATOR_DETAIL:
                        Details.Add(new Detail(content));
                        break;
                }
            }
        }

        public List<Header> Headers { get; } = new List<Header>();
        public List<Detail> Details { get; } = new List<Detail>();
    }
}
