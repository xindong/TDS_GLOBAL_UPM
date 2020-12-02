using TDSCommon;
using System.Collections;
using System;
using System.Collections.Generic;
using UnityEngine;

namespace TDSGlobal
{
    public class TDSGlobalImpl : ITDSGlobal
    {

        private volatile static ITDSGlobal sInstance;
        private static readonly object locker = new object();

        private TDSGlobalImpl()
        {
            Debug.Log("初始化TDSGlobalBridgeService");
            EngineBridge.GetInstance().Register(TDSGlobalBridgeName.SERVICE_CLZ, TDSGlobalBridgeName.SERVICE_IMPL);
            EngineBridge.GetInstance().Register(TDSGlobalBridgeName.IAP_SERVICE_CLZ, TDSGlobalBridgeName.IAP_SERVICE_IMPL);
            EngineBridge.GetInstance().Register(TDSGlobalBridgeName.LOGIN_SERVICE_CLZ, TDSGlobalBridgeName.LOGIN_SERVICE_IMPL);
        }


        public static ITDSGlobal GetInstance()
        {
            lock (locker)
            {
                if (sInstance == null)
                {
                    sInstance = new TDSGlobalImpl();
                }
            }
            return sInstance;
        }

        public void Init(Action<bool> callback)
        {
            Command command = new Command(TDSGlobalBridgeName.SERVICE_NAME, "initTDSGlobalSDK", true, System.Guid.NewGuid().ToString(), null);
            EngineBridge.GetInstance().CallHandler(command, (result) =>
            {
                Debug.Log("initSDK result:" + result.toJSON());

                if(!checkResultSuccess(result)){
                    return;
                }
                
                TDSGlobalInitWrapper initWrapper = new TDSGlobalInitWrapper(result.content);

                if(initWrapper!=null){
                    callback(initWrapper.success);
                }
            });
        }

        public void Login(Action<TDSGlobalUser> callback, Action<TDSGlobalError> errorCallback)
        {
            Command command = new Command(TDSGlobalBridgeName.LOGIN_SERVICE_NAME, "login", true, System.Guid.NewGuid().ToString(), null);
            EngineBridge.GetInstance().CallHandler(command, (result) =>
            {   
                Debug.Log("login result:" + result.toJSON());

                if(!checkResultSuccess(result)){
                    return;
                }

                TDSGlobalUserWrapper userWrapper = new TDSGlobalUserWrapper(result.content);
                if(userWrapper.user!=null){
                    callback(userWrapper.user);
                }
                else if(userWrapper.error!=null){
                    errorCallback(userWrapper.error);
                }                
            });
        }

        public void Logout()
        {
            Command command = new Command(TDSGlobalBridgeName.LOGIN_SERVICE_NAME, "logout", true, System.Guid.NewGuid().ToString(), null);
            EngineBridge.GetInstance().CallHandler(command);
        }

        public void AddUserStatusChangeCallback(Action<int> callback)
        {
            Command command = new Command(TDSGlobalBridgeName.LOGIN_SERVICE_NAME, "addUserStatusChangeCallback", true, System.Guid.NewGuid().ToString(), null);
            EngineBridge.GetInstance().CallHandler(command, (result) =>
            {
                if(!checkResultSuccess(result)){
                    return;
                }
                
                TDSGlobalUserStatusChangeWrapper statusChangeWrapper = new TDSGlobalUserStatusChangeWrapper(result.content);
                callback(statusChangeWrapper.code);

            });
        }

        public void GetUser(Action<TDSGlobalUser> callback, Action<TDSGlobalError> errorCallback)
        {
            Command command = new Command(TDSGlobalBridgeName.LOGIN_SERVICE_NAME, "getUser", true, System.Guid.NewGuid().ToString(), null);
            EngineBridge.GetInstance().CallHandler(command, (result) =>
            {
                Debug.Log("getUser result:" + result.toJSON());
                
                if(!checkResultSuccess(result)){
                    return;
                }
                TDSGlobalUserWrapper userWrapper = new TDSGlobalUserWrapper(result.content);
                if(userWrapper.user!=null){
                    callback(userWrapper.user);
                }
                else if(userWrapper.error!=null){
                    errorCallback(userWrapper.error);
                }                
            });
        }

        public void UserCenter()
        {
            Command command = new Command(TDSGlobalBridgeName.LOGIN_SERVICE_NAME, "userCenter", true, System.Guid.NewGuid().ToString(), null);
            EngineBridge.GetInstance().CallHandler(command);
        }

