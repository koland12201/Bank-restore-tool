using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Runtime.InteropServices;

namespace UAC_Bank_Restore_Commands
{
    public partial class Form1 : Form
    {
        public delegate void KeyEventHandler(object sender, KeyEventArgs e);
        public Form1()
        {
            InitializeComponent();
            KeyboardHook hook = new KeyboardHook((int)KeyboardHook.Modifiers.None, Keys.A, this);

            hook.Register(); // registering globally that A will call a method
        }
        private void Form1_Load(object sender, EventArgs e)
        {

        }
        protected override void WndProc(ref Message m)
        {
            if (m.Msg == 0x0312)
                HandleHotkey(); // A, which was registered before, was pressed
            base.WndProc(ref m);
        }

        private void HandleHotkey()
        {
            // instead of A send Q
            KeyboardManager.PressKey(Keys.Q);
        }
    }
}
