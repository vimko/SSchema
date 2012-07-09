using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.ServiceProcess;
using System.ComponentModel;
using System.Runtime.InteropServices;

namespace SSChema.Controller
{
    public partial class MainForm : Form
    {
        public const int WM_PAINT = 0xF;
        public const int WM_USER = 0x0400;
        public const int TB_BUTTONCOUNT = WM_USER + 24;
        public const int TB_GETRECT = WM_USER + 51;

        [DllImport("USER32.DLL")]
        public static extern int SendMessage(IntPtr hwnd, int msg, int character, IntPtr lpsText);
        [DllImport("user32.DLL")]
        public static extern int SendMessage(IntPtr hWnd, int Msg, int wParam, int lParam);
        [DllImport("user32.DLL")]
        public static extern IntPtr FindWindow(string lpszClass, string lpszWindow);
        [DllImport("user32.DLL")]
        public static extern IntPtr FindWindowEx(IntPtr hwndParent,
            IntPtr hwndChildAfter, string lpszClass, string lpszWindow);
        [DllImport("user32.dll")]
        public static extern uint GetWindowThreadProcessId(IntPtr hWnd,
            out uint dwProcessId);


        private ServiceController sc;

        public MainForm()
        {
            InitializeComponent();

            InitForm();
        }

        private void InitForm()
        {
            this.Hide();

            try
            {
                sc = new ServiceController("PostSaleOrders");

                ServicesStatus();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "操作提示", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void ServicesStatus()
        {
            if (sc.Status == ServiceControllerStatus.Running)
            {
                this.buttonStart.Enabled = false;
                this.buttonStop.Enabled = true;
                this.buttonRestart.Enabled = true;

                this.notifyIcon1.Icon = Resources.play;

                this.listViewServiceStatus.Items[0].ImageIndex = 0;
            }
            else if (sc.Status == ServiceControllerStatus.Stopped)
            {
                this.buttonStart.Enabled = true;
                this.buttonStop.Enabled = false;
                this.buttonRestart.Enabled = false;

                this.notifyIcon1.Icon = Resources.play_gray;

                this.listViewServiceStatus.Items[0].ImageIndex = 1;
            }
        }


        #region notifyicon 上下文菜单
        /// <summary>
        /// 退出监视程序
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void toolStripMenuItemExit_Click(object sender, EventArgs e)
        {
            Close();
            GetHandler();
            Dispose();
        }

        /// <summary>
        /// 打开服务
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void toolStripMenuItemServices_Click(object sender, EventArgs e)
        {
            System.Diagnostics.Process.Start("services.msc");
        }

        private void toolStripMenuItemSController_Click(object sender, EventArgs e)
        {
            ////this.WindowState = FormWindowState.Normal;

            //if (this.WindowState == FormWindowState.Minimized)
            //    this.WindowState = FormWindowState.Normal;
            //else if (this.WindowState == FormWindowState.Normal)
            //    this.WindowState = FormWindowState.Minimized;

            //// Activate the form.
            //this.Activate();

            WindowState = FormWindowState.Maximized;
            Activate();
            ShowInTaskbar = false;

        }
        #endregion

        #region notifyicon 双击事件
        private void notifyIcon1_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            //this.WindowState = FormWindowState.Normal;

            //if (this.WindowState == FormWindowState.Minimized)
            //    this.WindowState = FormWindowState.Normal;
            //else if (this.WindowState == FormWindowState.Normal)
            //    this.WindowState = FormWindowState.Minimized;
            

            //// Activate the form.
            //this.Activate();

            WindowState = FormWindowState.Maximized;
            Activate();
            ShowInTaskbar = false;
        }
        #endregion

        #region 控制器操作

        /// <summary>
        /// 确定
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void buttonOk_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
    
        }

        /// <summary>
        /// 启动服务
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void buttonStart_Click(object sender, EventArgs e)
        {
            StartOrStopServices();
        }


        /// <summary>
        /// 停止服务
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void buttonStop_Click(object sender, EventArgs e)
        {
            StartOrStopServices();
        }

