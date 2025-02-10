using System;
using Newtonsoft.Json;

namespace JsonConverter.Model.ASN
{
    // Root myDeserializedClass = JsonConvert.DeserializeObject<List<Root>>(myJsonResponse);
    public class RawASNData
    {
        [JsonProperty("Site Code")]
        public string SiteCode { get; set; }
        public string ASN { get; set; }

        [JsonProperty("Company code")]
        public string Companycode { get; set; }

        [JsonProperty("Doc Date")]
        public string DocDate { get; set; }

        [JsonProperty("ETA Date")]
        public string ETADate { get; set; }
        public string Status { get; set; }

        [JsonProperty("Asn Type")]
        public string AsnType { get; set; }

        [JsonProperty("Partner Code")]
        public string PartnerCode { get; set; }

        [JsonProperty("Dock Code")]
        public string DockCode { get; set; }

        [JsonProperty("Dock Building Code")]
        public string DockBuildingCode { get; set; }

        [JsonProperty("Equipment Type")]
        public string EquipmentType { get; set; }

        [JsonProperty("Container/Trailer Nr")]
        public string ContainerTrailerNr { get; set; }

        [JsonProperty("HMRC Reference")]
        public string HMRCReference { get; set; }

        [JsonProperty("Customer Account")]
        public string CustomerAccount { get; set; }

        [JsonProperty("Store Number")]
        public string StoreNumber { get; set; }

        [JsonProperty("Customer ASN Number")]
        public string CustomerASNNumber { get; set; }

        [JsonProperty("Reason Code")]
        public string ReasonCode { get; set; }

        [JsonProperty("Company Code")]
        public string CompanyCode { get; set; }
    }


}

