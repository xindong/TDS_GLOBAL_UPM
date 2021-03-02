
#import <Foundation/Foundation.h>

NS_ASSUME_NONNULL_BEGIN
@class TDSGlobalUser;

typedef NS_ENUM(NSInteger,TDSGlobalUserStateChangeCode) {
    TDSGlobalUserStateChangeCodeLogout          = 0x9001,      // user logout
    TDSGlobalUserStateChangeCodeBindSuccess     = 0x1001,      // user bind other OAuth account,msg = entry type in string,eg: @"TAPTAP"
    TDSGlobalUserStateChangeCodeUnBindSuccess   = 0x1002,      // user unbind other OAuth account,msg = entry type in string
};

/**
  Describes the call back to the TDSGlobalLoginManager
 @param result the result user date of the Request
 @param error error, if any.
 */
typedef void (^TDSGlobalLoginManagerRequestHandler)(TDSGlobalUser * _Nullable result, NSError * _Nullable error);

/**
  Describes the call back of state of current user
 @param userStateChangeCode user state change type code.
 */
typedef void (^TDSGlobalUserStateChangeHandler)(TDSGlobalUserStateChangeCode userStateChangeCode,NSString *message);

@interface TDSGlobalLoginManager : NSObject
+ (void)login:(TDSGlobalLoginManagerRequestHandler)handler;

+ (void)addUserStatusChangeCallback:(TDSGlobalUserStateChangeHandler)handler;

/// logout current user
+ (void)logout;

/// get current user
+ (void)getUser:(TDSGlobalLoginManagerRequestHandler)handler;

+ (void)userCenter;
@end

NS_ASSUME_NONNULL_END
