using System;
using System.Collections.Generic;
using System.Text;
using System.Timers;
using NLog;

namespace SSChema.Services.Common
{
    class CreateTimer
    {
        private Timer timer = null;

        public Timer HTimer
        {
            get { return timer; }
        }

        private AppSetting appSeeting = null;

        /// <summary>
        /// 服务上次运行时间
        /// </summary>
        private static DateTime upExecTime = DateTime.Now;

        public CreateTimer()
        {
            appSeeting = new AppSetting();

            timer = new Timer();

            InitTimer(timer);
        }

        /// <summary>
        /// 设置计时器时间间隔
        /// </summary>
        /// <param name="timmer"></param>
        private void InitTimer(Timer timer)
        {
            try
            {
                if (appSeeting.PlanpleverydayType == "2")
                {
                    int times = Convert.ToInt32(appSeeting.PlaneverydaytwoTimes);

                    switch (appSeeting.PlaneverydaytwotimesType)
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

                

            }
            catch (Exception ex)
            {
                AppLog.CreateAppLog().Error(ex.Message);
            }
        }

        /// <summary>
        /// 判断当前时间是否执行
        /// <remarks>返回真执行，假不执行</remarks>
        /// </summary>
        /// <returns></returns>
        public bool JudgeCurrentTimeWillExec()
        {
            bool flag = true;

            DateTime now = DateTime.Now;
            DateTime nowTime = DateTime.Parse(now.ToLongTimeString());
            DateTime upTime = DateTime.Parse(upExecTime.ToLongTimeString());

            //判断是否在执行时间断内
            if (now.CompareTo(DateTime.Parse(appSeeting.PlancxBDate)) < 0) return false;

            if (ConfigAppSettingHelper.PlancxType == "1")
                if (now.CompareTo(DateTime.Parse(appSeeting.PlancxEDate)) > 0) return false;

            //检查当天是否执行
            if (appSeeting.Planpl != "1")
                if (DateDayDiff(now, DateTime.Parse(appSeeting.PlanSetDate)) % Convert.ToInt32(appSeeting.Planpl) != 0)
                    return false;
            
            //判断每天频率
            //每天只执行一次
            if (appSeeting.PlanpleverydayType == "1")
            {
                if (DateTime.Parse(appSeeting.PlaneverydayoneDate).CompareTo(nowTime) != 0)
                    return false;
            }
            else if (appSeeting.PlanpleverydayType == "2")
            {
                if (nowTime.CompareTo(DateTime.Parse(appSeeting.PlaneverydaytwoBDate)) < 0 || nowTime.CompareTo(DateTime.Parse(appSeeting.PlaneverydaytwoEDate)) > 0)
                    return false;
                else
                {
                    int times = Convert.ToInt32(appSeeting.PlaneverydaytwoTimes);

                    switch (appSeeting.PlaneverydaytwotimesType)
                    {
                        case "秒":
                            if (upTime.AddSeconds(times).CompareTo(nowTime) != 0)
                                return false;
                            break;
                        case "每分":
                            if (upTime.AddMinutes(times).CompareTo(nowTime) != 0)
                                return false;
                            break;
                        case "每时":
                            if (upTime.AddHours(times).CompareTo(nowTime) != 0)
                                return false;
                            break;
                        default:
                            break;
                    }
                }
            }

            upExecTime = now;

            return flag;
        }

        /// <summary>
        /// 返回两个日期相关的天数
        /// </summary>
        /// <param name="DateTime1"></param>
        /// <param name="DateTime2"></param>
        /// <returns></returns>
        private int DateDayDiff(DateTime DateTime1, DateTime DateTime2)
        {
            TimeSpan ts1 = new TimeSpan(DateTime1.Date.Ticks);
            TimeSpan ts2 = new TimeSpan(DateTime2.Date.Ticks);
            TimeSpan ts = ts1.Subtract(ts2).Duration();

            return ts.Days;
        }

    }
}
