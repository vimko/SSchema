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
        private System.Timers.Timer timer;
        private Common.CreateTimer createTimer;
        private DoServices.DoSendDataByPost sendData;

        public PostSaleOrders()
        {
            InitializeComponent();

            createTimer = new Common.CreateTimer();
            timer = createTimer.HTimer;

            sendData = new DoServices.DoSendDataByPost();
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
            try
            {
                timer.Elapsed += new System.Timers.ElapsedEventHandler(timer_Elapsed);
                timer.Enabled = true;
          
            }
            catch (Exception ex)
            {

            }

        }

        void timer_Elapsed(object sender, System.Timers.ElapsedEventArgs e)
        {

            if (createTimer.JudgeCurrentTimeWillExec())
                sendData.Do();
        }

        protected override void OnStop()
        {
            timer.Close();
        }
    }
}
