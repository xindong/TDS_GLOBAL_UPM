using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TDSCommon;

namespace TDSGlobal
{
#if UNITY_IOS
    [Serializable]
    public class TDSGlobalRestoredPurchases
    {
        public string transactionIdentifier;

        public string productIdentifier;

        public TDSGlobalRestoredPurchases(string json)
        {
            JsonUtility.FromJsonOverwrite(json, this);
        }

        public TDSGlobalRestoredPurchases(Dictionary<string,object> dic)
        {
            this.transactionIdentifier = SafeDictionary.SafeGetValueByKey(dic,"transactionIdentifier") as string;
            this.productIdentifier = SafeDictionary.SafeGetValueByKey(dic,"productIdentifier") as string;
        }
    }

#elif UNITY_ANDROID
    [Serializable]
    public class TDSGlobalRestoredPurchases
    {
        public string orderId;

        public string packageName;

        public string productId;

        public long purchaseTime;

        public string purchaseToken;

        public int purchaseState;

        public string developerPayload;

        public bool acknowledged;

        public bool autoRenewing;

        public TDSGlobalRestoredPurchases(string json)
        {
            JsonUtility.FromJsonOverwrite(json,this);
        }

        public TDSGlobalRestoredPurchases(Dictionary<string,object> dic)
        {
            this.orderId = SafeDictionary.SafeGetValueByKey(dic,"orderId") as string;
            this.packageName = SafeDictionary.SafeGetValueByKey(dic,"packageName") as string;
            this.productId = SafeDictionary.SafeGetValueByKey(dic,"productId") as string;
            this.purchaseTime = long.Parse(SafeDictionary.SafeGetValueByKey(dic,"purchaseTime") as string);
            this.purchaseToken = SafeDictionary.SafeGetValueByKey(dic,"purchaseToken") as string;
            this.purchaseState = int.Parse(SafeDictionary.SafeGetValueByKey(dic,"purchaseState") as string);
            this.developerPayload = SafeDictionary.SafeGetValueByKey(dic,"developerPayload") as string;
            this.acknowledged = (bool)SafeDictionary.SafeGetValueByKey(dic,"acknowledged");
            this.autoRenewing = (bool)SafeDictionary.SafeGetValueByKey(dic,"autoRenewing");
        }
    }

#elif UNITY_EDITOR
    public class TDSGlobalRestoredPurchases
    {
        public TDSGlobalRestoredPurchases(Dictionary<string,object> dic)
        {

        }

        public TDSGlobalRestoredPurchases(string json)
        {
            
        }
    }
#endif
}