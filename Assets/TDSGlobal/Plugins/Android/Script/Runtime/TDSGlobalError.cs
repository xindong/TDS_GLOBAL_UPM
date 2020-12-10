using System.Collections;
using System;
using System.Collections.Generic;
using UnityEngine;

namespace TDSGlobal
{
    [Serializable]
    public class TDSGlobalError
    {
        public string error_msg;

        public int code;

        public TDSGlobalError(string json)
        {
            JsonUtility.FromJsonOverwrite(json, this);
        }

        public string ToJSON(){
            return JsonUtility.ToJson(this);
        }
        
    }
}