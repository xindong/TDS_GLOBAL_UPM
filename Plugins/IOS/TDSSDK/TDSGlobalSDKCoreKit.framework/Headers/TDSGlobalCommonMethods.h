
//  工具类 公用方法

#import <Foundation/Foundation.h>
#import <UIKit/UIKit.h>


NS_ASSUME_NONNULL_BEGIN

@interface TDSGlobalCommonMethods : NSObject
+ (NSBundle *)bundle;


/// 计算字符串长度
/// @param string 字符串
/// @param fontSize 字体大小
/// @param height VIEW高度
+ (CGFloat)calculateRowWidth:(NSString *)string fontSize:(CGFloat)fontSize height:(CGFloat)height;

/// 获取自定义错误
/// @param domain 错误domain
/// @param errorCode 错误码
/// @param errorDesc 错误描述
+ (NSError *)customError:(NSString * _Nullable)domain code:(NSInteger)errorCode desc:(NSString *)errorDesc;

+ (void)addShadowToView:(UIView *)targetView innerShadowColor:
(int)innerShadowColor outerShadowColor:(int)outerShadowColor shadowOffset:(CGSize)shadowOffset;
@end

NS_ASSUME_NONNULL_END
