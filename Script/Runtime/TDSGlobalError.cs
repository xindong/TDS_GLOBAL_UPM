using System.Collections;
using System;
using System.Collections.Generic;
using UnityEngine;
using TDSCommon;

namespace TDSGlobal
{
    [Serializable]
    public class TDSGlobalError
    {
        public string error_msg;

        public int code;

        public TDSGlobalError(string json)
        {
            Dictionary<string,object> dic = Json.Deserialize(json) as Dictionary<string,object>;
            this.error_msg = SafeDictionary.SafeGetValueByKey(dic,"error_msg") as string;
            this.code = int.Parse(SafeDictionary.SafeGetValueByKey(dic,"code").ToString());
        }


        public TDSGlobalError(Dictionary<string,object> dic)
        {
            this.error_msg = SafeDictionary.SafeGetValueByKey(dic,"error_msg") as string;
            this.code = int.Parse(SafeDictionary.SafeGetValueByKey(dic,"code").ToString());
        }

        public string ToJSON(){
            return JsonUtility.ToJson(this);
        }
        
    }
}