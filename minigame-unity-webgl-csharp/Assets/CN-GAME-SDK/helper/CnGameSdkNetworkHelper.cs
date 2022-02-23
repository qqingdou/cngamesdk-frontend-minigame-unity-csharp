using CN_GAME_SDK.config;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;

namespace CN_GAME_SDK.helper
{
    public class CnGameSdkNetworkHelper : MonoBehaviour
    {
        private static object LockObject;

        private static GameObject MyGameObject;
        /// <summary>
        /// 获取实例
        /// </summary>
        /// <returns></returns>
        public static CnGameSdkNetworkHelper GetInstance()
        {
            lock (LockObject)
            {
                if (MyGameObject != null && 
                    MyGameObject.GetComponents<CnGameSdkNetworkHelper>().Length >= CnGameSdkConfig.GAME_OBEJCT_DESTORY_NUM)
                {
                    Destroy(MyGameObject);
                    MyGameObject = null;
                }
                if (MyGameObject == null)
                {
                    MyGameObject = new GameObject();
                }
            }
            
            return MyGameObject.AddComponent<CnGameSdkNetworkHelper>();
        }
        /// <summary>
        /// 请求地址
        /// </summary>
        public string Url;
        /// <summary>
        /// 超时时间。单位:秒
        /// </summary>
        public int Timeout = CnGameSdkConfig.HTTP_TIME_OUT;
        /// <summary>
        /// POST 参数
        /// </summary>
        public WWWForm PostData;
        /// <summary>
        /// 头部信息
        /// </summary>
        public Dictionary<string, string> Headers;
        /// <summary>
        /// 成功回调函数
        /// </summary>
        public Action<string> SuccessCallback;
        /// <summary>
        /// 失败回调
        /// </summary>
        public Action FailCallback;
        /// <summary>
        /// 完成回调
        /// </summary>
        public Action CompleteCallback;

        /// <summary>
        /// GET 请求
        /// </summary>
        public void Get()
        {
            StartCoroutine(CoroutineGet());
        }

        private IEnumerator CoroutineGet()
        {
            UnityWebRequest webRequest = UnityWebRequest.Get(this.Url);
            webRequest.timeout = this.Timeout;
            Dictionary<string, string> headers = this.Headers;
            if (headers != null && headers.Count > 0)
            {
                foreach (var header in headers)
                {
                    webRequest.SetRequestHeader(header.Key, header.Value);
                }
            }

            yield return webRequest.SendWebRequest();

            try
            {
                if (webRequest.isHttpError || webRequest.isNetworkError)
                {
                    CnGameSdkDebugHelper.Error(webRequest.error);
                    if (this.FailCallback != null)
                    {
                        this.FailCallback();
                    }
                }
                else
                {
                    if (this.SuccessCallback != null)
                    {
                        this.SuccessCallback(webRequest.downloadHandler.text);
                    }
                }
            }
            catch(Exception exception)
            {
                CnGameSdkDebugHelper.Exception(exception);
            }
            finally
            {
                if(this.CompleteCallback != null)
                {
                    this.CompleteCallback();
                }
            }
        }

        /// <summary>
        /// POST请求
        /// </summary>
        public void Post()
        {
            StartCoroutine(CoroutinePost());
        }

        private IEnumerator CoroutinePost()
        {

            UnityWebRequest webRequest = UnityWebRequest.Post(this.Url, this.PostData);
            webRequest.timeout = this.Timeout;
            Dictionary<string, string> headers = this.Headers;
            if (headers != null && headers.Count > 0)
            {
                foreach (var header in headers)
                {
                    webRequest.SetRequestHeader(header.Key, header.Value);
                }
            }

            yield return webRequest.SendWebRequest();

            try
            {
                if (webRequest.isHttpError || webRequest.isNetworkError)
                {
                    CnGameSdkDebugHelper.Error(webRequest.error);
                    if (this.FailCallback != null)
                    {
                        this.FailCallback();
                    }
                }
                else
                {
                    if (this.SuccessCallback != null)
                    {
                        this.SuccessCallback(webRequest.downloadHandler.text);
                    }
                }
            }
            catch (Exception exception)
            {
                CnGameSdkDebugHelper.Exception(exception);
            }
            finally
            {
                if (this.CompleteCallback != null)
                {
                    this.CompleteCallback();
                }
            }
        }
    }
}