        public void Share(int shareFlavors, string uri, string message, TDSGlobalShareCallback callback)
        {
            Dictionary<string, object> dic = new Dictionary<string, object>();
            dic.Add("url", uri);
            dic.Add("message", message);
            dic.Add("shareWithType", shareFlavors);
            Command command = new Command(TDSGlobalBridgeName.SERVICE_NAME, "shareWithUriMessage", true, System.Guid.NewGuid().ToString(), dic);
            EngineBridge.GetInstance().CallHandler(command, (result) =>
            {
                handlerShareCallback(result,callback);
            });
        }

        public void Share(int shareFlavors, string imagePath, TDSGlobalShareCallback callback)
        {
            Dictionary<string, object> dic = new Dictionary<string, object>();
            dic.Add("image", imagePath);
            dic.Add("shareWithType", shareFlavors);
            Command command = new Command(TDSGlobalBridgeName.SERVICE_NAME, "shareWithImage", true, System.Guid.NewGuid().ToString(), dic);
            EngineBridge.GetInstance().CallHandler(command, (result) =>
            {
                handlerShareCallback(result,callback);
            });
        }

        public void SetLanguage(int languageType)
        {
            Dictionary<string, object> dic = new Dictionary<string, object>();
            dic.Add("setLanguage", languageType);
            Command command = new Command(TDSGlobalBridgeName.SERVICE_NAME, "changeLanguageType", false, null, dic);
            EngineBridge.GetInstance().CallHandler(command);
        }

        public void PayWithProduct(string orderId, string productId, string roleId, string serverId, string ext,Action<TDSGlobalOrderInfo> callback,Action<TDSGlobalError> errorCallback)
        {
            Dictionary<string, object> dic = new Dictionary<string, object>();
            dic.Add("payWithOrderId", orderId);
            dic.Add("productId", productId);
            dic.Add("roleId", roleId);
            dic.Add("serverId", serverId);
            dic.Add("ext", ext);
            Command command = new Command(TDSGlobalBridgeName.IAP_SERVICE_NAME, "payWithProduct", true, System.Guid.NewGuid().ToString(), dic);
            EngineBridge.GetInstance().CallHandler(command, (result) => { 
                handlerOrderInfoCallback(result,callback,errorCallback);
            });
        }

        public void PayWithWeb(string serverId, string roleId, Action<TDSGlobalError> callback)
        {
            Dictionary<string, object> dic = new Dictionary<string, object>();
            dic.Add("roleId", roleId);
            dic.Add("serverId", serverId);
            Command command = new Command(TDSGlobalBridgeName.IAP_SERVICE_NAME, "payWithWeb", true, System.Guid.NewGuid().ToString(), dic);
            EngineBridge.GetInstance().CallHandler(command, (result) => {
                if(!checkResultSuccess(result))
                {
                    return;
                } 
                TDSGlobalError error = new TDSGlobalError(result.content);
                callback(error);
             });
        }

        public void QueryWithProductIds(string[] productIds, Action<List<TDSGlobalSkuDetail>> callback,Action<TDSGlobalError> errorCallback)
        {
            Dictionary<string, object> dic = new Dictionary<string, object>();
            dic.Add("queryWithProductIds", productIds);
            Command command = new Command(TDSGlobalBridgeName.IAP_SERVICE_NAME, "querySKUWithProductIds", true, System.Guid.NewGuid().ToString(), dic);
            EngineBridge.GetInstance().CallHandler(command, (result) => 
            { 
                if(!checkResultSuccess(result))
                {
                    return;
                }
                TDSGlobalSkuDetailWrapper wrapper = new TDSGlobalSkuDetailWrapper(result.content);
                if(wrapper==null)
                {
                    return;
                }
                if(wrapper.products!=null)
                {
                    callback(wrapper.products);
                    return;
                }
                errorCallback(wrapper.error);
            });
        }

        public void QueryRestoredPurchases(Action<List<TDSGlobalRestoredPurchases>> callback)
        {
            Command command = new Command(TDSGlobalBridgeName.IAP_SERVICE_NAME,"queryRestoredPurchases",true,System.Guid.NewGuid().ToString(),null);
            EngineBridge.GetInstance().CallHandler(command, (result) => { 
                if(!checkResultSuccess(result))
                {
                    return;
                }
                TDSGlobalRestoredPurchasesWrapper wrapper = new TDSGlobalRestoredPurchasesWrapper(result.content);
                callback(wrapper.transactions);
            });
        }

