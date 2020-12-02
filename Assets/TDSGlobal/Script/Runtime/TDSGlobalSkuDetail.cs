using System.Collections;
using System;
using System.Collections.Generic;
using UnityEngine;

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

        public PriceLocale priceLocale;

        public TDSGlobalSkuDetail(string json)
        {
            JsonUtility.FromJsonOverwrite(json, this);
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

        public string ToJSON(){
            return JsonUtility.ToJson(this);
        }

    }
#endif
}