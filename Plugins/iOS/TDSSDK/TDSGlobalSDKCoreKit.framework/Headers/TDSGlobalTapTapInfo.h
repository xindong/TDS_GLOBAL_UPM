//
//  TDSGlobalTapTapInfo.h
//  TDSGlobalSDKCoreKit
//
//  Created by JiangJiahao on 2020/11/4.
//

#import <Foundation/Foundation.h>

NS_ASSUME_NONNULL_BEGIN

@interface TDSGlobalTapTapInfo : NSObject

@property (nonatomic) NSString *clientId;
@property (nonatomic) NSString *clientSecret;

@property (nonatomic) BOOL tapdbEnabled;

@property (nonatomic) BOOL momentEnabled;

+ (instancetype)instanceWithInfoDic:(NSDictionary *)infoDic;
@end

NS_ASSUME_NONNULL_END
