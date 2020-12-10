using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

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
    }

    #endif

}