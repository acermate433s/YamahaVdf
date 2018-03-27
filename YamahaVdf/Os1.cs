using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;

namespace YamahaVdf
{
    public class Os1
    {
        public enum FreightChargeType
        {
            [Code("C")]
            Collect,

            [Code("D")]
            PrePaid,
        }

        public enum SalesOrderType
        {
            [Code("R")]
            Regular,

            [Code("E")]
            Emergency,
        }

        public enum SalesOrderSourceType
        {
            [Code("D")]
            Domestic,

            [Code("I")]
            Internal,

            [Code("E")]
            Employee,
        }

        public enum ShippingMethodType
        {
            [Code("A")]
            Air,

            [Code("S")]
            Sea,

            [Code("G")]
            Ground,
        }

        public enum CarrierServiceType
        {
            [Code("A")]
            [Description("UPS 2nd Day Air")]
            Ups2ndDayAir,

            [Code("S")]
            [Description("Parcel Post")]
            ParcelPost,

            [Code("G")]
            [Description("UPS Ground")]
            UpsGround,

            [Code("009")]
            [Description("Truck Freight")]
            TruckFreight,

            [Code("020")]
            [Description("Federal Express Saturday Delivery")]
            FederalExpressSaturdayDelivery,

            [Code("021")]
            [Description("DHL Worldwide Express")]
            DhlWorldwideExpress,

            [Code("028")]
            [Description("UPS Next Day Air")]
            UpsNextDayAir,

            [Code("050")]
            [Description("Ground Fedex Ground")]
            GroundFedexGround,

            [Code("108")]
            [Description("Fedex Standard Overnight By 3pm")]
            FedexStandardOvernightBy3pm,

            [Code("112")]
            [Description("Priority Mail Express")]
            PriorityMailExpress,

            [Code("119")]
            [Description("Export Air")]
            ExportAir,

            [Code("120")]
            [Description("Export Sea Freight")]
            ExportSeaFreight,

            [Code("121")]
            [Description("Export Surface Freight")]
            ExportSurfaceFreight,
        }

        public class Header1
        {
            internal Header1(string content)
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
                SalesOrderNo = double.Parse(contents[index++]);
                CustomerCode = contents[index++];
                CustomerReferenceNo = contents[index++];
                PromotionCode = contents[index++];
                PaymentTerm = contents[index++];
                FreightCharge = contents[index++].EnumValue<FreightChargeType>(FreightChargeType.Collect);
                SalesOrder = contents[index++].EnumValue<SalesOrderType>(SalesOrderType.Regular);
                SalesOrderSource = contents[index++].EnumValue<SalesOrderSourceType>(SalesOrderSourceType.Internal);
                SupplierCode = contents[index++];
                CompanyCode = contents[index++];
                ShippingMethod = contents[index++].EnumValue<ShippingMethodType>(ShippingMethodType.Ground);
                CarrierService = contents[index++].EnumValue<CarrierServiceType>(CarrierServiceType.UpsGround);
            }

            public char Indicator { get; } = 'A';
            public double SalesOrderNo { get; set; }
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
            public CarrierServiceType CarrierService { get; set; }
        }

        public class Header2
        {
            internal Header2(string content)
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
                SalesOrderNo = double.Parse(contents[index++]);
                ContactPerson = contents[index++];
                AddressLine1 = contents[index++];
                AddressLine2 = contents[index++];
            }

            public char Indicator { get; } = 'B';
            public double SalesOrderNo { get; set; }
            public string ContactPerson { get; set; }
            public string AddressLine1 { get; set; }
            public string AddressLine2 { get; set; }
        }

        public class Header3
        {
            internal Header3(string content)
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
                SalesOrderNo = double.Parse(contents[index++]);
                CustomerName = contents[index++];
                CityName = contents[index++];
                StateCode = contents[index++];
                PostalCode = contents[index++];
                CountryCode = contents[index++];
                ContactPhoneNo = contents[index++];
            }

            public char Indicator { get; } = 'C';
            public double SalesOrderNo { get; set; }
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
                SalesOrderNo = double.Parse(contents[index++]);
                SalesOrderLineNo = int.Parse(contents[index++]);
                PartNo = contents[index++];
                SalesQuantity = double.Parse(contents[index++]);
                SalesPrice = double.Parse(contents[index++]);
                RequiredShipDate = DateTime.ParseExact(contents[index++], "yyyyMMdd", null);
                PurchasePrice = double.Parse(contents[index++]);
                TaxAmount = contents[index] != "" ? double.Parse(contents[index++]) : 0D;
            }

            public char Indicator { get; } = 'D';
            public double SalesOrderNo { get; set; }
            public int SalesOrderLineNo { get; set; }
            public string PartNo { get; set; }
            public double SalesQuantity { get; set; }
            public double SalesPrice { get; set; }
            public DateTime RequiredShipDate { get; set; }
            public double PurchasePrice { get; set; }
            public double TaxAmount { get; set; }
        }

        public Os1(string[] contents)
        {
            foreach(var content in contents)
            {
                switch(content[0])
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
