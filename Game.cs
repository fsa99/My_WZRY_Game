#region 作者和版权
/*************************************************************************************
* CLR 版本:       4.0.30319.42000
* 类 名 称:       Game
* 机器名称:       TZTEK3083
* 命名空间:       MyGame
* 文 件 名:       Game
* 创建时间:       2022/8/24 10:51:01
* 作    者:       范思澳 fansiao
* 所属部门：      软件四部
* 版    权:    	  <copyright company="天准科技股份有限公司">
* 签    名:       TZTEK Technology Co.,Ltd.
* 网    站:       http://www.tztek.com/
* 邮    箱:       fansiao@tztek.com 
* 唯一标识：      1cacd397-ece2-4eb3-9b66-6ae201726bd5  
* 登录用户:       fansiao
* 所 属 域:       TZTEK
* 创建年份:       2022
* 修改时间:
* 修 改 人:
************************************************************************************/
#endregion

namespace MyGame
{
    using System;
    using System.Collections.Generic;

    public class Game
    {
        private static string[] roleMessList = new string[50];
        private static string[] rightRoleList = new string[50];
        private static Dictionary<string, GameRole> dictRole = new Dictionary<string, GameRole>();
        private static Dictionary<string, Weapon> dictWeapon = new Dictionary<string, Weapon>();

        // 分别创建英雄角色的实例  并初始化名字
        private Robbers LanLingWang = new Robbers("兰陵王");
        private Robbers AKe = new Robbers("阿珂");
        private Robbers NaKeLuLu = new Robbers("娜可露露");
        private Mage Daji = new Mage("妲己");
        private Mage ZhuGeLiang = new Mage("诸葛亮");
        private Mage MiYue = new Mage("芈月");
        private Soldier SunWuKong = new Soldier("孙悟空", 120);
        private Soldier Kai = new Soldier("凯", 120);
        private Soldier Yao = new Soldier("耀", 120);
        // 分别创建各个武器
        public static Weapon weaponSZAS = new Weapon("霜之哀伤", "战士", 0, 36, 10, 0, 0, 0, 0, 0, 20, 10);
        public static Weapon weaponHZSZ = new Weapon("灰烬使者", "战士,盗贼", 0, 40, 12, 16, 0, 0, 0, 0, 20, 0);
        public static Weapon weaponSGLSQZ = new Weapon("萨格拉斯权杖", "法师,盗贼", 0, 30, 17, 0, 0, 26, 0, 0, 0, 0);
        public static Weapon weaponATYS = new Weapon("埃提耶什", "法师", 0, 33, 20, 0, 0, 20, 0, 2, 0, 0);
        public static Weapon weaponAXRSSR = new Weapon("埃辛诺斯双刃", "战士,盗贼", 5, 34, 18, 28, 0, 0, 0, 0, 0, 0);
        public static Weapon weaponLTZN = new Weapon("雷霆之怒", "盗贼", 0, 36, 15, 20, 20, 0, 0, 0, 0, 0);

        public Game()
        {

        }

        /// <summary>
        /// Game 一些集合的初始化
        /// </summary>
        public void Init()
        {
            Flag = -1;
            RoundNum = 1;
            DictRAdd();
            DictWAdd();
            // 分别将法师 战士 盗贼 武器 加入对应的列表中去
            Mage.MageRoleList.Add(Daji);
            Mage.MageRoleList.Add(MiYue);
            Mage.MageRoleList.Add(ZhuGeLiang);
            Soldier.SoldierRoleList.Add(Kai);
            Soldier.SoldierRoleList.Add(SunWuKong);
            Soldier.SoldierRoleList.Add(Yao);
            Robbers.RobbersRoleList.Add(NaKeLuLu);
            Robbers.RobbersRoleList.Add(AKe);
            Robbers.RobbersRoleList.Add(LanLingWang);
            Weapon.Weapons.Add(weaponSZAS);
            Weapon.Weapons.Add(weaponHZSZ);
            Weapon.Weapons.Add(weaponSGLSQZ);
            Weapon.Weapons.Add(weaponATYS);
            Weapon.Weapons.Add(weaponAXRSSR);
            Weapon.Weapons.Add(weaponLTZN);
        }

        /// <summary>
        /// 角色字典的添加
        /// </summary>
        /// <param name="role"></param>
        private void DictRAdd()
        {
            DictRole.Add(LanLingWang.Name, LanLingWang);
            DictRole.Add(AKe.Name, AKe);
            DictRole.Add(NaKeLuLu.Name, NaKeLuLu);
            DictRole.Add(Daji.Name, Daji);
            DictRole.Add(MiYue.Name, MiYue);
            DictRole.Add(ZhuGeLiang.Name, MiYue);
            DictRole.Add(SunWuKong.Name, SunWuKong);
            DictRole.Add(Kai.Name, Kai);
            DictRole.Add(Yao.Name, Yao);
        }

