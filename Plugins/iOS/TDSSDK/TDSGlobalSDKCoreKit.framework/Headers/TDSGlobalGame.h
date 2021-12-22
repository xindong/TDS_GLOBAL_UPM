
//  游戏数据

#import <Foundation/Foundation.h>
#import "TDSGlobalGameBindEntry.h"

NS_ASSUME_NONNULL_BEGIN

@interface TDSGlobalGame : NSObject
@property (nonatomic,copy) NSString *clientId;

@property (nonatomic,copy) NSString *region;                         // 发行地区
@property (nonatomic,copy) NSString *developerId;                    // 开发者ID
@property (nonatomic,copy) NSString *appId;

@property (nonatomic,strong) NSMutableArray *loginEntries;           // 登录入口
@property (nonatomic,strong) NSMutableArray *bindEntriesConfig;      // 绑定入口配置


@property (nonatomic,copy) NSString *reportUrl;                      // 客服地址

@property (nonatomic,assign) NSInteger languageLocale;               // 语言

/**
 协议
 */
@property (nonatomic,copy) NSString *serviceTermsUrl;
@property (nonatomic,copy) NSString *serviceAgreementUrl;
@property (nonatomic,copy) NSString *californiaPrivacyUrl;

- (void)updateBindEntriesConfig:(NSArray *)config;

@end

NS_ASSUME_NONNULL_END
