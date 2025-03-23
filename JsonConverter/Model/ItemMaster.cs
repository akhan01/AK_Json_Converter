using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JsonConverter.Model.ItemMaster
{
    public class ItemMaster
    {
        public string ItemNumber { get; set; }
        public Spare Spare { get; set; }
        public Company Company { get; set; }
        public string ItemType { get; set; }
        public string BaseItemNumber { get; set; }
        public string ShortDescription { get; set; }
        public string LongDescription { get; set; }
        public string Barcode { get; set; }
        public DefaultItemAttributes DefaultItemAttributes { get; set; }
        public UnitSize UnitSize { get; set; }
        public double WeightNet { get; set; }
        public string EconomicValue { get; set; }
        public string ItemSerialsType { get; set; }
        public string ItemSerialsHandling { get; set; }
        public bool ToBeExported { get; set; }
        public FashionDetails FashionDetails { get; set; }
        public bool HazardousMaterial { get; set; }
        public string UnCode { get; set; }
        public Custom Custom { get; set; }
        public List<BarcodeData> Barcodes { get; set; }
    }

    public class Spare
    {
        public string String3 { get; set; }
        public double Number2 { get; set; }
        public int Number4 { get; set; }
        public string String1 { get; set; }
        public string String2 { get; set; }
        public string String5 { get; set; }
        public string String4 { get; set; }
        public string String6 { get; set; }
        public string String7 { get; set; }
        public string String8 { get; set; }
        public int Number1 { get; set; }
        public bool Boolean1 { get; set; }
    }

    public class Company
    {
        public string Code { get; set; }
    }

    public class DefaultItemAttributes
    {
        public DefaultPackaging DefaultPackaging { get; set; }
        public string TraceabilityName { get; set; }
        public int WarningDays { get; set; }
        public string StorageStrategyName { get; set; }
    }

    public class DefaultPackaging
    {
        public int PalletQty { get; set; }
        public int LayerQty { get; set; }
        public int OuterQty { get; set; }
        public int InnerUnit { get; set; }
        public int UnitQuantity { get; set; }
        public bool SelfShippableUnit { get; set; }
        public bool SelfShippableInner { get; set; }
        public bool SelfShippableOuter { get; set; }
    }

    public class UnitSize
    {
        public double SizeLength { get; set; }
        public double SizeWidth { get; set; }
        public double SizeHeight { get; set; }
    }

    public class FashionDetails
    {
        public string Season { get; set; }
        public string Color { get; set; }
    }

    public class Custom
    {
        public string CommodityCode { get; set; }
        public double ItemPrice1 { get; set; }
        public double ItemPrice2 { get; set; }
    }

    public class BarcodeData
    {
        public string Barcode { get; set; }
        public string Type { get; set; }
        public int QtyMultiplier { get; set; }
    }

}
