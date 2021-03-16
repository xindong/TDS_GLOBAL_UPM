# TDSGlobal-iOS

## 1.接入前准备

### 1.1 TDSGlobalSDK说明
TDSGlobalSDK支持登录和支付功能，**最低iOS版本为iOS10**.以下framework为**静态库**。

	TDSGlobalSDKCoreKit.framework 	TDSGlobalSDK核心组件
	TDSGlobalSDKLoginKit.framework 	TDSGlobalSDK登录组件
	TDSGlobalSDKIAPKit.framework	TDSGlobalSDK支付组件
	
### 1.2 添加TDSGlobalSDK
将配置文件**TDSGlobalGlobal-Info.plist**加入工程。
#### 1.2.1 添加TDSGlobalSDK文件
* 将**TDSGlobalSDKCoreKit.framework**和**TDSGlobalSDKLoginKit.framework**添加到项目，确保Link Binary With Libraries中已添加。

* 将**TDSGlobalDKResources.bundle**添加到项目，确保Copy Bundler Resources中已添加

* 支付组件**TDSGlobalSDKIAPKit.framework**视游戏需要添加

* 由于第三方组件中有使用Swift开发部分，纯Objective-C项目需要打开Swift编译器，可在项目中添加Swift文件。将**Blank.swift**添加到项目

	
#### 1.2.2 添加libs文件

* 将libs中所有framework文件添加到项目，确保Link Binary With Libraries中已添加。

* 将libs中所有bundle文件添加到项目，确保Copy Bundler Resources中已添加
	
### 1.3 添加系统依赖库
请检查项目中是否已自动添加以下依赖项：

	AdSupport.framework
	LocalAuthentication.framework
	AuthenticationServices.framework
	SystemConfiguration.framework
	Accelerate.framework
	SafariServices.framework
	Webkit.framework
	CoreTelephony.framework
	Security.framework
	libc++.tdb


### 1.4 配置编译选项
**在Build Setting中的Other Link Flag中添加-ObjC**

**在Build Setting中的Always Embed Swift Standard Libraried设置为YES**

在**Capabilities**中打开以下功能

<img src="./DocImages/capabilities.jpg"></img>


### 1.5 配置URL Types
选择应用**TARGETS**，点击**Info**标签，展开**URL Types**。添加以下几项 URL Scheme.大括号内为游戏App对应参数，在开发者后台获取。

	TapTap	:	tt{taptap-client-id}
	Facebook:	fb{facebook-app-id}
	Google	:	{google-client-id}
	Line	: 	line3rdp.{product_bundle_identify}

### 1.6 配置Schemes
在应用的info.plist中配置以下内容。
	
	<key>LSApplicationQueriesSchemes</key>
	<array>
	  <string>tapsdk</string>
	  <string>tapiosdk</string>
	  <string>fbapi</string>
	  <string>fbapi20130214</string>
	  <string>fbapi20130410</string>
	  <string>fbapi20130702</string>
	  <string>fbapi20131010</string>
	  <string>fbapi20131219</string>
	  <string>fbapi20140410</string>
	  <string>fbapi20140116</string>
	  <string>fbapi20150313</string>
	  <string>fbapi20150629</string>
	  <string>fbapi20160328</string>
	  <string>fbauth</string>
	  <string>fb-messenger-share-api</string>
	  <string>fbauth2</string>
	  <string>fbshareextension</string>
	  <string>lineauth2</string>
	</array>

## 2.TDSGlobalSDK使用说明

### 2.1 TDSGlobalSDK配置

#### 2.1.1 配置与初始化

在AppDelegate.m中,引入头文件

	#import <TDSGlobalSDKCoreKit/TDSGlobalSDK.h>

在以下接口中添加调用,并**初始化SDK**,游戏可调整初始化时机，建议尽早。

	- (BOOL)application:(UIApplication *)application didFinishLaunchingWithOptions:(NSDictionary *)launchOptions {
		/* 初始化 */
		[TDSGlobalSDK initTDSGlobalSDK:^(BOOL success) {
	        if (success) {
	            NSLog(@"Init success");
	        }else {
	            NSLog(@"Init fail");
	        }
		}];
	 	[TDSGlobalSDK application:application didFinishLaunchingWithOptions:launchOptions];
	 	...
	}
	
	- (BOOL)application:(UIApplication *)application
            openURL:(NSURL *)url sourceApplication:(NSString *)sourceApplication
         annotation:(id)annotation {
    	[TDSGlobalSDK application:application openURL:url sourceApplication:sourceApplication annotation:annotation];
    	...
    }
    
    - (BOOL)application:(UIApplication *)app openURL:(NSURL *)url options:(NSDictionary<UIApplicationOpenURLOptionsKey, id> *)options{
    	[TDSGlobalSDK application:app openURL:url options:options];
    	...
    }

	- (BOOL)application:(UIApplication *)application continueUserActivity:(NSUserActivity *)userActivity restorationHandler:(void (^)(NSArray<id<UIUserActivityRestoring>> * _Nullable))restorationHandler {
		[TDSGlobalSDK application:application continueUserActivity:userActivity restorationHandler:restorationHandler];
		...
    }

	- (void)application:(UIApplication *)application didReceiveRemoteNotification:(NSDictionary *)userInfo fetchCompletionHandler:(void (^)(UIBackgroundFetchResult))completionHandler {
		...
    	[TDSGlobalSDK application:application didReceiveRemoteNotification:userInfo fetchCompletionHandler:completionHandler];
    }
    
