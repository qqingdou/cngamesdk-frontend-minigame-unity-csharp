﻿using System;
namespace WeChatWASM
{
    /// <summary>
    /// Grid 广告 详见 https://developers.weixin.qq.com/minigame/dev/guide/open-ability/ad/grid-ad.html
    /// </summary>
    public class WXGridAd:WXBaseAd,IWXAdResizable
    {

        public WXAdBaseStyle style;

        public Action<WXADResizeResponse> onResizeAction;

        public WXGridAd(string id, Style style) : base(id)
        {
            instanceId = id;
            this.style = new WXAdBaseStyle(id, style);
        }

        public void OnResizeCallback(WXADResizeResponse res)
        {
            onResizeAction?.Invoke(res);
        }

        /// <summary>
        /// 监听 Grid 广告尺寸变化事件。
        /// </summary>
        /// <param name="action">banner 广告尺寸变化事件的回调函数</param>
        public void OnResize(Action<WXADResizeResponse> action)
        {
            onResizeAction += action;
        }

        /// <summary>
        /// 取消监听 Grid 广告尺寸变化事件
        /// </summary>
        /// <param name="action">banner 广告尺寸变化事件的回调函数</param>
        public void OffResize(Action<WXADResizeResponse> action)
        {
            onResizeAction -= action;
        }

        /// <summary>
        /// 隐藏 Grid 广告。
        /// </summary>
        public void Hide()
        {
            WXSDKManagerHandler.Instance.HideAd(instanceId);
        }

    }
}
