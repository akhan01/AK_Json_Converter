using System;
using Newtonsoft.Json;

namespace JsonConverter.Model.ASN
{
    public class Carrier
    {
        public string code { get; set; }
        public Company company { get; set; }
    }

    public class Company
    {
        public string code { get; set; }
    }

    public class Custom
    {
        public string reasonOfReturn { get; set; }
        public string stockStatus { get; set; }
        public string MasterPositionRef { get; set; }
    }

    public class ExpectedStock
    {
        public Item item { get; set; }
        public int quantity { get; set; }
        public string uom { get; set; }
        public Packaging packaging { get; set; }
        public ProductionInfo productionInfo { get; set; }
        public TrackingInfo trackingInfo { get; set; }
    }

    public class InboundSite
    {
        public string code { get; set; }
    }

    public class Item
    {
        public string itemNumber { get; set; }
        public Company company { get; set; }
    }

    public class PackageType
    {
        public string type { get; set; }
    }

    public class Packaging
    {
        public int? palletQty { get; set; }
        public PalletType palletType { get; set; }
    }

    public class PalletType
    {
        public PackageType packageType { get; set; }
    }

    public class Position
    {
        public ExpectedStock expectedStock { get; set; }
        public string positionId { get; set; }
        public Reason reason { get; set; }
        public string notes { get; set; }
        public Spare spare { get; set; }
        public Custom custom { get; set; }
    }

    public class ProductionInfo
    {
        public string lotId { get; set; }
        public string expiryDate { get; set; }
        public string madeIn { get; set; }
    }

    public class Reason
    {
        public string code { get; set; }
        public Company company { get; set; }
    }

    public class ReasonCode
    {
        public string code { get; set; }
        public Company company { get; set; }
    }

    public class ASNData
    {
        [JsonProperty("@type")]
        public string type { get; set; }
        public Company company { get; set; }
        public DateTime? docDate { get; set; }
        public string documentNumber { get; set; }
        public DateTime dueDate { get; set; }
        public InboundSite inboundSite { get; set; }
        public List<Position> positions { get; set; }
        public ReasonCode reasonCode { get; set; }
        public Spare spare { get; set; }
        public string status { get; set; }
        public Carrier carrier { get; set; }
    }

    public class Spare
    {
        public string string1 { get; set; }
        public string string2 { get; set; }
        public string string3 { get; set; }
        public string string4 { get; set; }
        public string string7 { get; set; }
        public double number1 { get; set; }
        public double number2 { get; set; }
        public string string5 { get; set; }
        public string string6 { get; set; }
    }

    public class TrackingInfo
    {
        public string bin { get; set; }
    }
}

