#region 作者和版权
/*************************************************************************************
* CLR 版本:       4.0.30319.42000
* 类 名 称:       Soldier
* 机器名称:       TZTEK3083
* 命名空间:       MyGame
* 文 件 名:       Soldier
* 创建时间:       2022/7/29 9:25:26
* 作    者:       范思澳 fansiao
* 所属部门：      软件四部
* 版    权:    	  <copyright company="天准科技股份有限公司">
* 签    名:       TZTEK Technology Co.,Ltd.
* 网    站:       http://www.tztek.com/
* 邮    箱:       fansiao@tztek.com 
* 唯一标识：      ad5fe559-b777-436a-855a-b505e87fc087  
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

    class Soldier :GameRole
    {
        private double combatEffectiveness = 50;
        private double defense = 6;
        private static List<Soldier> soldierRoleList = new List<Soldier>();
        private static List<Soldier> soldierWeaponList = new List<Soldier>();

        public Soldier(string name, double HP) : base(name, HP)
        {
            Group = "战士";
        }

        /*public Soldier(string name, double CE, double DF, double BD, double HP, double CL) : base(name, BD, HP, CL)
        {
            this.CombatEffectiveness = CE;
            this.Defense = DF;
        }*/


        /// <summary>
        /// 力量(初始50, eg:50表示增加50%的物理伤害)
        /// </summary>
        public double CombatEffectiveness { get => combatEffectiveness; set => combatEffectiveness = value; }

        /// <summary>
        /// 防御(初始6, eg:6,则表示会把6%的物理伤害反弹回对方，自身则可减免该部分的伤害
        /// </summary>
        public double Defense { get => defense; set => defense = value; }

        /// <summary>
        /// 存放所有战士的列表
        /// </summary>
        internal static List<Soldier> SoldierRoleList { get => soldierRoleList; set => soldierRoleList = value; }

        /// <summary>
        /// 存放该类英雄所能有的武器
        /// </summary>
        internal static List<Soldier> SoldierWeaponList { get => soldierWeaponList; set => soldierWeaponList = value; }

        /// <summary>
        /// 给一个战士的对象 能输出他的所有属性
        /// </summary>
        /// <param name="soldier"></param>
        /// <returns></returns>
        public static string Output(Soldier soldier)
        {
            string result = "";
            result += soldier.Name + "\t" + soldier.Group + "\r\n" + "血量：";
            result += soldier.HealthPoint.ToString() + "\r\n" + "伤害：";
            result += soldier.BaseDamage.ToString() + "\r\n" + "暴击：";
            result += soldier.CriticalStrike.ToString() + "\r\n" + "力量：";
            result += soldier.CombatEffectiveness.ToString() + "\r\n" + "防御：";
            result += soldier.Defense.ToString();
            return result;
        }
    }
}
