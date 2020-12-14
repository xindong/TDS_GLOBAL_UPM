using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TDSCommon;

namespace TDSGlobal
{
    [Serializable]
    public class TDSGlobalInitWrapper
    {
        public bool success;

        public TDSGlobalInitWrapper(string json)
        {
            Dictionary<string,object> dic = Json.Deserialize(json) as Dictionary<string,object>;
            this.success = (bool)dic["success"];
        }
    }

    [Serializable]
    public class TDSGlobalUserWrapper
    {
        public TDSGlobalUser user;

        public TDSGlobalError error;

        public TDSGlobalUserWrapper(string json)
        {
            Dictionary<string,object> dic = Json.Deserialize(json) as Dictionary<string,object>;
            Dictionary<string,object> userDic =(Dictionary<string,object>) SafeDictionary.SafeGetValueByKey(dic,"user");
            Dictionary<string,object> errorDic = (Dictionary<string,object> ) SafeDictionary.SafeGetValueByKey(dic,"error");
            if(userDic !=null)
            {
                this.user = new TDSGlobalUser(userDic);
            }
            if(errorDic!=null)
            {
                this.error = new TDSGlobalError(errorDic);
            }
        }

        public string ToJSON()
        {
            return JsonUtility.ToJson(this);
        }
    }

    [Serializable]
    public class TDSGlobalShareWrapper
    {
        public bool cancel;

        public TDSGlobalError error;

        public TDSGlobalShareWrapper(string json)
        {
            Dictionary<string,object> dic = Json.Deserialize(json) as Dictionary<string,object>;
            this.cancel = (bool) SafeDictionary.SafeGetValueByKey(dic,"cancel");
            Dictionary<string,object> errorDic = SafeDictionary.SafeGetValueByKey(dic,"error") as Dictionary<string,object>;
            if(errorDic!=null)
            {
                this.error = new TDSGlobalError(errorDic);
            }
        }
    
        public string ToJSON(){
            return JsonUtility.ToJson(this);
        }
    
    }

    [Serializable]
    public class TDSGlobalUserStatusChangeWrapper
    {
        public int code;

        public TDSGlobalUserStatusChangeWrapper(string json)
        {
            Dictionary<string,object> dic = Json.Deserialize(json) as Dictionary<string,object>;
            this.code =int.Parse(SafeDictionary.SafeGetValueByKey(dic,"code").ToString());
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
            Dictionary<string,object> dic = Json.Deserialize(json) as Dictionary<string,object>;
            Dictionary<string,object> orderInfoDic = SafeDictionary.SafeGetValueByKey(dic,"orderInfo") as Dictionary<string,object>;
            Dictionary<string,object> errorDic = SafeDictionary.SafeGetValueByKey(dic,"error") as Dictionary<string,object>;
            if(orderInfoDic != null)
            {
                this.orderInfo = new TDSGlobalOrderInfo(orderInfoDic);
            }
            if(errorDic != null)
            {
                this.error = new TDSGlobalError(errorDic);
            }
        }
    }

    [Serializable]
    public class TDSGlobalRestoredPurchasesWrapper
    {

        public List<TDSGlobalRestoredPurchases> transactions;

        public TDSGlobalRestoredPurchasesWrapper(string json)
        {
            Dictionary<string,object> dic = Json.Deserialize(json) as Dictionary<string,object>;
            List<object> list = SafeDictionary.SafeGetValueByKey(dic,"transactions") as List<object>;
            if(list == null)
            {
                return;
            }
            this.transactions = new List<TDSGlobalRestoredPurchases>();
            foreach (var obj in list)
            {
                Dictionary<string,object> innerDic = obj as Dictionary<string,object>;
                TDSGlobalRestoredPurchases restorePurchases = new TDSGlobalRestoredPurchases(innerDic);
                this.transactions.Add(restorePurchases);   
            }
        }
        
    }

    [Serializable]
    public class TDSGlobalSkuDetailWrapper
    {

        public List<TDSGlobalSkuDetail> products;

        public TDSGlobalError error;

        public TDSGlobalSkuDetailWrapper(string json)
        {
            Dictionary<string,object> dic = Json.Deserialize(json) as Dictionary<string,object>;
            Dictionary<string,object> errorDic = SafeDictionary.SafeGetValueByKey(dic,"error") as Dictionary<string,object>;
            List<object> list = SafeDictionary.SafeGetValueByKey(dic,"products") as List<object>;
            if(errorDic!=null)
            {
                this.error = new TDSGlobalError(errorDic);
            }
            if(list !=null)
            {
                this.products = new List<TDSGlobalSkuDetail>();
                foreach(var skuDetail in list)
                {
                    Dictionary<string,object> innerDic = skuDetail as Dictionary<string,object>;
                    TDSGlobalSkuDetail detail = new TDSGlobalSkuDetail(innerDic);
                    products.Add(detail);
                }
            }
        }

    }

}