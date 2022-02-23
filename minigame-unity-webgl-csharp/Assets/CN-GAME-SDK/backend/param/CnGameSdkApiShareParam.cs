namespace CN_GAME_SDK.backend.param
{
    internal class CnGameSdkApiShareParam : CnGameSdkApiBaseParam
    {
        public override string GetRequestUrl()
        {
            return base.RequestUrlAppendExtraParams(Config.GetShareUrl());
        }
    }
}