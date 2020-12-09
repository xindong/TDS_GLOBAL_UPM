
#import <Foundation/Foundation.h>

NS_ASSUME_NONNULL_BEGIN

typedef NS_ENUM(NSInteger,TDSGlobalShareType) {
    TDSGlobalShareTypeFacebook = 0,
};

typedef void(^TDSGlobalShareResultHandler)(NSError * _Nullable error, BOOL cancel);

@interface TDSGlobalShareManager : NSObject
/// 分享图片
/// @param type 分享平台类型
/// @param image 待分享图片
/// @param completeHandler 分享结果回调
+ (void)shareWithType:(TDSGlobalShareType)type image:(UIImage *)image completeHandler:(TDSGlobalShareResultHandler)completeHandler;

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
+ (void)shareWithType:(TDSGlobalShareType)type url:(NSString *)url message:(NSString *)message completeHandler:(TDSGlobalShareResultHandler)completeHandler;


@end

NS_ASSUME_NONNULL_END
