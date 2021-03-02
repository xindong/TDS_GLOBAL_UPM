
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

/*
 enum of loginType in string
 */
extern NSString *const TDSGLOBAL_TAPTAP_ENTRY;
extern NSString *const TDSGLOBAL_GOOGLE_ENTRY;
extern NSString *const TDSGLOBAL_FACEBOOK_ENTRY;
extern NSString *const TDSGLOBAL_APPLE_ENTRY;
extern NSString *const TDSGLOBAL_LINE_ENTRY;
extern NSString *const TDSGLOBAL_TWITTER_ENTRY;
extern NSString *const TDSGLOBAL_GUEST_ENTRY;

@interface TDSGlobalLoginType : NSObject
+ (NSString *)accountStringByLoginType:(TDSGlobalSDKLoginType)loginType;
+ (NSString *)accountPureStringByLoginType:(TDSGlobalSDKLoginType)loginType;

+ (NSString *)logoImageByLoginType:(TDSGlobalSDKLoginType)loginType;
+ (NSString *)buttonImageByLoginType:(TDSGlobalSDKLoginType)loginType;

/// convert integer to string
/// @param loginType loginType in integer
+ (NSString *)stringByLoginType:(TDSGlobalSDKLoginType)loginType;

@end

NS_ASSUME_NONNULL_END
