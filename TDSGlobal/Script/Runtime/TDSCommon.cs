using System.Collections;
using System;
using System.Collections.Generic;
using UnityEngine;

namespace TDSCommon
{
    public class TDSCommon
    {
        private static TDSCommon sInstance = new TDSCommon();

        public static TDSCommon GetInstance()
        {
            return sInstance;
        }

        private TDSCommon()
        {
            EngineBridge.GetInstance().Register("com.tds.common.wrapper.TDSCommonService", "com.tds.common.wrapper.TDSCommonServiceImpl");
        }

        public void SetLanguage(string language)
        {
            Dictionary<string, object> dic = new Dictionary<string, object>();
            dic.Add("language", language);
            Command command = new Command("TDSCommonService", "setLanguage", false, null, dic);
            EngineBridge.GetInstance().CallHandler(command);
        }

        public void GetRegionCode(Action<bool> callback)
        {
            Command command = new Command("TDSCommonService", "getRegionCode", true, System.Guid.NewGuid().ToString(), null);
            EngineBridge.GetInstance().CallHandler(command, (result) =>
            {
                if (result.code != Result.RESULT_SUCCESS)
                {
                    return;
                }

                if (string.IsNullOrEmpty(result.content))
                {
                    return;
                }

                CommonRegionWrapper wrapper = new CommonRegionWrapper(result.content);
                if(wrapper!=null)
                {
                    callback(wrapper.isMainland);
                }

            });

            

        }

    }

    [Serializable]
    public class CommonRegionWrapper
    {
        public bool isMainland;

        public CommonRegionWrapper(string json)
        {
            JsonUtility.FromJsonOverwrite(json, this);
        }

    }

}