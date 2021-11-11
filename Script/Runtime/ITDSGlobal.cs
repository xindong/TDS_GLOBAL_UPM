using System.Collections;
using System;
using System.Collections.Generic;

namespace TDSGlobal
{
    public interface ITDSGlobal
    {
        void Init(Action<bool> callback);

        void Login(Action<TDSGlobalUser> callback, Action<TDSGlobalError> errorCallback);

        void LoginByType(LoginType loginType, Action<TDSGlobalUser> callback, Action<TDSGlobalError> errorCallback);

        void Logout();

        void AddUserStatusChangeCallback(Action<int, string> callback);

        void GetUser(Action<TDSGlobalUser> callback, Action<TDSGlobalError> errorCallback);

        void UserCenter();

        void Share(int shareFlavors, string uri, string message, TDSGlobalShareCallback callback);

        void Share(int shareFlavors, string imagePath, TDSGlobalShareCallback callback);

        void SetLanguage(int languageType);

        void PayWithProduct(string orderId, string productId, string roleId, string serverId, string ext,
            Action<TDSGlobalOrderInfo> callback, Action<TDSGlobalError> errorCallback);

        void PayWithWeb(string serverId, string roleId, Action<TDSGlobalError> callback);

        void QueryWithProductIds(string[] productIds, Action<List<TDSGlobalSkuDetail>> callback,
            Action<TDSGlobalError> errorCallback);

        void QueryRestoredPurchases(Action<List<TDSGlobalRestoredPurchases>> callback);

        void RestorePurchase(string tdsTransactionInfo, string orderId, string productId, string roleId,
            string serverId, string ext, Action<TDSGlobalOrderInfo> callback, Action<TDSGlobalError> errorCallback);

        void Report(string serverId, string roleId, string roleName);

        void TrackUser(string serverId);

        void TrackUser(string serverId, string roleId, string roleName, int level);

        void TrackEvent(string eventName);

        void TrackAchievement();

        void EventCompletedTutorial();

        void EventCreateRole();

        void GetVersionName(Action<string> callback);

        void StoreReview();

        void AdvertiserIDCollectionEnable(bool enable);

        /**
         * 当前手机版本是否是 Android 11 及以上
         */
        void IsBuildVersionAboveAndroid11(Action<bool> callback);

        /**
         * 当前是否有外部存储管理权限(在 Android 11及以上调用此方法才生效，否则都是 false)
         */
        void IsExternalStorageManager(Action<bool> callback);

        /**
         * 调用系统设置请求获取外部存储管理权限(在 Android 11及以上，且没有此权限调用此方法才生效，否则无反应)
         */
        void RequestExternalStorageManagerPermission(int requestCode);
    }

    public interface TDSGlobalShareCallback
    {
        void ShareSuccess();

        void ShareCancel();

        void ShareError(string error);
    }
}