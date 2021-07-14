using BusinessTier;
using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using System.Text;
using System.Text.RegularExpressions;
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
    /// Interaction logic for AccountDetails.xaml
    /// </summary>
    public partial class AccountDetails : Window
    {
        IBizTier biz;
        private uint bal;
        private uint accountID;
        public AccountDetails(uint accountID)
        {
            this.accountID = accountID;
            InitializeComponent();
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
            this.lblAccountID.Content = accountID.ToString();

            bal = biz.getBalance(accountID);
            this.lblBalance.Content = "LKR. " + bal.ToString();
        }

        private void NumberValidationTextBox(object sender, TextCompositionEventArgs e)
        {
            Regex regex = new Regex("[^0-9]+");
            e.Handled = regex.IsMatch(e.Text);
        }

        private void btnDeposit_Click(object sender, RoutedEventArgs e)
        {
            uint amt = Convert.ToUInt32(tbDepAmount.Text);
            bool res = biz.deposit(amt);
            if (res == true)
            {
                MessageBoxResult result = MessageBox.Show("Deposit Successful");
            }
            else if (res == false)
            {
                MessageBoxResult result = MessageBox.Show("Deposit Unsuccesful!");
            }
        }


        private void btnRefresh_Click(object sender, RoutedEventArgs e)
        {
            bal = biz.getBalance(accountID);
            this.lblBalance.Content = "LKR. " + bal.ToString();
        }

        private void btnWIthdraw_Click(object sender, RoutedEventArgs e)
        {
            uint amt = Convert.ToUInt32(tbWithdrawAmt.Text);
            bool res  = biz.withdraw(amt);
            if(res == true)
            {
                MessageBoxResult result = MessageBox.Show("Withdraw Successful");
            }else if (res == false)
            {
                MessageBoxResult result = MessageBox.Show("Withdraw Unsuccesful!");
            }
        }
    }
}
