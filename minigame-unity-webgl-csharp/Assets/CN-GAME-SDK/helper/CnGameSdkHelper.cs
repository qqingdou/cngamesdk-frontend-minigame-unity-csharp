using Assets.CN_GAME_SDK.response;
using CN_GAME_SDK.callback;
using CN_GAME_SDK.config;
using CN_GAME_SDK.param;
using CN_GAME_SDK.response;
using System;
using System.Collections.Generic;
using WeChatWASM;

namespace CN_GAME_SDK.helper
{
    internal class CnGameSdkHelper
    {
        /// <summary>
        /// 已经重试微信登录次数
        /// </summary>
        private static int alreadyRetryWxLoginNum = 0;
        /// <summary>
        /// 初始化微信SDK
        /// </summary>
        /// <param name="callback">回调函数</param>
        public static void InitSdk(Action callback)
        {
            WX.InitSDK(delegate (int code) {
                GetSystemInfo();
                if (callback != null)
                {
                    callback();
                }
            });
        }
        /// <summary>
        /// 获取系统信息
        /// </summary>
        private static void GetSystemInfo()
        {
            WX.GetSystemInfo(new GetSystemInfoOption() {
                complete    =   delegate (GeneralCallbackResult generalCallbackResult) {
                    //防止获取启动参数为同步,故放在获取系统信息异步完成后
                    GetEnterOptionsGame();
                },
                fail        =   delegate (GeneralCallbackResult generalCallbackResult) { 
                    CnGameSdkDebugHelper.Error(LitJson.JsonMapper.ToJson(generalCallbackResult)); 
                },
                success     = delegate (SystemInfo systemInfo) {
                    CnGameSdkConfig.Instance.systemInfo = systemInfo;
                }
            });
        }

