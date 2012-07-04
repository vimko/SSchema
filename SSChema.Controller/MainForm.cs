using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.ServiceProcess;

namespace SSChema.Controller
{
    public partial class MainForm : Form
    {
        private ServiceController sc;

        public MainForm()
        {
            InitializeComponent();

            InitForm();
        }

        private void InitForm()
        {
            sc = new ServiceController("PostSaleOrders");

            ServicesStatus();
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
            this.Close();
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
            this.WindowState = FormWindowState.Normal;
        }
        #endregion

        #region notifyicon 双击事件
        private void notifyIcon1_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            this.WindowState = FormWindowState.Normal;
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

            form.ShowDialog();
        }

        /// <summary>
        /// 执行计划
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void buttonPlan_Click(object sender, EventArgs e)
        {
            TimeSetForm form = new TimeSetForm();

            form.ShowDialog();
        }

        /// <summary>
        /// 退出程序
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void buttonExit_Click(object sender, EventArgs e)
        {
            this.Close();
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



    }
}
