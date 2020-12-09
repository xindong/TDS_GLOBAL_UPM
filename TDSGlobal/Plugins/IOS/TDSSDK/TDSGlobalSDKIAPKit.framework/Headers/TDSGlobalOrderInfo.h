#import <Foundation/Foundation.h>

NS_ASSUME_NONNULL_BEGIN

/*
 TDSGlobal 平台订单信息
 */
@interface TDSGlobalOrderInfo : NSObject

@property (nonatomic,copy) NSString *gameOrderId;
@property (nonatomic,copy) NSString *productIdentifier;
@property (nonatomic,copy) NSString *serverId;
@property (nonatomic,copy) NSString *roleId;
@property (nonatomic,copy) NSString *currency;
@property (nonatomic,strong) NSDecimalNumber *price;

+ (TDSGlobalOrderInfo *)createOrderInfo:(NSDictionary *)orderInfo;
@end

NS_ASSUME_NONNULL_END
