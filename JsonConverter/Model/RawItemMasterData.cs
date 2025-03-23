using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JsonConverter.Model.ItemMaster
{
    // Root myDeserializedClass = JsonConvert.DeserializeObject<List<Root>>(myJsonResponse);
    public class RawItemMasterData
    {
        [JsonProperty("SKU code")]
        public string SKUcode { get; set; }

        [JsonProperty("SKU code (interface)")]
        public string SKUcodeinterface { get; set; }

        [JsonProperty("Company code")]
        public string Companycode { get; set; }

        [JsonProperty("Item type")]
        public string Itemtype { get; set; }

        [JsonProperty("Base UOM SKU")]
        public string BaseUOMSKU { get; set; }

        [JsonProperty("SKU description")]
        public string SKUdescription { get; set; }

        [JsonProperty("SKU alternative description")]
        public string SKUalternativedescription { get; set; }

        [JsonProperty("Default Barcode")]
        public string DefaultBarcode { get; set; }

        [JsonProperty("Pallet Qty")]
        public int? PalletQty { get; set; }

        [JsonProperty("Layer Qty")]
        public int? LayerQty { get; set; }

        [JsonProperty("Outer Qty")]
        public int? OuterQty { get; set; }

        [JsonProperty("Inner Qty")]
        public int? InnerQty { get; set; }

        [JsonProperty("Unit Qty")]
        public int? UnitQty { get; set; }

        [JsonProperty("Self Shippable Unit")]
        public bool? SelfShippableUnit { get; set; }

        [JsonProperty("Self Shippable Inner")]
        public bool? SelfShippableInner { get; set; }

        [JsonProperty("Self Shippable Outer")]
        public bool? SelfShippableOuter { get; set; }

        [JsonProperty("SKU length (cm)")]
        public double? SKUlengthcm { get; set; }

        [JsonProperty("SKU depth (cm)")]
        public double? SKUdepthcm { get; set; }

        [JsonProperty("SKU height (cm)")]
        public double? SKUheightcm { get; set; }

        [JsonProperty("Gross weight (kg)")]
        public double? Grossweightkg { get; set; }

        [JsonProperty("SKU net weight (kg)")]
        public double? SKUnetweightkg { get; set; }

        [JsonProperty("SKU cost price")]
        public string SKUcostprice { get; set; }
        public string Traceability { get; set; }

        [JsonProperty("Warning Days")]
        public int? WarningDays { get; set; }

        [JsonProperty("Item serials type")]
        public string Itemserialstype { get; set; }

        [JsonProperty("Item serials handling")]
        public string Itemserialshandling { get; set; }

        [JsonProperty("Service Type")]
        public int? ServiceType { get; set; }

        [JsonProperty("Storage Strategy")]
        public string StorageStrategy { get; set; }

        [JsonProperty("Domestic use")]
        public bool? Domesticuse { get; set; }

        [JsonProperty("SKU style")]
        public string SKUstyle { get; set; }

        [JsonProperty("SKU size")]
        public string SKUsize { get; set; }

        [JsonProperty("SKU season")]
        public string SKUseason { get; set; }

        [JsonProperty("SKU colour")]
        public string SKUcolour { get; set; }

        [JsonProperty("SKU colour code")]
        public string SKUcolourcode { get; set; }

        [JsonProperty("SKU country of origin")]
        public string SKUcountryoforigin { get; set; }

        [JsonProperty("Organisation ID")]
        public string OrganisationID { get; set; }

        [JsonProperty("SKU Hazardous")]
        public bool? SKUHazardous { get; set; }

        [JsonProperty("Hazardous UN code")]
        public string HazardousUNcode { get; set; }

        [JsonProperty("SKU hazardous class")]
        public string SKUhazardousclass { get; set; }

        [JsonProperty("SKU material composition")]
        public string SKUmaterialcomposition { get; set; }
        public int? Vat { get; set; }

        [JsonProperty("Commodity Code")]
        public string CommodityCode { get; set; }

        [JsonProperty("Item Price 1")]
        public double? ItemPrice1 { get; set; }

        [JsonProperty("Item Price 2")]
        public double? ItemPrice2 { get; set; }

        [JsonProperty("Catch-weight item")]
        public bool? Catchweightitem { get; set; }
    }


}
