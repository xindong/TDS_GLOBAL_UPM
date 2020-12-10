
using System.Collections;
using System;
using System.Collections.Generic;
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

        public string ToJSON()
        {
            return JsonUtility.ToJson(this);
        }

    }
}