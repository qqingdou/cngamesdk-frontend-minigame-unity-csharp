namespace CN_GAME_SDK.param
{
    public class CnGameSdkInitParam : CnGameSdkBaseParam
    {
        /// <summary>
        /// 游戏版本号。如：101
        /// </summary>
        public int app_version_code = 0;
        /// <summary>
        /// 游戏版本号。如：1.0.1
        /// </summary>
        public string app_version_name = "";
        /// <summary>
        /// 微信APPID。如:wx669xxxxxxd502b0
        /// </summary>
        public string wx_app_id = "";
        /// <summary>
        /// 登录秘钥
        /// </summary>
        public string login_key = "";
    }
}