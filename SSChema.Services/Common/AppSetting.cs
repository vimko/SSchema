using System;
using System.Collections.Generic;
using System.Text;
using System.Configuration;

namespace SSChema.Services.Common
{
    class AppSetting
    {

        private static string _token = null;
        /// <summary>
        /// 安全令牌
        /// </summary>
        public static string token
        {
            get { return SSChema.Common.StringEncrypt.Decode(_token); }
        }

        private static string _httpurl = null;
        /// <summary>
        /// 提交地址
        /// </summary>
        public static string httpurl
        {
            get { return SSChema.Common.StringEncrypt.Decode(_httpurl); }
        }

        private Configuration conf = null;

        public AppSetting()
        {
            conf = ConfigurationManager.OpenExeConfiguration(ConfigurationUserLevel.None);
        }

        static AppSetting()
        {
            if (_token == null)
            {
                Configuration conff = ConfigurationManager.OpenExeConfiguration(ConfigurationUserLevel.None);

                _token = conff.AppSettings.Settings["token"].Value;
            }

            if (_httpurl == null)
            {
                Configuration conff = ConfigurationManager.OpenExeConfiguration(ConfigurationUserLevel.None);

                _httpurl = conff.AppSettings.Settings["httpurl"].Value;
            }
        }

        #region 获取 appsetting 属性

        /// <summary>
        /// 
        /// </summary>
        public string HttpUrl
        {
            get
            {
                return conf.AppSettings.Settings["httpurl"].Value;
            }
        }

        public string Token
        {
            get
            {
                return conf.AppSettings.Settings["token"].Value;
            }
        }

        public string PlanplType
        {
            get
            {
                return conf.AppSettings.Settings["planpltype"].Value;
            }
        }

        public string Planpl
        {
            get
            {
                return conf.AppSettings.Settings["planpl"].Value;
            }
        }

        public string PlanpleverydayType
        {
            get
            {
                return conf.AppSettings.Settings["planpleverydaytype"].Value;
            }
        }

        public string PlaneverydayoneDate
        {
            get
            {
                return conf.AppSettings.Settings["planeverydayonedate"].Value;
            }
        }

        public string PlaneverydaytwoTimes
        {
            get
            {
                return conf.AppSettings.Settings["planeverydaytwotimes"].Value;
            }
        }

        public string PlaneverydaytwotimesType
        {
            get
            {
                return conf.AppSettings.Settings["planeverydaytwotimestype"].Value;
            }
        }

        public string PlaneverydaytwoBDate
        {
            get
            {
                return conf.AppSettings.Settings["planeverydaytwobdate"].Value;
            }
        }

        public string PlaneverydaytwoEDate
        {
            get
            {
                return conf.AppSettings.Settings["planeverydaytwoedate"].Value;
            }
        }

        public string PlancxType
        {
            get
            {
                return conf.AppSettings.Settings["plancxtype"].Value;
            }
        }

        public  string PlancxBDate
        {
            get
            {
                return conf.AppSettings.Settings["plancxbdate"].Value;
            }
        }

        public string PlancxEDate
        {
            get
            {
                return conf.AppSettings.Settings["plancxedate"].Value;
            }
        }

        public string PlanSetDate
        {
            get
            {
                return conf.AppSettings.Settings["plansetdate"].Value;
            }
        }

        #endregion
    }
}
