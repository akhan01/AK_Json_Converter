using JsonConverter.Extensions;
using JsonConverter.Model;
using JsonConverter.Model.ItemMaster;
using Newtonsoft.Json;
using OfficeOpenXml;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.NetworkInformation;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace JsonConverter.Logic
{
    internal class ExcelToJsonConverter
    {
        public ExcelToJsonConverter() { }
        public string ConvertExcelToJson(string filePath, int sheet)
        {
            // Ensure the file exists
            if (!File.Exists(filePath))
                throw new FileNotFoundException("Excel file not found.");

            // Enable EPPlus license
            ExcelPackage.LicenseContext = LicenseContext.NonCommercial;

            using (var package = new ExcelPackage(new FileInfo(filePath)))
            {
                var worksheet = package.Workbook.Worksheets[sheet]; // Access the first worksheet
                var rowCount = worksheet.Dimension.Rows; // Total rows
                var colCount = worksheet.Dimension.Columns; // Total columns

                // Create a list to hold the rows as dictionaries
                var rows = new List<Dictionary<string, object>>();

                // Read the header row
                var headers = new List<string>();
                for (int col = 1; col <= colCount; col++)
                {
                    headers.Add(worksheet.Cells[1, col].Text);
                }

                // Read each row of data
                for (int row = 2; row <= rowCount; row++)
                {
                    var rowData = new Dictionary<string, object>();
                    for (int col = 1; col <= colCount; col++)
                    {
                        rowData[headers[col - 1]] = worksheet.Cells[row, col].Text;
                    }
                    rows.Add(rowData);
                }

                // Convert the list of rows to JSON
                return JsonConvert.SerializeObject(rows, Newtonsoft.Json.Formatting.Indented);
            }
        }

        #region Sales Order
        public List<ShipmentOrder> GenerateShipmentOrder(string shipmentData, string positionsData)
        {
            List<RawShipmentData> rawShipmentOrders = JsonConvert.DeserializeObject<List<RawShipmentData>>(shipmentData);

            //RawShipmentData rs = rawShipmentOrders.FirstOrDefault();
            if (rawShipmentOrders.Count == 0) 
            {
                throw new Exception("No Shipment data. Press Enter to try again");
            }

            List<ShipmentOrder> shipmentOrders = new List<ShipmentOrder>();
            foreach (RawShipmentData rs in rawShipmentOrders)
            {
                ShipmentOrder shipmentOrder = new ShipmentOrder()
                {
                    Type = rs.Type,
                    OrderNumber = rs.Ordernumber,
                    OrderRef = rs.Orderref,
                    Spare = new Model.Spare()
                    {
                        String1 = rs.SpareString1,
                        Boolean3 = rs.SpareBoolean3 == null ? false : (bool)rs.SpareBoolean3,
                        Date1 = rs.SpareDate1.ParseCustom(),
                        Date2 = rs.SpareDate2.ParseCustom(),
                        String4 = rs.SpareString4,
                        String5 = rs.SpareString5,
                        String6 = rs.SpareString6,
                        String7 = rs.SpareString7,
                        String8 = rs.SpareString8,
                        Boolean2 = rs.SpareBoolean2 == null ? false : (bool)rs.SpareBoolean2,
                        Boolean4 = rs.SpareBoolean4 == null ? false : (bool)rs.SpareBoolean4
                    },
                    OrderType = rs.Ordertype,
                    Company = new Model.Company()
                    {
                        Code = rs.CompanyCode,
                    },
                    Site = new Model.Company()
                    {
                        Code = rs.SiteCode
                    },
                    Reason = new Reason()
                    {
                        Code = rs.ReasonCode,
                        Company = new Model.Company()
                        {
                            Code = rs.ReasonCompanyCode
                        }
                    },
                    ShipmentInfo = new ShipmentInfo()
                    {
                        Carrier = new Carrier()
                        {
                            Code = rs.ShipmentinfoCarrierCode,
                            Partner = new CarrierPartner()
                            {
                                Name = rs.ShipmentinfoCarrierPartnerName
                            },
                            Company = new Model.Company()
                            {
                                Code = rs.ShipmentinfoCarrierCompanyCode
                            }
                        },
                        ShipmentType = rs.ShipmentinfoShipmenttype
                    },
                    OrderDate = rs.Orderdate.ParseCustom(),
                    DueDate = rs.Duedate.ParseCustom(),
                    Notes = rs.Notes,
                    Consegnee = new Consegnee()
                    {
                        Partner = new ConsegneePartner()
                        {
                            Name = rs.ConsegneePartnerName,
                            Address = new Address()
                            {
                                AddressAddress = rs.ConsegneePartnerAddressAddress,
                                SecondaryAddress = rs.ConsegneePartnerAddressSecondaryaddress,
                                ZipCode = rs.ConsegneePartnerAddressZipcode,
                                Country = rs.ConsegneePartnerAddressCountry,
                                City = rs.ConsegneePartnerAddressCity,
                                AddressNumber = rs.ConsegneePartnerAddressAddressnumber,
                                Province = rs.ConsegneePartnerAddressProvince,
                                Building = rs.ConsegneePartnerAddressBuilding
                            },
                            VatNumber = rs.ConsegneePartnerVatnumber,
                            TaxCode = rs.ConsegneePartnerTaxcode,
                            PhoneNumber = rs.ConsegneePartnerPhonenumber,
                            RefPersonMail = rs.ConsegneePartnerRefpersonmail,
                            BusinessName = rs.ConsegneePartnerBusinessname,
                            DeliveryInstructions = rs.ConsegneePartnerDeliveryinstructions,
                            RefPerson = rs.ConsegneePartnerRefperson,
                            ReferenceCode = string.Empty
                        }
                    },
                    Customer = new Consegnee()
                    {
                        Partner = new ConsegneePartner()
                        {
                            Name = rs.CustomerPartnerName,
                            Address = new Address()
                            {
                                AddressAddress = rs.CustomerPartnerAddressAddress,
                                SecondaryAddress = rs.CustomerPartnerAddressSecondaryaddress,
                                ZipCode = rs.CustomerPartnerAddressZipcode,
                                Country = rs.CustomerPartnerAddressCountry,
                                City = rs.CustomerPartnerAddressCity,
                                AddressNumber = rs.CustomerPartnerAddressAddressnumber,
                                Province = rs.CustomerPartnerAddressProvince,
                                Building = rs.CustomerPartnerAddressBuilding
                            },
                            TaxCode = rs.CustomerPartnerTaxcode,
                            PhoneNumber = rs.CustomerPartnerPhonenumber,
                            RefPersonMail = rs.CustomerPartnerRefpersonmail,
                            BusinessName = rs.CustomerPartnerBusinessname,
                            RefPerson = rs.CustomerPartnerRefperson,
                            ReferenceCode = string.IsNullOrEmpty(rs.CustomerPartnerReferencecode) ? string.Empty : rs.CustomerPartnerReferencecode
                        }
                    },
                    PaymentInfo = new PaymentInfo()
                    {
                        Currency = rs.PaymentinfoCurrency,
                        Amount = rs.PaymentinfoAmount == null ? 0 : (double)rs.PaymentinfoAmount,
                        InsuredAmount = rs.PaymentinfoInsuredamount == null ? 0 : (double)rs.PaymentinfoInsuredamount,
                        Incoterms = rs.PaymentinfoIncoterms == null ? 0 : (double)rs.PaymentinfoIncoterms,
                        TotalAmountWords = rs.PaymentinfoTotalamountwords
                    },
                    //Positions = GeneratePositionsData(positionsData)?.ToArray()
                };

                List<Position> positions = GeneratePositionsData(positionsData, rs.Ordernumber);
                shipmentOrder.Positions = positions?.ToArray();
                shipmentOrders.Add(shipmentOrder);
            }
            return shipmentOrders;
        }

        private List<Position> GeneratePositionsData(string data, string orderNumber)
        {
            List<RawPositionData> rawPositions = JsonConvert.DeserializeObject<List<RawPositionData>>(data);

            List<Position> positions = new List<Position>();

            foreach(RawPositionData rd in rawPositions.Where(a => a.OrderNumber == orderNumber))
            {
                positions.Add(new Position() 
                {
                    PosId = rd.Position,
                    Item = new Item()
                    {
                        ItemNumber = rd.SkuCode,
                        Company = new Model.Company()
                        {
                            Code = rd.CompanyCode,
                        }
                    },
                    RequestedQt = rd.RequestedQty,
                    Spare = new PositionSpare()
                    {
                        String1 = rd.UnitOfMeasure,
                        Boolean1 = rd.TravellingNumberBond == null ? false : (bool)rd.TravellingNumberBond,
                        String2 = rd.SeedNumber,
                        String3 = rd.SalesTax,
                        String5 = rd.BundleKey
                    },
                    StockSelector = new StockSelector()
                    {
                        SearchOptions = new SearchOptions()
                        {
                            LotId = rd.BatchNumber
                        },
                        PositionSelector = new PositionSelector()
                        {
                            HuCode = rd.HuCode
                        }
                    },
                    PaymentInfo = new PositionPaymentInfo()
                    {
                        UnitValue = rd.Price == null ? 0 : (double)rd.Price,
                        TotalValue = rd.ShippingCosts == null ? 0 : (double)rd.ShippingCosts,
                        TotalDiscount = rd.Discount == null ? 0 : (double)rd.Discount
                    },
                    Custom = new Model.Custom()
                    {
                        UserDefined1 = rd.CustomerSkuCode,
                        UserDefined2 = rd.CustomerSkuDescription,
                        UserDefined3 = rd.CustomerPrice,
                    }
                });
            }
            return positions;
        }
        #endregion

        #region Item Master
        public List<ItemMaster> GenerateItemMaster(string itemMasterData, string barcodeData)
        {
            List<RawItemMasterData> rawItemMasterData = JsonConvert.DeserializeObject<List<RawItemMasterData>>(itemMasterData);

            //RawShipmentData rs = rawShipmentOrders.FirstOrDefault();
            if (rawItemMasterData.Count == 0)
            {
                throw new Exception("No Item Master data. Press Enter to try again");
            }

            List<ItemMaster> itemMasters = new List<ItemMaster>();

            foreach (RawItemMasterData rd in rawItemMasterData) 
            {
                ItemMaster itemMaster = new ItemMaster()
                {
                    ItemNumber = rd.SKUcode,
                    Spare = new Model.ItemMaster.Spare()
                    {
                        String3 = rd.SKUcodeinterface,
                        Number2 = rd.Grossweightkg != null ? (double)rd.Grossweightkg.Value : 0,
                        Number4 = rd.ServiceType != null ? (int)rd.ServiceType.Value : 0,
                        String1 = rd.SKUstyle,
                        String2 = rd.SKUsize,
                        String5 = rd.SKUcolourcode,
                        String4 = rd.SKUcountryoforigin,
                        String6 = rd.OrganisationID,
                        String7 = rd.SKUhazardousclass,
                        String8 = rd.SKUmaterialcomposition,
                        Number1 = rd.Vat != null ? (int)rd.Vat.Value : 0,
                        Boolean1 = rd.Catchweightitem != null ? (bool)rd.Catchweightitem.Value : false,
                    },
                    Company = new Model.ItemMaster.Company()
                    {
                        Code = rd.Companycode
                    },
                    ItemType = rd.Itemtype,
                    BaseItemNumber = rd.BaseUOMSKU,
                    ShortDescription = rd.SKUdescription,
                    LongDescription = rd.SKUalternativedescription,
                    Barcode = rd.DefaultBarcode,
                    DefaultItemAttributes = new DefaultItemAttributes()
                    {
                        DefaultPackaging = new DefaultPackaging()
                        {
                            PalletQty = rd.PalletQty != null ? (int)rd.PalletQty : 0,
                            LayerQty = rd.LayerQty != null ? (int)rd.LayerQty : 0,
                            OuterQty = rd.OuterQty != null ? (int) rd.OuterQty : 0,
                            InnerUnit = rd.InnerQty != null ? (int)rd.InnerQty : 0,
                            UnitQuantity = rd.UnitQty != null ? (int)rd.UnitQty : 0,
                            SelfShippableUnit = rd.SelfShippableUnit != null ? (bool)rd.SelfShippableUnit : false,
                            SelfShippableInner = rd.SelfShippableInner != null ? (bool)rd.SelfShippableInner : false,
                            SelfShippableOuter = rd.SelfShippableOuter != null ? (bool)rd.SelfShippableOuter : false
                        },
                        TraceabilityName = rd.Traceability,
                        WarningDays = rd.WarningDays != null ? (int)rd.WarningDays : 0,
                        StorageStrategyName = rd.StorageStrategy
                    },
                    UnitSize = new UnitSize()
                    {
                        SizeLength = rd.SKUlengthcm != null ? (int)rd.SKUlengthcm : 0,
                        SizeWidth = rd.SKUdepthcm != null ? (int)rd.SKUdepthcm : 0,
                        SizeHeight = rd.SKUheightcm != null ? (int)rd.SKUheightcm : 0,
                    },
                    WeightNet = rd.SKUnetweightkg != null ? (double)rd.SKUnetweightkg : 0,
                    EconomicValue = rd.SKUcostprice,
                    ItemSerialsType = rd.Itemserialstype,
                    ItemSerialsHandling = rd.Itemserialshandling,
                    ToBeExported = rd.Domesticuse != null ? (bool)rd.Domesticuse : false,
                    FashionDetails = new FashionDetails()
                    {
                        Season = rd.SKUseason,
                        Color = rd.SKUcolour
                    },
                    HazardousMaterial = rd.SKUHazardous != null ? (bool)rd.SKUHazardous : false,
                    UnCode = rd.HazardousUNcode,
                    Custom = new Model.ItemMaster.Custom()
                    {
                        ItemPrice1 = rd.ItemPrice1 != null ? (double)rd.ItemPrice1 : 0,
                        ItemPrice2 = rd.ItemPrice2 != null ? (double)rd.ItemPrice2 : 0,
                    },
                    Barcodes = GenerateBarcodes(barcodeData, rd.SKUcode),
                };
                itemMasters.Add(itemMaster);
            }


            return itemMasters;
        }

        private List<BarcodeData> GenerateBarcodes(string barcodeData, string itemNumber) 
        {
            List<RawItemMasterBarcodeData> rawBarcodes = JsonConvert.DeserializeObject<List<RawItemMasterBarcodeData>>(barcodeData);

            List<BarcodeData> barcodes = new List<BarcodeData>();

            foreach (RawItemMasterBarcodeData rd in rawBarcodes.Where(a => a.SkuCode == itemNumber))
            {
                barcodes.Add(new BarcodeData()
                {
                    Barcode = rd.ItemBarcode,
                    QtyMultiplier = rd.QuantityperUOM != null ? (int)rd.QuantityperUOM : 0,
                    Type = rd.UOMType
                });
            }
            return barcodes;
        }
        #endregion
    }
}
