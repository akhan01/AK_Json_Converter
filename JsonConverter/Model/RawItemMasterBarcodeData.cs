using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JsonConverter.Model.ItemMaster
{
    // Root myDeserializedClass = JsonConvert.DeserializeObject<List<Root>>(myJsonResponse);
    public class RawItemMasterBarcodeData
    {
        [JsonProperty("SKU code")]
        public string SkuCode { get; set; }

        [JsonProperty("Item Barcode")]
        public string ItemBarcode { get; set; }

        [JsonProperty("UOM Type")]
        public string UOMType { get; set; }

        [JsonProperty("Quantity per UOM")]
        public int? QuantityperUOM { get; set; }
    }
}
