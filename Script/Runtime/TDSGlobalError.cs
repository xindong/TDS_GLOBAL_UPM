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
            this.error_msg = SafeDictionary.GetValue<string>(dic,"error_msg") as string;
            this.code  = SafeDictionary.GetValue<int>(dic,"code");
        }


        public TDSGlobalError(Dictionary<string,object> dic)
        {
            this.error_msg = SafeDictionary.GetValue<string>(dic,"error_msg") as string;
            this.code = SafeDictionary.GetValue<int>(dic,"code");
        }

        public TDSGlobalError(int code,string error_msg)
        {
            this.code = code;
            this.error_msg = error_msg;
        }

        public string ToJSON(){
            return JsonUtility.ToJson(this);
        }
        
    }
}