        /// <summary>
        /// 武器字典的添加
        /// </summary>
        /// <param name="role"></param>
        private void DictWAdd()
        {
            DictWeapon.Add(weaponSZAS.Name, weaponSZAS);
            DictWeapon.Add(weaponHZSZ.Name, weaponHZSZ);
            DictWeapon.Add(weaponSGLSQZ.Name, weaponSGLSQZ);
            DictWeapon.Add(weaponATYS.Name, weaponATYS);
            DictWeapon.Add(weaponAXRSSR.Name, weaponAXRSSR);
            DictWeapon.Add(weaponLTZN.Name, weaponLTZN);
        }

        /// <summary>
        /// 标志符 默认为 -1 方便某些循环操作
        /// </summary>
        public static int Flag { get; set; }

        /// <summary>
        /// 左 记录选中的角色对象
        /// </summary>
        internal static GameRole LPitchUpRole { get; set; }

        /// <summary>
        /// 右 记录选中的角色对象
        /// </summary>
        internal static GameRole RPitchUpRole { get; set; }

        /// <summary>
        /// 三 记录选中的角色对象
        /// </summary>
        internal static GameRole TPitchUpRole { get; set; }

        /// <summary>
        /// 左 记录选中的武器的对象
        /// </summary>
        internal static Weapon LPitchUpWeapon { get; set; }

        /// <summary>
        /// 右 记录选中的武器的对象
        /// </summary>
        internal static Weapon RPitchUpWeapon { get; set; }

        /// <summary>
        /// 攻击权，false表示红方，true表示蓝方
        /// </summary>
        public static bool AttackPower { get; set; }

        /// <summary>
        /// 左 游戏角色 的 字符串信息 存为数据列表
        /// </summary>
        public static string[] RoleMessList { get => roleMessList; set => roleMessList = value; }

        /// <summary>
        /// 回合数
        /// </summary>
        public static int RoundNum { get; set; }

        /// <summary>
        /// 记录游戏是否结束
        /// </summary>
        public static bool GameIsOver { get; set; }

        /// <summary>
        /// 是否 暴击 并显示出来
        /// </summary>
        public static bool IsShowCrit { get; set; }

        /// <summary>
        /// 是否 闪躲 并显示出来
        /// </summary>
        public static bool IsShowDodge { get; set; }

        /// <summary>
        /// 存放所有角色父类的字典 
        /// 键是角色名字
        /// 值是角色对象
        /// </summary>
        internal static Dictionary<string, GameRole> DictRole { get => dictRole; set => dictRole = value; }

        /// <summary>
        /// 存放所有武器的字典 
        /// 键是武器名字
        /// 值是武器对象
        /// </summary>
        public static Dictionary<string, Weapon> DictWeapon { get => dictWeapon; set => dictWeapon = value; }

        /// <summary>
        /// 角色的提示信息
        /// </summary>
        /// <param name="name"></param>
        /// <returns></returns>
        public static string RoleHint(string name)
        {
            string result = "";
            switch (DictRole[name].Group)
            {
                case "战士":
                    result = Soldier.Output((Soldier)DictRole[name]);
                    break;
                case "盗贼":
                    result = Robbers.Output((Robbers)DictRole[name]);
                    break;
                case "法师":
                    result = Mage.Output((Mage)DictRole[name]);
                    break;
                default:
                    break;
            }

            return result;
        }


        /// <summary>
        /// 以字符串列表的形式返回 角色对象各属性值信息
        /// 赋值给RoleMessList存储
        /// 便于游戏窗体中 角色各信息label的赋值
        /// </summary>
        internal static void StrTOList(GameRole role, Weapon weapon)
        {
            RoleMessList = null;
            string message;
            if (role.Group == "战士")
            {
                Soldier sRole = (Soldier)role;
                message = Soldier.Output(sRole);
                strToList();
            }

            if (role.Group == "盗贼")
            {
                Robbers rRole = (Robbers)role;
                message = Robbers.Output(rRole);
                strToList();
            }

            if (role.Group == "法师")
            {
                Mage mRole = (Mage)role;
                message = Mage.Output(mRole);
                strToList();
            }

            void strToList()
            {
                message = message.Replace("\r\n", "：");
                message = message.Replace("\t", "：");
                if (!(weapon is null))
                {
                    message += "\t\n" + "武器" + "：" + weapon.Name;
                }
                RoleMessList = message.Split(new string[] { "\t\n", "：" }, StringSplitOptions.RemoveEmptyEntries);
            }
        }

        /// <summary>
        /// 将武器的属性 添加至角色对应的属性上
        /// </summary>
        /// <param name="role">角色</param>
        /// <param name="weapon">武器</param>
        internal static void AddWeaponProp(GameRole role, Weapon weapon)
        {
            role.HealthPoint += weapon.HealthPoint;
            role.BaseDamage += weapon.BaseDamage;
            role.CriticalStrike += weapon.CriticalStrike;
            if (role.Group == "战士")
            {
                ((Soldier)role).CombatEffectiveness += weapon.CombatEffectiveness;
                ((Soldier)role).Defense += weapon.Defense;
            }

            if (role.Group == "盗贼")
            {
                ((Robbers)role).Agility += weapon.Agility;
                ((Robbers)role).Dodge += weapon.Dodge;
            }

            if (role.Group == "法师")
            {
                ((Mage)role).SpellPower += weapon.SpellPower;
                ((Mage)role).AvoidInjury += weapon.AvoidInjury;
            }
        }

