using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SampleScene : MonoBehaviour, TDSGlobal.TDSGlobalShareCallback
{
    private string productId = "输入productId";

    private string productIds = "输入查询productId";

    private string logText = "";

    private string imagePath = "输入图片地址";

    // Start is called before the first frame update
    void Start()
    {
        Screen.orientation = ScreenOrientation.AutoRotation;
        Screen.autorotateToLandscapeLeft = true;
        Screen.autorotateToLandscapeRight = true;
        Screen.autorotateToPortrait = false;
        Screen.autorotateToPortraitUpsideDown = false;
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void CapturePic(string path)
    {
        ScreenCapture.CaptureScreenshot(path, 0);
    }


    public void ShareSuccess()
    {
        Debug.Log("分享成功");
        this.logText = "分享成功";
    }
    public void ShareCancel()
    {
        Debug.Log("分享取消");
        this.logText = "分享取消";
    }
    public void ShareError(string error)
    {
        Debug.Log("分享失败:" + error);
        this.logText = "分享失败" + error;
    }

    private void OnGUI()
    {
        GUIStyle myButtonStyle = new GUIStyle(GUI.skin.button)
        {
            fontSize = 30
        };

        GUIStyle myLabelStyle = new GUIStyle(GUI.skin.label)
        {
            fontSize = 20
        };


        GUI.depth = 0;

        productId = GUI.TextArea(new Rect(850, 50, 300, 150), productId, myButtonStyle);

        productIds = GUI.TextArea(new Rect(850, 220, 300, 150), productIds, myButtonStyle);

        imagePath = GUI.TextArea(new Rect(850, 380, 300, 150), imagePath, myButtonStyle);

        GUI.Label(new Rect(850, 600, 500, 300), logText, myLabelStyle);

        if (GUI.Button(new Rect(50, 50, 200, 60), "简体", myButtonStyle))
        {
            TDSGlobal.TDSGlobalSDK.SetLanguage(TDSGlobal.TDSGlobalLanguage.ZH_CN);
            this.logText = "简体";
        }

        if (GUI.Button(new Rect(50, 120, 200, 60), "繁体", myButtonStyle))
        {
            TDSGlobal.TDSGlobalSDK.SetLanguage(TDSGlobal.TDSGlobalLanguage.ZH_TW);
            this.logText = "繁体";
        }

        if (GUI.Button(new Rect(50, 190, 200, 60), "泰文", myButtonStyle))
        {
            TDSGlobal.TDSGlobalSDK.SetLanguage(TDSGlobal.TDSGlobalLanguage.TH);
            this.logText = "泰文";
        }

        if (GUI.Button(new Rect(50, 270, 200, 60), "印尼", myButtonStyle))
        {
            TDSGlobal.TDSGlobalSDK.SetLanguage(TDSGlobal.TDSGlobalLanguage.ID);
            this.logText = "印尼";
        }

        if (GUI.Button(new Rect(50, 350, 200, 60), "英文", myButtonStyle))
        {
            TDSGlobal.TDSGlobalSDK.SetLanguage(TDSGlobal.TDSGlobalLanguage.EN);
            this.logText = "英文";
        }

        if (GUI.Button(new Rect(50, 430, 200, 60), "初始化", myButtonStyle))
        {
            TDSGlobal.TDSGlobalSDK.Init((initSuccess) =>
            {
                if (initSuccess)
                {
                    Debug.Log("初始化成功");
                    this.logText = "初始化成功";
                }
                else
                {
                    Debug.Log("初始化失败");
                    this.logText = "初始化失败";
                }
            });
        }

        if (GUI.Button(new Rect(50, 510, 200, 60), "登陆", myButtonStyle))
        {
            TDSGlobal.TDSGlobalSDK.Login((tdsUser) =>
            {
                Debug.Log("user:" + tdsUser.ToJSON());
                this.logText = "user:" + tdsUser.ToJSON();
            }, (tdsError) =>
            {
                this.logText = "error:" + tdsError.ToJSON();
                Debug.Log("error:" + tdsError.ToJSON());
            });
        }

        if (GUI.Button(new Rect(50, 590, 200, 60), "账户中心", myButtonStyle))
        {
            TDSGlobal.TDSGlobalSDK.UserCenter();
        }

        if (GUI.Button(new Rect(300, 50, 200, 60), "退出登陆", myButtonStyle))
        {
            TDSGlobal.TDSGlobalSDK.Logout();
        }

        if (GUI.Button(new Rect(300, 130, 200, 60), "客服", myButtonStyle))
        {
            TDSGlobal.TDSGlobalSDK.Report("serverId", "4332464624", "roleName");
        }

        if (GUI.Button(new Rect(300, 210, 200, 60), "网页支付", myButtonStyle))
        {
            TDSGlobal.TDSGlobalSDK.PayWithWeb("1", "4332464624", (error) =>
            {
                Debug.Log("pay With Web:" + error.ToJSON());
                this.logText = "网页支付:" + error.ToJSON();
            });
        }


        if (GUI.Button(new Rect(300, 290, 200, 60), "查询商品", myButtonStyle))
        {
            TDSGlobal.TDSGlobalSDK.QueryWithProductIds(productIds.Split(','), (sku) =>
            {
                this.logText = "查询商品:";
                foreach (TDSGlobal.TDSGlobalSkuDetail detail in sku)
                {
                    this.logText = this.logText + detail.ToJSON();
                }
            }, (error) =>
             {
                 this.logText = "查询商品错误:" + error.ToJSON();
                 Debug.Log("查询商品错误:" + error.ToJSON());
             });

        }

        if (GUI.Button(new Rect(300, 370, 200, 60), "未完成订单", myButtonStyle))
        {
            TDSGlobal.TDSGlobalSDK.QueryRestoredPurchases((list) =>
            {
                this.logText = "未完成订单:";
                foreach (TDSGlobal.TDSGlobalRestoredPurchases purchaes in list)
                {
                    this.logText = this.logText + JsonUtility.ToJson(purchaes);
                }
            });
        }

        if (GUI.Button(new Rect(300, 450, 200, 60), "分享UriMessage", myButtonStyle))
        {
            TDSGlobal.TDSGlobalSDK.Share(TDSGlobal.TDSGlobalShareFlavors.FACEBOOK, "https://www.baidu.com", "message", this);
        }

        if (GUI.Button(new Rect(300, 530, 200, 60), "分享图片", myButtonStyle))
        {
            TDSGlobal.TDSGlobalSDK.Share(TDSGlobal.TDSGlobalShareFlavors.FACEBOOK, imagePath, this);
        }

        if (GUI.Button(new Rect(300, 610, 200, 60), "添加用户状态", myButtonStyle))
        {
            TDSGlobal.TDSGlobalSDK.AddUserStatusChangeCallback((code) =>
            {
                Debug.Log("code:" + code);
                this.logText = "用户状态回调" + code;
            });
        }

        if (GUI.Button(new Rect(550, 50, 200, 60), "获取用户信息", myButtonStyle))
        {
            TDSGlobal.TDSGlobalSDK.GetUser((tdsUser) =>
            {
                Debug.Log("user:" + tdsUser.ToJSON());
                this.logText = "user:" + tdsUser.ToJSON();
            }, (tdsError) =>
            {
                Debug.Log("error:" + tdsError.ToJSON());
                this.logText = "error:" + tdsError.ToJSON();
            });
        }

        if (GUI.Button(new Rect(550, 130, 200, 60), "获取SDK版本", myButtonStyle))
        {
            TDSGlobal.TDSGlobalSDK.GetVersionName((version) =>
            {
                Debug.Log("version:" + version);
                this.logText = "version:" + version;
            });
        }

        if (GUI.Button(new Rect(550, 210, 200, 60), "支付商品", myButtonStyle))
        {
            TDSGlobal.TDSGlobalSDK.PayWithProduct("orderId", productId, "4332464624", "serverId", "ext", (orderInfo) =>
            {
                Debug.Log("orderInfo:" + orderInfo.ToJSON());
                this.logText = "orderInfo:" + orderInfo.ToJSON();
            }, (tdsError) =>
            {
                Debug.Log("tdsError:" + tdsError.ToJSON());
                this.logText = "tdsError:" + tdsError.ToJSON();
            });
        }

        if (GUI.Button(new Rect(550, 290, 200, 60), "补单", myButtonStyle))
        {
            TDSGlobal.TDSGlobalSDK.RestorePurchase("info", "orderId", productId, "4332464624", "serverId", "ext", (info) =>
            {
                Debug.Log("补单:" + info.ToJSON());
                this.logText = "补单:" + info.ToJSON();
            }, (tdsError) =>
            {
                Debug.Log("tdsError:" + tdsError.ToJSON());
                this.logText = "tdsError:" + tdsError.ToJSON();
            });
        }

        if (GUI.Button(new Rect(550, 370, 200, 60), "获取地区", myButtonStyle))
        {
            TDSCommon.TDSCommon.GetInstance().GetRegionCode((isMainLand) =>
            {
                Debug.Log("是否是国内:" + isMainLand);
                this.logText = "是否是国内:" + isMainLand;
            });
        }

        if (GUI.Button(new Rect(550, 450, 200, 60), "跳转商店", myButtonStyle))
        {
            TDSGlobal.TDSGlobalSDK.StoreReview();
        }

        if (GUI.Button(new Rect(550, 530, 200, 60), "IOS截图", myButtonStyle))
        {
            this.imagePath = Application.dataPath + "/ScreenShot/ScreenShot1.png";
            CapturePic(imagePath);
        }

    }

}
