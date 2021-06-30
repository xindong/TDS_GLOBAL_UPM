using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TapTap.Common;

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
            this.transactionIdentifier = SafeDictionary.GetValue<string>(dic,"transactionIdentifier") ;
            this.productIdentifier = SafeDictionary.GetValue<string>(dic,"productIdentifier") ;
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
            this.orderId = SafeDictionary.GetValue<string>(dic,"orderId") ;
            this.packageName = SafeDictionary.GetValue<string>(dic,"packageName") ;
            this.productId = SafeDictionary.GetValue<string>(dic,"productId") ;
            this.purchaseTime = SafeDictionary.GetValue<long>(dic,"purchaseTime") ;
            this.purchaseToken = SafeDictionary.GetValue<string>(dic,"purchaseToken") ;
            this.purchaseState = SafeDictionary.GetValue<int>(dic,"purchaseState");
            this.developerPayload = SafeDictionary.GetValue<string>(dic,"developerPayload") ;
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