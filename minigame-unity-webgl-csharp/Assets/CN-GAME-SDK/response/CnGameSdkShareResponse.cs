
namespace CN_GAME_SDK.response
{
    internal class CnGameSdkShareResponseInfo
    {
        /// <summary>
        /// 转发显示图片的链接
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
        /// 查询字符串
        /// </summary>
        public string query = "";
        /// <summary>
        /// 转发标题，不传则默认使用当前小游戏的昵称
        /// </summary>
        public string title = "";
        /// <summary>
        /// 是否转发到当前群
        /// </summary>
        public bool to_current_group = false;
    }

    internal class CnGameSdkShareResponseLists
    {

    }
}