如果您的应用使用Scene管理App生命周期，在以下接口中添加调用

	- (void)scene:(UIScene *)scene openURLContexts:(NSSet<UIOpenURLContext *> *)URLContexts API_AVAILABLE(ios(13.0)){
    	[TDSGlobalSDK scene:scene openURLContexts:URLContexts];
    }

	- (void)scene:(UIScene *)scene continueUserActivity:(NSUserActivity *)userActivity  API_AVAILABLE(ios(13.0)){
    	[TDSGlobalSDK scene:scene continueUserActivity:userActivity];
    }

#### 2.1.2 设置SDK显示语言

可以调用以下接口设置SDK显示语言

	+ (void)setLanguage:(TDSGlobalLanguageLocale)locale;

TDSGlobalLanguageLocale说明

参数 | 说明
---|---|
TDSGlobalLanguageLocaleSimplifiedChinese | 简体中文
TDSGlobalLanguageLocaleTraditionalChinese | 繁体中文
TDSGlobalLanguageLocaleEnglish | 英文
TDSGlobalLanguageLocaleThai | 泰文
TDSGlobalLanguageLocaleBahasa | 印尼文


### 2.1 登录
TDSGlobalSDK支持使用以下方式进行登录

登录方式 | 说明
---|---|
TapTap | 
Apple | iOS13以上支持
Google | 
Facebook | 
Guest | 游客登录
Line | 开发中
Twitter | 开发中


引入头文件

	#import <TDSGlobalSDKLoginKit/TDSGlobalLoginManager.h>
	#import <TDSGlobalSDKCoreKit/TDSGlobalUser.h>
	#import <TDSGlobalSDKCoreKit/TDSGlobalUserToken.h>

调用以下接口
	
	// 调用登录
    [TDSGlobalLoginManager login:^(TDSGlobalUser * _Nullable result, NSError * _Nullable error) {
	    NSLog(@"result:%@,error:%@",result,error);
	    if (error) {
	        // login fail;
	    }else {
	        // login success;
	    }
    }];
    
    // 监听用户状态改变
    [TDSGlobalLoginManager addUserStatusChangeCallback:^(TDSGlobalUserStateChangeCode userStateChangeCode) {
        if (userStateChangeCode == TDSGlobalUserStateChangeCodeBindStateChange) {
        	// user bind state change
        }else if (userStateChangeCode == TDSGlobalUserStateChangeCodeLogout) {
			// user logged out
        }
    }];
    
    // 打开用户中心
    [TDSGlobalLoginManager userCenter];
    
    // 登出当前用户
    [TDSGlobalLoginManager logout];
 
 **用户数据TDSGlobalUser说明**
 
 	@interface TDSGlobalUser : NSObject <NSCoding>
	/**
	The user's user ID.
	*/
	@property (nonatomic,assign) NSInteger userId;
	
	/**
	The user’s user ID in string.
	*/
	@property (nonatomic,copy) NSString *sub;
	
	/**
	The user's user name.
	*/
	@property (nonatomic,copy) NSString *name;
	
	/**
	The user's token.
	*/
	@property (nonatomic,strong) TDSGlobalUserToken *token;
	
	@end
 
**用户TDSGlobalUserToken说明**

	@interface TDSGlobalUserToken : NSObject
	/// 唯一标志
	@property (nonatomic, copy) NSString *kid;
	
	/// 认证码
	@property (nonatomic, copy) NSString *accessToken;
	
	/// 认证码类型
	@property (nonatomic, copy) NSString *tokenType;
	
	/// mac密钥
	@property (nonatomic, copy) NSString *macKey;
	
	/// mac密钥计算方式
	@property (nonatomic, copy) NSString *macAlgorithm;
	
	/// 用户授权的权限，多个时以逗号隔开（预留字段）
	@property (nonatomic, copy) NSString *scope;
	
	@end

### 2.2 支付

#### 2.2.1 支付商品
引入头文件

	#import <TDSGlobalSDKIAPKit/TDSGlobalInAppPurchaseManager.h>

调用以下接口
	
	[TDSGlobalInAppPurchaseManager payWithOrderId:@"orderId" productId:@"productId" roleId:@"roleId" serverId:@"serverId" ext:@"ext" completionHandler:^(NSDictionary * _Nonnull orderInfo, NSError * _Nonnull error) {
        if (error) {
        	// pay fail, handler error
        }else {
        	// pay success
        }
    }];
    
支付接口参数说明

