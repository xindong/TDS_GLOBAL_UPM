
#import <Foundation/Foundation.h>

@class TDSGlobalGame;

NS_ASSUME_NONNULL_BEGIN
@interface TDSGlobalGameDataManager : NSObject
+ (TDSGlobalGameDataManager *)shareInstance;

+ (TDSGlobalGame *)currentGameData;
+ (NSArray *)currentLoginEntries;
+ (NSArray *)currentBindEntries;
+ (NSString *)serviceTermsUrl;
+ (NSString *)serviceAgreementUrl;
+ (NSString *)californiaPrivacyUrl;
+ (NSArray *)gameLogos;


+ (void)setLanguageLocale:(NSInteger)locale;

+ (void)getClientConfig:(void (^)(BOOL success))handler;

/// 是否已经初始化
+ (BOOL)isGameInited;
/// 是否需要客服
+ (BOOL)needReportService;
#pragma mark - configs
+ (BOOL)isGameInKorea;
+ (BOOL)isGameInNA;

+ (BOOL)googleEnable;
+ (BOOL)facebookEnable;
+ (BOOL)taptapEnable;
+ (BOOL)tapdbEnable;
+ (BOOL)adjustEnable;
+ (BOOL)appsflyersEnable;
+ (BOOL)lineEnable;
@end

NS_ASSUME_NONNULL_END
