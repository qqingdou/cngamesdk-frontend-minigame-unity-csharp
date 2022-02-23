using Assets.CN_GAME_SDK.response;
using CN_GAME_SDK.helper;
using CN_GAME_SDK.param;
using CN_GAME_SDK.response;
using WeChatWASM;

namespace CN_GAME_SDK.config
{
    internal class CnGameSdkConfig
    {
        /// <summary>
        /// 加密的键值
        /// </summary>
        public const string SIGN_KEY = "sign";
        /// <summary>
        /// sdk 版本号(整形)
        /// </summary>
        public const int SDK_VERSION_CODE = 101;
        /// <summary>
        /// sdk 版本号
        /// </summary>
        public const string SDK_VERSION_CODE_NAME = "1.0.1";
        /// <summary>
        /// 网络请求中游戏对象销毁的数量
        /// </summary>
        public const int GAME_OBEJCT_DESTORY_NUM = 50;
        /// <summary>
        /// HTTP超时时间
        /// </summary>
        public const int HTTP_TIME_OUT = 5000;
        /// <summary>
        /// 打印的标签名字
        /// </summary>
        public const string TAG_CN_GAME_SDK_NAME = "CnGameSdk";
        /// <summary>
        /// 配置实例的单例
        /// </summary>
        private static CnGameSdkConfig instance = null;
        /// <summary>
        /// 初始化参数
        /// </summary>
        public CnGameSdkInitParam cnGameSdkInitParam;
        /// <summary>
        /// 系统信息
        /// </summary>
        public SystemInfo systemInfo;
        /// <summary>
        /// 启动参数
        /// </summary>
        public EnterOptionsGame enterOptionsGame;
        /// <summary>
        /// 追踪ID
        /// </summary>
        public string TraceId = "";
        /// <summary>
        /// 微信重登的次数，防止死循环
        /// </summary>
        public static int RetryWxLoginCount = 2;

        /// <summary>
        /// 登录后返回
        /// </summary>
        public CnGameSdkBaseResponse<CnGameSdkLoginResponseInfo, CnGameSdkLoginResponseLists> cnGameSdkBaseResponse = new CnGameSdkBaseResponse<CnGameSdkLoginResponseInfo, CnGameSdkLoginResponseLists>(); 

        /// <summary>
        /// 获取配置单例
        /// </summary>
        public static CnGameSdkConfig Instance {
            get
            {
                if (instance == null)
                {
                    instance = new CnGameSdkConfig();
                    instance.TraceId = CnGameSdkCommonHelper.GenerateStringID32();
                }
                return instance;
            }
        }
    }
}