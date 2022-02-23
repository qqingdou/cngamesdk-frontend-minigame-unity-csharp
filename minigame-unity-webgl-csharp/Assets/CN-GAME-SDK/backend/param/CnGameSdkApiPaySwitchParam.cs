namespace CN_GAME_SDK.backend.param
{
    internal class CnGameSdkApiPaySwitchParam : CnGameSdkApiBaseParam
    {
        public override string GetRequestUrl()
        {
            return base.RequestUrlAppendExtraParams(Config.GetPaySwitchUrl());
        }
    }
}