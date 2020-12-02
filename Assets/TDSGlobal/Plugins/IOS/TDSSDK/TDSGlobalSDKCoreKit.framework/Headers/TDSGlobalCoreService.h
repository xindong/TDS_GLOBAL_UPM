//
//  TDSGlobalCoreService.h
//  TDSGlobalSDKCoreKit
//
//  Created by JiangJiahao on 2020/11/23.
//  unity 桥

#import <Foundation/Foundation.h>

NS_ASSUME_NONNULL_BEGIN

@interface TDSGlobalCoreService : NSObject
+ (NSString *)getTDSGlobalSDKVersion;

+ (void)setLanguage:(NSNumber *)locale;

+ (void)initTDSGlobalSDK:(void (^)(NSString *result))callback;

/// 当前登录用户，打开客服中心
/// @param serverId 服务器ID，可为空
/// @param roleId 角色ID，可为空
/// @param roleName 角色名，可为空
+ (void)reportWithServerId:(NSString *)serverId roleId:(NSString *)roleId roleName:(NSString *)roleName;

/// 调起或跳转商店评分
+ (void)storeReview;

#pragma mark - 分享
+ (void)shareWithType:(NSNumber *)type image:(UIImage *)image bridgeCallback:(void (^)(NSString *result))callback;

+ (void)shareWithType:(NSNumber *)type url:(NSString *)url message:(NSString *)message bridgeCallback:(void (^)(NSString *result))callback;

#pragma mark - 数据追踪
+ (void)trackUser:(NSString *)roleId
         roleName:(NSString *)roleName
         serverId:(NSString *)serverId
            level:(NSNumber *)level;

+ (void)trackEvent:(NSString *)eventName;

+ (void)trackAchievement;

+ (void)eventCompletedTutorial;

+ (void)eventCreateRole;
@end

NS_ASSUME_NONNULL_END
