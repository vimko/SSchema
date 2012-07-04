using System;
using System.Collections.Generic;
using System.Text;
using System.Configuration;
using NLog;

namespace SSChema.Services
{
    class ConfigAppSettingHelper
    {
        /// <summary>
        /// 获取配置
        /// </summary>
        public static Configuration Conf
        {
            get
            {

                //string exePath = System.IO.Path.Combine(, "SSChema.Services.exe");

                //Logger logger = LogManager.GetLogger("file");
                //logger.Info(exePath);

                System.Configuration.Configuration conf = System.Configuration.ConfigurationManager.OpenExeConfiguration(ConfigurationUserLevel.None);

                return conf;
            }
        }


        #region 获取 appsetting 属性

        /// <summary>
        /// 
        /// </summary>
        public static string HttpUrl
        {
            get
            {
                return ConfigAppSettingHelper.Conf.AppSettings.Settings["httpurl"].Value;
            }
        }

        public static string Token
        {
            get
            {
                return ConfigAppSettingHelper.Conf.AppSettings.Settings["token"].Value;
            }
        }

        public static string PlanplType
        {
            get
            {
                return ConfigAppSettingHelper.Conf.AppSettings.Settings["planpltype"].Value;
            }
        }

        public static string Planpl
        {
            get
            {
                return ConfigAppSettingHelper.Conf.AppSettings.Settings["planpl"].Value;
            }
        }

        public static string PlanpleverydayType
        {
            get
            {
                return ConfigAppSettingHelper.Conf.AppSettings.Settings["planpleverydaytype"].Value;
            }
        }

        public static string PlaneverydayoneDate
        {
            get
            {
                return ConfigAppSettingHelper.Conf.AppSettings.Settings["planeverydayonedate"].Value;
            }
        }

        public static string PlaneverydaytwoTimes
        {
            get
            {
                return ConfigAppSettingHelper.Conf.AppSettings.Settings["planeverydaytwotimes"].Value;
            }
        }

        public static string PlaneverydaytwotimesType
        {
            get
            {
                return ConfigAppSettingHelper.Conf.AppSettings.Settings["planeverydaytwotimestype"].Value;
            }
        }

        public static string PlaneverydaytwoBDate
        {
            get
            {
                return ConfigAppSettingHelper.Conf.AppSettings.Settings["planeverydaytwobdate"].Value;
            }
        }

        public static string PlaneverydaytwoEDate
        {
            get
            {
                return ConfigAppSettingHelper.Conf.AppSettings.Settings["planeverydaytwoedate"].Value;
            }
        }

        public static string PlancxType
        {
            get
            {
                return ConfigAppSettingHelper.Conf.AppSettings.Settings["plancxtype"].Value;
            }
        }

        public static string PlancxBDate
        {
            get
            {
                return ConfigAppSettingHelper.Conf.AppSettings.Settings["plancxbdate"].Value;
            }
        }

        public static string PlancxEDate
        {
            get
            {
                return ConfigAppSettingHelper.Conf.AppSettings.Settings["plancxedate"].Value;
            }
        }

        #endregion

    }
}
