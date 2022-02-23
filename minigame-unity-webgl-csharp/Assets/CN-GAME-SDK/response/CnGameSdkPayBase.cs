using Assets.CN_GAME_SDK.response;

namespace CN_GAME_SDK.response
{
    internal abstract class CnGameSdkPayBase 
    {
        /// <summary>
        /// 支付类型
        /// </summary>
        public static string PayType = "";
        /// <summary>
        /// 支付逻辑
        /// </summary>
        /// <param name="cnGameSdkBaseResponse"></param>
        abstract public void Pay(CnGameSdkBaseResponse<CnGameSdkPayResponseInfo, CnGameSdkPayResponseLists> cnGameSdkBaseResponse);
     
    }
}