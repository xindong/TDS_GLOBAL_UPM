using System.Collections;
using System;
using System.Collections.Generic;

namespace TDSGlobal
{
    public class TDSGlobalSDK
    {
        public static void Init(Action<bool> callback)
        {
            TDSGlobalImpl.GetInstance().Init(callback);
        }

        public static void Login(Action<TDSGlobalUser> callback, Action<TDSGlobalError> errorCallback)
        {
            TDSGlobalImpl.GetInstance().Login(callback, errorCallback);
        }

        public static void Logout()
        {
            TDSGlobalImpl.GetInstance().Logout();
        }

        public static void UserCenter()
        {
            TDSGlobalImpl.GetInstance().UserCenter();
        }

        public static void AddUserStatusChangeCallback(Action<int> callback)
        {
            TDSGlobalImpl.GetInstance().AddUserStatusChangeCallback(callback);
        }

        public static void GetUser(Action<TDSGlobalUser> callback, Action<TDSGlobalError> errorCallback)
        {
            TDSGlobalImpl.GetInstance().GetUser(callback, errorCallback);
        }

        public static void Share(int shareFlavors, string uri, string message, TDSGlobalShareCallback callback)
        {
            TDSGlobalImpl.GetInstance().Share(shareFlavors, uri, message, callback);
        }

        public static void Share(int shareFlavors, string imagePath, TDSGlobalShareCallback callback)
        {
            TDSGlobalImpl.GetInstance().Share(shareFlavors, imagePath, callback);

        }

        public static void SetLanguage(int languageType)
        {
            TDSGlobalImpl.GetInstance().SetLanguage(languageType);
        }

        public static void PayWithProduct(string orderId, string productId, string roleId, string serverId, string ext, Action<TDSGlobalOrderInfo> callback,Action<TDSGlobalError> errorCallback)
        {
            TDSGlobalImpl.GetInstance().PayWithProduct(orderId, productId, roleId, serverId, ext, callback,errorCallback);
        }

        public static void PayWithWeb(string serverId, string roleId,Action<TDSGlobalError> callback)
        {
            TDSGlobalImpl.GetInstance().PayWithWeb(serverId, roleId, callback);
        }

        public static void QueryWithProductIds(string[] productIds, Action<List<TDSGlobalSkuDetail>> callback,Action<TDSGlobalError> errorCallback)
        {
            TDSGlobalImpl.GetInstance().QueryWithProductIds(productIds, callback,errorCallback);
        }

        public static void QueryRestoredPurchases(Action<List<TDSGlobalRestoredPurchases>> callback)
        {
            TDSGlobalImpl.GetInstance().QueryRestoredPurchases(callback);
        }

        public static void RestorePurchase(string tdsTransactionInfo, string orderId, string productId, string roleId, string serverId, string ext, Action<TDSGlobalOrderInfo> callback,Action<TDSGlobalError> errorCallback)
        {
            TDSGlobalImpl.GetInstance().RestorePurchase(tdsTransactionInfo, orderId, productId, roleId, serverId, ext, callback, errorCallback);
        }

        public static void Report(string serverId, string roleId, string roleName)
        {
            TDSGlobalImpl.GetInstance().Report(serverId, roleId, roleName);
        }

        public static void TrackUser(string serverId, string roleId, string roleName, int level)
        {
            TDSGlobalImpl.GetInstance().TrackUser(serverId, roleId, roleName, level);
        }

        public static void TrackEvent(string eventName)
        {
            TDSGlobalImpl.GetInstance().TrackEvent(eventName);
        }

        public static void TrackAchievement()
        {
            TDSGlobalImpl.GetInstance().TrackAchievement();
        }

        public static void EventCompletedTutorial()
        {
            TDSGlobalImpl.GetInstance().EventCompletedTutorial();
        }

        public static void EventCreateRole()
        {
            TDSGlobalImpl.GetInstance().EventCreateRole();
        }

        public static void GetVersionName(Action<string> callback)
        {
            TDSGlobalImpl.GetInstance().GetVersionName(callback);
        }

        public static void StoreReview()
        {
            TDSGlobalImpl.GetInstance().StoreReview();
        }

    }
}