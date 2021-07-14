using BusinessTier;
using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace BankClient
{
    /// <summary>
    /// Interaction logic for Profile.xaml
    /// </summary>
    public partial class Profile : Window
    {
        IBizTier biz;
        public Profile(uint userID)
        {
            try
            {
                ChannelFactory<IBizTier> BankChannelFactory;
                NetTcpBinding tcpBinding = new NetTcpBinding();

                BankChannelFactory = new ChannelFactory<IBizTier>(tcpBinding, "net.tcp://localhost:8002/BizServer");
                biz = BankChannelFactory.CreateChannel();
            }
            catch (Exception e)
            {
                Console.WriteLine("Unable to connect to bank data server " + e);
            }
            InitializeComponent();

            string fname;
            string lname;

            biz.getNames(out fname, out lname);

            lblFName.Content = fname;
            lblLName.Content = lname;

        }


    }
}
