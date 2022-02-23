

using Assets.CN_GAME_SDK.response;
using CN_GAME_SDK.helper;
using System.Collections.Generic;
using WeChatWASM;

namespace CN_GAME_SDK.response
{
    internal class CnGameSdkPayConfigMiniprogram : CnGameSdkPayBase
    {   
        /// <summary>
        /// 支付方式
        /// </summary>
        public static string PayType = "miniprogram";
        /// <summary>
        /// 支付逻辑
        /// </summary>
        /// <param name="cnGameSdkBaseResponse"></param>
        public override void Pay(CnGameSdkBaseResponse<CnGameSdkPayResponseInfo, CnGameSdkPayResponseLists> cnGameSdkBaseResponse)
        {
            LitJson.JsonData config = cnGameSdkBaseResponse.info.config;
            NavigateToMiniProgramOption navigateToMiniProgramOption = new NavigateToMiniProgramOption();

            if (config.ContainsKey("app_id"))
            {
                navigateToMiniProgramOption.appId = config["app_id"].ToString();
            }

            if (config.ContainsKey("env_version"))
            {
                navigateToMiniProgramOption.envVersion = config["env_version"].ToString();
            }

            if (config.ContainsKey("extra_data"))
            {
                Dictionary<string, string> dicExtraData = new Dictionary<string, string>();
                LitJson.JsonData extraData = config["extra_data"];
                foreach (var item in extraData.Keys)
                {
                    if (!dicExtraData.ContainsKey(item))
                    {
                        dicExtraData.Add(item, extraData[item].ToString());
                    }
                }
                navigateToMiniProgramOption.extraData = dicExtraData;
            }

            if (config.ContainsKey("path"))
            {
                navigateToMiniProgramOption.path = config["path"].ToString();
            }

            if (config.ContainsKey("short_link"))
            {
                navigateToMiniProgramOption.shortLink = config["short_link"].ToString();
            }

            navigateToMiniProgramOption.complete = null;
            navigateToMiniProgramOption.fail = delegate (GeneralCallbackResult generalCallbackResult) {
                string message = $"小程序拉起失败,请重试.{generalCallbackResult.errMsg}";
                CnGameSdkDebugHelper.Error(message);
                WX.ShowModal(new ShowModalOption { title = "支付提示", content = message });
            };
            navigateToMiniProgramOption.success = null;

            WX.NavigateToMiniProgram(navigateToMiniProgramOption);
        }
    }
}