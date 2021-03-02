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
            Dictionary<string,object> userDic = SafeDictionary.GetValue<Dictionary<string,object>>(dic,"user");
            Dictionary<string,object> errorDic = SafeDictionary.GetValue<Dictionary<string,object>>(dic,"error");
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
            this.cancel = (bool) SafeDictionary.GetValue<bool>(dic,"cancel");
            Dictionary<string,object> errorDic = SafeDictionary.GetValue<Dictionary<string,object>>(dic,"error");
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
            this.code = SafeDictionary.GetValue<int>(dic,"code");
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
            Debug.Log("TDSGlobalOrderInfoWrapper json:" + json);
            Dictionary<string,object> dic = Json.Deserialize(json) as Dictionary<string,object>;
            Dictionary<string,object> orderInfoDic = SafeDictionary.GetValue<Dictionary<string,object>>(dic,"orderInfo");
            Dictionary<string,object> errorDic = SafeDictionary.GetValue<Dictionary<string,object>>(dic,"error");
            Debug.Log("TDSGlobalOrderInfoWrapper parse after orderInfoDic json:" + orderInfoDic);
            Debug.Log("TDSGlobalOrderInfoWrapper parse after errorDic json:" + errorDic);

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
            List<object> list = SafeDictionary.GetValue<List<object>>(dic,"transactions");
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
            Dictionary<string,object> errorDic = SafeDictionary.GetValue<Dictionary<string,object>>(dic,"error");
            List<object> list = SafeDictionary.GetValue<List<object>>(dic,"products");
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