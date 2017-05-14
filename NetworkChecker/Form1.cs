using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Threading;
using System.Net.NetworkInformation;
using System.IO;
using System.Diagnostics;
using System.Security.Principal;

namespace NetworkChecker
{
    public partial class NetworkChecker : Form
    {
        NotifyIcon theIcon;
        Icon activeIcon;
        Icon idleIcon;
        Thread threadWorker;

        public static string _path = Directory.GetCurrentDirectory() + "\\Logs";
        public static string _txtPath = _path += "\\swaps.log";
        public static string _interface1 = "6";
        public static string _interface2 = "7";
        public static int _seconds = 60;
        public static int _totalSwaps = 0;
        public static double _swapsPerHour = 0.00;
        public static DateTime _lastSwapTime;
        public static DateTime _runtime = DateTime.Now;

        public NetworkChecker()
        {
            InitializeComponent();
            

            activeIcon = new Icon("Active.ico");
            idleIcon = new Icon("Idle.ico");
            theIcon = new NotifyIcon();

            

            theIcon.BalloonTipClicked += TheIcon_BalloonTipClicked;

            richTextBox1.KeyDown += RichTextBox1_KeyDown;

            theIcon.MouseDoubleClick += MainMouseDoubleClick;
            theIcon.Icon = idleIcon;
            theIcon.Visible = true;

            MenuItem quitMenuItem = new MenuItem("Quit");
            MenuItem showMenuItem = new MenuItem("Show");
            ContextMenu contextMenu = new ContextMenu();
            contextMenu.MenuItems.Add(showMenuItem);
            contextMenu.MenuItems.Add(quitMenuItem);

            theIcon.ContextMenu = contextMenu;

            quitMenuItem.Click += QuitMenuItem_Click;
            showMenuItem.Click += ShowMenuItem_Click;

            this.WindowState = FormWindowState.Minimized;
            //this.ShowInTaskbar = false;

            threadWorker = new Thread(new ThreadStart(threadStuff));
            threadWorker.Start();

            if (!IsAdministrator())
            {
                DialogResult result = MessageBox.Show("You must run this as Admin.", "Missing permissions", MessageBoxButtons.OK);
                if (result != DialogResult.None)
                {
                    this.Close();
                }
            }
        }

        public static bool IsAdministrator()
        {
            return (new WindowsPrincipal(WindowsIdentity.GetCurrent()))
                    .IsInRole(WindowsBuiltInRole.Administrator);
        }

        private void TheIcon_BalloonTipClicked(object sender, EventArgs e)
        {
            ShowWindow();
        }

        private void RichTextBox1_KeyDown(object sender, KeyEventArgs e)
        {
            e.SuppressKeyPress = true;
        }

        private void ShowMenuItem_Click(object sender, EventArgs e)
        {
            ShowWindow();
        }

        private void QuitMenuItem_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        protected override void OnResize(EventArgs e)
        {
            base.OnResize(e);

            bool cursorNotInBar = Screen.GetWorkingArea(this).Contains(Cursor.Position);

            if (this.WindowState == FormWindowState.Minimized && cursorNotInBar)
            {
                this.WindowState = FormWindowState.Minimized;
                this.ShowInTaskbar = false;
                theIcon.Visible = true;
                this.Hide();
            }
        }

        private void MainMouseDoubleClick(object sender, MouseEventArgs e)
        {
            ShowWindow();
        }

        private void ShowWindow()
        {
            try
            {
                this.Show();
                this.WindowState = FormWindowState.Normal;
                this.ShowInTaskbar = true;
                theIcon.Visible = true;
                richTextBox1.SelectionStart = richTextBox1.Text.Length;
                richTextBox1.ScrollToCaret();
                richTextBox2.SelectionStart = richTextBox2.Text.Length;
                richTextBox2.ScrollToCaret();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message);
            }
        }

        //public delegate void TextBoxDelegate(string message);

