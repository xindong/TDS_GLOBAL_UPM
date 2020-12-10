
#import <Foundation/Foundation.h>


@class TDSGlobalProductInfo;
@class TDSGlobalTransactionInfo;
@class TDSGlobalOrderInfo;
NS_ASSUME_NONNULL_BEGIN
/**
 
 */
typedef void(^TDSGlobalQueryProductsResultHandler)(NSArray<TDSGlobalProductInfo *> *_Nullable result,NSError *_Nullable error);

/**
 
 */
typedef void(^TDSGlobalQueryRestoreProductsResultHandler)(NSArray<TDSGlobalTransactionInfo *> *result);

/**
 
 */
typedef void(^TDSGlobalInAppPurchaseResultHandler)(TDSGlobalOrderInfo *orderInfo,NSError *error);

@interface TDSGlobalInAppPurchaseManager : NSObject

/// 查询商品价格,请等待回调之后再做下一次查询，否则可能造成数据错乱
/// @param productIds 商品ID集合
/// @param completionHandler 查询结果处理
+ (void)queryWithProductIds:(NSArray *)productIds completionHandler:(TDSGlobalQueryProductsResultHandler)completionHandler;


/// 支付商品
/// @param orderId 商品ID
/// @param productId 商品ID
/// @param roleId 角色ID
/// @param serverId 服务器ID
/// @param ext 支付额外信息EXT
/// @param completionHandler 支付结果处理
+ (void)payWithOrderId:(NSString *)orderId
             productId:(NSString *)productId
                roleId:(NSString *)roleId
              serverId:(NSString *)serverId
                   ext:(NSString *)ext
     completionHandler:(TDSGlobalInAppPurchaseResultHandler)completionHandler;


/// 查询当前是否有未处理订单或者礼包码
/// @param completionHandler 查询结果处理
+ (void)queryRestoredPurchases:(TDSGlobalQueryRestoreProductsResultHandler)completionHandler;


/// 恢复一笔订单/礼包码
/// @param restoreTransaction 需要回复的订单信息，queryRestoredProducts回调中返回
/// @param orderId 商品ID
/// @param roleId 角色ID
/// @param serverId 服务器ID
/// @param ext 支付EXT信息
/// @param completionHandler 回调处理
+ (void)restorePurchase:(TDSGlobalTransactionInfo *)restoreTransaction
                orderId:(NSString *)orderId
                 roleId:(NSString *)roleId
               serverId:(NSString *)serverId
                    ext:(NSString *)ext
      completionHandler:(TDSGlobalInAppPurchaseResultHandler)completionHandler;

@end

NS_ASSUME_NONNULL_END
