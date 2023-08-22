using System.Collections;
using System;
using System.Collections.Generic;
using UnityEngine;
using TDSCommon;

namespace TDSGlobal
{
#if UNITY_IOS
    [Serializable]
    public class TDSGlobalSkuDetail
    {
        public string localizedDescription;

        public string localizedTitle;

        public double price;

        public string productIdentifier;

        public string localeIdentifier;

        public PriceLocale priceLocale;

        public TDSGlobalSkuDetail(string json)
        {
            Dictionary<string,object> dic = Json.Deserialize(json) as Dictionary<string,object>;
            this.localeIdentifier = SafeDictionary.GetValue<string>(dic,"localeIdentifier");
            this.localizedTitle = SafeDictionary.GetValue<string>(dic,"localizedTitle") ;
            this.price = SafeDictionary.GetValue<double>(dic, "price");
            this.productIdentifier = SafeDictionary.GetValue<string>(dic,"productIdentifier");
            Dictionary<string,object> priceLocaleDic = SafeDictionary.GetValue<Dictionary<string,object>>(dic,"priceLocale") as Dictionary<string,object>;
            this.priceLocale = new PriceLocale(priceLocaleDic);
        }

        public TDSGlobalSkuDetail(Dictionary<string,object> dic)
        {
            this.localeIdentifier = SafeDictionary.GetValue<string>(dic,"localeIdentifier");
            this.localizedTitle = SafeDictionary.GetValue<string>(dic,"localizedTitle") ;
            this.price =SafeDictionary.GetValue<double>(dic,"price");
            this.productIdentifier = SafeDictionary.GetValue<string>(dic,"productIdentifier");
            Dictionary<string,object> priceLocaleDic = SafeDictionary.GetValue<Dictionary<string,object>>(dic,"priceLocale") as Dictionary<string,object>;
            this.priceLocale = new PriceLocale(priceLocaleDic);
        }

        public TDSGlobalSkuDetail()
        {

        }

        public string ToJSON(){
            return JsonUtility.ToJson(this);
        }
        

    }
    [Serializable]
    public class PriceLocale
    {
        public string localeIdentifier;

        public string languageCode;

        public string countryCode;

        public string scriptCode;

        public string calendarIdentifier;

        public string decimalSeparator;

        public string currencySymbol;

        public PriceLocale(Dictionary<string,object> dic)
        {
            this.localeIdentifier = SafeDictionary.GetValue<string>(dic,"localeIdentifier");
            this.languageCode = SafeDictionary.GetValue<string>(dic,"languageCode");
            this.countryCode = SafeDictionary.GetValue<string>(dic,"countryCode");
            this.scriptCode = SafeDictionary.GetValue<string>(dic,"scriptCode");
            this.calendarIdentifier = SafeDictionary.GetValue<string>(dic,"calendarIdentifier");
            this.decimalSeparator = SafeDictionary.GetValue<string>(dic,"decimalSeparator");
            this.currencySymbol = SafeDictionary.GetValue<string>(dic,"currencySymbol");
        }
    }

#elif UNITY_ANDROID

    [Serializable]
    public class TDSGlobalSkuDetail
    {
        private string _originString;
        public string description;
        public string name;
        public string productId;
        public string productType;
        public string title;
        public GoogleOneTimePurchaseOfferDetails googleOneTimePurchaseOfferDetails;

        public override string ToString()
        {
            return _originString;
        }

        public TDSGlobalSkuDetail(Dictionary<string,object> dic)
        {
            if (dic == null) return;
            _originString = SafeDictionary.GetValue<string>(dic, "originString");
            description = SafeDictionary.GetValue<string>(dic, "description");
            name = SafeDictionary.GetValue<string>(dic, "name");
            productId = SafeDictionary.GetValue<string>(dic, "productId");
            productType = SafeDictionary.GetValue<string>(dic, "productType");
            title = SafeDictionary.GetValue<string>(dic, "title");
            googleOneTimePurchaseOfferDetails = new GoogleOneTimePurchaseOfferDetails(SafeDictionary.GetValue<Dictionary<string, object>>(dic, "googleOneTimePurchaseOfferDetails"));
        }


        public string ToJSON(){
            return JsonUtility.ToJson(this);
        }

    }
    
        [Serializable]
        public class GoogleOneTimePurchaseOfferDetails
        {
            public string formattedPrice;
            public long priceAmountMicros;
            public string priceCurrencyCode;

            public GoogleOneTimePurchaseOfferDetails(Dictionary<string, object> dic)
            {
                formattedPrice = SafeDictionary.GetValue<string>(dic, "formattedPrice");
                priceAmountMicros = SafeDictionary.GetValue<long>(dic, "priceAmountMicros");
                priceCurrencyCode = SafeDictionary.GetValue<string>(dic, "priceCurrencyCode");
            }
        }
#elif UNITY_EDITOR
     public class TDSGlobalSkuDetail
     {
         public TDSGlobalSkuDetail(Dictionary<string,object> dic)
         {
            
         }

         public string ToJSON(){
            return JsonUtility.ToJson(this);
        }
     }
#endif

}