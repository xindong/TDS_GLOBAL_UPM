using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace TDSGlobal
{
    [Serializable]
    public class TDSGlobalInitWrapper
    {
        public bool success;

        public TDSGlobalInitWrapper(string json)
        {
            JsonUtility.FromJsonOverwrite(json, this);
        }

    }

    [Serializable]
    public class TDSGlobalUserWrapper
    {
        public TDSGlobalUser user;

        public TDSGlobalError error;

        public TDSGlobalUserWrapper(string json)
        {
            JsonUtility.FromJsonOverwrite(json, this);
        }

    }

    [Serializable]
    public class TDSGlobalShareWrapper
    {
        public bool cancel;

        public TDSGlobalError shareError;

        public TDSGlobalShareWrapper(string json)
        {
            JsonUtility.FromJsonOverwrite(json, this);
        }
    }

    [Serializable]
    public class TDSGlobalUserStatusChangeWrapper
    {
        public int code;

        public TDSGlobalUserStatusChangeWrapper(string json)
        {
            JsonUtility.FromJsonOverwrite(json, this);
        }
    }

    public class TDSGlobalPaymentResult
    {

    }

    [Serializable]
    public class TDSGlobalOrderInfoWrapper
    {
        public TDSGlobalOrderInfo orderInfo;

        public TDSGlobalError error;
    
        public TDSGlobalOrderInfoWrapper(string json)
        {
            JsonUtility.FromJsonOverwrite(json,this);
        }
    }

    [Serializable]
    public class TDSGlobalRestoredPurchasesWrapper
    {

        public List<TDSGlobalRestoredPurchases> transactions;

        public TDSGlobalRestoredPurchasesWrapper(string json)
        {
            JsonUtility.FromJsonOverwrite(json,this);
        }
        
    }

    [Serializable]
    public class TDSGlobalSkuDetailWrapper
    {

        public List<TDSGlobalSkuDetail> products;

        public TDSGlobalError error;

        public TDSGlobalSkuDetailWrapper(string json)
        {
            JsonUtility.FromJsonOverwrite(json, this);
        }
    }

}