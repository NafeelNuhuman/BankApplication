using DataTier;
using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using System.Text;
using System.Threading.Tasks;

namespace BusinessTier
{
    internal class IBizTierImpl : IBizTier
    {
        private IBank data;

        public IBizTierImpl()
        {
            //connect to the data server
            try
            {
                ChannelFactory<IBank> BankChannelFactory;
                NetTcpBinding tcpBinding = new NetTcpBinding();

                BankChannelFactory = new ChannelFactory<IBank>(tcpBinding, "net.tcp://localhost:8001/BankServer");
                data = BankChannelFactory.CreateChannel();
            }
            catch (Exception e)
            {
                Console.WriteLine("Unable to connect to bank data server " + e);
            }
        }

        //Account methods
        public uint createAccount(uint userID)
        {
            return data.CreateAccount(userID);
        }

        public bool deposit(uint amount)
        {
            return data.Deposit(amount);
        }

        public uint getBalance(uint accountID)
        {
            data.SelectAccount(accountID);
            return data.GetBalance();
        }

        public bool withdraw(uint amount)
        {
            uint bal = data.GetBalance();
            if (bal > amount)
            {
                return data.Withdraw(amount);
            }
            return false;
        }

        List<uint> IBizTier.getAllAccounts(uint userID)
        {
            return data.GetAccountIDsByUser(userID);
        }

        //Transaction methods
        public uint createTrasaction(uint sendersAcc, uint recAcc, uint amount)
        {
            uint transID = data.CreateTransaction();
            data.SelectTransaction(transID);
            data.SetRecvr(recAcc);
            data.SetSendr(sendersAcc);
            data.SetAmount(amount);
            return transID;
        }

        public List<uint> getAllTransactions()
        {
            return data.GetTransactions();
        }

        public List<uint> getTransactionsForAccount(uint accountID)
        {
            List<uint> allTransactions = data.GetTransactions();
            List<uint> accTransactions = new List<uint>();
            foreach (uint transaction in allTransactions)
            {
                data.SelectTransaction(transaction);
                uint senderAcc = data.GetSendrAcct();
                if (senderAcc == accountID)
                {
                    accTransactions.Add(transaction);
                }
            }
            return accTransactions;
        }

        public void processAllTransacations()
        {
            data.ProcessAllTransactions();
        }

        //User Methods
        public uint createUser(string fname, string lname, string uname, string pwd)
        { 
            uint id = data.CreateUser();
            data.SelectUser(id);
            data.SetUserName(fname, lname);
            data.Register(id, uname, pwd);
            return id;
        }

        public uint editUser(string fname, string lname, uint id)
        {
            data.SelectUser(id);
            data.SetUserName(fname, lname);
            return id;
        }

        public void getNames(out string fname, out string lname)
        {
            data.GetUserName(out fname, out lname);
        }

        public List<uint> getUsers()
        {
            return data.GetUsers();
        }

        public uint login(string uname, string pwd)
        {
            return data.Login(uname, pwd);
        }
        
    }
}
