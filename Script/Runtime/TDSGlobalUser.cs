using System.Collections;
using System;
using System.Collections.Generic;
using UnityEngine;
using TDSCommon;

namespace TDSGlobal
{
    [Serializable]
    public class TDSGlobalUser
    {
        public int userId;

        public string sub;

        public string name;

        public TDSGlobalAccessToken token;

        public TDSGlobalUser(string json)
        {
            Dictionary<string,object> dic = Json.Deserialize(json) as Dictionary<string,object>;
            this.userId = int.Parse(SafeDictionary.SafeGetValueByKey(dic,"userId").ToString());
            this.sub = SafeDictionary.SafeGetValueByKey(dic,"sub") as string;
            this.name = SafeDictionary.SafeGetValueByKey(dic,"name") as string;
            this.token  = new TDSGlobalAccessToken(SafeDictionary.SafeGetValueByKey(dic,"token") as Dictionary<string,object>);
        }

        public TDSGlobalUser(Dictionary<string,object> dic)
        {   
            this.userId = int.Parse(SafeDictionary.SafeGetValueByKey(dic,"userId").ToString());
            this.sub = SafeDictionary.SafeGetValueByKey(dic,"sub") as string;
            this.name = SafeDictionary.SafeGetValueByKey(dic,"name") as string;
            this.token  = new TDSGlobalAccessToken(SafeDictionary.SafeGetValueByKey(dic,"token") as Dictionary<string,object>);
        }

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
            
        public TDSGlobalAccessToken(Dictionary<string,object> dic)
        {   
            this.accessToken = SafeDictionary.SafeGetValueByKey(dic,"accessToken") as string;
            this.kid = SafeDictionary.SafeGetValueByKey(dic,"kid") as string;
            this.macKey = SafeDictionary.SafeGetValueByKey(dic,"macKey") as string;
            this.macAlgorithm = SafeDictionary.SafeGetValueByKey(dic,"macAlgorithm") as string;
            this.tokenType = SafeDictionary.SafeGetValueByKey(dic,"tokenType") as string;
        }
    }
}