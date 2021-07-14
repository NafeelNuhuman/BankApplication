using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using System.Text;
using System.Threading.Tasks;

namespace DataTier
{
    class DataServer
    {
        static void Main(string[] args)
        {
            try
            {
                Console.WriteLine("Bank Data Server Started");
                ServiceHost hostData;
                NetTcpBinding tcpBinding = new NetTcpBinding();

                hostData = new ServiceHost(typeof(IBankImpl));
                hostData.AddServiceEndpoint(typeof(IBank), tcpBinding, "net.tcp://localhost:8001/BankServer");

                hostData.Open();
                Console.WriteLine("Press Enter To Exit");
                Console.ReadLine();

                hostData.Close();
            }
            catch (FaultException exception)
            {
                Console.WriteLine("Unable to establish connection with bank data server" + exception);
            }
        }
    }
}
