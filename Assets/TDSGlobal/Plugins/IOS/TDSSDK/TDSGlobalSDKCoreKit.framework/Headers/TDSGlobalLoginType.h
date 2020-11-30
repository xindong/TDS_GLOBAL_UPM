
#import <Foundation/Foundation.h>

NS_ASSUME_NONNULL_BEGIN

typedef NS_ENUM(NSInteger,TDSGlobalSDKLoginType) {
    TDSGlobalSDKLoginTypeNone = 0,
    TDSGlobalSDKLoginTypeTapTap,
    TDSGlobalSDKLoginTypeApple,
    TDSGlobalSDKLoginTypeGoogle,
    TDSGlobalSDKLoginTypeFacebook,
    TDSGlobalSDKLoginTypeLine,
    TDSGlobalSDKLoginTypeTwitter,
    TDSGlobalSDKLoginTypeGuest
};
extern NSString *const TAPTAP_LOGIN;
extern NSString *const GOOGLE_LOGIN;
extern NSString *const FACEBOOK_LOGIN;
extern NSString *const APPLE_LOGIN;
extern NSString *const LINE_LOGIN;
extern NSString *const TWITTER_LOGIN;
extern NSString *const GUEST_LOGIN;

@interface TDSGlobalLoginType : NSObject
+ (NSString *)accountStringByLoginType:(TDSGlobalSDKLoginType)loginType;
+ (NSString *)accountPureStringByLoginType:(TDSGlobalSDKLoginType)loginType;

+ (NSString *)logoImageByLoginType:(TDSGlobalSDKLoginType)loginType;
+ (NSString *)buttonImageByLoginType:(TDSGlobalSDKLoginType)loginType;

@end

NS_ASSUME_NONNULL_END
