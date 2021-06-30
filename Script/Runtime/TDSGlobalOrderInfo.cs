
using System.Collections;
using System;
using System.Collections.Generic;
using TapTap.Common;
using UnityEngine;

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
            this.orderId = SafeDictionary.GetValue<string>(dic,"orderId");
            this.productId = SafeDictionary.GetValue<string>(dic,"productId");
            this.roleId = SafeDictionary.GetValue<string>(dic,"roleId");
            this.serverId = SafeDictionary.GetValue<string>(dic,"serverId");
            this.ext = SafeDictionary.GetValue<string>(dic,"ext");
            Debug.Log("Parse TDSGlobal OrderInfo finish:" + ToJSON());
        }

        public string ToJSON()
        {
            return JsonUtility.ToJson(this);
        }

    }
}