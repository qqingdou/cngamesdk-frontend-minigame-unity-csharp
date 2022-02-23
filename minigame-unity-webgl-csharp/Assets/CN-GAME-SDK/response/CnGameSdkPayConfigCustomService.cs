

using Assets.CN_GAME_SDK.response;
using CN_GAME_SDK.helper;
using System;
using WeChatWASM;

namespace CN_GAME_SDK.response
{
    internal class CnGameSdkPayConfigCustomerService : CnGameSdkPayBase
    {
        /// <summary>
        /// 支付方式
        /// </summary>
        public static string PayType = "customer_service";
        /// <summary>
        /// 支付逻辑
        /// </summary>
        /// <param name="cnGameSdkBaseResponse"></param>
        public override void Pay(CnGameSdkBaseResponse<CnGameSdkPayResponseInfo, CnGameSdkPayResponseLists> cnGameSdkBaseResponse)
        {
            LitJson.JsonData config = cnGameSdkBaseResponse.info.config;
            OpenCustomerServiceConversationOption openCustomerServiceConversationOption = new OpenCustomerServiceConversationOption();

            openCustomerServiceConversationOption.complete = null;
            openCustomerServiceConversationOption.fail = delegate (GeneralCallbackResult generalCallbackResult) {
                string message = $"客服拉起失败,请重试.{generalCallbackResult.errMsg}";
                CnGameSdkDebugHelper.Error(message);
                WX.ShowModal(new ShowModalOption { title = "支付提示", content = message });
            };
            openCustomerServiceConversationOption.success = null;

            if (config.ContainsKey("send_message_img"))
            {
                openCustomerServiceConversationOption.sendMessageImg = config["send_message_img"].ToString();
            }

            if (config.ContainsKey("send_message_path"))
            {
                openCustomerServiceConversationOption.sendMessagePath = config["send_message_path"].ToString();
            }

            if (config.ContainsKey("send_message_title"))
            {
                openCustomerServiceConversationOption.sendMessageTitle = config["send_message_title"].ToString();
            }

            if (config.ContainsKey("session_from"))
            {
                openCustomerServiceConversationOption.sessionFrom = config["session_from"].ToString();
            }

            if (config.ContainsKey("show_message_card"))
            {
                openCustomerServiceConversationOption.showMessageCard = Convert.ToBoolean(config["show_message_card"]);
            }
    
            WX.OpenCustomerServiceConversation(openCustomerServiceConversationOption);
        }
    }
}