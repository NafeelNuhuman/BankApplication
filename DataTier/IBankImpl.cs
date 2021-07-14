using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.ServiceModel;
using System.Text;
using System.Threading.Tasks;

namespace DataTier
{
    [ServiceBehavior(ConcurrencyMode = ConcurrencyMode.Multiple, UseSynchronizationContext = false, IncludeExceptionDetailInFaults = true)]
    internal class IBankImpl : IBank
    {
        //Creating a static object of BankDB from BankDB.dll
        //static BankDB.BankDB bank = new BankDB.BankDB();
        public static BankDB.BankDB bank { get; } = new BankDB.BankDB();
        //creating interfaces from BankDB.dll
        //account interface
        private BankDB.AccountAccessInterface AccountAccessInterface; 
       
        //user interface
        private BankDB.UserAccessInterface UserAccessInterface; 

        //Transaction interface
        private BankDB.TransactionAccessInterface TransactionAccessInterface; 

        public IBankImpl()
        {
            AccountAccessInterface = bank.GetAccountInterface();
            UserAccessInterface = bank.GetUserAccess();
            TransactionAccessInterface =  bank.GetTransactionInterface();
        }

        public void SaveToDisk()
        {
            bank.SaveToDisk();
        }

        public void ProcessAllTransactions()
        {
            bank.ProcessAllTransactions();
        }

        //Account interface methods

        public void SelectAccount(uint accID)
        {
            AccountAccessInterface.SelectAccount(accID);
        }

        public uint CreateAccount(uint userID)
        {
            uint id = 0;
            try
            {
                id = AccountAccessInterface.CreateAccount(userID);
                bank.SaveToDisk();
                return id;
            }catch(Exception e)
            {
                Console.WriteLine("unable to create an account " + e);
            }
            return id;
        }
        public List<uint> GetAccountIDsByUser(uint userID)
        {
            return AccountAccessInterface.GetAccountIDsByUser(userID);
        }

        public Boolean Deposit(uint amount)
        {
            try
            {
                AccountAccessInterface.Deposit(amount);
                bank.SaveToDisk();
                return true;
            }
            catch (Exception e)
            {
                Console.WriteLine("unable to deposit amount" + e);
                return false;
            }
        }
        public Boolean Withdraw(uint amount)
        {
            try
            {
                AccountAccessInterface.Withdraw(amount);
                bank.SaveToDisk();
                return true;
            }
            catch (Exception e)
            {
                Console.WriteLine("unable to withdraw amount" + e);
                return false;
            }
            
        }

        public uint GetBalance()
        {
            uint balance = 0;
            try
            {
                balance = AccountAccessInterface.GetBalance();
                return balance;
            }
            catch(Exception e)
            {
                Console.WriteLine("Unable to fet balance " + e);
            }
            return balance;
        }

        public uint GetOwner()
        {
            return AccountAccessInterface.GetOwner();
        }
        
        public uint Register(uint userID, string uname, string pwd)
        {
            string docPath = @"registrations.txt";

            //if text file does not exist
            if (!File.Exists(docPath))
            { // Create a file to write to   
                using (StreamWriter sw = File.CreateText(docPath)) { };
            }

            try
            {
                //append to existing file
                using (StreamWriter outputFile = new StreamWriter(docPath, true))
                {
                    outputFile.WriteLine(userID + " " + uname + " " + pwd);
                }
                return 1;
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                return 0;
            }
        }

        public uint Login(string uname, string pwd)
        {
            string docPath = @"registrations.txt";
            List<string> users = File.ReadAllLines(docPath).ToList();
            uint id = 0;
            foreach(string line in users)
            {
                string[] words = line.Split(new char[] { ' ' });
                id = Convert.ToUInt32(words[0]);
                string username = words[1];
                string password = words[2];
                if(username == uname && password == pwd)
                {
                    return id;
                }
            }
            return 0;
        }


        //User interface methods

        public void SelectUser(uint userID)
        {
            UserAccessInterface.SelectUser(userID);
        }
        public List<uint> GetUsers()
        {
            return UserAccessInterface.GetUsers();
        }

        public uint CreateUser()
        {
            uint id = 0;
            try
            {
                id = UserAccessInterface.CreateUser();
                bank.SaveToDisk();
                return id;
            }
            catch(Exception e)
            {
                Console.WriteLine("Unable to create user " + e);
            }
            return id;
        }

        public void GetUserName(out string fname, out string lname)
        {
            UserAccessInterface.GetUserName(out fname,out lname);
        }

        public void SetUserName(string fname, string lname)
        {
            try
            {
                UserAccessInterface.SetUserName(fname, lname);
                bank.SaveToDisk();
            }catch(Exception e)
            {
                Console.WriteLine("Unable to set user names " + e);
            }
 
        }

        //Transaction interface methods

        public void SelectTransaction(uint transID)
        {
            TransactionAccessInterface.SelectTransaction(transID);
        }

        public List<uint> GetTransactions()
        {
            return TransactionAccessInterface.GetTransactions();
        }

        public uint CreateTransaction()
        {
            uint id = 0;
            try
            {
                id = TransactionAccessInterface.CreateTransaction();
                bank.SaveToDisk();
                return id;
            }catch(Exception e)
            {
                Console.WriteLine("Unable to create acccount " + e);
            }
            return id;
        }

        public uint GetRecvrAcct()
        {
            uint id = 0;
            try
            {
                id = TransactionAccessInterface.GetRecvrAcct();
                return id;
            }
            catch (Exception e)
            {
                Console.WriteLine("Unable to get recievers account " + e);
            }
            return id;
        }

        public uint GetSendrAcct()
        {
            uint id = 0;
            try
            {
                id = TransactionAccessInterface.GetSendrAcct();
                return id;
            }
            catch (Exception e)
            {
                Console.WriteLine("Unable to get senders account " + e);
            }
            return id;
        }

        public void SetAmount(uint amount)
        {
            try
            {
                TransactionAccessInterface.SetAmount(amount);
                bank.SaveToDisk();
            }
            catch(Exception e)
            {
                Console.WriteLine("Unable to set amount " + e);
            }
            
        }
        public uint GetAmount()
        {
            uint amount = 0;
            try
            {
                amount = TransactionAccessInterface.GetAmount();
                return amount;
            }
            catch (Exception e)
            {
                Console.WriteLine("Could not get amount " + e);
            }
            return amount;
        }
        public void SetRecvr(uint accID)
        {
            try
            {
                TransactionAccessInterface.SetRecvr(accID);
                bank.SaveToDisk();
            }
            catch (Exception e)
            {
                Console.WriteLine("Unable to set reciever " + e);
            }
            
        }

        public void SetSendr(uint accID)
        {
            try
            {
                TransactionAccessInterface.SetSendr(accID);
                bank.SaveToDisk();
            }
            catch (Exception e)
            {
                Console.WriteLine("Unable to set sender " + e);
            }
        }

        
    }
}
