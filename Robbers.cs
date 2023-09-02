#region 作者和版权
/*************************************************************************************
* CLR 版本:       4.0.30319.42000
* 类 名 称:       Robbers
* 机器名称:       TZTEK3083
* 命名空间:       MyGame
* 文 件 名:       Robbers
* 创建时间:       2022/7/29 9:43:51
* 作    者:       范思澳 fansiao
* 所属部门：      软件四部
* 版    权:    	  <copyright company="天准科技股份有限公司">
* 签    名:       TZTEK Technology Co.,Ltd.
* 网    站:       http://www.tztek.com/
* 邮    箱:       fansiao@tztek.com 
* 唯一标识：      8b112fbc-3711-4aff-b980-5bc03e961294  
* 登录用户:       fansiao
* 所 属 域:       TZTEK
* 创建年份:       2022
* 修改时间:
* 修 改 人:
************************************************************************************/
#endregion

namespace MyGame
{
    using System.Collections.Generic;

    class Robbers :GameRole
    {
        private double agility = 48;  
        private double dodge = 25;
        private static List<Robbers> robbersRoleList = new List<Robbers>();

        public Robbers(string name) : base(name)
        {
            Group = "盗贼";
        }

        /*public Robbers(string name, double AG, double DD, double PH) : base(name, PH)
        {
            this.Agility = AG;
            this.Dodge = DD;
        }

        public Robbers(string name, double AG, double DD, double BD, double HP, double CL) : base(name, BD, HP, CL)
        {
            this.Agility = AG;
            this.Dodge = DD;
        }*/

        /// <summary>
        /// 敏捷(初始48, eg:48表示增加48%的伤害)
        /// </summary>
        public double Agility { get => agility; set => agility = value; }

        /// <summary>
        /// 闪躲(初始25, eg:25,则表示有25%的几率躲闪掉该次物理伤害)
        /// </summary>
        public double Dodge { get => dodge; set => dodge = value; }

        /// <summary>
        /// 存放所有盗贼的列表
        /// </summary>
        internal static List<Robbers> RobbersRoleList { get => robbersRoleList; set => robbersRoleList = value; }

        /// <summary>
        /// 给一个盗贼的对象 能输出他的所有属性
        /// </summary>
        /// <param name="soldier"></param>
        /// <returns></returns>
        public static string Output(Robbers robbers)
        {
            string result = "";
            result += robbers.Name + "\t" + robbers.Group + "\r\n" + "血量：";
            result += robbers.HealthPoint.ToString() + "\r\n" + "伤害：";
            result += robbers.BaseDamage.ToString() + "\r\n" + "暴击：";
            result += robbers.CriticalStrike.ToString() + "\r\n" + "敏捷：";
            result += robbers.Agility.ToString() + "\r\n" + "闪躲：";
            result += robbers.Dodge.ToString();
            return result;
        }
    }
}
