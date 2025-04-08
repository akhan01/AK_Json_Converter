using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JsonConverter.Model
{
    public partial class RawShipmentData
    {
        [JsonProperty("@type")]
        public string @Type { get; set; }
        public string Ordernumber { get; set; }
        public string Orderref { get; set; }
        public string SpareString1 { get; set; }
        public bool? SpareBoolean3 { get; set; }
        public string SpareDate1 { get; set; }
        public string SpareDate2 { get; set; }
        public string SpareString4 { get; set; }
        public string SpareString5 { get; set; }
        public string SpareString6 { get; set; }
        public string SpareString7 { get; set; }
        public string SpareString8 { get; set; }
        public bool? SpareBoolean2 { get; set; }
        public bool? SpareBoolean4 { get; set; }
        public string Ordertype { get; set; }
        public string CompanyCode { get; set; }
        public string SiteCode { get; set; }
        public string ReasonCode { get; set; }
        public string ReasonCompanyCode { get; set; }
        public string ShipmentinfoCarrierCode { get; set; }
        public string ShipmentinfoCarrierPartnerName { get; set; }
        public string ShipmentinfoCarrierCompanyCode { get; set; }
        public string ShipmentinfoShipmenttype { get; set; }
        public string Orderdate { get; set; }
        public string Duedate { get; set; }
        public string Notes { get; set; }
        public string ConsegneePartnerName { get; set; }
        public string ConsegneePartnerAddressAddress { get; set; }
        public string ConsegneePartnerAddressSecondaryaddress { get; set; }
        public string ConsegneePartnerAddressZipcode { get; set; }
        public string ConsegneePartnerAddressCountry { get; set; }
        public string ConsegneePartnerAddressCity { get; set; }
        public string ConsegneePartnerAddressAddressnumber { get; set; }
        public string ConsegneePartnerAddressProvince { get; set; }
        public string ConsegneePartnerAddressBuilding { get; set; }
        public string ConsegneePartnerVatnumber { get; set; }
        public string ConsegneePartnerTaxcode { get; set; }
        public string ConsegneePartnerPhonenumber { get; set; }
        public string ConsegneePartnerRefpersonmail { get; set; }
        public string ConsegneePartnerReferencecode { get; set; }
        public string ConsegneePartnerBusinessname { get; set; }
        public string ConsegneePartnerDeliveryinstructions { get; set; }
        public string ConsegneePartnerRefperson { get; set; }
        public string CustomerPartnerName { get; set; }
        public string CustomerPartnerTaxcode { get; set; }
        public string CustomerPartnerPhonenumber { get; set; }
        public string CustomerPartnerBusinessname { get; set; }
        public string CustomerPartnerRefperson { get; set; }
        public string CustomerPartnerRefpersonmail { get; set; }
        public string CustomerPartnerReferencecode { get; set; }
        public string CustomerPartnerAddressCity { get; set; }
        public string CustomerPartnerAddressAddressnumber { get; set; }
        public string CustomerPartnerAddressProvince { get; set; }
        public string CustomerPartnerAddressBuilding { get; set; }
        public string CustomerPartnerAddressAddress { get; set; }
        public string CustomerPartnerAddressSecondaryaddress { get; set; }
        public string CustomerPartnerAddressZipcode { get; set; }
        public string CustomerPartnerAddressCountry { get; set; }
        public string PaymentinfoCurrency { get; set; }
        public double? PaymentinfoAmount { get; set; }
        public double? PaymentinfoInsuredamount { get; set; }
        public double? PaymentinfoIncoterms { get; set; }
        public string PaymentinfoTotalamountwords { get; set; }
    }
}
