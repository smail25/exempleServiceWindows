using System;
using System.Security.Cryptography;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Threading;
using Topshelf;

namespace ExempleService
{
    public class ExempleService : ServiceControl
    {
        private bool _mServiceIsRunning = false;
        private Thread _pollingCycle;
        private readonly int _mActivityPollingDelay = 3000;
        private WebServiceHost svcHost;

        public bool Start(HostControl hostControl)
        {
            try
            {
                 _mServiceIsRunning = true;
                _pollingCycle = new Thread(new ThreadStart(ActivationPollingCycle));
                _pollingCycle.Start();
           

                return true;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
                throw;
            }
        }

        private void ActivationPollingCycle()
        {
            RunServiceHost();


            while (_mServiceIsRunning)
            {
                Console.WriteLine("ActivityPollingDelay");
                Thread.Sleep(_mActivityPollingDelay);
            }
        }

        public bool Stop(HostControl hostControl)
        {
            try
            {
              _mServiceIsRunning = false;
              svcHost.Close();
                return true;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
                throw;
            }
        }


        public void RunServiceHost()
        {
            try
            {
                Uri baseAddress = new Uri("http://127.0.0.1:8000/");
                svcHost = new WebServiceHost(typeof(Command), baseAddress);

                svcHost.Open();
                Console.WriteLine("svcHost.Open");
            }
            catch (Exception e)
            {
                Console.WriteLine(e.ToString());

            }

        }
    }
}