        //public void WriteLine(string msg)
        //{
        //    //DateTime now = DateTime.Now;
        //    //string msg = message;
        //    if (richTextBox1.InvokeRequired)
        //    {
        //        richTextBox1.Invoke(new TextBoxDelegate(WriteLine), new object[] { msg });
        //    }
        //    else
        //    {
        //        if (richTextBox1.Lines.Length >= 300)
        //        {
        //            int numOfLines = 30;
        //            string[] lines = richTextBox1.Lines;
        //            var newLines = lines.Skip(numOfLines);
        //            richTextBox1.Lines = newLines.ToArray();
        //        }
        //        DateTime now = DateTime.Now;
        //        richTextBox1.AppendText(now + " | " + msg + Environment.NewLine);
        //        richTextBox1.SelectionStart = richTextBox1.Text.Length;
        //        richTextBox1.ScrollToCaret();

        //        //in case if you want to ADD text to previuos one do:
        //        //textBox1.Text += msg + " ";

        //        //if (InvokeRequired)
        //        //{
        //        //    this.Invoke(new Action<string>(WriteLine), new object[] { msg });
        //        //    return;
        //        //}
        //        //DateTime now = DateTime.Now;
        //        //richTextBox1.Text += now + " | " + msg;
        //    }
        //}

        public delegate void TextBoxDelegate(string message, RichTextBox box);

        public void WriteLine(string msg, RichTextBox box)
        {
            //DateTime now = DateTime.Now;
            //string msg = message;
            if (box.InvokeRequired)
            {
                box.Invoke(new TextBoxDelegate(WriteLine), new object[] { msg, box });
            }
            else
            {
                if (box.Lines.Length >= 300)
                {
                    int numOfLines = 30;
                    string[] lines = box.Lines;
                    var newLines = lines.Skip(numOfLines);
                    box.Lines = newLines.ToArray();
                }
                DateTime now = DateTime.Now;
                box.AppendText(now + " | " + msg + Environment.NewLine);
                box.SelectionStart = richTextBox1.Text.Length;
                box.ScrollToCaret();
            }
        }

        protected override void OnFormClosing(FormClosingEventArgs e)
        {
            base.OnFormClosing(e);

            if (e.CloseReason == CloseReason.WindowsShutDown) return;

            //threadWorker.Interrupt();
            //if (!threadWorker.Join(2000))
            //{
            //    threadWorker.Abort();
            //}
            threadWorker.Abort();
            theIcon.Dispose();
        }

        public void threadStuff()
        {
            try
            {
                //DateTime dt;
                while (true)
                {
                    MinuteToolStrip();
                    if (PingHost("google.com"))
                    {
                        Thread.Sleep(_seconds * 1000);
                        continue;
                    }
                    theIcon.Icon = activeIcon;
                    WriteLine("Failed to ping Google. Attempting to ping Twitter...", richTextBox1);
                    if (PingHost("twitter.com"))
                    {
                        theIcon.Icon = idleIcon;
                        Thread.Sleep(_seconds * 1000);
                        continue;
                    }
                    WriteLine("Failed to ping Twitter. Attempting to swap network interfaces...", richTextBox1);
                    NetworkInterface[] interfaces = NetworkInterface.GetAllNetworkInterfaces();
                    foreach (NetworkInterface adapter in interfaces)
                    {
                        if (adapter.Name.EndsWith(_interface1))
                        {
                            SwapInterfaces(_interface2, _interface1);
                        }
                        else if (adapter.Name.EndsWith(_interface2))
                        {
                            SwapInterfaces(_interface1, _interface2);
                        }
                    }
                    UpdateToolstrip();
                    theIcon.ShowBalloonTip(5000, "Network Adapter Changed", "The active network adapter has switched.", ToolTipIcon.Info);
                    theIcon.Icon = idleIcon;
                    Thread.Sleep(_seconds * 1000);
                }
            }
            catch (ThreadAbortException tbe)
            {
                
            }
        }

        public bool PingHost(string nameOrAddress)
        {
            bool pingable = false;
            Ping pinger = new Ping();
            try
            {
                PingReply reply = pinger.Send(nameOrAddress);
                pingable = reply.Status == IPStatus.Success;
                if (pingable)
                {
                    WriteLine("Heartbeat " + nameOrAddress + " " + reply.RoundtripTime + "ms.", richTextBox1);
                }
            }
            catch (PingException)
            {
                // Discard PingExceptions and return false;
            }
            return pingable;
        }

