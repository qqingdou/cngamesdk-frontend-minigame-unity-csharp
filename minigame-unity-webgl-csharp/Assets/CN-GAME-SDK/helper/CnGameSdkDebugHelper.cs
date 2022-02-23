using CN_GAME_SDK.config;
using System;
using UnityEngine;

namespace CN_GAME_SDK.helper
{
    internal class CnGameSdkDebugHelper
    {
        public static void Error(object message)
        {
            Debug.LogError(CnGameSdkConfig.TAG_CN_GAME_SDK_NAME);
            Debug.LogError(message);
        }

        public static void Log(object message)
        {
            Debug.Log(CnGameSdkConfig.TAG_CN_GAME_SDK_NAME);
            Debug.Log(message);
        }

        public static void Warning(object message)
        {
            Debug.LogWarning(CnGameSdkConfig.TAG_CN_GAME_SDK_NAME);
            Debug.LogWarning(message);
        }

        public static void Exception(Exception exception)
        {
            Debug.LogError(CnGameSdkConfig.TAG_CN_GAME_SDK_NAME);
            Debug.LogException(exception);
        }
    }
}