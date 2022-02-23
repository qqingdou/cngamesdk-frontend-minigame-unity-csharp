namespace CN_GAME_SDK.param
{
    public class CnGameSdkShareParam : CnGameSdkBaseParam
    {
        /// <summary>
        /// 分享标题
        /// </summary>
        public string title = "";
        /// <summary>
        /// 图片地址
        /// </summary>
        public string image_url = "";
        /// <summary>
        /// 审核通过的图片 ID
        /// </summary>
        public string image_url_id = "";
        /// <summary>
        /// 独立分包路径
        /// </summary>
        public string path = "";
        /// <summary>
        /// 是否转发到当前群
        /// </summary>
        public bool to_current_group = false;
        /// <summary>
        /// 分享后透传的参数
        /// </summary>
        public string share_ext = "";
    }
}