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

        public float price;

        public string productIdentifier;

        public string localeIdentifier;

        public PriceLocale priceLocale;

        public TDSGlobalSkuDetail(string json)
        {
            Dictionary<string,object> dic = Json.Deserialize(json) as Dictionary<string,object>;
            this.localeIdentifier = SafeDictionary.GetValue<string>(dic,"localeIdentifier");
            this.localizedTitle = SafeDictionary.GetValue<string>(dic,"localizedTitle") ;
            this.price = float.Parse(SafeDictionary.GetValue<string>(dic,"price"));
            this.productIdentifier = SafeDictionary.GetValue<string>(dic,"productIdentifier");
            Dictionary<string,object> priceLocaleDic = SafeDictionary.GetValue<Dictionary<string,object>>(dic,"priceLocale") as Dictionary<string,object>;
            this.priceLocale = new PriceLocale(priceLocaleDic);
        }

        public TDSGlobalSkuDetail(Dictionary<string,object> dic)
        {
            this.localeIdentifier = SafeDictionary.GetValue<string>(dic,"localeIdentifier");
            this.localizedTitle = SafeDictionary.GetValue<string>(dic,"localizedTitle") ;
            this.price = float.Parse(SafeDictionary.GetValue<string>(dic,"price"));
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
        public string description;

        public string freeTrialPeriod;

        public string iconUrl;

        public string introductoryPrice;

        public long introductoryPriceAmountMicros;

        public int introductoryPriceCycles;

        public string originJson;

        public string originPrice;

        public long originPriceAmountMicors;

        public string price;

        public long priceAmountMicros;

        public string priceCurrencyCode;

        public string productId;

        public string subscriptionPeroid;

        public string title;

        public string type;

        public TDSGlobalSkuDetail(Dictionary<string,object> dic)
        {
            this.description = SafeDictionary.GetValue<string>(dic,"description");
            this.freeTrialPeriod = SafeDictionary.GetValue<string>(dic,"freeTrialPeriod");
            this.iconUrl = SafeDictionary.GetValue<string>(dic,"iconUrl");
            this.introductoryPrice = SafeDictionary.GetValue<string>(dic,"introductoryPrice");
            this.introductoryPriceAmountMicros =SafeDictionary.GetValue<long>(dic,"introductoryPriceAmountMicros");
            this.introductoryPriceCycles = SafeDictionary.GetValue<int>(dic,"introductoryPriceCycles");
            this.originJson = SafeDictionary.GetValue<string>(dic,"originJson");
            this.originPrice = SafeDictionary.GetValue<string>(dic,"originPrice");
            this.originPriceAmountMicors = SafeDictionary.GetValue<long>(dic,"originPriceAmountMicors");
            this.price = SafeDictionary.GetValue<string>(dic,"price");
            this.priceAmountMicros = SafeDictionary.GetValue<long>(dic,"priceAmountMicros");
            this.priceCurrencyCode = SafeDictionary.GetValue<string>(dic,"priceCurrencyCode");
            this.productId = SafeDictionary.GetValue<string>(dic,"productId");
            this.subscriptionPeroid = SafeDictionary.GetValue<string>(dic,"subscriptionPeroid");
            this.title = SafeDictionary.GetValue<string>(dic,"title");
            this.type = SafeDictionary.GetValue<string>(dic,"type");
        }


        public string ToJSON(){
            return JsonUtility.ToJson(this);
        }

    }
#elif UNITY_EDITOR
     public class TDSGlobalSkuDetail
     {
         public TDSGlobalSkuDetail(Dictionary<string,object> dic)
         {
             
         }
     }
#endif

}