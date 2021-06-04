
#import <Foundation/Foundation.h>

NS_ASSUME_NONNULL_BEGIN

typedef NS_ENUM(NSInteger,TDSGlobalSDKEntryType) {
    TDSGlobalSDKEntryTypeDefault = 0,
    TDSGlobalSDKEntryTypeTapTap,
    TDSGlobalSDKEntryTypeApple,
    TDSGlobalSDKEntryTypeGoogle,
    TDSGlobalSDKEntryTypeFacebook,
    TDSGlobalSDKEntryTypeLine,
    TDSGlobalSDKEntryTypeTwitter,
    TDSGlobalSDKEntryTypeGuest
};

/**
 enum of entryType in string
 */
extern NSString *const TDSGLOBAL_TAPTAP_ENTRY;              // @"TAPTAP"
extern NSString *const TDSGLOBAL_GOOGLE_ENTRY;              // @"GOOGLE"
extern NSString *const TDSGLOBAL_FACEBOOK_ENTRY;            // @"FACEBOOK"
extern NSString *const TDSGLOBAL_APPLE_ENTRY;               // @"APPLE"
extern NSString *const TDSGLOBAL_LINE_ENTRY;                // @"LINE"
extern NSString *const TDSGLOBAL_TWITTER_ENTRY;             // @"TWITTER"
extern NSString *const TDSGLOBAL_GUEST_ENTRY;               // @"GUEST"

/// Login or bind entry type
@interface TDSGlobalEntryType : NSObject
+ (NSString *)accountstringByEntryType:(TDSGlobalSDKEntryType)entryType;
+ (NSString *)accountPurestringByEntryType:(TDSGlobalSDKEntryType)entryType;

+ (NSString *)logoImageByEntryType:(TDSGlobalSDKEntryType)entryType;
+ (NSString *)buttonImageByEntryType:(TDSGlobalSDKEntryType)entryType;

/// convert integer to string
/// @param entryType entryType in integer
+ (NSString *)stringByEntryType:(TDSGlobalSDKEntryType)entryType;

/// convert string to integer enum
/// @param entryTypeInString entryType in string
+ (TDSGlobalSDKEntryType)entryTypeByString:(NSString *)entryTypeInString;

@end

NS_ASSUME_NONNULL_END
