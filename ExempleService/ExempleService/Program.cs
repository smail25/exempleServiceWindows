using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Topshelf;

namespace ExempleService
{

    //http://topshelf-project.com/
    class Program
    {
        static void Main(string[] args)
        {
            var rc = HostFactory.Run(configurator =>
            {
                configurator.Service(service => new ExempleService());
                configurator.SetDescription("ExempleService");
                configurator.SetDisplayName("ExempleService");
                configurator.SetServiceName("ExempleService");

            });

            Environment.ExitCode = (int)Convert.ChangeType(rc, rc.GetTypeCode());


        }
    }
}
