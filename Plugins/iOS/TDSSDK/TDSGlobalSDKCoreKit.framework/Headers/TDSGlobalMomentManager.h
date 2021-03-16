#import <Foundation/Foundation.h>

NS_ASSUME_NONNULL_BEGIN

typedef NS_ENUM (NSInteger, TDSGlobalMomentOrientation) {
    TDSGlobalMomentOrientationDefault   = -1,
    TDSGlobalMomentOrientationLandscape = 0,
    TDSGlobalMomentOrientationPortrait  = 1,
};

@interface TDSGlobalMomentConfig : NSObject

/// orientation of moment,default is landscape
@property (nonatomic, assign) TDSGlobalMomentOrientation orientation;

@end

typedef NS_ENUM(NSInteger,TDSGlobalMomentCallbackCode) {
    TDSGlobalMomentCallbackCodePostSucceed              = 10000,        // 动态发布成功
    TDSGlobalMomentCallbackCodePostFailed               = 10100,        // 动态发布失败
    TDSGlobalMomentCallbackCodePostClosed               = 10200,        // 关闭动态发布页面
    TDSGlobalMomentCallbackCodeFetchNewMessageSucceed   = 20000,        // 获取新消息成功
    TDSGlobalMomentCallbackCodeFetchNewMessageFailed    = 20100,        // 获取新消息失败
    TDSGlobalMomentCallbackCodePageOpened               = 30000,        // 动态页面打开
    TDSGlobalMomentCallbackCodePageClosed               = 30100,        // 动态页面关闭
    TDSGlobalMomentCallbackCodeCancelClose              = 50000,        // 取消关闭所有动态界面（弹框点击取消按钮）
    TDSGlobalMomentCallbackCodeConfirmClose             = 50100,        // 确认关闭所有动态界面（弹框点击确认按钮
    TDSGlobalMomentCallbackCodeLoginSucceed             = 60000,        // 动态页面内登录成功
};
typedef void(^TDSGlobalMomentCallbackHandler)(NSInteger code, NSString *msg);

/**
 只支持TapTap登录时或绑定TapTap账号以后使用
 */
@interface TDSGlobalMomentManager : NSObject
/// 注册回调处理
/// @param handler 回调，code 见上枚举
+ (void)registerCallbackHandler:(TDSGlobalMomentCallbackHandler)handler;

/// 打开动态页面
/// @param config 动态配置，横竖屏等
+ (void)openTapMomentWithConfig:(TDSGlobalMomentConfig *) config;

/// 直接打开发布图片动态页面
/// @param imagesPathArray 图片地址
/// @param content 图片说明内容
/// @param config 动态页面配置，横竖屏等
+ (void)postImages:(NSArray *)imagesPathArray
           content:(NSString *)content
      momentConfig:(TDSGlobalMomentConfig *)config;

/// 直接打开发布视频动态页面
/// @param videosPathArray 视频地址
/// @param imagesPathArray 图片地址
/// @param title 动态标题
/// @param content 动态内容
/// @param config 动态页面配置，如横竖屏
+ (void)postVideos:(NSArray *)videosPathArray
            images:(NSArray *)imagesPathArray
             title:(NSString *)title
           content:(NSString *)content
      momentConfig:(TDSGlobalMomentConfig *)config;

/// 获取新动态消息数量
/// callback code = TM_RESULT_CODE_NEW_MSG_SUCCEED
+ (void)fetchNewMessage;

+ (void)closeMoment;

+ (NSString *)getMomentVersion;
@end

NS_ASSUME_NONNULL_END
