using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using System.Text;
using System.Threading.Tasks;
using DataTier;

namespace BusinessTier
{
    class BizTierServer
    {
        static void Main(string[] args)
        {
            try
            {
                Console.WriteLine("Bank Data Server Started");
                ServiceHost hostData;
                NetTcpBinding tcpBinding = new NetTcpBinding();

                hostData = new ServiceHost(typeof(IBizTierImpl));
                hostData.AddServiceEndpoint(typeof(IBizTier), tcpBinding, "net.tcp://localhost:8002/BizServer");

                hostData.Open();
                Console.WriteLine("Press Enter To Exit");
                Console.ReadLine();

                hostData.Close();
            }
            catch (FaultException exception)
            {
                Console.WriteLine("Unable to establish connection with bank business server" + exception);
            }

        }
    }
}
