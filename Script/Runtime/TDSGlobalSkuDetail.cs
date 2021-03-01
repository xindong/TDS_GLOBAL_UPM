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
            this.localeIdentifier = SafeDictionary.GetValue<string>(dic,"localeIdentifier") as string;
            this.localizedTitle = SafeDictionary.GetValue<string>(dic,"localizedTitle") as string ;
            this.price = float.Parse(SafeDictionary.GetValue<string>(dic,"price")as string);
            this.productIdentifier = SafeDictionary.GetValue<string>(dic,"productIdentifier") as string;
            Dictionary<string,object> priceLocaleDic = SafeDictionary.GetValue<Dictionary<string,object>>(dic,"priceLocale") as Dictionary<string,object>;
            this.priceLocale = new PriceLocale(priceLocaleDic);
        }

        public TDSGlobalSkuDetail(Dictionary<string,object> dic)
        {
            this.localeIdentifier = SafeDictionary.GetValue<string>(dic,"localeIdentifier") as string;
            this.localizedTitle = SafeDictionary.GetValue<string>(dic,"localizedTitle") as string ;
            this.price = float.Parse(SafeDictionary.GetValue<string>(dic,"price")as string);
            this.productIdentifier = SafeDictionary.GetValue<string>(dic,"productIdentifier") as string;
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
            this.localeIdentifier = SafeDictionary.GetValue<string>(dic,"localeIdentifier") as string;
            this.languageCode = SafeDictionary.GetValue<string>(dic,"languageCode") as string;
            this.countryCode = SafeDictionary.GetValue<string>(dic,"countryCode") as string;
            this.scriptCode = SafeDictionary.GetValue<string>(dic,"scriptCode") as string;
            this.calendarIdentifier = SafeDictionary.GetValue<string>(dic,"calendarIdentifier") as string;
            this.decimalSeparator = SafeDictionary.GetValue<string>(dic,"decimalSeparator") as string;
            this.currencySymbol = SafeDictionary.GetValue<string>(dic,"currencySymbol") as string;
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
            this.description = SafeDictionary.GetValue<string>(dic,"description") as string;
            this.freeTrialPeriod = SafeDictionary.GetValue<string>(dic,"freeTrialPeriod") as string;
            this.iconUrl = SafeDictionary.GetValue<string>(dic,"iconUrl") as string;
            this.introductoryPrice = SafeDictionary.GetValue<string>(dic,"introductoryPrice") as string;
            this.introductoryPriceAmountMicros =long.Parse(SafeDictionary.GetValue<string>(dic,"introductoryPriceAmountMicros")as string);
            this.introductoryPriceCycles = int.Parse(SafeDictionary.GetValue<string>(dic,"introductoryPriceCycles")as string);
            this.originJson = SafeDictionary.GetValue<string>(dic,"originJson") as string;
            this.originPrice = SafeDictionary.GetValue<string>(dic,"originPrice") as string;
            this.originPriceAmountMicors = long.Parse(SafeDictionary.GetValue<string>(dic,"originPriceAmountMicors")as string );
            this.price = SafeDictionary.GetValue<string>(dic,"price") as string;
            this.priceAmountMicros = long.Parse(SafeDictionary.GetValue<string>(dic,"priceAmountMicros") as string);
            this.priceCurrencyCode = SafeDictionary.GetValue<string>(dic,"priceCurrencyCode") as string;
            this.productId = SafeDictionary.GetValue<string>(dic,"productId") as string;
            this.subscriptionPeroid = SafeDictionary.GetValue<string>(dic,"subscriptionPeroid") as string;
            this.title = SafeDictionary.GetValue<string>(dic,"title") as string;
            this.type = SafeDictionary.GetValue<string>(dic,"type") as string;
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