        public void SwapInterfaces(string intToEnable, string intToDisable)
        {
            //DateTime dt;
            Process process = new Process();
            ProcessStartInfo startInfo = new ProcessStartInfo();
            startInfo.WindowStyle = System.Diagnostics.ProcessWindowStyle.Hidden;
            startInfo.FileName = "cmd.exe";
            startInfo.Arguments = "/C netsh interface set interface \"Ethernet " + intToEnable + "\" admin=enable";
            process.StartInfo = startInfo;
            WriteLine("Enabling interface \"Ethernet " + intToEnable + "\".", richTextBox1);
            process.Start();
            WriteLine("Done. Waiting 4s...", richTextBox1);
            Thread.Sleep(4 * 1000);
            startInfo.Arguments = "/C netsh interface set interface \"Ethernet " + intToDisable + "\" admin=disable";
            process.StartInfo = startInfo;
            WriteLine("Disabling interface \"Ethernet " + intToDisable + "\".", richTextBox1);
            process.Start();
            WriteLine("Done.", richTextBox1);
            WriteLine("Swapped Ethernet " + intToDisable + " (disabled) with Ethernet " + intToEnable + " (enabled).", richTextBox2);
            LogToFile("Swapped Ethernet " + intToDisable + " (disabled) with Ethernet " + intToEnable + " (enabled).");
        }

        public void LogToFile(string message)
        {
            DateTime now = DateTime.Now;
            string msg = now + " | " + message;
            try
            {
                Directory.CreateDirectory(Path.GetDirectoryName(_txtPath));
            }
            catch (IOException e)
            {
                MessageBox.Show("Error: " + e.Message);
            }

            //try
            //{
            //    if (!Directory.Exists(_path))
            //    {
            //        Directory.CreateDirectory(_path);
            //    }
            //}
            //catch (Exception e)
            //{

            //}
            

            File.AppendAllLines(_txtPath, new[]
            {
                msg
            });
            WriteLine("Wrote line to log file: " + _txtPath, richTextBox1);

            //try
            //{
            //    if (!File.Exists(txtPath))
            //    {
            //        using (StreamWriter sw = File.CreateText(txtPath))
            //        {
            //            //create empty file
            //            sw.Write("");
            //        }
            //    }
            //}
            //catch (Exception e)
            //{
            //    WriteLine(e.Message);
            //}


            //using (StreamWriter sw = File.AppendText(txtPath))
            //{
            //    sw.WriteLine(msg);
            //    WriteLine("Wrote line to log file: " + txtPath);
            //}
        }

        public void MinuteToolStrip()
        {
            if (_totalSwaps > 0)
            {
                DateTime now = DateTime.Now;
                TimeSpan ts = now - _runtime;
                TimeSpan ts2 = now - _lastSwapTime;
                double minutes = ts.TotalMinutes;
                if (minutes > 1)
                {
                    _swapsPerHour = (_totalSwaps / (minutes / 60));
                }
                else
                {
                    _swapsPerHour = (double)_totalSwaps;
                }
                swapsPerHour.Text = "Avg Swaps Per Hour: " + _swapsPerHour.ToString("n2");
                String laast = "Last Swap: " + _lastSwapTime + " - ";
                if (ts2.TotalHours < 1 && ts2.TotalMinutes < 1)
                {
                    laast += "Just now";
                }
                else if (ts2.TotalHours < 1)
                {
                    laast += ts2.Minutes + " minutes ago";
                }
                else if (ts2.Hours > 0)
                {
                    laast += ts2.Hours + " hours " + ts2.Minutes + " minutes ago";
                }
                //String laaast = $"Last Swap: {_lastSwapTime} - {((ts2.Hours < 1 && ts2.Minutes < 5) ? "Just now" : "{ts2.Hours} hours {ts2.Minutes} minutes ago")}";
                lastSwapTS.Text = laast;
            }
        }

        public void UpdateToolstrip()
        {
            _lastSwapTime = DateTime.Now;
            _totalSwaps++;
            totalSwaps.Text = "Total Swaps: " + _totalSwaps;
            MinuteToolStrip();
        }
    }
}
