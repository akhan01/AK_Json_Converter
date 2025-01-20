using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JsonConverter.Model
{
    public partial class ShipmentOrder
    {
        [JsonProperty("@type")]
        public string Type { get; set; }

        [JsonProperty("orderNumber")]
        public string OrderNumber { get; set; }

        [JsonProperty("orderRef")]
        public string OrderRef { get; set; }

        [JsonProperty("spare")]
        public Spare Spare { get; set; }

        [JsonProperty("orderType")]
        public string OrderType { get; set; }

        [JsonProperty("company")]
        public Company Company { get; set; }

        [JsonProperty("site")]
        public Company Site { get; set; }

        [JsonProperty("reason")]
        public Reason Reason { get; set; }

        [JsonProperty("shipmentInfo")]
        public ShipmentInfo ShipmentInfo { get; set; }

        [JsonProperty("orderDate")]
        public DateTimeOffset? OrderDate { get; set; }

        [JsonProperty("dueDate")]
        public DateTimeOffset? DueDate { get; set; }

        [JsonProperty("notes")]
        public string Notes { get; set; }

        [JsonProperty("consegnee")]
        public Consegnee Consegnee { get; set; }

        [JsonProperty("customer")]
        public Consegnee Customer { get; set; }

        [JsonProperty("paymentInfo")]
        public PaymentInfo PaymentInfo { get; set; }

        [JsonProperty("positions")]
        public Position[] Positions { get; set; }
    }

    public partial class Company
    {
        [JsonProperty("code")]
        public string Code { get; set; }
    }

    public partial class Consegnee
    {
        [JsonProperty("partner")]
        public ConsegneePartner Partner { get; set; }
    }

    public partial class ConsegneePartner
    {
        [JsonProperty("name")]
        public string Name { get; set; }

        [JsonProperty("address")]
        public Address Address { get; set; }

        [JsonProperty("vatNumber", NullValueHandling = NullValueHandling.Ignore)]
        public string VatNumber { get; set; }

        [JsonProperty("taxCode")]
        public string TaxCode { get; set; }

        [JsonProperty("phoneNumber")]
        public string PhoneNumber { get; set; }

        [JsonProperty("refPersonMail")]
        public string RefPersonMail { get; set; }

        [JsonProperty("referenceCode")]
        public string ReferenceCode { get; set; }

        [JsonProperty("businessName")]
        public string BusinessName { get; set; }

        [JsonProperty("deliveryInstructions", NullValueHandling = NullValueHandling.Ignore)]
        public string DeliveryInstructions { get; set; }

        [JsonProperty("refPerson")]
        public string RefPerson { get; set; }
    }

    public partial class Address
    {
        [JsonProperty("address")]
        public string AddressAddress { get; set; }

        [JsonProperty("secondaryAddress")]
        public string SecondaryAddress { get; set; }

        [JsonProperty("zipCode")]
        public string ZipCode { get; set; }

        [JsonProperty("country")]
        public string Country { get; set; }

        [JsonProperty("city")]
        public string City { get; set; }

        [JsonProperty("addressNumber")]
        public string AddressNumber { get; set; }

        [JsonProperty("province")]
        public string Province { get; set; }

        [JsonProperty("building")]
        public string Building { get; set; }
    }

    public partial class PaymentInfo
    {
        [JsonProperty("currency")]
        public string Currency { get; set; }

        [JsonProperty("amount")]
        public double Amount { get; set; }

        [JsonProperty("insuredAmount")]
        public double InsuredAmount { get; set; }

        [JsonProperty("incoterms")]
        public double Incoterms { get; set; }

        [JsonProperty("totalAmountWords")]
        public string TotalAmountWords { get; set; }
    }

    public partial class Position
    {
        [JsonProperty("posId")]
        public string PosId { get; set; }

        [JsonProperty("item")]
        public Item Item { get; set; }

        [JsonProperty("requestedQt")]
        public int RequestedQt { get; set; }

        [JsonProperty("spare")]
        public PositionSpare Spare { get; set; }

        [JsonProperty("stockSelector")]
        public StockSelector StockSelector { get; set; }

        [JsonProperty("paymentInfo")]
        public PositionPaymentInfo PaymentInfo { get; set; }

        [JsonProperty("custom")]
        public Custom Custom { get; set; }
    }

    public partial class Custom
    {
        [JsonProperty("userDefined1")]
        public string UserDefined1 { get; set; }

        [JsonProperty("userDefined2")]
        public string UserDefined2 { get; set; }

        [JsonProperty("userDefined3")]
        public string UserDefined3 { get; set; }
    }

    public partial class Item
    {
        [JsonProperty("itemNumber")]
        public string ItemNumber { get; set; }

        [JsonProperty("company")]
        public Company Company { get; set; }
    }

    public partial class PositionPaymentInfo
    {
        [JsonProperty("unitValue")]
        public double UnitValue { get; set; }

        [JsonProperty("totalValue")]
        public double TotalValue { get; set; }

        [JsonProperty("totalDiscount")]
        public double TotalDiscount { get; set; }
    }

    public partial class PositionSpare
    {
        [JsonProperty("string1")]
        public string String1 { get; set; }

        [JsonProperty("boolean1")]
        public bool Boolean1 { get; set; }

        [JsonProperty("string2")]
        public string String2 { get; set; }

        [JsonProperty("string3")]
        public string String3 { get; set; }

        [JsonProperty("string5")]
        public object String5 { get; set; }
    }

    public partial class StockSelector
    {
        [JsonProperty("searchOptions")]
        public SearchOptions SearchOptions { get; set; }

        [JsonProperty("positionSelector")]
        public PositionSelector PositionSelector { get; set; }
    }

    public partial class PositionSelector
    {
        [JsonProperty("huCode")]
        public string HuCode { get; set; }
    }

    public partial class SearchOptions
    {
        [JsonProperty("lotId")]
        public string LotId { get; set; }
    }

    public partial class Reason
    {
        [JsonProperty("code")]
        public string Code { get; set; }

        [JsonProperty("company")]
        public Company Company { get; set; }
    }

    public partial class ShipmentInfo
    {
        [JsonProperty("carrier")]
        public Carrier Carrier { get; set; }

        [JsonProperty("shipmentType")]
        public string ShipmentType { get; set; }
    }

    public partial class Carrier
    {
        [JsonProperty("code")]
        public string Code { get; set; }

        [JsonProperty("partner")]
        public CarrierPartner Partner { get; set; }

        [JsonProperty("company")]
        public Company Company { get; set; }
    }

    public partial class CarrierPartner
    {
        [JsonProperty("name")]
        public string Name { get; set; }
    }

    public partial class Spare
    {
        [JsonProperty("string1")]
        public string String1 { get; set; }

        [JsonProperty("boolean3")]
        public bool Boolean3 { get; set; }

        [JsonProperty("date1")]
        public DateTimeOffset? Date1 { get; set; }

        [JsonProperty("date2")]
        public DateTimeOffset? Date2 { get; set; }

        [JsonProperty("string4")]
        public string String4 { get; set; }

        [JsonProperty("string5")]
        public string String5 { get; set; }

        [JsonProperty("string6")]
        public string String6 { get; set; }

        [JsonProperty("string7")]
        public string String7 { get; set; }

        [JsonProperty("string8")]
        public object String8 { get; set; }

        [JsonProperty("boolean2")]
        public bool Boolean2 { get; set; }

        [JsonProperty("boolean4")]
        public bool Boolean4 { get; set; }
    }
}