        public void RestorePurchase(string tdsTransactionInfo, string orderId, string productId, string roleId, string serverId, string ext, Action<TDSGlobalOrderInfo> callback,Action<TDSGlobalError> errorCallback)
        {
            Dictionary<string, object> dic = new Dictionary<string, object>();
            dic.Add("restorePurchase", tdsTransactionInfo);
            dic.Add("orderId", orderId);
            dic.Add("roleId", roleId);
            dic.Add("serverId", serverId);
            dic.Add("ext", ext);
            dic.Add("productId", productId);
            Command command = new Command(TDSGlobalBridgeName.IAP_SERVICE_NAME, "queryRestoredPurchasesWithInfo", true, System.Guid.NewGuid().ToString(), dic);
            EngineBridge.GetInstance().CallHandler(command, (result) => { 
                handlerOrderInfoCallback(result,callback,errorCallback);
            });
        }

        public void Report(string serverId, string roleId, string roleName)
        {
            Dictionary<string, object> dic = new Dictionary<string, object>();
            dic.Add("reportWithServerId", serverId);
            dic.Add("roleId", roleId);
            dic.Add("roleName", roleName);
            Command command = new Command(TDSGlobalBridgeName.SERVICE_NAME, "report", false, null, dic);
            EngineBridge.GetInstance().CallHandler(command);
        }

        public void TrackUser(string serverId, string roleId, string roleName, int level)
        {
            Dictionary<string, object> dic = new Dictionary<string, object>();
            dic.Add("serverId", serverId);
            dic.Add("trackUser", roleId);
            dic.Add("roleName", roleName);
            dic.Add("level", level);
            Command command = new Command(TDSGlobalBridgeName.SERVICE_NAME, "trackUser", false, null, dic);
            EngineBridge.GetInstance().CallHandler(command);
        }

        public void TrackEvent(string eventName)
        {
            Dictionary<string, object> dic = new Dictionary<string, object>();
            dic.Add("trackEvent", eventName);
            Command command = new Command(TDSGlobalBridgeName.SERVICE_NAME, "trackEvent", false, null, dic);
            EngineBridge.GetInstance().CallHandler(command);
        }

        public void TrackAchievement()
        {
            Command command = new Command(TDSGlobalBridgeName.SERVICE_NAME, "trackAchievement", false, null, null);
            EngineBridge.GetInstance().CallHandler(command);
        }

        public void EventCompletedTutorial()
        {
            Command command = new Command(TDSGlobalBridgeName.SERVICE_NAME, "eventCompletedTutorial", false, null, null);
            EngineBridge.GetInstance().CallHandler(command);
        }

        public void EventCreateRole()
        {
            Command command = new Command(TDSGlobalBridgeName.SERVICE_NAME, "eventCreateRole", false, null, null);
            EngineBridge.GetInstance().CallHandler(command);
        }
        
        public void GetVersionName(Action<string> callback)
        {
            Command command = new Command(TDSGlobalBridgeName.SERVICE_NAME, "getTDSGlobalSDKVersion", true, System.Guid.NewGuid().ToString(), null);
            EngineBridge.GetInstance().CallHandler(command, (result) =>
            {
                if(!checkResultSuccess(result)){
                    return;
                }
                callback(result.content);
            });
        }

        public void StoreReview()
        {
            Command command = new Command(TDSGlobalBridgeName.SERVICE_NAME,"storeReview",false,null,null);
            EngineBridge.GetInstance().CallHandler(command);
        }

        private bool checkResultSuccess(Result result){
            return result.code == Result.RESULT_SUCCESS && !string.IsNullOrEmpty(result.content);
        }

        private void handlerShareCallback(Result result,TDSGlobalShareCallback callback)
        {
            if(!checkResultSuccess(result)){
                    return;
                }
                TDSGlobalShareWrapper shareWrapper = new TDSGlobalShareWrapper(result.content);
                if(shareWrapper.cancel){
                    callback.ShareCancel();
                    return;
                }
                if(shareWrapper.shareError!=null){
                    callback.ShareError(shareWrapper.shareError.error_msg);
                    return;
                }
                callback.ShareSuccess();
        }

        private void handlerOrderInfoCallback(Result result,Action<TDSGlobalOrderInfo> callback,Action<TDSGlobalError> errorCallback)
        {
            if(!checkResultSuccess(result))
            {
                return;
            }

            TDSGlobalOrderInfoWrapper infoWrapper = new TDSGlobalOrderInfoWrapper(result.content);
            if(infoWrapper == null)
            {
                return;
            }
            if(infoWrapper.orderInfo != null)
            {
                callback(infoWrapper.orderInfo);
                return;
            }
            errorCallback(infoWrapper.error);
        }

    }
}