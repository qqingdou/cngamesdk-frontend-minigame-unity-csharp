namespace CN_GAME_SDK.backend.param
{
    internal class CnGameSdkApiDataReportParam : CnGameSdkApiBaseParam
    {
        /// <summary>
        /// 获取请求地址
        /// </summary>
        /// <returns></returns>
        public override string GetRequestUrl()
        {
            return base.RequestUrlAppendExtraParams(Config.GetDataReportUrl());
        }
    }
}