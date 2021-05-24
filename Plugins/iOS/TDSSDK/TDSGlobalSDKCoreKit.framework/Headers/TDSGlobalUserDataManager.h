
#import <Foundation/Foundation.h>
#import <TDSGlobalSDKCoreKit/TDSGlobalUser.h>
#import <TDSGlobalSDKCoreKit/TDSGlobalEntryType.h>

NS_ASSUME_NONNULL_BEGIN
@interface TDSGlobalUserDataManager : NSObject

+ (void)setCurrentUser:(TDSGlobalUser *)user;
+ (TDSGlobalUser *)getCurrentUserData;

+ (void)updateLoginState:(BOOL)loggedIn;
+ (BOOL)isUserLoggedIn;
+ (BOOL)isUserTokenValid;

+ (TDSGlobalSDKEntryType)getCurLoginType;

+ (void)userLoginSuccess;
+ (void)userLogout;

/// 是否需要弹隐私协议
+ (BOOL)needShowAgreement;
+ (void)updateUserServiceAgreement;

/// 推送开关
+ (BOOL)needPushService;
+ (void)updatePushServiceStatu:(BOOL)statu;

@end

NS_ASSUME_NONNULL_END
