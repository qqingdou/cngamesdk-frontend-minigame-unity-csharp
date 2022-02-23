

using CN_GAME_SDK.config;

namespace CN_GAME_SDK.backend.param
{
    internal class CnGameSdkApiLoginParam : CnGameSdkApiBaseParam
    {
        /// <summary>
        /// 微信CODE
        /// </summary>
        public string code = "";

        public override string GetRequestUrl()
        {
            return base.RequestUrlAppendExtraParams(Config.GetLoginUrl());
        }
    }
}