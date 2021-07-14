using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using System.Text;
using System.Threading.Tasks;

namespace BusinessTier
{
    [ServiceContract]
    public interface IBizTier
    {
        [OperationContract]
        void processAllTransacations();

        // User method
        [OperationContract]
        uint createUser(string fname, string lname, string uname, string pwd);

        [OperationContract]
        uint login(string uname, string pwd);

        [OperationContract]
        uint editUser(string fname, string lname, uint id);

        [OperationContract]
        void getNames(out string fname, out string lname);

        [OperationContract]
        List<uint> getUsers();
        //Account Methods

        [OperationContract]
        uint createAccount(uint userID);

        [OperationContract]
        List<uint> getAllAccounts(uint userID);

        [OperationContract]
        uint getBalance(uint accountID);

        [OperationContract]
        Boolean deposit(uint amount);

        [OperationContract]
        Boolean withdraw(uint amount);

        //Transaction Methods
        [OperationContract]
        uint createTrasaction(uint sendersAcc, uint recAcc, uint amount);

        [OperationContract]
        List<uint> getAllTransactions();

        [OperationContract]
        List<uint> getTransactionsForAccount(uint accountID);
    }
}
