using JsonConverter.Model;
using Newtonsoft.Json;
using OfficeOpenXml;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.NetworkInformation;
using System.Text;
using System.Threading.Tasks;
using System.Xml;

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
                    Spare = new Spare()
                    {
                        String1 = rs.SpareString1,
                        Boolean3 = rs.SpareBoolean3 == null ? false : (bool)rs.SpareBoolean3,
                        Date1 = DateTime.Parse(rs.SpareDate1),
                        Date2 = DateTime.Parse(rs.SpareDate2),
                        String4 = rs.SpareString4,
                        String5 = rs.SpareString5,
                        String6 = rs.SpareString6,
                        String7 = rs.SpareString7,
                        String8 = rs.SpareString8,
                        Boolean2 = rs.SpareBoolean2 == null ? false : (bool)rs.SpareBoolean2,
                        Boolean4 = rs.SpareBoolean4 == null ? false : (bool)rs.SpareBoolean4
                    },
                    OrderType = rs.Ordertype,
                    Company = new Company()
                    {
                        Code = rs.CompanyCode,
                    },
                    Site = new Company()
                    {
                        Code = rs.SiteCode
                    },
                    Reason = new Reason()
                    {
                        Code = rs.ReasonCode,
                        Company = new Company()
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
                            Company = new Company()
                            {
                                Code = rs.ShipmentinfoCarrierCompanyCode
                            }
                        },
                        ShipmentType = rs.ShipmentinfoShipmenttype
                    },
                    OrderDate = DateTime.Parse(rs.Orderdate),
                    DueDate = DateTime.Parse(rs.Duedate),
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
                            RefPerson = rs.ConsegneePartnerRefperson
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
                            ReferenceCode = rs.CustomerPartnerReferencecode
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
                        Company = new Company()
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
                    Custom = new Custom()
                    {
                        UserDefined1 = rd.CustomerSkuCode,
                        UserDefined2 = rd.CustomerSkuDescription,
                        UserDefined3 = rd.CustomerPrice,
                    }
                });
            }
            return positions;
        }
    }
}
