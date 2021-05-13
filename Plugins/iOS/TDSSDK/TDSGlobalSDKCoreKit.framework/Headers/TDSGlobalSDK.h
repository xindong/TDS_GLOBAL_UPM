
#import <Foundation/Foundation.h>
#import <UIKit/UIKit.h>

NS_ASSUME_NONNULL_BEGIN

typedef NS_ENUM(NSInteger,TDSGlobalLanguageLocale) {
    TDSGlobalLanguageLocaleSimplifiedChinese = 0,                 // 简体中文
    TDSGlobalLanguageLocaleTraditionalChinese,                    // 繁体中文
    TDSGlobalLanguageLocaleEnglish,                               // 英文
    TDSGlobalLanguageLocaleThai,                                  // 泰文
    TDSGlobalLanguageLocaleBahasa,                                // 印尼文
    TDSGlobalLanguageLocaleKorean,                                // 韩文
    TDSGlobalLanguageLocaleJapanese,                              // 日文
    TDSGlobalLanguageLocaleGerman,                                // 德语
    TDSGlobalLanguageLocaleFrench,                                // 法语
    TDSGlobalLanguageLocalePortuguese,                            // 葡萄牙语
    TDSGlobalLanguageLocaleSpanish,                               // 西班牙语
    TDSGlobalLanguageLocaleTurkish,                               // 土耳其语
    TDSGlobalLanguageLocaleRussian,                               // 俄语
};

/**
 Describe the result of init
 */
typedef void(^TDSGlobalInitResultHandler)(BOOL success);

@interface TDSGlobalSDK : NSObject
/// 是否开启收集广告标识符 IDFA,将会开启和关闭所有第三方 SDK 收集。 请在最早调用（任何 SDK 调用之前）
/// @param enable YES: 开启 NO: 关闭。 默认 NO
+ (void)setAdvertiserIDCollectionEnable:(BOOL)enable;

/// 设置调试模式，debug 会输出SDK日志
/// @param debug 是否 debug 模式。默认 NO
+ (void)setDebugMode:(BOOL)debug;

/// 获取当前 SDK 版本
+ (NSString *)getTDSGlobalSDKVersion;

/// 设置SDK显示语言
/// @param locale 语言，在 TDSGlobalLanguageLocale 枚举中查看
+ (void)setLanguage:(TDSGlobalLanguageLocale)locale;

/// 初始化 SDK
/// @param handler 初始化结果回调
+ (void)initTDSGlobalSDK:(TDSGlobalInitResultHandler)handler;

/// 当前登录用户，打开客服中心
/// @param serverId 服务器 ID，可为空
/// @param roleId 角色 ID，可为空
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
