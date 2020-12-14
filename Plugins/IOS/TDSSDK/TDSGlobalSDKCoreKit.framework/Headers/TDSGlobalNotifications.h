
#import <Foundation/Foundation.h>

NS_ASSUME_NONNULL_BEGIN

extern NSString *const TDS_LOGIN_SUCCESS_NOTIFICATION;
extern NSString *const TDS_LOGIN_FAIL_NOTIFICATION;

extern NSString *const TDS_LOGOUT_SUCCESS_NOTIFICATION;

extern NSString *const TDS_BIND_SUCCESS_NOTIFICATION;
extern NSString *const TDS_BIND_FAIL_NOTIFICATION;

extern NSString *const TDS_UNBIND_SUCCESS_NOTIFICATION;
extern NSString *const TDS_UNBIND_FAIL_NOTIFICATION;

/*
 支付
 */
extern NSString *const TDS_PAY_SUCCESS_NOTIFICATION;
extern NSString *const TDS_PAY_FAIL_NOTIFICATION;

extern NSString *const TDS_RECEIPT_SEND_SUCCESS_NOTIFICATION;
extern NSString *const TDS_RECEIPT_SEND_FAIL_NOTIFICATION;
@interface TDSGlobalNotifications : NSObject

@end

NS_ASSUME_NONNULL_END
