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
        public long userId;

        public string sub;

        public string name;

        public int loginType;

        public List<string> boundAccounts;

        public TDSGlobalAccessToken token;

        public TDSGlobalUser(string json)
        {
            Dictionary<string,object> dic = Json.Deserialize(json) as Dictionary<string,object>;
            this.userId = SafeDictionary.GetValue<long>(dic,"userId");
            this.sub = SafeDictionary.GetValue<string>(dic,"sub");
            this.name = SafeDictionary.GetValue<string>(dic,"name");
            this.loginType = SafeDictionary.GetValue<int>(dic,"loginType");
            this.boundAccounts = SafeDictionary.GetValue<List<string>>(dic,"boundAccounts");
            this.token  = new TDSGlobalAccessToken(SafeDictionary.GetValue<Dictionary<string,object>>(dic,"token"));
        }

        public TDSGlobalUser(Dictionary<string,object> dic)
        {   
            this.userId = SafeDictionary.GetValue<long>(dic,"userId");
            this.sub = SafeDictionary.GetValue<string>(dic,"sub");
            this.name = SafeDictionary.GetValue<string>(dic,"name");
            this.token  = new TDSGlobalAccessToken(SafeDictionary.GetValue<Dictionary<string,object>>(dic,"token"));
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