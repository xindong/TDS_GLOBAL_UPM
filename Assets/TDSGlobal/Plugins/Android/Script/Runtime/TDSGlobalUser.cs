using System.Collections;
using System;
using System.Collections.Generic;
using UnityEngine;

namespace TDSGlobal
{
    [Serializable]
    public class TDSGlobalUser
    {
        public string userId;

        public string sub;

        public string name;

        public TDSGlobalAccessToken token;
    
        public string ToJSON(){
            return JsonUtility.ToJson(this);
        }
    }

    [Serializable]
    public class TDSGlobalAccessToken
    {

        public string accessToken;

        public string kid;

        public string macKey;

        public string macAlgorithm;

        public string tokenType;
            
    }
}