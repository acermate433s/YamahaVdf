using System;
using System.Linq;

namespace YamahaVdf
{
    public class Os7
    {
        public Os7(string content)
        {
            if (String.IsNullOrEmpty(content))
                throw new ArgumentNullException(nameof(content), "Content cannot be an empty string");

            var contents =
                content
                .Split(new[] { Constants.DELIMITER }, StringSplitOptions.None)
                .ToArray();

            int index = 0;
            SupplierCode = contents[index++];
            PartNo = contents[index++];
            InventoryDate = DateTime.ParseExact(contents[index++], "yyyyMMdd", null);
            StandardLeadTime = double.Parse(contents[index++]);
            EmergencyLeadTime = double.Parse(contents[index++]);
        }

        public string SupplierCode { get; set; }
        public string PartNo { get; set; }
        public DateTime InventoryDate { get; set; } 
        public double StandardLeadTime { get; set; }
        public double EmergencyLeadTime { get; set; }
    }
}
