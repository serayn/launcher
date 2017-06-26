using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Net.Sockets;
using System.Windows.Forms;
using System.Diagnostics;
using System.Net;
namespace launcher
{
    class DB
    {
        public static System.Drawing.Color bColor = System.Drawing.Color.FromArgb(((int)(((byte)(187)))), ((int)(((byte)(187)))), ((int)(((byte)(187)))));
        public static string launcherScriptAddress = @"http://" + SIMPLE_CONFIG.IP + @"/launcher/data.php";
        public static HtmlDocument launcherPage;
        public static WebClient pgDown = new WebClient();
        public static string GetRealmlist()
        {
            return launcherPage.GetElementById("serverRealmlist").InnerText;
        }
        public static string GetRealmName()
        {
            string data = launcherPage.GetElementById("serverName").InnerText;

            byte[] buffer1 = Encoding.Default.GetBytes(data);
            byte[] buffer2 = Encoding.Convert(Encoding.UTF8, Encoding.Default, buffer1, 0, buffer1.Length);
            string strBuffer = Encoding.Default.GetString(buffer2, 0, buffer2.Length);
            data = strBuffer;

            Properties.Settings.Default.server = data;
            Properties.Settings.Default.Save();
            return data;
        }
        public static int GetOnlinePlayers()
        {
            return Convert.ToInt32(launcherPage.GetElementById("playersOnlineCount").InnerText);
        }
        public static bool IsServerOnline()
        {
            try
            {
                string data = pgDown.DownloadString(launcherScriptAddress);
                if (data.Contains("mysqli_num_rows")) // error message: mysqli_query() expects parameter X to be mysqli...
                    return false;
                return true;
            }
            catch
            {
                return false;
            }
        }
        public static string GetNews()
        {
            string data = launcherPage.GetElementById("news").InnerText;

            byte[] buffer1 = Encoding.Default.GetBytes(data);
            byte[] buffer2 = Encoding.Convert(Encoding.UTF8, Encoding.Default, buffer1, 0, buffer1.Length);
            string strBuffer = Encoding.Default.GetString(buffer2, 0, buffer2.Length);
            data = strBuffer;

            Properties.Settings.Default.news = data;
            Properties.Settings.Default.Save();
            return data;
        }
        public static string GetChangelog()
        {
            string data = launcherPage.GetElementById("changelog").InnerText;

            byte[] buffer1 = Encoding.Default.GetBytes(data);
            byte[] buffer2 = Encoding.Convert(Encoding.UTF8, Encoding.Default, buffer1, 0, buffer1.Length);
            string strBuffer = Encoding.Default.GetString(buffer2, 0, buffer2.Length);
            data = strBuffer;

            Properties.Settings.Default.changelog = data;
            Properties.Settings.Default.Save();
            return data;
        }
        public static void GetLinksOffline(out string _register, out string _forum, out string _account, out string _changelog, out string _news)
        {
            _register = Properties.Settings.Default.register;
            _forum = Properties.Settings.Default.forum;
            _account = Properties.Settings.Default.account;
            _changelog = Properties.Settings.Default.changelog_link;
            _news = Properties.Settings.Default.news_link;
        }
        public static void GetLinksOnline(out string _register, out string _forum, out string _account, out string _changelog, out string _news)
        {
            _register = launcherPage.GetElementById("registerLink").InnerText;
            _forum = launcherPage.GetElementById("forumLink").InnerText;
            _changelog = launcherPage.GetElementById("changelogLink").InnerText;
            _account = launcherPage.GetElementById("accountLink").InnerText;
            _news = launcherPage.GetElementById("newsLink").InnerText;

            #region SavingLinksLocally
            Properties.Settings.Default.register = _register;
            Properties.Settings.Default.forum = _forum;
            Properties.Settings.Default.account = _account;
            Properties.Settings.Default.changelog_link = _changelog;
            Properties.Settings.Default.news_link = _news;
            Properties.Settings.Default.Save();
            #endregion

        }
        public static void GetPatch(int nr,out int _patch_version, out string _patch_name,out string _patch_link)
        {
            _patch_link = launcherPage.GetElementById("patchLink" + nr.ToString()).InnerText;
            _patch_name = launcherPage.GetElementById("patchName" + nr.ToString()).InnerText;
            _patch_version = Convert.ToInt32(launcherPage.GetElementById("patchVersion"+nr.ToString()).InnerText);
        }
        public static int GetNewPatchId()
        {
            int patch_v;
            string patch_name, patch_l;
            GetPatch(1, out patch_v, out patch_name, out patch_l);
            if (patch_v != Properties.Settings.Default.patch_version_1)
                return 1;
            GetPatch(2, out patch_v, out patch_name, out patch_l);
            if (patch_v != Properties.Settings.Default.patch_version_2)
                return 2;
            GetPatch(3, out patch_v, out patch_name, out patch_l);
            if (patch_v != Properties.Settings.Default.patch_version_3)
                return 3;
            GetPatch(4, out patch_v, out patch_name, out patch_l);
            if (patch_v != Properties.Settings.Default.patch_version_4)
                return 4;
            GetPatch(5, out patch_v, out patch_name, out patch_l);
            if (patch_v != Properties.Settings.Default.patch_version_5)
                return 5;
            return 0;
        }
        public static bool RequiresUpdate()
        {
            int patch_v;
            string patch_name, patch_l;
            GetPatch(1,out patch_v,out patch_name,out patch_l);
            if (patch_v != Properties.Settings.Default.patch_version_1)
                return true;
            GetPatch(2, out patch_v, out patch_name, out patch_l);
            if (patch_v != Properties.Settings.Default.patch_version_2)
                return true;
            GetPatch(3, out patch_v, out patch_name, out patch_l);
            if (patch_v != Properties.Settings.Default.patch_version_3)
                return true;
            GetPatch(4, out patch_v, out patch_name, out patch_l);
            if (patch_v != Properties.Settings.Default.patch_version_4)
                return true;
            GetPatch(5, out patch_v, out patch_name, out patch_l);
            if (patch_v != Properties.Settings.Default.patch_version_5)
                return true;
            return false;
        }
        public static void GetAllOnlineCharactersData(out Character[] chr)
        {
            int i = 0;
            chr = new Character[GetOnlinePlayers()];


            string[] players = launcherPage.GetElementById("playersOnlineData").InnerText.Split('\n');

            foreach (string player in players)
            {
                string[] playerData = player.Split(',');
                chr[i] = new Character(playerData[0], Convert.ToInt32(playerData[3]), Convert.ToInt32(playerData[1]), Convert.ToInt32(playerData[2]), 1);
                i++;
            }
        }
        public static void ShowOnlineCharacters(int page, Character[] chr,Label lblName, Label lblLevel, PictureBox picSide, PictureBox picClass, Control _this)
        {

            // Removes all characters from the last page
            for (int i = _this.Controls.Count - 1; i >= 0; i--)
                if (_this.Controls[i].Name != "lblTitle" && _this.Controls[i].Name != "btnNext" && _this.Controls[i].Name != "btnBack" && _this.Controls[i].Name != "lblExit")
                    _this.Controls.Remove(_this.Controls[i]);

            //Adds characters to the current page
            int y = 0, counter = 0;
            foreach (Character p in chr)
            {
                if (counter >= ((page - 1) * 12) && counter < (page * 12))
                {

                    Label lblName_t = lblName.Clone();

                    lblName_t.Visible = true;
                    lblName_t.Text = p._NAME;
                    lblName_t.Location = new System.Drawing.Point(lblName.Location.X, lblName.Location.Y + 27 * y);
                    _this.Controls.Add(lblName_t);
                    lblName_t.Name = "lblName_t";

                    Label lblLevel_t = lblLevel.Clone();
                    lblLevel_t = lblLevel.Clone();

                    lblLevel_t.Visible = true;
                    lblLevel_t.Text = p._NAME;
                    lblLevel_t.Location = new System.Drawing.Point(lblLevel.Location.X, lblLevel.Location.Y + 27 * y);
                    _this.Controls.Add(lblLevel_t);
                    lblLevel_t.Name = "lblLevel_t";

                    PictureBox picSide_t = picSide.Clone();
                    picSide_t.Visible = true; picSide_t.Location = new System.Drawing.Point(picSide.Location.X, picSide.Location.Y + 27 * y);

                    _this.Controls.Add(picSide_t);
                    picSide_t.Name = "picSide_t";


                    PictureBox picClass_t = picClass.Clone();
                    picClass_t.Visible = true; picClass_t.Location = new System.Drawing.Point(picClass.Location.X, picClass.Location.Y + 27 * y);

                    _this.Controls.Add(picClass_t);
                    picClass_t.Name = "picClass_t";


                    lblName_t.Text = p._NAME;
                    lblLevel_t.Text = p._LEVEL.ToString();
                    if (p._RACE == 1 || p._RACE == 3 || p._RACE == 4 || p._RACE == 7 || p._RACE == 11)
                        picSide_t.Image = Properties.Resources.alliance;
                    else picSide_t.Image = Properties.Resources.horde;
                    switch (p._CLASS)
                    {
                        case 1:
                            picClass_t.Image = Properties.Resources.warrior;
                            break;
                        case 2:
                            picClass_t.Image = Properties.Resources.paladin;
                            break;
                        case 3:
                            picClass_t.Image = Properties.Resources.hunter;
                            break;
                        case 4:
                            picClass_t.Image = Properties.Resources.rogue;
                            break;
                        case 5:
                            picClass_t.Image = Properties.Resources.priest;
                            break;
                        case 6:
                            picClass_t.Image = Properties.Resources.dk;
                            break;
                        case 7:
                            picClass_t.Image = Properties.Resources.shaman;
                            break;
                        case 8:
                            picClass_t.Image = Properties.Resources.mage;
                            break;
                        case 9:
                            picClass_t.Image = Properties.Resources._lock;
                            break;
                        case 11:
                            picClass_t.Image = Properties.Resources.druid;
                            break;
                    }

                    y++;
                }
                counter++;
            }
            
        }

    }
    class Character // WORK IN PROGRESS
    {
        public string _NAME;
        public int _LEVEL, _RACE, _CLASS, _ONLINE;
        public Character(string _name, int _level, int _race, int _class, int _online)
        {
            _NAME = char.ToUpper(_name[0]) + _name.Substring(1);
            _LEVEL = _level;
            _RACE = _race;
            _CLASS = _class;
            _ONLINE = _online;
        }
        public void Show(int Nr, Label lblName,Label lblLevel, PictureBox picSide, PictureBox picClass )
        {
            
        
        }
        public void Reset(Label lblName, PictureBox picStatus)
        {
            lblName.Visible = false;
            picStatus.Visible = false;
        }
    }
    public static class ControlExtensions
    {
        public static T Clone<T>(this T controlToClone)
            where T : Control
        {
            System.Reflection.PropertyInfo[] controlProperties = typeof(T).GetProperties(System.Reflection.BindingFlags.Public | System.Reflection.BindingFlags.Instance);

            T instance = Activator.CreateInstance<T>();

            foreach (System.Reflection.PropertyInfo propInfo in controlProperties)
            {
                if (propInfo.CanWrite)
                {
                    if (propInfo.Name != "WindowTarget")
                        propInfo.SetValue(instance, propInfo.GetValue(controlToClone, null), null);
                }
            }

            return instance;
        }
    }
}
