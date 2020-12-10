
namespace TDSGlobal
{
    public class TDSGlobalLanguage
    {
        public static int ZH_CN = 0;

        public static int ZH_TW = 1;

        public static int EN = 2;

        public static int TH = 3;

        public static int ID = 4;
    }

    public class TDSGlobalShareFlavors
    {
        public static int FACEBOOK = 0;
    }

    public class TDSGlobalPaymentResultCode
    {
        public static int PAYMENT_PREPARE_START = 0x200001;
        public static int PAYMENT_PREPARE_END = 0x200002;
        public static int PAYMENT_ORDER_START = 0x200003;
        public static int PAYMENT_ORDER_END = 0x200004;
    }

    public class TDSGlobalUserStatusCode
    {
        public static int LOGOUT = 0x9001;
        public static int DELETE = 0x9002;
        public static int BIND_CHANGE = 0x9003;
    }

    public class TDSGlobalBridgeName
    {
        public static string SERVICE_NAME = "TDSGlobalCoreService";

        public static string LOGIN_SERVICE_NAME = "TDSGlobalLoginService";

        public static string IAP_SERVICE_NAME = "TDSGlobalIAPService";

        public static string SERVICE_CLZ = "com.tds.xdg.core.bridge.TDSGlobalCoreService";

        public static string SERVICE_IMPL = "com.tds.xdg.core.bridge.TDSGlobalCoreServiceImpl";

        public static string LOGIN_SERVICE_CLZ = "com.tds.xdg.core.bridge.TDSGlobalLoginService";

        public static string LOGIN_SERVICE_IMPL = "com.tds.xdg.core.bridge.TDSGlobalLoginServiceImpl";

        public static string IAP_SERVICE_CLZ = "com.tds.xdg.core.bridge.TDSGlobalIAPService";

        public static string IAP_SERVICE_IMPL = "com.tds.xdg.core.bridge.TDSGlobalIAPServiceImpl";

    }

}