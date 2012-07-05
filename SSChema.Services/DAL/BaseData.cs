using System;
using System.Collections.Generic;
using System.Text;
using System.Configuration;

namespace SSChema.Services.DAL
{
    class BaseData
    {

        private string connectString = string.Empty;

        // 数据库存连接字符串
        public string ConnectString
        {
            get
            {
                return this.connectString;
            }
        }

        // 静态数据库连接字符串
        public static string StaConnectString
        {
            get
            {
                try
                {
                    ConnectionStringSettings conStr = ConfigurationManager.ConnectionStrings["DataBaseConString"];


                    return SSChema.Common.StringEncrypt.Decode(conStr.ConnectionString);
                }
                catch (Exception)
                {
                    throw;
                }
            }
        }

        public BaseData()
        {
            try
            {
                ConnectionStringSettings conStr = ConfigurationManager.ConnectionStrings["DataBaseConString"];

                this.connectString = SSChema.Common.StringEncrypt.Decode(conStr.ConnectionString);
            }
            catch (Exception)
            {
                throw;
            }
        }


    }
}
