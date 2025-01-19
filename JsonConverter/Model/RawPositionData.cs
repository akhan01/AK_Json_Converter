using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JsonConverter.Model
{
    public partial class RawPositionData
    {
        [JsonProperty("OrderNumber")]
        public string OrderNumber { get; set; }

        [JsonProperty("Position")]
        public string Position { get; set; }

        [JsonProperty("SKU Code")]
        public string SkuCode { get; set; }

        [JsonProperty("CompanyCode")]
        public string CompanyCode { get; set; }

        [JsonProperty("RequestedQty")]
        public int RequestedQty { get; set; }

        [JsonProperty("UnitOfMeasure")]
        public string UnitOfMeasure { get; set; }

        [JsonProperty("BatchNumber")]
        public string BatchNumber { get; set; }

        [JsonProperty("HuCode")]
        public string HuCode { get; set; }

        [JsonProperty("TravellingNumberBond")]
        public bool? TravellingNumberBond { get; set; }

        [JsonProperty("SeedNumber")]
        public string SeedNumber { get; set; }

        [JsonProperty("Price")]
        public double? Price { get; set; }

        [JsonProperty("ShippingCosts")]
        public double? ShippingCosts { get; set; }

        [JsonProperty("Discount")]
        public double? Discount { get; set; }

        [JsonProperty("SalesTax")]
        public string SalesTax { get; set; }

        [JsonProperty("BundleKey")]
        public string BundleKey { get; set; }

        [JsonProperty("CustomerSKUCode")]
        public string CustomerSkuCode { get; set; }

        [JsonProperty("CustomerSKUDescription")]
        public string CustomerSkuDescription { get; set; }

        [JsonProperty("CustomerPrice")]
        public string CustomerPrice { get; set; }
    }
}
