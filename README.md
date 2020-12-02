# TDSGlobalUnity

### 前提条件

* 安装Unity **5.6.4**或更高版本

* IOS **10**或更高版本

* Android 目标为**API19**或更高版本

### 1.添加TDSGlobal Unity SDK

使用Unity Package Manager 添加SDK到项目中。
```json
//在Packages/manifest.json 中添加TDSGlobalUnity SDK
{
    "dependencies":{
        "com.tds.global":"https://github.com/xindong/TDS_GLOABL_UPM#{verison}",
    }
}
```

### 2.添加配置文件

### 3.接口使用

#### 3.1 初始化

```c#
TDSGlobal.TDSGlobalSDK.Init((success)=
{
    // 是否初始化成功
});
```

#### 3.2 设置SDK语言

```c#
TDSGlobal.TDSGlobalSDK.SetLanguage(TDSGlobal.TDSGlobalLanguage.ZH_CN);
```
##### 语言类型说明

```c#
public class TDSGlobalLanguage
{
    //简体
    public static int ZH_CN = 0;
    //繁体
    public static int ZH_TW = 1;
    //英文
    public static int EN = 2;
    //泰文
    public static int TH = 3;
    //印尼
    public static int ID = 4;
}
```

#### 3.3 用户

##### 3.3.1 登陆
```c#
TDSGlobal.TDSGlobalSDK.Login((tdsUser)=
{
    //返回用户信息
},(tdsError)=>
{
    //登陆失败
});
```

##### 3.3.2 获取用户信息
```c#
TDSGlobal.TDSGlobalSDK.GetUser((tdsUser)=
{
    //返回用户信息
},(tdsError)=>
{
    //获取失败
});
```
##### 3.3.3 添加用户状态回调
```c#
TDSGlobal.TDSGlobalSDK.AddUserStatusChangeCallback((code)=
{

});
```
##### 3.3.4用户中心
```c#
TDSGlobal.TDSGlobalSDK.UserCenter();
```

##### 用户信息说明

```c#
public class TDSGlobalUser
{
    [Serializable]
    public class TDSGlobalUser
    {   
        // user id
        public string id;
        // user id in string
        public string sub;
        // use Name
        public string name;
        // Token
        public TDSGlobalAccessToken token;
    
    }

    [Serializable]
    public class TDSGlobalAccessToken
    {
        //认证码
        public string accessToken;
        //唯一标示
        public string kid;
        //mac密钥
        public string macKey;
        //mac密钥计算方式
        public string macAlgorithm;
        //认证码类型
        public string tokenType;
        
    }
}
```

#### 3.4 支付

##### 3.4.1 购买商品
```c#
/*
 * orderId 订单ID。游戏侧订单号，服务端支付回调会包含该字段
 * productId 商品ID。到AppStore购买的商品ID
 * roleId 角色ID。支付角色ID，服务端支付回调会包含该字段
 * serverId 服务器ID。所在服务器ID，不能有特殊字符，服务端支付回调会包含该字段
 * ext 透传参数。服务端支付回调会包含该字段。可用于标记区分充值回调地址，如需使用该功能，请联系平台进行配置。
 */
TDSGlobal.TDSGlobalSDK.PayWithProduct(orderId,productId,roleId,serverId,ext,(orderInfo)=>
{
    //支付成功
},(tdsError)=>
{
    //支付失败
});
```

##### 3.4.2 查询商品信息
```c#
/**
 * productIds 查询的商品Id数组
 */
TDSGlobal.TDSGlobalSDK.QueryWithProductIds(productIds,(skuList)=>
{
    //返回商品 TDSGlobalSkuDetail list
},(tdsError)=>
{
    //查询失败
});
```

##### 3.4.3 查询未完成的订单
```c#
TDSGlobal.TDSGlobalSDK.QueryRestoredPurchases((transactions)=>
{
    // 返回结果
});
```

##### 3.4.4 网页支付(Android)
```c#
TDSGlobal.TDSGlobalSDK.PayWithWeb(serverId,roleId,(tdsError)=>{
    // 返回结果
});
```

#### 3.5 客服反馈

```c#
TDSGlobal.TDSGlobalSDK.Report(serverId,roleId,roleName);
```

#### 3.6 分享

```c#
//分享回调
public interface TDSGlobalShareCallback
{
    void ShareSuccess();

    void ShareCancel();

    void ShareError(string error);
}

```

```c#
//分享URL和链接
TDSGlobal.TDSGlobalSDK.Share(shareType,url,message,tdsShareCallback);
//分享图片
TDSGlobal.TDSGlobalSDK.Share(shareType,imagePath,tdsShareCallback);
```

#### 3.7 日志上报

```c#
//用户信息上报
TDSGlobal.TDSGlobalSDK.TrackUser(roleId,roleName,serverId,level);
// 成就上报
TDSGlobal.TDSGlobalSDK.TrackAchievement()；
//创建角色
TDSGlobal.TDSGlobalSDK.EventCreateRole();
//完成新手指引
TDSGlobal.TDSGlobalSDK.EventCompletedTutorial();
```

#### 3.8 跳转到应用商店

```c#
TDSGlobal.TDSGlobalSDK.StoreReview();
```