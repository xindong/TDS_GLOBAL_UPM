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
            this.localeIdentifier = SafeDictionary.SafeGetValueByKey(dic,"localeIdentifier") as string;
            this.localizedTitle = SafeDictionary.SafeGetValueByKey(dic,"localizedTitle") as string ;
            this.price = float.Parse(SafeDictionary.SafeGetValueByKey(dic,"price")as string);
            this.productIdentifier = SafeDictionary.SafeGetValueByKey(dic,"productIdentifier") as string;
            Dictionary<string,object> priceLocaleDic = SafeDictionary.SafeGetValueByKey(dic,"priceLocale") as Dictionary<string,object>;
            this.priceLocale = new PriceLocale(priceLocaleDic);
        }

        public TDSGlobalSkuDetail(Dictionary<string,object> dic)
        {
            this.localeIdentifier = SafeDictionary.SafeGetValueByKey(dic,"localeIdentifier") as string;
            this.localizedTitle = SafeDictionary.SafeGetValueByKey(dic,"localizedTitle") as string ;
            this.price = float.Parse(SafeDictionary.SafeGetValueByKey(dic,"price")as string);
            this.productIdentifier = SafeDictionary.SafeGetValueByKey(dic,"productIdentifier") as string;
            Dictionary<string,object> priceLocaleDic = SafeDictionary.SafeGetValueByKey(dic,"priceLocale") as Dictionary<string,object>;
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
            this.localeIdentifier = SafeDictionary.SafeGetValueByKey(dic,"localeIdentifier") as string;
            this.languageCode = SafeDictionary.SafeGetValueByKey(dic,"languageCode") as string;
            this.countryCode = SafeDictionary.SafeGetValueByKey(dic,"countryCode") as string;
            this.scriptCode = SafeDictionary.SafeGetValueByKey(dic,"scriptCode") as string;
            this.calendarIdentifier = SafeDictionary.SafeGetValueByKey(dic,"calendarIdentifier") as string;
            this.decimalSeparator = SafeDictionary.SafeGetValueByKey(dic,"decimalSeparator") as string;
            this.currencySymbol = SafeDictionary.SafeGetValueByKey(dic,"currencySymbol") as string;
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
            this.description = SafeDictionary.SafeGetValueByKey(dic,"description") as string;
            this.freeTrialPeriod = SafeDictionary.SafeGetValueByKey(dic,"freeTrialPeriod") as string;
            this.iconUrl = SafeDictionary.SafeGetValueByKey(dic,"iconUrl") as string;
            this.introductoryPrice = SafeDictionary.SafeGetValueByKey(dic,"introductoryPrice") as string;
            this.introductoryPriceAmountMicros =long.Parse(SafeDictionary.SafeGetValueByKey(dic,"introductoryPriceAmountMicros")as string);
            this.introductoryPriceCycles = int.Parse(SafeDictionary.SafeGetValueByKey(dic,"introductoryPriceCycles")as string);
            this.originJson = SafeDictionary.SafeGetValueByKey(dic,"originJson") as string;
            this.originPrice = SafeDictionary.SafeGetValueByKey(dic,"originPrice") as string;
            this.originPriceAmountMicors = long.Parse(SafeDictionary.SafeGetValueByKey(dic,"originPriceAmountMicors")as string );
            this.price = SafeDictionary.SafeGetValueByKey(dic,"price") as string;
            this.priceAmountMicros = long.Parse(SafeDictionary.SafeGetValueByKey(dic,"priceAmountMicros") as string);
            this.priceCurrencyCode = SafeDictionary.SafeGetValueByKey(dic,"priceCurrencyCode") as string;
            this.productId = SafeDictionary.SafeGetValueByKey(dic,"productId") as string;
            this.subscriptionPeroid = SafeDictionary.SafeGetValueByKey(dic,"subscriptionPeroid") as string;
            this.title = SafeDictionary.SafeGetValueByKey(dic,"title") as string;
            this.type = SafeDictionary.SafeGetValueByKey(dic,"type") as string;
        }


        public string ToJSON(){
            return JsonUtility.ToJson(this);
        }

    }
#endif

     public class TDSGlobalSkuDetail
     {
         public TDSGlobalSkuDetail(Dictionary<string,object> dic)
         {
             
         }
     }

}