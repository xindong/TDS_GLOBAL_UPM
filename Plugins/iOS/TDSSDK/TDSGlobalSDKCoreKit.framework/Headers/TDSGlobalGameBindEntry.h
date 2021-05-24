//
//  TDSGlobalGameBindEntry.h
//  TDSGlobalSDKCoreKit
//
//  Created by JiangJiahao on 2021/5/19.
//

#import <Foundation/Foundation.h>
#import <TDSGlobalSDKCoreKit/TDSGlobalEntryType.h>

NS_ASSUME_NONNULL_BEGIN

@interface TDSGlobalGameBindEntry : NSObject
@property (nonatomic,copy) NSString *entryName;
@property (nonatomic,assign) TDSGlobalSDKEntryType type;
@property (nonatomic,assign) BOOL canUnbind;
@property (nonatomic,assign) BOOL canBind;
 
@end

NS_ASSUME_NONNULL_END
