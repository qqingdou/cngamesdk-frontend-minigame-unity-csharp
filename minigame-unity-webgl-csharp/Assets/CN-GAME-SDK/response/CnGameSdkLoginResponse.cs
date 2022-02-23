

namespace CN_GAME_SDK.response
{
    internal class CnGameSdkLoginResponseInfo
    {
        /// <summary>
        /// 用户ID
        /// </summary>
        public int user_id = 0;
        /// <summary>
        /// 用户昵称
        /// </summary>
        public string nickname = "";
        /// <summary>
        /// 用户头像
        /// </summary>
        public string avatar = "";
        /// <summary>
        /// 用户访问令牌
        /// </summary>
        public string token = "";
        /// <summary>
        /// UNIX时间戳。单位：秒
        /// </summary>
        public int time = 0;
    }

    internal class CnGameSdkLoginResponseLists
    {
    }

}