        /// <summary>
        /// 获取启动参数
        /// </summary>
        private static void GetEnterOptionsGame()
        {
            EnterOptionsGame enterOptionsGame = WX.GetEnterOptionsSync();
            CnGameSdkConfig.Instance.enterOptionsGame = enterOptionsGame;
        }
        /// <summary>
        /// 登录
        /// </summary>
        /// <param name="cnGameSdkLoginParam"></param>
        /// <param name="successCallback"></param>
        /// <param name="failCallback"></param>
        /// <param name="completeCallback"></param>
        public static void Login(CnGameSdkLoginParam cnGameSdkLoginParam,
            Action<CnGameSdkLoginCallback> successCallback = null,
            Action<CnGameSdkLoginCallback> failCallback = null,
            Action<CnGameSdkLoginCallback> completeCallback = null)
        {
            WX.Login(new LoginOption() {
                complete    =   delegate (GeneralCallbackResult generalCallbackResult) {
                    if (completeCallback != null) { 
                        completeCallback(new CnGameSdkLoginCallback()); 
                    }
                },
                fail        =   delegate (GeneralCallbackResult generalCallbackResult) {
                    CnGameSdkDebugHelper.Error(LitJson.JsonMapper.ToJson(generalCallbackResult));
                    if(failCallback != null)
                    {
                        failCallback(new CnGameSdkLoginCallback());
                    }
                },
                success     =   delegate (LoginSuccessCallbackResult loginSuccessCallbackResult) {
                    backend.param.CnGameSdkApiLoginParam backLoginParam = new backend.param.CnGameSdkApiLoginParam();
                    CnGameSdkNetworkHelper cnGameSdkNetworkHelper = CnGameSdkNetworkHelper.GetInstance();
                    cnGameSdkNetworkHelper.Url = backLoginParam.GetRequestUrl();
                    cnGameSdkNetworkHelper.PostData = CnGameSdkCommonHelper.ConvertDic2Form(CnGameSdkCommonHelper.MergeDictionary(cnGameSdkLoginParam.GetAttributes(),backLoginParam.GetPostData()));
                    cnGameSdkNetworkHelper.CompleteCallback = delegate () {
                        if (completeCallback != null)
                        {
                            completeCallback(new CnGameSdkLoginCallback());
                        }
                    };
                    cnGameSdkNetworkHelper.FailCallback = delegate () {
                        CnGameSdkDebugHelper.Error($"请求失败：{cnGameSdkNetworkHelper.Url}");
                        if (failCallback != null)
                        {
                            failCallback(new CnGameSdkLoginCallback());
                        }
                    };
                    cnGameSdkNetworkHelper.SuccessCallback = delegate (string message) {
                        bool success = false;
                        try
                        {
                            if (!string.IsNullOrEmpty(message))
                            {
                                CnGameSdkBaseResponse<CnGameSdkLoginResponseInfo, CnGameSdkLoginResponseLists> cnGameSdkBaseResponse =
                          LitJson.JsonMapper.ToObject<CnGameSdkBaseResponse<CnGameSdkLoginResponseInfo, CnGameSdkLoginResponseLists>>(message);
                                if (cnGameSdkBaseResponse != null && cnGameSdkBaseResponse.code == CnGameSdkResponceCode.CODE_SUCCESS)
                                {
                                    success = true;
                                    CnGameSdkConfig.Instance.cnGameSdkBaseResponse = cnGameSdkBaseResponse;
                                    if (successCallback != null)
                                    {
                                        successCallback(CnGameSdkResponse2Callback.LoginResponse2Callback(cnGameSdkBaseResponse));
                                    }
                                }
                            }
                        }
                        catch (Exception exception)
                        {
                            CnGameSdkDebugHelper.Exception(exception);
                        }
                        finally
                        {
                            if (completeCallback != null)
                            {
                                completeCallback(new CnGameSdkLoginCallback());
                            }
                            if (!success && failCallback != null)
                            {
                                failCallback(new CnGameSdkLoginCallback());
                            }
                        }
                    };
                    cnGameSdkNetworkHelper.Post();
                }
            });
        }
        /// <summary>
        /// 充值开关
        /// </summary>
        /// <param name="cnGameSdkPaySwitchParam"></param>
        /// <param name="successCallback"></param>
        /// <param name="failCallback"></param>
        /// <param name="completeCallback"></param>
        public static void PaySwitch(CnGameSdkPaySwitchParam cnGameSdkPaySwitchParam,
            Action<CnGameSdkPaySwitchCallback> successCallback,
            Action<CnGameSdkPaySwitchCallback> failCallback = null,
            Action<CnGameSdkPaySwitchCallback> completeCallback = null)
        {
            backend.param.CnGameSdkApiPaySwitchParam apiCnGameSdkPaySwitchParam = new backend.param.CnGameSdkApiPaySwitchParam();

            Dictionary<string, string> postData = CnGameSdkCommonHelper.MergeDictionary(cnGameSdkPaySwitchParam.GetAttributes(), apiCnGameSdkPaySwitchParam.GetPostData());

            CnGameSdkNetworkHelper cnGameSdkNetworkHelper = CnGameSdkNetworkHelper.GetInstance();
            cnGameSdkNetworkHelper.Url = apiCnGameSdkPaySwitchParam.GetRequestUrl();
            cnGameSdkNetworkHelper.PostData = CnGameSdkCommonHelper.ConvertDic2Form(postData);
            cnGameSdkNetworkHelper.CompleteCallback = null;
            cnGameSdkNetworkHelper.FailCallback = delegate () {
                CnGameSdkDebugHelper.Error($"请求失败：{cnGameSdkNetworkHelper.Url}");
                if(failCallback != null)
                {
                    failCallback(new CnGameSdkPaySwitchCallback());
                }
            };
            cnGameSdkNetworkHelper.SuccessCallback = delegate (string message) {
                bool success = false;
                try
                {
                    if (!string.IsNullOrEmpty(message))
                    {
                        CnGameSdkBaseResponse<CnGameSdkPaySwitchResponseInfo, CnGameSdkPaySwitchResponseLists> cnGameSdkBaseResponse =
                  LitJson.JsonMapper.ToObject<CnGameSdkBaseResponse<CnGameSdkPaySwitchResponseInfo, CnGameSdkPaySwitchResponseLists>>(message);

                        if (cnGameSdkBaseResponse != null)
                        {
                            if (cnGameSdkBaseResponse.code == CnGameSdkResponceCode.CODE_SUCCESS)
                            {
                                success = true;
                                if(successCallback != null)
                                {
                                    successCallback(CnGameSdkResponse2Callback.PaySwitchResponse2Callback(cnGameSdkBaseResponse));
                                }
                            }
                        }
                    }
                }
                catch (Exception exception)
                {
                    CnGameSdkDebugHelper.Exception(exception);
                }
                finally
                {
                    if (!success)
                    {
                        CnGameSdkDebugHelper.Error($"支付返回异常：{message}");
                    }
                    if(completeCallback != null)
                    {
                        completeCallback(new CnGameSdkPaySwitchCallback() { });
                    }
                }
            };
            cnGameSdkNetworkHelper.Post();
        }

