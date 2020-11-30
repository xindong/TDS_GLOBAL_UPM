
#import <TDSGlobalSDKCoreKit/TDSGlobalAsyncHttp.h>

NS_ASSUME_NONNULL_BEGIN

/*
 common params key
 */
extern NSString *const TDS_COMMON_PARAM_CLIENT_ID_KEY;
extern NSString *const TDS_COMMON_PARAM_CHANNEL_KEY;
extern NSString *const TDS_COMMON_PARAM_ACCESS_TOKEN_KEY;
extern NSString *const TDS_COMMON_PARAM_USER_ID_KEY;
extern NSString *const TDS_COMMON_PARAM_SERVICE_ID_KEY;
extern NSString *const TDS_COMMON_PARAM_ROLE_ID_KEY;
extern NSString *const TDS_COMMON_PARAM_ROLE_NAME_KEY;
extern NSString *const TDS_COMMON_PARAM_RES_KEY;
extern NSString *const TDS_COMMON_PARAM_CPU_KEY;
extern NSString *const TDS_COMMON_PARAM_MEM_KEY;
extern NSString *const TDS_COMMON_PARAM_PLATFORM_KEY;
extern NSString *const TDS_COMMON_PARAM_OS_KEY;
extern NSString *const TDS_COMMON_PARAM_MOD_KEY;
extern NSString *const TDS_COMMON_PARAM_BRAND_KEY;
extern NSString *const TDS_COMMON_PARAM_APP_VERSION_KEY;
extern NSString *const TDS_COMMON_PARAM_APP_VERSION_CODE_KEY;
extern NSString *const TDS_COMMON_PARAM_SDK_VERSION_KEY;
extern NSString *const TDS_COMMON_PARAM_LANGUAGE_KEY;
extern NSString *const TDS_COMMON_PARAM_SDK_LANGUAGE_KEY;
extern NSString *const TDS_COMMON_PARAM_GAME_NAME_KEY;
extern NSString *const TDS_COMMON_PARAM_REGION_KEY;
extern NSString *const TDS_COMMON_PARAM_IDFA_KEY;
extern NSString *const TDS_COMMON_PARAM_PKG_NAME_KEY;
extern NSString *const TDS_COMMON_PARAM_DEVICE_ID_KEY;
extern NSString *const TDS_COMMON_PARAM_DEVICE_LOCATION_KEY;
extern NSString *const TDS_COMMON_PARAM_DEVICE_TIME_KEY;

@interface TDSGlobalSDKAsyncHttp : TDSGlobalAsyncHttp

/// GET请求
/// @param urlStr url
/// @param requestParams 网络请求参数，如超时、格式等
/// @param params 本次请求参数
/// @param callBackBlock 成功回调
/// @param failedCallback 失败回调
+ (TDSGlobalAsyncHttp *)httpGet:(NSString *)urlStr requestParams:(nullable NSDictionary *)requestParams params:(nullable NSDictionary *)params callBack:(CallBackBlock)callBackBlock failedCallback:(CallBackBlock)failedCallback;

/// POST请求
/// @param urlStr URL
/// @param requestParams 网络请求参数，如超时、数据格式、请求头等
/// @param params 本次请求参数
/// @param callBackBlock 成功回调
/// @param failedCallback 失败回调
+ (TDSGlobalAsyncHttp *)httpPost:(NSString *)urlStr requestParams:(nullable NSDictionary *)requestParams params:(nullable NSDictionary *)params callBack:(CallBackBlock)callBackBlock failedCallback:(CallBackBlock)failedCallback;

@end

NS_ASSUME_NONNULL_END
