

using Assets.CN_GAME_SDK.response;
using CN_GAME_SDK.helper;
using System;
using WeChatWASM;

namespace CN_GAME_SDK.response
{
    internal class CnGameSdkPayConfigMidas : CnGameSdkPayBase
    {
        /// <summary>
        /// 支付类型
        /// </summary>
        public static new string PayType = "midas";
        /// <summary>
        /// 支付逻辑
        /// </summary>
        /// <param name="cnGameSdkBaseResponse"></param>
        public override void Pay(CnGameSdkBaseResponse<CnGameSdkPayResponseInfo, CnGameSdkPayResponseLists> cnGameSdkBaseResponse)
        {
            RequestMidasPaymentOption requestMidasPaymentOption = new RequestMidasPaymentOption();
            LitJson.JsonData config = cnGameSdkBaseResponse.info.config;
            if (config.ContainsKey("buy_quantity"))
            {
                requestMidasPaymentOption.buyQuantity = Convert.ToDouble(config["buy_quantity"].ToString());
            }

           if (config.ContainsKey("currency_type"))
            {
                requestMidasPaymentOption.currencyType = config["currency_type"].ToString();
            }

            if (config.ContainsKey("env"))
            {
                requestMidasPaymentOption.env = Convert.ToDouble(config["env"].ToString());
            }

            if (config.ContainsKey("mode"))
            {
                requestMidasPaymentOption.env = Convert.ToDouble(config["mode"].ToString());
            }

            if (config.ContainsKey("offer_id"))
            {
                requestMidasPaymentOption.offerId = config["offer_id"].ToString();
            }

            if (config.ContainsKey("platform"))
            {
                requestMidasPaymentOption.platform = config["platform"].ToString();
            }

            if (config.ContainsKey("zone_id"))
            {
                requestMidasPaymentOption.zoneId = config["zone_id"].ToString();
            }

            requestMidasPaymentOption.complete = null;
            requestMidasPaymentOption.fail = delegate (MidasPaymentError midasPaymentError) {
                string message = $"米大师拉起失败,请重试.code:{midasPaymentError.errCode},message:{midasPaymentError.errMsg}";
                CnGameSdkDebugHelper.Error(message);
                WX.ShowModal(new ShowModalOption { title = "支付提示", content = message });
            };
            requestMidasPaymentOption.success = null;

            WX.RequestMidasPayment(requestMidasPaymentOption);
        }
    }
}