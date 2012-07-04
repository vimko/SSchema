using System;
using System.Collections.Generic;
using System.Text;
using System.ServiceProcess;

namespace SSChema.Controller
{
    class ServiceControllerHelper
    {
        private ServiceController sc;

        public ServiceController Service
        {
            get { return sc; }
        }

        public ServiceControllerHelper(string servicename)
        {
            sc = new ServiceController(servicename);
        }


    }
}
