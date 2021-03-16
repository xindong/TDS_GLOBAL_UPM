
#import <Foundation/Foundation.h>
#import <TDSGlobalSDKCoreKit/TDSGlobalUserToken.h>
#import <TDSGlobalSDKCoreKit/TDSGlobalLoginType.h>

NS_ASSUME_NONNULL_BEGIN

@interface TDSGlobalUser : NSObject <NSCoding>
/**
The user's user ID.
*/
@property (nonatomic,assign,readonly) NSInteger userId;

/**
The user’s user ID in string.
*/
@property (nonatomic,copy,readonly) NSString *sub;

/**
The user's user name.
*/
@property (nonatomic,copy,readonly) NSString *name;

/**
The user's current loginType.
*/
@property (nonatomic,assign,readonly) TDSGlobalSDKLoginType loginType;

/**
The user's bound accounts. eg.@[@"TAPTAP",@"GOOGLE",@"FACEBOOK"]
*/
@property (nonatomic,copy,readonly) NSArray<NSString *> *boundAccounts;

/**
The user's token.
*/
@property (nonatomic,strong,readonly) TDSGlobalUserToken *token;

- (instancetype)initWithUserID:(NSInteger)userID
                           sub:(NSString *)sub
                          name:(NSString *)name
                     loginType:(TDSGlobalSDKLoginType)loginType
               boundAccounts:(NSArray *)boundAccounts
                         token:(TDSGlobalUserToken *)token;

@end

NS_ASSUME_NONNULL_END
