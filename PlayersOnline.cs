using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Diagnostics;
namespace launcher
{
    public partial class PlayersOnline : Form
    {
        blizzButton.blizzButton btnNext = new blizzButton.blizzButton(), btnBack = new blizzButton.blizzButton();
        Character[] players;
        int _CURRENT_PAGE = 1;

        public PlayersOnline()
        {
            InitializeComponent();
            this.SetStyle(ControlStyles.DoubleBuffer, true);
            this.SetStyle(ControlStyles.AllPaintingInWmPaint, true);
            this.SetStyle(ControlStyles.UserPaint, true);
            this.SetStyle(ControlStyles.Opaque, false);
            this.SetStyle(ControlStyles.OptimizedDoubleBuffer, true);
            this.SetStyle(ControlStyles.ResizeRedraw, true);
        }
        protected override void WndProc(ref Message m)
        {
            switch (m.Msg)
            {
                case 0x84:
                    base.WndProc(ref m);
                    if ((int)m.Result == 0x1)
                        m.Result = (IntPtr)0x2;
                    return;
            }

            base.WndProc(ref m);
        }
        private void Search_Load(object sender, EventArgs e)
        {
            LoadButtons();
            DB.GetAllOnlineCharactersData(out players);
            DB.ShowOnlineCharacters(_CURRENT_PAGE, players, lblName, lblLevel, picSide, picClass, this);

        }
        void LoadButtons()
        {
            
            btnNext.Parent = this;
            btnNext.Size = new Size(118, 22);
            btnNext.Location = new Point(165, 375);
            btnNext.Text = "Next";
            btnNext.Name = "btnNext";
            btnNext.SetValues(Properties.Resources.play_no_hover1, Properties.Resources.play_take, Properties.Resources.play_hover, Properties.Resources.play_no_active, 11);
            btnNext.Click += btnNext_Click;
            btnNext.MouseUp += btnNext_MouseUp;
            if (_CURRENT_PAGE < DB.GetOnlinePlayers() / 12 + 1) btnBack.Enabled = true;
            else btnNext.Enabled = false;


            btnBack.Parent = this;
            btnBack.Size = new Size(118, 22);
            btnBack.Location = new Point(20, 375);
            btnBack.Enabled = false;
            btnBack.Text = "Back";
            btnBack.Name = "btnBack";
            btnBack.SetValues(Properties.Resources.play_no_hover1, Properties.Resources.play_take, Properties.Resources.play_hover, Properties.Resources.play_no_active, 11);
            btnBack.Click += btnBack_Click;
            btnBack.MouseUp += btnBack_MouseUp;
        }

        private void btnBack_MouseUp(object sender, MouseEventArgs e)
        {
            if (_CURRENT_PAGE > 1) btnNext.Enabled = true;
            else btnBack.Enabled = false;
        }

        private void btnBack_Click(object sender, EventArgs e)
        {
            if (_CURRENT_PAGE > 1)
            {
                DB.ShowOnlineCharacters(--_CURRENT_PAGE, players, lblName, lblLevel, picSide, picClass, this);
                btnNext.Enabled = true;
            }
            else btnBack.Enabled = false;
        }

        private void lblExit_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        private void btnNext_Click(object sender, EventArgs e)
        {
            Debug.WriteLine("Page: " + (_CURRENT_PAGE).ToString());
            Debug.WriteLine("Players: " + DB.GetOnlinePlayers().ToString());
            Debug.WriteLine(_CURRENT_PAGE < DB.GetOnlinePlayers() / 12 + 1);


            if (_CURRENT_PAGE < DB.GetOnlinePlayers()/12+1)
            {
                DB.ShowOnlineCharacters(++_CURRENT_PAGE, players, lblName, lblLevel, picSide, picClass, this);
                btnBack.Enabled = true;
            }
            else btnNext.Enabled = false;
        }

        private void btnNext_MouseUp(object sender, MouseEventArgs e)
        {
            if (_CURRENT_PAGE < DB.GetOnlinePlayers() / 12 + 1) btnBack.Enabled = true;
            else btnNext.Enabled = false;
        }

        
    }
}
