namespace Assets.CN_GAME_SDK.response
{
    internal class CnGameSdkBaseResponse<T_INFO,T_LISTS>
    {
        /// <summary>
        /// 状态码
        /// </summary>
        public int code = 0;
        /// <summary>
        /// 返回提示
        /// </summary>
        public string message = "";
        /// <summary>
        /// object信息
        /// </summary>
        public T_INFO info = default(T_INFO);
        /// <summary>
        /// 列表
        /// </summary>
        public T_LISTS[] lists;
        /// <summary>
        /// 请求ID
        /// </summary>
        public string request_id = "";

    }
}