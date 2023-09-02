namespace MyGame
{
    using System;
    using System.Drawing;
    using System.Drawing.Drawing2D;
    using System.Windows.Forms;
    using System.Threading;
    using System.Collections.Generic;

    public partial class Form2 : Form
    {
        private Label[] labelListLeft = new Label[16];
        private Label[] labelListRight = new Label[16];

        public Form2()
        {
            this.InitializeComponent();
            StartPointLeftX = panel3.Location.X;
            StartPointRightX = panel4.Location.X;
            TimeDifference = 0;
            Game.GameIsOver = false;
            Game.IsShowCrit = false;
            Game.IsShowDodge = false;
            AddInList();
        }

        /// <summary>
        /// 左 攻击波的开始位置
        /// </summary>
        public int StartPointLeftX { get; set; }

        /// <summary>
        /// 右 攻击波的开始位置
        /// </summary>
        public int StartPointRightX { get; set; }

        /// <summary>
        /// 左  显示角色信息的各label控件的集合
        /// </summary>
        public Label[] LabelListLeft { get => labelListLeft; set => labelListLeft = value; }

        /// <summary>
        /// 左  显示角色信息的各label控件的集合
        /// </summary>
        public Label[] LabelListRight { get => labelListRight; set => labelListRight = value; }

        /// <summary>
        /// 时间差
        /// </summary>
        public int TimeDifference { get; set; }

        /// <summary>
        /// Form2 加载时 显示双方信息 并开始抽取先手
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        public void Form2_Load(object sender, EventArgs e)
        {
            HideControl();
            ShowRole(Game.LPitchUpRole, Game.RPitchUpRole);
            // 将实时PH 赋值
            label3.Text = label10.Text;
            label4.Text = label26.Text;
            // 开始随机抽取本局游戏的先手
            timer3.Start();
        }

        /// <summary>
        /// 将选中的角色的信息加载到对战窗口中
        /// </summary>
        private void ShowRole(GameRole roleL, GameRole roleR)
        {
            string path = "..//..//image//";
            string pathLeft = path + roleL.Name + ".jpg";
            pictureBox1.BackgroundImage = new Bitmap(@pathLeft);
            pictureBox1.BackgroundImageLayout = ImageLayout.Zoom;
            string pathRight = path + roleR.Name + ".jpg";
            pictureBox2.BackgroundImage = new Bitmap(@pathRight);
            pictureBox2.BackgroundImageLayout = ImageLayout.Zoom;
            groupBox1.Text = roleL.Name;                            // 显示角色姓名
            groupBox2.Text = roleR.Name;
            if (!(Game.LPitchUpWeapon is null))
            {
                Game.AddWeaponProp(roleL, Game.LPitchUpWeapon);         // 将武器的属性 添加到角色
            }
            if (!(Game.RPitchUpWeapon is null))
            {
                Game.AddWeaponProp(roleR, Game.RPitchUpWeapon);
            }
            Game.StrTOList(roleL, Game.LPitchUpWeapon);             // 将添加完武器属性的角色属性以字符串列表存储
            ShowLabelData(LabelListLeft);                           // 将信息列表相应的赋值给窗口上各label值
            Game.StrTOList(roleR, Game.RPitchUpWeapon);
            ShowLabelData(LabelListRight);
        }

        /// <summary>
        /// 隐藏一些开局不显示的控件
        /// </summary>
        private void HideControl()
        {
            label50.Hide();
            label44.Hide();
            label45.Hide();
            label73.Hide();
            label74.Hide();
            label48.Hide();
            label49.Hide();
            pictureBox3.Location = new Point(311, 131);
            pictureBox3.Hide();
            panel8.Hide();
        }

        /// <summary>
        /// 显示信息的多个label控件添加至 label集合中
        /// </summary>
        private void AddInList()
        {
            LabelListLeft[0] = label7;
            LabelListLeft[1] = label8;
            LabelListLeft[2] = label9;
            LabelListLeft[3] = label10;
            LabelListLeft[4] = label11;
            LabelListLeft[5] = label12;
            LabelListLeft[6] = label13;
            LabelListLeft[7] = label14;
            LabelListLeft[8] = label15;
            LabelListLeft[9] = label16;
            LabelListLeft[10] = label17;
            LabelListLeft[11] = label18;
            LabelListLeft[12] = label19;
            LabelListLeft[13] = label20;
            LabelListLeft[14] = label21;
            LabelListLeft[15] = label22;
            LabelListRight[0] = label23;
            LabelListRight[1] = label24;
            LabelListRight[2] = label25;
            LabelListRight[3] = label26;
            LabelListRight[4] = label27;
            LabelListRight[5] = label28;
            LabelListRight[6] = label29;
            LabelListRight[7] = label30;
            LabelListRight[8] = label31;
            LabelListRight[9] = label32;
            LabelListRight[10] = label33;
            LabelListRight[11] = label34;
            LabelListRight[12] = label35;
            LabelListRight[13] = label36;
            LabelListRight[14] = label37;
            LabelListRight[15] = label38;
        }

        /// <summary>
        /// 将信息对号入座到各label控件 
        /// </summary>
        private void ShowLabelData(Label[] labels)
        {
            for (int i = 0; i < Game.RoleMessList.Length; i++)
            {
                labels[i].Text = Game.RoleMessList[i];
            }
        }

        /// <summary>
        /// 画出攻击波 左
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Panel3_Paint(object sender, PaintEventArgs e)
        {
            // 创建一块画布
            Graphics graphics = e.Graphics;
            // 创建渐变画刷 画出攻击波 左
            Rectangle rectangleLeft = new Rectangle(80, 6, 200, 100);
            LinearGradientBrush linearGradientBrush = new LinearGradientBrush(rectangleLeft,
                Color.CadetBlue, Color.Blue, LinearGradientMode.Horizontal);
            graphics.FillEllipse(linearGradientBrush, rectangleLeft);
        }

        /// <summary>
        /// 画出攻击波 右
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Panel4_Paint(object sender, PaintEventArgs e)
        {
            // 创建一块画布
            Graphics graphics = e.Graphics;
            // 创建渐变画刷 画出攻击波 右
            Rectangle rectangleRight = new Rectangle(0, 6, 200, 100);
            LinearGradientBrush linearGradientBrush1 = new LinearGradientBrush(rectangleRight,
                Color.Red, Color.GreenYellow, LinearGradientMode.Horizontal);
            graphics.FillEllipse(linearGradientBrush1, rectangleRight);
        }

        /// <summary>
        /// 受到攻击时  角色的抖动
        /// </summary>
        /// <param name="pictureBox"></param>
        private void PictureShake(PictureBox pictureBox)
        {
            int x = pictureBox.Left;
            int y = pictureBox.Top;
            for (int i = 0; i < 3; i++)
            {
                pictureBox.Location = new Point(x - 3, y);
                Thread.Sleep(10);
                pictureBox.Location = new Point(x - 3, y - 3);
                Thread.Sleep(10);
                pictureBox.Location = new Point(x, y - 3);
                Thread.Sleep(10);
                pictureBox.Location = new Point(x + 3, y - 3);
                Thread.Sleep(10);
                pictureBox.Location = new Point(x + 3, y);
                Thread.Sleep(10);
                pictureBox.Location = new Point(x + 3, y + 3);
                Thread.Sleep(10);
                pictureBox.Location = new Point(x, y + 3);
                Thread.Sleep(10);
                pictureBox.Location = new Point(x - 3, y + 3);
                Thread.Sleep(10);
                pictureBox.Location = new Point(x, y);
                Thread.Sleep(10);
            }
        }

        /// <summary>
        /// 蓝方的攻击波移动
        /// 并造成伤害
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Timer1_Tick(object sender, EventArgs e)
        {
            if (panel3.Location.X < 650)
            {
                panel3.Location = new Point(panel3.Location.X + 23, panel3.Location.Y);
            }
            else
            {
                timer1.Stop();
                PictureShake(pictureBox2);
                panel3.Location = new Point(StartPointLeftX, panel3.Location.Y);
                UpdateHP(label3, label73, label4, label74, label44, label48, Game.LPitchUpRole, Game.RPitchUpRole);
                timer5.Start();
            }
        }

        /// <summary>
        /// 红方的攻击波的移动 并赵成伤害
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Timer2_Tick(object sender, EventArgs e)
        {
            if (panel4.Location.X > -145)
            {
                panel4.Location = new Point(panel4.Location.X - 23, panel4.Location.Y);
            }
            else
            {
                timer2.Stop();
                PictureShake(pictureBox1);
                panel4.Location = new Point(StartPointRightX, panel4.Location.Y);
                UpdateHP(label4, label74, label3, label73, label45, label49, Game.RPitchUpRole, Game.LPitchUpRole);
                timer5.Start();
            }
        }

        /// <summary>
        /// 随机选出 红蓝 先手方
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Timer3_Tick(object sender, EventArgs e)
        {
            if (TimeDifference < 33)
            {
                TimeDifference++;
                Random random = new Random();
                int n = random.Next(0, 100);
                if (n <= 50)
                {
                    label40.Text = "红方";
                }
                else
                {
                    label40.Text = "蓝方";
                }
            }
            else
            {
                timer3.Stop();
                label46.Text = label40.Text;
                panel8.Show();
                TimeDifference = 0;
                timer4.Start();
            }
        }

        /// <summary>
        /// 展示 先手方是谁
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Timer4_Tick(object sender, EventArgs e)
        {
            if (TimeDifference < 17)
            {
                TimeDifference++;
            }
            else
            {
                timer4.Stop();
                panel8.Hide();
                TimeDifference = 0;
                if (label40.Text.ToString() == "红方")
                {
                    Game.AttackPower = false;
                }

                if (label40.Text.ToString() == "蓝方")
                {
                    Game.AttackPower = true;
                }
                timer6.Start();
                timer7.Start();
            }
        }

        /// <summary>
        /// 血量变化值 暴击 闪躲 显示一段时间后 再次隐藏
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Timer5_Tick(object sender, EventArgs e)
        {
            if (TimeDifference < 13)
            {
                TimeDifference++;
            }
            else
            {
                timer5.Stop();
                label73.Hide();
                label74.Hide();
                label44.Hide();
                label45.Hide();
                label48.Hide();
                label49.Hide();
                TimeDifference = 0;
            }
        }

        /// <summary>
        /// 回合开始 直到有角色阵亡
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Timer6_Tick(object sender, EventArgs e)
        {
            // 第几回合        
            if (Game.GameIsOver)
            {
                timer6.Stop();
                DialogResult result = MessageBox.Show("游戏结束了！", "再见", MessageBoxButtons.OK);
                if (result == DialogResult.OK)
                {
                    this.Close();
                }
            }
            else
            {
                label43.Text = Game.RoundNum++.ToString();
                if (Game.AttackPower)
                {
                    timer1.Start();
                    Game.AttackPower = false;
                }

                else
                {
                    timer2.Start();
                    Game.AttackPower = true;
                }
            }
        }

        /// <summary>
        /// 游戏开始前 倒计时器
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Timer7_Tick(object sender, EventArgs e)
        {
            label50.Show();
            label50.Text = (int.Parse(label50.Text.ToString()) - 1).ToString();
            if (int.Parse(label50.Text.ToString()) <= 0)
            {
                timer7.Stop();
                label50.Hide();
            }
        }

        /// <summary>
        /// 其中一角色阵亡后的操作！
        /// </summary>
        private void GameOver(Label att, Label vic)
        {
            if (double.Parse(att.Text) < 0)
            {
                att.Parent.BackColor = Color.DimGray;
                pictureBox3.Show();
                pictureBox3.Location = new Point(441, 131);
                Game.GameIsOver = true;
            }

            if (double.Parse(vic.Text) < 0)
            {
                panel2.BackColor = Color.DimGray;
                pictureBox3.Show();
                pictureBox3.Location = new Point(171, 131);
                Game.GameIsOver = true;
            }
        }

        /// <summary>
        /// 攻击一次后 界面的更新
        /// 若暴击或闪躲则显示
        /// 并将显示标志符重置
        /// </summary>
        /// <param name="aHP">攻击者实时HP值的Label</param>
        /// <param name="aChangeValue">攻击者HP改变值的Label</param>
        /// <param name="vHP">受害者实时HP值的Label</param>
        /// <param name="vChangeValue">受害者HP改变值的Label</param>
        /// <param name="Crit">暴击两个字的Label</param>
        /// <param name="Dodge">闪躲两个字的Label</param>
        /// <param name="attackRole">攻击者</param>
        /// <param name="victimRole">受害者</param>
        private void UpdateHP(
            Label aHP, Label aChangeValue, Label vHP, Label vChangeValue, Label Crit, 
            Label Dodge, GameRole attackRole, GameRole victimRole)
        {
            GameOver(aHP, vHP);
            double attackHP;
            double victimHP;
            double attackSub;
            double victimSub;
            (attackHP, victimHP, victimSub, attackSub) = Game.AnAttack(attackRole, victimRole);
            aHP.Text = attackHP.ToString();
            vHP.Text = victimHP.ToString();
            aChangeValue.Text = attackSub.ToString();
            vChangeValue.Text = victimSub.ToString();
            aChangeValue.Show();
            vChangeValue.Show();
            if (Game.IsShowCrit)
            {
                Crit.Show();
            }

            if (Game.IsShowDodge)
            {
                Dodge.Show();
            }

            Game.IsShowDodge = false;
            Game.IsShowCrit = false;
            GameOver(aHP, vHP);
        }
    }
}
