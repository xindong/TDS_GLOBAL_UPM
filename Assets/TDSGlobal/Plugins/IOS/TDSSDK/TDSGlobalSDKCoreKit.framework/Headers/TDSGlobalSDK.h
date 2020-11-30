
#import <Foundation/Foundation.h>
#import <UIKit/UIKit.h>

NS_ASSUME_NONNULL_BEGIN

typedef NS_ENUM(NSInteger,TDSGlobalLanguageLocale) {
    TDSGlobalLanguageLocaleSimplifiedChinese = 0,                 // 简体中文
    TDSGlobalLanguageLocaleTraditionalChinese,                    // 繁体中文
    TDSGlobalLanguageLocaleEnglish,                               // 英文
    TDSGlobalLanguageLocaleThai,                                  // 泰文
    TDSGlobalLanguageLocaleBahasa                                 // 印尼文
};

/**
 Describe the result of init
 */
typedef void(^TDSGlobalInitResultHandler)(BOOL success);

@interface TDSGlobalSDK : NSObject
#pragma mark - SDK CONFIG
+ (NSString *)getTDSGlobalSDKVersion;

+ (void)setLanguage:(TDSGlobalLanguageLocale)locale;

/// 初始化SDK
/// @param handler 初始化结果回调
+ (void)initTDSGlobalSDK:(TDSGlobalInitResultHandler)handler;

#pragma mark - SDK FUCTIONS

/// 当前登录用户，打开客服中心
/// @param serverId 服务器ID，可为空
/// @param roleId 角色ID，可为空
/// @param roleName 角色名，可为空
+ (void)reportWithServerId:(NSString *)serverId roleId:(NSString *)roleId roleName:(NSString *)roleName;

/// 调起或跳转商店评分
+ (void)storeReview;

#pragma mark - Applicaiton Delegate
+ (void)application:(UIApplication *)application
didFinishLaunchingWithOptions:(nullable NSDictionary<UIApplicationLaunchOptionsKey, id> *)launchOptions;

+ (void)application:(UIApplication *)application openURL:(NSURL *)url options:(NSDictionary<UIApplicationOpenURLOptionsKey,id> *)options;

+ (void)application:(UIApplication *)application openURL:(NSURL *)url sourceApplication:(NSString *)sourceApplication annotation:(id)annotation;

+ (void)application:(UIApplication *)application continueUserActivity:(NSUserActivity *)userActivity restorationHandler:(void (^)(NSArray<id<UIUserActivityRestoring>> * _Nullable))restorationHandler;

+ (void)application:(UIApplication *)application didReceiveRemoteNotification:(NSDictionary *)userInfo fetchCompletionHandler:(void (^)(UIBackgroundFetchResult))completionHandler;

+ (void)scene:(UIScene *)scene openURLContexts:(NSSet<UIOpenURLContext *> *)URLContexts API_AVAILABLE(ios(13.0));

+ (void)scene:(UIScene *)scene continueUserActivity:(NSUserActivity *)userActivity  API_AVAILABLE(ios(13.0));
@end

NS_ASSUME_NONNULL_END
