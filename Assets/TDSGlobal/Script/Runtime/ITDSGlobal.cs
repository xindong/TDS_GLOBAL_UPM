using System.Collections;
using System;
using System.Collections.Generic;

namespace TDSGlobal
{
    public interface ITDSGlobal
    {
        void Init(Action<bool> callback);

        void Login(Action<TDSGlobalUser> callback, Action<TDSGlobalError> errorCallback);

        void Logout();

        void AddUserStatusChangeCallback(Action<int> callback);

        void GetUser(Action<TDSGlobalUser> callback, Action<TDSGlobalError> errorCallback);

        void UserCenter();

        void Share(int shareFlavors, string uri, string message, TDSGlobalShareCallback callback);

        void Share(int shareFlavors, string imagePath, TDSGlobalShareCallback callback);

        void SetLanguage(int languageType);

        void PayWithProduct(string orderId, string productId, string roleId, string serverId, string ext, Action<TDSGlobalOrderInfo> callback , Action<TDSGlobalError> errorCallback);

        void PayWithWeb(string serverId, string roleId,Action<TDSGlobalError> callback);

        void QueryWithProductIds(string[] productIds, Action<List<TDSGlobalSkuDetail>> callback,Action<TDSGlobalError> errorCallback);

        void QueryRestoredPurchases(Action<List<TDSGlobalRestoredPurchases>> callback);

        void RestorePurchase(string tdsTransactionInfo, string orderId, string productId, string roleId, string serverId, string ext, Action<TDSGlobalOrderInfo> callback,Action<TDSGlobalError> errorCallback);

        void Report(string serverId, string roleId, string roleName);

        void TrackUser(string serverId, string roleId, string roleName, int level);

        void TrackEvent(string eventName);

        void TrackAchievement();

        void EventCompletedTutorial();

        void EventCreateRole();

        void GetVersionName(Action<string> callback);

        void StoreReview();

    }

    public interface TDSGlobalShareCallback
    {
        void ShareSuccess();

        void ShareCancel();

        void ShareError(string error);
    }


}