
using System.Collections;
using System;
using System.Collections.Generic;
using UnityEngine;
using TDSCommon;

namespace TDSGlobal
{
    public class TDSGlobalOrderInfo
    {
        public string orderId;

        public string productId;

        public string roleId;

        public string serverId;

        public string ext;

        public TDSGlobalOrderInfo(string json)
        {
            JsonUtility.FromJsonOverwrite(json, this);
        }

        public TDSGlobalOrderInfo(Dictionary<string,object> dic)
        {
            this.orderId = SafeDictionary.SafeGetValueByKey(dic,"orderId") as string;
            this.productId = SafeDictionary.SafeGetValueByKey(dic,"productId") as string;
            this.roleId = SafeDictionary.SafeGetValueByKey(dic,"roleId") as string;
            this.serverId = SafeDictionary.SafeGetValueByKey(dic,"serverId") as string;
            this.ext = SafeDictionary.SafeGetValueByKey(dic,"ext") as string;
        }

        public string ToJSON()
        {
            return JsonUtility.ToJson(this);
        }

    }
}