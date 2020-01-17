/*
* bank restore form 
* :InMySight:
* 
* by koland
* date 16/1/20
*/
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace UAC_Bank_Restore_Commands
{
    public partial class Form1 : Form
    {
        public delegate void KeyEventHandler(object sender, KeyEventArgs e);
        public Form1()
        {
            InitializeComponent();
            KeyboardHook hook = new KeyboardHook((int)KeyboardHook.Modifiers.None, Keys.F1, this);
            hook.Register(); // registering globally that A will call a method
        }
        private void Form1_Load(object sender, EventArgs e)
        {

        }
        protected override void WndProc(ref Message m)
        {
            if (m.Msg == 0x0312)//matched event
            {
                //XP
                String2Command("/bank setxp " + textBox_playerNo.Text + " 1 " + textBox_EnlistXP.Text + "/");      //enlisted xp
                String2Command("/bank setxp " + textBox_playerNo.Text + " 2 " + textBox_WOXP.Text + "/");          //CO xp
                String2Command("/bank setxp " + textBox_playerNo.Text + " 3 " + textBox_COXP.Text + "/");          //WO xp

                //Set Records
                String2Command("/bank setgames " + textBox_playerNo.Text + " " + textBox_GamesSaved.Text + "/");   //saved games
                String2Command("/bank setrevs " + textBox_playerNo.Text + " " + textBox_Revives.Text + "/");       //revives

                //Games won
                String2Command("/bank setwon " + textBox_playerNo.Text + " 1 " + textBox_Recruit.Text + "/");      //recruit
                String2Command("/bank setwon " + textBox_playerNo.Text + " 2 " + textBox_Normal.Text + "/");       //normal
                String2Command("/bank setwon " + textBox_playerNo.Text + " 3 " + textBox_Hard.Text + "/");         //hard
                String2Command("/bank setwon " + textBox_playerNo.Text + " 4 " + textBox_Insane.Text + "/");       //insane
                String2Command("/bank setwon " + textBox_playerNo.Text + " 5 " + textBox_Nightmare.Text + "/");    //nm
                String2Command("/bank setwon " + textBox_playerNo.Text + " 11 " + textBox_PMCStory.Text + "/");    //pmc story

                String2Command("/bank setwon " + textBox_playerNo.Text + " 7 " + textBox_Survival.Text + "/");     //surv
                String2Command("/bank setwon " + textBox_playerNo.Text + " 8 " + textBox_PMCSurvival.Text + "/");  //PMC surv
                String2Command("/bank setwon " + textBox_playerNo.Text + " 9 " + textBox_BossMode.Text + "/");     //BM

                //SI
                if (richTextBox_SIs.Text != "")
                {
                    richTextBox_SIs.Text=richTextBox_SIs.Text.Replace(" ", "");
                    PrintSIs(richTextBox_SIs.Text);
                }

                //Camo
                if (richTextBox_Camos.Text != "")
                {
                    richTextBox_Camos.Text=richTextBox_Camos.Text.Replace(" ", "");
                    PrintCamos(richTextBox_Camos.Text);
                }

                //Decal
                if (richTextBox_Decals.Text != "")
                {
                    richTextBox_Decals.Text=richTextBox_Decals.Text.Replace(" ", "");
                    PrintDecals(richTextBox_Decals.Text);
                }
            }
            base.WndProc(ref m);
        }

        void PrintSIs(string SIsText)
        {
            String [] Parsed = SIsText.Split(',');
            String[] Table = SIsTable();
            for (int i = 0; i < Parsed.Length; i++)
            {
                //scan for matched Sis
                for (int i2 = 1; i2 < Table.Length; i2++)
                {
                    if (Parsed[i].ToUpper() == Table[i2])
                    {
                        String2Command("/bank addsi " + textBox_playerNo.Text + " " + i2 + "/");
                    }
                }
            }
        }

        void PrintCamos(string CamosText)
        {
            String[] Parsed = CamosText.Split(',');
            String[] Table = CamoTable();
            for (int i = 0; i < Parsed.Length; i++)
            {
                //scan for matched camo
                for (int i2 = 1; i2 < Table.Length; i2++)
                {
                    if(Parsed[i].ToLower() == Table[i2].ToLower())
                    {
                        String2Command("/bank addcamo " + textBox_playerNo.Text + " " + i2 + "/");
                    }
                }
            }
        }   

        void PrintDecals(string DecalsText)
        {
            String[] Parsed = DecalsText.Split(',');
            String[] Table = DecalTable();
            for (int i = 0; i < Parsed.Length; i++)
            {
                //scan for matched camo
                for (int i2 = 1; i2 < Table.Length; i2++)
                {
                    if (Parsed[i].ToLower() == Table[i2].ToLower())
                    {
                        String2Command("/bank adddecal " + textBox_playerNo.Text + " " + (i2-1) + "/");   //decal has offset of 1 :(
                    }
                }
            }
        }
        String[] CamoTable()
        {
            String[] Table =new String[53];
            Table[1] = "Default";
            Table[2] = "ACUPAT";
            Table[3] = "CADPAT";
            Table[4] = "MARPAT";
            Table[5] = "Night";
            Table[6] = "Olive";
            Table[7] = "RedTiger";
            Table[8] = "SAS";
            Table[9] = "Woodland";
            Table[10] = "WoodlandTiger";
            Table[11] = "Chameleon";
            Table[12] = "Octo Camo";
            Table[13] = "Medic";
            Table[14] = "Desert";
            Table[15] = "NavyBlue";
            Table[16] = "ABU";
            Table[17] = "Snow";
            Table[18] = "RockAvalanche";
            Table[19] = "Gold";
            Table[20] = "Rain";
            Table[21] = "Cyber";
            Table[22] = "DesertStorm";
            Table[23] = "Frost";
            Table[24] = "BetaTester";
            Table[25] = "SnowRockAvalanche";
            Table[26] = "Specter";
            Table[27] = "BDU";
            Table[28] = "RedSteel";
            Table[29] = "Party";
            Table[30] = "Galactic";
            Table[31] = "Blood";
            Table[32] = "Lightning";
            Table[33] = "Galaxy";
            Table[34] = "DOOM";
            Table[35] = "Obsidian";
            Table[36] = "AUC";
            Table[37] = "Icy";
            Table[38] = "Pride";
            Table[39] = "Hellfire";
            Table[40] = "Laser";
            Table[41] = "Leopard";
            Table[42] = "DND";
            Table[43] = "Sparkle";
            Table[44] = "Emerald";
            Table[45] = "ZES";
            Table[46] = "BIO";
            Table[47] = "Holiday";
            Table[48] = "UrbanSnow";
            Table[49] = "RNJesus";
            Table[50] = "WhiteTiger";
            Table[51] = "Ghost";
            Table[52] = "SyL";
            return Table;
        }

        String[] SIsTable()
        {
            String[] Table = new String[70];
            Table[26] = "BB";
            Table[27] = "BG";
            Table[28] = "GS";
            Table[31] = "GR";
            Table[32] = "AW";
            Table[33] = "BO";
            Table[34] = "ER";
            Table[35] = "HT";
            Table[36] = "";
            Table[37] = "BR";
            Table[38] = "PM";
            Table[39] = "DF";
            Table[40] = "";
            Table[41] = "ST";
            Table[42] = "";
            Table[43] = "SC";
            Table[44] = "AB";
            Table[45] = "HE";
            Table[46] = "AT";
            Table[47] = "IS";
            Table[48] = "SF";
            Table[49] = "LO";
            Table[50] = "GM";
            Table[51] = "OV";
            Table[52] = "";
            Table[53] = "EE";
            Table[54] = "CS";
            Table[55] = "HA";
            Table[56] = "RM";
            Table[57] = "SU";
            Table[58] = "";
            Table[59] = "VA";
            Table[60] = "CC";
            Table[61] = "PH";
            Table[62] = "PS";
            Table[63] = "";
            Table[64] = "";
            Table[65] = "SB";
            Table[66] = "";
            Table[67] = "FT";
            Table[68] = "";
            Table[69] = "SW";
            return Table;
        }
        String[] DecalTable()
        {
            String[] Table = new String[48];
            Table[1] = "Default";
            Table[2] = "BearClaw";
            Table[3] = "BlueDiamond";
            Table[4] = "CavalrySabers";
            Table[5] = "Outlaw";
            Table[6] = "RockAvalanche";
            Table[7] = "RavenSword";
            Table[8] = "CombatMedic";
            Table[9] = "ZES";
            Table[10] = "Wolves";
            Table[11] = "USFlag";
            Table[12] = "AUC";
            Table[13] = "RussiaFlag";
            Table[14] = "SingaporeFlag";
            Table[15] = "ItalyFlag";
            Table[16] = "FinlandFlag";
            Table[17] = "CanadaFlag";
            Table[18] = "SouthKoreaFlag";
            Table[19] = "UKFlag";
            Table[20] = "GermanyFlag";
            Table[21] = "Woodland";
            Table[22] = "Bronze";
            Table[23] = "Silver";
            Table[24] = "Gold";
            Table[25] = "Platinum";
            Table[26] = "Diamond";
            Table[27] = "Master";
            Table[28] = "GrandMaster";
            Table[29] = "Galactic";
            Table[30] = "Bio-hazard";
            Table[31] = "GreenDiamond";
            Table[32] = "LionHeart";
            Table[33] = "Serpent";
            Table[34] = "Krypton";
            Table[35] = "Earth";
            Table[36] = "T1Hunter";
            Table[37] = "Ranger";
            Table[38] = "LostPack";
            Table[39] = "RedSkull";
            Table[40] = "Huntress";
            Table[41] = "DaretoWin";
            Table[42] = "MexicoFlag";
            Table[43] = "DarkSky";
            Table[44] = "AustraliaFlag";
            Table[45] = "VietnamFlag";
            Table[46] = "US/CanadaFlag";
            Table[47] = "SyL";
            return Table;
        }
        void String2Command(String command)
        {
            char[] char_arry = command.ToCharArray();
            for(int i=0;i<char_arry.Length;i++)
            {
                switch(char_arry[i])
                {
                    case 'a': Manager.PressKey(Keys.A); break;
                    case 'b': Manager.PressKey(Keys.B); break;
                    case 'c': Manager.PressKey(Keys.C); break;
                    case 'd': Manager.PressKey(Keys.D); break;
                    case 'e': Manager.PressKey(Keys.E); break;
                    case 'f': Manager.PressKey(Keys.F); break;
                    case 'g': Manager.PressKey(Keys.G); break;
                    case 'h': Manager.PressKey(Keys.H); break;
                    case 'i': Manager.PressKey(Keys.I); break;
                    case 'j': Manager.PressKey(Keys.J); break;
                    case 'k': Manager.PressKey(Keys.K); break;
                    case 'l': Manager.PressKey(Keys.L); break;
                    case 'm': Manager.PressKey(Keys.M); break;
                    case 'n': Manager.PressKey(Keys.N); break;
                    case 'o': Manager.PressKey(Keys.O); break;
                    case 'p': Manager.PressKey(Keys.P); break;
                    case 'q': Manager.PressKey(Keys.Q); break;
                    case 'r': Manager.PressKey(Keys.R); break;
                    case 's': Manager.PressKey(Keys.S); break;
                    case 't': Manager.PressKey(Keys.T); break;
                    case 'u': Manager.PressKey(Keys.U); break;
                    case 'v': Manager.PressKey(Keys.V); break;
                    case 'w': Manager.PressKey(Keys.W); break;
                    case 'x': Manager.PressKey(Keys.X); break;
                    case 'y': Manager.PressKey(Keys.Y); break;
                    case 'z': Manager.PressKey(Keys.Z); break;

                    case '0': Manager.PressKey(Keys.D0); break;
                    case '1': Manager.PressKey(Keys.D1); break;
                    case '2': Manager.PressKey(Keys.D2); break;
                    case '3': Manager.PressKey(Keys.D3); break;
                    case '4': Manager.PressKey(Keys.D4); break;
                    case '5': Manager.PressKey(Keys.D5); break;
                    case '6': Manager.PressKey(Keys.D6); break;
                    case '7': Manager.PressKey(Keys.D7); break;
                    case '8': Manager.PressKey(Keys.D8); break;
                    case '9': Manager.PressKey(Keys.D9); break;

                    case ' ': Manager.PressKey(Keys.Space); break;
                    case '/': Manager.PressKey(Keys.Enter); break;
                }
            }
        }
    }
}
