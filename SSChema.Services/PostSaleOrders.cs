using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.ServiceProcess;
using System.Text;
using NLog;
using System.Threading;
using System.IO;

namespace SSChema.Services
{
    public partial class PostSaleOrders : ServiceBase
    {
        
        public PostSaleOrders()
        {
            InitializeComponent();
        }

        protected override void OnStart(string[] args)
        {
            Thread servicethread = new Thread(DoServerice);

            servicethread.IsBackground = true;
            servicethread.Name = "servicethread";
            servicethread.Start();
        }

        /// <summary>
        /// 实际执行的计划
        /// </summary>
        private void DoServerice()
        {
            Logger logger = LogManager.GetLogger("file");

            try
            {
                System.Timers.Timer timer = new System.Timers.Timer();

                if (ConfigAppSettingHelper.PlanpleverydayType == "2")
                {
                    int times = Convert.ToInt32( ConfigAppSettingHelper.PlaneverydaytwoTimes);

                    logger.Info(times.ToString());

                    switch (ConfigAppSettingHelper.PlaneverydaytwotimesType)
                    {
                        case "秒":
                            timer.Interval = times * 1000;
                            break;
                        case "每分":
                            timer.Interval = times * 60 * 1000;
                            break;
                        case "每时":
                            timer.Interval = times * 3600 * 1000;
                            break;
                        default:
                            timer.Interval = 1000;
                            break;

                    }

                }
                else
                    timer.Interval = 1000;

                
                logger.Info(string.Format("时间间隔：{0}",timer.Interval));

                timer.Elapsed += new System.Timers.ElapsedEventHandler(timer_Elapsed);
                timer.Enabled = true;
            }
            catch (Exception ex)
            {
                logger.Error(ex.Message);
            }

        }

        void timer_Elapsed(object sender, System.Timers.ElapsedEventArgs e)
        {
            DateTime now = DateTime.Now;

            //判断是否在执行时间断内
            //if (now.CompareTo(DateTime.Parse(ConfigAppSettingHelper.PlancxBDate)) < 0) return;

            //if(ConfigAppSettingHelper.PlancxType == "1")
            //    if (now.CompareTo(DateTime.Parse(ConfigAppSettingHelper.PlancxEDate)) > 0) return;

            Logger logger = LogManager.GetLogger("file");
            logger.Info(DateTime.Now.ToLongTimeString());
        }

        protected override void OnStop()
        {
            //System.Windows.Forms.MessageBox.Show("服务停止");
        }
    }
}
