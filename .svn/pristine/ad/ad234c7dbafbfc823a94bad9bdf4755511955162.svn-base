using System;
using System.Collections.Generic;
using System.Text;
using System.Reflection;
using System.ComponentModel;

namespace ITA.Utility
{
    public class Utils
    {
        /// <summary>
        /// 通过反射获取指定枚举值对应的自定义字符串
        /// </summary>
        /// <param name="enumValue"></param>
        /// <returns></returns>
        public static string GetStringFromEnum(Enum enumValue)
        {
            FieldInfo fieldInfo = enumValue.GetType().GetField(enumValue.ToString());
            object[] attr = fieldInfo.GetCustomAttributes(typeof(DescriptionAttribute), true);
            if (attr.Length > 0)
            {
                DescriptionAttribute desc = attr[0] as DescriptionAttribute;
                if (desc != null)
                {
                    return desc.Description;
                }
            }
            return enumValue.ToString();
            //return Enum.GetName(enumValue.GetType(), enumValue);
        }

        public static List<string> TrimArray(List<string> list)
        {
            List<string> newList = new List<string>();
            for(int i=0;i<list.Count;i++)
            {
                if (!newList.Contains(list[i]))
                {
                    newList.Add(list[i]);
                }
            }
            return newList;
        }

        public static int TagNumber(string strTag)
        {
            string[] strTemp = strTag.Split(' ');
            List<string> arrTag = new List<string>();
            for (int i = 0; i < strTemp.Length; i++)
            {
                if (strTemp[i].Trim() != "")
                {
                    arrTag.Add(strTemp[i]);
                }
            }
            return arrTag.Count;
        }

        /// <summary>
        /// SQL Server 全文索引 查询字符串格式化
        /// </summary>
        /// <param name="str"></param>
        /// <returns></returns>
        public static string FullTextSearchStringGenerator(string str)
        {
            List<string> list = new List<string>();
            string[] stringArray = str.Split(' ');
            foreach (string s in stringArray)
            {
                if (!string.IsNullOrEmpty(s.Trim()))
                    list.Add(string.Format("\"*{0}*\"",s.Trim()));
            }
            return string.Join(" OR ", list.ToArray());
        }
    }
}
