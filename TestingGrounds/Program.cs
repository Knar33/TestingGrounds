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
                CustomerClassification = new CodeDescriptionType()
                {
                    Code = "",
                    Description = ""
                },
                PickupType = new CodeDescriptionType()
                {
                    Code = "",
                    Description = ""
                },
                Request = new RequestType()
                {
                    RequestOption = new string[] { },
                    SubVersion = "",
                    TransactionReference = new TransactionReferenceType()
                    {
                        CustomerContext = "",
                        TransactionIdentifier = ""
                    }
                },
                Shipment = new ShipmentType()
                {
                    OriginRecordTransactionTimestamp = "",
                    Shipper = new ShipperType()
                    {
                        Name = "",
                        Address = new AddressType()
                        {
                            AddressLine = new string[] { },
                            City = "",
                            StateProvinceCode = "",
                            PostalCode = "",
                            CountryCode = ""
                        },
                        ShipperNumber = ""
                    },
                    ShipTo = new ShipToType()
                    {
                        Name = "",
                        Address = new ShipToAddressType()
                        {
                            ResidentialAddressIndicator = "",
                            AddressLine = new string[] { },
                            City = "",
                            StateProvinceCode = "",
                            PostalCode = "",
                            CountryCode = ""
                        }
                    },
                    ShipFrom = new ShipFromType()
                    {
                        Name = "",
                        Address = new ShipAddressType()
                        {
                            AddressLine = new string[] { },
                            City = "",
                            StateProvinceCode = "",
                            PostalCode = "",
                            CountryCode = ""
                        }
                    },
                    AlternateDeliveryAddress = new AlternateDeliveryAddressType()
                    {
                        Name = "",
                        Address = new ADRType()
                        {
                            AddressLine = new string[] { },
                            City = "",
                            StateProvinceCode = "",
                            PostalCode = "",
                            CountryCode = "",
                            ResidentialAddressIndicator = "",
                            POBoxIndicator = ""
                        }
                    },
                    ShipmentIndicationType = new IndicationType[]
                    {
                        new IndicationType()
                        {
                            Code = "",
                            Description = ""
                        }
                    },
                    PaymentDetails = new PaymentDetailsType()
                    {
                        ShipmentCharge = new ShipmentChargeType[]
                        {
                            new ShipmentChargeType()
                            {
                                Type = "",
                                BillShipper = new BillShipperChargeType()
                                {
                                    AccountNumber = ""
                                },
                                BillReceiver = new BillReceiverChargeType()
                                {
                                    AccountNumber = "",
                                    Address = new BillReceiverAddressType()
                                    {
                                        PostalCode = ""
                                    }
                                },
                                BillThirdParty = new BillThirdPartyChargeType()
                                {
                                    AccountNumber = "",
                                    Address = new AddressType()
                                    {
                                        AddressLine = new string[] { },
                                        City = "",
                                        StateProvinceCode = "",
                                        PostalCode = "",
                                        CountryCode = ""
                                    }
                                },
                                ConsigneeBilledIndicator = ""
                            }
                        },
                        SplitDutyVATIndicator = ""
                    },
                    FRSPaymentInformation = new FRSPaymentInfoType()
                    {
                        Type = new CodeDescriptionType()
                        {
                            Code = "",
                            Description = ""
                        },
                        AccountNumber = "",
                        Address = new PayerAddressType()
                        {
                            PostalCode = "",
                            CountryCode = ""
                        }
                    },
                    FreightShipmentInformation = new FreightShipmentInformationType()
                    {
                        FreightDensityInfo = new FreightDensityInfoType()
                        {
                            AdjustedHeightIndicator = "",
                            AdjustedHeight = new AdjustedHeightType()
                            {
                                Value = "",
                                UnitOfMeasurement = new CodeDescriptionType()
                                {
                                    Code = "",
                                    Description = ""
                                }
                            },
                            HandlingUnits = new HandlingUnitsType[]
                            {
                                new HandlingUnitsType()
                                {
                                    Quantity = "",
                                    Type = new CodeDescriptionType()
                                    {
                                        Code = "",
                                        Description = ""
                                    },
                                    Dimensions = new HandlingUnitsDimensionsType()
                                    {
                                        UnitOfMeasurement = new CodeDescriptionType()
                                        {
                                            Code = "",
                                            Description = ""
                                        },
                                        Length = "",
                                        Height = "",
                                        Width = ""
                                    }
                                }
                            }
                        },
                        DensityEligibleIndicator = ""
                    },
                    GoodsNotInFreeCirculationIndicator = "",
                    Service = new CodeDescriptionType()
                    {
                        Code = "",
                        Description = ""
                    },
                    NumOfPieces = "",
                    ShipmentTotalWeight = new ShipmentWeightType()
                    {
                        UnitOfMeasurement = new CodeDescriptionType()
                        {
                            Code = "",
                            Description = ""
                        },
                        Weight = ""
                    },
                    DocumentsOnlyIndicator = "",
                    Package = new PackageType[]
                    {
                        new PackageType()
                        {
                            PackagingType = new CodeDescriptionType()
                            {
                                Code = "",
                                Description = ""
                            },
                            Dimensions = new DimensionsType()
                            {
                                UnitOfMeasurement = new CodeDescriptionType()
                                {
                                    Code = "",
                                    Description = ""
                                },
                                Length = "",
                                Width = "",
                                Height = ""
                            },
                            DimWeight = new PackageWeightType()
                            {
                                UnitOfMeasurement = new CodeDescriptionType()
                                {
                                    Code = "",
                                    Description = ""
                                },
                                Weight = ""
                            },
                            PackageWeight = new PackageWeightType()
                            {
                                UnitOfMeasurement = new CodeDescriptionType()
                                {
                                    Code = "",
                                    Description = ""
                                },
                                Weight = ""
                            },
                            Commodity = new CommodityType()
                            {
                                FreightClass = "",
                                NMFC = new NMFCCommodityType()
                                {
                                    PrimeCode = "",
                                    SubCode = ""
                                }
                            },
                            LargePackageIndicator = "",
                            PackageServiceOptions = new PackageServiceOptionsType()
                            {
                                DeliveryConfirmation = new DeliveryConfirmationType()
                                {
                                    DCISType = ""
                                },
                                AccessPointCOD = new PackageServiceOptionsAccessPointCODType()
                                {
                                    CurrencyCode = "",
                                    MonetaryValue = ""
                                },
                                COD = new CODType()
                                {
                                    CODAmount = new CODAmountType()
                                    {
                                        CurrencyCode = "",
                                        MonetaryValue = ""
                                    },
                                    CODFundsCode = ""
                                },
                                DeclaredValue = new InsuredValueType()
                                {
                                    CurrencyCode = "",
                                    MonetaryValue = ""
                                },
                                ShipperDeclaredValue = new ShipperDeclaredValueType()
                                {
                                    CurrencyCode = "",
                                    MonetaryValue = ""
                                },
                                ProactiveIndicator = "",
                                RefrigerationIndicator = "",
                                Insurance = new InsuranceType()
                                {
                                    BasicFlexibleParcelIndicator = new InsuranceValueType()
                                    {
                                        CurrencyCode = "",
                                        MonetaryValue = ""
                                    },
                                    ExtendedFlexibleParcelIndicator = new InsuranceValueType()
                                    {
                                        CurrencyCode = "",
                                        MonetaryValue = ""
                                    },
                                    TimeInTransitFlexibleParcelIndicator = new InsuranceValueType()
                                    {
                                        CurrencyCode = "",
                                        MonetaryValue = ""
                                    }
                                },
                                VerbalConfirmationIndicator = "",
                                UPSPremiumCareIndicator = "",
                                HazMat = new HazMatType()
                                {
                                    PackageIdentifier = "",
                                    QValue = "",
                                    OverPackedIndicator = "",
                                    AllPackedInOneIndicator = "",
                                    HazMatChemicalRecord = new HazMatChemicalRecordType[]
                                    {
                                        new HazMatChemicalRecordType()
                                        {
                                            ChemicalRecordIdentifier = "",
                                            ClassDivisionNumber = "",
                                            IDNumber = "",
                                            TransportationMode = "",
                                            RegulationSet = "",
                                            EmergencyPhone = "",
                                            EmergencyContact = "",
                                            ReportableQuantity = "",
                                            SubRiskClass = "",
                                            PackagingGroupType = "",
                                            Quantity = "",
                                            UOM = "",
                                            PackagingInstructionCode = "",
                                            ProperShippingName = "",
                                            TechnicalName = "",
                                            AdditionalDescription = "",
                                            PackagingType = "",
                                            HazardLabelRequired = "",
                                            PackagingTypeQuantity = "",
                                            CommodityRegulatedLevelCode = "",
                                            TransportCategory = "",
                                            TunnelRestrictionCode = "",
                                        }
                                    }
                                },
                                DryIce = new DryIceType()
                                {
                                    RegulationSet = "",
                                    DryIceWeight = new DryIceWeightType()
                                    {
                                        UnitOfMeasurement = new CodeDescriptionType()
                                        {
                                            Code = "",
                                            Description = ""
                                        },
                                        Weight = "",
                                    },
                                    MedicalUseIndicator = "",
                                    AuditRequired = ""
                                }
                            },
                            AdditionalHandlingIndicator = ""
                        }
                    },
                    ShipmentServiceOptions = new ShipmentServiceOptionsType()
                    {
                        SaturdayPickupIndicator = "",
                        SaturdayDeliveryIndicator = "",
                        AccessPointCOD = new ShipmentServiceOptionsAccessPointCODType()
                        {
                            CurrencyCode = "",
                            MonetaryValue = ""
                        },
                        DeliverToAddresseeOnlyIndicator = "",
                        DirectDeliveryOnlyIndicator = "",
                        COD = new CODType()
                        {
                            CODFundsCode = "",
                            CODAmount = new CODAmountType()
                            {
                                CurrencyCode = "",
                                MonetaryValue = ""
                            }
                        },
                        DeliveryConfirmation = new DeliveryConfirmationType()
                        {
                            DCISType = ""
                        },
                        ReturnOfDocumentIndicator = "",
                        UPScarbonneutralIndicator = "",
                        CertificateOfOriginIndicator = "",
                        PickupOptions = new PickupOptionsType()
                        {
                            LiftGateAtPickupIndicator = "",
                            HoldForPickupIndicator = ""
                        },
                        DeliveryOptions = new DeliveryOptionsType()
                        {
                            LiftGateAtDeliveryIndicator = "",
                            DropOffAtUPSFacilityIndicator = ""
                        },
                        RestrictedArticles = new RestrictedArticlesType()
                        {
                            AlcoholicBeveragesIndicator = "",
                            DiagnosticSpecimensIndicator = "",
                            PerishablesIndicator = "",
                            PlantsIndicator = "",
                            SeedsIndicator = "",
                            SpecialExceptionsIndicator = "",
                            TobaccoIndicator = ""
                        },
                        ShipperExportDeclarationIndicator = "",
                        CommercialInvoiceRemovalIndicator = "",
                        ImportControl = new ImportControlType()
                        {
                            Code = "",
                            Description = ""
                        },
                        ReturnService = new ReturnServiceType()
                        {
                            Code = "",
                            Description = ""
                        },
                        SDLShipmentIndicator = "",
                        EPRAIndicator = ""
                    },
                    ShipmentRatingOptions = new ShipmentRatingOptionsType()
                    {
                        NegotiatedRatesIndicator = "",
                        FRSShipmentIndicator = "",
                        RateChartIndicator = "",
                        UserLevelDiscountIndicator = ""
                    },
                    InvoiceLineTotal = new InvoiceLineTotalType()
                    {
                        CurrencyCode = "",
                        MonetaryValue = ""
                    },
                    RatingMethodRequestedIndicator = "",
                    TaxInformationIndicator = "",
                    PromotionalDiscountInformation = new PromotionalDiscountInformationType()
                    {
                        PromoCode = "",
                        PromoAliasCode = ""
                    },
                    DeliveryTimeInformation = new TimeInTransitRequestType()
                    {
                        PackageBillType = "",
                        Pickup = new PickupType()
                        {
                            Date = "",
                            Time = ""
                        }
                    }
                }
            };
            

            var response = client.ProcessRate(security, request);
        }
    }
}
