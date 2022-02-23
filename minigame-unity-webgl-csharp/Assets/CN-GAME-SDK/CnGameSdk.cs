using CN_GAME_SDK.callback;
using CN_GAME_SDK.config;
using CN_GAME_SDK.helper;
using CN_GAME_SDK.param;
using System;

namespace CN_GAME_SDK
{
    public class CnGameSdk
    {
        /// <summary>
        /// 初始化
        /// </summary>
        /// <param name="cnGameSdkInitParam">初始化参数</param>
        /// <param name="callback">回调函数</param>
        public static void Init(CnGameSdkInitParam cnGameSdkInitParam, Action callback)
        {
            CnGameSdkConfig.Instance.cnGameSdkInitParam = cnGameSdkInitParam;
            CnGameSdkHelper.InitSdk(callback);
        }
        /// <summary>
        /// 登录
        /// </summary>
        /// <param name="cnGameSdkLoginParam">登录参数</param>
        /// <param name="successCallback">成功回调函数</param>
        /// <param name="failCallback">失败回调函数</param>
        /// <param name="completeCallback">完成回调函数</param>
        public static void Login(
            CnGameSdkLoginParam cnGameSdkLoginParam, 
            Action<CnGameSdkLoginCallback> successCallback, 
            Action<CnGameSdkLoginCallback> failCallback, 
            Action<CnGameSdkLoginCallback> completeCallback)
        {
            CnGameSdkHelper.Login(cnGameSdkLoginParam, successCallback, failCallback, completeCallback);
        }
        /// <summary>
        /// 充值开关
        /// </summary>
        /// <param name="cnGameSdkPaySwitchParam"></param>
        public static void PaySwitch(CnGameSdkPaySwitchParam cnGameSdkPaySwitchParam, 
            Action<CnGameSdkPaySwitchCallback> successCallback, 
            Action<CnGameSdkPaySwitchCallback> failCallback, 
            Action<CnGameSdkPaySwitchCallback> completeCallback)
        {
            CnGameSdkHelper.PaySwitch(cnGameSdkPaySwitchParam, successCallback, failCallback, completeCallback);
        }

        /// <summary>
        /// 支付
        /// </summary>
        /// <param name="cnGameSdkPayParam">支付参数</param>
        public static void Pay(CnGameSdkPayParam cnGameSdkPayParam)
        {
            CnGameSdkHelper.Pay(cnGameSdkPayParam);
        }

        /// <summary>
        /// 数据上报
        /// </summary>
        /// <param name="cnGameSdkDataReportParam"></param>
        public static void DataReport(CnGameSdkDataReportParam cnGameSdkDataReportParam)
        {
            CnGameSdkHelper.DataReport(cnGameSdkDataReportParam);
        }

        /// <summary>
        /// 主动分享
        /// </summary>
        public static void Share(CnGameSdkShareParam cnGameSdkShareParam)
        {
            CnGameSdkHelper.Share(cnGameSdkShareParam);
        }
        /// <summary>
        /// 监听分享
        /// </summary>
        /// <param name="cnGameSdkShareParam"></param>
        public static void OnShare(CnGameSdkShareParam cnGameSdkShareParam)
        {
            CnGameSdkHelper.OnShare(cnGameSdkShareParam);
        }
    }
}