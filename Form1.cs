namespace MyGame
{
    using System;
    using System.Collections.Generic;
    using System.Drawing;
    using System.Windows.Forms;

    public partial class Form1 : Form
    {
        private PictureBox[] weaponPitureBox = new PictureBox[30];
        private Control.ControlCollection controlsRoleL;
        private Control.ControlCollection controlsRoleR;
        private Dictionary<Panel, GameRole> dictPanelRole = new Dictionary<Panel, GameRole>();
        Game game = new Game();

        public Form1()
        {
            this.InitializeComponent();
            game.Init();
        }

        /// <summary>
        /// 存放武器图的图片控件 集合
        /// </summary>
        public PictureBox[] WeaponPitureBox { get => weaponPitureBox; set => weaponPitureBox = value; }

        /// <summary>
        /// 左 获取 存放角色图片控件的 GroupBox集合
        /// </summary>
        public Control.ControlCollection ControlsRoleL { get => controlsRoleL; set => controlsRoleL = value; }

        /// <summary>
        /// 左 获取 存放角色图片控件的 GroupBox集合
        /// </summary>
        public Control.ControlCollection ControlsRoleR { get => controlsRoleR; set => controlsRoleR = value; }

        /// <summary>
        /// 存放Panel 容器与其对应 选中英雄的字典
        /// 键 panel容器
        /// 值 该容器选中的角色对象
        /// </summary>
        internal Dictionary<Panel, GameRole> DictPanelRole { get => dictPanelRole; set => dictPanelRole = value; }

        /// <summary>
        /// 窗体的加载
        /// 获取两边Panel容器中的所有控件 并上背景图
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Form1_Load(object sender, EventArgs e)
        {
            DictPanelRole.Add(panel1, Game.LPitchUpRole);
            DictPanelRole.Add(panel2, Game.RPitchUpRole);
            ControlsRoleL = panel1.Controls;
            LoadPicture(ControlsRoleL);
            ControlsRoleR = panel2.Controls;
            LoadPicture(ControlsRoleR);
        }

        /// <summary>
        /// 集合中所有的 GroupBox 控件的 text 从所有角色的字典中找出并赋值
        /// 获取GroupBox 控件下的Picture 控件 并根据名字 找到对应的图片设为其背景图
        /// </summary>
        /// <param name="controls"></param>
        private void LoadPicture(Control.ControlCollection controls)
        {
            int i = 1;
            foreach (var item in Game.DictRole.Keys)
            {
                controls[i].Text = item;
                string path = @"..//..//image//";
                path = path + item + ".jpg";
                Control.ControlCollection picture = controls[i].Controls;
                ((PictureBox)picture[0]).BackgroundImage = new Bitmap(path);
                ((PictureBox)picture[0]).BackgroundImageLayout = ImageLayout.Zoom;
                i++;
            }
        }

        /// <summary>
        /// 返回 picture 控件所在容器 同级的所有控件集合
        /// </summary>
        /// <param name="picture"></param>
        /// <returns></returns>
        private Control.ControlCollection AllControls(PictureBox picture)
        {
            Control control = picture.Parent;
            Control parentControl = control.Parent;
            Control.ControlCollection result = parentControl.Controls;
            return result;
        }

        /// <summary>
        /// 左 鼠标进入每个图片控件时，图片控件所在的容器的背景色变为黄色
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void PictureBox_MouseEnterL(object sender, EventArgs e)
        {
            if (Game.LPitchUpRole is null)
            {
                PictureBox pictureBox = (PictureBox)sender;
                Control control = pictureBox.Parent;
                control.BackColor = Color.Gold;
            }
        }

        /// <summary>
        /// 左 鼠标离开每个图片控件时，图片控件所在的容器的背景色恢复为透明
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void PictureBox_MouseLeaveL(object sender, EventArgs e)
        {
            if (Game.LPitchUpRole is null)
            {
                PictureBox pictureBox = (PictureBox)sender;
                Control control = pictureBox.Parent;
                control.BackColor = Color.Transparent;
            }
        }

        /// <summary>
        /// 右 鼠标进入每个图片控件时，图片控件所在的容器的背景色变为黄色
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void PictureBox_MouseEnterR(object sender, EventArgs e)
        {
            if (Game.RPitchUpRole is null)
            {
                PictureBox pictureBox = (PictureBox)sender;
                Control control = pictureBox.Parent;
                control.BackColor = Color.Gold;
            }
        }

        /// <summary>
        /// 右 鼠标进入每个图片控件时，图片控件所在的容器的背景色恢复为透明
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void PictureBox_MouseLeaveR(object sender, EventArgs e)
        {
            if (Game.RPitchUpRole is null)
            {
                PictureBox pictureBox = (PictureBox)sender;
                Control control = pictureBox.Parent;
                control.BackColor = Color.Transparent;
            }
        }

        /// <summary>
        /// 鼠标单击，表示选中某个游戏角色，将其所在容器背景改为黄色，并禁用Enter和Leave事件
        /// 将选中的游戏角色的名字 存储在左边选定角色的变量中
        /// 选定的角色会给出相应的武器
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void LeftPictureBox_Click(object sender, EventArgs e)
        {
            PictureBox picture = (PictureBox)sender;
            // allControls 为sender所在控件的父容器的所有同级容器集合
            Control.ControlCollection allControls = AllControls(picture);
            Control parentControl = picture.Parent;
            // 根据字典找到 存储当前英雄panel选中角色的对象
            // GameRole pitchUpRole = DictPanelRole[(Panel)parentControl.Parent];
            for (int i = 1; i < allControls.Count; i++)
            {
                allControls[i].BackColor = Color.Transparent;
            }

            parentControl.BackColor = Color.LightPink;
            Game.LPitchUpRole = Game.DictRole[parentControl.Text.ToString()];
            // 选定英雄后 给相应的武器前  先清空一下 武器栏
            allControls[0].Controls.Clear();
            AddWeapon((TableLayoutPanel)allControls[0], Game.LPitchUpRole);
        }

        /// <summary>
        /// 右边的 鼠标单击，表示选中某个游戏角色，将其所在容器背景改为黄色，并禁用Enter和Leave事件
        /// 将选中的游戏角色的名字 存储在左边选定角色的变量中
        /// 选定的角色会给出相应的武器
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void RightPictureBox_Click(object sender, EventArgs e)
        {
            PictureBox picture = (PictureBox)sender;
            // allControls 为sender所在控件的父容器的所有同级容器集合
            Control.ControlCollection allControls = AllControls(picture);
            Control parentControl = picture.Parent;
            for (int i = 1; i < allControls.Count; i++)
            {
                allControls[i].BackColor = Color.Transparent;
            }

            parentControl.BackColor = Color.LightPink;
            Game.RPitchUpRole = Game.DictRole[parentControl.Text.ToString()];
            // 选定英雄后 给相应的武器前  先清空一下 武器栏
            allControls[0].Controls.Clear();
            AddWeapon((TableLayoutPanel)allControls[0], Game.RPitchUpRole);

        }

        private void GivePitchUpRole(Panel panel, string name)
        {
            switch (panel.AccessibleName)
            {
                case "first":
                    Game.LPitchUpRole = Game.DictRole[name];
                    // AddWeapon((TableLayoutPanel)panel.Controls[0], Game.LPitchUpRole);
                    break;
                case "second":
                    Game.RPitchUpRole = Game.DictRole[name];
                    // AddWeapon((TableLayoutPanel)panel.Controls[0], Game.RPitchUpRole);
                    break;
                default:
                    Game.TPitchUpRole = Game.DictRole[name];
                    // AddWeapon((TableLayoutPanel)panel.Controls[0], Game.TPitchUpRole);
                    break;
            }
        }

        /// <summary>
        /// 悬停事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void PictureBox_MouseHover(object sender, EventArgs e)
        {
            PictureBox pictureBox = (PictureBox)sender;
            Control control = pictureBox;
            string showMessageStr = ShowMessage(pictureBox);
            toolTip1.SetToolTip(control, showMessageStr);
        }

        /// <summary>
        /// 给一个图片控件窗口 返回它所存放的 角色或武器的信息
        /// </summary>
        /// <param name="picture"></param>
        /// <returns></returns>
        public static String ShowMessage(PictureBox picture)
        {
            string result;
            Control control = picture.Parent;
            // 如果PictureBox 的 Text 并没有字符串 则表明它为武器，调用武器输出自身信息的方法
            if (control.Text.Length < 1)
            {
                result = Weapon.Output(Game.DictWeapon[picture.AccessibleName]);
            }
            else
            {
                result = Game.RoleHint(control.Text);
            }

            return result;
        }

        /// <summary>
        /// 点击开始游戏 双方都选定则弹出游戏窗口
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Button1_Click(object sender, EventArgs e)
        {
            if (Game.LPitchUpRole is null)
            {
                MessageBox.Show("请选择左边的英雄！", "提示", MessageBoxButtons.OK);
            }
            else if (Game.RPitchUpRole is null)
            {
                MessageBox.Show("请选择右边的英雄！", "提示", MessageBoxButtons.OK);
            }
            else
            {
                Form2 form2 = new Form2();
                form2.Show();
            }
        }

        /// <summary>
        /// 左 判断那边有选中的  给选中的英雄 显示对应的武器
        /// 并每个武器控件添加鼠标点击事件
        /// </summary>
        private void AddWeapon(TableLayoutPanel table, GameRole pitchUpRole)
        {
            // 判断是否有选中的 英雄
            if (!(pitchUpRole is null))
            {
                NewWeapon(pitchUpRole, table);
                for (int i = 0; i < table.Controls.Count; i++)
                {
                    WeaponPitureBox[i].MouseClick += WeaponPictureBox_Click;
                }
            }
        }

        /// <summary>
        /// 将选定的名字给这个函数 会显示这个名字应有的武器
        /// </summary>
        /// <param name="role"></param>
        private void NewWeapon(GameRole role, TableLayoutPanel tableLayoutPanel)
        {
            string[] sold = new string[] { "霜之哀伤", "灰烬使者", "埃辛诺斯双刃" };
            string[] robb = new string[] { "灰烬使者", "萨格拉斯权杖", "埃辛诺斯双刃", "雷霆之怒" };
            string[] ma = new string[] { "萨格拉斯权杖", "埃提耶什" };
            // 判断选中的英雄是 法师 战士 还是盗贼  给出对应的武器
            if (role.Group == "战士")
            {
                for (int i = 0; i < 3; i++)
                {
                    string path = "..//..//image//";
                    this.WeaponPitureBox[i] = new PictureBox();
                    path = path + sold[i] + ".png";
                    AddWeaponEvent(WeaponPitureBox[i], path);
                    WeaponPitureBox[i].AccessibleName = sold[i];
                    tableLayoutPanel.Controls.Add(WeaponPitureBox[i]);
                }
            }

            if (role.Group == "盗贼")
            {
                for (int i = 0; i < 4; i++)
                {
                    string path = "..//..//image//";
                    this.WeaponPitureBox[i] = new PictureBox();
                    path = path + robb[i] + ".png";
                    AddWeaponEvent(WeaponPitureBox[i], path);
                    WeaponPitureBox[i].AccessibleName = robb[i];
                    tableLayoutPanel.Controls.Add(WeaponPitureBox[i]);
                }
            }

            if (role.Group == "法师")
            {
                for (int i = 0; i < 2; i++)
                {
                    string path = "..//..//image//";
                    this.WeaponPitureBox[i] = new PictureBox();
                    path = path + ma[i] + ".png";
                    AddWeaponEvent(WeaponPitureBox[i], path);
                    WeaponPitureBox[i].AccessibleName = ma[i];
                    tableLayoutPanel.Controls.Add(WeaponPitureBox[i]);
                }
            }
        }

        /// <summary>
        /// 添加武器图片控件的一些操作
        /// </summary>
        /// <param name="box"></param>
        /// <param name="path"></param>
        private void AddWeaponEvent(PictureBox box, string path)
        {
            box.Size = new Size(50, 50);
            box.BackColor = Color.Transparent;
            box.BackgroundImage = new Bitmap(@path);
            box.BackgroundImageLayout = ImageLayout.Zoom;
            // 将悬停事件 添加到新创建的控件上
            box.MouseHover += PictureBox_MouseHover;
        }

        /// <summary>
        /// 左 武器控件的点击事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void WeaponPictureBox_Click(object sender, EventArgs e)
        {
            PictureBox pictureBox = (PictureBox)sender;
            var table = pictureBox.Parent;
            foreach (PictureBox box in table.Controls)
            {
                box.BackColor = Color.Transparent;
            }
            pictureBox.BackColor = Color.Gold;
            switch (table.Parent.AccessibleName)
            {
                case "first":
                    Game.LPitchUpWeapon = Game.DictWeapon[pictureBox.AccessibleName.ToString()];
                    break;
                case "second":
                    Game.RPitchUpWeapon = Game.DictWeapon[pictureBox.AccessibleName.ToString()];
                    break;
                default:
                    break;
            }
        }

        private void PeopleNumCutClick(object sender, EventArgs e)
        {
            var button = (Button)sender;
            button.Text = "点击切换至双人游戏";
            button1.Location = new Point(button1.Location.X + Game.Flag * 89, button1.Location.Y - Game.Flag * 342);
            button.Location = new Point(button.Location.X - Game.Flag * 122, button.Location.Y + Game.Flag * 2);
            Game.Flag *= -1;
        }
    }
}
