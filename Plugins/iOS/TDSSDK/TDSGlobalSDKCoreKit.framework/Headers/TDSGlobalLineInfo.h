//
//  TDSGlobalLineInfo.h
//  TDSGlobalSDKCoreKit
//
//  Created by JiangJiahao on 2020/11/10.
//

#import <Foundation/Foundation.h>

NS_ASSUME_NONNULL_BEGIN

@interface TDSGlobalLineInfo : NSObject
@property (nonatomic) NSString *channelId;
+ (instancetype)instanceWithInfoDic:(NSDictionary *)infoDic;
@end

NS_ASSUME_NONNULL_END
