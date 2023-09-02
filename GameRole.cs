#region 作者和版权
/*************************************************************************************
* CLR 版本:       4.0.30319.42000
* 类 名 称:       GameRole
* 机器名称:       TZTEK3083
* 命名空间:       MyGame
* 文 件 名:       GameRole
* 创建时间:       2022/7/29 9:10:41
* 作    者:       范思澳 fansiao
* 所属部门：      软件四部
* 版    权:    	  <copyright company="天准科技股份有限公司">
* 签    名:       TZTEK Technology Co.,Ltd.
* 网    站:       http://www.tztek.com/
* 邮    箱:       fansiao@tztek.com 
* 唯一标识：      77c3f27c-c52c-406a-b7db-4e5804dfda64  
* 登录用户:       fansiao
* 所 属 域:       TZTEK
* 创建年份:       2022
* 修改时间:
* 修 改 人:
************************************************************************************/
#endregion

namespace MyGame
{
    class GameRole
    {
        private string name = "";
        private string group = "";
        private double baseDamage = 20;     
        private double healthPoint = 100;   
        private double criticalStrike = 20; 

        public GameRole(string name)
        {
            this.Name = name;
        }

        public GameRole(string name, double HP)
        {
            this.Name = name;
            this.HealthPoint = HP;
        }

        /*public GameRole(string name, double BD , double HP, double CL)
        {
            this.Name = name;
            this.BaseDamage = BD;
            this.HealthPoint = HP;
            this.CriticalStrike = CL;
        }*/

        /// <summary>
        /// 角色名字 
        /// </summary>
        public string Name { get => name; set => name = value; }

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
        /// 阵容 比如 法师 盗贼 战士
        /// </summary>
        public string Group { get => group; set => group = value; }
    }
}
