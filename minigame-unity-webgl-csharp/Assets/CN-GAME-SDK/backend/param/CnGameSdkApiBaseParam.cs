using CN_GAME_SDK.config;
using CN_GAME_SDK.helper;
using CN_GAME_SDK.param;
using System;
using System.Collections.Generic;
using System.Reflection;
using WeChatWASM;
using System.Linq;
using System.Text;
using CN_GAME_SDK.security;

namespace CN_GAME_SDK.backend.param
{
    abstract internal class CnGameSdkApiBaseParam : CN_GAME_SDK.param.CnGameSdkBaseParam
    {
        /// <summary>
        /// 每次请求ID
        /// </summary>
        public string request_id = "";

        public CnGameSdkApiBaseParam()
        {
            if (string.IsNullOrEmpty(this.request_id))
            {
                this.request_id = CnGameSdkCommonHelper.GenerateStringID32();
            }
        }
        /// <summary>
        /// 获取请求的数据
        /// </summary>
        /// <returns></returns>
        public Dictionary<string, string> GetPostData()
        {
            Dictionary<string, string> mergeDictionary = 
                CnGameSdkCommonHelper.MergeDictionary(CnGameSdkCommonHelper.GetRequestGlobalParams(), this.GetAttributes());
            if (!mergeDictionary.ContainsKey(CnGameSdkConfig.SIGN_KEY))
            {
                mergeDictionary.Add(CnGameSdkConfig.SIGN_KEY, CnGameSdkCommonHelper.BuildSign(mergeDictionary, CnGameSdkConfig.Instance.cnGameSdkInitParam.login_key));
            }
           
            return mergeDictionary;
        }

        /// <summary>
        /// 请求地址增加额外参数，方便追踪整个链路
        /// </summary>
        /// <param name="url"></param>
        /// <returns></returns>
        protected string RequestUrlAppendExtraParams(string url)
        {
            if (string.IsNullOrEmpty(url))
            {
                return "";
            }

            string connectStr = url.IndexOf("?") > -1 ? "&" : "?";

            return $"{url}{connectStr}request_id={this.request_id}&trace_id={CnGameSdkConfig.Instance.TraceId}";
        }

        abstract public string GetRequestUrl();
    }
}