        /// <summary>
        /// 支付逻辑
        /// </summary>
        /// <param name="cnGameSdkPayParam"></param>
        public static void Pay(CnGameSdkPayParam cnGameSdkPayParam)
        {
            backend.param.CnGameSdkApiPayParam apiCnGameSdkPayParam = new backend.param.CnGameSdkApiPayParam();

            Dictionary<string, string> postData = CnGameSdkCommonHelper.MergeDictionary(cnGameSdkPayParam.GetAttributes(), apiCnGameSdkPayParam.GetPostData());

            CnGameSdkNetworkHelper cnGameSdkNetworkHelper = CnGameSdkNetworkHelper.GetInstance();
            cnGameSdkNetworkHelper.Url = apiCnGameSdkPayParam.GetRequestUrl();
            cnGameSdkNetworkHelper.PostData = CnGameSdkCommonHelper.ConvertDic2Form(postData);
            cnGameSdkNetworkHelper.CompleteCallback = null;
            cnGameSdkNetworkHelper.FailCallback = delegate () {
                CnGameSdkDebugHelper.Error($"请求失败：{cnGameSdkNetworkHelper.Url}");
            };
            cnGameSdkNetworkHelper.SuccessCallback = delegate (string message) {
                bool success = false;
                string errorMessage = "";
                try
                {
                    if (!string.IsNullOrEmpty(message))
                    {
                        CnGameSdkBaseResponse<CnGameSdkPayResponseInfo, CnGameSdkPayResponseLists> cnGameSdkBaseResponse =
                  LitJson.JsonMapper.ToObject<CnGameSdkBaseResponse<CnGameSdkPayResponseInfo, CnGameSdkPayResponseLists>>(message);

                        if (cnGameSdkBaseResponse != null)
                        {
                            errorMessage = cnGameSdkBaseResponse.message;
                            if (cnGameSdkBaseResponse.code == CnGameSdkResponceCode.CODE_SUCCESS)
                            {
                                success = true;
                                string payType = cnGameSdkBaseResponse.info.pay_type.Trim().ToLower();
                                if (payType == CnGameSdkPayConfigMidas.PayType)
                                {
                                    new CnGameSdkPayConfigMidas().Pay(cnGameSdkBaseResponse);
                                }
                                else if (payType == CnGameSdkPayConfigMiniprogram.PayType)
                                {
                                    new CnGameSdkPayConfigMiniprogram().Pay(cnGameSdkBaseResponse);
                                }
                                else if (payType == CnGameSdkPayConfigCustomerService.PayType)
                                {
                                    new CnGameSdkPayConfigCustomerService().Pay(cnGameSdkBaseResponse);
                                }
                                else
                                {
                                    CnGameSdkDebugHelper.Error($"支付类型未配置：{payType}");
                                }
                            }else if(cnGameSdkBaseResponse.code == CnGameSdkResponceCode.CODE_LOGIN_EXPIRE)//登录失效
                            {
                                alreadyRetryWxLoginNum++;
                                //防止死循环
                                if(alreadyRetryWxLoginNum < CnGameSdkConfig.RetryWxLoginCount)
                                {
                                    Login(new CnGameSdkLoginParam() { }, delegate (CnGameSdkLoginCallback cnGameSdkLoginCallback) {
                                        Pay(cnGameSdkPayParam);
                                    });
                                }
                            }  
                        }
                    }
                }
                catch (Exception exception)
                {
                    CnGameSdkDebugHelper.Exception(exception);
                }
                finally
                {
                    alreadyRetryWxLoginNum = 0;

                    if (!success)
                    {
                        string tipMessage = string.IsNullOrEmpty(errorMessage) ? message : errorMessage;
                        CnGameSdkDebugHelper.Error($"支付返回异常：{message}");
                        WX.ShowModal(new ShowModalOption() { title = "下单提示", content = tipMessage });
                    }
                }
            };
            cnGameSdkNetworkHelper.Post();
        }
        /// <summary>
        /// 数据上报
        /// </summary>
        /// <param name="cnGameSdkDataReportParam"></param>
        public static void DataReport(CnGameSdkDataReportParam cnGameSdkDataReportParam)
        {
            backend.param.CnGameSdkApiDataReportParam apiCnGameSdkDataReportParam = new backend.param.CnGameSdkApiDataReportParam();
            Dictionary<string, string> postData = CnGameSdkCommonHelper.MergeDictionary(cnGameSdkDataReportParam.GetAttributes(), apiCnGameSdkDataReportParam.GetPostData());
            CnGameSdkNetworkHelper cnGameSdkNetworkHelper = CnGameSdkNetworkHelper.GetInstance();
            cnGameSdkNetworkHelper.Url = apiCnGameSdkDataReportParam.GetRequestUrl();
            cnGameSdkNetworkHelper.PostData = CnGameSdkCommonHelper.ConvertDic2Form(postData);
            cnGameSdkNetworkHelper.CompleteCallback = null;
            cnGameSdkNetworkHelper.FailCallback = delegate () {
                CnGameSdkDebugHelper.Error($"请求失败：{cnGameSdkNetworkHelper.Url}");
            };
            cnGameSdkNetworkHelper.SuccessCallback = delegate (string message) {
                bool success = false;
                try
                {
                    if (!string.IsNullOrEmpty(message))
                    {
                        CnGameSdkBaseResponse<CnGameSdkPayResponseInfo, CnGameSdkPayResponseLists> cnGameSdkBaseResponse =
                    LitJson.JsonMapper.ToObject<CnGameSdkBaseResponse<CnGameSdkPayResponseInfo, CnGameSdkPayResponseLists>>(message);

                        if (cnGameSdkBaseResponse != null && cnGameSdkBaseResponse.code == CnGameSdkResponceCode.CODE_SUCCESS)
                        {
                            success = true;
                        }
                    }
                }
                catch (Exception exception)
                {
                    CnGameSdkDebugHelper.Exception(exception);
                }
                finally
                {
                    if (!success)
                    {
                        CnGameSdkDebugHelper.Error($"数据上报异常：{message}");
                    }
                }
                
            };
            cnGameSdkNetworkHelper.Post();
        }
        /// <summary>
        /// 获取分享配置
        /// </summary>
        /// <param name="cnGameSdkShareParam"></param>
        /// <param name="successCallback"></param>
        private static void myShare(CnGameSdkShareParam cnGameSdkShareParam, Action<CnGameSdkBaseResponse<CnGameSdkShareResponseInfo, CnGameSdkShareResponseLists>> successCallback = null)
        {
            backend.param.CnGameSdkApiShareParam apiCnGameSdkShareParam = new backend.param.CnGameSdkApiShareParam();
            Dictionary<string, string> postData = CnGameSdkCommonHelper.MergeDictionary(cnGameSdkShareParam.GetAttributes(), apiCnGameSdkShareParam.GetPostData());
            CnGameSdkNetworkHelper cnGameSdkNetworkHelper = CnGameSdkNetworkHelper.GetInstance();
            cnGameSdkNetworkHelper.Url = apiCnGameSdkShareParam.GetRequestUrl();
            cnGameSdkNetworkHelper.PostData = CnGameSdkCommonHelper.ConvertDic2Form(postData);
            cnGameSdkNetworkHelper.CompleteCallback = null;
            cnGameSdkNetworkHelper.FailCallback = delegate () {
                CnGameSdkDebugHelper.Error($"请求失败：{cnGameSdkNetworkHelper.Url}");
            };
            cnGameSdkNetworkHelper.SuccessCallback = delegate (string message) {
                bool success = false;
                try
                {
                    if (!string.IsNullOrEmpty(message))
                    {
                        CnGameSdkBaseResponse<CnGameSdkShareResponseInfo, CnGameSdkShareResponseLists> cnGameSdkBaseResponse =
                    LitJson.JsonMapper.ToObject<CnGameSdkBaseResponse<CnGameSdkShareResponseInfo, CnGameSdkShareResponseLists>>(message);

                        if (cnGameSdkBaseResponse != null && cnGameSdkBaseResponse.code == CnGameSdkResponceCode.CODE_SUCCESS)
                        {
                            success = true;
                            if(successCallback != null)
                            {
                                successCallback(cnGameSdkBaseResponse);
                            }
                        }
                    }
                }
                catch (Exception exception)
                {
                    CnGameSdkDebugHelper.Exception(exception);
                }
                finally
                {
                    if (!success)
                    {
                        CnGameSdkDebugHelper.Error($"获取分享配置异常：{message}");
                    }
                }

            };
            cnGameSdkNetworkHelper.Post();
        }

