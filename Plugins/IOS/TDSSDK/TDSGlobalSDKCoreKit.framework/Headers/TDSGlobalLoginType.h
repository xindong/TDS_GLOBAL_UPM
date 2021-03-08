
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
extern NSString *const TDSGLOBAL_TAPTAP_ENTRY;              // @"TAPTAP"
extern NSString *const TDSGLOBAL_GOOGLE_ENTRY;              // @"GOOGLE"
extern NSString *const TDSGLOBAL_FACEBOOK_ENTRY;            // @"FACEBOOK"
extern NSString *const TDSGLOBAL_APPLE_ENTRY;               // @"APPLE"
extern NSString *const TDSGLOBAL_LINE_ENTRY;                // @"LINE"
extern NSString *const TDSGLOBAL_TWITTER_ENTRY;             // @"TWITTER"
extern NSString *const TDSGLOBAL_GUEST_ENTRY;               // @"GUEST"

@interface TDSGlobalLoginType : NSObject
+ (NSString *)accountStringByLoginType:(TDSGlobalSDKLoginType)loginType;
+ (NSString *)accountPureStringByLoginType:(TDSGlobalSDKLoginType)loginType;

+ (NSString *)logoImageByLoginType:(TDSGlobalSDKLoginType)loginType;
+ (NSString *)buttonImageByLoginType:(TDSGlobalSDKLoginType)loginType;

/// convert integer to string
/// @param loginType loginType in integer
+ (NSString *)stringByLoginType:(TDSGlobalSDKLoginType)loginType;

/// convert string to integer enum
/// @param loginTypeInString loginType in string
+ (TDSGlobalSDKLoginType)loginTypeByString:(NSString *)loginTypeInString;

@end

NS_ASSUME_NONNULL_END
