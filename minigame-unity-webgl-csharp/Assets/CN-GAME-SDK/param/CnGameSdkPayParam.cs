

namespace CN_GAME_SDK.param
{
    public class CnGameSdkPayParam : CnGameSdkBaseParam
    {
        /// <summary>
        /// 用户ID
        /// </summary>
        public int user_id = 0;
        /// <summary>
        /// 充值金额。单位：分
        /// </summary>
        public int money = 0;
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
        /// 产品ID
        /// </summary>
        public string product_id = "";
        /// <summary>
        /// 产品名称
        /// </summary>
        public string product_name = "";
        /// <summary>
        /// 产品描述
        /// </summary>
        public string product_desc = "";
        /// <summary>
        /// 充值透传参数
        /// </summary>
        public string pay_ext = "";
    }
}