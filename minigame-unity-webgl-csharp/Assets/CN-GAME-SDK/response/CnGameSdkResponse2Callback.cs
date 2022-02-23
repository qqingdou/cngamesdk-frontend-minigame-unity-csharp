using Assets.CN_GAME_SDK.response;
using CN_GAME_SDK.callback;

namespace CN_GAME_SDK.response
{
    internal class CnGameSdkResponse2Callback 
    {
        /// <summary>
        /// 与服务端登录后对象转化给CP需要的对象
        /// </summary>
        /// <param name="cnGameSdkBaseResponse"></param>
        /// <returns></returns>
        public static CnGameSdkLoginCallback LoginResponse2Callback(CnGameSdkBaseResponse<CnGameSdkLoginResponseInfo, CnGameSdkLoginResponseLists> cnGameSdkBaseResponse)
        {
            CnGameSdkLoginCallback cnGameSdkLoginCallback = new CnGameSdkLoginCallback();
            CnGameSdkLoginResponseInfo cnGameSdkLoginResponseInfo = cnGameSdkBaseResponse.info;
            cnGameSdkLoginCallback.avatar = cnGameSdkLoginResponseInfo.avatar;
            cnGameSdkLoginCallback.nickname = cnGameSdkLoginResponseInfo.nickname;
            cnGameSdkLoginCallback.request_id = cnGameSdkBaseResponse.request_id;
            cnGameSdkLoginCallback.time = cnGameSdkLoginResponseInfo.time;
            cnGameSdkLoginCallback.token = cnGameSdkLoginResponseInfo.token;
            cnGameSdkLoginCallback.user_id = cnGameSdkLoginResponseInfo.user_id;
            return cnGameSdkLoginCallback;
        }
        /// <summary>
        /// 获取充值开关API对象转换为CP需要对象
        /// </summary>
        /// <param name="cnGameSdkBaseResponse"></param>
        /// <returns></returns>
        public static CnGameSdkPaySwitchCallback PaySwitchResponse2Callback(CnGameSdkBaseResponse<CnGameSdkPaySwitchResponseInfo, CnGameSdkPaySwitchResponseLists> cnGameSdkBaseResponse)
        {
            CnGameSdkPaySwitchCallback cnGameSdkPaySwitchCallback = new CnGameSdkPaySwitchCallback();
            cnGameSdkPaySwitchCallback.request_id = cnGameSdkBaseResponse.request_id;
            cnGameSdkPaySwitchCallback.pay_switch = cnGameSdkBaseResponse.info.pay_switch;
            return cnGameSdkPaySwitchCallback;
        }
    }
}