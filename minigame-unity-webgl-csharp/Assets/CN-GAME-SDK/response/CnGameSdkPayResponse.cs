namespace CN_GAME_SDK.response
{
    internal class CnGameSdkPayResponseInfo
    {
        /// <summary>
        /// 订单号
        /// </summary>
        public string order_id = "";
        /// <summary>
        /// 支付类型。midas：米大师支付；customer_service：客服H5支付;miniprogram：小程序支付
        /// </summary>
        public string pay_type = "";
        /// <summary>
        /// 支付类型对应的配置
        /// </summary>
        public LitJson.JsonData config;
    }

    internal class CnGameSdkPayResponseLists
    {
    }
}