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
    /// Interaction logic for Login.xaml
    /// </summary>
    public partial class Login : Window
    {
        IBizTier biz;
        public Login()
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

        private void btnCancel_Click(object sender, RoutedEventArgs e)
        {
            MainWindow mw = new MainWindow();
            mw.Show();
            this.Close();
        }

        private void btnConfirm_Click(object sender, RoutedEventArgs e)
        {
            string uname = tbUname.Text;
            string pwd = tbPwd.Text;

            uint userID = biz.login(uname, pwd);

            if (uname == "admin" && pwd == "admin")
            {
                Management mng = new Management();
                mng.Show();
                this.Close();
                userID = 1;
            }
            
            if (userID != 0 && userID != 1)
            {
                Dashboard db = new Dashboard(userID);
                db.Show();
                this.Close();
            }else if (userID == 0) {
                MessageBoxResult result = MessageBox.Show("Invalid Credentials");
            }
                
        }
    }
}
