
#import <Foundation/Foundation.h>
#import <TDSGlobalSDKCoreKit/TDSGlobalUserToken.h>
#import <TDSGlobalSDKCoreKit/TDSGlobalLoginType.h>

NS_ASSUME_NONNULL_BEGIN

@interface TDSGlobalUser : NSObject <NSCoding>
/**
The user's user ID.
*/
@property (nonatomic,assign) NSInteger userId;

/**
The user’s user ID in string.
*/
@property (nonatomic,copy) NSString *sub;

/**
The user's user name.
*/
@property (nonatomic,copy) NSString *name;

/**
The user's current loginType.
*/
@property (nonatomic,assign) TDSGlobalSDKLoginType loginType;

/**
The user's token.
*/
@property (nonatomic,strong) TDSGlobalUserToken *token;

@end

NS_ASSUME_NONNULL_END
