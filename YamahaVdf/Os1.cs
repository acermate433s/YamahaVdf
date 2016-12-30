using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace YamahaVdf
{
    public class Os1
    {
        private const string DELIMITER = ",";

        public enum FreightChargeType
        {
            Collect,
            PrePaid,
        }

        public enum SalesOrderType
        {
            Regular,
            Emergency,
        }

        public enum SalesOrderSourceType
        {
            Domestic,
            Internal,
            Employee,
        }

        public enum ShippingMethodType
        {
            Air,
            Sea,
            Ground,
        }

        public class Header1
        {
            internal Header1(string content)
            {
                if (content[0] != Indicator)
                    throw new ArgumentException($"Invalid indicator.  Expecting {Indicator}");

                var contents =
                    content
                    .Split(new[] { DELIMITER }, StringSplitOptions.None)
                    .Skip(1)
                    .ToArray();

                int index = 0;
                SalesOrderNo = contents[index++];
                CustomerCode = contents[index++];
                CustomerReferenceNo = contents[index++];
                PromotionCode = contents[index++];
                PaymentTerm = contents[index++];
                FreightCharge =
                    (new Func<string, FreightChargeType>(
                        (item) =>
                        {
                            FreightChargeType result = FreightChargeType.Collect;

                            switch (item)
                            {
                                case "C":
                                    result = FreightChargeType.Collect;
                                    break;
                                case "P":
                                    result = FreightChargeType.PrePaid;
                                    break;
                            }

                            return result;
                        })
                    )
                    .Invoke(contents[index++]);
                SalesOrder =
                    (new Func<string, SalesOrderType>(
                        (item) =>
                        {
                            SalesOrderType result = SalesOrderType.Emergency;

                            switch (item)
                            {
                                case "E":
                                    result = SalesOrderType.Emergency;
                                    break;
                                case "R":
                                    result = SalesOrderType.Regular;
                                    break;
                            }

                            return result;
                        })
                    )
                    .Invoke(contents[index++]);
                SalesOrderSource =
                    (new Func<string, SalesOrderSourceType>(
                        (item) =>
                        {
                            SalesOrderSourceType result = SalesOrderSourceType.Domestic;

                            switch (item)
                            {
                                case "D":
                                    result = SalesOrderSourceType.Domestic;
                                    break;
                                case "E":
                                    result = SalesOrderSourceType.Employee;
                                    break;
                                case "I":
                                    result = SalesOrderSourceType.Internal;
                                    break;
                            }

                            return result;
                        })
                    )
                    .Invoke(contents[index++]);
                SupplierCode = contents[index++];
                CompanyCode = contents[index++];
                ShippingMethod =
                    (new Func<string, ShippingMethodType>(
                        (item) =>
                        {
                            ShippingMethodType result = ShippingMethodType.Air;

                            switch (item)
                            {
                                case "A":
                                    result = ShippingMethodType.Air;
                                    break;
                                case "G":
                                    result = ShippingMethodType.Ground;
                                    break;
                                case "S":
                                    result = ShippingMethodType.Sea;
                                    break;
                            }

                            return result;
                        })
                    )
                    .Invoke(contents[index++]);
            }

            public char Indicator { get; } = 'A';
            public string SalesOrderNo { get; set; }
            public string CustomerCode { get; set; }
            public string CustomerReferenceNo { get; set; }
            public string PromotionCode { get; set; }
            public string PaymentTerm { get; set; }
            public FreightChargeType FreightCharge { get; set; }
            public SalesOrderType SalesOrder { get; set; }
            public SalesOrderSourceType SalesOrderSource { get; set; }
            public string SupplierCode { get; set; }
            public string CompanyCode { get; set; }
            public ShippingMethodType ShippingMethod { get; set; }
        }

        public class Header2
        {
            internal Header2(string content)
            {
                if (content[0] != Indicator)
                    throw new ArgumentException($"Invalid indicator.  Expecting {Indicator}");

                var contents =
                    content
                    .Split(new[] { DELIMITER }, StringSplitOptions.None)
                    .Skip(1)
                    .ToArray();

                int index = 0;
                SalesOrderNo = contents[index++];
                ContactPerson = contents[index++];
                AddressLine1 = contents[index++];
                AddressLine2 = contents[index++];
            }

            public char Indicator { get; } = 'B';
            public string SalesOrderNo { get; set; }
            public string ContactPerson { get; set; }
            public string AddressLine1 { get; set; }
            public string AddressLine2 { get; set; }
        }

        public class Header3
        {
            internal Header3(string content)
            {
                if (content[0] != Indicator)
                    throw new ArgumentException($"Invalid indicator.  Expecting {Indicator}");

                var contents =
                    content
                    .Split(new[] { DELIMITER }, StringSplitOptions.None)
                    .Skip(1)
                    .ToArray();

                int index = 0;
                SalesOrderNo = contents[index++];
                CustomerName = contents[index++];
                CityName = contents[index++];
                StateCode = contents[index++];
                PostalCode = contents[index++];
                CountryCode = contents[index++];
                ContactPhoneNo = contents[index++];
            }

            public char Indicator { get; } = 'C';
            public string SalesOrderNo { get; set; }
            public string CustomerName { get; set; }
            public string CityName { get; set; }
            public string StateCode { get; set; }
            public string PostalCode { get; set; }
            public string CountryCode { get; set; }
            public string ContactPhoneNo { get; set; }
        }

        public class Detail
        {
            internal Detail(string content)
            {
                if (content[0] != Indicator)
                    throw new ArgumentException($"Invalid indicator.  Expecting {Indicator}");

                var contents =
                    content
                    .Split(new[] { DELIMITER }, StringSplitOptions.None)
                    .Skip(1)
                    .ToArray();

                int index = 0;
                SalesOrderNo = contents[index++];
                SalesOrderLineNo = contents[index++];
                PartNo = contents[index++];
                SalesQuantity = contents[index++];
                SalesPrice = contents[index++];
                RequiredShipDate = contents[index++];
                PurchasePrice = contents[index++];
                TaxAmount = contents[index++];
            }

            public char Indicator { get; } = 'D';
            public string SalesOrderNo { get; set; }
            public string SalesOrderLineNo { get; set; }
            public string PartNo { get; set; }
            public string SalesQuantity { get; set; }
            public string SalesPrice { get; set; }
            public string RequiredShipDate { get; set; }
            public string PurchasePrice { get; set; }
            public string TaxAmount { get; set; }
        }

        public Os1(string[] contents)
        {
            foreach (var content in contents)
            {
                switch (content[0])
                {
                    case 'A':
                        Header1s.Add(new Header1(content));
                        break;
                    case 'B':
                        Header2s.Add(new Header2(content));
                        break;
                    case 'C':
                        Header3s.Add(new Header3(content));
                        break;
                    case 'D':
                        Details.Add(new Detail(content));
                        break;
                }
            }
        }

        public List<Header1> Header1s { get; } = new List<Header1>();
        public List<Header2> Header2s { get; } = new List<Header2>();
        public List<Header3> Header3s { get; } = new List<Header3>();
        public List<Detail> Details { get; } = new List<Detail>();
    }
}
