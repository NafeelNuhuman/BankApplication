using BusinessTier;
using DataTier;
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
    /// Interaction logic for Accounts.xaml
    /// </summary>
    public partial class Accounts : Window
    {
        IBizTier biz;
        uint userID = 739565980;
        public Accounts(uint userID)
        {
            this.userID = userID;
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

       
        private void ListView_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            string item = accountList.SelectedItem.ToString();
            uint accountID = Convert.ToUInt32(item);
            AccountDetails ac = new AccountDetails(accountID);
            ac.Show();
        }

        private void btnCreateAcc_Click(object sender, RoutedEventArgs e)
        {
            biz.createAccount(userID);
            MessageBoxResult result = MessageBox.Show("Account Created Successfully");
        }

        private void btnShowAcc_Click(object sender, RoutedEventArgs e)
        {
            List<uint> accounts = biz.getAllAccounts(userID);
            this.accountList.ItemsSource = accounts;
        }
    }
}
