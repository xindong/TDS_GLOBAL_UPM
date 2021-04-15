
#import <Foundation/Foundation.h>
#import <UIKit/UIKit.h>

NS_ASSUME_NONNULL_BEGIN

typedef NS_ENUM(NSInteger,TDSGlobalShareType) {
    TDSGlobalShareTypeFacebook = 0,
    TDSGlobalShareTypeLine,
    TDSGlobalShareTypeTwitter,
};

typedef NS_ENUM(NSInteger,TDSGlobalShareErrorCode) {
    TDSGlobalShareErrorCodeNone         = 0,
    TDSGlobalShareErrorCodeFail         = 0x5001,
    TDSGlobalShareErrorCodeNotSupport   = 0x5002
};

typedef void(^TDSGlobalShareResultHandler)(NSError * _Nullable error, BOOL cancel);

@interface TDSGlobalShareManager : NSObject
/// 分享图片
/// @param type 分享平台类型
/// @param image 待分享图片
/// @param completeHandler 分享结果回调
+ (void)shareWithType:(TDSGlobalShareType)type image:(UIImage *)image completeHandler:(TDSGlobalShareResultHandler)completeHandler;

/// 分享图片
/// @param type 分享平台类型
/// @param imagePath 待分享图片沙盒路径
/// @param completeHandler 分享结果回调
+ (void)shareWithType:(TDSGlobalShareType)type imagePath:(NSString *)imagePath completeHandler:(TDSGlobalShareResultHandler)completeHandler;

/// 分享URL
/// @param type 分享平台类型
/// @param url 待分享URL
/// @param completeHandler 分享结果回调
+ (void)shareWithType:(TDSGlobalShareType)type url:(NSString *)url completeHandler:(TDSGlobalShareResultHandler)completeHandler;

/// 分享URL
/// @param type 分享平台类型
/// @param url 待分享URL
/// @param message 文字说明
/// @param completeHandler 分享结果回调
+ (void)shareWithType:(TDSGlobalShareType)type url:(NSString *)url message:(nullable NSString *)message completeHandler:(TDSGlobalShareResultHandler)completeHandler;


@end

NS_ASSUME_NONNULL_END
