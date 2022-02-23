using CN_GAME_SDK.config;
using CN_GAME_SDK.param;
using CN_GAME_SDK.security;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;
using WeChatWASM;

namespace CN_GAME_SDK.helper
{
    internal class CnGameSdkCommonHelper
    {
        /// <summary>
        /// 生成唯一ID
        /// </summary>
        /// <returns></returns>
        public static string GenerateStringID()
        {
            long i = 1;
            foreach (byte b in Guid.NewGuid().ToByteArray())
            {
                i *= ((int)b + 1);
            }
            return string.Format("{0:x}", i - DateTime.Now.Ticks);

        }
        /// <summary>
        /// 生成32位唯一ID
        /// </summary>
        /// <returns></returns>
        public static string GenerateStringID32()
        {
            return CnGameSdkHashCrypt.MD5Encrypt32(GenerateStringID());
        }

        /// <summary>
        /// 字段转换为WWWForm
        /// </summary>
        /// <param name="dictionary"></param>
        /// <returns>WWWForm</returns>
        public static WWWForm ConvertDic2Form(Dictionary<string, string> dictionary)
        {
            WWWForm wWWForm = new WWWForm();
            foreach (var item in dictionary)
            {
                wWWForm.AddField(item.Key, item.Value);
            }
            return wWWForm;
        }

        /// <summary>
        /// 构建请求加密SIGN
        /// </summary>
        /// <param name="dictionary"></param>
        /// <returns></returns>
        public static string BuildSign(Dictionary<string, string> dictionary, string key)
        {
            Dictionary<string, string> sortDictionary = dictionary.OrderBy(p => p.Key).ToDictionary(p => p.Key, o => o.Value);

            StringBuilder stringBuilder = new StringBuilder();

            foreach (var item in sortDictionary)
            {
                if (item.Key == CnGameSdkConfig.SIGN_KEY || string.IsNullOrEmpty(item.Value))
                {
                    continue;
                }
                stringBuilder.Append($"&{item.Key}={item.Value}");
            }

            string encryptStr = stringBuilder.Remove(0, 1) + key;

            return CnGameSdkHashCrypt.MD5Encrypt32(encryptStr);
        }

        /// <summary>
        /// 合并字典
        /// </summary>
        /// <param name="dictionarys"></param>
        /// <returns></returns>
        public static Dictionary<string, string> MergeDictionary(params Dictionary<string,string>[] dictionarys)
        {
            Dictionary<string, string> mergeDics = new Dictionary<string, string>();
            foreach(var itemDic in dictionarys)
            {
                foreach(var dicItem in itemDic)
                {
                    if (!mergeDics.ContainsKey(dicItem.Key))
                    {
                        mergeDics.Add(dicItem.Key, dicItem.Value);
                    }
                }
            }
            return mergeDics;
        }

        /// <summary>
        /// 获取请求的全局参数
        /// </summary>
        /// <returns></returns>
        public static Dictionary<string, string> GetRequestGlobalParams()
        {
            CnGameSdkConfig cnGameSdkConfig = CnGameSdkConfig.Instance;
            WeChatWASM.SystemInfo systemInfo = cnGameSdkConfig.systemInfo;
            EnterOptionsGame enterOptionsGame = cnGameSdkConfig.enterOptionsGame;
            CnGameSdkInitParam cnGameSdkInitParam = cnGameSdkConfig.cnGameSdkInitParam;
            Dictionary<string, string> query = enterOptionsGame.query;
            Dictionary<string, string> globalParams = new Dictionary<string, string>();
            globalParams.Add("wx_appid", cnGameSdkInitParam.wx_app_id);
            globalParams.Add("app_version_name", cnGameSdkInitParam.app_version_name);
            globalParams.Add("app_version_code", cnGameSdkInitParam.app_version_code.ToString());
            globalParams.Add("sdk_version", CnGameSdkConfig.SDK_VERSION_CODE_NAME);
            globalParams.Add("trace_id", cnGameSdkConfig.TraceId);

            if (enterOptionsGame != null)
            {
                if (query != null)
                {
                    if (query.ContainsKey("agent_id"))
                    {
                        globalParams.Add("agent_id", query["agent_id"]);
                    }
                    if (query.ContainsKey("site_id"))
                    {
                        globalParams.Add("site_id", query["site_id"]);
                    }
                    if (query.ContainsKey("gdt_vid"))
                    {
                        globalParams.Add("gdt_vid", query["gdt_vid"]);
                    }
                    if (query.ContainsKey("weixinadinfo"))
                    {
                        globalParams.Add("weixinadinfo", query["weixinadinfo"]);
                    }
                }
                globalParams.Add("launch_scene", enterOptionsGame.scene.ToString());
            }

            if (systemInfo != null)
            {
                globalParams.Add("platform", systemInfo.platform);
                globalParams.Add("device_brand", systemInfo.brand);
                globalParams.Add("model", systemInfo.model);
                globalParams.Add("system_version", systemInfo.system);
            }
            return globalParams;
        }
    }
}