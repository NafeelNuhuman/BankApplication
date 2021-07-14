using System;
using System.Collections.Generic;
using System.Linq;
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
    /// Interaction logic for Dashboard.xaml
    /// </summary>
    public partial class Dashboard : Window
    {
        private uint userID;
        public Dashboard(uint userID)
        {
            this.userID = userID;
            InitializeComponent();
        }

        public Dashboard()
        {
            InitializeComponent();
        }

        private void btnAccounts_Click(object sender, RoutedEventArgs e)
        {
            Accounts acc = new Accounts(userID);
            acc.Show();
        }

        private void btnProfile_Click(object sender, RoutedEventArgs e)
        {
            Profile profile = new Profile(userID);
            profile.Show();
        }

        private void btnTransacations_Click(object sender, RoutedEventArgs e)
        {
            Transactions trans = new Transactions();
            trans.Show();
        }

        private void btnLogOut_Click(object sender, RoutedEventArgs e)
        {
            Login login = new Login();
            login.Show();
            this.Close();
        }
    }
}
