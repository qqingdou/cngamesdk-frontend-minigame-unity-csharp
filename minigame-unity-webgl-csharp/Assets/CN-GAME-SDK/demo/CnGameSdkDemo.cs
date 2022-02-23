using CN_GAME_SDK.callback;
using CN_GAME_SDK.helper;
using UnityEngine;
using WeChatWASM;

namespace CN_GAME_SDK.demo
{
    public class CnGameSdkDemo : MonoBehaviour
    {
        /// <summary>
        /// 版本号（整形）
        /// </summary>
        private static int app_version_code = 101;
        /// <summary>
        /// 版本号（字符串）
        /// </summary>
        private static string app_version_code_name = "1.0.1";

        private static string wx_app_id = "你的微信APPID";

        private static string login_key = "你的加密秘钥";

        /// <summary>
        /// 初始化事件
        /// </summary>
        public void OnInit()
        {
            Init();
        }
        /// <summary>
        /// 初始化
        /// </summary>
        public static void Init()
        {
            CnGameSdk.Init(new param.CnGameSdkInitParam() {
             app_version_code = app_version_code,
              app_version_name  =   app_version_code_name,
               login_key = login_key,
                 wx_app_id = wx_app_id
            }, delegate () {
                WX.ShowToast(new ShowToastOption() { title = "完成.", duration = 3000 });
            });
        }
        /// <summary>
        /// 登录事件
        /// </summary>
        public void OnLogin()
        {
            Login();
        }
        /// <summary>
        /// 登录
        /// </summary>
        public static void Login()
        {
            CnGameSdk.Login(new param.CnGameSdkLoginParam() { }, 
                delegate (CnGameSdkLoginCallback cnGameSdkLoginCallback) { 
                    WX.ShowToast(new ShowToastOption() { title = "成功.", duration = 3000, icon = "success" });
                    CnGameSdkDebugHelper.Log(LitJson.JsonMapper.ToJson(cnGameSdkLoginCallback));
                }, 
                delegate (CnGameSdkLoginCallback cnGameSdkLoginCallback) {
                    WX.ShowToast(new ShowToastOption() { title = "失败.", duration = 3000, icon = "error" });
                }, 
                delegate (CnGameSdkLoginCallback cnGameSdkLoginCallback) {
                    CnGameSdkDebugHelper.Log("完成");
                });
        }

        /// <summary>
        /// 充值开关事件
        /// </summary>
        public void OnPaySwitch()
        {
            PaySwitch();
        }
        /// <summary>
        /// 充值开关
        /// </summary>
        public void PaySwitch()
        {
            CnGameSdk.PaySwitch(new param.CnGameSdkPaySwitchParam() {
                role_create_time = 0,
                role_id = "",
                role_level = 0,
                role_name = "",
                server_id = "",
                server_name = "",
                total_game_coin = 0,
                user_id = 0
            },
                delegate (CnGameSdkPaySwitchCallback cnGameSdkPaySwitchCallback) {
                    WX.ShowToast(new ShowToastOption() { title = "成功.", duration = 3000, icon = "success" });
                    CnGameSdkDebugHelper.Log(LitJson.JsonMapper.ToJson(cnGameSdkPaySwitchCallback));
                },
                delegate (CnGameSdkPaySwitchCallback cnGameSdkPaySwitchCallback) {
                    WX.ShowToast(new ShowToastOption() { title = "失败.", duration = 3000, icon = "error" });
                },
                delegate (CnGameSdkPaySwitchCallback cnGameSdkPaySwitchCallback) {
                    CnGameSdkDebugHelper.Log("完成");
                });
        }
        /// <summary>
        /// 充值事件
        /// </summary>
        public void OnPay() {
            Pay();
        }
        /// <summary>
        /// 充值
        /// </summary>
        public static void Pay()
        {
            CnGameSdk.Pay(new param.CnGameSdkPayParam() {
                money = 100,
                pay_ext = "",
                product_desc = "test",
                product_id = "test",
                product_name = "test",
                role_id = "test",
                role_level = 0,
                role_name = "test",
                server_id = "123",
                server_name = "test",
                user_id = 0
            });
        }
        /// <summary>
        /// 数据上报事件
        /// </summary>
        public void OnDataReport()
        {
            DataReport();
        }
        /// <summary>
        /// 数据上报
        /// </summary>
        public static void DataReport()
        {
            CnGameSdk.DataReport(new param.CnGameSdkDataReportParam()
            {
                report_type = 1,
                role_id = "test",
                role_level = 0,
                role_name = "test",
                server_id = "123",
                server_name = "test",
                user_id = 0
            }) ;
        }
        /// <summary>
        /// 主动分享事件
        /// </summary>
        public void OnShare()
        {
            Share();
        }

        public static void Share()
        {
            CnGameSdk.Share(new param.CnGameSdkShareParam()
            {
                image_url = "https://up.enterdesk.com/22/a6/5d/83/afb258a5a6d3bb3f5a215acd049dfd79.jpg",
                image_url_id = "",
                path = "",
                share_ext = "test_param=123",
                title = "测试分享",
                to_current_group = false
            });
        }
        /// <summary>
        /// 监听分享事件
        /// </summary>
        public void OnListenShare()
        {
            ListenShare();
        }
        /// <summary>
        /// 监听分享
        /// </summary>
        public static void ListenShare()
        {
            CnGameSdk.OnShare(new param.CnGameSdkShareParam()
            {
                image_url = "https://up.enterdesk.com/22/a6/5d/83/afb258a5a6d3bb3f5a215acd049dfd79.jpg",
                image_url_id = "",
                path = "",
                share_ext = "test_param=123",
                title = "测试分享",
                to_current_group = false
            });
        }

    }
}