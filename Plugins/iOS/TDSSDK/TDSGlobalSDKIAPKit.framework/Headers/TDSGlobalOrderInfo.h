#import <Foundation/Foundation.h>

NS_ASSUME_NONNULL_BEGIN

/** TDSGlobal 平台订单信息 */
@interface TDSGlobalOrderInfo : NSObject
/// 游戏侧订单号
@property (nonatomic,copy,readonly) NSString *gameOrderId;
/// 商品 ID
@property (nonatomic,copy,readonly) NSString *productIdentifier;
/// 角色所在服务器 ID
@property (nonatomic,copy,readonly) NSString *serverId;
/// 角色ID
@property (nonatomic,copy,readonly) NSString *roleId;
/// 当前订单所用货币
@property (nonatomic,copy,readonly) NSString *currency;
/// 当前订单价格
@property (nonatomic,strong,readonly) NSDecimalNumber *price;

+ (TDSGlobalOrderInfo *)createOrderInfo:(NSDictionary *)orderInfo;
@end

NS_ASSUME_NONNULL_END
