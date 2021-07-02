
#import <Foundation/Foundation.h>
#import <TDSGlobalSDKCoreKit/TDSGlobalUserToken.h>
#import <TDSGlobalSDKCoreKit/TDSGlobalEntryType.h>

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
The user’s  tds ID
 */
@property (nonatomic,copy,readonly,nullable) NSString *tdsId;
/**
The user's user name.
*/
@property (nonatomic,copy,readonly) NSString *name;
/**
The user's current loginType.
*/
@property (nonatomic,assign,readonly) TDSGlobalSDKEntryType loginType;
/**
The user's bound accounts. eg.@[@"TAPTAP",@"GOOGLE",@"FACEBOOK"]
*/
@property (nonatomic,copy,readonly) NSArray<NSString *> *boundAccounts;
/**
The user need push service or not
*/
@property (nonatomic,assign,readonly,getter=isPushServiceEnable) BOOL pushServiceEnable;

/**
The user's token.
*/
@property (nonatomic,strong,readonly) TDSGlobalUserToken *token;
/// The current user profile
+ (TDSGlobalUser *)currentUser;

+ (void)clearCurrentUser;

- (instancetype)initWithUserID:(NSInteger)userID
                           sub:(nullable NSString *)sub
                         tdsID:(nullable NSString *)tdsID
                          name:(nullable NSString *)name
                     loginType:(TDSGlobalSDKEntryType)loginType
               boundAccounts:(NSArray *)boundAccounts
                         token:(TDSGlobalUserToken *)token;

- (instancetype)initWithUserID:(NSInteger)userID
                           sub:(nullable NSString *)sub
                         tdsID:(nullable NSString *)tdsID
                          name:(nullable NSString *)name
                     loginType:(TDSGlobalSDKEntryType)loginType
                 boundAccounts:(NSArray *)boundAccounts
                         token:(TDSGlobalUserToken *)token
             pushServiceEnable:(BOOL)enable;

@end

NS_ASSUME_NONNULL_END