        /// <summary>
        /// 返回一次进攻后 
        /// 攻击者剩余的HP
        /// 受害者剩余的HP
        /// 攻击者造成的实际伤害
        /// 受害者反弹的实际伤害
        /// </summary>
        /// <param name="attack">攻击者</param>
        /// <param name="victim">受害者</param>
        /// <returns></returns>
        internal static (double, double, double, double) AnAttack(GameRole attack, GameRole victim)
        {
            // 被攻击的英雄收到的伤害值
            double injuriesReceived = 0;
            // 攻击者发起一次进攻后 收到的伤害
            double rebound = 0;
            // 暴击倍数
            double multipleCrit = 1;
            // 闪躲系数
            double numDodge = 1;
            // 先判断是否有人血量低于零  如果低于零则游戏结束
            // GameOver();
            if (!GameIsOver)
            {
                if (attack.Group == "战士" && victim.Group == "战士")
                {
                    if (IsCritOrDodge(attack.CriticalStrike))
                    {
                        multipleCrit = 2;
                        IsShowCrit = true;
                    }

                    injuriesReceived = multipleCrit *
                        attack.BaseDamage *
                        (1 + ((Soldier)attack).CombatEffectiveness * 0.01);
                    rebound = injuriesReceived * ((Soldier)victim).Defense * 0.01;
                    injuriesReceived -= rebound;
                }
                else if (attack.Group == "战士" && victim.Group == "法师")
                {
                    if (IsCritOrDodge(attack.CriticalStrike))
                    {
                        multipleCrit = 2;
                        IsShowCrit = true;
                    }

                    injuriesReceived = multipleCrit *
                        attack.BaseDamage *
                        (1 + ((Soldier)attack).CombatEffectiveness * 0.01) *
                        (1 - ((Mage)victim).AvoidInjury * 0.01);
                    rebound = injuriesReceived * ((Mage)victim).Shield * 0.01;
                }
                else if (attack.Group == "战士" && victim.Group == "盗贼")
                {
                    if (IsCritOrDodge(attack.CriticalStrike))
                    {
                        multipleCrit = 2;
                        IsShowCrit = true;
                    }

                    if (IsCritOrDodge(((Robbers)victim).Dodge))
                    {
                        numDodge = 0;
                        IsShowDodge = true;
                    }

                    injuriesReceived = multipleCrit * attack.BaseDamage *
                        (1 + ((Soldier)attack).CombatEffectiveness * 0.01) *
                        numDodge;
                }
                else if (attack.Group == "盗贼" && victim.Group == "法师")
                {
                    if (IsCritOrDodge(attack.CriticalStrike))
                    {
                        multipleCrit = 2;
                        IsShowCrit = true;
                    }

                    injuriesReceived = multipleCrit *
                        attack.BaseDamage *
                        (1 + ((Robbers)attack).Agility * 0.01) *
                        (1 - ((Mage)victim).AvoidInjury * 0.01);
                    rebound = injuriesReceived * ((Mage)victim).Shield * 0.01;
                }
                else if (attack.Group == "盗贼" && (victim.Group == "战士" || victim.Group == "盗贼"))
                {
                    if (IsCritOrDodge(attack.CriticalStrike))
                    {
                        multipleCrit = 2;
                        IsShowCrit = true;
                    }
                    injuriesReceived = multipleCrit *
                        attack.BaseDamage *
                        (1 + ((Robbers)attack).Agility * 0.01);
                }
                else if (attack.Group == "法师" && victim.Group == "法师")
                {
                    if (IsCritOrDodge(attack.CriticalStrike))
                    {
                        multipleCrit = 2;
                        IsShowCrit = true;
                    }

                    injuriesReceived = multipleCrit *
                        attack.BaseDamage *
                        (1 + ((Mage)attack).SpellPower * 0.01) *
                        (1 - ((Mage)victim).AvoidInjury * 0.01);
                    rebound = injuriesReceived * ((Mage)victim).Shield * 0.01;
                }
                else if (attack.Group == "法师" && (victim.Group == "战士" || victim.Group == "盗贼"))
                {
                    if (IsCritOrDodge(attack.CriticalStrike))
                    {
                        multipleCrit = 2;
                        IsShowCrit = true;
                    }
                    injuriesReceived = multipleCrit *
                        attack.BaseDamage *
                        (1 + ((Mage)attack).SpellPower * 0.01);
                }
            }

            attack.HealthPoint -= rebound;
            victim.HealthPoint -= injuriesReceived;
            return (attack.HealthPoint, victim.HealthPoint,  -1 * injuriesReceived, -1 * rebound);
        }

        /// <summary>
        /// 计算是否暴击 或 闪躲
        /// </summary>
        /// <param name="probability"></param>
        /// <returns></returns>
        private static bool IsCritOrDodge(double probability)
        {
            Random random = new Random();
            int i = random.Next(0, 10000);
            if (i < probability * 100)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
    }
}
