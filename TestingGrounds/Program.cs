using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
using TestingGrounds.RateService;

namespace TestingGrounds
{
    public class Program
    {
        static void Main(string[] args)
        {
            RatePortTypeClient client = new RatePortTypeClient();

            UPSSecurity security = new UPSSecurity();
            security.UsernameToken.Username = "";
            security.UsernameToken.Password = "";
            security.ServiceAccessToken.AccessLicenseNumber = "";

            RateRequest request = new RateRequest()
            {
                Request = new RequestType()
                {
                    /*
                    Required: Yes Type: String Max Allowed: UNB Length: 1…15
                    Used to define the request type.
                    Valid Values: Rate = The server rates (The default Request option is Rate if a Request Option is not provided). Shop = The server validates the shipment, and returns rates for all UPS products from the ShipFrom to the ShipTo addresses. Ratetimeintransit = The server rates with transit time information Shoptimeintransit = The server validates the shipment, and returns rates and transit times for all UPS products from the ShipFrom to the ShipTo addresses. Rate is the only valid request option for UPS Ground Freight Pricing requests.
                    */
                    RequestOption = new string[] { },

                    /*
                    Required: No Type: String Max Allowed: 1 Length: 4
                    Indicates Rate API to display the new release features in Rate API response based on Rate release. See the What's New section for the latest Rate release. Supported values: 1601, 1607, 1701, 1801
                    */
                    SubVersion = "",

                    /*
                    Required: No Type: Container Max Allowed: 1 Length: N/A
                    TransactionReference identifies transactions between client and server.
                    */
                    TransactionReference = new TransactionReferenceType()
                    {
                        /*
                        Required: No Type: String Max Allowed: 1 Length: 1…512
                        May be used to synchronize request/response pairs. Information in the request element is echoed back in the response. Must contain valid XML.
                        */
                        CustomerContext = "",

                        /*
                        ?
                        */
                        TransactionIdentifier = ""
                    }
                },

                /*
                Required: No Type: Container Max Allowed: 1 Length: N/A
                Customer classification container. Valid if ShipFrom country or territory is “US”
                */
                CustomerClassification = new CodeDescriptionType()
                {
                    /*
                    Required: Yes* Type: String Max Allowed: 1 Length: 2
                    Customer classification code.
                    Valid values: 00 - Rates Associated with Shipper Number 01 - Daily Rates 04 - Retail Rates 05 - Regional Rates 06 - General List Rates 53 - Standard List Rates Length is not validated. If customer classification code is not a valid value please refer to Rate Types Table on page 11.
                    */
                    Code = "",

                    /*
                    Required: No Type: String Max Allowed: 1 Length: 1…35
                    Customer classification description of the code above.
                    Ignored if provided in the Request. Length is not validated.
                    */
                    Description = ""
                },

                /*
                Required: No Type: Container Max Allowed: 1 Length: N/A
                Pickup Type container tag.
                */
                PickupType = new CodeDescriptionType()
                {
                    /*
                        Required: Yes* Type: String Max Allowed: 1 Length: 2
                        Pickup Type Code.
                        Valid values: 01 - Daily Pickup (Default - used when an invalid pickup type code is provided) 03 - Customer Counter 06 - One Time Pickup 19 - Letter Center 20 - Air Service Center
                        Length is not validated. When negotiated rates are requested, 07 (onCallAir) will be ignored.
                        Refer to the Rate Types Table in the Appendix for rate type based on Pickup Type and Customer Classification Code.
                    */
                    Code = "",

                    /*
                        Required: No Type: String Max Allowed: 1 Length: 1…35
                        Pickup Type Description.
                        Ignored if provided in the Request.
                    */
                    Description = ""
                },

                /*
                Required: Yes Type: Container Max Allowed: 1 Length: N/A
                Container for Shipment Information.
                */
                Shipment = new ShipmentType()
                {
                    /*
                    Required: No Type: String Max Allowed: 1 Length: N/A
                    The time that the request was made from the originating system. UTC time down to milliseconds. Example - 2016-07-14T12:01:33.999
                    Applicable only for HazMat request and with subversion greater than or equal to 1701.
                    */
                    OriginRecordTransactionTimestamp = "",

                    /*
                    Required: Yes Type: Container Max Allowed: 1 Length: N/A
                    Shipper container. Information associated with the UPS account number.
                    */
                    Shipper = new ShipperType()
                    {
                        /*
                        Required: No Type: String Max Allowed: 1 Length: 1…35
                        Shipper's name or company name.
                        */
                        Name = "",

                        /*
                        Required: Yes Type: Container Max Allowed: 1 Length: N/A
                        Address Container.
                        */
                        Address = new AddressType()
                        {
                            /*
                            Required: No Type: String Max Allowed: 3 Length: 1…35
                            Shipper's street address including name and number (when applicable).
                            */
                            AddressLine = new string[] { },

                            /*
                            Required: Cond Type: String Max Allowed: 1 Length: 1…30
                            Shipper's city.
                            */
                            City = "",

                            /*
                            Required: No Type: String Max Allowed: 1 Length: 2
                            Shipper's state code.
                            */
                            StateProvinceCode = "",

                            /*
                            Required: Cond Type: String Max Allowed: 1 Length: 1…9
                            Shipper's postal code.
                            */
                            PostalCode = "",

                            /*
                            Required: Yes Type: String Max Allowed: 1 Length: 2
                            Country or Territory code. Refer to the Supported Country or Territory Tables located in Appendix.
                            */
                            CountryCode = ""
                        },

                        /*
                        Required: Cond Type: String Max Allowed: 1 Length: 6
                        Shipper's UPS account number.
                        */
                        ShipperNumber = ""
                    },

                    /*
                    Required: Yes Type: Container Max Allowed: 1 Length: N/A
                    Ship To Container
                    */
                    ShipTo = new ShipToType()
                    {
                        /*
                        Required: No Type: String Max Allowed: 1 Length: 1…35
                        Destination attention name or company name.
                        */
                        Name = "",

                        /*
                        Required: Yes Type: Container Max Allowed: 1 Length: N/A
                        Address Container.
                        */
                        Address = new ShipToAddressType()
                        {
                            /*
                            Required: No Type: String Max Allowed: 1 Length: 0
                            Residential Address flag. This field is a flag to indicate if the destination is a residential location. True if ResidentialAddressIndicator tag exists; false otherwise. This element does not require a value and if one is entered it will be ignored.
                            Empty Tag.
                            */
                            ResidentialAddressIndicator = "",

                            /*
                            Required: No Type: String Max Allowed: 3 Length: 1…35
                            Destination street address including name and number (when applicable).
                            Max Occurrence can be 3. Length is not validated.
                            */
                            AddressLine = new string[] { },

                            /*
                            Required: Cond Type: String Max Allowed: 1 Length: 1…30
                            Destination city.
                            Required if country or territory does not utilize postal codes. Length is not validated.
                            */
                            City = "",

                            /*
                            Required: Cond Type: String Max Allowed: 1 Length: 2
                            Destination state code.
                            */
                            StateProvinceCode = "",

                            /*
                            Required: Cond Type: String Max Allowed: 1 Length: 1…9
                            Destination postal code.
                            Required if country or territory utilizes postal codes (i.e. US and PR).
                            */
                            PostalCode = "",

                            /*
                            Required: Yes Type: String Max Allowed: 1 Length: 2
                            Destination country or territory code. Refer to the Supported Country or Territory Tables located in the Appendix.
                            */
                            CountryCode = ""
                        }
                    },

                    /*
                    Required: No Type: Container Max Allowed: 1 Length: N/A
                    Ship From Container.
                    */
                    ShipFrom = new ShipFromType()
                    {
                        /*
                        Required: No Type: String Max Allowed: 1 Length: 1…35
                        Origin attention name or company name.
                        Length is not validated.
                        */
                        Name = "",

                        /*
                        Required: Yes* Type: Container Max Allowed: 1 Length: N/A
                        Address container for Ship From.
                        Address Container
                        */
                        Address = new ShipAddressType()
                        {
                            /*
                            Required: No Type: String Max Allowed: 3 Length: 1…35
                            The origin street address including name and number (when applicable).
                            Length is not validated.
                            */
                            AddressLine = new string[] { },

                            /*
                            Required: Cond Type: String Max Allowed: 1 Length: 1…30
                            Origin city.
                            Required if country or territory does not utilize postal codes. Length is not validated.
                            */
                            City = "",

                            /*
                            Required: Cond Type: String Max Allowed: 1 Length: 2
                            Origin state code.
                            A StateProvinceCode and valid account number are required when requesting negotiated rates. Otherwise the StateProvinceCode is optional. If the TaxInformationIndicator flag is present in the request, a StateProvinceCode must be entered for tax charges to be accurately calculated in the response.
                            */
                            StateProvinceCode = "",

                            /*
                            Required: Cond Type: String Max Allowed: 1 Length: 1…9
                            Origin postal code.
                            Required if country or territory utilizes postal codes (e.g. US and PR).
                            */
                            PostalCode = "",

                            /*
                            Required: Yes* Type: String Max Allowed: 1 Length: 2
                            Origin country or territory code. Refer to the Supported country or territory Tables located in the Appendix.
                            Required, but defaults to US.
                            */
                            CountryCode = ""
                        }
                    },

                    /*
                    Required: Cond Type: Container Max Allowed: 1 Length: N/A
                    Alternate Delivery Address container. Applies for deliveries to UPS Access Point™ locations. Required for the following ShipmentIndicationType values: 01 - Hold for Pickup at UPS Access Point™ 02 - UPS Access Point™ Delivery
                    */
                    AlternateDeliveryAddress = new AlternateDeliveryAddressType()
                    {
                        /*
                        Required: No Type: String Max Allowed: 1 Length: 1…35
                        UPS Access Point™ location name.
                        */
                        Name = "",

                        /*
                        Required: Yes* Type: Container Max Allowed: 1 Length: N/A
                        Address container for Alternate Delivery Address.
                        */
                        Address = new ADRType()
                        {
                            /*
                            Required: Yes* Type: String Max Allowed: 3 Length: 1…35
                            The UPS Access Point's street address, including name and number (when applicable).
                            Length is not validated.
                            */
                            AddressLine = new string[] { },

                            /*
                            Required: Cond Type: String Max Allowed: 1 Length: 1…30
                            UPS Access Point city.
                            */
                            City = "",

                            /*
                            Required: Cond Type: String Max Allowed: 1 Length: 2
                            UPS Access Point State or Province code.
                            */
                            StateProvinceCode = "",

                            /*
                            Required: Cond Type: String Max Allowed: 1 Length: 1…9
                            UPS Access Point Postal code.
                            */
                            PostalCode = "",

                            /*
                            Required: Yes* Type: String Max Allowed: 1 Length: 2
                            UPS Access Point country or territory code.
                            */
                            CountryCode = "",

                            /*
                            Required: No Type: String Max Allowed: 1 Length: 0
                            Presence/Absence Indicator. Any value inside is ignored.This field is a flag to indicate if the Alternate Delivery location is a residential location. True if ResidentialAddressIndicator tag exists.
                            For future use.
                            */
                            ResidentialAddressIndicator = "",

                            /*
                            Required: No Type: String Max Allowed: 1 Length: 0
                            Presence/Absence Indicator. Any value inside is ignored. This field is a flag to indicate if the Alternate Delivery location is a PO box location. True if POBoxIndicator tag exists; false otherwise.
                            Not valid with Shipment Indication Types: 01 Hold for Pickup at UPS Access Point 02 UPS Access Point™ Delivery
                            */
                            POBoxIndicator = ""
                        }
                    },

                    /*
                    Required: Cond Type: Container Max Allowed: 1 Length: N/A
                    Container to hold shipment indication type.
                    */
                    ShipmentIndicationType = new IndicationType[]
                    {
                        new IndicationType()
                        {
                            /*
                            Required: Yes* Type: String Max Allowed: 1 Length: 2
                            Code for Shipment Indication Type. Valid valuese: 01 - Hold for Pickup at UPS Access Point 02 - UPS Access Point™ Delivery
                            */
                            Code = "",

                            /*
                            Required: No Type: String Max Allowed: 1 Length: 1...50
                            Description for Shipment Indication Type.
                            Length is not Validated.
                            */
                            Description = ""
                        }
                    },

                    /*
                    Required: No Type: Container Max Allowed: 1 Length: N/A
                    Payment details container for detailed shipment charges. The two shipment charges that are available for specification are Transportation charges and Duties and Taxes.
                    This container is used for Who Pays What functionality.
                    */
                    PaymentDetails = new PaymentDetailsType()
                    {
                        /*
                        Required: Yes* Type: Container Max Allowed: 2 Length: N/A
                        Shipment charge container.
                        */
                        ShipmentCharge = new ShipmentChargeType[]
                        {
                            new ShipmentChargeType()
                            {
                                /*
                                Required: Yes* Type: String Max Allowed: 1 Length: 2
                                Values are 01 = Transportation, 02 = Duties and Taxes
                                */
                                Type = "",

                                /*
                                Required: Cond Type: Container Max Allowed: 1 Length: N/A
                                Container for the BillShipper billing option.
                                This element or its sibling element, BillReceiver, BillThirdParty or ConsigneeBilledIndicator, must be present but no more than one can be present.
                                */
                                BillShipper = new BillShipperChargeType()
                                {
                                    /*
                                    Required: Yes* Type: String Max Allowed: 1 Length: 6
                                    UPS account number
                                    Must be the same UPS account number as the one provided in Shipper/ShipperNumber.
                                    */
                                    AccountNumber = ""
                                },

                                /*
                                Required: Cond Type: Container Max Allowed: 1 Length: N/A
                                Container for the BillReceiver billing option.
                                This element or its sibling element, BillShipper, BillThirdParty or Consignee Billed, must be present but no more than one can be present. For a return shipment, Bill Receiver is invalid for Transportation charges.
                                */
                                BillReceiver = new BillReceiverChargeType()
                                {
                                    /*
                                    Required: Yes* Type: String Max Allowed: 1 Length: 6
                                    The UPS account number.
                                    The account must be a valid UPS account number that is active. For US, PR and CA accounts, the account must be a daily pickup account, an occasional account, a customer B.I.N account, or a dropper shipper account. All other accounts must be either a daily pickup account, an occasional account, a drop shipper account, or a non-shipping account.
                                    */
                                    AccountNumber = "",
                                    /*
                                    Required: Cond Type: Container Max Allowed: 1 Length: N/A
                                    Container for additional information for the bill receiver’s UPS accounts address.
                                    */
                                    Address = new BillReceiverAddressType()
                                    {
                                        /*
                                        Required: Yes* Type: String Max Allowed: 1 Length: 1…9
                                        The postal code for the UPS account's pickup address. The pickup postal code was entered in the UPS system when the account was set-up.
                                        */
                                        PostalCode = ""
                                    }
                                },

                                /*
                                Required: Cond Type: Container Max Allowed: 1 Length: N/A
                                Container for the third party billing option.
                                This element or its sibling element, BillShipper, BillReceiver or Consignee Billed, must be present but no more than one can be present.
                                */
                                BillThirdParty = new BillThirdPartyChargeType()
                                {
                                    /*
                                    Required: Yes* Type: String Max Allowed: 1 Length: 6
                                    The UPS account number of the third party shipper.
                                    The account must be a valid UPS account number that is active. For US, PR and CA accounts, the account must be either a daily pickup account, an occasional account, or a customer B.I.N account, or a drop shipper account. All other accounts must be either a daily pickup account, an occasional account, a drop shipper account, or a non-shipping account.
                                    */
                                    AccountNumber = "",

                                    /*
                                    Required: Yes* Type: Container Max Allowed: 1 Length: N/A
                                    Container for additional information for the third party UPS accounts address.
                                    */
                                    Address = new AddressType()
                                    {
                                        /*
    
                                        */
                                        AddressLine = new string[] { },

                                        /*
    
                                        */
                                        City = "",

                                        /*
    
                                        */
                                        StateProvinceCode = "",

                                        /*
                                        Required: Yes* Type: String Max Allowed: 1 Length: 1…9
                                        Origin postal code.
                                        The postal code must be the same as the UPS account pickup address postal code. Required for United States and Canadian UPS accounts and/or if the UPS account pickup address has a postal code. If the UPS account's pickup country or territory is US or Puerto Rico, the postal code is 5 or 9 digits. The character '-' may be used to separate the first five digits and the last four digits. If the UPS account's pickup country or territory is CA, the postal code is 6 alphanumeric characters whose format is A#A#A# where A is an uppercase letter and # is a digit.
                                        */
                                        PostalCode = "",

                                        /*
                                        Required: Yes* Type: String Max Allowed: 1 Length: 2
                                        Origin country or territory code. Refer to the Supported country or territory Tables located in the Appendix.
                                        */
                                        CountryCode = ""
                                    }
                                },

                                /*
                                Required: Cond Type: String Max Allowed: 1 Length: 0
                                Consignee Billing payment option indicator. The presence indicates consignee billing option is selected. The absence indicates one of the other payment options is selected.
                                Empty Tag. This element or its sibling element, BillShipper, BillReceiver or BillThirdParty, must be present but no more than one can be present. This billing option is valid for a shipment charge type of Transportation only. Only applies to US/PR and PR/US shipment origins and destination.
                                */
                                ConsigneeBilledIndicator = ""
                            }
                        },

                        /*
                        Required: No Type: String Max Allowed: 1 Length: 0
                        Split Duty VAT Indicator. The presence indicates the payer specified for Transportation Charges will pay transportation charges and any duties that apply to the shipment. The payer specified for Duties and Taxes will pay the VAT (Value-Added Tax) only.
                        Empty Tag. The payment method for Transportation charges must be UPS account. The UPS account must be a daily pickup account or an occasional account.
                        */
                        SplitDutyVATIndicator = ""
                    },

                    /*
                    Required: Cond Type: Container Max Allowed: 1 Length: N/A
                    UPS Ground Freight Pricing (GFP) Payment Information container.
                    Required only for GFP and when the FRSIndicator is present.
                    */
                    FRSPaymentInformation = new FRSPaymentInfoType()
                    {
                        /*
                        Required: Yes* Type: Container Max Allowed: 1 Length: N/A
                        GFP Payment Information Type container.
                        GFP only.
                        */
                        Type = new CodeDescriptionType()
                        {
                            /*
                            Required: Yes* Type: String Max Allowed: 1 Length: 2
                            Payer Type code for FRS Rate request.
                            Valid Values are: 01 = Prepaid 02 = FreightCollect 03 = BillThirdParty
                            */
                            Code = "",

                            /*
                            Required: No Type: String Max Allowed: 1 Length: 1…35
                            Text description of the code representing the GFP payment type.
                            */
                            Description = ""
                        },

                        /*
                        Required: No Type: String Max Allowed: 1 Length: 6
                        UPS Account Number.
                        */
                        AccountNumber = "",

                        /*
                        Required: Cond Type: Container Max Allowed: 1 Length: N/A
                        Payer Address Container.
                        Address container may be present for FRS Payment Information type = 02 and required when the FRS Payment Information type = 03.
                        */
                        Address = new PayerAddressType()
                        {
                            /*
                            Required: Cond Type: String Max Allowed: 1 Length: 1...9
                            Postal Code for UPS accounts billing address.
                            Postal Code may be present when the FRS Payment Information type = 02 and type = 03.
                            */
                            PostalCode = "",

                            /*
                            Required: Yes* Type: String Max Allowed: 1 Length: 2
                            Country or Territory code for the UPS accounts & billing address.
                            Country or Territory Code is required when the FRS Payment Information type = 02 and type= 03.
                            */
                            CountryCode = ""
                        }
                    },

                    /*
                    Required: No Type: Container Max Allowed: 1 Length: N/A
                    Container to hold Freight Shipment information.
                    */
                    FreightShipmentInformation = new FreightShipmentInformationType()
                    {
                        /*
                        Required: Cond Type: Container Max Allowed: 1 Length: N/A
                        Freight Density Info container.
                        Required if DensityEligibleIndicator is present.
                        */
                        FreightDensityInfo = new FreightDensityInfoType()
                        {
                            /*
                            Required: No Type: String Max Allowed: 1 Length: 0
                            The presence of the AdjustedHeightIndicator allows UPS to do height reduction adjustment for density based rate request.
                            */
                            AdjustedHeightIndicator = "",

                            /*
                            Required: Cond Type: Container Max Allowed: 1 Length: N/A
                            Container to hold Adjusted Height information.
                            Required if AdjustedHeightIndicator is present.
                            */
                            AdjustedHeight = new AdjustedHeightType()
                            {
                                /*
                                Required: Yes* Type: String Max Allowed: 1 Length: 1…19
                                Adjusted Height value for the handling unit.
                                */
                                Value = "",

                                /*
                                Required: Yes* Type: Container Max Allowed: 1 Length: N/A
                                Unit of Measurement container for the Adjusted height.
                                */
                                UnitOfMeasurement = new CodeDescriptionType()
                                {
                                    /*
                                    Required: Yes* Type: String Max Allowed: 1 Length: 2
                                    Code associated with Unit of Measurement for the Adjusted height. Valid value is IN
                                    Unit of measurement code for Adjusted height is validated only when Handling unit type is SKD = Skid or PLT = Pallet.
                                    */
                                    Code = "",

                                    /*
                                    Required: No Type: String Max Allowed: 1 Length: 1…35
                                    Description for Code associated with Unit of Measurement for the Adjusted height.
                                    */
                                    Description = ""
                                }
                            },

                            /*
                            Required: Yes* Type: Container Max Allowed: UNB Length: N/A
                            Handling Unit for Density based rating container.
                            */
                            HandlingUnits = new HandlingUnitsType[]
                            {
                                new HandlingUnitsType()
                                {
                                    /*
                                    Required: Yes* Type: String Max Allowed: 1 Length: 8
                                    Handling Unit Quantity for Density based rating.
                                    */
                                    Quantity = "",

                                    /*
                                    Required: Yes* Type: Container Max Allowed: 1 Length: N/A
                                    Handling Unit Type for Density based rating.
                                    */
                                    Type = new CodeDescriptionType()
                                    {
                                        /*
                                        Required: Yes* Type: String Max Allowed: 1 Length: 3
                                        The code associated with Handling Unit Type.
                                        Valid values: SKD = Skid CBY = Carboy PLT = Pallet TOT = Totes LOO = Loose OTH = Other
                                        */
                                        Code = "",

                                        /*
                                        Required: Yes* Type: String Max Allowed: 1 Length: 3
                                        The code associated with Handling Unit Type.
                                        Valid values: SKD = Skid CBY = Carboy PLT = Pallet TOT = Totes LOO = Loose OTH = Other
                                        */
                                        Description = ""
                                    },

                                    /*
                                    Required: Yes* Type: String Max Allowed: 1 Length: 3
                                    The code associated with Handling Unit Type.
                                    Valid values: SKD = Skid CBY = Carboy PLT = Pallet TOT = Totes LOO = Loose OTH = Other
                                    */
                                    Dimensions = new HandlingUnitsDimensionsType()
                                    {
                                        /*
                                        Required: Yes* Type: Container Max Allowed: 1 Length: N/A
                                        UnitOfMeasurement container.
                                        */
                                        UnitOfMeasurement = new CodeDescriptionType()
                                        {
                                            /*
                                            Required: Yes* Type: String Max Allowed: 1 Length: 2
                                            Code for UnitOfMeasurement for the line item dimension. Valid value: IN = Inches
                                            */
                                            Code = "",

                                            /*
                                            Required: No Type: String Max Allowed: 1 Length: 1…35
                                            Description for UnitOfMeasurement for the line item dimension.
                                            */
                                            Description = ""
                                        },

                                        /*
                                        Required: Yes* Type: String Max Allowed: 1 Length: 1…19
                                        The length of the line item used to determine dimensional weight.
                                        */
                                        Length = "",

                                        /*
                                        Required: Yes* Type: String Max Allowed: 1 Length: 1…19
                                        The height of the line item used to determine dimensional weight.
                                        */
                                        Height = "",

                                        /*
                                        Required: Yes* Type: String Max Allowed: 1 Length: 1…19
                                        The width of the line item used to determine dimensional weight.
                                        */
                                        Width = ""
                                    }
                                }
                            }
                        },

                        /*
                        Required: No Type: String Max Allowed: 1 Length: 0
                        The presence of the tag indicates that the rate request is density based. For Density Based Rating (DBR), the customer must have DBR Contract Service.
                        */
                        DensityEligibleIndicator = ""
                    },

                    /*
                    Required: No Type: String Max Allowed: 1 Length: 0
                    Goods Not In Free Circulation indicator.
                    This is an empty tag, any value inside is ignored. This indicator is invalid for a package type of UPS Letter and DocumentsOnly.
                    */
                    GoodsNotInFreeCirculationIndicator = "",

                    /*
                    Required: Cond Type: Container Max Allowed: 1 Length: N/A
                    Service Container.
                    Only valid with RequestOption = Rate for both Small package and GFP Rating requests.
                    */
                    Service = new CodeDescriptionType()
                    {
                        /*
                        Required: Yes* Type: String Max Allowed: 1 Length: 2
                        The code for the UPS Service associated with the shipment. Valid domestic values: NOTE: For all values, refer to Service Codes in the Appendix. 01 = Next Day Air 02 = 2nd Day Air 03 = Ground 12 = 3 Day Select 13 = Next Day Air Saver 14 = UPS Next Day Air Early 59 = 2nd Day Air A.M. Valid international values: 07 = Worldwide Express 08 = Worldwide Expedited 11= Standard 54 = Worldwide Express Plus 65 = Saver 96 = UPS Worldwide Express Freight 71 = UPS Worldwide Express Freight Midday Required for Rating and ignored for Shopping.
                        */
                        Code = "",

                        /*
                        Required: No Type: String Max Allowed: 1 Length: 1…35
                        A text description of the UPS Service associated with the shipment.
                        Length is not validated.
                        */
                        Description = ""
                    },

                    /*
                    Required: No Type: String Max Allowed: 1 Length: 1…5
                    Total number of pieces in all pallets. Required for UPS Worldwide Express Freight and UPS Worldwide Express Freight Midday shipments.
                    */
                    NumOfPieces = "",

                    /*
                    Required: Cond Type: Container Max Allowed: 1 Length: N/A
                    Shipment Total Weight Container. This container is only applicable for "ratetimeintransit" and "shoptimeintransit" request options.
                    Required for all international shipments when retreiving time in transit information, including letters and documents shipments.
                    */
                    ShipmentTotalWeight = new ShipmentWeightType()
                    {
                        /*
                        Required: Yes* Type: Container Max Allowed: 1 Length: N/A
                        UnitOfMeasurement Container.
                        */
                        UnitOfMeasurement = new CodeDescriptionType()
                        {
                            /*
                            Required: Yes* Type: String Max Allowed: 1 Length: 3
                            Code representing the unit of measure associated with the package weight. Codes are: LBS = Pounds, KGS = Kilograms.
                            */
                            Code = "",

                            /*
                            Required: No Type: String Max Allowed: 1 Length: 1..35
                            Text description of the code representing the unit of measure associated with the shipment weight.
                            */
                            Description = ""
                        },
                        /*
                        Required: Yes* Type: String Max Allowed: Length: 1..3
                        Non-zero total weight of all packages in the shipment.
                        */
                        Weight = ""
                    },

                    /*
                    Required: No Type: String Max Allowed: 1 Length: 0
                    Valid values are Document and Non-document. If the indicator is present then the value is Document else Non-Document. Note: Not applicable for FRS rating requests.
                    Empty Tag.
                    */
                    DocumentsOnlyIndicator = "",

                    /*
                    Required: Yes Type: Container Max Allowed: 200 Length: N/A
                    Package Container.
                    */
                    Package = new PackageType[]
                    {
                        new PackageType()
                        {
                            /*
                            Required: Cond Type: Container Max Allowed: 1 Length: N/A
                            Packaging Type Container.   
                            */
                            PackagingType = new CodeDescriptionType()
                            {
                                /*
                                Required: Yes* Type: String Max Allowed: 1 Length: 2
                                The code for the UPS packaging type associated with the package.
                                Valid values: 00 = UNKNOWN 01 = UPS Letter 02 = Package 03 = Tube 04 = Pak 21 = Express Box 24 = 25KG Box 25 = 10KG Box 30 = Pallet 2a = Small Express Box 2b = Medium Express Box 2c = Large Express Box. For FRS rating requests the only valid value is customer supplied packaging “02”.  
                                */
                                Code = "",

                                /*
                                Required: No Type: String Max Allowed: 1 Length: 1…35
                                A text description of the code for the UPS packaging type associated with the shipment.
                                Length is not validated.    
                                */
                                Description = ""
                            },

                            /*
                            Required: No Type: Container Max Allowed: 1 Length: N/A
                            Dimensions Container. This container is not applicable for GFP Rating request.   
                            */
                            Dimensions = new DimensionsType()
                            {
                                /*
                                Required: Yes* Type: Container Max Allowed: 1 Length: N/A
                                UnitOfMeasurement Container. 
                                */
                                UnitOfMeasurement = new CodeDescriptionType()
                                {
                                    /*
                                    Required: Yes* Type: String Max Allowed: 1 Length: 2
                                    Package dimensions unit of measurement code. Codes are: ‘IN’ = Inches, ‘CM’ = Centimeters.
                                    Valid codes are: ‘IN’ or ‘CM’.    
                                    */
                                    Code = "",

                                    /*
                                    Required: No Type: String Max Allowed: 1 Length: 1…35
                                    Text description of the code representing the UnitOfMeasurement associated with the package.
                                    This element is not validated.    
                                    */
                                    Description = ""
                                },

                                /*
                                Required: Cond Type: String Max Allowed: 1 Length: 6
                                Length of the package used to determine dimensional weight.
                                Required for GB to GB and Poland to Poland shipments.    
                                */
                                Length = "",

                                /*
                                Required: Cond Type: String Max Allowed: 1 Length: 6
                                Width of the package used to determine dimensional weight.
                                Required for GB to GB and Poland to Poland shipments.    
                                */
                                Width = "",

                                /*
                                Required: Cond Type: String Max Allowed: 1 Length: 6
                                Height of the package used to determine dimensional weight.
                                Required for GB to GB and Poland to Poland shipments.    
                                */
                                Height = ""
                            },

                            /*
                            Required: No Type: Container Max Allowed: 1 Length: N/A
                            Package Dimensional Weight container. Values in this container are ignored when package dimensions are provided. Please visit ups.com for instructions on calculating this value.
                            Only used for non-US/CA/PR shipments.    
                            */
                            DimWeight = new PackageWeightType()
                            {
                                /*
                                 Required: No Type: Container Max Allowed: 1 Length: N/A
                                UnitOfMeasurement Container.
                                N   
                                */
                                UnitOfMeasurement = new CodeDescriptionType()
                                {
                                    /*
                                     Required: No Type: String Max Allowed: 1 Length: 3
                                    Code representing the unit of measure associated with the package weight. Codes are: LBS = Pounds, KGS = Kilograms.
                                    Valid values: “LBS” = Pounds (default) and “KGS” = Kilograms.   
                                    */
                                    Code = "",

                                    /*
                                    Required: No Type: String Max Allowed: 1 Length: 3
                                    Code representing the unit of measure associated with the package weight. Codes are: LBS = Pounds, KGS = Kilograms.
                                    Valid values: “LBS” = Pounds (default) and “KGS” = Kilograms.    
                                    */
                                    Description = ""
                                },
                                /*
                                Required: No Type: String Max Allowed: 1 Length: 6
                                Dimensional weight of the package. Decimal values are not accepted, however there is one implied decimal place for values in this field (i.e. 115 = 11.5).    
                                */
                                Weight = ""
                            },

                            /*
                            Required: Cond Type: Container Max Allowed: 1 Length: N/A
                            Package Weight Container.
                            Required for an GFP Rating request. Otherwise optional.   
                            */
                            PackageWeight = new PackageWeightType()
                            {
                                /*
                                Required: Yes* Type: Container Max Allowed: 1 Length: N/A
                                UnitOfMeasurement Container.    
                                */
                                UnitOfMeasurement = new CodeDescriptionType()
                                {
                                    /*
                                    Required: Yes* Type: String Max Allowed: 1 Length: 3
                                    Code representing the unit of measure associated with the package weight. Codes are: LBS = Pounds, KGS = Kilograms.
                                    Valid values: LBS = Pounds (default) KGS = Kilograms    
                                    */
                                    Code = "",

                                    /*
                                    Required: No Type: String Max Allowed: 1 Length: 1…35
                                    Text description of the code representing the unit of measure associated with the package weight.
                                    Length and value are not validated.    
                                    */
                                    Description = ""
                                },
                                /*
                                Required: Yes* Type: String Max Allowed: 1 Length: 6
                                Actual package weight.
                                Weight accepted for letters/envelopes.    
                                */
                                Weight = ""
                            },

                            /*
                            Required: Cond Type: Container Max Allowed: 1 Length: N/A
                            Commodity Container.
                            Required only for GFP rating when FRSShipmentIndicator is requested.    
                            */
                            Commodity = new CommodityType()
                            {
                                /*
                                Required: Yes* Type: String Max Allowed: 1 Length: 10
                                Freight Classification. Freight class partially determines the freight rate for the article.
                                See Appendix of the Rating Ground Freight Web Services Developers Guide for list of Freight classes. For GFP Only.    
                                */
                                FreightClass = "",

                                /*
                                Required: No Type: Container Max Allowed: 1 Length: N/A
                                NMFC Commodity container.
                                For GFP Only.    
                                */
                                NMFC = new NMFCCommodityType()
                                {
                                    /*
                                    Required: Yes* Type: String Max Allowed: 1 Length: 4..6
                                    Value of NMFC Prime. Contact your service representative if you need information concerning NMFC Codes.
                                    Required if NMFC Container is present. For GFP Only.    
                                    */
                                    PrimeCode = "",

                                    /*
                                    Required: Cond Type: String Max Allowed: 1 Length: 2
                                    Value of NMFC Sub. Contact your service representative if you need information concerning NMFC Codes.
                                    Needs to be provided when the SubCode associated with the PrimeCode is other than 00. API defaults the sub value to 00 if not provided. If provided the Sub Code should be associated with the PrimeCode of the NMFC.    
                                    */
                                    SubCode = ""
                                }
                            },

                            /*
                            Required: No Type: String Max Allowed: 1 Length: 0
                            This element does not require a value and if one is entered it will be ignored.
                            If present, it indicates the shipment will be categorized as a Large Package.    
                            */
                            LargePackageIndicator = "",

                            /*
                            Required: No Type: Container Max Allowed: 1 Length: N/A
                            PackageServiceOptions container.    
                            */
                            PackageServiceOptions = new PackageServiceOptionsType()
                            {
                                /*
                                Required: No Type: Container Max Allowed: 1 Length: N/A
                                Delivery Confirmation Container. For a list of valid origin/destination countries or territories please refer to appendix.
                                DeliveryConfirmation and COD are mutually exclusive.    
                                */
                                DeliveryConfirmation = new DeliveryConfirmationType()
                                {
                                    /*
                                    Required: Yes* Type: String Max Allowed: 1 Length: 1
                                    Type of delivery confirmation.
                                    Valid values: 1 - Delivery Confirmation 2 - Delivery Confirmation Signature Required 3 - Delivery Confirmation Adult Signature Required    
                                    */
                                    DCISType = ""
                                },

                                /*
                                Required: No Type: Container Max Allowed: 1 Length: N/A
                                Access Point COD indicates Package COD is requested for a shipment.
                                Valid only for : 01 - Hold For Pickup At UPS Access Point, Shipment Indication type. Package Access Point COD is valid only for shipment without return service from US/PR to US/PR and CA to CA. Not valid with (Package) COD.   
                                */
                                AccessPointCOD = new PackageServiceOptionsAccessPointCODType()
                                {
                                    /*
                                    Required: Yes* Type: String Max Allowed: 1 Length: 3
                                    Access Point COD Currency Code.
                                    Required if Access Point COD container is present. UPS does not support all international currency codes. Refer to the appendix for a list of valid codes.    
                                    */
                                    CurrencyCode = "",

                                    /*
                                    Required: Yes* Type: String Max Allowed: 1 Length: 8
                                    Access Point COD Monetary Value.
                                    Required if Access Point COD container is present.    
                                    */
                                    MonetaryValue = ""
                                },

                                /*
                                Required: No Type: Container Max Allowed: 1 Length: N/A
                                COD Container. Indicates COD is requested.
                                Valid for the following country or territory combinations: US/PR to US/PR CA to CA CA to US Not allowed for CA to US for packages that are designated as Letters or Envelopes.    
                                */
                                COD = new CODType()
                                {
                                    /*
                                    Required: Yes* Type: Container Max Allowed: 1 Length: N/A
                                    CODAmount Container.    
                                    */
                                    CODAmount = new CODAmountType()
                                    {
                                        /*
                                        Required: Yes* Type: String Max Allowed: 1 Length: 3
                                        Currency Code.
                                        Required if a value for the COD amount exists in the MonetaryValue tag. Must match one of the IATA currency codes. UPS does not support all international currency codes. Refer to Currency Codes in the Appendix for a list of valid codes.   
                                        */
                                        CurrencyCode = "",

                                        /*
                                        Required: Yes* Type: String Max Allowed: 1 Length: 8
                                        The COD value for the package.
                                        Required if COD option is present. The maximum amount allowed is 50,000 USD.    
                                        */
                                        MonetaryValue = ""
                                    },

                                    /*
                                    Required: Yes* Type: String Max Allowed: 1 Length: 1
                                    Indicates the type of funds that will be used for the C.O.D. payment.
                                    For valid values, refer to Rating and Shipping COD Supported Countries or Territories in the Appendix.    
                                    */
                                    CODFundsCode = ""
                                },

                                /*
                                Required: No Type: Container Max Allowed: 1 Length: N/A
                                Declared Value Container.    
                                */
                                DeclaredValue = new InsuredValueType()
                                {
                                    /*
                                    Required: Yes* Type: String Max Allowed: 1 Length: 3
                                    The IATA currency code associated with the declared value amount for the package.
                                    Required if a value for the package declared value amount exists in the MonetaryValue tag. Must match one of the IATA currency codes. Length is not validated. UPS does not support all international currency codes. Refer to Currency Codes in the Appendix for a list of valid codes.    
                                    */
                                    CurrencyCode = "",

                                    /*
                                    Required: Yes* Type: String Max Allowed: 1 Length: 8
                                    The monetary value for the declared value amount associated with the package.
                                    Max value of 5,000 USD for Local and 50,000 USD for Remote. Absolute maximum value is 21474836.47    
                                    */
                                    MonetaryValue = ""
                                },

                                /*
                                Required: No Type: Container Max Allowed: 1 Length: N/A
                                Shipper Paid Declared Value Charge at Package level.
                                Valid for UPS World Wide Express Freight shipments.    
                                */
                                ShipperDeclaredValue = new ShipperDeclaredValueType()
                                {
                                    /*
                                    Required: Yes* Type: String Max Allowed: 1 Length: 3
                                    The IATA currency code associated with the amount for the package.
                                    UPS does not support all international currency codes. Refer to the appendix for a list of valid codes.    
                                    */
                                    CurrencyCode = "",

                                    /*
                                    Required: Yes* Type: String Max Allowed: 1 Length: 1…19
                                    The monetary value for the amount associated with the package.    
                                    */
                                    MonetaryValue = ""
                                },

                                /*
                                Required: No Type: String Max Allowed: 1 Length: 0
                                Any value associated with this element will be ignored.
                                If present, the package is rated for UPS Proactive Response and proactive package tracking.
                                Contractual accessorial for health care companies to allow package monitoring throughout the UPS system.
                                Shippers account needs to have valid contract for UPS Proactive Response.    
                                */
                                ProactiveIndicator = "",

                                /*
                                Required: No Type: String Max Allowed: 1 Length: 0
                                Presence/Absence Indicator. Any value is ignored. If present, indicates that the package contains an item that needs refrigeration.
                                Shippers account needs to have a valid contract for Refrigeration.    
                                */
                                RefrigerationIndicator = "",

                                /*
                                Required: No Type: Container Max Allowed: 1 Length: N/A
                                Insurance Accesorial. Only one type of insurance can exist at a time on the shipment.
                                Valid for UPS World Wide Express Freight shipments.    
                                */
                                Insurance = new InsuranceType()
                                {
                                    /*
                                    Required: No Type: Container Max Allowed: 1 Length: N/A
                                    Container to hold Basic Flexible Parcel Indicator information.
                                    Valid for UPS World Wide Express Freight shipments.   
                                    */
                                    BasicFlexibleParcelIndicator = new InsuranceValueType()
                                    {
                                        /*
                                        Required: Yes* Type: String Max Allowed: 1 Length: 3
                                        The IATA currency code associated with the amount for the package.
                                        UPS does not support all international currency codes. Refer to the appendix for a list of valid codes. Valid for UPS World Wide Express Freight shipments.    
                                        */
                                        CurrencyCode = "",

                                        /*
                                        Required: Yes* Type: String Max Allowed: 1 Length: 8
                                        The monetary value associated with the package.
                                        Valid for UPS World Wide Express Freight shipments.    
                                        */
                                        MonetaryValue = ""
                                    },

                                    /*
                                    Required: No Type: Container Max Allowed: 1 Length: N/A
                                    Container for Extended Flexible Parcel Indicator
                                    Valid for UPS World Wide Express Freight shipments.    
                                    */
                                    ExtendedFlexibleParcelIndicator = new InsuranceValueType()
                                    {
                                        /*
                                        Required: Yes* Type: String Max Allowed: 1 Length: 3
                                        The IATA currency code associated with the amount for the package.
                                        UPS does not support all international currency codes. Refer to the appendix for a list of valid codes. Valid for UPS World Wide Express Freight shipments.    
                                        */
                                        CurrencyCode = "",

                                        /*
                                        Required: Yes* Type: String Max Allowed: 1 Length: 8
                                        The monetary value associated with the package.
                                        Valid for UPS World Wide Express Freight shipments.    
                                        */
                                        MonetaryValue = ""
                                    },

                                    /*
                                    Required: No Type: Container Max Allowed: 1 Length: N/A
                                    Container to hold Time In Transit Flexible Parcel Indicator information.
                                    Valid for UPS World Wide Express Freight shipments.    
                                    */
                                    TimeInTransitFlexibleParcelIndicator = new InsuranceValueType()
                                    {
                                        /*
                                        Required: Yes* Type: String Max Allowed: 1 Length: 3
                                        The IATA currency code associated with the amount for the package.
                                        UPS does not support all international currency codes. Refer to the appendix for a list of valid codes. Valid for UPS World Wide Express Freight shipments.    
                                        */
                                        CurrencyCode = "",

                                        /*
                                        Required: Yes* Type: String Max Allowed: 1 Length: 8
                                        The monetary value associated with the package.
                                        Valid for UPS World Wide Express Freight shipments.    
                                        */
                                        MonetaryValue = ""
                                    }
                                },

                                /*
                                Required: No Type: String Max Allowed: 1 Length: 0
                                A flag indicating if the packages require Verbal Confirmation. True if VerbalConfirmationIndicator tag exists; false otherwise.
                                Empty Tag.    
                                */
                                VerbalConfirmationIndicator = "",

                                /*
                                 Required: No Type: String Max Allowed: 1 Length: 0
                                An UPSPremiumCareIndicator indicates special handling is required for shipment having controlled substances.
                                Empty Tag means indicator is present. Valid only for Canada to Canada movements. Available for the following Return Services: Returns Exchange (available with a contract) Print Return Label Print and Mail Electronic Return Label Return Service Three Attempt May be requested with following UPS services: UPS Express® Early UPS Express UPS Express Saver UPS Standard. Not available for packages with the following: Delivery Confirmation - Signature Required Delivery Confirmation - Adult Signature Required.   
                                */
                                UPSPremiumCareIndicator = "",

                                /*
                                Required: No Type: Container Max Allowed: 1 Length: N/A
                                Container to hold HazMat information.
                                Applies only if SubVersion is greater than or equal to 1701.    
                                */
                                HazMat = new HazMatType()
                                {
                                    /*
                                     Required: Cond Type: String Max Allowed: 1 Length: 1…5
                                    Identifies the package containing Dangerous Goods.
                                    Required if SubVersion is greater than or equal to 1701.   
                                    */
                                    PackageIdentifier = "",

                                    /*
                                    Required: Cond Type: String Max Allowed: 1 Length: 3
                                    QValue is required when a HazMat shipment specifies AllPackedInOneIndicator and the regulation set for that shipment is IATA.
                                    Applies only if SubVersion is greater than or equal to 1701. Valid values are : 0.1; 0.2; 0.3; 0.4; 0.5; 0.6; 0.7; 0.8; 0.9; 1.0    
                                    */
                                    QValue = "",

                                    /*
                                    Required: No Type: String Max Allowed: 1 Length: 0
                                    Presence/Absence Indicator. Any value is ignored. Presence indicates that shipment is overpack.
                                    Applies only if SubVersion is greater than or equal to 1701.    
                                    */
                                    OverPackedIndicator = "",

                                    /*
                                    Required: No Type: String Max Allowed: 1 Length: 0
                                    Presence/Absence Indicator. Any value is ignored. Indicates the hazmat shipment/package is all packed in one.
                                    Applies only if SubVersion is greater than or equal to 1701.   
                                    */
                                    AllPackedInOneIndicator = "",

                                    /*
                                    Required: Yes* Type: Container Max Allowed: 3 Length: N/A
                                    Container to hold HazMat Chemical Records.    
                                    */
                                    HazMatChemicalRecord = new HazMatChemicalRecordType[]
                                    {
                                        new HazMatChemicalRecordType()
                                        {
                                            /*
                                            Required: Cond Type: String Max Allowed: 1 Length: 1…3
                                            Identifies the Chemcial Record.
                                            Required if SubVersion is greater than or equal to 1701.    
                                            */
                                            ChemicalRecordIdentifier = "",

                                            /*
                                            Required: Cond Type: String Max Allowed: 1 Length: 1…7
                                            This is the hazard class associated to the specified commodity. Required if CommodityRegulatedLevelCode is ‘LQ’ or ‘FR’
                                            Applies only if SubVersion is greater than or equal to 1701.    
                                            */
                                            ClassDivisionNumber = "",

                                            /*
                                            Required: Cond Type: String Max Allowed: 1 Length: 1…6
                                            This is the ID number (UN/NA/ID) for the specified commodity. Required if CommodityRegulatedLevelCode = LR, LQ or FR and if the field applies to the material by regulation. UN/NA/ID Identification Number assigned to the specified regulated good. (Include the UN/NA/ID as part of the entry).
                                            Applies only if SubVersion is greater than or equal to 1701.    
                                            */
                                            IDNumber = "",

                                            /*
                                            Required: Yes* Type: String Max Allowed: 1 Length: 2
                                            The method of transport by which a shipment is approved to move and the regulations associated with that method. Only required when the CommodityRegulatedLevelCode is FR or LQ. Valid values: 01 - Highway 02 - Ground 03 - Passenger Aircraft 04 - Cargo Aircraft Only
                                            Applies only if SubVersion is greater than or equal to 1701. For multiple ChemicalRecords per package having different TransportationMode, TransportationMode of first ChemicalRecord would be considered for validating and rating the package. All TransportationMode except for '04' are general service offering. If any chemical record contains '04' as TransportationMode, ShipperNumber needs to be authorized to use '04' as TransportationMode.    
                                            */
                                            TransportationMode = "",

                                            /*
                                            Required: Yes* Type: String Max Allowed: 1 Length: 3…4
                                            The Regulatory set associated with every regulated shipment. It must be the same across the shipment. Valid values: ADR - For Europe to Europe Ground Movement CFR - For HazMat regulated by US Dept. of Transportation within the U.S. or ground shipments to Canada, IATA - For Worldwide Air movement TDG - For Canada to Canada ground movement or Canada to U.S. standard movement
                                            Applies only if SubVersion is greater than or equal to 1701. For multiple ChemicalRecords per package or multiple packages containing different RegulationSet, RegulationSet of first ChemicalRecord would be considered for validating and rating the entire shipment.    
                                            */
                                            RegulationSet = "",

                                            /*
                                            Required: No Type: String Max Allowed: 1 Length: 1…25
                                            24 Hour Emergency Phone Number of the shipper. Valid values for this field are (0) through (9) with trailing blanks. For numbers within the U.S., the layout is '1', area code, 7-digit number. For all other countries or territories the layout is country or territory code, area code, number.
                                            Applies only if SubVersion is greater than or equal to 1701.
                                            The following are restricted in the phone number
                                            “period “.”, dash “-“, plus sign “+” and conventional parentheses “(“ and “)”, “EXT or OPT”    
                                            */
                                            EmergencyPhone = "",

                                            /*
                                            Required: Cond Type: String Max Allowed: 1 Length: 1…35
                                            The emergency information, contact name and/or contact number, required to be communicated when a call is placed to the EmergencyPhoneNumber. The information is required if there is a value in the EmergencyPhoneNumber field above and the shipment is with a US50 or PR origin and/or destination and the RegulationSet is IATA.
                                            Applies only if SubVersion is greater than or equal to 1701.    
                                            */
                                            EmergencyContact = "",

                                            /*
                                            Required: Cond Type: String Max Allowed: 1 Length: 1…2
                                            Required if CommodityRegulatedLevelCode = LQ or FR and if the field applies to the material by regulation. If reportable quantity is met, 'RQ' should be entered.
                                            Applies only if SubVersion is greater than or equal to 1701.    
                                            */
                                            ReportableQuantity = "",

                                            /*
                                            Required: Cond Type: String Max Allowed: 1 Length: 1…100
                                            Required if CommodityRegulatedLevelCode = LQ or FR and if the field applies to the material by regulation. Secondary hazardous characteristics of a package. (There can be more than one – separate each with a comma).
                                            Applies only if SubVersion is greater than or equal to 1701.    
                                            */
                                            SubRiskClass = "",

                                            /*
                                            Required: Cond Type: String Max Allowed: 1 Length: 1…10
                                            This is the packing group category associated to the specified commodity. Required if CommodityRegulatedLevelCode = LQ or FR and if the field applies to the material by regulation. Must be shown in Roman Numerals. Valid values are: I, II, III, blank.
                                            Applies only if SubVersion is greater than or equal to 1701.    
                                            */
                                            PackagingGroupType = "",

                                            /*
                                            Required: Cond Type: String Max Allowed: 1 Length: 15
                                            Required if CommodityRegulatedLevelCode = LQ or FR. The numerical value of the mass capacity of the regulated good.
                                            Applies only if SubVersion is greater than or equal to 1701.    
                                            */
                                            Quantity = "",

                                            /*
                                            Required: Cond Type: String Max Allowed: 1 Length: 1…10
                                            Required if CommodityRegulatedLevelCode = LQ or FR. The unit of measure used for the mass capacity of the regulated good. For Example: ml, L, g, mg, kg, cylinder, pound, pint, quart, gallon, ounce etc.
                                            Applies only if SubVersion is greater than or equal to 1701.    
                                            */
                                            UOM = "",

                                            /*
                                             Required: Cond Type: String Max Allowed: 1 Length: 1…353
                                            The packing instructions related to the chemical record. Required if CommodityRegulatedLevelCode = LQ or FR and if the field applies to the material by regulation.
                                            Applies only if SubVersion is greater than or equal to 1701.   
                                            */
                                            PackagingInstructionCode = "",

                                            /*
                                            Required: Cond Type: String Max Allowed: 1 Length: 1…250
                                            The Proper Shipping Name assigned by ADR, CFR or IATA. Required if CommodityRegulatedLevelCode = LR, LQ or FR.
                                            Applies only if SubVersion is greater than or equal to 1701.   
                                            */
                                            ProperShippingName = "",

                                            /*
                                             Required: Cond Type: String Max Allowed: 1 Length: 1…300
                                            The technical name (when required) for the specified commodity. Required if CommodityRegulatedLevelCode = LQ or FR and if the field applies to the material by regulation.
                                            Applies only if SubVersion is greater than or equal to 1701.   
                                            */
                                            TechnicalName = "",

                                            /*
                                            Required: Cond Type: String Max Allowed: 1 Length: 1…75
                                            Additional remarks or special provision information. Required if CommodityRegulatedLevelCode = LQ or FR and if the field applies to the material by regulation. Additional information that may be required by regulation about a hazardous material, such as, “Limited Quantity”, DOT-SP numbers, EX numbers.
                                            Applies only if SubVersion is greater than or equal to 1701.    
                                            */
                                            AdditionalDescription = "",

                                            /*
                                            Required: Cond Type: String Max Allowed: 1 Length: 1…255
                                            The package type code identifying the type of packaging used for the commodity. (Ex: Fiberboard Box). Required if CommodityRegulatedLevelCode = LQ or FR.
                                            Applies only if SubVersion is greater than or equal to 1701.    
                                            */
                                            PackagingType = "",

                                            /*
                                            Required: Cond Type: String Max Allowed: 1 Length: 1…50
                                            Defines the type of label that is required on the package for the commodity. Not applicable if CommodityRegulatedLevelCode = LR or EQ.
                                            Applies only if SubVersion is greater than or equal to 1701.    
                                            */
                                            HazardLabelRequired = "",

                                            /*
                                            Required: Cond Type: String Max Allowed: 1 Length: 1…3
                                            The number of pieces of the specific commodity. Required if CommodityRegulatedLevelCode = LQ or FR. Valid values are 1 to 999.
                                            Applies only if SubVersion is greater than or equal to 1701.    
                                            */
                                            PackagingTypeQuantity = "",

                                            /*
                                            Required: Cond Type: String Max Allowed: 1 Length: 2
                                            Indicates the type of commodity - Fully Regulated (FR), Limited Quantity (LQ), Excepted Quantity (EQ), Lightly Regulated (LR). Default value is FR. Valid values are LR, FR, LQ, EQ.
                                            Applies only if SubVersion is greater than or equal to 1701.    
                                            */
                                            CommodityRegulatedLevelCode = "",

                                            /*
                                            Required: No Type: String Max Allowed: 1 Length: 1
                                            Transport Category. Valid values are 0 to 4.
                                            Applies only if SubVersion is greater than or equal to 1701.    
                                            */
                                            TransportCategory = "",

                                            /*
                                            Required: No Type: String Max Allowed: 1 Length: 1…10
                                            Defines what is restricted to pass through a tunnel.
                                            Applies only if SubVersion is greater than or equal to 1701.    
                                            */
                                            TunnelRestrictionCode = "",
                                        }
                                    }
                                },

                                /*
                                Required: No Type: Container Max Allowed: 1 Length: N/A
                                Container to hold Dry Ice information.    
                                */
                                DryIce = new DryIceType()
                                {
                                    /*
                                    Required: Yes* Type: String Max Allowed: 1 Length: 3…4
                                    Regulation set for DryIce Shipment. Valid values: CFR = For HazMat regulated by US Dept of Transportation within the U.S. or ground shipments to Canada, IATA = For Worldwide Air movement.
                                    The following values are valid: CFR and IATA.    
                                    */
                                    RegulationSet = "",

                                    /*
                                    Required: Yes* Type: Container Max Allowed: 1 Length: N/A
                                    Container for Weight information for Dry Ice.    
                                    */
                                    DryIceWeight = new DryIceWeightType()
                                    {
                                        /*
                                        Required: Yes* Type: Container Max Allowed: 1 Length: N/A
                                        Container for Unit Of Measurement for Dry Ice.    
                                        */
                                        UnitOfMeasurement = new CodeDescriptionType()
                                        {
                                            /*
                                            Required: Yes* Type: String Max Allowed: 1 Length: 2
                                            DryIce weight unit of measurement code. Valid values: 00 = KG (Metric Unit of Measurements) or KGS 01 = LB (English Unit of Measurements) or LBS
                                            The following values are valid : 00 , 01    
                                            */
                                            Code = "",

                                            /*
                                            Required: No Type: String Max Allowed: 1 Length: 1…20
                                            Text description of the code representing the unit of measure associated with the package.    
                                            */
                                            Description = ""
                                        },

                                        /*
                                        Required: Yes* Type: String Max Allowed: 1 Length: 1…5
                                        Weight for Dry Ice.
                                        Cannot be more than package weight. Should be more than 0.0. Valid characters are 0-9 and "." (Decimal point). Limit to 1 digit after the decimal. The maximum length of the field is 5 including "." and can hold up to 1 decimal place.    
                                        */
                                        Weight = "",
                                    },

                                    /*
                                    Required: No Type: String Max Allowed: 1 Length: 0
                                    Presence/Absence Indicator. Any value inside is ignored. Relevant only in CFR regulation set. If present it is used to designate the Dry Ice is for any medical use and rates are adjusted for DryIce weight more than 2.5 KGS or 5.5 LBS.    
                                    */
                                    MedicalUseIndicator = "",

                                    /*
                                        Required: No Type: String Max Allowed: 1 Length: 0
                                    Presence/Absence Indicator. Any value inside is ignored. Indicates a Dry Ice audit will be performed per the Regulation Set requirements. Empty tag means indicator is present.   
                                    */
                                    AuditRequired = ""
                                }
                            },

                            /*
                            Required: No Type: String Max Allowed: 1 Length: 0
                            A flag indicating if the packages require additional handling. True if AdditionalHandlingIndicator tag exists; false otherwise. Additional Handling indicator indicates it’s a non-corrugated package.
                            Empty Tag.    
                            */
                            AdditionalHandlingIndicator = ""
                        }
                    },

                    /*
                     Required: No Type: Container Max Allowed: 1 Length: N/A
                    Shipment level Accessorials are included in this container.   
                    */
                    ShipmentServiceOptions = new ShipmentServiceOptionsType()
                    {
                        /*
                        Required: No Type: String Max Allowed: 1 Length: 0
                        A flag indicating if the shipment requires a Saturday pickup. True if SaturdayPickupIndicator tag exists; false otherwise. Not available for GFP rating requests.
                        Empty Tag.    
                        */
                        SaturdayPickupIndicator = "",

                        /*
                         Required: No Type: String Max Allowed: 1 Length: 0
                        A flag indicating if a shipment must be delivered on a Saturday. True if SaturdayDeliveryIndicator tag exists; false otherwise
                        Empty Tag.   
                        */
                        SaturdayDeliveryIndicator = "",

                        /*
                        Required: No Type: Container Max Allowed: 1 Length: N/A
                        Access Point COD indicates Shipment level Access Point COD is requested for a shipment.
                        Valid only for "01 - Hold For Pickup At UPS Access Point" Shipment Indication type. Shipment Access Point COD is valid only for countries or territories within E.U. Not valid with (Shipment) COD. Not available to shipment with return service.    
                        */
                        AccessPointCOD = new ShipmentServiceOptionsAccessPointCODType()
                        {
                            /*
                            Required: Yes* Type: String Max Allowed: 1 Length: 3
                            Access Point COD Currency Code.
                            Required if Access Point COD container is present. UPS does not support all international currency codes. Refer to the appendix for a list of valid codes.    
                            */
                            CurrencyCode = "",

                            /*
                            Required: Yes* Type: String Max Allowed: 1 Length: 8…2
                            Access Point COD Monetary Value.
                            Required if Access Point COD container is present.    
                            */
                            MonetaryValue = ""
                        },

                        /*
                         Required: No Type: String Max Allowed: 1 Length: 0
                        Presence/Absence Indicator. Any value inside is ignored. DeliverToAddresseeOnlyIndicator is shipper specified restriction that requires the addressee to be the one who takes final delivery of the "Hold For PickUp at UPS Access Point" package. Presence of indicator means shipper restriction will apply to the shipment.
                        Only valid for Shipment Indication type "01 - Hold For PickUp at UPS Access Point".   
                        */
                        DeliverToAddresseeOnlyIndicator = "",

                        /*
                        Required: No Type: String
                        Max Allowed: 1 Length: 0
                        Presence/Absence Indicator. Any value inside is ignored. Direct Delivery Only (DDO) accessorial in a request would ensure that delivery is made only to the Ship To address on the shipping label.
                        This accessorial is not valid with Shipment Indication Types: 01 - Hold For Pickup At UPS Access Point 02 - UPS Access Point™ Delivery"    
                        */
                        DirectDeliveryOnlyIndicator = "",

                        /*
                        Required: No Type: Container Max Allowed: 1 Length: N/A
                        If present, indicates C.O.D. is requested for the shipment.
                        Shipment level C.O.D. is only available for EU origin countries or territories. C.O.D. shipments are only available for Shippers with Daily Pickup and Drop Shipping accounts.    
                        */
                        COD = new CODType()
                        {
                            /*
                            Required: Yes* Type: String Max Allowed: 1 Length: 1
                            For valid values, refer to Rating and Shipping COD Supported Countries or Territories in the Appendix.    
                            */
                            CODFundsCode = "",

                            /*
                            Required: Yes* Type: Container Max Allowed: 1 Length: N/A
                            CODAmount Container.
                            UPS does not support all international currency codes. Refer to the appendix for a list of valid codes.    
                            */
                            CODAmount = new CODAmountType()
                            {
                                /*
                                Required: Yes* Type: String Max Allowed: 1 Length: 3
                                COD amount currency code type.    
                                */
                                CurrencyCode = "",

                                /*
                                Required: Yes* Type: String Max Allowed: 1 Length: 8
                                COD Amount.    
                                */
                                MonetaryValue = ""
                            }
                        },

                        /*
                        Required: No Type: Container Max Allowed: 1 Length: N/A
                        Delivery Confirmation Container.
                        DeliveryConfirmation and C.O.D. are mutually exclusive. Refer to the Appendix for a list of valid origin-destination country or territory pairs associated with each confirmation type.    
                        */
                        DeliveryConfirmation = new DeliveryConfirmationType()
                        {
                            /*
                            Required: Yes* Type: String Max Allowed: 1 Length: 1
                            Type of delivery confirmation.
                            Valid values: 1 - Delivery Confirmation Signature Required 2 - Delivery Confirmation Adult Signature Required    
                            */
                            DCISType = ""
                        },

                        /*
                        Required: No Type: String Max Allowed: 1 Length: 0
                        Return of Documents Indicator - If the flag is present, the shipper has requested the ReturnOfDocument accessorial be added to the shipment
                        Valid for Poland to Poland shipment.    
                        */
                        ReturnOfDocumentIndicator = "",

                        /*
                        Required: No Type: String Max Allowed: 1 Length: 0
                        UPS carbon neutral indicator. Indicates the shipment will be rated as carbon neutral.    
                        */
                        UPScarbonneutralIndicator = "",

                        /*
                        Required: No Type: String Max Allowed: 1 Length: 0
                        The empty tag in request indicates that customer would be using UPS prepared SED form.
                        Valid for UPS World Wide Express Freight shipments.   
                        */
                        CertificateOfOriginIndicator = "",

                        /*
                            Required: No Type: Container Max Allowed: 1 Length: N/A
                        Shipment Service Pickup Options Container.
                        Valid for UPS Worldwide Express Freight and UPS Worldwide Express Freight Midday shipments.   
                        */
                        PickupOptions = new PickupOptionsType()
                        {
                            /*
                            Required: No Type: String Max Allowed: 1 Length: 0
                            The presence of the tag LiftGatePickupRequiredIndicator indicates that the shipment requires a lift gate for pickup.    
                            */
                            LiftGateAtPickupIndicator = "",

                            /*
                            Required: No Type: String Max Allowed: 1 Length: 0
                            The presence of the tag HoldForPickupIndicator indicates that the user opted to hold the shipment at UPS location for pickup.    
                            */
                            HoldForPickupIndicator = ""
                        },

                        /*
                        Required: No Type: Container Max Allowed: 1 Length: N/A
                        Shipment Service Delivery Options Container.
                        Valid for UPS Worldwide Express Freight and UPS Worldwide Express Freight Midday shipments.    
                        */
                        DeliveryOptions = new DeliveryOptionsType()
                        {
                            /*
                            Required: No Type: String Max Allowed: 1 Length: 0
                            The presence of the tag LiftGateAtDeliveryIndicator indicates that the shipment requires a lift gate for delivery.    
                            */
                            LiftGateAtDeliveryIndicator = "",

                            /*
                            Required: No Type: String Max Allowed: 1 Length: 0
                            The presence of the tag DropOffAtUPSFacilityIndicator indicates the package will be dropped at a UPS facility for shipment.    
                            */
                            DropOffAtUPSFacilityIndicator = ""
                        },

                        /*
                        Required: No Type: Container Max Allowed: 1 Length: N/A
                        Restricted Articles container.
                        Valid for UPS World Wide Express Freight shipments.    
                        */
                        RestrictedArticles = new RestrictedArticlesType()
                        {
                            /*
                            Required: No Type: String Max Allowed: 1 Length: 0
                            This field is a flag to indicate if the package has Alcohol. True if present; false otherwise.
                            Valid for UPS World Wide Express Freight shipments.    
                            */
                            AlcoholicBeveragesIndicator = "",

                            /*
                            Required: No Type: String Max Allowed: 1 Length: 0
                            This field is a flag to indicate if the package has Biological substances. True if present; false otherwise.
                            Valid for UPS World Wide Express Freight shipments.    
                            */
                            DiagnosticSpecimensIndicator = "",

                            /*
                            Required: No Type: String Max Allowed: 1 Length: 0
                            This field is a flag to indicate if the package has Perishables. True if present; false otherwise.
                            Valid for UPS World Wide Express Freight shipments.    
                            */
                            PerishablesIndicator = "",

                            /*
                            Required: No Type: String Max Allowed: 1 Length: 0
                            This field is a flag to indicate if the package has Plants. True if present; false otherwise.
                            Valid for UPS World Wide Express Freight shipments.    
                            */
                            PlantsIndicator = "",

                            /*
                            Required: No Type: String Max Allowed: 1 Length: 0
                            This field is a flag to indicate if the package has Seeds. True if present; false otherwise.
                            Valid for UPS World Wide Express Freight shipments.    
                            */
                            SeedsIndicator = "",

                            /*
                            Required: No Type: String Max Allowed: 1 Length: 0
                            This field is a flag to indicate if the package has Special Exceptions Restricted Materials. True if present; false otherwise.
                            Valid for UPS World Wide Express Freight shipments.    
                            */
                            SpecialExceptionsIndicator = "",

                            /*
                            Required: No Type: String Max Allowed: 1 Length: 0
                            This field is a flag to indicate if the package has Tobacco. True if present; false otherwise.
                            Valid for UPS World Wide Express Freight shipments.    
                            */
                            TobaccoIndicator = ""
                        },

                        /*
                        Required: No Type: String Max Allowed: 1 Length: 0
                        The empty tag in request indicates that customer would be using UPS prepared SED form.
                        Valid for UPS World Wide Express Freight shipments.    
                        */
                        ShipperExportDeclarationIndicator = "",

                        /*
                        Required: No Type: String Max Allowed: 1 Length: 0
                        Presence/Absence Indicator. Any value inside is ignored. CommercialInvoiceRemovalIndicator - empty tag means indicator is present. CommercialInvoiceRemovalIndicator allows a shipper to dictate that UPS remove the Commercial Invoice from the user's shipment before the shipment is delivered to the ultimate consignee.    
                        */
                        CommercialInvoiceRemovalIndicator = "",

                        /*
                        Required: No Type: Container Max Allowed: 1 Length: N/A
                        Container for type of Import Control shipments.    
                        */
                        ImportControl = new ImportControlType()
                        {
                            /*
                            Required: Yes* Type: String Max Allowed: 1 Length: 2
                            Code for type of Import Control shipment.
                            Valid values are:
                            '01' = ImportControl Print and Mail
                            '02' = ImportControl One-Attempt '03' = ImportControl Three-Attempt
                            '04' = ImportControl Electronic Label
                            '05' = ImportControl Print Label.    
                            */
                            Code = "",

                            /*
                            Required: No Type: String Max Allowed: 1 Length: 1…50
                            Text description of the code representing the Import Control associated with the shipment.    
                            */
                            Description = ""
                        },

                        /*
                        Required: No Type: Container Max Allowed: 1 Length: N/A
                        Container for type of Return Services.   
                        */
                        ReturnService = new ReturnServiceType()
                        {
                            /*
                            Required: Yes* Type: String Max Allowed: 1 Length: 1…2
                            Code for type of Return shipment.
                            Valid values are:
                            '2' = UPS Print and Mail Return Label
                            '3' =UPS One-Attempt Return Label
                            '5' = UPS Three Attempt Return Label
                            '8' = UPS Electronic Return Label
                            '9' = UPS Print Return Label
                            '10' = UPS Exchange Print Return Label '11' = UPS Pack & Collect Service 1-Attempt Box 1
                            '12' = UPS Pack & Collect Service 1-Attempt Box 2
                            '13' = UPS Pack & Collect Service 1-Attempt Box 3
                            '14' = UPS Pack & Collect Service 1-Attempt Box 4
                            '15' = UPS Pack & Collect Service 1-Attempt Box 5
                            '16' = UPS Pack & Collect Service 3-Attempt Box 1
                            '17' = UPS Pack & Collect Service 3-Attempt Box 2
                            '18' = UPS Pack & Collect Service 3-Attempt Box 3
                            '19' = UPS Pack & Collect Service 3-Attempt Box 4
                            '20' = UPS Pack & Collect Service 3-Attempt Box 5
                            #5 and #10 - Three Attempt Return Label are not valid for UPS WorldWide Express Freight and UPS Worldwide Express Freight Midday Services. #3 is not valid return service with UPS Premium Care accessorial.    
                            */
                            Code = "",

                            /*
                            Required: No Type: String Max Allowed: 1 Length: 1…50
                            Description for type of Return Service.    
                            */
                            Description = ""
                        },

                        /*
                        Required: No Type: String Max Allowed: 1 Length: 0
                        Empty Tag means the indicator is present. This field is a flag to indicate if the receiver needs SDL rates in response. True if SDLShipmentIndicator tag exists; false otherwise.
                        If present, the State Department License (SDL) rates will be returned in the response. This service requires that the account number is enabled for SDL.    
                        */
                        SDLShipmentIndicator = "",

                        /*
                        Required: No Type: String Max Allowed: 1 Length: 0
                        Presence/Absence Indicator. Any value inside is ignored. This field is a flag to indicate Package Release Code is requested for shipment. This accessorial is only valid with ShipmentIndicationType ‘01’ - Hold for Pickup at UPS Access Point™.    
                        */
                        EPRAIndicator = ""
                    },

                    /*
                    Required: No Type: Container Max Allowed: 1 Length: N/A
                    Shipment Rating Options container.    
                    */
                    ShipmentRatingOptions = new ShipmentRatingOptionsType()
                    {
                        /*
                        Required: Cond Type: String Max Allowed: 1 Length: 0
                        NegotiatedRatesIndicator - Required to display two types of discounts: 1) Bids or Account Based Rates 2) Web/Promotional Discounts Bids Account Based Rates: If the indicator is present, the Shipper is authorized, and the Rating API XML Request is configured to return Negotiated Rates, then Negotiated Rates should be returned in the response. Web/Promotional Discounts: If the indicator is present, the Shipper is authorized for Web/Promotional Discounts then Negotiated Rates should be returned in the response.    
                        */
                        NegotiatedRatesIndicator = "",

                        /*
                        Required: Cond Type: String Max Allowed: 1 Length: 0
                        FRS Indicator. The indicator is required to obtain rates for UPS Ground Freight Pricing (GFP).
                        The account number must be enabled for GFP.    
                        */
                        FRSShipmentIndicator = "",

                        /*
                        Required: Cond Type: String Max Allowed: 1 Length: 0
                        RateChartIndicator - If present in a request, the response will contain a RateChart element.    
                        */
                        RateChartIndicator = "",

                        /*
                        Required: No Type: String Max Allowed: 1 Length: 0
                        UserLevelDiscountIndicator - required to obtain rates for User Level Promotions.
                        This is required to obtain User Level Discounts. There must also be no ShipperNumber in the Shipper container.    
                        */
                        UserLevelDiscountIndicator = ""
                    },

                    /*
                    Required: Cond Type: Container Max Allowed: 1 Length: N/A
                    Container to hold InvoiceLineTotal Information.
                    Required if the shipment is from US/PR Outbound to non US/PR destination with the PackagingType of UPS PAK(04). Required for international shipments when using request option "ratetimeintransit" or "shoptimeintransit".    
                    */
                    InvoiceLineTotal = new InvoiceLineTotalType()
                    {
                        /*
                        Required: No Type: String Max Allowed: 1 Length: 3
                        Invoice Line Total Currency type. Defaults to the rating currency used in the shipper's country or territory. If entered, the Currency code should match the origin country’s or territory’s currency code, otherwise the currency code entered will be ignored.
                        Note: UPS doesn't support all international currency codes. Please check the developer guides for Supported Currency codes.   
                        */
                        CurrencyCode = "",

                        /*
                        Required: Yes* Type: String Max Allowed: 1 Length: 1..19
                        Total amount of the invoice accompanying the shipment. Required when the InvoiceLineTotal container exists in the rate request.
                        Valid values are from 1 to 99999999.    
                        */
                        MonetaryValue = ""
                    },

                    /*
                    Required: No Type: String Max Allowed: 1 Length: 0
                    Presence/Absence Indicator. Any value inside is ignored. RatingMethodRequestedIndicator is an indicator. If present, Billable Weight Calculation method and Rating Method information would be returned in response.    
                    */
                    RatingMethodRequestedIndicator = "",

                    /*
                    Required: No Type: String Max Allowed: 1 Length: 0
                    Presence/Absence Indicator. Any value inside is ignored. TaxInformationIndicator is an indicator. The Tax related information includes any type of Taxes, corresponding Monetary Values, Total Charges with Taxes and disclaimers (if applicable) would be returned in response.
                    If present, any taxes that may be applicable to a shipment would be returned in response. If this indicator is requested with NegotiatedRatesIndicator, Tax related information, if applicable, would be returned only for Negotiated Rates and not for Published Rates.   
                    */
                    TaxInformationIndicator = "",

                    /*
                    Required: No Type: Container Max Allowed: 1 Length: N/A
                    PromotionalDiscountInformation container. This container contains discount information that the customer wants to request each time while placing a shipment.   
                    */
                    PromotionalDiscountInformation = new PromotionalDiscountInformationType()
                    {
                        /*
                        Required: Yes* Type: String Max Allowed: 1 Length: 9
                        Promotion Code. A discount that is applied to the user.
                        Required if PromotionalDiscountInformation container is present.    
                        */
                        PromoCode = "",

                        /*
                        Required: Yes* Type: String Max Allowed: 1 Length: 20
                        Promotion Alias code
                        Required if PromotionalDiscountInformation container is present.    
                        */
                        PromoAliasCode = ""
                    },

                    /*
                    Required: No Type: Container Max Allowed: 1 Length: N/A
                    Container for requesting Time In Transit Information. Required to view time in transit information.
                    Required to view any time in transit information.    
                    */
                    DeliveryTimeInformation = new TimeInTransitRequestType()
                    {
                        /*
                        Required: Yes* Type: String Max Allowed: 1 Length: 2
                        Valid values are: 02 - Document only 03 - Non-Document 04 - WWEF Pallet 07 - Domestic Pallet If 04 is included, Worldwide Express Freight and UPS Worldwide Express Freight Midday services (if applicable) will be included in the response.   
                        */
                        PackageBillType = "",

                        /*
                        Required: No Type: Container Max Allowed: 1 Length: N/A
                        Pickup container.    
                        */
                        Pickup = new PickupType()
                        {
                            /*
                            Required: No Type: String Max Allowed: 1 Length: 8
                            Shipment Date; The Pickup date is a Shipment Date and it is a required input field. The user is allowed to query up to 35 days into the past and 60 days into the future. Format: YYYYMMDD
                            If a date is not provided, it will be defaulted to the current system date.    
                            */
                            Date = "",

                            /*
                            Required: No Type: String Max Allowed: 1 Length: 4…6
                            Reflects the time the package is tendered to UPS for shipping (can be dropped off at UPS or picked up by UPS). Military Time Format HHMMSS or HHMM.
                            Invalid pickup time will not be validated.    
                            */
                            Time = ""
                        }
                    }
                }
            };
            
            var response = client.ProcessRate(security, request);
        }
    }
}
