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
    /// Interaction logic for Transactions.xaml
    /// </summary>
    public partial class Transactions : Window
    {
        IBizTier biz;
        public Transactions()
        {
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
        }

        private void NumberValidationTextBox(object sender, TextCompositionEventArgs e)
        {
            Regex regex = new Regex("[^0-9]+");
            e.Handled = regex.IsMatch(e.Text);
        }

        private void btnCancel_Click(object sender, RoutedEventArgs e)
        {
            Dashboard db = new Dashboard();
            db.Show();
            this.Close();
        }

        private void btnConfirm_Click(object sender, RoutedEventArgs e)
        {
            uint senderID = Convert.ToUInt32(this.tbSendID.Text);
            uint recID = Convert.ToUInt32(this.tbRecID.Text);
            uint amount = Convert.ToUInt32(this.tbAmount.Text);
            biz.createTrasaction(senderID, recID, amount);

            MessageBoxResult result = MessageBox.Show("Transaction Created Successfully. It will be processed in a while.");
        }

        private void btnSearch_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                List<uint> transactions = biz.getTransactionsForAccount(Convert.ToUInt32(tbAccountID.Text));
                this.transList.ItemsSource = transactions;
            }catch(Exception exception)
            {
                MessageBoxResult result = MessageBox.Show("Unable to get transactions");
            }
            
        }
    }
}