参数 | 说明
---|---|
orderId | 订单ID。游戏侧订单号，服务端支付回调会包含该字段
productId | 商品ID。到AppStore购买的商品ID
roleId | 角色ID。支付角色ID，服务端支付回调会包含该字段
serverId | 服务器ID。所在服务器ID，不能有特殊字符，服务端支付回调会包含该字段
ext | 透传参数。服务端支付回调会包含该字段。可用于标记区分充值回调地址，如需使用该功能，请联系平台进行配置。
    
#### 2.2.2 查询商品信息

引入头文件
	
	#import <TDSGlobalSDKIAPKit/TDSGlobalProductInfo.h>
	
可以调用以下接口,**传入需要查询的商品ID数组**，查询商品信息

	[TDSGlobalInAppPurchaseManager queryWithProductIds:@[@"productId1",@"productId2"] completionHandler:^(NSArray<TDSGlobalProductInfo *> * _Nullable result, NSError * _Nullable error) {
        // handle result
    }];
    
商品信息TDSGlobalProductInfo包含的信息和SKProduct一致。
	
	@interface TDSGlobalProductInfo : NSObject
		@property(nonatomic,strong,readonly) NSString *localizedDescription;
		
		@property(nonatomic,strong,readonly) NSString *localizedTitle;
	
		@property(nonatomic,strong,readonly) NSDecimalNumber *price;
	
		@property(nonatomic,strong,readonly) NSLocale *priceLocale;
	
		@property(nonatomic,strong,readonly) NSString *productIdentifier;

	@end
	
    
#### 2.2.3 查询礼包码
引入以下头文件

	#import <TDSGlobalSDKIAPKit/TDSGlobalTransactionInfo.h>

可以调用以下接口查询用户是否兑换了商品礼包码，**某些特殊情况的掉单也会在该接口返回**
	
	[TDSGlobalInAppPurchaseManager queryRestoredPurchases:^(NSArray<TDSGlobalTransactionInfo *> * _Nonnull result) {
        // handle result
    }];
 
 TDSGlobalTransactionInfo 包含了部分 SKPaymentTransaction 信息
 
 	@interface TDSGlobalTransactionInfo : NSObject
		// The unique server-provided identifier
		@property (nonatomic,strong,readonly) NSString *transactionIdentifier;
		
		@property (nonatomic,strong,readonly) NSString *productIdentifier;

	@end
	
在查询到结果后，可以调用以下接口，传入必要参数完成交易，**参数说明同2.2.1节**支付。

	[TDSGlobalInAppPurchaseManager restorePurchase:transactionInfo orderId:@"orderId" roleId:@"roleId" serverId:@"serverId" ext:@"ext" completionHandler:^(NSDictionary * _Nonnull orderInfo, NSError * _Nonnull error) {
        // handle result
    }];
	
### 2.3 客服反馈
引入头文件

	#import <TDSGlobalSDKCoreKit/TDSGlobalSDK.h>
用户**登录成功以后**，可以使用客服反馈功能.

    [TDSGlobalSDK reportWithServerId:@"serverId" roleId:@"roleId" roleName:@"roleName"];

    
 参数 | 说明
---|---|
serverId | 服务器ID，可为空
roleId | 角色ID，可为空
roleName | 角色名，可为空

## 3.可选功能
以下功能游戏根据需要进行调用
### 3.1 分享

	#import <TDSGlobalSDKCoreKit/TDSGlobalShareManager.h>

**支持分享图片与URL**，调用接口：

	// URL分享
	[TDSGlobalShareManager shareWithType:TDSGlobalShareTypeFacebook url:@"https://www.taptap.com/" message:@"taptap" completeHandler:^(NSError * _Nullable error, BOOL cancel) {
	    if (error) {
	        // fail
	    }else {
			// success
	    }
	}];
	
	// 图片分享
	[TDSGlobalShareManager shareWithType:TDSGlobalShareTypeFacebook image:shareImage completeHandler:^(NSError * _Nullable error, BOOL cancel) {
            if (error) {
		        // fail
            }else {
				// success
            }
     }];
     
 分享平台类型TDSGlobalShareType说明
 
  参数 | 说明
---|---|
TDSGlobalShareTypeFacebook | 分享到Facebook
 

### 3.2 数据跟踪

	#import <TDSGlobalSDKCoreKit/TDSGlobalTrackManager.h>

支持简单数据追踪，调用接口：

	/// 跟踪玩家
	/// @param roleId 角色ID
	/// @param roleName 角色名
	/// @param serverId 服务器ID
	/// @param level 玩家等级
	[TDSGlobalTrackManager trackUser:@"roleId" roleName:@"roleName" serverId:@"serverId" level:0];
	
	/// 跟踪自定义事件
	/// @param eventName 事件名
    [TDSGlobalTrackManager trackEvent:@"eventName"];
    
    /// 跟踪完成成就
    [TDSGlobalTrackManager trackAchievement];
    
    /// 跟踪完成新手引导接口
    [TDSGlobalTrackManager eventCompletedTutorial];
    
    /// 跟踪完成创角
    [TDSGlobalTrackManager eventCreateRole];
	