        /// <summary>
        /// 重启服务
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void buttonRestart_Click(object sender, EventArgs e)
        {
            if (sc.Status == ServiceControllerStatus.Running)
            {
                sc.Refresh();

                sc.WaitForStatus(ServiceControllerStatus.Running);
            }

            ServicesStatus();

            string msg2 = "服务已经重启。";
            listBox2.Items.Add(msg2);
        }

        /// <summary>
        /// 打开所有服务
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void buttonServices_Click(object sender, EventArgs e)
        {
            System.Diagnostics.Process.Start("services.msc");
        }

        /// <summary>
        /// 打开配置窗口
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void buttonConfig_Click(object sender, EventArgs e)
        {
            //SSChema.Services.ConfigForm form = new Services.ConfigForm();

            ConfigForm form = new ConfigForm();

            if (form.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                if (sc.Status == ServiceControllerStatus.Running)
                {
                    StartOrStopServices();
                    StartOrStopServices();
                }
            }
        }

        /// <summary>
        /// 执行计划
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void buttonPlan_Click(object sender, EventArgs e)
        {
            TimeSetForm form = new TimeSetForm();

            if (form.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                if (sc.Status == ServiceControllerStatus.Running)
                {
                    StartOrStopServices();
                    StartOrStopServices();
                }
            }
        }

        /// <summary>
        /// 退出程序
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void buttonExit_Click(object sender, EventArgs e)
        {
            Close();
            GetHandler();
            Dispose();
        }
        #endregion

        /// <summary>
        /// 双击服务状态
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void listViewServiceStatus_DoubleClick(object sender, EventArgs e)
        {
            ListView servicesStates = sender as ListView;

            if (servicesStates == null) return;

            ListViewItem svItem = servicesStates.SelectedItems[0];

            if (svItem.Text == "同步服务")
            {
                StartOrStopServices();
                //MessageBox.Show("sssssssss");
            }
        }

        private void StartOrStopServices()
        {
            try
            {
                if (sc.Status == ServiceControllerStatus.Stopped)
                {
                    sc.Start();

                    string msg1 = "服务正在启动。";
                    listBox2.Items.Add(msg1);

                    sc.WaitForStatus(ServiceControllerStatus.Running);

                    string msg2 = "服务启动完成。";
                    listBox2.Items.Add(msg2);
                }
                else if (sc.Status == ServiceControllerStatus.Running)
                {
                    if (sc.CanStop)
                    {
                        sc.Stop();

                        string msg3 = "服务正在停止。";
                        listBox2.Items.Add(msg3);

                        sc.WaitForStatus(ServiceControllerStatus.Stopped);

                        string msg4 = "服务停止。";
                        listBox2.Items.Add(msg4);
                    }
                }

                ServicesStatus();
            }
            catch (Exception ee)
            {
                MessageBox.Show(ee.Message, "操作提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void MainForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            //e.Cancel = true;
        }


        private void GetHandler()
        {
            IntPtr vHandle = FindWindow("Shell_TrayWnd", null);
            vHandle = FindWindowEx(vHandle, IntPtr.Zero, "ReBarWindow32", null);
            vHandle = FindWindowEx(vHandle, IntPtr.Zero, "MSTaskSwWClass", null);
            vHandle = FindWindowEx(vHandle, IntPtr.Zero, "ToolbarWindow32", null);
            int vCount = SendMessage(vHandle, TB_BUTTONCOUNT, 0, 0);
            try
            {
                for (int i = 0; i < vCount; i++)
                {
                    SendMessage(vHandle, WM_PAINT, 0, IntPtr.Zero);
                }
            }
            catch (Exception e)
            {
                notifyIcon1.Text = e.Message;
            }
            finally
            {
                notifyIcon1.Icon.Dispose();
            }
        }

        protected override void OnClosing(CancelEventArgs e)
        {
            e.Cancel = true;
            Hide();
            ShowInTaskbar = true;
        }


    }
}