        /// <summary>
        /// 主动分享
        /// </summary>
        /// <param name="cnGameSdkShareParam"></param>
        public static void Share(CnGameSdkShareParam cnGameSdkShareParam)
        {
            myShare(cnGameSdkShareParam, delegate (CnGameSdkBaseResponse<CnGameSdkShareResponseInfo, CnGameSdkShareResponseLists> cnGameSdkBaseResponse) {
                CnGameSdkShareResponseInfo cnGameSdkShareResponseInfo = cnGameSdkBaseResponse.info;
                WX.ShareAppMessage(new ShareAppMessageOption() { 
                    imageUrl   = cnGameSdkShareResponseInfo.image_url,
                    imageUrlId = cnGameSdkShareResponseInfo.image_url_id,
                    path = cnGameSdkShareResponseInfo.path, 
                    query = cnGameSdkShareResponseInfo.query, 
                    title = cnGameSdkShareResponseInfo.title, 
                    toCurrentGroup = cnGameSdkShareResponseInfo.to_current_group
                });
            });
        }
        /// <summary>
        /// 监听分享
        /// </summary>
        /// <param name="cnGameSdkShareParam"></param>
        public static void OnShare(CnGameSdkShareParam cnGameSdkShareParam)
        {
            myShare(cnGameSdkShareParam, delegate (CnGameSdkBaseResponse<CnGameSdkShareResponseInfo, CnGameSdkShareResponseLists> cnGameSdkBaseResponse) {
                CnGameSdkShareResponseInfo cnGameSdkShareResponseInfo = cnGameSdkBaseResponse.info;
                WX.OnShareAppMessage(new WXShareAppMessageParam()
                {
                    imageUrl = cnGameSdkShareResponseInfo.image_url,
                    imageUrlId = cnGameSdkShareResponseInfo.image_url_id,
                    path = cnGameSdkShareResponseInfo.path,
                    query = cnGameSdkShareResponseInfo.query,
                    title = cnGameSdkShareResponseInfo.title,
                    toCurrentGroup = cnGameSdkShareResponseInfo.to_current_group
                });
            });
        }
    }
}