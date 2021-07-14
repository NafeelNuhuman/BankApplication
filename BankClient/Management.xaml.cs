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
    /// Interaction logic for Management.xaml
    /// </summary>
    public partial class Management : Window
    {
        IBizTier biz;

        public Management()
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
        }

        private void btnShowTrans_Click(object sender, RoutedEventArgs e)
        {
            List<uint> transactions = biz.getAllTransactions();
            this.transList.ItemsSource = transactions;
        }

        private void btnLogOut_Click(object sender, RoutedEventArgs e)
        {
            Login login = new Login();
            login.Show();
            this.Close();
        }

        private void btnProcessAll_Click(object sender, RoutedEventArgs e)
        {
            biz.processAllTransacations();
            MessageBoxResult result = MessageBox.Show("All transactions have been processed");
        }

        private void btnShowUsers_Click(object sender, RoutedEventArgs e)
        {
            List<uint> users = biz.getUsers();
            this.usersList.ItemsSource = users;
        }
    }
}
