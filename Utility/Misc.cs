using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.ComponentModel;
using System.Collections;

namespace ITA.Utility
{
    public class Misc
    {
        public static List<string> arrImgType = new List<string>() { ".jpg", ".gif", ".png", ".bmp"};
        public static List<string> arrTorrent = new List<string>() { ".torrent"};
        public static string filepath = "~/UploadFiles";
        public static string work_filepath = "~/UploadFiles/Works";
        public static string case_filepath = "~/UploadFiles/Cases";
        //WebControl 访问权限
        public static string Default_VisitXML = string.Format("{0},{1}", EnumMapHelper.GetStringFromEnum(RoleTypeEnum.Admin), EnumMapHelper.GetStringFromEnum(RoleTypeEnum.AdvancedRole));
        public static string Default_GridView1 = string.Format("{0}", EnumMapHelper.GetStringFromEnum(RoleTypeEnum.Admin));

        public enum RoleTypeEnum
        {
            /// <summary>
            /// 管理员
            /// </summary>
            [Description("管理员")]
            Admin = 0,

            /// <summary>
            /// 普通用户
            /// </summary>
            [Description("普通用户")]
            CommonRole = 1,

            /// <summary>
            /// 高级用户
            /// </summary>
            [Description("高级用户")]
            AdvancedRole = 2
        }


        /// <summary>
        /// 俱乐部预约
        /// </summary>
        public enum AppointmentTypeEnum { 场馆 = 1, 教练 = 2 }

        /// <summary>
        /// 商城订单状态
        /// </summary>
        public enum OrderStatusEnum { 未付款 = 1, 付款成功 = 2, 付款失败 = 3 }

        /// <summary>
        /// 支付方式
        /// </summary>
        public enum PayTypeEnum { 货到付款 = 1, 在线支付 = 2 }

    }
}
