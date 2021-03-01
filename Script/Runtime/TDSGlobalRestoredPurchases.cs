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
            this.transactionIdentifier = SafeDictionary.GetValue<string>(dic,"transactionIdentifier") as string;
            this.productIdentifier = SafeDictionary.GetValue<string>(dic,"productIdentifier") as string;
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
            this.orderId = SafeDictionary.GetValue<string>(dic,"orderId") as string;
            this.packageName = SafeDictionary.GetValue<string>(dic,"packageName") as string;
            this.productId = SafeDictionary.GetValue<string>(dic,"productId") as string;
            this.purchaseTime = long.Parse(SafeDictionary.GetValue<string>(dic,"purchaseTime") as string);
            this.purchaseToken = SafeDictionary.GetValue<string>(dic,"purchaseToken") as string;
            this.purchaseState = int.Parse(SafeDictionary.GetValue<string>(dic,"purchaseState") as string);
            this.developerPayload = SafeDictionary.GetValue<string>(dic,"developerPayload") as string;
            this.acknowledged = SafeDictionary.GetValue<bool>(dic,"acknowledged");
            this.autoRenewing = SafeDictionary.GetValue<bool>(dic,"autoRenewing");
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