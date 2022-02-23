namespace CN_GAME_SDK.param
{
    public class CnGameSdkPaySwitchParam : CnGameSdkBaseParam
    {
        /// <summary>
        /// 用户ID
        /// </summary>
        public int user_id = 0;
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
        /// 区服名称
        /// </summary>
        public string server_name = "";
        /// <summary>
        /// 角色创建时间
        /// </summary>
        public int role_create_time = 0;
        /// <summary>
        /// 角色总充值游戏币数量
        /// </summary>
        public int total_game_coin = 0;
    }
}