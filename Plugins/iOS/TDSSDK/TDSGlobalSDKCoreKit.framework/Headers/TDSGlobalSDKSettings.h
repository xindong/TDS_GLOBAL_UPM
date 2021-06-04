

#import <Foundation/Foundation.h>

NS_ASSUME_NONNULL_BEGIN
typedef NS_ENUM(NSInteger,TDSGlobalLanguageLocale) {
    TDSGlobalLanguageLocaleSimplifiedChinese = 0,                 // 简体中文
    TDSGlobalLanguageLocaleTraditionalChinese,                    // 繁体中文
    TDSGlobalLanguageLocaleEnglish,                               // 英文
    TDSGlobalLanguageLocaleThai,                                  // 泰文
    TDSGlobalLanguageLocaleBahasa,                                // 印尼文
    TDSGlobalLanguageLocaleKorean,                                // 韩文
    TDSGlobalLanguageLocaleJapanese,                              // 日文
    TDSGlobalLanguageLocaleGerman,                                // 德语
    TDSGlobalLanguageLocaleFrench,                                // 法语
    TDSGlobalLanguageLocalePortuguese,                            // 葡萄牙语
    TDSGlobalLanguageLocaleSpanish,                               // 西班牙语
    TDSGlobalLanguageLocaleTurkish,                               // 土耳其语
    TDSGlobalLanguageLocaleRussian,                               // 俄语
};

/// SDK Settings
@interface TDSGlobalSDKSettings : NSObject
/// 是否开启收集广告标识符 IDFA,将会开启和关闭所有第三方 SDK 收集。 请在最早调用（任何 SDK 调用之前）
/// @param enable YES: 开启 NO: 关闭。 默认 NO
+ (void)setAdvertiserIDCollectionEnable:(BOOL)enable;

/// 设置调试模式，debug 会输出SDK日志
/// @param debug 是否 debug 模式。默认 NO
+ (void)setDebugMode:(BOOL)debug;

/// 设置SDK显示语言
/// @param locale 语言，在 TDSGlobalLanguageLocale 枚举中查看
+ (void)setLanguage:(TDSGlobalLanguageLocale)locale;
@end

NS_ASSUME_NONNULL_END
