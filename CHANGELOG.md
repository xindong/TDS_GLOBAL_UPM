# ChangeLog

## v1.3.0

### New Feature

- 客服中心新增支持选择视频类型文件
- TDSGlobalUser 新增 tdsId, 使用 taptap 登录时可获取，其他情况为空

### BugFix

* iOS 修复 Twitter 登陆错误问题

### BreakingChanges

- Remove TapSDK v1.1.6

### Dependencies

- TapTap.Bootstrap v2.1.6
- TapTap.Login v2.1.6
- TapTap.Common v2.1.6
- TapTap.TapDB v2.1.6

## v1.2.0

### Feature

* iOS 登录界面底部 Logo 尺寸改为 62*14,建议用 3x 图保证清晰度
* iOS 韩国地区协议界面推送通知开关默认改为 关闭
* iOS libs 更新，FacebookSDK 更新为 9.3.0 ； TwitterLoginKit 更新
* iOS 新增 TDSGlobalSDKSettings 类，SDK 相关配置调用类方法
* iOS 支持 Bitcode
* 登录弹窗LOGO放大
* Android TapDB初始化参数更换
* 补款流程订单新增 UserId
* 上报角色名称修改
* 韩国法务合规逻辑变更
* 新增支付成功事件打点
* 添加 Firebase Performance Monitoring 监控

### BugFix

* iOS 修复 IDFA 开关无效 bug

### Dependencies

* TapSDk v1.1.6

## v1.1.6

### BugFix

* 修复 Android Bridge 方法匹配错误

### Dependencies

* TapSDK v1.1.6

## v1.1.5

### Feature

*  部分日文翻译更改
*  登录界面默认展开所有登录方式
*  可配置账号中心解绑绑定开关（是否显示解绑按钮）
*  账号安全中心的解绑/绑定/删除账号功能由后端字段控制
* iOS Appsflyer 升级

### Dependencies
* TapSDK v1.1.6

## v1.1.4

### BugFix
* 修复 iOS 查询商品时 JSON 解析错误导致的崩溃
* 修复 iOS ALWAYS_EMBED_SWIFT_STANDARD_LIBRARIES 设置问题可能导致的 AppStore 审核无法通过
### Dependencies
* TapSDK v1.1.6

## v1.1.3

### Feature 

* 新增 Firebase Crashlytics
* 新增 IDFA 开关
* Android support library migrate to AndroidX
* 多语言 日语部分更新

### Dependencies

* TapSDK v1.1.5

## v1.1.2

### Feature

- 更新 iOS Twitter 

## v1.1.1

### Feature

- 更新 iOS AppsFlyer 

## v1.1.0

### Feature

- 新增自定义登陆接口
- tds 域名切换 
- 支持海外域名动态切换
- 网络稳定性日志上报
- 登陆新增 twitter、Line
- 分享新增 twitter、Line

### BugFix

- 修复 TapDB 数据上报错误

### Dependencies

- TapSDK 1.1.2