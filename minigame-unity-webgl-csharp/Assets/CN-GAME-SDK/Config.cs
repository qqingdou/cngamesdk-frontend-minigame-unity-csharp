
namespace CN_GAME_SDK
{
    public class Config
    {
        /// <summary>
        /// 获取接口接入协议
        /// </summary>
        /// <returns></returns>
        public static string GetProtocol()
        {
            return "https";
        }
        /// <summary>
        /// 获取接口接入域名.请自行替换
        /// </summary>
        /// <returns></returns>
        public static string GetEndpoint()
        {
            return "cngamesdk.xx.com";
        }
        /// <summary>
        /// 获取接口模块
        /// </summary>
        /// <returns></returns>
        public static string GetModule()
        {
            return "minigame";
        }
        /// <summary>
        /// 获取登录请求地址
        /// </summary>
        /// <returns></returns>
        public static string GetLoginUrl()
        {
            return $"{GetProtocol()}://{GetEndpoint()}/{GetModule()}/login/account";
        }

        /// <summary>
        /// 获取支付请求地址
        /// </summary>
        /// <returns></returns>
        public static string GetPayUrl()
        {
            return $"{GetProtocol()}://{GetEndpoint()}/{GetModule()}/pay/preorder";
        }

        /// <summary>
        /// 获取数据上报请求地址
        /// </summary>
        /// <returns></returns>
        public static string GetDataReportUrl()
        {
            return $"{GetProtocol()}://{GetEndpoint()}/{GetModule()}/report/role";
        }
        /// <summary>
        /// 获取分享配置请求地址
        /// </summary>
        /// <returns></returns>
        public static string GetShareUrl()
        {
            return $"{GetProtocol()}://{GetEndpoint()}/{GetModule()}/config/share";
        }
        /// <summary>
        /// 获取充值开关请求地址
        /// </summary>
        /// <returns></returns>
        public static string GetPaySwitchUrl()
        {
            return $"{GetProtocol()}://{GetEndpoint()}/{GetModule()}/pay/switch";
        }
    }
}