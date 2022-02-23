namespace CN_GAME_SDK.param
{
    public class CnGameSdkDataReportParam : CnGameSdkBaseParam
    {
        /// <summary>
        /// 用户ID
        /// </summary>
        public int user_id = 0;
        /// <summary>
        /// 上报类型.1：创建角色，2：角色升级
        /// </summary>
        public int report_type = 0;
        /// <summary>
        /// 角色ID
        /// </summary>
        public string role_id = "";
        /// <summary>
        /// 角色名称
        /// </summary>
        public string role_name = "";
        /// <summary>
        /// 角色等级
        /// </summary>
        public int role_level = 0;
        /// <summary>
        /// 区服ID
        /// </summary>
        public string server_id = "";
        /// <summary>
        /// 区服ID
        /// </summary>
        public string server_name = "";
    }
}