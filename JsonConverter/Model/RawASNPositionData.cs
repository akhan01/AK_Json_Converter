using System;
using Newtonsoft.Json;

namespace JsonConverter.Model.ASN
{
    // Root myDeserializedClass = JsonConvert.DeserializeObject<List<Root>>(myJsonResponse);
    // Root myDeserializedClass = JsonConvert.DeserializeObject<List<Root>>(myJsonResponse);
    public class RawASNPositionData
    {
        public string DocNumber { get; set; }
        public string Position { get; set; }

        [JsonProperty("SKU code")]
        public string SKUcode { get; set; }

        [JsonProperty("Company code")]
        public string Companycode { get; set; }
        public string Quantity { get; set; }
        public string Code { get; set; }
        public string SSCC { get; set; }

        [JsonProperty("Pallet Qty")]
        public string PalletQty { get; set; }

        [JsonProperty("Package Type")]
        public string PackageType { get; set; }
        public string Lot { get; set; }
        public string BBE { get; set; }

        [JsonProperty("Made In")]
        public string MadeIn { get; set; }
        public string UoM { get; set; }

        [JsonProperty("HU Code")]
        public string HUCode { get; set; }

        [JsonProperty("Country of Origin")]
        public string CountryofOrigin { get; set; }

        [JsonProperty("Load Type")]
        public string LoadType { get; set; }

        [JsonProperty("PO Number")]
        public string PONumber { get; set; }

        [JsonProperty("Entry Number")]
        public string EntryNumber { get; set; }

        [JsonProperty("Invoice Number")]
        public string InvoiceNumber { get; set; }

        [JsonProperty("Factory Name")]
        public string FactoryName { get; set; }
        public string GSP { get; set; }

        [JsonProperty("Bond Regime")]
        public string BondRegime { get; set; }

        [JsonProperty("Unit Price")]
        public string UnitPrice { get; set; }

        [JsonProperty("Freight Cost")]
        public string FreightCost { get; set; }

        [JsonProperty("Reason of Return")]
        public string ReasonofReturn { get; set; }

        [JsonProperty("Stock Status")]
        public string StockStatus { get; set; }

        [JsonProperty("Master Position Reference")]
        public string MasterPositionReference { get; set; }
    }




}

