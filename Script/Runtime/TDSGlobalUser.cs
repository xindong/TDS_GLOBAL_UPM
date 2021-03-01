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
            this.userId = SafeDictionary.GetValue<int>(dic,"userId");
            this.sub = SafeDictionary.GetValue<string>(dic,"sub");
            this.name = SafeDictionary.GetValue<string>(dic,"name");
            this.token  = new TDSGlobalAccessToken(SafeDictionary.GetValue<Dictionary<string,object>>(dic,"token") as Dictionary<string,object>);
        }

        public TDSGlobalUser(Dictionary<string,object> dic)
        {   
            this.userId = SafeDictionary.GetValue<int>(dic,"userId");
            this.sub = SafeDictionary.GetValue<string>(dic,"sub");
            this.name = SafeDictionary.GetValue<string>(dic,"name");
            this.token  = new TDSGlobalAccessToken(SafeDictionary.GetValue<Dictionary<string,object>>(dic,"token") as Dictionary<string,object>);
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
            this.accessToken = SafeDictionary.GetValue<string>(dic,"accessToken");
            this.kid = SafeDictionary.GetValue<string>(dic,"kid");
            this.macKey = SafeDictionary.GetValue<string>(dic,"macKey");
            this.macAlgorithm = SafeDictionary.GetValue<string>(dic,"macAlgorithm");
            this.tokenType = SafeDictionary.GetValue<string>(dic,"tokenType");
        }
    }
}