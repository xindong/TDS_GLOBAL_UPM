
#import <Foundation/Foundation.h>

NS_ASSUME_NONNULL_BEGIN

@interface TDSGlobalTrackManager : NSObject
/// 跟踪玩家
/// @param roleId 角色ID
/// @param roleName 角色名
/// @param serverId 服务器ID
/// @param level 玩家等级
+ (void)trackUser:(NSString *)roleId
         roleName:(NSString *)roleName
         serverId:(NSString *)serverId
            level:(NSInteger)level;

/// 跟踪自定义事件
/// @param eventName 事件名
+ (void)trackEvent:(NSString *)eventName;

/// 跟踪完成成就
+ (void)trackAchievement;

/// 跟踪完成新手引导接口
+ (void)eventCompletedTutorial;

/// 跟踪完成创角
+ (void)eventCreateRole;

@end

NS_ASSUME_NONNULL_END
