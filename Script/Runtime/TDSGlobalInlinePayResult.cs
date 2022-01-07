using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TDSCommon;

namespace TDSGlobal
{
    public class TDSGlobalInlinePayResult
    {
        public int code = -1;
        public string message = "";
        
        public TDSGlobalInlinePayResult(string jsonStr)
        {
            var dic = Json.Deserialize(jsonStr) as Dictionary<string,object>;
            if (dic != null)
            {
                code = SafeDictionary.GetValue<int>(dic, "code");
                message = SafeDictionary.GetValue<string>(dic, "message");
            }
        }

        public TDSGlobalInlinePayResult(int code, string message)
        {
            this.code = code;
            this.message = message;
        }
    }
}