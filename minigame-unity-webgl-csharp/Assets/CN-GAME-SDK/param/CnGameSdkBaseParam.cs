using System;
using System.Collections.Generic;
using System.Reflection;

namespace CN_GAME_SDK.param
{
    public class CnGameSdkBaseParam 
    {
        /// <summary>
        /// 通过反射获取类的属性
        /// </summary>
        /// <returns></returns>
        public Dictionary<string, string> GetAttributes()
        {
            Dictionary<string, string> dictionary = new Dictionary<string, string>();

            Type type = this.GetType();

            FieldInfo[] fieldInfos = type.GetFields();

            if(fieldInfos.Length > 0)
            {
                foreach (FieldInfo fieldInfo in fieldInfos)
                {
                    dictionary.Add(fieldInfo.Name, fieldInfo.GetValue(this).ToString());
                }
            }
            return dictionary;
        }
      
    }
}