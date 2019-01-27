using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using CefSharp;
using CefSharp.WinForms;
using NHotkey;
using NHotkey.WindowsForms;

namespace AOU
{
    public partial class Form1 : Form
    {
        // CefSharp
        // Ref : https://www.codeproject.com/Articles/1058700/Embedding-Chrome-in-your-Csharp-App-using-CefSharp

        // MyCustomMenuHandler
        // Ref : https://ourcodeworld.com/articles/read/448/how-to-prevent-the-native-context-menu-from-appearing-on-a-cefsharp-control-in-winforms

        public Form1()
        {
            InitializeComponent();

            // Hotkey
            HotkeyManager.Current.AddOrReplace("Escape", Keys.Escape, OnEscape_Click);

            // make a topmost and borderless form
            this.FormBorderStyle = FormBorderStyle.None;
            this.TopMost = true;
            this.WindowState = FormWindowState.Maximized;

            InitBrowser();
        }

        private void OnEscape_Click(object sender, HotkeyEventArgs e)
        {
            this.Close();
        }

        public ChromiumWebBrowser browser;
        public void InitBrowser()
        {
            //var setting = new CefSettings();

            var url = "https://www.google.com";
            url = "https://www.sce.pccu.edu.tw";

            Cef.Initialize(new CefSettings());
            browser = new ChromiumWebBrowser(url);
            this.Controls.Add(browser);
            browser.Dock = DockStyle.Fill;

            // Register your Custom Menu Handler as default
            browser.MenuHandler = new MyCustomMenuHandler();
        }
    }
}
