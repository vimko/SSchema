using System;
using System.Collections.Generic;
using System.Text;

namespace SSChema.Services.DoServices
{
    class DoSendDataByPost
    {

        public void Do()
        {
            Common.AppLog.CreateAppLog().Debug(DateTime.Now.ToLongTimeString());
        }

    }
}
