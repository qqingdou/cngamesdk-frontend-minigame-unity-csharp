
namespace CN_GAME_SDK.backend.param
{
    internal class CnGameSdkApiPayParam : CnGameSdkApiBaseParam
    {
        public override string GetRequestUrl()
        {
            return base.RequestUrlAppendExtraParams(Config.GetPayUrl());
        }
    }
}