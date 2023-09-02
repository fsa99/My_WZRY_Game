#region 作者和版权
/*************************************************************************************
* CLR 版本:       4.0.30319.42000
* 类 名 称:       Weapon
* 机器名称:       TZTEK3083
* 命名空间:       MyGame
* 文 件 名:       Weapon
* 创建时间:       2022/8/2 19:29:40
* 作    者:       范思澳 fansiao
* 所属部门：      软件四部
* 版    权:    	  <copyright company="天准科技股份有限公司">
* 签    名:       TZTEK Technology Co.,Ltd.
* 网    站:       http://www.tztek.com/
* 邮    箱:       fansiao@tztek.com 
* 唯一标识：      086bcd9f-9047-4e24-a6c8-22a9538f6aba  
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

    public class Weapon
    {
        private string name = "";
        private string owner = "";
        private double baseDamage = 0;
        private double healthPoint = 0;
        private double criticalStrike = 0;
        private double agility = 0;
        private double dodge = 0;
        private double spellPower = 0;
        private double avoidInjury = 0;
        private double shield = 0;
        private double combatEffectiveness = 0;
        private double defense = 0;
        internal static List<Weapon> weapons = new List<Weapon>();

        public Weapon(string n, string group, double baseDamage, double healthPoint, double criticalStrike,
            double agility, double dodge, double spellPower, double avoidInjury,
            double shield, double combatEffectiveness, double defense)
        {
            this.Name = n;
            this.Owner = group;
            this.BaseDamage = baseDamage;
            this.HealthPoint = healthPoint;
            this.CriticalStrike = criticalStrike;
            this.Agility = agility;
            this.Dodge = dodge;
            this.SpellPower = spellPower;
            this.AvoidInjury = avoidInjury;
            this.Shield = shield;
            this.CombatEffectiveness = combatEffectiveness;
            this.Defense = defense;
        }


        /// <summary>
        /// 存放所有武器的列表
        /// </summary>
        internal static List<Weapon> Weapons { get => weapons; set => weapons = value; }

        /// <summary>
        /// 武器名
        /// </summary>
        public string Name { get => name; set => name = value; }

        /// <summary>
        /// 属于战士 法师 还是盗贼
        /// </summary>
        public string Owner { get => owner; set => owner = value; }

        /// <summary>
        /// 基础伤害
        /// </summary>
        public double BaseDamage { get => baseDamage; set => baseDamage = value; }

        /// <summary>
        /// 血量值
        /// </summary>
        public double HealthPoint { get => healthPoint; set => healthPoint = value; }

        /// <summary>
        /// 暴击率
        /// </summary>
        public double CriticalStrike { get => criticalStrike; set => criticalStrike = value; }

        /// <summary>
        /// 敏捷(初始0, eg:48表示增加48%的伤害)
        /// </summary>
        public double Agility { get => agility; set => agility = value; }

        /// <summary>
        /// 闪躲(初始0, eg:25,则表示有25%的几率躲闪掉该次物理伤害)
        /// </summary>
        public double Dodge { get => dodge; set => dodge = value; }

        /// <summary>
        /// 法伤(初始0, eg:45表示增加45%的法术伤害
        /// </summary>
        public double SpellPower { get => spellPower; set => spellPower = value; }

        /// <summary>
        /// 免伤(初始0, eg:15,则表示减免15%的伤害
        /// </summary>
        public double AvoidInjury { get => avoidInjury; set => avoidInjury = value; }

        /// <summary>
        /// 护盾(初始0, eg:8,则表示会把8%的伤害反弹回对方
        /// </summary>
        public double Shield { get => shield; set => shield = value; }

        /// <summary>
        /// 力量(初始0 的物理伤害)
        /// </summary>
        public double CombatEffectiveness { get => combatEffectiveness; set => combatEffectiveness = value; }

        /// <summary>
        /// 防御(初始0, 的物理伤害反弹对方，自身免该部分的伤害
        /// </summary>
        public double Defense { get => defense; set => defense = value; }

        /// <summary>
        /// 给一个武器对象 返回它非空的所有信息
        /// </summary>
        /// <param name="weapon"></param>
        /// <returns></returns>
        public static string Output(Weapon weapon)
        {
            string result = "";
            result += weapon.Name + "\r\n" + "血量：+";
            result += weapon.HealthPoint.ToString() + "\r\n" + "暴击：+";
            result += weapon.CriticalStrike.ToString() + "\r\n";
            if (weapon.BaseDamage > 0)
            {
                result += "伤害：+" + weapon.BaseDamage.ToString() + "\r\n";
            }

            if (weapon.Agility > 0)
            {
                result += "敏捷：+" + weapon.Agility.ToString() + "\r\n";
            }

            if (weapon.Dodge > 0)
            {
                result += "闪躲：+" + weapon.Dodge.ToString() + "\r\n";
            }

            if (weapon.SpellPower > 0)
            {
                result += "法伤：+" + weapon.SpellPower.ToString() + "\r\n";
            }

            if (weapon.AvoidInjury > 0)
            {
                result += "免伤：+" + weapon.AvoidInjury.ToString() + "\r\n";
            }

            if (weapon.Shield > 0)
            {
                result += "护盾：+" + weapon.Shield.ToString() + "\r\n";
            }

            if (weapon.CombatEffectiveness > 0)
            {
                result += "力量：+" + weapon.CombatEffectiveness.ToString() + "\r\n";
            }

            if (weapon.Defense > 0)
            {
                result += "防御：+" + weapon.Defense.ToString() + "\r\n";
            }

            return result;
        }
    }
}
