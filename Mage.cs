#region 作者和版权
/*************************************************************************************
* CLR 版本:       4.0.30319.42000
* 类 名 称:       Mage
* 机器名称:       TZTEK3083
* 命名空间:       MyGame
* 文 件 名:       Mage
* 创建时间:       2022/7/29 9:36:08
* 作    者:       范思澳 fansiao
* 所属部门：      软件四部
* 版    权:    	  <copyright company="天准科技股份有限公司">
* 签    名:       TZTEK Technology Co.,Ltd.
* 网    站:       http://www.tztek.com/
* 邮    箱:       fansiao@tztek.com 
* 唯一标识：      a24f5329-3247-476b-86d5-fc50b408342d  
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

    class Mage :GameRole
    {
        private double spellPower = 45;
        private double avoidInjury = 15;
        private double shield = 8; 
        internal static List<Mage> mageRoleList = new List<Mage>();

        public Mage(string name):base(name)
        {
            Group = "法师";
        }

        /*public Mage(string name, double SP, double AI, double SL,double HP) : base(name , HP)
        {
            this.SpellPower = SP;
            this.AvoidInjury = AI;
            this.Shield = SL;
        }

        public Mage(string name, double SP, double AI, double SL, double BD, double HP, double CL) : base(name, BD, HP, CL)
        {
            this.SpellPower = SP;
            this.AvoidInjury = AI;
            this.Shield = SL;
        }*/


        /// <summary>
        /// 法伤(初始45, eg:45表示增加45%的法术伤害
        /// </summary>
        public double SpellPower { get => spellPower; set => spellPower = value; }

        /// <summary>
        /// 免伤(初始15, eg:15,则表示减免15%的伤害
        /// </summary>
        public double AvoidInjury { get => avoidInjury; set => avoidInjury = value; }

        /// <summary>
        /// 护盾(初始8, eg:8,则表示会把8%的伤害反弹回对方
        /// </summary>
        public double Shield { get => shield; set => shield = value; }

        /// <summary>
        /// 存放所有法师的列表
        /// </summary>
        internal static List<Mage> MageRoleList { get => mageRoleList; set => mageRoleList = value; }

        /// <summary>
        /// 给一个法师的对象 能输出他的所有属性
        /// </summary>
        /// <param name="soldier"></param>
        /// <returns></returns>
        public static string Output(Mage mage)
        {
            string result = "";
            result += mage.Name + "\t" + mage.Group + "\r\n" + "血量：";
            result += mage.HealthPoint.ToString() + "\r\n" + "伤害：";
            result += mage.BaseDamage.ToString() + "\r\n" + "暴击：";
            result += mage.CriticalStrike.ToString() + "\r\n" + "法伤：";
            result += mage.SpellPower.ToString() + "\r\n" + "免伤：";
            result += mage.AvoidInjury.ToString() + "\r\n" + "护盾：";
            result += mage.Shield.ToString();
            return result;
        }
    }
}
